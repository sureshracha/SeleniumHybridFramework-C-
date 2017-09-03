// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.UI.LoadableComponent`1
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;

namespace OpenQA.Selenium.Support.UI
{
  public abstract class LoadableComponent<T> : ILoadableComponent where T : LoadableComponent<T>
  {
    public virtual string UnableToLoadMessage { get; set; }

    protected bool IsLoaded
    {
      get
      {
        try
        {
          return this.EvaluateLoadedStatus();
        }
        catch (WebDriverException ex)
        {
          return false;
        }
      }
    }

    public virtual T Load()
    {
      if (this.IsLoaded)
        return (T) this;
      this.TryLoad();
      if (!this.IsLoaded)
        throw new LoadableComponentException(this.UnableToLoadMessage);
      else
        return (T) this;
    }

    ILoadableComponent ILoadableComponent.Load()
    {
      return (ILoadableComponent) this.Load();
    }

    protected virtual void HandleLoadError(WebDriverException ex)
    {
    }

    protected abstract void ExecuteLoad();

    protected abstract bool EvaluateLoadedStatus();

    protected T TryLoad()
    {
      try
      {
        this.ExecuteLoad();
      }
      catch (WebDriverException ex)
      {
        this.HandleLoadError(ex);
      }
      return (T) this;
    }
  }
}
