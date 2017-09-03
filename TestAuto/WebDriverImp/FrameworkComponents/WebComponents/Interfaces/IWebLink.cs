
using OpenQA.Selenium;
using TestAutomation.ObjectLocators;
using TestAutomation.WebComponents.ObjectProperties;


namespace TestAutomation.WebComponents.Interfaces
{
    /// <summary>
    /// WebComponent's IWebLink Interface which gives basic operations on Link
   
    /// </summary>
    public interface IWebLink
    {

        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// click method which clicks on the Link
        /// </summary>
        void Click();
        /// <summary>
        /// click method which clicks on the Link using JavaScriptExecutor
        /// </summary>
        void JsClick();
        /// <summary>
        /// Get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        string GetCssValue(string prp);
        /// <summary>
        /// Getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        IObjectLocator GetLocator();
        /// <summary>
        /// Getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        string GetPropertyValue(GetBy objprp);
        /// <summary>
        /// Set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        void SetLocatorValues(FindBy type, string value);
        /// <summary>
        /// Get the boolean value (true/false) whether the Link is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        bool IsEnabled();
        /// <summary>
        /// Get the boolen value (true/false) whether the Link is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        bool IsExist();
        /// <summary>
        /// Get the X position value
        /// </summary>
        /// <returns></returns>
        int GetX();
        /// <summary>
        /// Get the Y position value
        /// </summary>
        /// <returns></returns>
        int GetY();
        /// <summary>
        /// Get the Width of the Link 
        /// </summary>
        /// <returns></returns>
        int GetWidth();
        /// <summary>
        /// Get the Hight of the Link
        /// </summary>
        /// <returns></returns>
        int GetHeight();

        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetLink();


    }
}
