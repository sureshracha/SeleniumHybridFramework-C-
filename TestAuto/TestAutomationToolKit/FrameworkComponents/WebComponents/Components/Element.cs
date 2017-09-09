using System;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.Interfaces; 
using TestAutomation.ObjectLocators;
using System.Collections;
using OpenQA.Selenium.Interactions;

namespace TestAutomation.WebDriver
{
    /// <summary>
    /// WebComponent's IElement Interface which gives basic operations on  Element

    /// </summary>
    public class Element :  IElement
    {
        IObjectLocator locator;
        WebdriverImp wr;
        IWebElement ele;
        IWebDriver driver = null;

        /// <summary>
        /// get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        /// <author> Suresh Racha</author>
        public string GetCssValue(string prp)
        {
            if (IsExist())
            {
                return this.wr.GetCssValue(this.locator, prp);
            }
            return "";
        }

        
        /// <summary>
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <author> Suresh Racha</author>
        public Element(Browser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        
        /// <summary>
        /// click method which clicks on the element
        /// </summary>
        public void Click()        {

         
           if(IsExist())
              this.ele.Click();
        }

        /// <summary>
        /// getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public IObjectLocator GetLocator()
        {
            return this.locator;
        }
        /// <summary>
        /// set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <author> Suresh Racha</author>
        public void SetLocatorValues(FindBy type, string value)
        {

            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="prp"></param>
        /// <returns></returns>
        
        public string GetPropertyValue(string prp)
        {
            if (IsExist())
            {
                if (this.driver == null)
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                 
                   

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public string GetPropertyValue(GetBy prp)
        {
            if (IsExist())
            {
                if (this.driver == null)
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                else
                   

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// get the boolean value (true/false) whether the element is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public bool IsEnabled()
        {

            try
            {

                if (this.driver == null)
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                
                   

                this.ele = this.wr.GetElement(this.locator);

                return this.ele.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// get the boolen value (true/false) whether the button is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public bool IsExist()
        {
            try
            {

                if (this.driver == null)
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                
                   

                this.ele = this.wr.GetElement(this.locator);

                if (this.ele.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// get the X position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public int GetX()
        {
            
            if (IsExist())
            {
                Point Location = ele.Location;
                return Location.X;
            }
            return 0;

        }

        /// <summary>
        /// get the Y position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public int GetY()
        {
             
            if (IsExist())
            {
                Point Location = this.ele.Location;
                return Location.X;
            }
            return 0;
        }
        /// <summary>
        /// get the Width of the element 
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public int GetWidth()
        {
            
            if (IsExist())
            {
                Size Si = this.ele.Size;
                return Si.Width;
            }
            return 0;
        }
        /// <summary>
        /// get the Hight of the element
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public int GetHeight()
        {
            
            if (IsExist())
            {
                Size Si = this.ele.Size;
                return Si.Height;
            }
            return 0;
        }


        /// <summary>
        /// double click on the element
        /// </summary>
        /// <author> Suresh Racha</author>
        public void Doubleclick()
        {
            try
            {
                

                Actions action = new Actions(this.driver);
                if (this.IsEnabled())
                {
                    action.DoubleClick(this.ele);
                    action.Perform();
                }
                
            }
            catch(Exception e)
            {
                new Exception("unable to double click " + e.Message);
            }
        }

        //public IList<IElement> GetElements()
        //{
        //    IList<IElement> lst = null;
        //    if (this.driver == null)
        //        this.wr = new WebdriverImp(new Browser().GetBrowser());
        //    else
        //       
        //   IList<IWebElement> a = wr.GetElements(this.locator);

        //    int count = a.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        Element e = new Element();
        //        e.ele = a[i];
        //        lst.Add(e);
        //    }
        //    return lst;

        //}

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetElement());
        }

        public IWebElement GetElement()
        {
            IsExist();
            return this.ele;
            
        }

        public bool IsChecked()
        {

            try
            {

                if (this.driver == null)
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                else
                   

                this.ele = this.wr.GetElement(this.locator);

                return this.ele.GetAttribute("checked") == "true";
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
