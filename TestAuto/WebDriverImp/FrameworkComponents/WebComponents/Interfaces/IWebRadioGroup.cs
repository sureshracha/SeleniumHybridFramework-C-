
using OpenQA.Selenium;
using TestAutomation.ObjectLocators;
using TestAutomation.WebComponents.ObjectProperties;

namespace TestAutomation.WebComponents.Interfaces
{
    public interface IWebRadioGroup
    {

        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        
        IObjectLocator GetLocator();
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
        /// <param name="Itemname"></param>
        /// <returns></returns>
        
        string GetPropertyValue(string Itemname,GetBy objprp);
        /// <summary>
        /// set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        
        void SetLocatorValues(FindBy type, string value);
        /// <summary>
        /// get the boolean value (true/false) whether the Radiobuttongroup is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        
        bool IsEnabled();
        /// <summary>
        /// get the boolen value (true/false) whether the Radiobuttongroup is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        
        bool IsExist();
        /// <summary>
        /// get the X position value
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        int GetX(string itemname);
        /// <summary>
        /// get the Y position value
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        int GetY(string itemname);
        /// <summary>
        /// get the Width of the Radiobuttongroup 
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        
        int GetWidth(string itemname);
        /// <summary>
        /// get the Hight of the Radiobuttongroup
        /// </summary>
        /// <param name="itemname"></param>
        /// <returns></returns>
        


        int GetHeight(string itemname);
        /// <summary>
        /// Select the Radio button by giving the value
        /// </summary> 
        
        void Select(string itemname);
        /// <summary>
        /// get the boolen value (true/false) whether the Radiobuttongroup specified item is selected or not (selected => true, not selected => false)
        /// </summary> 
        
        bool IsSelect(string itemname);
        /// <summary>
        /// To get no.of radio buttons within the group
        /// </summary>
        /// <returns>integer</returns>
        
        int GetRadioButtonsCount();

        /// <summary>
        /// Get RadioGroup Element
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetRadioGroup();

        /// <summary>
        /// click method which clicks on the RadioGroup using JavaScriptExecutor
        /// </summary>
        void JsClick();
        

    }
}
