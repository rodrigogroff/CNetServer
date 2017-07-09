// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.money
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;

namespace SyCrafEngine
{
  public class money
  {
    public string prepareNumber(string numb)
    {
      return numb.Trim().Replace(".", "").Replace(",", "");
    }

    public string formatToMoney(string val)
    {
      string str1 = val.Trim().Replace(".", "").Replace(",", "");
      string str2 = "";
      if (str1.StartsWith("-"))
      {
        str1 = str1.Replace("-", "");
        str2 = "-";
      }
      while (str1.Length < 3)
        str1 = "0" + str1;
      string str3 = str1.Insert(str1.Length - 2, ",");
      if (str3.Length == 18)
        str3 = str3.Insert(3, ".").Insert(7, ".").Insert(11, ".").Insert(15, ".");
      if (str3.Length == 17)
        str3 = str3.Insert(2, ".").Insert(6, ".").Insert(10, ".").Insert(14, ".");
      if (str3.Length == 16)
        str3 = str3.Insert(1, ".").Insert(5, ".").Insert(9, ".").Insert(13, ".");
      if (str3.Length == 15)
        str3 = str3.Insert(3, ".").Insert(7, ".").Insert(11, ".");
      if (str3.Length == 14)
        str3 = str3.Insert(2, ".").Insert(6, ".").Insert(10, ".");
      if (str3.Length == 13)
        str3 = str3.Insert(1, ".").Insert(5, ".").Insert(9, ".");
      if (str3.Length == 12)
        str3 = str3.Insert(3, ".").Insert(7, ".");
      if (str3.Length == 11)
        str3 = str3.Insert(2, ".").Insert(6, ".");
      if (str3.Length == 10)
        str3 = str3.Insert(1, ".").Insert(5, ".");
      if (str3.Length == 9)
        str3 = str3.Insert(3, ".");
      if (str3.Length == 8)
        str3 = str3.Insert(2, ".");
      if (str3.Length == 7)
        str3 = str3.Insert(1, ".");
      return str2 + str3;
    }

    public long getNumericValue(string val)
    {
      return Convert.ToInt64(this.prepareNumber(val));
    }

    public string setMoneyFormat(long val)
    {
      return this.formatToMoney(Convert.ToString(val));
    }
  }
}
