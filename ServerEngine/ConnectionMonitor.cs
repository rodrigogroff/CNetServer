// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.ConnectionMonitor
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace SyCrafEngine
{
  public class ConnectionMonitor : Monitor
  {
    private int AliveConnections;
    private int TotalConnections;
    private ConnData last_Conn;

    public ConnectionMonitor()
    {
      this.AliveConnections = this.TotalConnections = 0;
      this.time = DateTime.Now;
      this.workThread = new Thread(new ThreadStart(this.ProcessTime));
      this.workThread.Start();
    }

    public int getAliveConnections()
    {
      return this.AliveConnections;
    }

    public int getTotalConnections()
    {
      return this.TotalConnections;
    }

    public void ProcessTime()
    {
      while (true)
      {
        do
        {
          Thread.Sleep(1000);
        }
        while (this.bStopMonitoring);
        this.SaveStats();
      }
    }

    private void SaveStats()
    {
      string stamp = this.getStamp();
      if (this.hshChunks[(object) stamp] != null)
        return;
      ConnData connData = new ConnData();
      connData.AliveConnections = this.AliveConnections;
      connData.TotalConnections = this.TotalConnections;
      if (this.last_Conn == null)
      {
        connData.pctAliveConnections = connData.pctTotalConnections = 0.0;
      }
      else
      {
        connData.pctAliveConnections = this.last_Conn.AliveConnections != this.AliveConnections ? (this.last_Conn.AliveConnections != 0 ? (this.last_Conn.AliveConnections == this.AliveConnections ? 0.0 : (double) (this.AliveConnections * 100 / this.last_Conn.AliveConnections)) : 0.0) : 0.0;
        connData.pctTotalConnections = this.last_Conn.TotalConnections != this.TotalConnections ? (this.last_Conn.TotalConnections != 0 ? (this.last_Conn.TotalConnections == this.TotalConnections ? 0.0 : (double) (this.TotalConnections * 100 / this.last_Conn.TotalConnections)) : 0.0) : 0.0;
      }
      this.last_Conn = connData;
      this.hshChunks[(object) stamp] = (object) connData;
      this.lstStamps.Add((object) stamp);
      ArrayList arrayList = new ArrayList();
      this.getLatestConns(1, ref arrayList);
      this.AppendDisk("connection_stats.log", ref arrayList);
    }

    public void NewConnection()
    {
      ++this.AliveConnections;
      ++this.TotalConnections;
    }

    public void TerminateConnection()
    {
      --this.AliveConnections;
    }

    public void getLatestConns(int count_last, ref ArrayList results)
    {
      for (int count = this.lstStamps.Count; count > 0; --count)
      {
        ConnData hshChunk = this.hshChunks[(object) (this.lstStamps[count - 1] as string)] as ConnData;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(this.lstStamps[count - 1] as string);
        stringBuilder.Append(" >> Threads (");
        stringBuilder.Append(string.Format("{0:d}", (object) hshChunk.AliveConnections).PadLeft(9));
        stringBuilder.Append(") Total  (");
        stringBuilder.Append(string.Format("{0:d}", (object) hshChunk.TotalConnections).PadLeft(9));
        stringBuilder.Append(")");
        results.Add((object) stringBuilder.ToString());
        if (count_last > 0 && --count_last == 0)
          break;
      }
    }
  }
}
