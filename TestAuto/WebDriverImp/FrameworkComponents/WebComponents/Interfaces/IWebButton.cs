

using OpenQA.Selenium;
using TestAutomation.ObjectLocators;
using TestAutomation.WebComponents.ObjectProperties;



namespace TestAutomation.WebComponents.Interfaces
{
    /// <summary>
    /// IWebButton intereface which is common to all tools implementation for WebButton
    /// </summary>
    
    public interface IWebButton 
    {
        /// <summary>
        /// click method which clicks on the button
        /// </summary>
        void Click();
        /// <summary>
        /// click method which clicks on the button using JavaScriptExecutor
        /// </summary>
        void JsClick();

        /// <summary>
        /// getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        IObjectLocator GetLocator();
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        string GetPropertyValue(GetBy objprp);
        /// <summary>
        /// set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        void SetLocatorValues(FindBy type, string value);
        /// <summary>
        /// get the boolean value (true/false) whether the button is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        bool IsEnabled();
        /// <summary>
        /// get the boolen value (true/false) whether the button is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        bool IsExist();
        /// <summary>
        /// get the X position value
        /// </summary>
        /// <returns></returns>
        int GetX();
        /// <summary>
        /// get the Y position value
        /// </summary>
        /// <returns></returns>
        int GetY();
        /// <summary>
        /// get the Width of the button 
        /// </summary>
        /// <returns></returns>
        int GetWidth();
        /// <summary>
        /// get the Hight of the button
        /// </summary>
        /// <returns></returns>
        int GetHeight();
        /// <summary>
        /// get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        string GetCssValue(string prp);
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// Get Button Element
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetButtonElement();

    }
}
