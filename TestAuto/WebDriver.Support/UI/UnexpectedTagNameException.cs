// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.UnexpectedTagNameException
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace OpenQA.Selenium.Support.UI
{
  [Serializable]
  public class UnexpectedTagNameException : WebDriverException
  {
    public UnexpectedTagNameException(string expected, string actual)
      : base(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Element should have been {0} but was {1}", new object[2]
      {
        (object) expected,
        (object) actual
      }))
    {
    }

    public UnexpectedTagNameException()
    {
    }

    public UnexpectedTagNameException(string message)
      : base(message)
    {
    }

    public UnexpectedTagNameException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected UnexpectedTagNameException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
