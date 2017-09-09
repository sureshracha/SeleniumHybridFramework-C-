using System;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.Interfaces;

 
using TestAutomation.ObjectLocators;
using System.Collections;

namespace TestAutomation.WebDriver 
{
    public class WebImage :  IWebImage
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
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                 

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// Get CSS value from the button
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
        /// click method which clicks on the ImageObj
        /// </summary>
        /// <author> Suresh Racha</author>
        public void Click()        {

           
           if(IsExist())
              this.ele.Click();
        }
        /// <summary>
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public WebImage(Browser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// Getting the Locator as return value
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
        /// Getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public string GetPropertyValue(GetBy prp)
        {
            if (IsExist())
            {
                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// Get the boolean value (true/false) whether the ImageObj is enabled or displayed (Enabled => true, disabled => false)
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
        /// Get the boolen value (true/false) whether the ImageObj is enabled or displayed (existed => true, not existed => false)
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
        /// Get the X position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
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
        /// Get the Width of the ImageObj 
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
        /// Get the Hight of the ImageObj
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
        /// Dobuble click on the image
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public void Doubleclick()
        {
            try
            {
                if (IsExist())
                {
                    
                    this.wr.Doubleclick(this.locator);
                }
            }
            catch(Exception e)
            {
                new Exception("unable to double click " + e.Message);
            }
        }

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetImageObject());
        }

        public IWebElement GetImageObject()
        {
            IsExist();
            return this.ele;
             
        }


    }
}
