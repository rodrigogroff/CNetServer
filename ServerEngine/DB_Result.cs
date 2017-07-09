// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DB_Result
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Collections;

namespace SyCrafEngine
{
  public class DB_Result
  {
    private ArrayList _rows = new ArrayList();

    public void Clear()
    {
      this._rows.Clear();
    }

    public bool HasRows()
    {
      return this._rows.Count > 0;
    }

    public int GetRowCount()
    {
      return this._rows.Count;
    }

    public DB_Row GetRowAtPosition(int position)
    {
      return this._rows[position] as DB_Row;
    }

    public DB_Row GetFirstRow()
    {
      return (DB_Row) this._rows[0];
    }

    public DB_Row GetLastRow()
    {
      return (DB_Row) this._rows[this._rows.Count - 1];
    }

    public void AddRow(ref DB_Row new_row)
    {
      this._rows.Add((object) new_row);
    }
  }
}
