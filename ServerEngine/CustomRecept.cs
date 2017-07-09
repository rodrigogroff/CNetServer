// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.CustomRecept
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

namespace SyCrafEngine
{
  public class CustomRecept
  {
    public string buffer_response = "";

    public virtual CustomRecept getNew()
    {
      return new CustomRecept();
    }

    public virtual bool ProcessRequest(string client_msg, ref Transaction trans, ref bool IsTerm)
    {
      return false;
    }

    public virtual void Finish(ref string buffer_response)
    {
    }
  }
}
