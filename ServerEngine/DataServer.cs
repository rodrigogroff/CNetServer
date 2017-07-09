// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DataServer
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.IO;
using System.Text;

namespace SyCrafEngine
{
  public class DataServer
  {
    public Communication i_Comm;
    public Dispatcher i_Disp;
    public LoadMonitor i_monDataLoad;
    public bool bDisconnected;
    private StreamWriter logStream;
    public DB_Access dbAccess;

    public DataServer(ref StreamWriter log, ref LoadMonitor ldl, ref DB_Access dba)
    {
      this.i_Comm = new Communication();
      this.logStream = log;
      this.i_monDataLoad = ldl;
      this.dbAccess = dba;
    }

    public void StopProcess()
    {
      this.dbAccess.CloseDB();
    }

    public void SetTransactionDispatcher(Dispatcher disp)
    {
      this.i_Disp = disp;
    }

    public void ReceiveAndProcessData(ref Translator var_Translator, ref CustomRecept recept, string buffer, int iPid, string session, ref bool IsHandled, ref bool IsTerm)
    {
      this.i_monDataLoad.NewInputData(buffer.Length);
      Transaction trans = new Transaction();
      trans.var_iPid = iPid;
      trans.var_Translator = var_Translator;
      trans.var_disp = this.i_Disp;
      trans.SetSessionKey(session);
      trans.SetCommunication(ref this.i_Comm);
      trans.SetLogAccess(ref this.logStream);
      trans.SetAccess(ref this.dbAccess);
      this.i_Disp.var_Translator = var_Translator;
      try
      {
        IsHandled = recept.ProcessRequest(buffer, ref trans, ref IsTerm);
      }
      catch (Exception ex)
      {
        this.logStream.WriteLine(ex.ToString());
        return;
      }
      if (IsTerm)
      {
        this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" Requested termination").ToString());
        this.bDisconnected = true;
      }
      else
      {
        if (IsHandled)
          return;
        if (buffer.StartsWith("SYCRAF"))
        {
          this.i_Comm.Clear();
          this.i_Comm.ImportCommunicationBuffer(buffer);
          this.i_Disp.ExecuteTransaction(this.i_Comm.s_transaction, iPid, ref this.logStream, ref this.i_Comm, ref this.dbAccess, session);
        }
        else
          this.bDisconnected = true;
      }
    }

    public void ConvertData(ref string buffer_response, int iPid)
    {
      string buffer = "";
      this.i_Comm.ExportCommunicationBuffer(ref buffer, false, true);
      buffer_response = buffer;
      this.i_monDataLoad.NewOutputData(buffer_response.Length);
      this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" TransmitData <").Append(buffer_response).Append(">").ToString());
      this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" TransmitData Length <").Append(buffer_response.Length.ToString()).Append(">").ToString());
      this.logStream.Flush();
    }

    public string GetCurrentTime()
    {
      return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff ");
    }
  }
}
