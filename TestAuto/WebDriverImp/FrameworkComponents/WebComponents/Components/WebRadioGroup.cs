using System;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.WebComponents.Interfaces;

using TestAutomation.WebDriver.Implementation;
using System.Collections.Generic;
using TestAutomation.ObjectLocators;
using System.Collections;
using TestAutomation.WebComponents.ObjectProperties;

namespace TestAutomation.WebDriver.WebComponents
{
    public class WebRadioGroup :   IWebRadioGroup
    {
        IObjectLocator locator;
        WebdriverImp wr;
        IList <IWebElement> ele;
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
        /// get CSS value from the button
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
        public WebRadioGroup(FindBy type, string value)
        {

            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;
           
        }
        /// <summary>
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public WebRadioGroup(MultiBrowser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        public WebRadioGroup(IObjectLocator Locator)
        {
           
            this.locator = Locator;
           
           
          
        }
        public WebRadioGroup()
        {
           
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
        /// getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        
        public IObjectLocator GetLocator()
        {
            return this.locator;
        }
      
        private string GetPropertyVal (string prp,int i)
        {
            if (IsExist())
            {

                switch (prp.Trim().ToLower())
                {

                    case "text":
                        return this.ele[i].Text;
                    case "tagname":
                        return this.ele[i].TagName;
                    case "id":
                        return this.ele[i].GetAttribute("id");
                    case "name":
                        return this.ele[i].GetAttribute("name");
                    case "value":
                        return this.ele[i].GetAttribute("value");
                    case "innertext":
                        return this.ele[i].GetAttribute("innertext");
                    case "outertext":
                        return this.ele[i].GetAttribute("outertext");
                    case "innerhtml":
                        return this.ele[i].GetAttribute("innerhtml");
                    case "outerhtml":
                        return this.ele[i].GetAttribute("outerhtml");
                    case "href":
                        return this.ele[i].GetAttribute("href");
                    case "src":
                        return this.ele[i].GetAttribute("src");
                    case "type":
                        return this.ele[i].GetAttribute("type");
                    case "title":
                        return this.ele[i].GetAttribute("title");
                    case "classname":
                        return this.ele[i].GetAttribute("class");

                    default:
                        return "";
                }
                
            }
            return "";
        }
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <param name="Itemname"></param>
        /// <returns></returns>
        
        public string GetPropertyValue(string itemname, GetBy prp)
        {
            if (IsExist())
            {

                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        return GetPropertyVal(  prp.ToString().Trim().ToLower(),  i); 
                    }
            }
            return "";
        }


        /// <summary>
        /// To get no.of radio buttons within the group
        /// </summary>
        /// <returns>integer</returns>
        public int GetRadioButtonsCount()
        {
            if (IsExist())
            {

                return this.ele.Count; 
            }
            return 0;
        }
        /// <summary>
        /// get the boolean value (true/false) whether the Radiobuttongroup is enabled or displayed (Enabled => true, disabled => false)
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

                this.ele = this.wr.GetElements(this.locator);

                return this.ele[0].Enabled;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// get the boolen value (true/false) whether the Radiobuttongroup is enabled or displayed (existed => true, not existed => false)
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

                this.ele = this.wr.GetElements(this.locator);

                if (this.ele[0].Displayed)
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
        /// Select the Radio button by giving the value
        /// </summary> 
        
        public void Select(string itemname)
        {

            if (IsExist())
            {
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        this.ele[i].Click();
                        break;
                    }
            }
        }
        /// <summary>
        /// get the boolen value (true/false) whether the Radiobuttongroup specified item is selected or not (selected => true, not selected => false)
        /// </summary> 
        
        public bool IsSelect(string itemname)
        {
            if (IsExist())
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        return this.ele[i].Selected;
                    }
            return false;
        }
        /// <summary>
        /// get the X position value
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        public int GetX(string itemname)
        {

           
            if (IsExist())
            {
                Point Location = this.ele[0].Location;
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        Location = this.ele[i].Location;
                    }
                    
               
                return Location.X;
            }
            return 0;

        }
        /// <summary>
        /// get the Y position value
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        public int GetY(string itemname)
        {
           
            if (IsExist())
            {
                Point Location = this.ele[0].Location;
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        Location = this.ele[i].Location;
                    }


                return Location.Y;
            }
            return 0;
        }
        /// <summary>
        /// get the Width of the Radiobuttongroup 
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        public int GetWidth(string itemname)
        {
            
            if (IsExist())
            {
                Size Si = this.ele[0].Size;
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        Si = this.ele[i].Size;
                    }               

                 
                return Si.Width;
            }
            return 0;
        }
        /// <summary>
        /// get the Hight of the Radiobuttongroup
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        public int GetHeight(string itemname)
        {
             
            if (IsExist())
            {
                Size Si = this.ele[0].Size;
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        Si = this.ele[i].Size;
                    }


                return Si.Height;
            }
            return 0;
        }
        /// <summary>
        /// get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        
        public String GetCssStyle(string itemname,String Style)
        {

            if (IsExist())
            {
                
                for (int i = 0; i < this.ele.Count; i++)
                    if (this.ele[i].GetAttribute("value").Equals(itemname))
                    {
                        return this.ele[i].GetCssValue(Style);
                    }
            }
           
            return "";
        }

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetRadioGroup());
        }

        public IWebElement GetRadioGroup()
        {
            IsExist();
            return this.ele[0];
             
        }
 
    }
     
}
