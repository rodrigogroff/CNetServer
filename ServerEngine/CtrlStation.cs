// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.CtrlStation
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SyCrafEngine
{
  public class CtrlStation
  {
    public ArrayList m_lstServerNodes = new ArrayList();
    public string genericErrorMsg = "";
    public string standby_server = "";
    public string standby_server_web = "";
    public int maxThreads = 50;
    public bool bPauseTraffic;
    public bool bStopServer;
    public bool bStoppedSlave;
    public bool bDumpLoadLog;
    public bool bDumpMonLog;
    public bool bServerLoaded;
    public bool bStartupError;
    public bool bConsoleMode;
    public bool StandByAlive;
    public bool ServingStandBy;
    public TcpListener tcpServerListener;
    public int standby_server_port;

    public void displayError()
    {
      if (this.bConsoleMode)
      {
        Console.WriteLine("## " + this.genericErrorMsg);
      }
      else
      {
        int num = (int) MessageBox.Show(this.genericErrorMsg, "SYSTEM");
      }
    }
  }
}
