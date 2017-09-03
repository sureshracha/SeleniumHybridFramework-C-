// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.ExpectedConditions
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenQA.Selenium.Support.UI
{
  public sealed class ExpectedConditions
  {
    private ExpectedConditions()
    {
    }

    public static Func<IWebDriver, bool> TitleIs(string title)
    {
      return (Func<IWebDriver, bool>) (driver => title == driver.Title);
    }

    public static Func<IWebDriver, bool> TitleContains(string title)
    {
      return (Func<IWebDriver, bool>) (driver => driver.Title.Contains(title));
    }

    public static Func<IWebDriver, bool> UrlToBe(string url)
    {
      return (Func<IWebDriver, bool>) (driver => driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant()));
    }

    public static Func<IWebDriver, bool> UrlContains(string fraction)
    {
      return (Func<IWebDriver, bool>) (driver => driver.Url.ToLowerInvariant().Contains(fraction.ToLowerInvariant()));
    }

    public static Func<IWebDriver, bool> UrlMatches(string regex)
    {
      return (Func<IWebDriver, bool>) (driver => new Regex(regex, RegexOptions.IgnoreCase).Match(driver.Url).Success);
    }

    public static Func<IWebDriver, IWebElement> ElementExists(By locator)
    {
      return (Func<IWebDriver, IWebElement>) (driver => driver.FindElement(locator));
    }

    public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
    {
      return (Func<IWebDriver, IWebElement>) (driver =>
      {
        try
        {
          return ExpectedConditions.ElementIfVisible(driver.FindElement(locator));
        }
        catch (StaleElementReferenceException ex)
        {
          return (IWebElement) null;
        }
      });
    }

    public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
    {
      return (Func<IWebDriver, ReadOnlyCollection<IWebElement>>) (driver =>
      {
        try
        {
          ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
          if (Enumerable.Any<IWebElement>((IEnumerable<IWebElement>) elements, (Func<IWebElement, bool>) (element => !element.Displayed)))
            return (ReadOnlyCollection<IWebElement>) null;
          else
            return Enumerable.Any<IWebElement>((IEnumerable<IWebElement>) elements) ? elements : (ReadOnlyCollection<IWebElement>) null;
        }
        catch (StaleElementReferenceException ex)
        {
          return (ReadOnlyCollection<IWebElement>) null;
        }
      });
    }

    public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(ReadOnlyCollection<IWebElement> elements)
    {
      return (Func<IWebDriver, ReadOnlyCollection<IWebElement>>) (driver =>
      {
        try
        {
          if (Enumerable.Any<IWebElement>((IEnumerable<IWebElement>) elements, (Func<IWebElement, bool>) (element => !element.Displayed)))
            return (ReadOnlyCollection<IWebElement>) null;
          else
            return Enumerable.Any<IWebElement>((IEnumerable<IWebElement>) elements) ? elements : (ReadOnlyCollection<IWebElement>) null;
        }
        catch (StaleElementReferenceException ex)
        {
          return (ReadOnlyCollection<IWebElement>) null;
        }
      });
    }

    public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
    {
      return (Func<IWebDriver, ReadOnlyCollection<IWebElement>>) (driver =>
      {
        try
        {
          ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
          return Enumerable.Any<IWebElement>((IEnumerable<IWebElement>) elements) ? elements : (ReadOnlyCollection<IWebElement>) null;
        }
        catch (StaleElementReferenceException ex)
        {
          return (ReadOnlyCollection<IWebElement>) null;
        }
      });
    }

    public static Func<IWebDriver, bool> TextToBePresentInElement(IWebElement element, string text)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          return element.Text.Contains(text);
        }
        catch (StaleElementReferenceException ex)
        {
          return false;
        }
      });
    }

    public static Func<IWebDriver, bool> TextToBePresentInElementLocated(By locator, string text)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          return driver.FindElement(locator).Text.Contains(text);
        }
        catch (StaleElementReferenceException ex)
        {
          return false;
        }
      });
    }

    public static Func<IWebDriver, bool> TextToBePresentInElementValue(IWebElement element, string text)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          string attribute = element.GetAttribute("value");
          if (attribute != null)
            return attribute.Contains(text);
          else
            return false;
        }
        catch (StaleElementReferenceException ex)
        {
          return false;
        }
      });
    }

    public static Func<IWebDriver, bool> TextToBePresentInElementValue(By locator, string text)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          string attribute = driver.FindElement(locator).GetAttribute("value");
          if (attribute != null)
            return attribute.Contains(text);
          else
            return false;
        }
        catch (StaleElementReferenceException ex)
        {
          return false;
        }
      });
    }

    public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(string frameLocator)
    {
      return (Func<IWebDriver, IWebDriver>) (driver =>
      {
        try
        {
          return driver.SwitchTo().Frame(frameLocator);
        }
        catch (NoSuchFrameException ex)
        {
          return (IWebDriver) null;
        }
      });
    }

    public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(By locator)
    {
      return (Func<IWebDriver, IWebDriver>) (driver =>
      {
        try
        {
          IWebElement element = driver.FindElement(locator);
          return driver.SwitchTo().Frame(element);
        }
        catch (NoSuchFrameException ex)
        {
          return (IWebDriver) null;
        }
      });
    }

    public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          return !driver.FindElement(locator).Displayed;
        }
        catch (NoSuchElementException ex)
        {
          return true;
        }
        catch (StaleElementReferenceException ex)
        {
          return true;
        }
      });
    }

    public static Func<IWebDriver, bool> InvisibilityOfElementWithText(By locator, string text)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          string text1 = driver.FindElement(locator).Text;
          if (string.IsNullOrEmpty(text1))
            return true;
          else
            return !text1.Equals(text);
        }
        catch (NoSuchElementException ex)
        {
          return true;
        }
        catch (StaleElementReferenceException ex)
        {
          return true;
        }
      });
    }

    public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
    {
      return (Func<IWebDriver, IWebElement>) (driver =>
      {
        IWebElement webElement = ExpectedConditions.ElementIfVisible(driver.FindElement(locator));
        try
        {
          if (webElement != null && webElement.Enabled)
            return webElement;
          else
            return (IWebElement) null;
        }
        catch (StaleElementReferenceException ex)
        {
          return (IWebElement) null;
        }
      });
    }

    public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
    {
      return (Func<IWebDriver, IWebElement>) (driver =>
      {
        try
        {
          if (element != null && element.Displayed && element.Enabled)
            return element;
          else
            return (IWebElement) null;
        }
        catch (StaleElementReferenceException ex)
        {
          return (IWebElement) null;
        }
      });
    }

    public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          return element == null || !element.Enabled;
        }
        catch (StaleElementReferenceException ex)
        {
          return true;
        }
      });
    }

    public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element)
    {
      return ExpectedConditions.ElementSelectionStateToBe(element, true);
    }

    public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element, bool selected)
    {
      return (Func<IWebDriver, bool>) (driver => element.Selected == selected);
    }

    public static Func<IWebDriver, bool> ElementSelectionStateToBe(IWebElement element, bool selected)
    {
      return (Func<IWebDriver, bool>) (driver => element.Selected == selected);
    }

    public static Func<IWebDriver, bool> ElementToBeSelected(By locator)
    {
      return ExpectedConditions.ElementSelectionStateToBe(locator, true);
    }

    public static Func<IWebDriver, bool> ElementSelectionStateToBe(By locator, bool selected)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          return driver.FindElement(locator).Selected == selected;
        }
        catch (StaleElementReferenceException ex)
        {
          return false;
        }
      });
    }

    public static Func<IWebDriver, IAlert> AlertIsPresent()
    {
      return (Func<IWebDriver, IAlert>) (driver =>
      {
        try
        {
          return driver.SwitchTo().Alert();
        }
        catch (NoAlertPresentException ex)
        {
          return (IAlert) null;
        }
      });
    }

    public static Func<IWebDriver, bool> AlertState(bool state)
    {
      return (Func<IWebDriver, bool>) (driver =>
      {
        try
        {
          driver.SwitchTo().Alert();
          return true == state;
        }
        catch (NoAlertPresentException ex)
        {
          return false == state;
        }
      });
    }

    private static IWebElement ElementIfVisible(IWebElement element)
    {
      if (!element.Displayed)
        return (IWebElement) null;
      else
        return element;
    }
  }
}
