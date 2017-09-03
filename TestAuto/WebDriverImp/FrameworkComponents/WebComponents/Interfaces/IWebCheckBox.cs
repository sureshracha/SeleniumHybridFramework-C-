

using OpenQA.Selenium;
using System.Collections.Generic;
using TestAutomation.ObjectLocators;
using TestAutomation.WebComponents.ObjectProperties;



namespace TestAutomation.WebComponents.Interfaces
{
    /// <summary>
    /// IWebCheckBox intereface which is common to all tools implementation for WebCheckBox
    /// </summary>
    
    public interface IWebCheckBox
    {


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
        string GetPropertyValue(string objprp);
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
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
        /// get the boolean value (true/false) whether the textbox is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        bool IsEnabled();
        /// <summary>
        /// get the boolen value (true/false) whether the textbox is enabled or displayed (existed => true, not existed => false)
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
        /// get the Width of the TExtbox 
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetWidth();
        /// <summary>
        /// get the Hight of the Textbox
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        int GetHeight();
        /// <summary>
        /// Select the checkbox
        /// </summary> 
        /// <author> Suresh Racha</author>
        void Select();
        /// <summary>
        /// unselect the selected checkbox
        /// </summary>
        /// <author> Suresh Racha</author>
        void UnSelect();
        /// <summary>
        /// get the boolen value (true/false) whether the checkbox is checked or unchecked (checked => true, unchecked => false)
        /// </summary>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        bool IsChecked();
        /// <summary>
        /// get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        /// <author> Suresh Racha</author>
        string GetCssValue(string prp);

        /// <summary>
        /// click method which clicks on the button using JavaScriptExecutor
        /// </summary>
        void JsClick();
        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetCheckBox();






    }
}
