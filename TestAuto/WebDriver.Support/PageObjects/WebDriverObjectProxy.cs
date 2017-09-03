// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.WebDriverObjectProxy
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace OpenQA.Selenium.Support.PageObjects
{
  internal abstract class WebDriverObjectProxy : RealProxy
  {
    private readonly IElementLocator locator;
    private readonly IEnumerable<By> bys;
    private readonly bool cache;

    protected IElementLocator Locator
    {
      get
      {
        return this.locator;
      }
    }

    protected IEnumerable<By> Bys
    {
      get
      {
        return this.bys;
      }
    }

    protected bool Cache
    {
      get
      {
        return this.cache;
      }
    }

    protected WebDriverObjectProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cache)
      : base(classToProxy)
    {
      this.locator = locator;
      this.bys = bys;
      this.cache = cache;
    }

    protected static ReturnMessage InvokeMethod(IMethodCallMessage msg, object representedValue)
    {
      if (msg == null)
        throw new ArgumentNullException("msg", "The message containing invocation information cannot be null");
      else
        return new ReturnMessage((msg.MethodBase as MethodInfo).Invoke(representedValue, msg.Args), (object[]) null, 0, msg.LogicalCallContext, msg);
    }
  }
}
