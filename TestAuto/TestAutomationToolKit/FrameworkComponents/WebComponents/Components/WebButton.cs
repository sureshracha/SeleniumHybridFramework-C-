using System;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.Interfaces;
using TestAutomation.ObjectLocators;
using System.Collections;
 
 

namespace TestAutomation.WebDriver 
{
    /// <summary>
    /// IWebButton intereface which is common to all tools implementation for WebButton
    /// </summary>
    
    public class WebButton :    IWebButton
    {
        IObjectLocator locator;
        WebdriverImp wr;
        IWebElement ele;
        IWebDriver driver=null;
       

        /// <summary>
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        
        public WebButton(Browser browser,FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
       
        
        /// <summary>
        /// set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
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
        /// click method which clicks on the button
        /// </summary>
        
        public void Click()        {

           
           if(IsExist())
              this.ele.Click();
           
        }

        /// <summary>
        /// getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        
        public IObjectLocator GetLocator()
        {
            return this.locator;
        }
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="prp"></param>
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
        /// get the boolean value (true/false) whether the button is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        
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
        
        public bool IsExist()
        {
            try
            {

                if(this.driver == null)
                    this.wr = new WebdriverImp(new Browser().GetBrowser());                 

                this.ele =  this.wr.GetElement(this.locator);
                
                if ( this.ele.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception )
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
        /// get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        
        public string GetCssValue(string prp)
        {
            if (IsExist())
            { 
               return  this.wr.GetCssValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// Get the Width of the element 
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
        /// Get the Hight of the element
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
                   

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor) this.driver;
            executor.ExecuteScript("arguments[0].click();", GetButtonElement());
        }

        public IWebElement GetButtonElement()
        {
            IsExist();
            return this.ele;
             
        }
    }
}
