// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.Encryptor
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.IO;
using System.Security.Cryptography;

namespace SyCrafEngine
{
  public class Encryptor
  {
    private EncryptTransformer transformer;
    private byte[] initVec;
    private byte[] encKey;

    public byte[] IV
    {
      get
      {
        return this.initVec;
      }
      set
      {
        this.initVec = value;
      }
    }

    public byte[] Key
    {
      get
      {
        return this.encKey;
      }
    }

    public Encryptor(EncryptionAlgorithm algId)
    {
      this.transformer = new EncryptTransformer(algId);
    }

    public byte[] Encrypt(byte[] bytesData, byte[] bytesKey)
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
        throw new Exception("Error while writing encrypted data to the  stream: \n" + ex.Message);
      }
      this.encKey = this.transformer.Key;
      this.initVec = this.transformer.IV;
      cryptoStream.FlushFinalBlock();
      cryptoStream.Close();
      return memoryStream.ToArray();
    }
  }
}
