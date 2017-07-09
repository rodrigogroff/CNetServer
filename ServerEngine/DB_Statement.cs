// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DB_Statement
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Collections;
using System.Text;

namespace SyCrafEngine
{
  public class DB_Statement
  {
    public ENUM_DB_SQL_CMD m_DB_SQL_CMD = ENUM_DB_SQL_CMD.notset;
    private string m_From = "";
    private string m_OrderBy = "";
    private ArrayList _labels = new ArrayList();
    private ArrayList _where = new ArrayList();
    private ArrayList _update = new ArrayList();
    private ArrayList _value = new ArrayList();
    public ArrayList var_distinct = new ArrayList();
    public string m_Distinct = "";
    public bool IsCount;
    public bool IsDistinct;
    public bool IsSum;
    public bool KeepNames;
    public long count_Value;
    public long nu_sum;
    public int var_maxRowsRead;

    public void SetMode(ENUM_DB_SQL_CMD iMode)
    {
      this.ClearAll();
      this.m_DB_SQL_CMD = iMode;
    }

    public void SetFrom(string buffer)
    {
      this.m_From = buffer;
    }

    public string GetFrom()
    {
      return this.m_From;
    }

    public void ClearAll()
    {
      this.m_From = "";
      this.m_OrderBy = "";
      this.m_DB_SQL_CMD = ENUM_DB_SQL_CMD.notset;
      this.ClearSelect();
      this.ClearWhere();
      this.ClearUpdate();
      this.ClearValues();
      this.count_Value = 0L;
    }

    public void ClearSelect()
    {
      this._labels.Clear();
    }

    public void ClearWhere()
    {
      this._where.Clear();
    }

    public void ClearUpdate()
    {
      this._update.Clear();
    }

    public void ClearValues()
    {
      this._value.Clear();
    }

    public void AddSelect(string label)
    {
      this._labels.Add((object) label);
    }

    public void AddWhere(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
          this._where.Add((object) (variable + "='" + new_value + "'"));
          break;
        case ENUM_SQL_UNIT.inttype:
          this._where.Add((object) (variable + "=" + new_value));
          break;
        case ENUM_SQL_UNIT.datetime:
          this._where.Add((object) (variable + "='" + new_value + "'"));
          break;
      }
    }

    public void AddLike(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      if (mode != ENUM_SQL_UNIT.chartype)
        return;
      this._where.Add((object) (variable + " like '%" + new_value + "%'"));
    }

    public void AddStartLike(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      if (mode != ENUM_SQL_UNIT.chartype)
        return;
      this._where.Add((object) (variable + " like '" + new_value + "%'"));
    }

    public void AddEndLike(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      if (mode != ENUM_SQL_UNIT.chartype)
        return;
      this._where.Add((object) (variable + " like '%" + new_value + "'"));
    }

    public void AddWhereGreater(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
          this._where.Add((object) (variable + ">'" + new_value + "'"));
          break;
        case ENUM_SQL_UNIT.inttype:
          this._where.Add((object) (variable + ">" + new_value));
          break;
        case ENUM_SQL_UNIT.datetime:
          this._where.Add((object) (variable + ">'" + new_value + "'"));
          break;
      }
    }

    public void AddWhereGreaterEqual(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
          this._where.Add((object) (variable + ">='" + new_value + "'"));
          break;
        case ENUM_SQL_UNIT.inttype:
          this._where.Add((object) (variable + ">=" + new_value));
          break;
        case ENUM_SQL_UNIT.datetime:
          this._where.Add((object) (variable + ">='" + new_value + "'"));
          break;
      }
    }

    public void AddWhereLessThan(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
          this._where.Add((object) (variable + "<'" + new_value + "'"));
          break;
        case ENUM_SQL_UNIT.inttype:
          this._where.Add((object) (variable + "<" + new_value));
          break;
        case ENUM_SQL_UNIT.datetime:
          this._where.Add((object) (variable + "<'" + new_value + "'"));
          break;
      }
    }

    public void AddWhereLessThanEqual(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
          this._where.Add((object) (variable + "<='" + new_value + "'"));
          break;
        case ENUM_SQL_UNIT.inttype:
          this._where.Add((object) (variable + "<=" + new_value));
          break;
        case ENUM_SQL_UNIT.datetime:
          this._where.Add((object) (variable + "<='" + new_value + "'"));
          break;
      }
    }

    public void AddWhereDiff(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
          this._where.Add((object) (variable + "<>'" + new_value + "'"));
          break;
        case ENUM_SQL_UNIT.inttype:
          this._where.Add((object) (variable + "<>" + new_value));
          break;
        case ENUM_SQL_UNIT.datetime:
          this._where.Add((object) (variable + "<>'" + new_value + "'"));
          break;
      }
    }

    public void AddWhereIn(string variable, ref ArrayList values)
    {
      StringBuilder stringBuilder = new StringBuilder(variable);
      stringBuilder.Append(" in ( ");
      for (int index1 = 0; index1 < values.Count; ++index1)
      {
        bool flag = true;
        string str = values[index1] as string;
        str.ToCharArray();
        for (int index2 = 0; index2 < str.Length; ++index2)
        {
          if (!char.IsNumber(str[index2]))
          {
            flag = false;
            break;
          }
        }
        if (flag)
        {
          stringBuilder.Append(str);
        }
        else
        {
          stringBuilder.Append("'");
          stringBuilder.Append(str);
          stringBuilder.Append("'");
        }
        if (index1 < values.Count - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append(")");
      this._where.Add((object) stringBuilder.ToString());
    }

    public void AddWhereNotIn(string variable, ref ArrayList values)
    {
      StringBuilder stringBuilder = new StringBuilder(variable);
      stringBuilder.Append(" not in ( ");
      for (int index1 = 0; index1 < values.Count; ++index1)
      {
        bool flag = true;
        string str = values[index1] as string;
        str.ToCharArray();
        for (int index2 = 0; index2 < str.Length; ++index2)
        {
          if (!char.IsNumber(str[index2]))
          {
            flag = false;
            break;
          }
        }
        if (flag)
        {
          stringBuilder.Append(str);
        }
        else
        {
          stringBuilder.Append("'");
          stringBuilder.Append(str);
          stringBuilder.Append("'");
        }
        if (index1 < values.Count - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append(")");
      this._where.Add((object) stringBuilder.ToString());
    }

    public void AddOrderBy(string sentence)
    {
      this.m_OrderBy = sentence;
    }

    public void AddUpdate(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      StringBuilder stringBuilder = new StringBuilder();
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
        case ENUM_SQL_UNIT.datetime:
          stringBuilder.Append(" ");
          stringBuilder.Append(variable);
          stringBuilder.Append("='");
          stringBuilder.Append(new_value);
          stringBuilder.Append("'");
          this._update.Add((object) stringBuilder.ToString());
          break;
        case ENUM_SQL_UNIT.inttype:
          stringBuilder.Append(" ");
          stringBuilder.Append(variable);
          stringBuilder.Append("=");
          stringBuilder.Append(new_value);
          this._update.Add((object) stringBuilder.ToString());
          break;
      }
    }

    public string processExceptions(string incoming)
    {
      if (!this.KeepNames)
      {
        incoming = incoming.Replace("{SE$1}", "'");
        incoming = incoming.Replace("{SE$2}", "\"");
        incoming = incoming.Replace("{SE$3}", ",");
        incoming = incoming.Replace("{SE$4}", "\r\n");
      }
      return incoming;
    }

    public void AddValue(string variable, string new_value, ENUM_SQL_UNIT mode)
    {
      this.AddSelect(variable);
      StringBuilder stringBuilder = new StringBuilder();
      if (mode == ENUM_SQL_UNIT.chartype && !this.KeepNames)
      {
        new_value = new_value.Replace("'", "{SE$1}");
        new_value = new_value.Replace("\"", "{SE$2}");
        new_value = new_value.Replace(",", "{SE$3}");
        new_value = new_value.Replace("\r\n", "{SE$4}");
      }
      switch (mode)
      {
        case ENUM_SQL_UNIT.chartype:
        case ENUM_SQL_UNIT.datetime:
          stringBuilder.Append(" '");
          stringBuilder.Append(new_value);
          stringBuilder.Append("'");
          this._value.Add((object) stringBuilder.ToString());
          break;
        case ENUM_SQL_UNIT.inttype:
          stringBuilder.Append(" ");
          stringBuilder.Append(new_value);
          this._value.Add((object) stringBuilder.ToString());
          break;
      }
    }

    public string ExportSQL()
    {
      switch (this.m_DB_SQL_CMD)
      {
        case ENUM_DB_SQL_CMD.select:
          StringBuilder stringBuilder1 = new StringBuilder("select ");
          if (this.IsCount)
            stringBuilder1.Append("count(*)");
          else if (this.IsDistinct || this.IsSum)
          {
            stringBuilder1.Append(this.m_Distinct);
          }
          else
          {
            for (int index = 0; index < this._labels.Count; ++index)
            {
              stringBuilder1.Append(this._labels[index] as string);
              if (index < this._labels.Count - 1)
                stringBuilder1.Append(",");
            }
          }
          stringBuilder1.Append(" from ");
          stringBuilder1.Append(this.m_From);
          if (this._where.Count > 0)
          {
            stringBuilder1.Append(" where ");
            for (int index = 0; index < this._where.Count; ++index)
            {
              stringBuilder1.Append(this._where[index] as string);
              if (index < this._where.Count - 1)
                stringBuilder1.Append(" and ");
            }
          }
          if (!this.IsCount && !this.IsSum && (!this.IsDistinct && this.m_OrderBy != ""))
          {
            stringBuilder1.Append(" Order by ");
            stringBuilder1.Append(this.m_OrderBy);
          }
          return stringBuilder1.ToString();
        case ENUM_DB_SQL_CMD.insert:
          StringBuilder stringBuilder2 = new StringBuilder("insert into ");
          stringBuilder2.Append(this.m_From);
          stringBuilder2.Append(" (");
          for (int index = 0; index < this._labels.Count; ++index)
          {
            stringBuilder2.Append(this._labels[index] as string);
            if (index < this._labels.Count - 1)
              stringBuilder2.Append(",");
          }
          stringBuilder2.Append(") values (");
          for (int index = 0; index < this._value.Count; ++index)
          {
            stringBuilder2.Append(this._value[index] as string);
            if (index < this._value.Count - 1)
              stringBuilder2.Append(",");
          }
          stringBuilder2.Append(")");
          return stringBuilder2.ToString();
        case ENUM_DB_SQL_CMD.delete:
          StringBuilder stringBuilder3 = new StringBuilder("delete from ");
          stringBuilder3.Append(this.m_From);
          if (this._where.Count > 0)
          {
            stringBuilder3.Append(" where ");
            for (int index = 0; index < this._where.Count; ++index)
            {
              stringBuilder3.Append(this._where[index] as string);
              if (index < this._where.Count - 1)
                stringBuilder3.Append(" and ");
            }
          }
          return stringBuilder3.ToString();
        case ENUM_DB_SQL_CMD.update:
          StringBuilder stringBuilder4 = new StringBuilder("update ");
          stringBuilder4.Append(this.m_From);
          stringBuilder4.Append(" set");
          for (int index = 0; index < this._update.Count; ++index)
          {
            stringBuilder4.Append(this._update[index] as string);
            if (index < this._update.Count - 1)
              stringBuilder4.Append(",");
          }
          stringBuilder4.Append(" where ");
          for (int index = 0; index < this._where.Count; ++index)
          {
            stringBuilder4.Append(this._where[index] as string);
            if (index < this._where.Count - 1)
              stringBuilder4.Append(" and ");
          }
          return stringBuilder4.ToString();
        default:
          return "<INFRA ERROR - NO DB CMD SET!!> ";
      }
    }

    public string Export()
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this._labels.Count; ++index)
      {
        stringBuilder.Append(this._labels[index] as string);
        if (index < this._labels.Count - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("~");
      for (int index = 0; index < this._where.Count; ++index)
      {
        stringBuilder.Append(this._where[index] as string);
        if (index < this._where.Count - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("~");
      for (int index = 0; index < this._update.Count; ++index)
      {
        stringBuilder.Append(this._update[index] as string);
        if (index < this._update.Count - 1)
          stringBuilder.Append(",");
      }
      return stringBuilder.ToString();
    }

    public void ExportLabels(ref ArrayList ret_list)
    {
      for (int index = 0; index < this._labels.Count; ++index)
        ret_list.Add((object) (this._labels[index] as string));
    }

    public void Import(string buffer)
    {
      string[] strArray1 = buffer.Split('^');
      string[] strArray2 = strArray1[0].Split('~');
      string[] strArray3 = strArray1[1].Split('~');
      string[] strArray4 = strArray1[2].Split('~');
      for (int index = 0; index < strArray2.Length; ++index)
        this._labels.Add((object) strArray2[index]);
      for (int index = 0; index < strArray3.Length; ++index)
        this._where.Add((object) strArray3[index]);
      for (int index = 0; index < strArray4.Length; ++index)
        this._update.Add((object) strArray4[index]);
    }
  }
}
