// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.IPageObjectMemberDecorator
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using System.Reflection;

namespace OpenQA.Selenium.Support.PageObjects
{
  public interface IPageObjectMemberDecorator
  {
    object Decorate(MemberInfo member, IElementLocator locator);
  }
}
