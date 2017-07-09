// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.HexEncoding
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Globalization;
using System.Text;

namespace SyCrafEngine
{
  public class HexEncoding
  {
    public static int GetByteCount(string hexString)
    {
      int num = 0;
      for (int index = 0; index < hexString.Length; ++index)
      {
        if (HexEncoding.IsHexDigit(hexString[index]))
          ++num;
      }
      if (num % 2 != 0)
        --num;
      return num / 2;
    }

    public static byte[] GetBytes(string hexString)
    {
      int num = 0;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hexString.Length; ++index)
      {
        char c = hexString[index];
        if (HexEncoding.IsHexDigit(c))
          stringBuilder.Append(c);
        else
          ++num;
      }
      string str = stringBuilder.ToString();
      byte[] numArray = new byte[str.Length / 2];
      int index1 = 0;
      for (int index2 = 0; index2 < numArray.Length; ++index2)
      {
        string hex = new string(new char[2]
        {
          str[index1],
          str[index1 + 1]
        });
        numArray[index2] = HexEncoding.HexToByte(hex);
        index1 += 2;
      }
      return numArray;
    }

    public static string ToString(byte[] bytes)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < bytes.Length; ++index)
        stringBuilder.Append(bytes[index].ToString("X2"));
      return stringBuilder.ToString();
    }

    public static bool InHexFormat(string hexString)
    {
      bool flag = true;
      foreach (char c in hexString)
      {
        if (!HexEncoding.IsHexDigit(c))
        {
          flag = false;
          break;
        }
      }
      return flag;
    }

    public static bool IsHexDigit(char c)
    {
      int int32_1 = Convert.ToInt32('A');
      int int32_2 = Convert.ToInt32('0');
      c = char.ToUpper(c);
      int int32_3 = Convert.ToInt32(c);
      return int32_3 >= int32_1 && int32_3 < int32_1 + 6 || int32_3 >= int32_2 && int32_3 < int32_2 + 10;
    }

    public static byte HexToByte(string hex)
    {
      if (hex.Length > 2 || hex.Length <= 0)
        throw new ArgumentException("hex must be 1 or 2 characters in length");
      return byte.Parse(hex, NumberStyles.HexNumber);
    }
  }
}
