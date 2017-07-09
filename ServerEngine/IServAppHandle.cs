// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.IServAppHandle
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Collections;
using System.Threading;

namespace SyCrafEngine
{
  public class IServAppHandle
  {
    private CtrlStation m_ctrl = new CtrlStation();
    private ConnectionMonitor m_mon = new ConnectionMonitor();
    private LoadMonitor m_ldl = new LoadMonitor();
    private CPU_Monitor m_cpu = new CPU_Monitor();
    private string path = "";
    public string m_engineVersion = "1080";
    public string m_connectionString = "";
    public string m_DB_Machine = "";
    public string m_language = "";
    public string m_schema = "";
    public string m_master_server = "";
    public string m_master_server_port = "";
    public string m_db = "";
    public string m_standby_server = "";
    public string m_standby_server_web = "";
    public string m_standby_server_port = "";
    public string m_fail_fs = "";
    private MainServer m_mainServer;
    private Thread m_workThread;
    public int m_clientServerPort;
    public int m_max_packet_size;
    public Dispatcher m_transDisp;
    public CustomRecept m_recept;
    public Translator var_translator;

    public IServAppHandle(string var_path, ref Translator trans)
    {
      this.path = var_path;
      this.m_mon.path = this.path;
      this.m_ldl.path = this.path;
      this.m_cpu.path = this.path;
      this.var_translator = trans;
    }

    public int getMaxThreads()
    {
      return this.m_ctrl.maxThreads;
    }

    public void setMaxThreads(int num)
    {
      this.m_ctrl.maxThreads = num;
    }

    public void SetConsoleMode()
    {
      this.m_ctrl.bConsoleMode = true;
    }

    public void RunMasterThread(bool master_srv)
    {
      this.m_ctrl.genericErrorMsg = "";
      this.m_workThread = !master_srv ? new Thread(new ThreadStart(this.cmd_Standby)) : new Thread(new ThreadStart(this.cmd_Start));
      this.m_workThread.Start();
    }

    public void RunSlaveThread()
    {
      this.m_ctrl.genericErrorMsg = "";
      this.m_workThread = new Thread(new ThreadStart(this.cmd_Slave));
      this.m_workThread.Start();
    }

    public bool cmd_Quit()
    {
      if (!this.Is_ServerLoaded())
      {
        this.m_mon.StopMonit();
        this.m_cpu.StopMonit();
        this.m_ldl.StopMonit();
        return true;
      }
      this.m_ctrl.bStopServer = true;
      this.m_ctrl.tcpServerListener.Stop();
      this.m_mon.StopMonit();
      this.m_cpu.StopMonit();
      this.m_ldl.StopMonit();
      this.m_workThread.Abort();
      this.m_ctrl.bServerLoaded = false;
      return true;
    }

    public void cmd_Start()
    {
      if (this.Is_ServerLoaded())
        return;
      this.m_mon.bStopMonitoring = false;
      this.m_cpu.bStopMonitoring = false;
      this.m_ldl.bStopMonitoring = false;
      this.m_mainServer = new MainServer(this.m_engineVersion, "", "", this.m_connectionString, this.m_DB_Machine, this.m_language.ToString(), this.m_schema, this.m_clientServerPort, this.m_max_packet_size, ref this.m_mon, ref this.m_ldl, ref this.m_cpu, ref this.m_ctrl, this.m_transDisp, this.m_db, this.path, this.m_recept, ref this.var_translator, this.m_standby_server, this.m_standby_server_web, this.m_standby_server_port, this.m_fail_fs, true);
    }

    public void cmd_Standby()
    {
      if (this.Is_ServerLoaded())
        return;
      this.m_mon.bStopMonitoring = false;
      this.m_cpu.bStopMonitoring = false;
      this.m_ldl.bStopMonitoring = false;
      this.m_mainServer = new MainServer(this.m_engineVersion, "", "", this.m_connectionString, this.m_DB_Machine, this.m_language.ToString(), this.m_schema, this.m_clientServerPort, this.m_max_packet_size, ref this.m_mon, ref this.m_ldl, ref this.m_cpu, ref this.m_ctrl, this.m_transDisp, this.m_db, this.path, this.m_recept, ref this.var_translator, this.m_standby_server, this.m_standby_server_web, this.m_standby_server_port, this.m_fail_fs, false);
    }

    public void cmd_Slave()
    {
    }

    public bool Is_StartupError()
    {
      return this.m_ctrl.bStartupError;
    }

    public string getErrorMsg()
    {
      return this.m_ctrl.genericErrorMsg;
    }

    public int getAliveConnections()
    {
      return this.m_mon.getAliveConnections();
    }

    public int getMasterNodesCount()
    {
      return this.m_ctrl.m_lstServerNodes.Count;
    }

    public void getMasterNodesList(ref ArrayList rec)
    {
      rec = this.m_ctrl.m_lstServerNodes;
    }

    public void getLastestConnections(int count, ref ArrayList results)
    {
      this.m_mon.getLatestConns(count, ref results);
    }

    public void getLastestLoads(int count, ref ArrayList results)
    {
      this.m_ldl.getLatestLoads(count, ref results);
    }

    public void getLastestCpuLoads(int count, ref ArrayList results)
    {
      this.m_cpu.getLatestCpuLoads(count, ref results);
    }

    public int getTotalConnections()
    {
      return this.m_mon.getTotalConnections();
    }

    public bool Is_PauseTraffic()
    {
      return this.m_ctrl.bPauseTraffic;
    }

    public bool Is_StopServer()
    {
      return this.m_ctrl.bStopServer;
    }

    public bool Is_ServerLoaded()
    {
      return this.m_ctrl.bServerLoaded;
    }

    public bool Is_StandByAvailable()
    {
      return this.m_ctrl.StandByAlive;
    }

    public bool Is_ServingStandBy()
    {
      return this.m_ctrl.ServingStandBy;
    }

    public void cmd_Pause()
    {
      this.m_ctrl.bPauseTraffic = true;
      this.m_ctrl.tcpServerListener.Stop();
    }

    public void cmd_Release()
    {
      this.m_ctrl.bPauseTraffic = false;
    }

    public static string getConnString(string DB_Machine, string database, string user, string password, int port, int db_choice)
    {
      string str1 = "" + "DRIVER={MySQL ODBC 3.51 Driver}" + ";SERVER=" + DB_Machine;
      if (database != "")
        str1 = str1 + ";DATABASE=" + database;
      string str2 = str1 + ";UID=" + user + ";PASSWORD=" + password + ";port=" + (object) port + ";OPTION=3";
      string str3 = "" + "Driver={SQL Server};Server=" + DB_Machine;
      if (database != "")
        str3 = str3 + ";Database=" + database;
      string str4 = str3 + ";Uid=" + user + ";Pwd=" + password + ";";
      switch (db_choice)
      {
        case 0:
          return str2;
        case 1:
          return str4;
        default:
          return "";
      }
    }
  }
}
