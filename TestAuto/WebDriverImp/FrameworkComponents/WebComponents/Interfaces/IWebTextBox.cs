using OpenQA.Selenium;
using System;
using TestAutomation.ObjectLocators;
using TestAutomation.WebComponents.ObjectProperties;


namespace TestAutomation.WebComponents.Interfaces
{
    /// <summary>
    /// WebComponent's IWebTextBox Interface which gives basic operations on textbox/editarea/editbox
   
    /// </summary>
    public interface IWebTextBox  
    {
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// click method which clicks on the element
        /// </summary>
        
        void Click();
        /// <summary>
        /// click method which clicks   using JavaScriptExecutor
        /// </summary>
        void JsClick();
        /// <summary>
        /// Getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        

        IObjectLocator GetLocator();
        /// <summary>
        /// Get Css value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>Css value as string</returns>
        
        string GetCssValue(string prp);
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
        /// Get the boolean value (true/false) whether the textbox is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        
        bool IsEnabled();
        /// <summary>
        /// Get the boolen value (true/false) whether the textbox is enabled or displayed (existed => true, not existed => false)
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
        /// Get the Width of the element 
        /// </summary>
        /// <returns></returns>
        
        int GetWidth();
        /// <summary>
        /// Get the Hight of the element
        /// </summary>
        /// <returns></returns>
        
        int GetHeight();
        /// <summary>
        /// Set a value to the textbox
        /// </summary>
        /// <param name="val"></param>
        
        void SetValue(String val);
        /// <summary>
        /// Type a value in the textbox ( adding to the extisting value)
        /// </summary>
        /// <param name="val"></param>
        
        void TypeValue(String val);
        /// <summary>
        /// clearing the existing content of the textbox
        /// </summary>
        
        void Clear();

        /// <summary>
        /// Set a value to the textbox which is of amount type
        /// </summary>
        /// <param name="val"></param>
        

        void SetAmountValue(string val);
        /// <summary>
        /// Set the encripted password
        /// </summary>
        /// <param name="val"></param>
        
        void SetPassword(string val);
        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetTextBox();

    }
 
}
