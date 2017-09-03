// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.LoadableComponentException
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Runtime.Serialization;

namespace OpenQA.Selenium.Support.UI
{
  [Serializable]
  public class LoadableComponentException : WebDriverException
  {
    public LoadableComponentException()
    {
    }

    public LoadableComponentException(string message)
      : base(message)
    {
    }

    public LoadableComponentException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected LoadableComponentException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
