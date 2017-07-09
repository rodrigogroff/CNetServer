// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.CPU_Timer
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;

namespace SyCrafEngine
{
  public class CPU_Timer : Base_Timer
  {
    private DateTime idle_time = new DateTime();
    private DateTime work_time = new DateTime();

    public CPU_Timer()
    {
      this.start_IDLE();
    }

    public void start_IDLE()
    {
      this.idle_time = DateTime.Now;
    }

    public void end_IDLE()
    {
      this.milisec_idle_work += -this.idle_time.Subtract(DateTime.Now).TotalMilliseconds;
    }

    public void start_WORK()
    {
      this.work_time = DateTime.Now;
      ++this.totProcessCalls;
    }

    public double end_WORK()
    {
      double num = -this.work_time.Subtract(DateTime.Now).TotalMilliseconds;
      this.milisec_cpu_work += num;
      if (num > this.milisec_cpu_slowest)
        this.milisec_cpu_slowest = num;
      return num;
    }
  }
}
