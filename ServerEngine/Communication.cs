// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Communication
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;

namespace SyCrafEngine
{
  public class Communication : Generic
  {
    public string s_transaction = "";
    private ArrayList m_lst_entry_portComm = new ArrayList();
    private ArrayList m_lst_exit_portComm = new ArrayList();
    private ArrayList m_lst_objections = new ArrayList();
    private string str_open_portable = "»";
    private string str_tag_value = "›";
    private string str_close_portable = "«";
    private char char_open_portable = '»';
    private char char_tag_value = '›';
    private char char_close_portable = '«';
    public bool m_TransactionSucessfull;

    public void ReceiveObjections(ref ArrayList msgs)
    {
      this.m_lst_objections = msgs;
    }

    public void AddObjection(string buffer)
    {
      this.m_lst_objections.Add((object) buffer);
    }

    public int GetObjectionCount()
    {
      return this.m_lst_objections.Count;
    }

    public string GetObjection(int iPos)
    {
      return this.m_lst_objections[iPos].ToString();
    }

    public void DumpInput(ref string buffer)
    {
      string buffer1 = "";
      for (int index = 0; index < this.m_lst_entry_portComm.Count; ++index)
      {
        ((DataPortable) this.m_lst_entry_portComm[index]).ExportBuffer(ref buffer1);
        buffer += buffer1;
      }
    }

    public void ExportCommunicationBuffer(ref string buffer, bool bEntry, bool bExit)
    {
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& local1 = @buffer;
      // ISSUE: explicit reference operation
      string str1 = ^local1 + this.str_open_portable + this.m_TransactionSucessfull.ToString() + this.str_close_portable;
      // ISSUE: explicit reference operation
      ^local1 = str1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& local2 = @buffer;
      // ISSUE: explicit reference operation
      string str2 = ^local2 + this.str_open_portable + this.s_transaction + this.str_close_portable;
      // ISSUE: explicit reference operation
      ^local2 = str2;
      buffer += this.str_open_portable;
      if (bEntry)
      {
        for (int index = 0; index < this.m_lst_entry_portComm.Count; ++index)
          ((DataPortable) this.m_lst_entry_portComm[index]).ExportBuffer(ref buffer);
      }
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& local3 = @buffer;
      // ISSUE: explicit reference operation
      string str3 = ^local3 + this.str_close_portable + this.str_open_portable;
      // ISSUE: explicit reference operation
      ^local3 = str3;
      if (bExit)
      {
        for (int index = 0; index < this.m_lst_exit_portComm.Count; ++index)
          ((DataPortable) this.m_lst_exit_portComm[index]).ExportBuffer(ref buffer);
      }
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& local4 = @buffer;
      // ISSUE: explicit reference operation
      string str4 = ^local4 + this.str_close_portable + this.str_open_portable;
      // ISSUE: explicit reference operation
      ^local4 = str4;
      for (int index = 0; index < this.m_lst_objections.Count; ++index)
      {
        buffer += this.m_lst_objections[index].ToString();
        if (index < this.m_lst_objections.Count - 1)
          buffer += this.str_tag_value;
      }
      buffer += this.str_close_portable;
      buffer = "SYCRAF" + (buffer.Length + 12).ToString().PadLeft(6, '0') + buffer;
    }

    public void ImportCommunicationBuffer(string buffer)
    {
      this.m_TransactionSucessfull = false;
      int num1 = buffer.Length - 1;
      int startIndex1 = 13;
      int index1 = 13;
      while (++index1 <= num1)
      {
        if ((int) buffer[index1] == (int) this.char_close_portable)
        {
          this.m_TransactionSucessfull = Convert.ToBoolean(buffer.Substring(startIndex1, index1 - startIndex1));
          index1 += 2;
          startIndex1 = index1;
          break;
        }
      }
      while (++index1 <= num1)
      {
        if ((int) buffer[index1] == (int) this.char_close_portable)
        {
          this.s_transaction = buffer.Substring(startIndex1, index1 - startIndex1);
          index1 += 2;
          startIndex1 = index1;
          break;
        }
      }
      int num2 = 2;
      while (true)
      {
        if ((int) buffer[index1] == (int) this.char_open_portable)
          ++num2;
        if ((int) buffer[index1] == (int) this.char_close_portable)
          --num2;
        if (num2 == 2)
        {
          int length = index1 - startIndex1 + 1;
          string buffer1 = buffer.Substring(startIndex1, length);
          DataPortable dataPortable = new DataPortable();
          dataPortable.ImportBuffer(buffer1);
          this.m_lst_entry_portComm.Add((object) dataPortable);
          ++index1;
          startIndex1 = index1;
        }
        else if (num2 != 1)
          ++index1;
        else
          break;
      }
      int index2 = index1 + 1 + 1;
      int startIndex2 = index2;
      int num3 = 2;
      while (true)
      {
        if ((int) buffer[index2] == (int) this.char_open_portable)
          ++num3;
        if ((int) buffer[index2] == (int) this.char_close_portable)
          --num3;
        if (num3 == 2)
        {
          int length = index2 - startIndex2 + 1;
          string buffer1 = buffer.Substring(startIndex2, length);
          DataPortable dataPortable = new DataPortable();
          dataPortable.ImportBuffer(buffer1);
          this.m_lst_exit_portComm.Add((object) dataPortable);
          ++index2;
          startIndex2 = index2;
        }
        else if (num3 != 1)
          ++index2;
        else
          break;
      }
      int index3 = index2 + 1 + 1;
      int startIndex3 = index3;
      for (; index3 <= num1; ++index3)
      {
        if ((int) buffer[index3] == (int) this.char_close_portable)
        {
          int length = index3 - startIndex3;
          string str = buffer.Substring(startIndex3, length);
          char[] chArray = new char[1]
          {
            this.char_tag_value
          };
          foreach (object obj in str.Split(chArray))
            this.m_lst_objections.Add(obj);
        }
      }
    }

    public void Clear()
    {
      this.m_TransactionSucessfull = false;
      this.m_lst_entry_portComm.Clear();
      this.m_lst_exit_portComm.Clear();
      this.m_lst_objections.Clear();
    }

    public int GetEntryPortCount()
    {
      return this.m_lst_entry_portComm.Count;
    }

    public void AddEntryPortable(ref DataPortable pItem)
    {
      this.m_lst_entry_portComm.Add((object) pItem);
    }

    public DataPortable GetFirstEntryPortable()
    {
      if (this.m_lst_entry_portComm.Count == 0)
        return new DataPortable();
      return this.m_lst_entry_portComm[0] as DataPortable;
    }

    public DataPortable GetFirstExitPortable()
    {
      if (this.m_lst_exit_portComm.Count == 0)
        return new DataPortable();
      return this.m_lst_exit_portComm[0] as DataPortable;
    }

    public DataPortable GetEntryPortableAtPosition(int iPos)
    {
      if (iPos >= this.m_lst_entry_portComm.Count)
        return new DataPortable();
      return this.m_lst_entry_portComm[iPos] as DataPortable;
    }

    public DataPortable GetExitPortableAtPosition(int iPos)
    {
      if (iPos >= this.m_lst_exit_portComm.Count)
        return new DataPortable();
      return this.m_lst_exit_portComm[iPos] as DataPortable;
    }

    public int GetExitPortCount()
    {
      return this.m_lst_exit_portComm.Count;
    }

    public void AddExitPortable(ref DataPortable pItem)
    {
      this.m_lst_exit_portComm.Add((object) pItem);
    }
  }
}
