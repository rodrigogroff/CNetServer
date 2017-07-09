// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.DecryptTransformer
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System.Security.Cryptography;

namespace SyCrafEngine
{
  public class DecryptTransformer
  {
    private EncryptionAlgorithm algorithmID;
    private byte[] initVec;

    internal byte[] IV
    {
      set
      {
        this.initVec = value;
      }
    }

    internal DecryptTransformer(EncryptionAlgorithm deCryptId)
    {
      this.algorithmID = deCryptId;
    }

    internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
    {
      switch (this.algorithmID)
      {
        case EncryptionAlgorithm.Des:
          DES des = (DES) new DESCryptoServiceProvider();
          des.Mode = CipherMode.CBC;
          des.Key = bytesKey;
          des.IV = this.initVec;
          return des.CreateDecryptor();
        case EncryptionAlgorithm.Rc2:
          RC2 rc2 = (RC2) new RC2CryptoServiceProvider();
          rc2.Mode = CipherMode.CBC;
          return rc2.CreateDecryptor(bytesKey, this.initVec);
        case EncryptionAlgorithm.Rijndael:
          Rijndael rijndael = (Rijndael) new RijndaelManaged();
          rijndael.Mode = CipherMode.CBC;
          return rijndael.CreateDecryptor(bytesKey, this.initVec);
        case EncryptionAlgorithm.TripleDes:
          TripleDES tripleDes = (TripleDES) new TripleDESCryptoServiceProvider();
          tripleDes.Mode = CipherMode.CBC;
          return tripleDes.CreateDecryptor(bytesKey, this.initVec);
        default:
          throw new CryptographicException("Algorithm ID '" + (object) this.algorithmID + "' not supported.");
      }
    }
  }
}
