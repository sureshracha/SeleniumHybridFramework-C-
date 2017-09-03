// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.Events.WebElementEventArgs
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Support.Events
{
  public class WebElementEventArgs : EventArgs
  {
    private IWebDriver driver;
    private IWebElement element;

    public IWebDriver Driver
    {
      get
      {
        return this.driver;
      }
    }

    public IWebElement Element
    {
      get
      {
        return this.element;
      }
    }

    public WebElementEventArgs(IWebDriver driver, IWebElement element)
    {
      this.driver = driver;
      this.element = element;
    }
  }
}
