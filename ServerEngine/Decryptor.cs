// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Decryptor
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.IO;
using System.Security.Cryptography;

namespace SyCrafEngine
{
  public class Decryptor
  {
    private DecryptTransformer transformer;
    private byte[] initVec;

    public byte[] IV
    {
      set
      {
        this.initVec = value;
      }
    }

    public Decryptor(EncryptionAlgorithm algId)
    {
      this.transformer = new DecryptTransformer(algId);
    }

    public byte[] Decrypt(byte[] bytesData, byte[] bytesKey)
    {
      MemoryStream memoryStream = new MemoryStream();
      this.transformer.IV = this.initVec;
      ICryptoTransform cryptoServiceProvider = this.transformer.GetCryptoServiceProvider(bytesKey);
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider, CryptoStreamMode.Write);
      try
      {
        cryptoStream.Write(bytesData, 0, bytesData.Length);
      }
      catch (Exception ex)
      {
        throw new Exception("Error while writing encrypted data to the stream: \n" + ex.Message);
      }
      cryptoStream.FlushFinalBlock();
      cryptoStream.Close();
      return memoryStream.ToArray();
    }
  }
}
