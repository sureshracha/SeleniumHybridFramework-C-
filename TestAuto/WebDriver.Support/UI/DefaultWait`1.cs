// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.DefaultWait`1
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace OpenQA.Selenium.Support.UI
{
  public class DefaultWait<T> : IWait<T>
  {
    private TimeSpan timeout = DefaultWait<T>.DefaultSleepTimeout;
    private TimeSpan sleepInterval = DefaultWait<T>.DefaultSleepTimeout;
    private string message = string.Empty;
    private List<Type> ignoredExceptions = new List<Type>();
    private T input;
    private IClock clock;

    public TimeSpan Timeout
    {
      get
      {
        return this.timeout;
      }
      set
      {
        this.timeout = value;
      }
    }

    public TimeSpan PollingInterval
    {
      get
      {
        return this.sleepInterval;
      }
      set
      {
        this.sleepInterval = value;
      }
    }

    public string Message
    {
      get
      {
        return this.message;
      }
      set
      {
        this.message = value;
      }
    }

    private static TimeSpan DefaultSleepTimeout
    {
      get
      {
        return TimeSpan.FromMilliseconds(500.0);
      }
    }

    public DefaultWait(T input)
      : this(input, (IClock) new SystemClock())
    {
    }

    public DefaultWait(T input, IClock clock)
    {
      if ((object) input == null)
        throw new ArgumentNullException("input", "input cannot be null");
      if (clock == null)
        throw new ArgumentNullException("clock", "clock cannot be null");
      this.input = input;
      this.clock = clock;
    }

    public void IgnoreExceptionTypes(params Type[] exceptionTypes)
    {
      if (exceptionTypes == null)
        throw new ArgumentNullException("exceptionTypes", "exceptionTypes cannot be null");
      foreach (Type c in exceptionTypes)
      {
        if (!typeof (Exception).IsAssignableFrom(c))
          throw new ArgumentException("All types to be ignored must derive from System.Exception", "exceptionTypes");
      }
      this.ignoredExceptions.AddRange((IEnumerable<Type>) exceptionTypes);
    }

    public TResult Until<TResult>(Func<T, TResult> condition)
    {
      if (condition == null)
        throw new ArgumentNullException("condition", "condition cannot be null");
      Type c = typeof (TResult);
      if (c.IsValueType && c != typeof (bool) || !typeof (object).IsAssignableFrom(c))
        throw new ArgumentException("Can only wait on an object or boolean response, tried to use type: " + c.ToString(), "condition");
      Exception lastException = (Exception) null;
      DateTime otherDateTime = this.clock.LaterBy(this.timeout);
      while (true)
      {
        try
        {
          TResult result = condition(this.input);
          if (c == typeof (bool))
          {
            bool? nullable = (object) result as bool?;
            if (nullable.HasValue)
            {
              if (nullable.Value)
                return result;
            }
          }
          else if ((object) result != null)
            return result;
        }
        catch (Exception ex)
        {
          if (!this.IsIgnoredException(ex))
            throw;
          else
            lastException = ex;
        }
        if (!this.clock.IsNowBefore(otherDateTime))
        {
          string exceptionMessage = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Timed out after {0} seconds", new object[1]
          {
            (object) this.timeout.TotalSeconds
          });
          if (!string.IsNullOrEmpty(this.message))
            exceptionMessage = exceptionMessage + ": " + this.message;
          this.ThrowTimeoutException(exceptionMessage, lastException);
        }
        Thread.Sleep(this.sleepInterval);
      }
    }

    protected virtual void ThrowTimeoutException(string exceptionMessage, Exception lastException)
    {
      throw new WebDriverTimeoutException(exceptionMessage, lastException);
    }

    private bool IsIgnoredException(Exception exception)
    {
      return Enumerable.Any<Type>((IEnumerable<Type>) this.ignoredExceptions, (Func<Type, bool>) (type => type.IsAssignableFrom(exception.GetType())));
    }
  }
}
