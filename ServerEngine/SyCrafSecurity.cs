// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.SyCrafSecurity
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Text;

namespace SyCrafEngine
{
  public class SyCrafSecurity
  {
    private byte[] key = Encoding.UTF8.GetBytes("7HL5T7X9Z5N78UJ44HAL84UZ");
    public bool Error;

    public string GetTextEncrypted(string text)
    {
      Encryptor encryptor = new Encryptor(EncryptionAlgorithm.TripleDes);
      byte[] bytes1 = Encoding.UTF8.GetBytes(text);
      byte[] bytes2 = encryptor.Encrypt(bytes1, this.key);
      return HexEncoding.ToString(encryptor.IV) + HexEncoding.ToString(bytes2);
    }

    public string GetTextDescript(string text)
    {
      try
      {
        byte[] bytes = HexEncoding.GetBytes(text.Substring(0, 16));
        return Encoding.UTF8.GetString(new Decryptor(EncryptionAlgorithm.TripleDes)
        {
          IV = bytes
        }.Decrypt(HexEncoding.GetBytes(text.Substring(16, text.Length - 16)), this.key));
      }
      catch (SystemException ex)
      {
        ex.ToString();
        this.Error = true;
        return "";
      }
    }
  }
}
