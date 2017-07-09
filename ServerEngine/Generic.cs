// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Generic
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Collections;
using System.Threading;

namespace SyCrafEngine
{
  public class Generic
  {
    public DB_Statement m_gen_dbStatement = new DB_Statement();
    public DB_Result m_db_result = new DB_Result();
    public DB_Access m_gen_my_access;
    public bool KeepNames;

    public void SetAccess(ref DB_Access access)
    {
      this.m_gen_my_access = access;
    }

    public void DelayProcess(int miliseconds)
    {
      Thread.Sleep(miliseconds);
    }

    public bool ExecSelect(ref ArrayList ret_objection, ref DB_Result db_res, string sql)
    {
      if (this.m_gen_my_access == null)
      {
        ret_objection.Add((object) "Generic::ExecSelect::DataBase not set");
        return false;
      }
      this.m_gen_dbStatement.KeepNames = this.KeepNames;
      if (this.m_gen_dbStatement.m_DB_SQL_CMD == ENUM_DB_SQL_CMD.select)
        return this.m_gen_my_access.SelectCommand(sql, ref ret_objection, ref this.m_gen_dbStatement, ref db_res);
      ret_objection.Add((object) "Generic::ExecSelect::m_DB_SQL_CMD != ENUM_DB_SQL_CMD.select");
      return false;
    }
  }
}
