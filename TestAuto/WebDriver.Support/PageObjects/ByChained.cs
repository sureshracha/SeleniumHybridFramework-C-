// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.ByChained
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace OpenQA.Selenium.Support.PageObjects
{
  public class ByChained : By
  {
    private readonly By[] bys;

    public ByChained(params By[] bys)
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
      List<IWebElement> list1 = (List<IWebElement>) null;
      foreach (By by in this.bys)
      {
        List<IWebElement> list2 = new List<IWebElement>();
        if (list1 == null)
        {
          list2.AddRange((IEnumerable<IWebElement>) by.FindElements(context));
        }
        else
        {
          foreach (IWebElement webElement in list1)
            list2.AddRange((IEnumerable<IWebElement>) webElement.FindElements(by));
        }
        list1 = list2;
      }
      return list1.AsReadOnly();
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
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "By.Chained([{0}])", new object[1]
      {
        (object) ((object) stringBuilder).ToString()
      });
    }
  }
}
