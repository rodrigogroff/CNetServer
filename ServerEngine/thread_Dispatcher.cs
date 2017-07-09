// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.thread_Dispatcher
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.IO;
using System.Threading;

namespace SyCrafEngine
{
  public class thread_Dispatcher
  {
    public string var_TransactionLabel = "";
    public string var_session = "";
    public Thread workThread;
    public Dispatcher var_m_disp;
    public StreamWriter var_m_Log;
    public Communication var_m_Comm;
    public DB_Access var_m_my_access;
    public int var_iPid;

    public void Exec()
    {
      this.var_m_disp.ExecuteTransaction(this.var_TransactionLabel, this.var_iPid, ref this.var_m_Log, ref this.var_m_Comm, ref this.var_m_my_access, this.var_session);
      this.var_m_Log.Close();
      this.var_m_my_access.CloseDB();
      string str = this.var_session.Replace(".wrk", "").Replace("\\Log_", "\\Log\\Log_");
      if (str.IndexOf("schedule_") >= 0)
        str = str.Replace("\\Log\\", "\\Log\\scheduler_log\\");
      if (File.Exists(str))
        File.Delete(str);
      File.Move(this.var_session, str);
      this.var_m_disp.my_threads.Remove((object) this);
    }

    public void ExecuteTransaction(ref Dispatcher disp, string TransactionLabel, int iPid, ref StreamWriter m_Log, ref Communication m_Comm, ref DB_Access m_my_access, string session)
    {
      this.var_m_disp = disp;
      this.var_TransactionLabel = TransactionLabel;
      this.var_iPid = iPid;
      this.var_m_Log = m_Log;
      this.var_m_Comm = m_Comm;
      this.var_m_my_access = m_my_access;
      this.var_session = session;
      this.workThread = new Thread(new ThreadStart(this.Exec));
      this.workThread.Start();
    }
  }
}
