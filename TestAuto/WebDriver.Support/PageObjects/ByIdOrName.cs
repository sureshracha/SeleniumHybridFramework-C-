// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.ByIdOrName
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace OpenQA.Selenium.Support.PageObjects
{
  public class ByIdOrName : By
  {
    private string elementIdentifier = string.Empty;
    private By idFinder;
    private By nameFinder;

    public ByIdOrName(string elementIdentifier)
    {
      if (string.IsNullOrEmpty(elementIdentifier))
        throw new ArgumentException("element identifier cannot be null or the empty string", "elementIdentifier");
      this.elementIdentifier = elementIdentifier;
      this.idFinder = By.Id(this.elementIdentifier);
      this.nameFinder = By.Name(this.elementIdentifier);
    }

    public override IWebElement FindElement(ISearchContext context)
    {
      try
      {
        return this.idFinder.FindElement(context);
      }
      catch (NoSuchElementException ex)
      {
        return this.nameFinder.FindElement(context);
      }
    }

    public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
    {
      List<IWebElement> list = new List<IWebElement>();
      list.AddRange((IEnumerable<IWebElement>) this.idFinder.FindElements(context));
      list.AddRange((IEnumerable<IWebElement>) this.nameFinder.FindElements(context));
      return list.AsReadOnly();
    }

    public override string ToString()
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "ByIdOrName([{0}])", new object[1]
      {
        (object) this.elementIdentifier
      });
    }
  }
}
