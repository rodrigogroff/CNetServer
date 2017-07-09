// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.ServerThread
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
  public class ServerThread : BasicExchange
  {
    private ArrayList lstStandByCmd = new ArrayList();
    private ConnectionMonitor i_monConnections;
    private CPU_Timer i_monCpu;
    private ServerNewConnInfo i_ConnInfo;
    private DataServer i_DataServer;
    private CtrlStation i_ctrl;
    private int m_max_packet_size;
    private int nu_heartBeatCounter;
    private int nu_Standby_heartBeatCounter;
    private StreamWriter logStream;
    private CustomRecept var_recept;
    private Translator var_translator;
    private ArrayList var_lstClients;
    private DateTime StandByTimer;

    public ServerThread(ref ServerNewConnInfo info, ref DataServer server, ref CPU_Timer cpuTimer, ref ConnectionMonitor con, ref StreamWriter stream, int max_packet_size, ref CtrlStation ctrl, ref CustomRecept recept, ref Translator translator, ref ArrayList lstClients)
    {
      this.i_ConnInfo = info;
      this.i_DataServer = server;
      this.i_monCpu = cpuTimer;
      this.i_monConnections = con;
      this.i_ctrl = ctrl;
      this.m_max_packet_size = max_packet_size;
      this.logStream = stream;
      this.var_recept = recept;
      this.var_translator = translator;
      this.var_lstClients = lstClients;
      this.StandByTimer = DateTime.Now;
    }

    public void StopProcess()
    {
      this.i_DataServer.StopProcess();
    }

    public void ServerLoop()
    {
      string str1 = "abcdefghijklmnopqrstuvxywz0123456789";
      string session = "";
      Random random = new Random();
      int length = str1.Length;
      for (int index = 0; index < 25; ++index)
        session += str1[random.Next(0, length)].ToString();
      this.i_DataServer.bDisconnected = false;
      this.nu_heartBeatCounter = 0;
      while (true)
      {
        do
        {
          Thread.Sleep(1);
          if (this.i_DataServer.bDisconnected)
          {
            this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Disconnected!").ToString());
            this.logStream.Flush();
            goto label_19;
          }
          else if (this.i_ctrl.bStopServer)
          {
            this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Stop Server Requested!").ToString());
            this.logStream.Flush();
            goto label_19;
          }
          else
          {
            if (!this.i_ctrl.ServingStandBy)
            {
              if (++this.nu_heartBeatCounter > 90000)
              {
                this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Quitting offline client session (" + (object) this.nu_heartBeatCounter + ") ").ToString());
                this.logStream.Flush();
                this.i_monConnections.TerminateConnection();
                this.i_DataServer.bDisconnected = true;
                goto label_19;
              }
            }
            else
            {
              ++this.nu_Standby_heartBeatCounter;
              if (this.nu_Standby_heartBeatCounter > 500)
              {
                this.i_ctrl.ServingStandBy = false;
                this.logStream.WriteLine((object) new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### (Standby) Quitting offline master"));
                this.logStream.Flush();
                this.i_monConnections.TerminateConnection();
                this.i_DataServer.bDisconnected = true;
                goto label_19;
              }
            }
            if (!this.i_ConnInfo.serverSockStream.CanRead)
              goto label_18;
          }
        }
        while (!this.i_ConnInfo.serverSockStream.DataAvailable);
        DateTime now = DateTime.Now;
        string msgFromClient = this.ReceiveMsgFromClient(ref this.i_ConnInfo.serverSockStream, this.m_max_packet_size);
        this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Received: " + msgFromClient).ToString());
        this.logStream.Flush();
        this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Size: " + msgFromClient.Length.ToString()).ToString());
        this.logStream.Flush();
        if (!(msgFromClient == ""))
        {
          this.i_monCpu.end_IDLE();
          this.i_monCpu.start_WORK();
          this.ProcessIncomingData(ref this.var_translator, ref msgFromClient, this.i_ConnInfo.iPid, ref session);
          double num = this.i_monCpu.end_WORK();
          this.i_monCpu.start_IDLE();
          this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Total request time: ").Append(string.Format("{0:n}", (object) num) + " miliseconds.").ToString());
        }
        else
          break;
      }
      this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Client null message").ToString());
      this.logStream.Flush();
      this.i_monConnections.TerminateConnection();
      this.i_DataServer.bDisconnected = true;
      goto label_19;
label_18:
      this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append("##### Quitting terminated client session").ToString());
      this.logStream.Flush();
      this.i_monConnections.TerminateConnection();
      this.i_DataServer.bDisconnected = true;
label_19:
      this.i_ConnInfo.logStream.Close();
      this.i_ConnInfo.logFile.Close();
      this.i_DataServer.dbAccess.CloseDB();
      string str2 = this.i_ConnInfo.path.Replace(".wrk", "").Replace("\\Log_", "\\Log\\Log_");
      if (File.Exists(str2))
        File.Delete(str2);
      File.Move(this.i_ConnInfo.path, str2);
      this.i_ConnInfo.serverSockStream.Close();
      this.i_ConnInfo.serverSocket.Close();
      this.var_lstClients.Remove((object) this.i_ConnInfo);
    }

    public bool ProcessStandByMessaging(ref string buffer)
    {
      if (buffer.StartsWith("CMDSTDBY"))
      {
        this.i_DataServer.dbAccess.ExecCommand(buffer.Substring(14, buffer.Length - 14), ref this.lstStandByCmd);
        this.WriteMsgToClient(ref this.i_ConnInfo.serverSockStream, "OK");
        return true;
      }
      if (buffer.StartsWith("CMDSTDBY_QUIT"))
      {
        this.logStream.WriteLine("DataServer  " + this.GetCurrentTime() + "##### CMDSTDBY_QUIT");
        this.i_monConnections.TerminateConnection();
        this.i_DataServer.bDisconnected = true;
        return true;
      }
      if (!(buffer == "STANDBYSQL_ALIVE"))
        return false;
      this.i_ctrl.ServingStandBy = true;
      this.nu_Standby_heartBeatCounter = 0;
      if (!this.WriteMsgToClient(ref this.i_ConnInfo.serverSockStream, "STANDBYSQL_ACCEPTED"))
      {
        this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" STANDBYSQL_CANT_WRITE").ToString());
        this.logStream.Flush();
        return true;
      }
      this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" STANDBYSQL_ACCEPTED").ToString());
      this.logStream.Flush();
      return true;
    }

    public bool ProcessClientExceptions(ref string buffer)
    {
      if (buffer == "REQUEST_SERVER")
      {
        string buffer_response = "REQUEST_SERVER_ACCEPTED,,";
        this.i_DataServer.i_monDataLoad.NewOutputData(buffer_response.Length);
        this.WriteMsgToClient(ref this.i_ConnInfo.serverSockStream, buffer_response);
        return true;
      }
      if (buffer == "HEART_BEAT")
      {
        this.nu_heartBeatCounter = 0;
        this.WriteMsgToClient(ref this.i_ConnInfo.serverSockStream, "HEARTBEAT_ACCEPTED");
        return true;
      }
      if (buffer == "TERMINATE")
      {
        this.logStream.WriteLine("DataServer  " + this.GetCurrentTime() + "##### TERMINATE");
        this.i_monConnections.TerminateConnection();
        this.i_DataServer.bDisconnected = true;
        return true;
      }
      if (!(buffer == "REQUEST_STANDBY"))
        return this.ProcessStandByMessaging(ref buffer);
      string buffer_response1 = "REQUEST_STANDBY_ACCEPTED," + this.i_ctrl.standby_server_web + "," + this.i_ctrl.standby_server_port.ToString();
      this.i_DataServer.i_monDataLoad.NewOutputData(buffer_response1.Length);
      this.WriteMsgToClient(ref this.i_ConnInfo.serverSockStream, buffer_response1);
      return true;
    }

    public void ProcessIncomingData(ref Translator var_translator, ref string buffer, int iPid, ref string session)
    {
      string buffer_response = "";
      if (this.i_ctrl.ServingStandBy)
      {
        this.ProcessStandByMessaging(ref buffer);
      }
      else
      {
        if (this.ProcessClientExceptions(ref buffer))
          return;
        this.nu_heartBeatCounter = 0;
        bool IsHandled = false;
        bool IsTerm = false;
        CustomRecept recept = this.var_recept.getNew();
        this.i_DataServer.ReceiveAndProcessData(ref var_translator, ref recept, buffer, iPid, session, ref IsHandled, ref IsTerm);
        if (!IsHandled)
        {
          if (buffer.StartsWith("SYCRAF"))
          {
            this.i_DataServer.ConvertData(ref buffer_response, iPid);
          }
          else
          {
            this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" TCP Packet Rejected").ToString());
            this.logStream.Flush();
            buffer_response = "0";
            IsTerm = true;
          }
        }
        else
        {
          buffer_response = recept.buffer_response;
          this.i_DataServer.i_monDataLoad.NewOutputData(buffer_response.Length);
          this.logStream.WriteLine(new StringBuilder().Append("DataServer  ").Append(this.GetCurrentTime()).Append(" SendData <").Append(buffer_response).Append(">").ToString() + " length:" + (object) buffer_response.Length);
          this.logStream.Flush();
        }
        if (buffer_response.Length > this.m_max_packet_size)
        {
          this.i_DataServer.i_Comm.Clear();
          this.i_DataServer.i_Comm.AddObjection("Maximum Output reached.");
          this.i_DataServer.i_Comm.ExportCommunicationBuffer(ref buffer_response, false, true);
        }
        if (!this.WriteMsgToClient(ref this.i_ConnInfo.serverSockStream, buffer_response))
        {
          this.logStream.WriteLine("DataServer  " + this.GetCurrentTime() + "##### CLIENT CLOSED");
          IsTerm = true;
        }
        this.nu_heartBeatCounter = 0;
        if (!IsTerm)
          return;
        this.logStream.WriteLine("DataServer  " + this.GetCurrentTime() + "##### TERMINATE");
        this.i_monConnections.TerminateConnection();
        this.i_DataServer.bDisconnected = true;
      }
    }

    public string GetCurrentTime()
    {
      return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff") + " ";
    }
  }
}
