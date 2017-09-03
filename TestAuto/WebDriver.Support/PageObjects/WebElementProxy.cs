// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.WebElementProxy
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace OpenQA.Selenium.Support.PageObjects
{
  internal sealed class WebElementProxy : WebDriverObjectProxy, IWrapsElement
  {
    private IWebElement cachedElement;

    public IWebElement WrappedElement
    {
      get
      {
        return this.Element;
      }
    }

    private IWebElement Element
    {
      get
      {
        if (!this.Cache || this.cachedElement == null)
          this.cachedElement = this.Locator.LocateElement(this.Bys);
        return this.cachedElement;
      }
    }

    private WebElementProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cache)
      : base(classToProxy, locator, bys, cache)
    {
    }

    public static object CreateProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cacheLookups)
    {
      return new WebElementProxy(classToProxy, locator, bys, cacheLookups).GetTransparentProxy();
    }

    public override IMessage Invoke(IMessage msg)
    {
      IWebElement element = this.Element;
      IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;
      if (typeof (IWrapsElement).IsAssignableFrom((methodCallMessage.MethodBase as MethodInfo).DeclaringType))
        return (IMessage) new ReturnMessage((object) element, (object[]) null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
      else
        return (IMessage) WebDriverObjectProxy.InvokeMethod(methodCallMessage, (object) element);
    }
  }
}
