// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Dispatcher
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
  public class Dispatcher
  {
    public string language_default_index = "";
    public string atual_version = "";
    public ArrayList my_threads = new ArrayList();
    public Translator var_Translator;

    public void ExecuteThreadTransaction(string TransactionLabel, int iPid, ref StreamWriter m_Log, ref Communication m_Comm, ref DB_Access m_my_access, string session)
    {
      thread_Dispatcher threadDispatcher = new thread_Dispatcher();
      this.my_threads.Add((object) this);
      Dispatcher disp = this;
      threadDispatcher.ExecuteTransaction(ref disp, TransactionLabel, iPid, ref m_Log, ref m_Comm, ref m_my_access, session);
    }

    public virtual void ExecuteTransaction(string TransactionLabel, int iPid, ref StreamWriter m_Log, ref Communication m_Comm, ref DB_Access m_my_access, string session)
    {
    }

    public string GetCurrentTime()
    {
      return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff") + " ";
    }
  }
}
