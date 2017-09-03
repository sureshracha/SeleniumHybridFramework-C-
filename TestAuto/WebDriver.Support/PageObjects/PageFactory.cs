// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.PageFactory
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenQA.Selenium.Support.PageObjects
{
  public sealed class PageFactory
  {
    private PageFactory()
    {
    }

    public static T InitElements<T>(IWebDriver driver)
    {
      return PageFactory.InitElements<T>((IElementLocator) new DefaultElementLocator((ISearchContext) driver));
    }

    public static T InitElements<T>(IElementLocator locator)
    {
      T obj1 = default (T);
      ConstructorInfo constructor = typeof (T).GetConstructor(new Type[1]
      {
        typeof (IWebDriver)
      });
      if (constructor == (ConstructorInfo) null)
        throw new ArgumentException("No constructor for the specified class containing a single argument of type IWebDriver can be found");
      if (locator == null)
        throw new ArgumentNullException("locator", "locator cannot be null");
      if (!(locator.SearchContext is IWebDriver))
        throw new ArgumentException("The search context of the element locator must implement IWebDriver", "locator");
      T obj2 = (T) constructor.Invoke(new object[1]
      {
        (object) (locator.SearchContext as IWebDriver)
      });
      PageFactory.InitElements((object) obj2, locator);
      return obj2;
    }

    public static void InitElements(ISearchContext driver, object page)
    {
      PageFactory.InitElements(page, (IElementLocator) new DefaultElementLocator(driver));
    }

    public static void InitElements(ISearchContext driver, object page, IPageObjectMemberDecorator decorator)
    {
      PageFactory.InitElements(page, (IElementLocator) new DefaultElementLocator(driver), decorator);
    }

    public static void InitElements(object page, IElementLocator locator)
    {
      PageFactory.InitElements(page, locator, (IPageObjectMemberDecorator) new DefaultPageObjectMemberDecorator());
    }

    public static void InitElements(object page, IElementLocator locator, IPageObjectMemberDecorator decorator)
    {
      if (page == null)
        throw new ArgumentNullException("page", "page cannot be null");
      if (locator == null)
        throw new ArgumentNullException("locator", "locator cannot be null");
      if (decorator == null)
        throw new ArgumentNullException("locator", "decorator cannot be null");
      if (locator.SearchContext == null)
        throw new ArgumentException("The SearchContext of the locator object cannot be null", "locator");
      Type type = page.GetType();
      List<MemberInfo> list = new List<MemberInfo>();
      list.AddRange((IEnumerable<MemberInfo>) type.GetFields(BindingFlags.Instance | BindingFlags.Public));
      list.AddRange((IEnumerable<MemberInfo>) type.GetProperties(BindingFlags.Instance | BindingFlags.Public));
      for (; type != (Type) null; type = type.BaseType)
      {
        list.AddRange((IEnumerable<MemberInfo>) type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic));
        list.AddRange((IEnumerable<MemberInfo>) type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic));
      }
      foreach (MemberInfo member in list)
      {
        object obj = decorator.Decorate(member, locator);
        if (obj != null)
        {
          FieldInfo fieldInfo = member as FieldInfo;
          PropertyInfo propertyInfo = member as PropertyInfo;
          if (fieldInfo != (FieldInfo) null)
            fieldInfo.SetValue(page, obj);
          else if (propertyInfo != (PropertyInfo) null)
            propertyInfo.SetValue(page, obj, (object[]) null);
        }
      }
    }
  }
}
