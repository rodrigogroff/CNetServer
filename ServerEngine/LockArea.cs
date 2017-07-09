// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.LockArea
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

using System;
using System.Collections;
using System.Threading;

namespace SyCrafEngine
{
  public class LockArea
  {
    private Hashtable hsh_lockObjs = new Hashtable();
    private Hashtable hsh_serials = new Hashtable();
    protected Random randObj = new Random();
    public int usingResourceSerial;
    public int usingResourceLock;
    public long currentSerial;

    public void getUniqueSerial(ref string new_serial)
    {
      while (Interlocked.Exchange(ref this.usingResourceSerial, 1) != 0)
        Thread.Sleep(1);
      ++this.currentSerial;
      new_serial = this.currentSerial.ToString();
      this.hsh_serials[(object) new_serial] = (object) "*";
      Interlocked.Exchange(ref this.usingResourceSerial, 0);
    }

    public void releaseSerial(string tag)
    {
      while (Interlocked.Exchange(ref this.usingResourceSerial, 1) != 0)
        Thread.Sleep(1);
      this.hsh_serials.Remove((object) tag);
      Interlocked.Exchange(ref this.usingResourceSerial, 0);
    }

    public void setLock(string lock_tag, string object_id, ref bool lock_resp)
    {
      while (Interlocked.Exchange(ref this.usingResourceLock, 1) != 0)
        Thread.Sleep(1);
      if (this.hsh_lockObjs[(object) lock_tag] == null)
      {
        LockObject lockObject = new LockObject();
        lockObject.useResource(object_id);
        this.hsh_lockObjs[(object) lock_tag] = (object) lockObject;
        lock_resp = true;
      }
      else
      {
        LockObject hshLockObj = this.hsh_lockObjs[(object) lock_tag] as LockObject;
        lock_resp = hshLockObj.useResource(object_id);
      }
      Interlocked.Exchange(ref this.usingResourceLock, 0);
    }

    public void releaseLock(string lock_tag, string object_id)
    {
      while (Interlocked.Exchange(ref this.usingResourceLock, 1) != 0)
        Thread.Sleep(1);
      if (this.hsh_lockObjs[(object) lock_tag] != null)
      {
        (this.hsh_lockObjs[(object) lock_tag] as LockObject).releaseResource(object_id);
        this.hsh_lockObjs[(object) lock_tag] = (object) null;
      }
      Interlocked.Exchange(ref this.usingResourceLock, 0);
    }
  }
}
