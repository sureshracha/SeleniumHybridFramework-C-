// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.SelectElement
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenQA.Selenium.Support.UI
{
  public class SelectElement : IWrapsElement
  {
    private readonly IWebElement element;

    public IWebElement WrappedElement
    {
      get
      {
        return this.element;
      }
    }

    public bool IsMultiple { get; private set; }

    public IList<IWebElement> Options
    {
      get
      {
        return (IList<IWebElement>) this.element.FindElements(By.TagName("option"));
      }
    }

    public IWebElement SelectedOption
    {
      get
      {
        foreach (IWebElement webElement in (IEnumerable<IWebElement>) this.Options)
        {
          if (webElement.Selected)
            return webElement;
        }
        throw new NoSuchElementException("No option is selected");
      }
    }

    public IList<IWebElement> AllSelectedOptions
    {
      get
      {
        List<IWebElement> list = new List<IWebElement>();
        foreach (IWebElement webElement in (IEnumerable<IWebElement>) this.Options)
        {
          if (webElement.Selected)
            list.Add(webElement);
        }
        return (IList<IWebElement>) list;
      }
    }

    public SelectElement(IWebElement element)
    {
      if (element == null)
        throw new ArgumentNullException("element", "element cannot be null");
      if (string.IsNullOrEmpty(element.TagName) || string.Compare(element.TagName, "select", StringComparison.OrdinalIgnoreCase) != 0)
        throw new UnexpectedTagNameException("select", element.TagName);
      this.element = element;
      string attribute = element.GetAttribute("multiple");
      this.IsMultiple = attribute != null && attribute.ToLowerInvariant() != "false";
    }

    public void SelectByText(string text)
    {
      if (text == null)
        throw new ArgumentNullException("text", "text must not be null");
      IList<IWebElement> list = (IList<IWebElement>) this.element.FindElements(By.XPath(".//option[normalize-space(.) = " + SelectElement.EscapeQuotes(text) + "]"));
      bool flag = false;
      foreach (IWebElement option in (IEnumerable<IWebElement>) list)
      {
        SelectElement.SetSelected(option, true);
        if (!this.IsMultiple)
          return;
        flag = true;
      }
      if (list.Count == 0 && text.Contains(" "))
      {
        string substringWithoutSpace = SelectElement.GetLongestSubstringWithoutSpace(text);
        foreach (IWebElement option in !string.IsNullOrEmpty(substringWithoutSpace) ? (IEnumerable<IWebElement>) this.element.FindElements(By.XPath(".//option[contains(., " + SelectElement.EscapeQuotes(substringWithoutSpace) + ")]")) : (IEnumerable<IWebElement>) this.element.FindElements(By.TagName("option")))
        {
          if (text == option.Text)
          {
            SelectElement.SetSelected(option, true);
            if (!this.IsMultiple)
              return;
            flag = true;
          }
        }
      }
      if (!flag)
        throw new NoSuchElementException("Cannot locate element with text: " + text);
    }

    public void SelectByValue(string value)
    {
      StringBuilder stringBuilder = new StringBuilder(".//option[@value = ");
      stringBuilder.Append(SelectElement.EscapeQuotes(value));
      stringBuilder.Append("]");
      IList<IWebElement> list = (IList<IWebElement>) this.element.FindElements(By.XPath(((object) stringBuilder).ToString()));
      bool flag = false;
      foreach (IWebElement option in (IEnumerable<IWebElement>) list)
      {
        SelectElement.SetSelected(option, true);
        if (!this.IsMultiple)
          return;
        flag = true;
      }
      if (!flag)
        throw new NoSuchElementException("Cannot locate option with value: " + value);
    }

    public void SelectByIndex(int index)
    {
      string str = index.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      foreach (IWebElement option in (IEnumerable<IWebElement>) this.Options)
      {
        if (option.GetAttribute("index") == str)
        {
          SelectElement.SetSelected(option, true);
          return;
        }
      }
      throw new NoSuchElementException("Cannot locate option with index: " + (object) index);
    }

    public void DeselectAll()
    {
      if (!this.IsMultiple)
        throw new InvalidOperationException("You may only deselect all options if multi-select is supported");
      foreach (IWebElement option in (IEnumerable<IWebElement>) this.Options)
        SelectElement.SetSelected(option, false);
    }

    public void DeselectByText(string text)
    {
      if (!this.IsMultiple)
        throw new InvalidOperationException("You may only deselect option if multi-select is supported");
      bool flag = false;
      StringBuilder stringBuilder = new StringBuilder(".//option[normalize-space(.) = ");
      stringBuilder.Append(SelectElement.EscapeQuotes(text));
      stringBuilder.Append("]");
      foreach (IWebElement option in (IEnumerable<IWebElement>) this.element.FindElements(By.XPath(((object) stringBuilder).ToString())))
      {
        SelectElement.SetSelected(option, false);
        flag = true;
      }
      if (!flag)
        throw new NoSuchElementException("Cannot locate option with text: " + text);
    }

    public void DeselectByValue(string value)
    {
      if (!this.IsMultiple)
        throw new InvalidOperationException("You may only deselect option if multi-select is supported");
      bool flag = false;
      StringBuilder stringBuilder = new StringBuilder(".//option[@value = ");
      stringBuilder.Append(SelectElement.EscapeQuotes(value));
      stringBuilder.Append("]");
      foreach (IWebElement option in (IEnumerable<IWebElement>) this.element.FindElements(By.XPath(((object) stringBuilder).ToString())))
      {
        SelectElement.SetSelected(option, false);
        flag = true;
      }
      if (!flag)
        throw new NoSuchElementException("Cannot locate option with value: " + value);
    }

    public void DeselectByIndex(int index)
    {
      if (!this.IsMultiple)
        throw new InvalidOperationException("You may only deselect option if multi-select is supported");
      string str = index.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      foreach (IWebElement option in (IEnumerable<IWebElement>) this.Options)
      {
        if (str == option.GetAttribute("index"))
        {
          SelectElement.SetSelected(option, false);
          return;
        }
      }
      throw new NoSuchElementException("Cannot locate option with index: " + (object) index);
    }

    private static string EscapeQuotes(string toEscape)
    {
      if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1 && toEscape.IndexOf("'", StringComparison.OrdinalIgnoreCase) > -1)
      {
        bool flag = false;
        if (toEscape.LastIndexOf("\"", StringComparison.OrdinalIgnoreCase) == toEscape.Length - 1)
          flag = true;
        List<string> list = new List<string>((IEnumerable<string>) toEscape.Split('"'));
        if (flag && string.IsNullOrEmpty(list[list.Count - 1]))
          list.RemoveAt(list.Count - 1);
        StringBuilder stringBuilder = new StringBuilder("concat(");
        for (int index = 0; index < list.Count; ++index)
        {
          stringBuilder.Append("\"").Append(list[index]).Append("\"");
          if (index == list.Count - 1)
          {
            if (flag)
              stringBuilder.Append(", '\"')");
            else
              stringBuilder.Append(")");
          }
          else
            stringBuilder.Append(", '\"', ");
        }
        return ((object) stringBuilder).ToString();
      }
      else if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1)
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "'{0}'", new object[1]
        {
          (object) toEscape
        });
      else
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "\"{0}\"", new object[1]
        {
          (object) toEscape
        });
    }

    private static string GetLongestSubstringWithoutSpace(string s)
    {
      string str1 = string.Empty;
      string str2 = s;
      char[] chArray = new char[1]
      {
        ' '
      };
      foreach (string str3 in str2.Split(chArray))
      {
        if (str3.Length > str1.Length)
          str1 = str3;
      }
      return str1;
    }

    private static void SetSelected(IWebElement option, bool select)
    {
      bool selected = option.Selected;
      if ((selected || !select) && (!selected || select))
        return;
      option.Click();
    }
  }
}
