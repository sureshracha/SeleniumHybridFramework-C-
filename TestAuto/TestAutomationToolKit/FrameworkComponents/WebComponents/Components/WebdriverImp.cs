using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using TestAutomation.ObjectLocators;
 

namespace TestAutomation.WebDriver
{

    public class WebdriverImp 
    {
        #region Variable Declaration
            public static int MaxTimeOut = 3;
            public  IWebDriver driver = null;
            
            

        #endregion Variable Declaration

        #region Constructors
            public WebdriverImp(IWebDriver dr)
        {
            this.driver = dr;

        }

        #endregion Constructors

        #region Get Methods

        public By GetByObject(IObjectLocator locator)
            {



                try { return By.Id(locator.GetIdentifier("id")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.Name(locator.GetIdentifier("name")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.CssSelector(locator.GetIdentifier("cssselector")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.ClassName(locator.GetIdentifier("classname")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.LinkText(locator.GetIdentifier("linktext")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.PartialLinkText(locator.GetIdentifier("partiallinktext")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.TagName(locator.GetIdentifier("tagname")); }
                catch (Exception)
                {
                    // it is not id
                }
                try { return By.XPath(locator.GetIdentifier("xpath")); }
                catch (Exception)
                {
                    // it is not id
                }

                return null;

            }
            /// <summary>
            ///     This is the core method to identify the element on the web page/DOM and returns the IWebElement associated with that DOM element.
            ///     Using this element you can perform any action you want.
            /// </summary>
            /// 
            /// <param name="locator"></param>
            /// <returns> IWebElement </returns>
            public IWebElement GetElement(IObjectLocator locator)
            {
                IList<IWebElement> elements = new List<IWebElement>();
                try
                {
                    elements = GetElements(locator);
                    if (elements.Count == 0)
                    {
                        elements[0] = null;


                    }
                }
                catch (Exception)
                {
                    //Ele = null;
                    return elements[0];
                }

                return elements[0];
            }

            //public IList<IWebElement> GetElementList(IObjectLocator locator)
            //{
            //    IList<IWebElement> elements = GetElements(locator);
            //    return (IList<IWebElement>)elements;
            //}

            public IWebDriver GetDriver()
            {
                return this.driver;
            }
            /// <summary>
            ///     Using this method we can find out all the elements on the web page having the identifiers defined in the IObjectLocator 
            ///     Example : If you want to find out all the web elements on the web page having class='required' we can use this method 
            ///     which will return the list of all Web Elements with class='required'
            /// </summary>
            /// <param name="locator"></param>
            /// <returns>IList IWebElement</returns>
            public IList<IWebElement> GetElements(IObjectLocator locator)
            {

                IList<IWebElement> elements = new List<IWebElement>();
          

                try
                {
                    MaxTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["maxtimeout"]);
                    WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(MaxTimeOut));
                     wait.Until(ExpectedConditions.ElementExists(GetByObject(locator)));
                    elements = this.driver.FindElements(GetByObject(locator));
                    return elements;
                }
                catch (WebDriverException)
                {
                    return elements;

                }

            }

            /// <summary>
            ///     This method will return the inner text for the specified web element 
            /// </summary>
            /// <param name="locator"></param>
            /// <returns></returns>
            public String GetElementText(IObjectLocator locator)
            {
                IWebElement element = GetElement(locator);
                return element.Text;
            }

            /// <summary>
            ///     This method will return the current page title. 
            /// </summary>
            /// <returns></returns>
            public String GetCurrentPageTitle()
        {
            return this.driver.Title;
        }

            /// <summary>
            ///     This method will return the Current page URL.
            /// </summary>
            /// <returns></returns>
            public String GetCurrentPageURL()
            {
                return this.driver.Url;

            }

           

            public Actions GetAction()
        {
            return new Actions(this.driver);
        }

            /// <summary>
            ///     This method will return the CSS value value of the specified Web element.
            /// </summary>
            /// <param name="locator"></param>
            /// <returns></returns>
            public string GetCssValue(IObjectLocator locator, string prp)
            {
                IWebElement ele = GetElement(locator);
                if (ele.Displayed)
                {
                    return ele.GetCssValue(prp);
                }
                return string.Empty;
            }

            /// <summary>
            ///     This method will return the attribute value of the specified Web element.
            /// </summary>
            /// <param name="locator"></param>
            /// <param name="prp"></param>
            /// <returns></returns>
            public string GetElementPropertyValue(IObjectLocator locator, string prp)
            {
                IWebElement ele = GetElement(locator);
                if (ele.Displayed)
                {
                    switch (prp.ToString().ToLower())
                    {

                        case "text":
                            return ele.Text;
                        case "tagname":
                            return ele.TagName;

                        default:
                            return ele.GetAttribute(prp);
                    }
                }
                return "";

            }

            /// <summary>
            ///     This method will return the attribute value of the specified Web element.
            /// </summary>
            /// <param name="locator"></param>
            /// <returns></returns>
            public string GetElementPropertyValue(IObjectLocator locator, GetBy prp)
        {
            IWebElement ele = GetElement(locator);
            if (ele.Displayed)
            {
                switch (prp.ToString().ToLower())
                {

                    case "text":
                        return ele.Text;
                    case "tagname":
                        return ele.TagName;
                    case "id":
                        return ele.GetAttribute("id");
                    case "name":
                        return ele.GetAttribute("name");
                    case "value":
                        return ele.GetAttribute("value");
                    case "innertext":
                        return ele.GetAttribute("innertext");
                    case "outertext":
                        return ele.GetAttribute("outertext");
                    case "innerhtml":
                        return ele.GetAttribute("innerhtml");
                    case "outerhtml":
                        return ele.GetAttribute("outerhtml");
                    case "href":
                        return ele.GetAttribute("href");
                    case "src":
                        return ele.GetAttribute("src");
                    case "type":
                        return ele.GetAttribute("type");
                    case "title":
                        return ele.GetAttribute("title");
                    case "classname":
                        return ele.GetAttribute("class");

                    default:
                        return "";
                }
            }
            return "";//element.GetAttribute(PropertyName.Trim());

        }

        #endregion Get Methods      

        #region Mouse Operation Methods

            public void KeyUp(String key)
            {
                GetAction().KeyUp(key).Perform();
                //.keyUp(key).perform();

            }

            public void KeyUp(IObjectLocator locator, String key)
            {
                GetAction().KeyUp(GetElement(locator), key).Perform();
            }

            public void KeyDown(String key)
            {
                GetAction().SendKeys(key).Perform();
            }

            public void KeyDown(IObjectLocator locator, String key)
            {
                GetAction().SendKeys(GetElement(locator), key).Perform();
            }        

            public void MouseDown(IObjectLocator locator)
            {
                GetAction().ClickAndHold(GetElement(locator)).Perform();

            }

            public void MouseUp(IObjectLocator locator)
            {
                GetAction().Release(GetElement(locator)).Perform();
            }

            public void MoveByOffset(int xOffset, int yOffset)
            {
                GetAction().MoveByOffset(xOffset, yOffset).Perform();
            }

            public void MouseMove(IObjectLocator locator)
        {
            GetAction().MoveToElement(GetElement(locator)).Build().Perform();
        }

        #endregion Mouse Operation Methods

        #region Other Methods
            public IWebDriver DefaultContent()
            {
                return this.driver.SwitchTo().DefaultContent();
            }
            /// <summary>
            ///     set max timeout
            /// </summary>
            /// <param name="seconds"></param>

            public void SetMaxTimeOut(int seconds)
                {
                    MaxTimeOut = seconds;

                }

            public void MoveToElement(IObjectLocator locator)
            {

                IList<IWebElement> elements = GetElements(locator);
                Actions action = new Actions(this.driver);

                foreach (IWebElement ele in elements)
                {
                    if (ele.Enabled)
                    {
                        action.MoveToElement(ele);
                        action.Perform();
                    }
                    else
                        throw new Exception("Element is not enabled on the DOM with locator :");
                }

            }

            public bool IsElementPresent(IObjectLocator locator)
            {
                IWebElement elements = GetElement(locator);

                if (elements == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            /// <summary>
            ///     This method can execute the Java Script code 
            /// </summary>
            /// <param name="jsScript"></param>
            public void ExecuteJavaScript(String jsScript)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)this.driver;
            jsExecutor.ExecuteScript(jsScript);
        }
        #endregion Other Methods

        #region Wait Methods

        public void WaitTillElementAppears(FindBy findby, string value, int timeout)
            {
                Hashtable htbl = new Hashtable();
                htbl[findby.ToString()] = value;
                ObjectLocator loc = new ObjectLocator(htbl);
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(GetByObject(loc)));
            }

            public void WaitTillElementAppears(IObjectLocator locator, int timeout)
            {
             
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(GetByObject(locator)));
            }

            public void WaitTillElementDisappears(IObjectLocator locator, int timeout)
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetByObject(locator)));
            }


        #endregion Wait Methods     

        #region Click Methods
            public void RightClick(IObjectLocator Locator)
            {
                try
                {
                    Actions action = new Actions(this.driver).ContextClick(GetElement(Locator));
                    action.Build().Perform();

                    //System.out.println("Sucessfully Right clicked on the element");
                }
                catch (StaleElementReferenceException)
                {
                    //System.out.println("Element is not attached to the page document "
                    // + e.getStackTrace());
                }
                catch (NoSuchElementException)
                {
                    //System.out.println("Element " + element + " was not found in DOM "                        + e.getStackTrace());
                }
                catch (Exception)
                {
                    //System.out.println("Element " + element + " was not clickable "                        + e.getStackTrace());
                }
            }
            public void RightClick(IWebElement element)
            {
                try
                {
                    Actions action = new Actions(this.driver).ContextClick(element);
                    action.Build().Perform();

                    //System.out.println("Sucessfully Right clicked on the element");
                }
                catch (StaleElementReferenceException)
                {
                    //System.out.println("Element is not attached to the page document "
                    // + e.getStackTrace());
                }
                catch (NoSuchElementException)
                {
                    //System.out.println("Element " + element + " was not found in DOM "                        + e.getStackTrace());
                }
                catch (Exception)
                {
                    //System.out.println("Element " + element + " was not clickable "                        + e.getStackTrace());
                }
            }
            public void ContextClick(IObjectLocator locator)
        {
            GetAction().ContextClick(GetElement(locator)).Perform();
        }
            public void DoubleClick(IWebElement element)
            {
                GetAction().DoubleClick(element).Perform();
            }
            public void Doubleclick(IObjectLocator locator)
        {
            IList<IWebElement> elements = GetElements(locator);
            Actions action = new Actions(this.driver);

            foreach (IWebElement ele in elements)
            {
                if (ele.Enabled)
                {
                    action.DoubleClick(ele);
                    action.Perform();
                }
                else
                    throw new Exception("Element is not enabled on the DOM with locator :");
            }
        }
        #endregion Click Methods
    }

}
