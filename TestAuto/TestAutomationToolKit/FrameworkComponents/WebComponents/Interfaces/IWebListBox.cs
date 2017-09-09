using OpenQA.Selenium;
using System;
using TestAutomation.ObjectLocators;
 


namespace TestAutomation.Interfaces
{
    /// <summary>
    /// WebComponent's IWebListBox Interface which gives basic operations on weblistbox
   
    /// </summary>
    public interface IWebListBox  
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
        /// click method which clicks on the ListBox
        /// </summary>
        
        void Click();
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
        /// Get the boolean value (true/false) whether the ListBox is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        
        bool IsEnabled();
        /// <summary>
        /// Get the boolen value (true/false) whether the ListBox is enabled or displayed (existed => true, not existed => false)
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
        /// Get the Width of the ListBox 
        /// </summary>
        /// <returns></returns>
        
        int GetWidth();
        /// <summary>
        /// Get the Hight of the ListBox
        /// </summary>
        /// <returns></returns>
        
        int GetHeight();
        /// <summary>
        ///  To Get all the Items of a listbox as a string, separated by ; (semicolon)
        /// </summary>
        /// <returns></returns>   
        
        String GetAllItemsValues();
        /// <summary>
        /// Select an Item by value from the listbox
        /// </summary>
        /// <param name="val"></param>
        
        void SelectItemByValue(String val);
        /// <summary>
        /// Select an Item by text from the list box
        /// </summary>
        /// <param name="val"></param>
        
        void SelectItemByText(String val);
        /// <summary>
        /// select an item by index from the listbox
        /// </summary>
        /// <param name="ilndex"></param>
        
        void SelectItemByIndex(int ilndex);
        /// <summary>
        /// deSelect an Item by value from the listbox
        /// </summary>
        /// <param name="val"></param>
        
        void DeSelectItemByValue(String val);
        /// <summary>
        /// deSelect an Item by text from the list box
        /// </summary>
        /// <param name="ilndex"></param>
        
        void DeSelectItemByIndex(int ilndex);
        /// <summary>
        /// deselect the items  from the listbox
        /// </summary>
        
        void DeSelectAllItems();
        /// <summary>
        /// Get CSS value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>CSS value as string</returns>
        
        string GetCssValue(string prp);

        /// <summary>
        /// List Items Count
        /// </summary>
        /// <returns>cout</returns>
        
        int ListItemsCount();
        /// <summary>
        /// Select all items of listbox
        /// </summary>
        
        void SelectAllElements();
        /// <summary>
        /// Get the selected element for combobox
        /// </summary>
        /// <returns></returns>
        
        string GetSelectedElement();
        /// <summary>
        /// get all list Items as array
        /// </summary>
        /// <returns>string array</returns>
        
        string[] GetListItemsAsArray();

        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetListBox();



    }
}
