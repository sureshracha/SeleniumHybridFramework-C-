// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Support.Events
{
  public class WebDriverNavigationEventArgs : EventArgs
  {
    private string url;
    private IWebDriver driver;

    public string Url
    {
      get
      {
        return this.url;
      }
    }

    public IWebDriver Driver
    {
      get
      {
        return this.driver;
      }
    }

    public WebDriverNavigationEventArgs(IWebDriver driver)
      : this(driver, (string) null)
    {
    }

    public WebDriverNavigationEventArgs(IWebDriver driver, string url)
    {
      this.url = url;
      this.driver = driver;
    }
  }
}
