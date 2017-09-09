using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using TestAutomation.Framework;
using System.Collections.Generic;

namespace TestAutomation.WebDriver 
{

    public class Browser:TestBase
    {


        private IWebDriver driver = null;
        private WebdriverImp wbd;
        string browser;
        public static string parenthandle = "";        
        /// <summary>
        /// Returns the browser
        /// </summary>
        /// <returns></returns>

        public IWebDriver GetBrowser()
        {              
            return this.driver;
        }

        public Browser()
        {
            this.wbd = new WebdriverImp(this.driver);
        }


        /// <summary>
        /// Navigate to specific url provided
        /// </summary>
        /// <param name="url"></param>
        public void Navigate(string url)
        {
           


            string browsertype = Convert.ToString(ConfigurationManager.AppSettings["Browser"]);
            if (browsertype != "")
                this.OpenURL(url, browsertype);
            else
                this.OpenURL(url);



        }
        /// <summary>
        /// Navigate to the defalt url which is defined in the app.config (param is 'AppURL')
        /// </summary>
        
        public void Navigate()
        {


            var url = ConfigurationManager.AppSettings["AppURL"];
            string browsertype = Convert.ToString(ConfigurationManager.AppSettings["Browser"]);
            if (browsertype != "")
                this.OpenURL(url, browsertype);
            else
                this.OpenURL(url);

        }

        /// <summary>
        /// Nagiigate to the url in specified browser like ie,firefox or chrome
        /// </summary>
        /// <param name="url"></param>
        /// <param name="browsertype"></param>
        
        public void Navigate(string url, string browsertype)
        {

            OpenURL(url, browsertype);

        }
        /// <summary>
        /// to close the browser
        /// </summary>
        
        public void CloseBrowser()
        {
            driver.Close();

        }

        /// <summary>
        ///     switch the focus to the default browser window.
        /// </summary>
        public void SwitchToDefaultWindow()
        {
            this.driver.SwitchTo().DefaultContent();
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
        /// Switch to window
        /// </summary>
        /// <param name="Windowtitle"></param>

        public void SwitchWindow(string Windowtitle)
        {
            var WTitle = Windowtitle.ToLower();
            //this.wr.SwitchWindow();

            var hnd = driver.WindowHandles;
            parenthandle = driver.CurrentWindowHandle;

            foreach (string handle in hnd)
            {
                var ttle = driver.SwitchTo().Window(handle).Title;
                if (ttle.ToLower().Contains(WTitle))
                {
                    driver.SwitchTo().Window(handle);

                    break;
                }
            }





        }
        /// <summary>
        /// Switch back to parent window
        /// </summary>
        public void SwitchToParentWindow()
        {
            
            driver.SwitchTo().Window(parenthandle);
        }
        /// <summary>
        /// to get the url from the browser
        /// </summary>
        /// <returns></returns>
        
        public string GetURL()
        {
            return driver.Url.ToString();
        }
        /// <summary>
        /// Get the parent handle
        /// </summary>
        /// <returns></returns>
        
        public string Getparenthandle()
        {
            return parenthandle;
        }
        /// <summary>
        /// To get the title of the current window
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return driver.Title;
        }
        /// <summary>
        /// verify the existence of browser
        /// </summary>
        /// <returns></returns>
        
        public bool IsExists()
        {
            return (driver.WindowHandles.Count >= 1);                
        }
        /// <summary>
        /// Set the driver
        /// </summary>
        
        private void SetDriver()
        {


            switch (browser.ToString().ToLower())
            {
                case "firefox":
                case "ff":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    InternetExplorerOptions options = new InternetExplorerOptions ();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.IgnoreZoomLevel = true;
                     options.EnableNativeEvents = false;
                    driver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-extensions");
                    driver = new ChromeDriver(chromeOptions);
                    break;

            }

        }
        /// <summary>
        /// Open the url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="browsertype"></param>
        private void OpenURL(string url, string browsertype = "IE")
        {

            browser = browsertype;
            SetDriver();
            driver.Navigate().GoToUrl(url);
            //Clicking 'Yes' button in ActiveX dialog          

            driver.Manage().Window.Maximize();
            
        }
        /// <summary>
        /// REfresh the current dirver
        /// </summary>
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public void Back()
        {
            driver.Navigate().Back();
        }
        public void Forward()
        {
            driver.Navigate().Forward();
        }
        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void DeleteCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }
        public void DeleteCookie(Cookie cookie)
        {
            driver.Manage().Cookies.DeleteCookie(cookie);
        }
        public void DeleteCookieNamed(string cookiename)
        {
            driver.Manage().Cookies.DeleteCookieNamed(cookiename);
        }
        public void AddCookie(Cookie cookie)
        {
            driver.Manage().Cookies.AddCookie(cookie);
        }
        public Cookie GetCookieNamed(string cookie)
        {
            return driver.Manage().Cookies.GetCookieNamed(cookie);
        }
        public int AllCookiesCount()
        {
            return driver.Manage().Cookies.AllCookies.Count;
        }
        public void ZoomIn()
        {
            IWebElement html = driver.FindElement(By.TagName("html"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(driver);
            act.Click(html).SendKeys(Keys.Control + Keys.Add).Build().Perform();
        }
        public void ZoomOut()
        {
            IWebElement html = driver.FindElement(By.TagName("html"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(driver);
            act.Click(html).SendKeys(Keys.Control + Keys.Subtract).Build().Perform();
        }

        public void ZoomNormal()
        {
            IWebElement html = driver.FindElement(By.TagName("html"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(driver);
            act.Click(html).SendKeys(Keys.Control + '0').Build().Perform();
        }

        public void Quit()
        {
            this.driver.Quit();
        }

        #region Frame Methods
            public IWebDriver Frame(int index)
            {
                return this.driver.SwitchTo().Frame(index);
                 
            }

            public IWebDriver Frame(String nameOrId)
            {
                return this.driver.SwitchTo().Frame(nameOrId);

            }

            public void SwitchToFrame(String FrameName)
            {
                this.driver.SwitchTo().Frame(FrameName);
            }
        #endregion Frame Methods

        #region Alert Methods
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

            public void SendKeysAlert(String keysToSend)
            {
                Alert().SendKeys(keysToSend);
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
            public String GetTexttAlert()
        {
            return Alert().Text.ToString();
        }
        #endregion Alert Methods
    }

}
