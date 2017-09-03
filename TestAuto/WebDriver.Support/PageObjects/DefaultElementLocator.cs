// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.DefaultElementLocator
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenQA.Selenium.Support.PageObjects
{
  public class DefaultElementLocator : IElementLocator
  {
    private ISearchContext searchContext;

    public ISearchContext SearchContext
    {
      get
      {
        return this.searchContext;
      }
    }

    public DefaultElementLocator(ISearchContext searchContext)
    {
      this.searchContext = searchContext;
    }

    public IWebElement LocateElement(IEnumerable<By> bys)
    {
      if (bys == null)
        throw new ArgumentNullException("bys", "List of criteria may not be null");
      string message = (string) null;
      foreach (By by in bys)
      {
        try
        {
          return this.searchContext.FindElement(by);
        }
        catch (NoSuchElementException ex)
        {
          message = (string) (message == null ? (object) "Could not find element by: " : (object) (message + ", or: ")) + (object) by;
        }
      }
      throw new NoSuchElementException(message);
    }

    public ReadOnlyCollection<IWebElement> LocateElements(IEnumerable<By> bys)
    {
      if (bys == null)
        throw new ArgumentNullException("bys", "List of criteria may not be null");
      List<IWebElement> list = new List<IWebElement>();
      foreach (By by in bys)
      {
        ReadOnlyCollection<IWebElement> elements = this.searchContext.FindElements(by);
        list.AddRange((IEnumerable<IWebElement>) elements);
      }
      return list.AsReadOnly();
    }
  }
}
