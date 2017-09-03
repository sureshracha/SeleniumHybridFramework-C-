
using OpenQA.Selenium;
using System.Collections.Generic;
using TestAutomation.ObjectLocators;
using TestAutomation.WebComponents.ObjectProperties;


namespace TestAutomation.WebComponents.Interfaces
{
    /// <summary>
    /// WebComponent's IElement Interface which gives basic operations on Element
   
    /// </summary>
    public interface IElement 
    {

        /// <summary>
        /// get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        /// <author> Suresh Racha</author>
        string GetCssValue(string prp);
        /// <summary>
        /// click method which clicks   using JavaScriptExecutor
        /// </summary>
        void JsClick();
        /// <summary>
        /// click method which clicks on the element
        /// </summary>
        /// <author> Suresh Racha</author>
        void Click();
        /// <summary>
        /// getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        IObjectLocator GetLocator();
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(GetBy objprp);
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <author> Suresh Racha</author>
        void SetLocatorValues(FindBy type, string value);
        /// <summary>
        /// get the boolean value (true/false) whether the element is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        bool IsEnabled();
        /// <summary>
        /// get the boolen value (true/false) whether the element is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        bool IsExist();
        /// <summary>
        /// get the X position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetX();
        /// <summary>
        /// get the Y position value
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetY();
        /// <summary>
        /// get the Width of the element 
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetWidth();
        /// <summary>
        /// get the Hight of the element
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetHeight();
        /// <summary>
        /// double click on the element
        /// </summary>
        /// <author> Suresh Racha</author>
        void Doubleclick();
        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetElement();

        /// <summary>
        /// Checks to see if an element is checked
        /// </summary>
        /// <returns></returns>
        bool IsChecked();

    }


 
}
