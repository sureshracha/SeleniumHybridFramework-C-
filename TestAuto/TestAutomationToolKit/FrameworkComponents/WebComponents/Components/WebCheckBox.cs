using OpenQA.Selenium;
using System;
using System.Collections;
using System.Drawing;
using TestAutomation.ObjectLocators;
using TestAutomation.Interfaces;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.WebDriver 
{
    public class WebCheckBox : IWebCheckBox
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
                   

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
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
        public WebCheckBox(Browser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        
 
        public  IObjectLocator GetLocator()
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
        /// get the boolean value (true/false) whether the textbox is enabled or displayed (Enabled => true, disabled => false)
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
        /// get the boolen value (true/false) whether the textbox is enabled or displayed (existed => true, not existed => false)
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
                Point Location = this.ele.Location;
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
        /// get the Width of the TExtbox 
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
        /// get the Hight of the Textbox
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
        /// Select the checkbox
        /// </summary> 
        /// <author> Suresh Racha</author>
        public void Select()
        {
            if (IsEnabled())
            {

                this.ele.Click();
                
            }
        }
        /// <summary>
        /// unselect the selected checkbox
        /// </summary>
        /// <author> Suresh Racha</author>
        public void UnSelect()
        {
            if (IsEnabled())
            {
                if(ele.Selected)
                {
                    this.ele.Click();
                }
            }
        }
        /// <summary>
        /// get the boolen value (true/false) whether the checkbox is checked or unchecked (checked => true, unchecked => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        public bool IsChecked()
        {
            
            if (IsExist())
                return this.ele.Selected.Equals(true);
            return false;
        } 

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetCheckBox());
        }

        public IWebElement GetCheckBox()
        {
            IsExist();
            return this.ele;
             
        }
    }
}
