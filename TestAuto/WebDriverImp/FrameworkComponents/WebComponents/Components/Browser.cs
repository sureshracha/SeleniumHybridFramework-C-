using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using TestAutomation.WebWinComponents.Interfaces;
using TestAutomation.WebDriver.WebWinComponents;
using OptumAutomationFramework.Framework;

namespace TestAutomation.WebDriver.WebComponents
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiBrowser 
    {


        public IWebDriver driver ;
        string browser;
        public string parenthandle = "";
        /// <summary>
        /// MultiBrowser for parallel execution
        /// </summary>
        
        public MultiBrowser()
        {
            this.driver = null;
        }
        /// <summary>
        ///  To get the current selinium dirver
        /// </summary>
        /// <returns>current IWebdriver </returns>
        
        public IWebDriver GetBrowser()        {
            
            return this.driver;
        }

        /// <summary>
        /// Navigate to given url
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
        /// Navigate to default (defined in app.config  , param is 'AppURL')
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
        /// Navigate to url with browser type (ie,firefox and chrome)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="browsertype"></param>
        
        public void Navigate(string url, string browsertype)
        {

             OpenURL(url, browsertype);

        }
        /// <summary>
        /// Close the current webdriver
        /// </summary>
        
        public void CloseBrowser()
        {
            this.driver.Close();
            
        }

        /// <summary>
        /// Switch to windiow using title
        /// </summary>
        /// <param name="Windowtitle"></param>
        
        public void SwitchWindow(string Windowtitle)
        {
            var WTitle = Windowtitle.ToLower();
            

            var hnd = this.driver.WindowHandles;
            this.parenthandle = this.driver.CurrentWindowHandle;

            foreach (string handle in hnd)
            {
                var ttle = this.driver.SwitchTo().Window(handle).Title;
                if (ttle.ToLower().Contains(WTitle))
                {
                    this.driver.SwitchTo().Window(handle);
                    
                    break;
                }
            }





        }
        /// <summary>
        /// switch back to parent windnow
        /// </summary>
        
        public void SwitchToParentWindow()
        {
            //this.driver.SwitchTo().Window("First");
            this.driver.SwitchTo().Window(parenthandle);
        }
        /// <summary>
        ///  To get the url of the browser
        /// </summary>
        /// <returns></returns>
        
        public string GetURL()
        {
            return this.driver.Url.ToString();
        }
        /// <summary>
        /// To get the Parent handle
        /// </summary>
        /// <returns></returns>
        
        public string Getparenthandle()
        {
            return this.parenthandle;
        }
        /// <summary>
        /// To get the tiltle of the browser
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return this.driver.Title;
        }
        /// <summary>
        /// verify the browser is existed or not
        /// </summary>
        /// <returns></returns>
        
        public bool IsExists()
        {
            
            return true;
        }

        /// <summary>
        /// Set the dirver
        /// </summary>
        
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
                    //options.EnableNativeEvents = true;
                   
                    this.driver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-extensions");
                    this.driver = new ChromeDriver(chromeOptions);
                    break;
                   
            }
            
        }
        /// <summary>
        /// To open the url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="browsertype"></param>
        
        private void OpenURL(string url, string browsertype = "IE")
        {

            this.browser = browsertype;
            this.SetDriver();
            this.driver.Navigate().GoToUrl(url);

            //Clicking 'Yes' button in ActiveX dialog
            IWebWinDialog WinDialog = new WebWinDialog("[CLASS:#32770]");
            WinDialog.BtnClickYes();
            this.driver.Manage().Window.Maximize();
            
        }
        /// <summary>
        /// REfresh the current dirver
        /// </summary>
        public void Refresh()
        {
            this.driver.Navigate().Refresh();
        }

        public void Back()
        {
            this.driver.Navigate().Back();
        }
        public void Forward()
        {
            this.driver.Navigate().Forward();
        }
        public void GoToUrl(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }
        public void DeleteCookies()
        {
            this.driver.Manage().Cookies.DeleteAllCookies();
        }
        public void DeleteCookie(Cookie cookie)
        {
            this.driver.Manage().Cookies.DeleteCookie(cookie);
        }
        public void DeleteCookieNamed(string cookiename)
        {
            this.driver.Manage().Cookies.DeleteCookieNamed(cookiename);
        }
        public void AddCookie(Cookie cookie)
        {
            this.driver.Manage().Cookies.AddCookie(cookie);
        }
        public Cookie GetCookieNamed(string cookie)
        {
            return this.driver.Manage().Cookies.GetCookieNamed(cookie);
        }
        public int AllCookiesCount()
        {
            return this.driver.Manage().Cookies.AllCookies.Count;
        }

        public void ZoomIn()
        {
            IWebElement html = this.driver.FindElement(By.TagName("html"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(driver);
            act.Click(html).SendKeys(Keys.Control + Keys.Add).Build().Perform();
        }
        public void ZoomOut()
        {
            IWebElement html = this.driver.FindElement(By.TagName("html"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(driver);
            act.Click(html).SendKeys(Keys.Control + Keys.Subtract).Build().Perform();
        }
        public void ZoomNormal()
        {
            IWebElement html = this.driver.FindElement(By.TagName("html"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(driver);
            act.Click(html).SendKeys(Keys.Control + '0').Build().Perform();
        }
    }

    public class Browser:TestBase
    {


        public static IWebDriver driver = null;
        string browser;
        public static string parenthandle = "";
        /// <summary>
        /// Returns the browser
        /// </summary>
        /// <returns></returns>
        
        public IWebDriver GetBrowser()
        {

            return driver;
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
                    InternetExplorerOptions options = new InternetExplorerOptions();
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
            IWebWinDialog WinDialog = new WebWinDialog("[CLASS:#32770]");
            WinDialog.BtnClickYes();

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
    }


}
