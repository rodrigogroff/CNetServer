// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DataPortable
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Collections;
using System.Text;

namespace SyCrafEngine
{
  public class DataPortable
  {
    private Hashtable hsh_tagValue = new Hashtable();
    public ArrayList lst_mapTags = new ArrayList();
    private ArrayList lst_ctrlTags = new ArrayList();
    private string str_open_portable = "»";
    private string str_tag_value = "›";
    private string str_field_sep = "•";
    private string str_close_portable = "«";
    private char char_open_portable = '»';
    private char char_tag_value = '›';
    private char char_close_portable = '«';

    public DataPortable()
    {
    }

    public DataPortable(string import)
    {
      this.ImportBuffer(import);
    }

    public void CleanUp()
    {
      this.hsh_tagValue.Clear();
      this.lst_mapTags.Clear();
      this.lst_ctrlTags.Clear();
    }

    public void ExportBuffer(ref string buffer)
    {
      int count = this.lst_mapTags.Count;
      int num = count - 1;
      StringBuilder stringBuilder = new StringBuilder(buffer);
      stringBuilder.Append(this.str_open_portable);
      for (int index1 = 0; index1 < count; ++index1)
      {
        string lstMapTag = this.lst_mapTags[index1] as string;
        string lstCtrlTag = this.lst_ctrlTags[index1] as string;
        stringBuilder.Append(lstMapTag);
        stringBuilder.Append(this.str_tag_value);
        if (lstCtrlTag == "0")
        {
          stringBuilder.Append(this.str_field_sep);
          stringBuilder.Append(this.hsh_tagValue[(object) lstMapTag] as string);
          stringBuilder.Append(this.str_field_sep);
        }
        else if (lstCtrlTag == "1")
        {
          stringBuilder.Append(this.str_open_portable);
          ArrayList arrayList = this.hsh_tagValue[(object) lstMapTag] as ArrayList;
          for (int index2 = 0; index2 < arrayList.Count; ++index2)
          {
            DataPortable dataPortable = arrayList[index2] as DataPortable;
            string buffer1 = "";
            dataPortable.ExportBuffer(ref buffer1);
            stringBuilder.Append(buffer1);
          }
          stringBuilder.Append(this.str_close_portable);
        }
        if (index1 < num)
          stringBuilder.Append(this.str_tag_value);
      }
      stringBuilder.Append(this.str_close_portable);
      buffer = stringBuilder.ToString();
    }

    public void ImportBuffer(string buffer)
    {
      this.hsh_tagValue.Clear();
      this.lst_mapTags.Clear();
      this.lst_ctrlTags.Clear();
      int num1 = buffer.Length - 1;
      int startIndex = 1;
      int index1 = 1;
      bool flag = false;
      int num2 = 0;
      while (++index1 <= num1)
      {
        if ((int) buffer[index1] == (int) this.char_tag_value || (int) buffer[index1] == (int) this.char_open_portable || (int) buffer[index1] == (int) this.char_close_portable)
        {
          ++num2;
          if (num2 == 2)
          {
            flag = true;
            num2 = 0;
          }
        }
        if (flag)
        {
          flag = false;
          string[] strArray = buffer.Substring(startIndex, index1 - startIndex).Split(this.char_tag_value);
          if (strArray[1].Length == 0)
          {
            int num3 = 1;
            ArrayList array = new ArrayList();
            for (int index2 = index1 + 1; index2 < num1; ++index2)
            {
              if ((int) buffer[index2] == (int) this.char_open_portable)
                ++num3;
              if ((int) buffer[index2] == (int) this.char_close_portable)
                --num3;
              if (num3 == 1)
              {
                int length = index2 - index1;
                string buffer1 = buffer.Substring(index1 + 1, length);
                DataPortable dataPortable = new DataPortable();
                array.Add((object) dataPortable);
                dataPortable.ImportBuffer(buffer1);
                index1 += length;
              }
            }
            this.MapTagArray(strArray[0], ref array);
            index1 += 3;
            startIndex = index1;
          }
          else
          {
            this.MapTagValue(strArray[0], strArray[1].Replace(this.str_field_sep, ""));
            startIndex += index1 - startIndex + 1;
          }
        }
      }
    }

    public int GetSize()
    {
      int num = 0;
      for (int index = 0; index < this.lst_ctrlTags.Count; ++index)
      {
        if (this.lst_ctrlTags[index].ToString() == "0")
          num = num + (this.lst_mapTags[index].ToString().Length + 2) + (this.hsh_tagValue[(object) this.lst_mapTags[index].ToString()].ToString().Length + 2);
      }
      return num + 12;
    }

    public void setValue(string tag, string val)
    {
      if (this.hsh_tagValue[(object) tag] == null)
      {
        this.lst_mapTags.Add((object) tag);
        this.lst_ctrlTags.Add((object) "0");
      }
      this.hsh_tagValue[(object) tag] = (object) val;
    }

    public string getValue(string tag)
    {
      return this.hsh_tagValue[(object) tag] as string ?? "";
    }

    public bool MapTagValue(string tag, string val)
    {
      if (this.hsh_tagValue[(object) tag] != null)
        return false;
      this.hsh_tagValue[(object) tag] = (object) val;
      this.lst_mapTags.Add((object) tag);
      this.lst_ctrlTags.Add((object) "0");
      return true;
    }

    public bool MapTagArray(string tag, ref ArrayList array)
    {
      if (this.hsh_tagValue[(object) tag] != null)
        return false;
      this.hsh_tagValue[(object) tag] = (object) array;
      this.lst_mapTags.Add((object) tag);
      this.lst_ctrlTags.Add((object) "1");
      return true;
    }

    public bool GetMapValue(string Tag, ref string ret_hash_value)
    {
      ret_hash_value = this.hsh_tagValue[(object) Tag] as string;
      if (ret_hash_value != null)
        return true;
      ret_hash_value = "";
      return false;
    }

    public bool GetMapArray(string Tag, ref ArrayList ret_lst_array)
    {
      ret_lst_array.Clear();
      ret_lst_array = this.hsh_tagValue[(object) Tag] as ArrayList;
      if (ret_lst_array != null)
        return true;
      ret_lst_array = new ArrayList();
      return false;
    }

    public bool MapTagContainer(string tag, DataPortable container)
    {
      if (this.hsh_tagValue[(object) tag] != null)
        return false;
      return this.MapTagArray(tag, ref new ArrayList()
      {
        (object) container
      });
    }

    public bool GetMapContainer(string tag, ref DataPortable tmp)
    {
      ArrayList ret_lst_array = new ArrayList();
      if (!this.GetMapArray(tag, ref ret_lst_array))
        return false;
      tmp = (DataPortable) ret_lst_array[0];
      return tmp != null;
    }

    public int GetMapCount()
    {
      return this.lst_mapTags.Count;
    }

    public string GetMapTagAtPosition(int iPos)
    {
      return this.lst_mapTags[iPos] as string;
    }

    public string GetMapTypeAtPosition(int iPos)
    {
      return this.lst_ctrlTags[iPos] as string;
    }

    public virtual void Import(DataPortable imp)
    {
      string buffer = "";
      imp.ExportBuffer(ref buffer);
      this.ImportBuffer(buffer);
    }
  }
}
