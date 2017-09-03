// Decompiled with JetBrains decompiler
// Type: OpenQA.Selenium.Support.PageObjects.FindsByAttribute
// Assembly: WebDriver.Support, Version=2.53.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 704EB963-86F6-4755-9D2E-D17CB3E0515A
// Assembly location: C:\Users\jcanno10\Source\Repos\efr-automation\ExternalDLLS\WebDriver.Support.dll

using OpenQA.Selenium;
using System;
using System.ComponentModel;

namespace OpenQA.Selenium.Support.PageObjects
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
  public sealed class FindsByAttribute : Attribute, IComparable
  {
    private By finder;

    [DefaultValue(How.Id)]
    public How How { get; set; }

    public string Using { get; set; }

    [DefaultValue(0)]
    public int Priority { get; set; }

    public Type CustomFinderType { get; set; }

    internal By Finder
    {
      get
      {
        if (this.finder == (By) null)
          this.finder = ByFactory.From(this);
        return this.finder;
      }
      set
      {
        this.finder = value;
      }
    }

    public static bool operator ==(FindsByAttribute one, FindsByAttribute two)
    {
      if (object.ReferenceEquals((object) one, (object) two))
        return true;
      if (one == null || two == null)
        return false;
      else
        return one.Equals((object) two);
    }

    public static bool operator !=(FindsByAttribute one, FindsByAttribute two)
    {
      return !(one == two);
    }

    public static bool operator >(FindsByAttribute one, FindsByAttribute two)
    {
      if (one == (FindsByAttribute) null)
        throw new ArgumentNullException("one", "Object to compare cannot be null");
      else
        return one.CompareTo((object) two) > 0;
    }

    public static bool operator <(FindsByAttribute one, FindsByAttribute two)
    {
      if (one == (FindsByAttribute) null)
        throw new ArgumentNullException("one", "Object to compare cannot be null");
      else
        return one.CompareTo((object) two) < 0;
    }

    public int CompareTo(object obj)
    {
      if (obj == null)
        throw new ArgumentNullException("obj", "Object to compare cannot be null");
      FindsByAttribute findsByAttribute = obj as FindsByAttribute;
      if (findsByAttribute == (FindsByAttribute) null)
        throw new ArgumentException("Object to compare must be a FindsByAttribute", "obj");
      if (this.Priority != findsByAttribute.Priority)
        return this.Priority - findsByAttribute.Priority;
      else
        return 0;
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      FindsByAttribute findsByAttribute = obj as FindsByAttribute;
      return !(findsByAttribute == (FindsByAttribute) null) && findsByAttribute.Priority == this.Priority && !(findsByAttribute.Finder != this.Finder);
    }

    public override int GetHashCode()
    {
      return this.Finder.GetHashCode();
    }
  }
}
