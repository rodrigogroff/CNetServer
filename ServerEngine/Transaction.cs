// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Transaction
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;

namespace SyCrafEngine
{
  public class Transaction : Generic
  {
    public string var_default_language = "";
    public string var_Alias = "";
    public string var_SessionKey = "";
    public string var_Ticket = "";
    public Hashtable ut_call = new Hashtable();
    public ArrayList objection = new ArrayList();
    protected ArrayList synchList = new ArrayList();
    public bool SQL_LOGGING_ENABLE = true;
    public Communication var_Comm;
    public StreamWriter var_Log;
    public Translator var_Translator;
    public Dispatcher var_disp;
    public int var_iPid;
    public int ut_max;
    public bool ut_enabled;
    public int ut_abort;
    public bool remoteTransaction;
    public bool IsFail;
    private Transaction old_trx;

    public Transaction()
    {
    }

    public Transaction(Transaction trx)
    {
      this.remoteTransaction = true;
      this.old_trx = trx;
      this.var_iPid = trx.var_iPid;
      this.var_Translator = trx.var_Translator;
      this.SetSessionKey(trx.var_SessionKey);
      this.SetLogAccess(ref trx.var_Log);
      this.SetAccess(ref trx.m_gen_my_access);
      this.SetCommunication(ref trx.var_Comm);
    }

    public string GetDataBaseTime()
    {
      return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public string GetDataBaseTime(DateTime tim)
    {
      return tim.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public string GetTodayStartTime()
    {
      return this.GetDataBaseTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
    }

    public string GetTodayEndTime()
    {
      return this.GetDataBaseTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1.0));
    }

    public string GetMonthStartTime()
    {
      return this.GetDataBaseTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
    }

    public string GetMonthEndTime()
    {
      return this.GetDataBaseTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1));
    }

    public void ut_coverMark(int pos)
    {
      if (!this.ut_enabled)
        return;
      this.ut_call[(object) pos] = (object) pos;
    }

    public void ut_coverMark(int pos, string unique_alias)
    {
      if (!this.ut_enabled || !(unique_alias == this.var_Alias))
        return;
      this.ut_call[(object) pos] = (object) pos;
    }

    public void ut_abortTest(int pos)
    {
      if (this.ut_enabled && this.ut_abort == pos)
        throw new Exception("ABORT");
    }

    public DataPortable MemoryGet(string tag)
    {
      return this.m_gen_my_access.MemoryGet(tag);
    }

    public string MemorySave(ref DataPortable content)
    {
      this.m_gen_my_access.MemorySave((++this.m_gen_my_access.st_rand).ToString(), ref content);
      return this.m_gen_my_access.st_rand.ToString();
    }

    public void MemoryClean()
    {
      this.m_gen_my_access.MemoryClean();
    }

    public void SetCommunication(ref Communication com)
    {
      this.var_Comm = com;
    }

    public void SetSessionKey(string key)
    {
      this.var_SessionKey = key;
    }

    public void SetLogAccess(ref StreamWriter log)
    {
      this.var_Log = log;
    }

    public void PublishError(string err)
    {
      if (this.objection.Count != 0)
        return;
      this.var_Log.WriteLine(new StringBuilder().Append("Transaction ").Append(this.GetDataBaseTime()).Append(" ").Append(this.var_Alias).Append(" ##### OBJECTION: *ERR <").Append(err).Append(">").ToString());
      this.objection.Add((object) ("ServerSystem.Error," + err));
    }

    public void PublishNote(string note)
    {
      this.var_Log.WriteLine(new StringBuilder().Append("Transaction ").Append(this.GetDataBaseTime()).Append(" ").Append(this.var_Alias).Append(" >>>>> OBJECTION: *WAR <").Append(note).Append(">").ToString());
      this.objection.Add((object) ("ServerSystem.Warning," + note));
    }

    public void Trace(string info)
    {
      this.var_Log.WriteLine(new StringBuilder().Append("Transaction ").Append(this.GetDataBaseTime()).Append(" ").Append(this.var_Alias).Append(" ### TRACE: >>").Append(info).Append("<<").ToString());
    }

    public void Registry(string info)
    {
      this.var_Log.WriteLine(new StringBuilder().Append("Transaction ").Append(this.GetDataBaseTime()).Append(" ").Append(this.var_Alias).Append(" * ").Append(info).ToString());
    }

    public bool TimeSpanCtrl(string time, TSpan_Mode mode, double argument, TSpan_Range range)
    {
      try
      {
        TimeSpan timeSpan = DateTime.Parse(time).Subtract(DateTime.Now);
        double num = 0.0;
        switch (range)
        {
          case TSpan_Range.Days:
            num = -timeSpan.TotalDays;
            break;
          case TSpan_Range.Hours:
            num = -timeSpan.TotalHours;
            break;
          case TSpan_Range.Minutes:
            num = -timeSpan.TotalMinutes;
            break;
          case TSpan_Range.Seconds:
            num = -timeSpan.TotalSeconds;
            break;
          case TSpan_Range.MiliSecs:
            num = -timeSpan.TotalMilliseconds;
            break;
        }
        switch (mode)
        {
          case TSpan_Mode.LESS_THAN:
            if (num < argument)
              return true;
            break;
          case TSpan_Mode.MORE_THAN:
            if (num > argument)
              return true;
            break;
          case TSpan_Mode.EQUALS:
            if (num == 0.0)
              return true;
            break;
        }
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }
      return false;
    }

    public void addSyncronization(Synchronization sync)
    {
      if (this.synchList.Contains((object) sync))
        return;
      this.synchList.Add((object) sync);
    }

    public void copyObjections(ref Transaction trx)
    {
      for (int index = 0; index < trx.objection.Count; ++index)
      {
        Thread.Sleep(1);
        this.objection.Add((object) trx.objection[index].ToString());
      }
    }

    public void endTransaction()
    {
      if (this.synchList.Count <= 0)
        return;
      this.Registry("releaseSynch " + this.var_Alias);
      for (int index = 0; index < this.synchList.Count; ++index)
      {
        Synchronization synch = this.synchList[index] as Synchronization;
        if (synch != null)
        {
          synch.ReleaseExclusive();
          synch.releaseSerial();
        }
      }
      this.synchList.Clear();
      this.Registry("releaseSynch Done " + this.var_Alias);
    }

    public virtual void constructor()
    {
    }

    public virtual bool setup()
    {
      return true;
    }

    public virtual bool saveInputTicket()
    {
      return true;
    }

    public virtual bool authenticate()
    {
      return true;
    }

    public virtual bool execute()
    {
      return true;
    }

    public virtual bool finish()
    {
      return true;
    }

    public virtual bool saveOutputTicket()
    {
      return true;
    }

    public bool TerminateTransaction()
    {
      if (!this.finish())
        this.PublishError(this.var_Translator.GetMsg(this.var_default_language, "ServerSystem.InternalError"));
      return this.remoteTransaction ? true : true;
    }

    public bool TerminateOnlineTransaction()
    {
      this.finish();
      this.endTransaction();
      return true;
    }

    public void sendObjections(ref ArrayList dest)
    {
      dest.Clear();
      for (int index = 0; index < this.objection.Count; ++index)
      {
        Thread.Sleep(1);
        dest.Add((object) this.objection[index].ToString());
      }
      this.objection.Clear();
    }

    public bool Run()
    {
      try
      {
        this.objection.Clear();
        this.synchList.Clear();
        Thread.Sleep(1);
        this.Registry("Starting: " + this.var_Alias);
        this.var_Comm.ReceiveObjections(ref this.objection);
        if (!this.setup())
        {
          this.IsFail = true;
          this.PublishError(this.var_Translator.GetMsg(this.var_default_language, "ServerSystem.InternalError"));
          this.TerminateTransaction();
          return false;
        }
        Thread.Sleep(1);
        if (!this.authenticate())
        {
          this.IsFail = true;
          this.PublishError(this.var_Translator.GetMsg(this.var_default_language, "ServerSystem.InternalError"));
          this.TerminateTransaction();
          return false;
        }
        Thread.Sleep(1);
        if (!this.execute())
        {
          this.IsFail = true;
          this.PublishError(this.var_Translator.GetMsg(this.var_default_language, "ServerSystem.InternalError"));
          this.TerminateTransaction();
          return false;
        }
        Thread.Sleep(1);
        if (!this.TerminateTransaction())
          return false;
        this.var_Comm.m_TransactionSucessfull = true;
        return true;
      }
      catch (Exception ex)
      {
        this.Registry(ex.ToString());
        this.Registry("*ERR - critical system exception occured ");
        this.TerminateTransaction();
        return false;
      }
    }

    public bool RunOnline()
    {
      try
      {
        this.objection.Clear();
        this.synchList.Clear();
        Thread.Sleep(1);
        this.Registry("Starting: " + this.var_Alias);
        Thread.Sleep(1);
        if (!this.authenticate())
        {
          this.IsFail = true;
          this.TerminateOnlineTransaction();
          return false;
        }
        Thread.Sleep(1);
        if (!this.execute())
        {
          this.IsFail = true;
          this.TerminateOnlineTransaction();
          return false;
        }
        Thread.Sleep(1);
        if (!this.TerminateOnlineTransaction())
          return false;
        this.var_Comm.m_TransactionSucessfull = true;
        for (int index = 0; index < this.objection.Count; ++index)
          this.old_trx.objection.Add((object) this.objection[index].ToString());
        return true;
      }
      catch (Exception ex)
      {
        this.Registry("System.Exception: " + ex.ToString());
        this.TerminateOnlineTransaction();
        return false;
      }
    }
  }
}
