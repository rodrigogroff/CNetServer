// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Translator
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
  public class Translator
  {
    public ArrayList var_lstLanguages = new ArrayList();
    public ArrayList var_lstLanguagesDesc = new ArrayList();
    private string path = "translator.dat";
    public DataPortable currentLanguage;

    public Translator()
    {
      FileStream fileStream = new FileStream(this.path, FileMode.OpenOrCreate, FileAccess.Read);
      StreamReader streamReader = new StreamReader((Stream) fileStream);
      while (!streamReader.EndOfStream)
      {
        this.var_lstLanguagesDesc.Add((object) streamReader.ReadLine());
        this.var_lstLanguages.Add((object) new DataPortable(streamReader.ReadLine()));
      }
      streamReader.Close();
      fileStream.Close();
    }

    public string GetLanguageDesc(string index)
    {
      return this.var_lstLanguagesDesc[Convert.ToInt32(index)] as string ?? "Undefined Languague!";
    }

    public void SetLanguage(string index)
    {
      if (index == "")
        index = "0";
      int int32 = Convert.ToInt32(index);
      if (int32 < this.var_lstLanguages.Count)
        this.currentLanguage = this.var_lstLanguages[int32] as DataPortable;
      else
        this.currentLanguage = this.var_lstLanguages[0] as DataPortable;
    }

    public string GetMsg(string index, string service, string tag)
    {
      this.SetLanguage(index);
      string ret_hash_value = "";
      this.currentLanguage.GetMapValue(service + "." + tag, ref ret_hash_value);
      return ret_hash_value;
    }

    public string GetMsg(string index, string tag)
    {
      this.SetLanguage(index);
      return this.currentLanguage.getValue(tag);
    }

    public string GetMsg(string tag)
    {
      return this.currentLanguage.getValue(tag);
    }
  }
}
