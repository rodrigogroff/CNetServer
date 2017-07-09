// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.ServerNode
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

namespace SyCrafEngine
{
  public class ServerNode
  {
    public string server = "";
    public string server_port = "";
    public int idle;
    public int conns;

    public ServerNode(string srv, string port, int stat, int conns)
    {
      this.server = srv;
      this.server_port = port;
      this.idle = stat;
    }
  }
}
