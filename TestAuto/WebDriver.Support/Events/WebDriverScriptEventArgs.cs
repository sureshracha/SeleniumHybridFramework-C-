// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.Events.WebDriverScriptEventArgs
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Support.Events
{
  public class WebDriverScriptEventArgs : EventArgs
  {
    private IWebDriver driver;
    private string script;

    public IWebDriver Driver
    {
      get
      {
        return this.driver;
      }
    }

    public string Script
    {
      get
      {
        return this.script;
      }
    }

    public WebDriverScriptEventArgs(IWebDriver driver, string script)
    {
      this.driver = driver;
      this.script = script;
    }
  }
}
