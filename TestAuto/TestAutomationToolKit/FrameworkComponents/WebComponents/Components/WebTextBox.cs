using System;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.Interfaces; 
using TestAutomation.ObjectLocators;
using System.Collections;

 

namespace TestAutomation.WebDriver 
{
    public class WebTextBox :  IWebTextBox
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
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public WebTextBox(Browser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// Get Css value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>Css value as string</returns>
        
        public string GetCssValue(string prp)
        {
            if (IsExist())
            {
                return this.wr.GetCssValue(this.locator, prp);
            }
            return "";
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
        /// <param name="objprp"></param>
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
        /// click method which clicks on the element
        /// </summary>
        
        public void Click()        {


            if (IsExist())
            {
                this.ele.Click();
            }
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
        /// Get the boolean value (true/false) whether the textbox is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>


        public bool IsEnabled()
        {

            try
            {

                if (this.driver == null)
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                else
                   

                this.ele = this.wr.GetElement(this.locator);

                return this.ele.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Get the boolen value (true/false) whether the textbox is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>

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
        /// Set a value to the textbox
        /// </summary>
        /// <param name="val"></param>
        
        public void SetValue(String val)
        {

            
            if (IsExist())
            {
                if (this.ele.GetAttribute("readonly") == null)

                {
                    this.ele.Clear();
                                       
                    if (GetPropertyValue(GetBy.value) == "0.00")
                    {
                        var act = this.wr.GetAction();
                        this.ele.Click();
                        act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                        act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                        act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                        act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                    }
                    this.ele.SendKeys(val);
                    
                }
               
            }
            
        }
        /// <summary>
        /// Type a value in the textbox ( adding to the extisting value)
        /// </summary>
        /// <param name="val"></param>
        
        public void TypeValue(String val)
        {

           
            if (IsExist())
            {
                if (this.ele.GetAttribute("readonly") == null)
                {
                    
                    this.ele.SendKeys(val);
                }
                
            }
            
        }
        /// <summary>
        /// clearing the existing content of the textbox
        /// </summary>
        
        public void Clear()
        {
            
            if (IsExist())
                this.ele.Clear();
        }


        public IWebElement GetEditField()
        {
            return this.ele;
        }
        /// <summary>
        /// SEt the encripted password to the the textbox
        /// </summary>
        /// <param name="val"></param>
        public void SetPassword(string val)
        {
            var password = TestAutomation.DataManipulations.DecryptCipherToPlanText.Decrypter(val);

            TypeValue(password);

        }
        /// <summary>
        /// Set a value to the textbox which is of amount type
        /// </summary>
        /// <param name="val"></param>
        
        public void SetAmountValue(string val)
        {
            if (IsExist())
            {
                this.ele.Clear();
                
                var act = this.wr.GetAction();
                if (GetPropertyValue(GetBy.value) == "0.00")
                {
                    this.ele.Click();
                    act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                    act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                    act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                    act.Click(this.ele).SendKeys(Keys.Backspace).Build().Perform();
                }
                this.ele.SendKeys(val);
            }
        }

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetTextBox());
        }

        public IWebElement GetTextBox()
        {
            IsExist();
                return this.ele;            
        }
    }


}
