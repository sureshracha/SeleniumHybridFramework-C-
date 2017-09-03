// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.SystemClock
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using System;

namespace OpenQA.Selenium.Support.UI
{
  public class SystemClock : IClock
  {
    public DateTime Now
    {
      get
      {
        return DateTime.Now;
      }
    }

    public DateTime LaterBy(TimeSpan delay)
    {
      return DateTime.Now.Add(delay);
    }

    public bool IsNowBefore(DateTime otherDateTime)
    {
      return DateTime.Now < otherDateTime;
    }
  }
}
