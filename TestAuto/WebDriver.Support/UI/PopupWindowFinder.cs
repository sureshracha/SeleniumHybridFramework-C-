// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.PopupWindowFinder
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenQA.Selenium.Support.UI
{
  public class PopupWindowFinder
  {
    private readonly IWebDriver driver;
    private readonly TimeSpan timeout;
    private readonly TimeSpan sleepInterval;

    private static TimeSpan DefaultTimeout
    {
      get
      {
        return TimeSpan.FromSeconds(5.0);
      }
    }

    private static TimeSpan DefaultSleepInterval
    {
      get
      {
        return TimeSpan.FromMilliseconds(250.0);
      }
    }

    public PopupWindowFinder(IWebDriver driver)
      : this(driver, PopupWindowFinder.DefaultTimeout, PopupWindowFinder.DefaultSleepInterval)
    {
    }

    public PopupWindowFinder(IWebDriver driver, TimeSpan timeout)
      : this(driver, timeout, PopupWindowFinder.DefaultSleepInterval)
    {
    }

    public PopupWindowFinder(IWebDriver driver, TimeSpan timeout, TimeSpan sleepInterval)
    {
      this.driver = driver;
      this.timeout = timeout;
      this.sleepInterval = sleepInterval;
    }

    public string Click(IWebElement element)
    {
      if (element == null)
        throw new ArgumentNullException("element", "element cannot be null");
      else
        return this.Invoke((Action) (() => element.Click()));
    }

    public string Invoke(Action popupMethod)
    {
      if (popupMethod == null)
        throw new ArgumentNullException("popupMethod", "popupMethod cannot be null");
      IList<string> existingHandles = (IList<string>) this.driver.WindowHandles;
      popupMethod();
      return new WebDriverWait((IClock) new SystemClock(), this.driver, this.timeout, this.sleepInterval).Until<string>((Func<IWebDriver, string>) (d =>
      {
        string str = (string) null;
        IList<string> difference = PopupWindowFinder.GetDifference(existingHandles, (IList<string>) this.driver.WindowHandles);
        if (difference.Count > 0)
          str = difference[0];
        return str;
      }));
    }

    private static IList<string> GetDifference(IList<string> existingHandles, IList<string> currentHandles)
    {
      return (IList<string>) Enumerable.ToList<string>(Enumerable.Except<string>((IEnumerable<string>) currentHandles, (IEnumerable<string>) existingHandles));
    }
  }
}
