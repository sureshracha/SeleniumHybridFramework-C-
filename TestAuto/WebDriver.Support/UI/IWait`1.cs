// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.IWait`1
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using System;

namespace OpenQA.Selenium.Support.UI
{
  public interface IWait<T>
  {
    TimeSpan Timeout { get; set; }

    TimeSpan PollingInterval { get; set; }

    string Message { get; set; }

    void IgnoreExceptionTypes(params Type[] exceptionTypes);

    TResult Until<TResult>(Func<T, TResult> condition);
  }
}
