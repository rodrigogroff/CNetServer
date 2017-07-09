// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Monitor
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.IO;
using System.Threading;

namespace SyCrafEngine
{
  public class Monitor
  {
    protected DateTime time = new DateTime();
    protected ArrayList lstStamps = new ArrayList();
    protected Hashtable hshChunks = new Hashtable();
    public bool bStopMonitoring = true;
    public string path = "";
    protected Thread workThread;

    protected string getStamp()
    {
      return Convert.ToString(DateTime.Now.Year).PadLeft(4, '0') + "." + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0') + "." + Convert.ToString(DateTime.Now.Day).PadLeft(2, '0') + " " + Convert.ToString(DateTime.Now.Hour).PadLeft(2, '0') + ":" + Convert.ToString(DateTime.Now.Minute).PadLeft(2, '0');
    }

    public void StopMonit()
    {
      this.bStopMonitoring = true;
      this.workThread.Abort();
    }

    public void AppendDisk(string dest_file, ref ArrayList contents)
    {
      FileStream fileStream = new FileStream(this.path + "\\" + dest_file, FileMode.Append, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
      for (int index = 0; index < contents.Count; ++index)
        streamWriter.WriteLine(contents[index] as string);
      streamWriter.Flush();
      streamWriter.Close();
      fileStream.Close();
      this.RemoveOldInfo();
    }

    public void RemoveOldInfo()
    {
      for (int index = 0; index > this.lstStamps.Count; ++index)
      {
        if (index < this.lstStamps.Count - 10)
          this.hshChunks.Remove((object) (this.lstStamps[index] as string));
      }
      while (this.lstStamps.Count > 10)
        this.lstStamps.Remove((object) (this.lstStamps[0] as string));
    }
  }
}
