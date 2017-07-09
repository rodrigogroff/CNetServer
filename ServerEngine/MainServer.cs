// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.MainServer
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace SyCrafEngine
{
  public class MainServer : BasicExchange
  {
    private string m_engineVersion = "";
    private string m_connectionString = "";
    private string m_master_server = "";
    private string m_master_server_port = "";
    private string m_db_machine = "";
    private string m_schema = "";
    private string my_db = "";
    private string m_var_path = "";
    private string m_fail_fs = "";
    public ConnectionMonitor i_monConnections;
    public LoadMonitor i_monDataLoad;
    public CPU_Monitor i_monCpu;
    public CtrlStation i_ctrl;
    private LockArea lockArea;
    private ArrayList lstClients;
    private Dispatcher transactionDispatcher;
    private CustomRecept recept;
    private int m_clientServerPort;
    private int m_max_packet_size;
    private thread_Scheduler thr_scheduler;
    private Translator var_translator;
    private FileStream failSafeFile;
    private StreamWriter failSafe;
    private bool MasterMode;
    private bool StandbyControlMode;
    private NetworkStream netStreamStandBy;
    private TcpClient tcpClientStandBy;

    public MainServer(string engineVersion, string master_server, string master_server_port, string connectionString, string DB_Machine, string language, string schema, int clientServerPort, int max_packet_size, ref ConnectionMonitor mon, ref LoadMonitor ldl, ref CPU_Monitor cpu, ref CtrlStation ctrl, Dispatcher transDisp, string db, string var_path, CustomRecept var_recept, ref Translator translator, string standby_server, string standby_server_web, string standby_server_port, string fail_fs, bool master_srv)
    {
      this.MasterMode = master_srv;
      this.i_monConnections = mon;
      this.i_monDataLoad = ldl;
      this.i_monCpu = cpu;
      this.i_ctrl = ctrl;
      this.var_translator = translator;
      this.recept = var_recept;
      if (!Directory.Exists(var_path + "\\LOG"))
        Directory.CreateDirectory(var_path + "\\LOG");
      this.m_var_path = var_path;
      this.transactionDispatcher = transDisp;
      this.transactionDispatcher.language_default_index = language;
      this.m_engineVersion = engineVersion;
      this.m_master_server = master_server;
      this.m_master_server_port = master_server_port;
      this.m_connectionString = connectionString;
      this.m_db_machine = DB_Machine;
      this.m_schema = schema;
      this.m_clientServerPort = clientServerPort;
      this.m_max_packet_size = max_packet_size;
      this.my_db = db;
      this.m_fail_fs = fail_fs;
      if (this.m_fail_fs == "")
        this.m_fail_fs = var_path + "\\failSafe.SQL";
      else if ((int) this.m_fail_fs[this.m_fail_fs.Length - 1] != 92)
        this.m_fail_fs += "\\failSafe.SQL";
      else
        this.m_fail_fs += "failSafe.SQL";
      this.failSafeFile = !File.Exists(this.m_fail_fs) ? new FileStream(this.m_fail_fs, FileMode.Create, FileAccess.Write) : new FileStream(this.m_fail_fs, FileMode.Truncate, FileAccess.Write);
      this.failSafe = new StreamWriter((Stream) this.failSafeFile);
      this.failSafe.AutoFlush = true;
      if (this.MasterMode && standby_server.Length > 0)
      {
        this.i_ctrl.standby_server = standby_server;
        this.i_ctrl.standby_server_web = standby_server_web;
        this.i_ctrl.standby_server_port = Convert.ToInt32(standby_server_port);
        try
        {
          this.tcpClientStandBy = new TcpClient(standby_server, Convert.ToInt32(standby_server_port));
          this.netStreamStandBy = this.tcpClientStandBy.GetStream();
          if (this.WriteMsgToClient(ref this.netStreamStandBy, "STANDBYSQL_ALIVE"))
          {
            if (this.ReceiveMsgFromClient(ref this.netStreamStandBy, this.m_max_packet_size) != "STANDBYSQL_ACCEPTED")
            {
              this.tcpClientStandBy.Close();
              this.netStreamStandBy.Close();
            }
            else
              ctrl.StandByAlive = true;
          }
        }
        catch (ArgumentNullException ex)
        {
          ex.ToString();
        }
        catch (ArgumentOutOfRangeException ex)
        {
          ex.ToString();
        }
        catch (SocketException ex)
        {
          ex.ToString();
        }
        catch (Exception ex)
        {
          ex.ToString();
        }
      }
      this.lockArea = new LockArea();
      this.lstClients = new ArrayList();
      if (this.MasterMode)
        this.createScheduler();
      this.StartServer();
    }

    private void createScheduler()
    {
      try
      {
        this.thr_scheduler = new thread_Scheduler(ref this.i_ctrl);
        this.thr_scheduler.transactionDispatcher = this.transactionDispatcher;
        this.thr_scheduler.var_path = this.m_var_path;
        this.thr_scheduler.netStreamStandBy = this.netStreamStandBy;
        this.thr_scheduler.m_max_packet_size = this.m_max_packet_size;
        this.thr_scheduler.scheduler_dbAccess = new DB_Access(this.m_connectionString, ref this.lockArea, ref this.i_monCpu, ref this.i_ctrl, true);
        this.thr_scheduler.scheduler_dbAccess.failSafe_archive = this.m_fail_fs;
      }
      catch (Exception ex)
      {
        this.i_ctrl.bServerLoaded = false;
        this.i_ctrl.genericErrorMsg = ex.Message;
        this.i_ctrl.displayError();
        this.TermServer();
        return;
      }
      this.StartScheduler();
    }

    private void StartScheduler()
    {
      this.thr_scheduler.workThread = new Thread(new ThreadStart(this.thr_scheduler.SchedulerLoop));
      this.thr_scheduler.Setup();
      this.thr_scheduler.workThread.Start();
    }

    private void StartServer()
    {
      this.i_ctrl.tcpServerListener = new TcpListener(this.m_clientServerPort);
      this.i_ctrl.genericErrorMsg = "";
      int num = 0;
      this.i_ctrl.bServerLoaded = true;
      while (!this.i_ctrl.bStopServer)
      {
        Thread.Sleep(1);
        Socket socket = (Socket) null;
        if (this.lstClients.Count < this.i_ctrl.maxThreads)
        {
          if (!this.MasterMode && !this.i_ctrl.ServingStandBy && !this.StandbyControlMode)
          {
            this.MasterMode = true;
            this.StandbyControlMode = true;
            this.createScheduler();
          }
          if (!this.i_ctrl.bPauseTraffic)
          {
            try
            {
              this.i_ctrl.tcpServerListener.Start();
              socket = this.i_ctrl.tcpServerListener.AcceptSocket();
            }
            catch (SocketException ex)
            {
              ex.ToString();
            }
            catch (IOException ex)
            {
              ex.ToString();
            }
            catch (Exception ex)
            {
              ex.ToString();
            }
            if (!this.i_ctrl.bStopServer)
            {
              if (!this.i_ctrl.bPauseTraffic)
              {
                ServerNewConnInfo info = new ServerNewConnInfo();
                info.serverSocket = socket;
                try
                {
                  info.path = this.m_var_path + "\\Log_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + "_" + (++num).ToString().PadLeft(7, '0') + ".txt.wrk";
                  info.logFile = !File.Exists(info.path) ? new FileStream(info.path, FileMode.Create, FileAccess.Write) : new FileStream(info.path, FileMode.Truncate, FileAccess.Write);
                  info.logStream = new StreamWriter((Stream) info.logFile);
                  info.logStream.AutoFlush = true;
                  info.logStream.WriteLine("");
                  info.logStream.WriteLine("============================================");
                  info.logStream.WriteLine("# ");
                  info.logStream.WriteLine("# Welcome to SyCraf Server Log. (Master Server)");
                  info.logStream.WriteLine("# " + DateTime.Now.ToString());
                  info.logStream.WriteLine("# ");
                  info.logStream.WriteLine("============================================");
                  DataServer server = new DataServer(ref info.logStream, ref this.i_monDataLoad, ref new DB_Access(this.m_connectionString, ref this.lockArea, ref this.i_monCpu, ref this.i_ctrl, false)
                  {
                    failSafe_archive = this.m_fail_fs
                  });
                  this.lstClients.Add((object) info);
                  this.i_monConnections.NewConnection();
                  info.iPid = num;
                  info.engine_version = this.m_engineVersion;
                  info.db_machine = this.m_db_machine;
                  info.schema = this.m_schema;
                  info.master_server = this.m_master_server;
                  info.master_server_port = this.m_master_server_port;
                  CPU_Timer cpuTimer = new CPU_Timer();
                  this.i_monCpu.AddTimer(ref cpuTimer, Convert.ToString(info.iPid));
                  info.serverSockStream = new NetworkStream(info.serverSocket);
                  info.serverThread = new ServerThread(ref info, ref server, ref cpuTimer, ref this.i_monConnections, ref info.logStream, this.m_max_packet_size, ref this.i_ctrl, ref this.recept, ref this.var_translator, ref this.lstClients);
                  info.workThread = new Thread(new ThreadStart(info.serverThread.ServerLoop));
                  server.SetTransactionDispatcher(this.transactionDispatcher);
                  info.workThread.Start();
                }
                catch (Exception ex)
                {
                  this.i_ctrl.bServerLoaded = false;
                  this.i_ctrl.genericErrorMsg = ex.Message;
                  this.i_ctrl.tcpServerListener.Stop();
                  this.i_ctrl.displayError();
                  socket.Close();
                  break;
                }
              }
            }
            else
              break;
          }
        }
      }
      this.TermServer();
    }

    private void TermServer()
    {
      for (int index = 0; index < this.lstClients.Count; ++index)
      {
        ServerNewConnInfo lstClient = this.lstClients[index] as ServerNewConnInfo;
        lstClient.serverSocket.Close();
        lstClient.serverThread.StopProcess();
        this.i_monCpu.RemoveTimer(Convert.ToString(lstClient.iPid));
      }
      this.lstClients.Clear();
      this.i_ctrl.bStopServer = true;
      if (!this.MasterMode)
        return;
      this.thr_scheduler.workThread.Abort();
      this.failSafe.Close();
      this.failSafeFile.Close();
      if (!this.i_ctrl.StandByAlive)
        return;
      this.netStreamStandBy.Close();
      this.tcpClientStandBy.Close();
    }
  }
}
