// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.Extensions.WebDriverExtensions
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Reflection;

namespace OpenQA.Selenium.Support.Extensions
{
  public static class WebDriverExtensions
  {
    public static Screenshot TakeScreenshot(this IWebDriver driver)
    {
      ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
      if (takesScreenshot != null)
        return takesScreenshot.GetScreenshot();
      IHasCapabilities hasCapabilities = driver as IHasCapabilities;
      if (hasCapabilities == null)
        throw new WebDriverException("Driver does not implement ITakesScreenshot or IHasCapabilities");
      if (!hasCapabilities.Capabilities.HasCapability(CapabilityType.TakesScreenshot) || !(bool) hasCapabilities.Capabilities.GetCapability(CapabilityType.TakesScreenshot))
        throw new WebDriverException("Driver capabilities do not support taking screenshots");
      Response response = driver.GetType().GetMethod("Execute", BindingFlags.Instance | BindingFlags.NonPublic).Invoke((object) driver, new object[2]
      {
        (object) DriverCommand.Screenshot,
        null
      }) as Response;
      if (response == null)
        throw new WebDriverException("Unexpected failure getting screenshot; response was not in the proper format.");
      else
        return new Screenshot(response.Value.ToString());
    }

    public static void ExecuteJavaScript(this IWebDriver driver, string script, params object[] args)
    {
      WebDriverExtensions.ExecuteJavaScriptInternal(driver, script, args);
    }

    public static T ExecuteJavaScript<T>(this IWebDriver driver, string script, params object[] args)
    {
      object o = WebDriverExtensions.ExecuteJavaScriptInternal(driver, script, args);
      T obj = default (T);
      Type nullableType = typeof (T);
      if (o == null)
      {
        if (nullableType.IsValueType && Nullable.GetUnderlyingType(nullableType) == (Type) null)
          throw new WebDriverException("Script returned null, but desired type is a value type");
      }
      else
      {
        if (!nullableType.IsInstanceOfType(o))
          throw new WebDriverException("Script returned a value, but the result could not be cast to the desired type");
        obj = (T) o;
      }
      return obj;
    }

    private static object ExecuteJavaScriptInternal(IWebDriver driver, string script, object[] args)
    {
      IJavaScriptExecutor javaScriptExecutor = driver as IJavaScriptExecutor;
      if (javaScriptExecutor == null)
        throw new WebDriverException("Driver does not implement IJavaScriptExecutor");
      else
        return javaScriptExecutor.ExecuteScript(script, args);
    }
  }
}
