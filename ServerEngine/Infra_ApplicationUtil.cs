// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Infra_ApplicationUtil
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Collections;
using System.IO;
using System.Text;

namespace SyCrafEngine
{
  public class Infra_ApplicationUtil
  {
    private Hashtable var_hshPort = new Hashtable();
    private Hashtable var_hshCSV = new Hashtable();
    private ArrayList var_lstCSV = new ArrayList();
    private int i_amount = 10;
    private FileStream read_file;
    private FileStream write_file;
    private int i_pointer;
    private int nu_totalBatch;

    public string CleanUpperPonctuation(string st)
    {
      st = st.ToUpper();
      st = st.Replace("Â", "A");
      st = st.Replace("À", "A");
      st = st.Replace("Á", "A");
      st = st.Replace("Ã", "A");
      st = st.Replace("É", "E");
      st = st.Replace("Ê", "E");
      st = st.Replace("È", "E");
      st = st.Replace("Í", "I");
      st = st.Replace("Î", "I");
      st = st.Replace("Ì", "I");
      st = st.Replace("Ü", "U");
      st = st.Replace("Ú", "U");
      st = st.Replace("Û", "U");
      st = st.Replace("Ù", "U");
      st = st.Replace("Ç", "C");
      st = st.Replace("Ñ", "N");
      st = st.Replace("Õ", "O");
      st = st.Replace("Ó", "O");
      st = st.Replace("Ô", "O");
      st = st.Replace("Ó", "O");
      return st;
    }

    public void CloseWriteFile()
    {
      if (this.write_file == null)
        return;
      this.write_file.Close();
    }

    public void CloseReadFile()
    {
      if (this.read_file == null)
        return;
      this.read_file.Close();
    }

    public void CreateWriteFile(ref StreamWriter configFile, string path)
    {
      this.write_file = !File.Exists(path) ? new FileStream(path, FileMode.CreateNew, FileAccess.Write) : new FileStream(path, FileMode.Truncate, FileAccess.Write);
      configFile = new StreamWriter((Stream) this.write_file);
    }

    public void OpenFile(ref StreamReader configFile, string path)
    {
      this.read_file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
      configFile = new StreamReader((Stream) this.read_file);
    }

    public void clearPortable()
    {
      this.var_hshPort.Clear();
    }

    public void savePortable(string tag, DataPortable port)
    {
      this.var_hshPort[(object) tag] = (object) port;
    }

    public DataPortable retrievePortable(string tag)
    {
      return this.var_hshPort[(object) tag] as DataPortable;
    }

    public int indexCSV(string csv)
    {
      return this.indexCSV(csv, ',');
    }

    public int indexCSV(string csv, char split)
    {
      this.var_hshCSV.Clear();
      this.var_lstCSV.Clear();
      this.i_pointer = 0;
      if (csv == "")
        return 0;
      int length = 1;
      for (int index = 0; index < csv.Length; ++index)
      {
        if ((int) csv[index] == (int) split)
          ++length;
      }
      if (length == 1)
      {
        this.var_hshCSV[(object) csv] = (object) "*";
        this.var_lstCSV.Add((object) csv);
      }
      else
      {
        string[] strArray1 = new string[length];
        char[] chArray = new char[1]{ split };
        string[] strArray2 = csv.Split(chArray);
        for (int index = 0; index < length; ++index)
        {
          this.var_hshCSV[(object) strArray2[index]] = (object) "*";
          this.var_lstCSV.Add((object) strArray2[index]);
        }
      }
      return length;
    }

    public bool IsValueInCSV(string tag)
    {
      return this.var_hshCSV[(object) tag] != null;
    }

    public string getCSV(int pos)
    {
      return this.var_lstCSV[pos] as string;
    }

    public void setBatchAmount(int amount)
    {
      this.i_amount = amount;
      this.nu_totalBatch = 0;
    }

    public string getnu_totalBatch()
    {
      return this.nu_totalBatch.ToString();
    }

    public bool buildBatch(ref string dest)
    {
      dest = "";
      int count = this.var_lstCSV.Count;
      if (this.nu_totalBatch == count)
        return false;
      int num = 0;
      this.nu_totalBatch = this.i_pointer + this.i_amount <= count ? this.i_pointer + this.i_amount : count - this.i_pointer;
      StringBuilder stringBuilder = new StringBuilder(dest);
      int iPointer = this.i_pointer;
      while (iPointer < this.nu_totalBatch)
      {
        stringBuilder.Append(this.getCSV(iPointer));
        if (iPointer < this.nu_totalBatch - 1)
          stringBuilder.Append(",");
        ++iPointer;
        ++this.i_pointer;
        ++num;
      }
      dest = stringBuilder.ToString();
      this.nu_totalBatch = num;
      return true;
    }

    public string getCSVList(ArrayList list)
    {
      StringBuilder stringBuilder = new StringBuilder();
      int count = list.Count;
      for (int index = 0; index < list.Count; ++index)
      {
        stringBuilder.Append(list[index].ToString());
        if (index < count - 1)
          stringBuilder.Append(",");
      }
      return stringBuilder.ToString();
    }
  }
}
