// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DB_Access
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.Data;
using System.Data.Odbc;
using System.Net.Sockets;

namespace SyCrafEngine
{
  public class DB_Access : BasicExchange
  {
    public Hashtable hsh_DataSave = new Hashtable();
    public string MyconnString = "";
    public string failSafe_archive = "";
    public LockArea m_lockArea;
    public CPU_Monitor i_monCpu;
    public CtrlStation i_ctrl;
    public OdbcConnection MyConnection;
    public bool IsBackup;
    public TcpClient tcpClientStandBy;
    public NetworkStream netStreamStandBy;
    public long st_rand;
    private bool disableStandBy;

    public DB_Access(ref DB_Access ac)
    {
      this.i_monCpu = ac.i_monCpu;
      this.MyconnString = ac.MyconnString;
      this.i_ctrl = ac.i_ctrl;
      this.failSafe_archive = ac.failSafe_archive;
      if (this.i_ctrl.StandByAlive)
      {
        this.tcpClientStandBy = new TcpClient(this.i_ctrl.standby_server, this.i_ctrl.standby_server_port);
        this.netStreamStandBy = this.tcpClientStandBy.GetStream();
      }
      this.MyConnection = new OdbcConnection(this.MyconnString);
      try
      {
        this.MyConnection.Open();
        this.setDateFormat();
      }
      catch (OdbcException ex)
      {
        throw new Exception(ex.Message);
      }
      this.m_lockArea = ac.m_lockArea;
    }

    public DB_Access(string connString)
    {
      this.IsBackup = true;
      this.MyconnString = connString;
      this.MyConnection = new OdbcConnection(connString);
      try
      {
        this.MyConnection.Open();
        this.setDateFormat();
      }
      catch (OdbcException ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public DB_Access(string connString, ref LockArea lockArea, ref CPU_Monitor cpu)
    {
      this.i_monCpu = cpu;
      this.m_lockArea = lockArea;
      this.disableStandBy = true;
      this.MyConnection = new OdbcConnection(connString);
      this.MyconnString = connString;
      try
      {
        this.MyConnection.Open();
        this.setDateFormat();
      }
      catch (OdbcException ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public DB_Access(string connString, ref LockArea lockArea, ref CPU_Monitor cpu, ref CtrlStation ctrl, bool var_disableStandBy)
    {
      this.i_monCpu = cpu;
      this.i_ctrl = ctrl;
      this.disableStandBy = var_disableStandBy;
      this.MyConnection = new OdbcConnection(connString);
      this.MyconnString = connString;
      if (this.i_ctrl.StandByAlive)
      {
        if (!this.disableStandBy)
        {
          this.tcpClientStandBy = new TcpClient(this.i_ctrl.standby_server, this.i_ctrl.standby_server_port);
          this.netStreamStandBy = this.tcpClientStandBy.GetStream();
        }
      }
      try
      {
        this.MyConnection.Open();
        this.setDateFormat();
      }
      catch (OdbcException ex)
      {
        throw new Exception(ex.Message);
      }
      this.m_lockArea = lockArea;
    }

    private void writeFailSafeCommand(string cmd)
    {
      if (this.IsBackup || this.i_ctrl.ServingStandBy || !this.i_ctrl.StandByAlive)
        return;
      this.WriteMsgToClient(ref this.netStreamStandBy, "CMDSTDBY" + (cmd.Length + 14).ToString().PadLeft(6, '0') + cmd);
      this.ReceiveMsgFromClient(ref this.netStreamStandBy, 10);
    }

    public bool MemorySave(string tag, ref DataPortable content)
    {
      if (this.hsh_DataSave[(object) tag] != null)
        return false;
      this.hsh_DataSave[(object) tag] = (object) content;
      return true;
    }

    public void MemoryClean()
    {
      this.hsh_DataSave.Clear();
    }

    public DataPortable MemoryGet(string tag)
    {
      if (this.hsh_DataSave[(object) tag] == null)
        return new DataPortable();
      DataPortable dataPortable1 = this.hsh_DataSave[(object) tag] as DataPortable;
      DataPortable dataPortable2 = new DataPortable();
      string buffer = "";
      dataPortable1.ExportBuffer(ref buffer);
      dataPortable2.ImportBuffer(buffer);
      this.hsh_DataSave.Remove((object) tag);
      return dataPortable2;
    }

    public void CloseDB()
    {
      if (this.MyConnection.State != ConnectionState.Closed)
        this.MyConnection.Close();
      if (this.i_ctrl == null || !this.i_ctrl.StandByAlive || this.disableStandBy)
        return;
      this.WriteMsgToClient(ref this.netStreamStandBy, "CMDSTDBY_QUIT");
      this.netStreamStandBy.Close();
      this.tcpClientStandBy.Close();
    }

    public void setDateFormat()
    {
      new OdbcCommand("SET DATEFORMAT mdy", this.MyConnection).ExecuteNonQuery();
    }

    public void truncateTable(string table)
    {
      string str1 = "delete from " + table;
      new OdbcCommand(str1, this.MyConnection).ExecuteNonQuery();
      this.writeFailSafeCommand(str1);
      string str2 = "truncate table " + table;
      new OdbcCommand(str2, this.MyConnection).ExecuteNonQuery();
      this.writeFailSafeCommand(str2);
    }

    public string retrievePatchDB()
    {
      OdbcDataReader odbcDataReader = new OdbcCommand("select i_unique from i_patch", this.MyConnection).ExecuteReader();
      int num = 0;
      while (odbcDataReader.Read())
        ++num;
      odbcDataReader.Close();
      return num.ToString();
    }

    public void patchDB(long level)
    {
      this.truncateTable("i_Patch");
      for (long index = 0; index < level; ++index)
        new OdbcCommand("insert into i_patch (st_done) values ('1')", this.MyConnection).ExecuteNonQuery();
    }

    public void consumeRow(string table, string fields_names, int fields, long num_id)
    {
      string str = "insert into " + table + " ( " + fields_names + ") values (";
      for (int index = 0; index < fields; ++index)
      {
        str += "NULL";
        if (index < fields - 1)
          str += ",";
      }
      new OdbcCommand(str + ")", this.MyConnection).ExecuteNonQuery();
      new OdbcCommand("delete from " + table + " where i_unique = " + (object) num_id, this.MyConnection).ExecuteNonQuery();
    }

    public bool ExecCommand(string sql_command, ref ArrayList ret_objection)
    {
      if (!this.IsBackup)
        this.i_monCpu.start_SQL();
      try
      {
        new OdbcCommand(sql_command, this.MyConnection).ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        ret_objection.Add((object) ("##### SQL Failure: " + sql_command));
        ret_objection.Add((object) ("##### Error: " + ex.Message));
        if (!this.IsBackup)
          this.i_monCpu.end_SQL();
        return false;
      }
      this.writeFailSafeCommand(sql_command);
      if (!this.IsBackup)
        this.i_monCpu.end_SQL();
      return true;
    }

    public bool ExecScalarCommand(string sql_command, ref ArrayList ret_objection, ref string table, ref string unique)
    {
      if (!this.IsBackup)
        this.i_monCpu.start_SQL();
      try
      {
        OdbcCommand odbcCommand = new OdbcCommand(sql_command, this.MyConnection);
        odbcCommand.ExecuteNonQuery();
        odbcCommand.CommandText = "select @@IDENTITY";
        unique = Convert.ToString(odbcCommand.ExecuteScalar());
      }
      catch (Exception ex)
      {
        ret_objection.Add((object) ("##### SQL Failure: " + sql_command));
        ret_objection.Add((object) ("##### Error: " + ex.Message));
        if (!this.IsBackup)
          this.i_monCpu.end_SQL();
        return false;
      }
      this.writeFailSafeCommand(sql_command);
      if (!this.IsBackup)
        this.i_monCpu.end_SQL();
      return true;
    }

    public bool SelectCommand(string sql_command, ref ArrayList ret_objection, ref DB_Statement db_st, ref DB_Result db_res)
    {
      if (!this.IsBackup)
        this.i_monCpu.start_SQL();
      ArrayList ret_list = new ArrayList();
      db_st.ExportLabels(ref ret_list);
      try
      {
        OdbcDataReader odbcDataReader = new OdbcCommand(sql_command, this.MyConnection).ExecuteReader();
        if (db_st.IsCount)
        {
          if (odbcDataReader.Read())
            db_st.count_Value = odbcDataReader.GetInt64(0);
        }
        else if (db_st.IsDistinct)
        {
          while (odbcDataReader.Read())
          {
            string data = db_st.processExceptions(odbcDataReader[db_st.m_Distinct].ToString());
            if (!db_st.var_distinct.Contains((object) data))
            {
              db_st.var_distinct.Add((object) data);
              DB_Row new_row = new DB_Row();
              new_row.allocField(data, db_st.m_Distinct);
              db_res.AddRow(ref new_row);
            }
          }
          db_st.var_distinct.Clear();
        }
        else if (db_st.IsSum)
        {
          while (odbcDataReader.Read())
            db_st.nu_sum += odbcDataReader.GetInt64(0);
        }
        else
        {
          int varMaxRowsRead = db_st.var_maxRowsRead;
          bool flag = false;
          if (varMaxRowsRead > 0)
            flag = true;
          while (odbcDataReader.Read())
          {
            DB_Row new_row = new DB_Row();
            for (int index = 0; index < ret_list.Count; ++index)
            {
              string label = ret_list[index] as string;
              new_row.allocField(db_st.processExceptions(odbcDataReader[label].ToString()), label);
            }
            db_res.AddRow(ref new_row);
            if (flag && --varMaxRowsRead == 0)
              break;
          }
        }
        odbcDataReader.Close();
      }
      catch (Exception ex)
      {
        ret_objection.Add((object) ("##### SQL Failure: " + sql_command));
        ret_objection.Add((object) ("##### Error: " + ex.Message));
        if (!this.IsBackup)
          this.i_monCpu.end_SQL();
        return false;
      }
      if (!this.IsBackup)
        this.i_monCpu.end_SQL();
      return true;
    }
  }
}
