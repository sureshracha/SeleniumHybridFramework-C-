
using OpenQA.Selenium;
using TestAutomation.ObjectLocators;



namespace TestAutomation.Interfaces
{
    /// <summary>
    /// WebComponent's IWebImage Interface which gives basic operations on Image
   
    /// </summary>
    public interface IWebImage
    {
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// click method which clicks   using JavaScriptExecutor
        /// </summary>
        void JsClick();
        /// <summary>
        /// click method which clicks on the ImageObj
        /// </summary>
        /// <author> Suresh Racha</author>
        void Click();
        /// <summary>
        /// Get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        /// <author> Suresh Racha</author>
        string GetCssValue(string prp);
        /// <summary>
        /// Getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        IObjectLocator GetLocator();
        /// <summary>
        /// Getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(GetBy objprp);
        /// <summary>
        /// set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <author> Suresh Racha</author>
        void SetLocatorValues(FindBy type, string value);
        /// <summary>
        /// Get the boolean value (true/false) whether the ImageObj is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        bool IsEnabled();
        /// <summary>
        /// Get the boolen value (true/false) whether the ImageObj is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        bool IsExist();
        /// <summary>
        /// Get the X position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetX();
        /// <summary>
        /// Get the Y position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetY();
        /// <summary>
        /// Get the Width of the ImageObj 
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetWidth();
        /// <summary>
        /// Get the Hight of the ImageObj
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetHeight();

        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetImageObject();
    }
}
