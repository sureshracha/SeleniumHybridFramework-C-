// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.Events.WebDriverExceptionEventArgs
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Support.Events
{
  public class WebDriverExceptionEventArgs : EventArgs
  {
    private Exception thrownException;
    private IWebDriver driver;

    public Exception ThrownException
    {
      get
      {
        return this.thrownException;
      }
    }

    public IWebDriver Driver
    {
      get
      {
        return this.driver;
      }
    }

    public WebDriverExceptionEventArgs(IWebDriver driver, Exception thrownException)
    {
      this.driver = driver;
      this.thrownException = thrownException;
    }
  }
}
