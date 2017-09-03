// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.WebDriverWait
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Support.UI
{
  public class WebDriverWait : DefaultWait<IWebDriver>
  {
    private static TimeSpan DefaultSleepTimeout
    {
      get
      {
        return TimeSpan.FromMilliseconds(500.0);
      }
    }

    public WebDriverWait(IWebDriver driver, TimeSpan timeout)
      : this((IClock) new SystemClock(), driver, timeout, WebDriverWait.DefaultSleepTimeout)
    {
    }

    public WebDriverWait(IClock clock, IWebDriver driver, TimeSpan timeout, TimeSpan sleepInterval)
      : base(driver, clock)
    {
      this.Timeout = timeout;
      this.PollingInterval = sleepInterval;
      this.IgnoreExceptionTypes(typeof (NotFoundException));
    }
  }
}
