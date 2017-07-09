// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.LockObject
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

namespace SyCrafEngine
{
  public class LockObject
  {
    private string id = "";

    public bool useResource(string newid)
    {
      if (this.id == "")
        this.id = newid;
      else if (this.id != newid)
        return false;
      return true;
    }

    public void releaseResource(string id_release)
    {
      if (this.id != id_release)
        return;
      this.id = "";
    }
  }
}
