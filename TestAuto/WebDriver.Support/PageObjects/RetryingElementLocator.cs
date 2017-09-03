// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.RetryingElementLocator
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace OpenQA.Selenium.Support.PageObjects
{
  public class RetryingElementLocator : IElementLocator
  {
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(5.0);
    private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(500.0);
    private ISearchContext searchContext;
    private TimeSpan timeout;
    private TimeSpan pollingInterval;

    public ISearchContext SearchContext
    {
      get
      {
        return this.searchContext;
      }
    }

    public RetryingElementLocator(ISearchContext searchContext)
      : this(searchContext, RetryingElementLocator.DefaultTimeout)
    {
    }

    public RetryingElementLocator(ISearchContext searchContext, TimeSpan timeout)
      : this(searchContext, timeout, RetryingElementLocator.DefaultPollingInterval)
    {
    }

    public RetryingElementLocator(ISearchContext searchContext, TimeSpan timeout, TimeSpan pollingInterval)
    {
      this.searchContext = searchContext;
      this.timeout = timeout;
      this.pollingInterval = pollingInterval;
    }

    public IWebElement LocateElement(IEnumerable<By> bys)
    {
      if (bys == null)
        throw new ArgumentNullException("bys", "List of criteria may not be null");
      string message = (string) null;
      DateTime dateTime = DateTime.Now.Add(this.timeout);
      bool flag = DateTime.Now > dateTime;
      while (!flag)
      {
        foreach (By by in bys)
        {
          try
          {
            return this.SearchContext.FindElement(by);
          }
          catch (NoSuchElementException ex)
          {
            message = (string) (message == null ? (object) "Could not find element by: " : (object) (message + ", or: ")) + (object) by;
          }
        }
        flag = DateTime.Now > dateTime;
        if (!flag)
          Thread.Sleep(this.pollingInterval);
      }
      throw new NoSuchElementException(message);
    }

    public ReadOnlyCollection<IWebElement> LocateElements(IEnumerable<By> bys)
    {
      if (bys == null)
        throw new ArgumentNullException("bys", "List of criteria may not be null");
      List<IWebElement> list = new List<IWebElement>();
      DateTime dateTime = DateTime.Now.Add(this.timeout);
      bool flag = DateTime.Now > dateTime;
      while (!flag)
      {
        foreach (By by in bys)
        {
          ReadOnlyCollection<IWebElement> elements = this.SearchContext.FindElements(by);
          list.AddRange((IEnumerable<IWebElement>) elements);
        }
        flag = list.Count != 0 || DateTime.Now > dateTime;
        if (!flag)
          Thread.Sleep(this.pollingInterval);
      }
      return list.AsReadOnly();
    }
  }
}
