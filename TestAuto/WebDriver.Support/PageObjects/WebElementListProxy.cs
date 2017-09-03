// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.WebElementListProxy
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace OpenQA.Selenium.Support.PageObjects
{
  internal class WebElementListProxy : WebDriverObjectProxy
  {
    private List<IWebElement> collection;

    private List<IWebElement> ElementList
    {
      get
      {
        if (!this.Cache || this.collection == null)
        {
          this.collection = new List<IWebElement>();
          this.collection.AddRange((IEnumerable<IWebElement>) this.Locator.LocateElements(this.Bys));
        }
        return this.collection;
      }
    }

    private WebElementListProxy(Type typeToBeProxied, IElementLocator locator, IEnumerable<By> bys, bool cache)
      : base(typeToBeProxied, locator, bys, cache)
    {
    }

    public static object CreateProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cacheLookups)
    {
      return new WebElementListProxy(classToProxy, locator, bys, cacheLookups).GetTransparentProxy();
    }

    public override IMessage Invoke(IMessage msg)
    {
      List<IWebElement> elementList = this.ElementList;
      return (IMessage) WebDriverObjectProxy.InvokeMethod(msg as IMethodCallMessage, (object) elementList);
    }
  }
}
