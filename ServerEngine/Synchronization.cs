// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Synchronization
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
  public class Synchronization : Generic
  {
    public string var_Tablename = "";
    public string var_Serial = "";
    public string var_Session = "";
    public string var_serialNumber = "";
    public ArrayList var_lstDistinct = new ArrayList();
    public Hashtable m_hshChangedFields = new Hashtable();
    public DataPortable uniqueResult = new DataPortable();
    private int m_iDefaultRetries = 9;
    private ArrayList m_lstUniqueSelect = new ArrayList();
    private ArrayList m_lstUniqueBloq = new ArrayList();
    private Hashtable m_hshRowRetry = new Hashtable();
    private Hashtable m_hshRowIndex = new Hashtable();
    protected string str_field_sep = "•";
    private Transaction m_trx = new Transaction();
    public const int UNLIMITED = 0;
    public int var_maxRowsRead;
    public int var_iPid;
    public bool var_InternalError;
    public Transaction var_Transaction;
    protected StreamWriter m_Log;
    private bool m_Lock;
    private bool IsBackupMode;
    private int m_iFetchRow;
    private bool IsReversed;
    private int iAttempt;

    public Synchronization()
    {
      this.IsBackupMode = true;
    }

    public void truncate()
    {
      this.m_gen_my_access.truncateTable(this.var_Tablename);
    }

    public void AcquireTransaction(ref Transaction trx)
    {
      this.m_trx = trx;
      this.SetAccess(ref trx.m_gen_my_access);
      this.SetLogAccess(ref trx.var_Log);
      this.var_iPid = trx.var_iPid;
      this.var_Session = trx.var_SessionKey;
      this.var_Transaction = trx;
      this.IsBackupMode = false;
      this.m_gen_my_access.m_lockArea.getUniqueSerial(ref this.var_serialNumber);
    }

    public void releaseSerial()
    {
      this.m_gen_my_access.m_lockArea.releaseSerial(this.var_serialNumber);
    }

    public int RowCount()
    {
      return this.m_db_result.GetRowCount();
    }

    public void SetReversedFetch()
    {
      this.IsReversed = true;
      this.m_iFetchRow = this.m_db_result.GetRowCount() - 1;
    }

    public void SetNormalFetch()
    {
      this.IsReversed = true;
    }

    public bool fetch()
    {
      if (!this.IsReversed)
      {
        int rowCount = this.m_db_result.GetRowCount();
        if (rowCount == 0 || this.m_iFetchRow == rowCount)
          return false;
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(this.m_iFetchRow++);
        this.fetchRetrieve(ref rowAtPosition);
      }
      else
      {
        if (this.m_iFetchRow < 0)
          return false;
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(this.m_iFetchRow--);
        this.fetchRetrieve(ref rowAtPosition);
      }
      return true;
    }

    public virtual void fetchRetrieve(ref DB_Row row)
    {
    }

    public void SetLogAccess(ref StreamWriter log)
    {
      this.m_Log = log;
    }

    public void ExclusiveAccess()
    {
      if (this.IsBackupMode)
        return;
      this.m_Lock = true;
      this.iAttempt = 0;
      this.var_Transaction.addSyncronization(this);
      if (!this.m_trx.SQL_LOGGING_ENABLE)
        return;
      this.m_Log.WriteLine(new StringBuilder().Append("Synchronize ").Append(this.GetCurrentTime()).Append(" ").Append(this.var_Transaction.var_Alias).Append(" ").Append("<").Append(this.var_Tablename).Append("> : ").Append(this.var_serialNumber).Append("  *** ExclusiveAccess Enabled ***").ToString());
    }

    public void ReleaseExclusive()
    {
      if (this.IsBackupMode || !this.m_Lock)
        return;
      ArrayList arrayList = new ArrayList();
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.GetCurrentTime());
      stringBuilder.Append(" ");
      stringBuilder.Append(this.var_Transaction.var_Alias);
      stringBuilder.Append(" <");
      stringBuilder.Append(this.var_Tablename);
      stringBuilder.Append("> : ");
      stringBuilder.Append(this.var_serialNumber);
      if (this.m_trx.SQL_LOGGING_ENABLE)
        this.m_Log.WriteLine("Synchronize " + stringBuilder.ToString() + " ReleaseExclusive");
      for (int index = 0; index < this.m_lstUniqueSelect.Count; ++index)
      {
        string lock_tag = this.m_lstUniqueSelect[index].ToString();
        if (this.m_trx.SQL_LOGGING_ENABLE)
          this.m_Log.WriteLine("Synchronize " + stringBuilder.ToString() + " unlocking " + lock_tag);
        this.m_gen_my_access.m_lockArea.releaseLock(lock_tag, this.var_serialNumber);
      }
      this.m_lstUniqueSelect.Clear();
      if (this.m_trx.SQL_LOGGING_ENABLE)
        this.m_Log.WriteLine("Synchronize " + stringBuilder.ToString() + " ReleaseExclusive Done");
      this.m_Lock = false;
    }

    public void StartUpdate()
    {
      this.m_gen_dbStatement.ClearAll();
      this.m_gen_dbStatement.SetMode(ENUM_DB_SQL_CMD.update);
      this.m_gen_dbStatement.SetFrom(this.var_Tablename);
      this.ExclusiveAccess();
    }

    public void StartDelete()
    {
      this.m_gen_dbStatement.ClearAll();
      this.m_gen_dbStatement.SetMode(ENUM_DB_SQL_CMD.delete);
      this.m_gen_dbStatement.SetFrom(this.var_Tablename);
    }

    public void StartInsert()
    {
      this.m_gen_dbStatement.ClearAll();
      this.m_gen_dbStatement.SetMode(ENUM_DB_SQL_CMD.insert);
      this.m_gen_dbStatement.SetFrom(this.var_Tablename);
    }

    public void StartSelect()
    {
      this.m_iFetchRow = 0;
      this.m_gen_dbStatement.var_maxRowsRead = this.var_maxRowsRead;
      this.m_gen_dbStatement.ClearAll();
      this.m_db_result.Clear();
      this.m_gen_dbStatement.SetMode(ENUM_DB_SQL_CMD.select);
      this.m_gen_dbStatement.SetFrom(this.var_Tablename);
    }

    public void SetCountMode()
    {
      this.m_gen_dbStatement.m_DB_SQL_CMD = ENUM_DB_SQL_CMD.select;
      this.m_gen_dbStatement.IsCount = true;
    }

    public void DisableCountMode()
    {
      this.m_gen_dbStatement.IsCount = false;
      this.m_gen_dbStatement.count_Value = 0L;
    }

    public long GetCount()
    {
      return this.m_gen_dbStatement.count_Value;
    }

    public long SelectCountAll()
    {
      string str = "select count(*) from " + this.var_Tablename;
      this.SetCountMode();
      this.GenerateLog(str);
      ArrayList ret_objection = new ArrayList();
      DateTime now = DateTime.Now;
      if (!this.ExecSelect(ref ret_objection, ref this.m_db_result, str))
      {
        for (int index = 0; index < ret_objection.Count; ++index)
          this.TraceLog(ret_objection[index].ToString());
        ret_objection.Clear();
        this.ReleaseExclusive();
        return 0;
      }
      TimeSpan timeSpan = now.Subtract(DateTime.Now);
      if (this.m_trx.SQL_LOGGING_ENABLE)
      {
        this.GenerateLog("# Time: " + (object) -timeSpan.TotalMilliseconds);
        this.GenerateLog("# Count: " + this.m_gen_dbStatement.count_Value.ToString());
      }
      return this.m_gen_dbStatement.count_Value;
    }

    public void SetDistinctMode(string field)
    {
      this.m_gen_dbStatement.IsDistinct = true;
      this.m_gen_dbStatement.m_Distinct = field;
      this.m_gen_dbStatement.var_distinct.Clear();
    }

    public void SetSumMode(string field)
    {
      this.m_gen_dbStatement.IsSum = true;
      this.m_gen_dbStatement.m_Distinct = field;
      this.m_gen_dbStatement.nu_sum = 0L;
    }

    public long GetSum()
    {
      return this.m_gen_dbStatement.nu_sum;
    }

    public void SelectDistinct(string field, ref ArrayList lst)
    {
      this.ReleaseExclusive();
      string str = "select distinct " + field + " from " + this.var_Tablename;
      this.m_gen_dbStatement.m_DB_SQL_CMD = ENUM_DB_SQL_CMD.select;
      this.m_gen_dbStatement.IsDistinct = true;
      this.m_gen_dbStatement.m_Distinct = field;
      this.m_gen_dbStatement.var_distinct.Clear();
      this.GenerateLog(str);
      ArrayList ret_objection = new ArrayList();
      DateTime now = DateTime.Now;
      if (!this.ExecSelect(ref ret_objection, ref this.m_db_result, str))
      {
        for (int index = 0; index < ret_objection.Count; ++index)
          this.TraceLog(ret_objection[index].ToString());
        ret_objection.Clear();
      }
      TimeSpan timeSpan = now.Subtract(DateTime.Now);
      if (this.m_trx.SQL_LOGGING_ENABLE)
      {
        this.GenerateLog("# Time: " + (object) -timeSpan.TotalMilliseconds);
        this.GenerateLog("# Count: " + this.m_gen_dbStatement.count_Value.ToString());
      }
      this.m_gen_dbStatement.IsDistinct = false;
      this.m_gen_dbStatement.m_Distinct = "";
      lst.AddRange((ICollection) this.m_gen_dbStatement.var_distinct);
    }

    public bool executeQuery()
    {
      string str = this.m_gen_dbStatement.ExportSQL();
      this.GenerateLog(str);
      ArrayList ret_objection = new ArrayList();
      DateTime now = DateTime.Now;
      if (!this.ExecSelect(ref ret_objection, ref this.m_db_result, str))
      {
        for (int index = 0; index < ret_objection.Count; ++index)
          this.TraceLog(ret_objection[index].ToString());
        ret_objection.Clear();
        this.ReleaseExclusive();
        return false;
      }
      if (!this.m_gen_dbStatement.IsCount && !this.m_gen_dbStatement.IsSum && (!this.m_gen_dbStatement.IsDistinct && !this.m_db_result.HasRows()) && this.m_trx.SQL_LOGGING_ENABLE)
        this.TraceLog(this.var_serialNumber + " # Warning: no rows selected!");
      if (this.m_gen_dbStatement.IsDistinct)
      {
        this.m_gen_dbStatement.IsDistinct = false;
        this.m_gen_dbStatement.m_Distinct = "";
      }
      if (this.m_gen_dbStatement.IsSum)
      {
        this.m_gen_dbStatement.IsSum = false;
        this.m_gen_dbStatement.m_Distinct = "";
      }
      if (this.m_gen_dbStatement.IsCount)
        this.m_gen_dbStatement.IsCount = false;
      TimeSpan timeSpan = now.Subtract(DateTime.Now);
      if (this.m_trx.SQL_LOGGING_ENABLE)
        this.GenerateLog("# Time: " + (object) -timeSpan.TotalMilliseconds);
      return true;
    }

    public bool HasRows()
    {
      if (this.m_gen_dbStatement.IsCount)
        return true;
      return this.m_db_result.HasRows();
    }

    public long SumAll(string field_tag)
    {
      long num = 0;
      for (int position = 0; position < this.m_db_result.GetRowCount(); ++position)
      {
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(position);
        try
        {
          num += Convert.ToInt64(rowAtPosition.GetField(field_tag));
        }
        catch (Exception ex)
        {
          ex.ToString();
          return 0;
        }
      }
      return num;
    }

    public int GetMin(string field_tag)
    {
      int num = 0;
      for (int position = 0; position < this.m_db_result.GetRowCount(); ++position)
      {
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(position);
        try
        {
          int int32 = Convert.ToInt32(rowAtPosition.GetField(field_tag).TrimStart('0').Trim());
          if (int32 < num)
            num = int32;
        }
        catch (Exception ex)
        {
          ex.ToString();
          return 0;
        }
      }
      return num;
    }

    public DateTime GetMinDate(string field_tag)
    {
      DateTime dateTime1 = DateTime.Now.AddYears(-100);
      for (int position = 0; position < this.m_db_result.GetRowCount(); ++position)
      {
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(position);
        try
        {
          DateTime dateTime2 = Convert.ToDateTime(rowAtPosition.GetField(field_tag));
          if (dateTime2 < dateTime1)
            dateTime1 = dateTime2;
        }
        catch (Exception ex)
        {
          ex.ToString();
          return DateTime.Now;
        }
      }
      return dateTime1;
    }

    public DateTime GetMaxDate(string field_tag)
    {
      DateTime dateTime1 = DateTime.Now;
      for (int position = 0; position < this.m_db_result.GetRowCount(); ++position)
      {
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(position);
        try
        {
          DateTime dateTime2 = Convert.ToDateTime(rowAtPosition.GetField(field_tag));
          if (dateTime2 > dateTime1)
            dateTime1 = dateTime2;
        }
        catch (Exception ex)
        {
          ex.ToString();
          return DateTime.Now;
        }
      }
      return dateTime1;
    }

    public int GetMax(string field_tag)
    {
      int num = 0;
      for (int position = 0; position < this.m_db_result.GetRowCount(); ++position)
      {
        DB_Row rowAtPosition = this.m_db_result.GetRowAtPosition(position);
        try
        {
          int int32 = Convert.ToInt32(rowAtPosition.GetField(field_tag));
          if (int32 > num)
            num = int32;
        }
        catch (Exception ex)
        {
          ex.ToString();
        }
      }
      return num;
    }

    public bool EndSelect()
    {
      if (this.IsBackupMode || !this.m_Lock)
        return true;
      bool flag = true;
      this.m_lstUniqueSelect.Clear();
      for (int position = 0; position < this.m_db_result.GetRowCount(); ++position)
      {
        string lock_tag = this.var_Tablename + this.m_db_result.GetRowAtPosition(position).GetField("i_unique");
        this.m_lstUniqueSelect.Add((object) lock_tag);
        bool lock_resp = false;
        this.m_gen_my_access.m_lockArea.setLock(lock_tag, this.var_serialNumber, ref lock_resp);
        if (!lock_resp)
        {
          this.TraceLog(this.var_serialNumber + " # EndSelect RETRY " + (object) this.iAttempt + " (index: " + lock_tag + " ) Waiting 200 miliseconds...");
          ++this.iAttempt;
          Thread.Sleep(200);
          if (this.iAttempt != this.m_iDefaultRetries)
            return false;
          this.TraceLog(this.var_serialNumber + " # EndSelect FAILURE (index: " + lock_tag + " )");
          break;
        }
        if (!flag)
        {
          this.ReleaseExclusive();
          this.m_db_result.Clear();
          return true;
        }
      }
      return true;
    }

    public string GetSelectField(string field)
    {
      return this.m_db_result.GetFirstRow().GetField(field);
    }

    protected bool Update()
    {
      if (this.m_gen_dbStatement.m_DB_SQL_CMD != ENUM_DB_SQL_CMD.update)
      {
        this.TraceLog(this.var_serialNumber + " ##### INFRA ERROR : Update Command not set properly!");
        this.ReleaseExclusive();
        return false;
      }
      string str = this.m_gen_dbStatement.ExportSQL();
      this.GenerateLog(str);
      ArrayList ret_objection = new ArrayList();
      DateTime now = DateTime.Now;
      if (!this.m_gen_my_access.ExecCommand(str, ref ret_objection))
      {
        for (int index = 0; index < ret_objection.Count; ++index)
          this.TraceLog(ret_objection[index].ToString());
        ret_objection.Clear();
        this.ReleaseExclusive();
        return false;
      }
      TimeSpan timeSpan = now.Subtract(DateTime.Now);
      if (this.m_trx.SQL_LOGGING_ENABLE)
        this.GenerateLog("# Time: " + (object) -timeSpan.TotalMilliseconds);
      this.m_hshChangedFields.Clear();
      this.ReleaseExclusive();
      return true;
    }

    public bool Execute()
    {
      if (this.m_gen_dbStatement.m_DB_SQL_CMD != ENUM_DB_SQL_CMD.insert && this.m_gen_dbStatement.m_DB_SQL_CMD != ENUM_DB_SQL_CMD.delete)
      {
        this.TraceLog(this.var_serialNumber + " ##### INFRA ERROR : Command not set properly!");
        return false;
      }
      string str = this.m_gen_dbStatement.ExportSQL();
      this.GenerateLog(str);
      ArrayList ret_objection = new ArrayList();
      DateTime now = DateTime.Now;
      if (!this.m_gen_my_access.ExecCommand(str, ref ret_objection))
      {
        for (int index = 0; index < ret_objection.Count; ++index)
          this.TraceLog(ret_objection[index].ToString());
        ret_objection.Clear();
        return false;
      }
      TimeSpan timeSpan = now.Subtract(DateTime.Now);
      if (this.m_trx.SQL_LOGGING_ENABLE)
        this.GenerateLog("# Time: " + (object) -timeSpan.TotalMilliseconds);
      return true;
    }

    public bool ExecuteScalar(ref string unique)
    {
      if (this.m_gen_dbStatement.m_DB_SQL_CMD != ENUM_DB_SQL_CMD.insert)
      {
        this.TraceLog(this.var_serialNumber + " ##### INFRA ERROR : Scalar Command not set properly!");
        return false;
      }
      string str = this.m_gen_dbStatement.ExportSQL();
      this.GenerateLog(str);
      ArrayList ret_objection = new ArrayList();
      DateTime now = DateTime.Now;
      if (!this.m_gen_my_access.ExecScalarCommand(str, ref ret_objection, ref this.var_Tablename, ref unique))
      {
        for (int index = 0; index < ret_objection.Count; ++index)
          this.TraceLog(ret_objection[index].ToString());
        ret_objection.Clear();
        return false;
      }
      TimeSpan timeSpan = now.Subtract(DateTime.Now);
      if (this.m_trx.SQL_LOGGING_ENABLE)
        this.GenerateLog("# Time: " + (object) -timeSpan.TotalMilliseconds);
      return true;
    }

    public string GetDataBaseTime()
    {
      return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public string ConvertTime(string time)
    {
      return Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss");
    }

    public string ConvertMoney(string val)
    {
      return new money().formatToMoney(val);
    }

    public string GetCurrentTicks()
    {
      return Convert.ToString(DateTime.Now.Hour * 360000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);
    }

    public string GetCurrentTime()
    {
      return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff") + " ";
    }

    private void GenerateLog(string buffer)
    {
      if (this.IsBackupMode || !this.m_trx.SQL_LOGGING_ENABLE)
        return;
      this.m_Log.WriteLine(new StringBuilder().Append("Synchronize ").Append(this.GetCurrentTime()).Append(" ").Append(this.var_Transaction.var_Alias).Append(" ").Append(this.var_serialNumber).Append(" SQL: ").Append(buffer).ToString());
    }

    public void TraceLog(string buffer)
    {
      if (this.IsBackupMode || !this.m_trx.SQL_LOGGING_ENABLE)
        return;
      this.m_Log.WriteLine(new StringBuilder().Append("Synchronize ").Append(this.GetCurrentTime()).Append(" ").Append(this.var_Transaction.var_Alias).Append(" ").Append(buffer).ToString());
    }
  }
}
