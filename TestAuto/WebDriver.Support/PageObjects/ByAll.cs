// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.ByAll
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OpenQA.Selenium.Support.PageObjects
{
  public class ByAll : By
  {
    private readonly By[] bys;

    public ByAll(params By[] bys)
    {
      this.bys = bys;
    }

    public override IWebElement FindElement(ISearchContext context)
    {
      ReadOnlyCollection<IWebElement> elements = this.FindElements(context);
      if (elements.Count == 0)
        throw new NoSuchElementException("Cannot locate an element using " + this.ToString());
      else
        return elements[0];
    }

    public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
    {
      if (this.bys.Length == 0)
        return new List<IWebElement>().AsReadOnly();
      IEnumerable<IWebElement> enumerable = (IEnumerable<IWebElement>) null;
      foreach (By by in this.bys)
      {
        ReadOnlyCollection<IWebElement> elements = by.FindElements(context);
        if (elements.Count == 0)
          return new List<IWebElement>().AsReadOnly();
        enumerable = enumerable != null ? Enumerable.Intersect<IWebElement>(enumerable, (IEnumerable<IWebElement>) by.FindElements(context)) : (IEnumerable<IWebElement>) elements;
      }
      return Enumerable.ToList<IWebElement>(enumerable).AsReadOnly();
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (By by in this.bys)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append(",");
        stringBuilder.Append((object) by);
      }
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "By.All([{0}])", new object[1]
      {
        (object) ((object) stringBuilder).ToString()
      });
    }
  }
}
