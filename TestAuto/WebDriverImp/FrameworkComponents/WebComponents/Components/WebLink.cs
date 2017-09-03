using System;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.WebComponents.Interfaces;

using TestAutomation.WebDriver.Implementation;
using TestAutomation.ObjectLocators;
using System.Collections;
using TestAutomation.WebComponents.ObjectProperties;

namespace TestAutomation.WebDriver.WebComponents
{
    /// <summary>
    /// WebComponent's IWebLink Interface which gives basic operations on Link
   
    /// </summary>
    public class WebLink :  IWebLink
    {
        IObjectLocator locator;
        WebdriverImp wr;
        IWebElement ele;
        IWebDriver driver = null;
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
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                else
                    this.wr = new WebdriverImp(this.driver);

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public WebLink(MultiBrowser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// Get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        public string GetCssValue(string prp)
        {
            if (IsExist())
            {
                return this.wr.GetCssValue(this.locator, prp);
            }
            return "";
        }

        /// <summary>
        /// Constructor takes findby and value as params
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public WebLink(FindBy type, string value)
        {

            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;
           
        }
        /// <summary>
        /// Constructor takes locator as param
        /// </summary>
        /// <param name="Locator"></param>
        public WebLink(IObjectLocator Locator)
        {
            this.locator = Locator;
           
            
            
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public WebLink()
        {
            this.locator = null;
        }

        /// <summary>
        /// click method which clicks on the Link
        /// </summary>
        public void Click()        {

            if (IsExist())
                this.ele.Click();
        }
        /// <summary>
        /// Getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        public IObjectLocator GetLocator()
        {
            return this.locator;
        }
        /// <summary>
        /// Set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetLocatorValues(FindBy type, string value)
        {

            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// Getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param>prp</param>
        /// <returns></returns>
        public string GetPropertyValue(GetBy prp)
        {
            if (IsExist())
            {
                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// Get the boolean value (true/false) whether the Link is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        public bool IsEnabled()
        {

            try
            {

                if (this.driver == null)
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                else
                    this.wr = new WebdriverImp(this.driver);

                this.ele = this.wr.GetElement(this.locator);

                return this.ele.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Get the boolen value (true/false) whether the Link is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            try
            {
                if (this.driver == null)
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                else
                    this.wr = new WebdriverImp(this.driver);

                this.ele = this.wr.GetElement(this.locator);
                
                if (this.ele.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception  )
            {
                return false;
            }
        }
        /// <summary>
        /// Get the X position value
        /// </summary>
        /// <returns></returns>
        public int GetX()
        {
           
            if (IsExist())
            {
                Point Location = this.ele.Location;
                return Location.X;
            }
            return 0;

        }
        /// <summary>
        /// Get the Y position value
        /// </summary>
        /// <returns></returns>
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
        /// Get the Width of the Link 
        /// </summary>
        /// <returns></returns>
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
        /// Get the Hight of the Link
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
           
            if (IsExist())
            {
                Size Si = this.ele.Size;
                return Si.Height;
            }
            return 0;
        }

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetLink());
        }

        public IWebElement GetLink()
        {
            IsExist();
            return this.ele;
            
        }

    }
}
