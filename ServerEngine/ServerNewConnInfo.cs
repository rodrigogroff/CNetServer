// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.ServerNewConnInfo
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace SyCrafEngine
{
  public class ServerNewConnInfo
  {
    public string path = "";
    public string master_server = "";
    public string master_server_port = "";
    public string engine_version = "";
    public string db_machine = "";
    public string schema = "";
    public Thread workThread;
    public Socket serverSocket;
    public NetworkStream serverSockStream;
    public FileStream logFile;
    public StreamWriter logStream;
    public ServerThread serverThread;
    public int iPid;

    public void StopProcess()
    {
      this.serverThread.StopProcess();
      this.serverSockStream.Close();
      this.serverSocket.Close();
      this.workThread.Abort();
    }
  }
}
