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
using TestAutomation.WebComponents.ObjectProperties;

namespace TestAutomation.WebDriver.Implementation
{

    public class WebdriverImp 
    {
        public static int MaxTimeOut = 3;
        public  IWebDriver driver = null;
        private IWebDriver auxDriver = null;
        private IWebDriver tempDriver = null;
        private static WebDriverWait wait = null;
        
        // string url = null;

        private String browser = null;

        public  WebdriverImp(IWebDriver dr)
        {
            this.driver = dr;

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





        /// <summary>
        ///     This method will return the current page title. 
        /// </summary>
        /// <returns></returns>
        public String GetCurrentPageTitle()
        {
            return this.driver.Title;
        }

        // wrapping WebDriver.TargetLocator
        public IWebElement ActiveElement()
        {
            return (this.driver.SwitchTo().ActiveElement());
        }

        public IAlert Alert()
        {
            return this.driver.SwitchTo().Alert();
        }

        public void DismissAlert()
        {
            Alert().Dismiss();
        }

        public void AcceptAlert()
        {
            Alert().Accept();
        }

        public String GetTexttAlert()
        {
            return Alert().Text.ToString();
        }

        public void SendKeysAlert(String keysToSend)
        {
            Alert().SendKeys(keysToSend);
        }

        public IWebDriver DefaultContent()
        {
            return this.driver.SwitchTo().DefaultContent();
        }

        public IWebDriver Frame(int index)
        {
            return this.driver.SwitchTo().Frame(index);

        }

        public IWebDriver Frame(String nameOrId)
        {
            return this.driver.SwitchTo().Frame(nameOrId);

        }



        /// <summary>
        ///     This method will return the Current page URL.
        /// </summary>
        /// <returns></returns>
        public String GetCurrentPageURL()
        {
            return this.driver.Url;

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


        /// <summary>
        ///     Switch the foucs to the Frame identified by it's name
        /// </summary>
        /// <param name="FrameName"></param>

        public void SwitchToFrame(String FrameName)
        {
            this.driver.SwitchTo().Frame(FrameName);
        }



        /// <summary>
        ///     Switch the focus to the browser window with it's index.
        /// </summary>
        /// <param name="index"></param>
        public void SwitchToWindow(int index)
        {
            IList<string> windows = new List<string>(this.driver.WindowHandles);

            this.driver.SwitchTo().Window(windows[index]);
        }

        /// <summary>
        ///     switch the focus to the default browser window.
        /// </summary>
        public void SwitchToDefaultWindow()
        {
            this.driver.SwitchTo().DefaultContent();
        }


        /// <summary>
        ///     Modify the default implicit wait time.
        /// </summary>
        /// <param name="seconds"></param>

        public void SetCustomImplicitWait(int seconds)
        {
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        ///     set max timeout
        /// </summary>
        /// <param name="seconds"></param>

        public void SetMaxTimeOut(int seconds)
        {
            MaxTimeOut = seconds;

        }

        /// <summary>
        ///     Revert the implicit wait time to it's default value
        /// </summary>
        public void SetDefaultImplicitWait()
        {
            
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(MaxTimeOut));
        }

        /// <summary>
        ///     Close the current browser window.
        /// </summary>
        public void CloseBrowser()
        {
            this.driver.Close();
        }

        

        // wrapping WebDriver.Window
        public void Maximize()
        {
            this.driver.Manage().Window.Maximize();
        }

        public Actions GetAction()
        {
            return new Actions(this.driver);
        }

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

        public void DoubleClick(IWebElement element)
        {
            GetAction().DoubleClick(element).Perform();
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

        public void ContextClick(IObjectLocator locator)
        {
            GetAction().ContextClick(GetElement(locator)).Perform();
        }





        /// <summary>
        ///     Close all the browser windows.
        /// </summary>
        public void CloseAllBrowsers()
        {
            this.driver.Quit();
        }






        /// <summary>
        ///     Accepts parent element and returns list of strings consisting of text value of childrens
        /// </summary>
        /// <param name="locator"></param>
        public List<String> FindChildElementText(IObjectLocator locator)
        {
            IList<IWebElement> elements = GetElements(locator);
            List<String> elementText = new List<String>();
            foreach (IWebElement element in elements)
            {
                if (!element.Text.Equals(""))
                {
                    elementText.Add(element.Text);
                }
            }
            return elementText;
        }

        /// <summary>
        ///     Accepts parent element locator and returns Hashtablel having key as visible text of checkbox and its isEnabled property
        /// </summary>
        /// <param name="locator"></param>
        public Hashtable GetCheckboxEnabledProperty(IObjectLocator locator)
        {
            Hashtable checkboxTable = new Hashtable();

            IList<IWebElement> elements = GetElements(locator);
            foreach (IWebElement element in elements)
            {
                if (!element.Text.Equals(""))
                {
                    checkboxTable.Add(element.Text, element.Enabled);
                }
            }
            return checkboxTable;
        }



         

        public void Wait(int sec)
        {
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(sec));
        }
        


        public By GetByObject(IObjectLocator locator)
        {

            

            try { return By.Id(locator.GetIdentifier("id")); } catch (Exception)
            { 
                // it is not id
            }
            try { return By.Name(locator.GetIdentifier("name")); } catch (Exception)
            {
                // it is not id
            }
            try { return By.CssSelector(locator.GetIdentifier("cssselector")); } catch (Exception)
            {
                // it is not id
            }
            try { return By.ClassName(locator.GetIdentifier("classname")); } catch (Exception)
            {
                // it is not id
            }
            try { return By.LinkText(locator.GetIdentifier("linktext")); } catch (Exception)
            {
                // it is not id
            }
            try { return By.PartialLinkText(locator.GetIdentifier("partiallinktext")); } catch (Exception)
            {
                // it is not id
            }
            try { return By.TagName(locator.GetIdentifier("tagname")); } catch (Exception)
            {
                // it is not id
            }
            try { return By.XPath(locator.GetIdentifier("xpath")); } catch (Exception)
            {
                // it is not id
            }

            return null;

        }

        public void SwitchContext()
        {
            // This will be useful if you want to open two webapplications simultaneously in any case
            tempDriver = this.driver;
            this.driver = auxDriver;
            auxDriver = tempDriver;
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








        public void SelectAllCheckboxes(IObjectLocator locator)
        {
            Click(locator);
        }

        /// <summary>
        ///     Select a item from the drop down for the element specified in the locator object.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="testData"></param>

        public void SelectItemFromDropdown(IObjectLocator locator, String testData)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);


            element.DeselectAll();

            element.SelectByText(testData.Trim());

        }
 

        public void SelectItemFromListBox(IObjectLocator locator, String testData)
        {

            IWebElement selectElement = GetElement(locator);

            IJavaScriptExecutor js = (IJavaScriptExecutor)this.driver;
            js.ExecuteScript("arguments[0].click()", selectElement);

        }


        public void SelectRadioButton(IObjectLocator locator)
        {
            Click(locator);
        }

        public void SelectSingleCheckboxe(IObjectLocator locator)
        {
            Click(locator);
        }

        public void UnselectAllCheckboxes(IObjectLocator locator)
        {
            Click(locator);
        }

        public void UnselectSingleCheckboxe(IObjectLocator locator)
        {
            Click(locator);
        }


        public void SelectByValue(IObjectLocator locator, String valueToSelect)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.SelectByValue(valueToSelect);

            // element.DeselectAll();
        }
        public void SelectByText(IObjectLocator locator, String valueToSelect)
        {
            IWebElement selectEle = GetElement(locator);
            try
            {
                SelectElement element = new SelectElement(selectEle);
                valueToSelect = valueToSelect.Replace("  ", " ");
                element.SelectByText(valueToSelect);
            }
            catch (Exception e)
            {
                new Exception("element not found : " + locator.GetIdentifier("type") + "/" + locator.GetIdentifier("value") + " - " + e.Message);
            }
            // element.DeselectAll();
        }

        public void SelectByIndex(IObjectLocator locator, int index)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.SelectByIndex(index);
        }

        public void DeselectByValue(IObjectLocator locator, String valueToSelect)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.DeselectByValue(valueToSelect);
        }

        public void DeselectByIndex(IObjectLocator locator, int index)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.DeselectByIndex(index);
        }

        public void SelectByVisibleText(IObjectLocator locator, String txt)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.SelectByText(txt);
        }
        public void DeselectByVisibleText(IObjectLocator locator, String visibleText)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.DeselectByText(visibleText);
        }

        public void DeselectAll(IObjectLocator locator)
        {
            IWebElement selectEle = GetElement(locator);

            SelectElement element = new SelectElement(selectEle);
            element.DeselectAll();
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
        
        public void SetDriver(IWebDriver dr)
        {
            this.driver = dr;
        }
        private void SetDriver()
        {


            switch (browser.ToString().ToLower())
            {
                case "firefox":
                case "ff":
                    this.driver = new FirefoxDriver();
                    break;
                case "ie":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.IgnoreZoomLevel = true;
                    options.EnableNativeEvents = false;
                    this.driver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-extensions");
                    this.driver = new ChromeDriver(chromeOptions);
                    break;
                   
            }
            SetCustomImplicitWait(MaxTimeOut);
        }


        public void AcceptModalDialog()
        {

            IAlert modalwindowhandle = this.driver.SwitchTo().Alert();

            try
            {
                modalwindowhandle.Accept();
            }
            catch (Exception e)
            {

                throw new Exception(" Alert is not available", e);
            }

        }



        public void Click(IObjectLocator locator)
        {
            // No Need of Test Data object here...
            IWebElement ele = GetElement(locator);


            if (ele.Enabled)
                ele.Click();

            else
                throw new Exception("Element is not enabled on the DOM with locator :");


        }


        public bool IsSelected(IObjectLocator locator)
        {
            // No Need of Test Data object here...
            IList<IWebElement> elements = GetElements(locator);
            Boolean flag;
            flag = false;
            foreach (IWebElement ele in elements)
            {
                if (ele.Selected)
                { flag = true; }

            }
            return flag;
        }


        public String GetText(IObjectLocator locator)
        {
            // No Need of Test Data object here...
            IList<IWebElement> elements = GetElements(locator);

            String str = "";
            if (elements.Count > 0)
            {
                foreach (IWebElement ele in elements)
                {
                    str = ele.Text;
                }


            }
            return str;
        }



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
 
    }

}
