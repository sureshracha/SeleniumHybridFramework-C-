// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.SlowLoadableComponent`1
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Threading;

namespace OpenQA.Selenium.Support.UI
{
  public abstract class SlowLoadableComponent<T> : LoadableComponent<T> where T : SlowLoadableComponent<T>
  {
    private TimeSpan sleepInterval = TimeSpan.FromMilliseconds(200.0);
    private readonly IClock clock;
    private readonly TimeSpan timeout;

    public TimeSpan SleepInterval
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

    protected SlowLoadableComponent(TimeSpan timeout)
      : this(timeout, (IClock) new SystemClock())
    {
    }

    protected SlowLoadableComponent(TimeSpan timeout, IClock clock)
    {
      this.clock = clock;
      this.timeout = timeout;
    }

    public override T Load()
    {
      if (this.IsLoaded)
        return (T) this;
      this.TryLoad();
      DateTime otherDateTime = this.clock.LaterBy(this.timeout);
      while (this.clock.IsNowBefore(otherDateTime))
      {
        if (this.IsLoaded)
          return (T) this;
        this.HandleErrors();
        this.Wait();
      }
      if (this.IsLoaded)
        return (T) this;
      throw new WebDriverTimeoutException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Timed out after {0} seconds.", new object[1]
      {
        (object) this.timeout.TotalSeconds
      }));
    }

    protected virtual void HandleErrors()
    {
    }

    private void Wait()
    {
      Thread.Sleep(this.sleepInterval);
    }
  }
}
