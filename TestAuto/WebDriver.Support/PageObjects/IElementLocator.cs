// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.IElementLocator
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenQA.Selenium.Support.PageObjects
{
  public interface IElementLocator
  {
    ISearchContext SearchContext { get; }

    IWebElement LocateElement(IEnumerable<By> bys);

    ReadOnlyCollection<IWebElement> LocateElements(IEnumerable<By> bys);
  }
}
