// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.LoadMonitor
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace SyCrafEngine
{
  public class LoadMonitor : Monitor
  {
    private long input_load_bytes;
    private long output_load_bytes;
    private LoadData last_Load;

    public LoadMonitor()
    {
      this.time = DateTime.Now;
      this.workThread = new Thread(new ThreadStart(this.ProcessTime));
      this.workThread.Start();
    }

    public long getInputLoad()
    {
      return this.input_load_bytes;
    }

    public long getOutputLoad()
    {
      return this.output_load_bytes;
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
      LoadData loadData = new LoadData();
      loadData.input_load_bytes = this.input_load_bytes;
      loadData.output_load_bytes = this.output_load_bytes;
      if (this.last_Load == null)
      {
        loadData.pctLoadInput = loadData.pctLoadOutput = 0.0f;
      }
      else
      {
        if (this.last_Load.input_load_bytes == this.input_load_bytes)
          loadData.pctLoadInput = 0.0f;
        else if (this.last_Load.input_load_bytes == 0L)
          loadData.pctLoadInput = 0.0f;
        else if (this.last_Load.input_load_bytes != this.input_load_bytes)
        {
          loadData.pctLoadInput = (float) (this.input_load_bytes * 100L / this.last_Load.input_load_bytes);
          if ((double) loadData.pctLoadInput > 100.0)
            loadData.pctLoadInput -= 100f;
        }
        else
          loadData.pctLoadInput = 0.0f;
        if (this.last_Load.output_load_bytes == this.output_load_bytes)
          loadData.pctLoadOutput = 0.0f;
        else if (this.last_Load.output_load_bytes == 0L)
          loadData.pctLoadOutput = 0.0f;
        else if (this.last_Load.output_load_bytes != this.output_load_bytes)
        {
          loadData.pctLoadOutput = (float) (this.output_load_bytes * 100L / this.last_Load.output_load_bytes);
          if ((double) loadData.pctLoadOutput > 100.0)
            loadData.pctLoadOutput -= 100f;
        }
        else
          loadData.pctLoadOutput = 0.0f;
      }
      this.last_Load = loadData;
      this.hshChunks[(object) stamp] = (object) loadData;
      this.lstStamps.Add((object) stamp);
      this.input_load_bytes = this.output_load_bytes = 0L;
      ArrayList arrayList = new ArrayList();
      this.getLatestLoads(1, ref arrayList);
      this.AppendDisk("load_stats.log", ref arrayList);
    }

    public void NewInputData(int bytes)
    {
      this.input_load_bytes += (long) bytes;
    }

    public void NewOutputData(int bytes)
    {
      this.output_load_bytes += (long) bytes;
    }

    public void getLatestLoads(int count_last, ref ArrayList results)
    {
      for (int count = this.lstStamps.Count; count > 0; --count)
      {
        LoadData hshChunk = this.hshChunks[(object) (this.lstStamps[count - 1] as string)] as LoadData;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(this.lstStamps[count - 1] as string);
        stringBuilder.Append(" >> Load In (");
        stringBuilder.Append(string.Format("{0:d}", (object) (hshChunk.input_load_bytes / 60L)).PadLeft(9));
        stringBuilder.Append(" bytes/sec) Load Out (");
        stringBuilder.Append(string.Format("{0:d}", (object) (hshChunk.output_load_bytes / 60L)).PadLeft(9));
        stringBuilder.Append(" bytes/sec)");
        results.Add((object) stringBuilder.ToString());
        if (count_last > 0 && --count_last == 0)
          break;
      }
    }
  }
}
