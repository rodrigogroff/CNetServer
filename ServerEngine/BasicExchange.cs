// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.BasicExchange
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SyCrafEngine
{
  public class BasicExchange
  {
    public bool WriteMsgToClient(ref NetworkStream stream, string buffer_response)
    {
      byte[] bytes = Encoding.Default.GetBytes(buffer_response);
label_1:
      Thread.Sleep(1);
      try
      {
        if (stream.CanWrite)
        {
          stream.Write(bytes, 0, bytes.Length);
          stream.Flush();
        }
        else
          goto label_1;
      }
      catch (ArgumentOutOfRangeException ex)
      {
        ex.ToString();
        return false;
      }
      catch (ArgumentNullException ex)
      {
        ex.ToString();
        return false;
      }
      catch (IOException ex)
      {
        ex.ToString();
        return false;
      }
      catch (ObjectDisposedException ex)
      {
        ex.ToString();
        return false;
      }
      return true;
    }

    public string ReceiveMsgFromClient(ref NetworkStream stream, int m_max_packet_size)
    {
      byte[] numArray1 = new byte[m_max_packet_size];
      long num = 2000;
label_1:
      Thread.Sleep(1);
      if (--num == 0L)
        return "";
      try
      {
        if (stream.DataAvailable)
        {
          int count1 = stream.Read(numArray1, 0, m_max_packet_size);
          string str = Encoding.Default.GetString(numArray1, 0, count1);
          int int32;
          if (str.StartsWith("SYCRAF"))
          {
            int32 = Convert.ToInt32(str.Substring(6, 6));
          }
          else
          {
            if (!str.StartsWith("CMDSTDBY"))
              return str;
            int32 = Convert.ToInt32(str.Substring(8, 6));
          }
          while (count1 < int32)
          {
            Thread.Sleep(1);
            if (stream.DataAvailable)
            {
              byte[] numArray2 = new byte[m_max_packet_size];
              int count2 = stream.Read(numArray2, 0, m_max_packet_size);
              count1 += count2;
              str += Encoding.Default.GetString(numArray2, 0, count2);
            }
          }
          return str;
        }
        goto label_1;
      }
      catch (ArgumentOutOfRangeException ex)
      {
        ex.ToString();
        return "";
      }
      catch (ArgumentNullException ex)
      {
        ex.ToString();
        return "";
      }
      catch (IOException ex)
      {
        ex.ToString();
        return "";
      }
      catch (ObjectDisposedException ex)
      {
        ex.ToString();
        return "";
      }
    }
  }
}
