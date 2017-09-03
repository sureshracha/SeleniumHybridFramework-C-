using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Drawing;
using TestAutomation.WebComponents.Interfaces;

using TestAutomation.WebDriver.Implementation;
using TestAutomation.ObjectLocators;
using System.Collections;
using TestAutomation.WebComponents.ObjectProperties;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.WebDriver.WebComponents
{
    public class WebListBox : IWebListBox
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


        public WebListBox(IObjectLocator Locator)
        {
             
            this.locator = Locator;
           
            
        }
        public WebListBox(FindBy type, string value)
        {

            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;
           
        }
        /// <summary>
        /// click method which clicks on the ListBox
        /// </summary>
        
        public void Click()        {

            if (IsExist())
                this.ele.Click();
        }

        public  IObjectLocator GetLocator()
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
        /// Getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        
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
        
        public WebListBox(MultiBrowser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// Get the boolean value (true/false) whether the ListBox is enabled or displayed (Enabled => true, disabled => false)
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
        /// get the boolen value (true/false) whether the button is enabled or displayed (existed => true, not existed => false)
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
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        ///  To Get all the Items of a listbox as a string, separated by ; (semicolon)
        /// </summary>
        /// <returns></returns>   
        
        public string GetAllItemsValues()
        {
            if (this.IsExist())
            {
                string vals = "";
                IList<IWebElement> ops = this.ele.FindElements(By.TagName("Option"));

                foreach (IWebElement element in ops)
                {
                    vals = vals + element.Text + ";";

                }
                
                return vals.TrimEnd(';'); 
            }
            return "";

        }
        /// <summary>
        /// get all list Items as array
        /// </summary>
        /// <returns>string array</returns>
        
        public string[] GetListItemsAsArray()
        {
            List<string> list = new List<string>();
            if (IsExist())
            {   

                IList<IWebElement> ops = this.ele.FindElements(By.TagName("Option"));

                foreach (IWebElement element in ops)
                {
                    list.Add(element.Text);

                }


                return list.ToArray(); 
            }
            return list.ToArray();

        }
        /// <summary>
        /// Select all items of listbox
        /// </summary>
        
        public void SelectAllElements()
        {
            if (IsExist())
            {
                
                IList<IWebElement> ops = this.ele.FindElements(By.TagName("Option"));

                for(int i=0; i<ops.Count; i++)
                {   SelectElement opss = new SelectElement(ops[i]);
                    opss.SelectByIndex(i);
                }
                
            }
        }

        /// <summary>
        /// Select an Item by value from the listbox
        /// </summary>
        /// <param name="val"></param>
        
        public void SelectItemByValue(String val)
        {
            if (IsExist())
                this.wr.SelectByValue(this.locator,val); 
        }
        /// <summary>
        /// Select an Item by text from the list box
        /// </summary>
        /// <param name="val"></param>
        
        public void SelectItemByText(String val)
        {
            if (IsExist())
                this.wr.SelectByText(this.locator, val);

        }


        /// <summary>
        /// select an item by index from the listbox
        /// </summary>
        /// <param name="ilndex"></param>

        public void SelectItemByIndex(int ilndex)
        {
            if (IsExist())
                this.wr.SelectByIndex(this.locator, ilndex);
        }

        /// <summary>
        /// deSelect an Item by value from the listbox
        /// </summary>
        /// <param name="val"></param>
        
        public void DeSelectItemByValue(String val)
        {
            if (IsExist())
                this.wr.DeselectByValue(this.locator, val);

        }
        /// <summary>
        /// deSelect an Item by text from the list box
        /// </summary>
        /// <param name="ilndex"></param>
        
        public void DeSelectItemByIndex(int ilndex)
        {
            if (IsExist())
                this.wr.DeselectByIndex(this.locator, ilndex);
        }
        /// <summary>
        /// deselect the items  from the listbox
        /// </summary>
        
        public void DeSelectAllItems()
        {
            if (IsExist())
                this.wr.DeselectAll(this.locator);
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
        /// Get the Width of the ListBox 
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
        /// Get the Hight of the ListBox
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
        /// List Items Count
        /// </summary>
        /// <returns>cout</returns>
        
        public int ListItemsCount()
        {
            if (IsExist())
            {
                 
                IList<IWebElement> ops = this.ele.FindElements(By.TagName("Option"));

                return ops.Count; 

            }
            return 0;
        }


        //public bool DoValExistInListBox( string val)
        //{
        //    bool doExists = false;
        //    if (IsExist())
        //    {
        //        for (int i = 0; i < this.ListItemsCount(); i++)
        //        {
        //            if(this.GetAllItemsValues)
        //        }
        //    }
        //    return doExists;
        //}


        /// <summary>
        /// Get the selected element for combobox
        /// </summary>
        /// <returns></returns>

        public string GetSelectedElement()
        {
            if (IsExist())
            {

                SelectElement selectedValue = new SelectElement(this.ele);
                return selectedValue.SelectedOption.Text;
            }
            return string.Empty;
        }
       

        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetListBox());
        }

        public IWebElement GetListBox()
        {
            IsExist();
            return this.ele;
             
        }
    }
}
