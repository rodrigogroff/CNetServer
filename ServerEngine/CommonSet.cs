// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.CommonSet
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.IO;

namespace SyCrafEngine
{
  public class CommonSet
  {
    public DB_Access m_gen_my_access;
    public StreamWriter m_Log;

    public void SetAccess(ref DB_Access access)
    {
      this.m_gen_my_access = access;
    }

    public void SetLogAccess(ref StreamWriter log)
    {
      this.m_Log = log;
    }
  }
}
