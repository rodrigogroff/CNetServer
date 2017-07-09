// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.thread_Scheduler
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace SyCrafEngine
{
  public class thread_Scheduler : BasicExchange
  {
    public string var_path = "";
    public Thread workThread;
    public Dispatcher transactionDispatcher;
    public DB_Access scheduler_dbAccess;
    public FileStream logFile;
    public StreamWriter logStream;
    public CtrlStation i_ctrl;
    public NetworkStream netStreamStandBy;
    public bool IsDone;
    public int m_max_packet_size;

    public thread_Scheduler(ref CtrlStation ctrl)
    {
      this.i_ctrl = ctrl;
    }

    public void Setup()
    {
      string path = this.var_path + "\\scheduler.log";
      this.logFile = !File.Exists(path) ? new FileStream(path, FileMode.Create, FileAccess.Write) : new FileStream(path, FileMode.Append, FileAccess.Write);
      this.logStream = new StreamWriter((Stream) this.logFile);
      this.logStream.AutoFlush = true;
    }

    public void SchedulerLoop()
    {
      Communication m_Comm = new Communication();
      int num = 0;
      bool flag = true;
      do
      {
        if (DateTime.Now.Second > 1)
          flag = true;
        else if (DateTime.Now.Second == 1 && flag)
        {
          flag = false;
          this.logStream.WriteLine("");
          this.logStream.WriteLine("# Scheduler Starting: " + DateTime.Now.ToString());
          this.logStream.WriteLine("");
          this.transactionDispatcher.ExecuteTransaction("infra_SchedulerDispatcher", ++num, ref this.logStream, ref m_Comm, ref this.scheduler_dbAccess, this.var_path);
        }
        Thread.Sleep(1000);
        if (this.i_ctrl.StandByAlive)
        {
          try
          {
            this.WriteMsgToClient(ref this.netStreamStandBy, "STANDBYSQL_ALIVE");
            if (this.ReceiveMsgFromClient(ref this.netStreamStandBy, this.m_max_packet_size) != "STANDBYSQL_ACCEPTED")
              this.i_ctrl.StandByAlive = false;
          }
          catch (Exception ex)
          {
            ex.ToString();
            this.i_ctrl.StandByAlive = false;
          }
        }
      }
      while (this.i_ctrl.bPauseTraffic || !this.i_ctrl.bStopServer);
      this.logStream.Flush();
      this.logStream.Close();
      this.logFile.Close();
      this.workThread.Abort();
      this.IsDone = true;
    }
  }
}
