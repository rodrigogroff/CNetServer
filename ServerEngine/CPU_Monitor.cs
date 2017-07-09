// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.CPU_Monitor
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace SyCrafEngine
{
  public class CPU_Monitor : Base_Timer
  {
    private ArrayList lstTimers = new ArrayList();
    private Hashtable hshTimers = new Hashtable();
    private DateTime sql_time = new DateTime();
    private double milisec_sql_work;
    private double totSqlCalls;

    public CPU_Monitor()
    {
      this.workThread = new Thread(new ThreadStart(this.ProcessTime));
      this.workThread.Start();
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

    public void start_SQL()
    {
      this.sql_time = DateTime.Now;
      ++this.totSqlCalls;
    }

    public void end_SQL()
    {
      this.milisec_sql_work += -this.sql_time.Subtract(DateTime.Now).TotalMilliseconds;
    }

    public void AddTimer(ref CPU_Timer timer, string tag)
    {
      this.lstTimers.Add((object) tag);
      this.hshTimers[(object) tag] = (object) timer;
    }

    public void RemoveTimer(string tag)
    {
      this.lstTimers.Remove((object) tag);
      this.hshTimers.Remove((object) tag);
    }

    private void SaveStats()
    {
      string stamp = this.getStamp();
      if (this.hshChunks[(object) stamp] != null)
        return;
      this.milisec_cpu_slowest = 0.0;
      this.milisec_cpu_work -= this.milisec_sql_work;
      this.ProcessList();
      CpuData cpuData = new CpuData();
      cpuData.milisec_idle_work = this.milisec_idle_work;
      cpuData.milisec_cpu_work = this.milisec_cpu_work;
      cpuData.milisec_cpu_slowest = this.milisec_cpu_slowest;
      cpuData.milisec_avg_sql = this.milisec_sql_work + this.milisec_cpu_work == 0.0 ? 0.0 : 100.0 * this.milisec_sql_work / (this.milisec_sql_work + this.milisec_cpu_work);
      cpuData.totSqlCalls = this.totSqlCalls;
      cpuData.milisec_avg_idle = 100.0;
      if (this.milisec_idle_work + this.milisec_cpu_work != 0.0)
        cpuData.milisec_avg_idle = 100.0 * this.milisec_idle_work / (this.milisec_idle_work + this.milisec_cpu_work);
      this.hshChunks[(object) stamp] = (object) cpuData;
      this.lstStamps.Add((object) stamp);
      ArrayList arrayList = new ArrayList();
      this.getLatestCpuLoads(1, ref arrayList);
      this.AppendDisk("cpu_stats.log", ref arrayList);
      this.milisec_sql_work = 0.0;
    }

    public void ProcessList()
    {
      this.milisec_idle_work = 0.0;
      this.milisec_cpu_work = 0.0;
      this.milisec_cpu_slowest = 0.0;
      this.totProcessCalls = 0.0;
      int count = this.lstTimers.Count;
      for (int index = 0; index < count; ++index)
      {
        CPU_Timer hshTimer = this.hshTimers[(object) (this.lstTimers[index] as string)] as CPU_Timer;
        this.milisec_idle_work += hshTimer.milisec_idle_work;
        this.milisec_cpu_work += hshTimer.milisec_cpu_work;
        if (hshTimer.milisec_cpu_slowest > this.milisec_cpu_slowest)
          this.milisec_cpu_slowest = hshTimer.milisec_cpu_slowest;
        hshTimer.milisec_cpu_slowest = 0.0;
        hshTimer.milisec_idle_work = 0.0;
        hshTimer.milisec_cpu_work = 0.0;
      }
      if (count <= 0)
        return;
      this.milisec_idle_work /= (double) count;
      this.milisec_cpu_work /= (double) count;
    }

    public void getLatestCpuLoads(int count_last, ref ArrayList results)
    {
      for (int count = this.lstStamps.Count; count > 0; --count)
      {
        CpuData hshChunk = this.hshChunks[(object) (this.lstStamps[count - 1] as string)] as CpuData;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(this.lstStamps[count - 1] as string);
        stringBuilder.Append(" >> Idle (");
        stringBuilder.Append(string.Format("{0:n}", (object) hshChunk.milisec_avg_idle));
        stringBuilder.Append("%) Slowest Request (");
        stringBuilder.Append(string.Format("{0:n}", (object) hshChunk.milisec_cpu_slowest));
        stringBuilder.Append(" ms) DataBase (");
        stringBuilder.Append(string.Format("{0:n}", (object) hshChunk.milisec_avg_sql));
        stringBuilder.Append("%) Calls (");
        stringBuilder.Append(hshChunk.totSqlCalls);
        stringBuilder.Append(")");
        results.Add((object) stringBuilder.ToString());
        if (count_last > 0 && --count_last == 0)
          break;
      }
    }
  }
}
