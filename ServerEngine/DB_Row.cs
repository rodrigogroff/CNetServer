// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DB_Row
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;

namespace SyCrafEngine
{
  public class DB_Row
  {
    private Hashtable _content = new Hashtable();
    private ArrayList _label = new ArrayList();

    public void clear()
    {
      this._content.Clear();
      this._label.Clear();
    }

    public void allocField(string data, string label)
    {
      this._content[(object) label] = (object) data;
      this._label.Add((object) label);
    }

    public bool updateField(string data, string label, ENUM_SQL_UNIT type)
    {
      try
      {
        if (type == ENUM_SQL_UNIT.datetime)
        {
          this._content[(object) label] = (object) Convert.ToDateTime(data);
          return true;
        }
        if (type == ENUM_SQL_UNIT.inttype)
        {
          this._content[(object) label] = (object) Convert.ToInt64(data);
          return true;
        }
        if (type != ENUM_SQL_UNIT.chartype)
          return false;
        this._content[(object) label] = (object) data;
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }
    }

    public int GetLabelCount()
    {
      return this._label.Count;
    }

    public string GetLabel(int position)
    {
      return (string) this._label[position];
    }

    public string GetField(string label)
    {
      return (string) this._content[(object) label] ?? "<unknow>";
    }
  }
}
