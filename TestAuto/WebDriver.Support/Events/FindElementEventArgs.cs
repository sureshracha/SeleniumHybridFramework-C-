// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.Events.FindElementEventArgs
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Support.Events
{
  public class FindElementEventArgs : EventArgs
  {
    private IWebDriver driver;
    private IWebElement element;
    private By method;

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

    public By FindMethod
    {
      get
      {
        return this.method;
      }
    }

    public FindElementEventArgs(IWebDriver driver, By method)
      : this(driver, (IWebElement) null, method)
    {
    }

    public FindElementEventArgs(IWebDriver driver, IWebElement element, By method)
    {
      this.driver = driver;
      this.element = element;
      this.method = method;
    }
  }
}
