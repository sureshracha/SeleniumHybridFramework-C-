using OpenQA.Selenium;
using System;
using TestAutomation.ObjectLocators;
 


namespace TestAutomation.Interfaces
{
    /// <summary>
    /// WebComponent's IWebTable Interface which gives basic operations on DAtaGrid (Table)
   
    /// </summary>
    public interface IWebTable 
    {
        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="objprp"></param>
        /// <returns></returns>
        /// <author> Suresh Racha</author>
        string GetPropertyValue(string objprp);
        /// <summary>
        /// click method which clicks on the table
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
        /// Get the boolean value (true/false) whether the table is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        
        bool IsEnabled();
        /// <summary>
        /// Get the boolen value (true/false) whether the table is enabled or displayed (existed => true, not existed => false)
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
        /// Get the Width of the table 
        /// </summary>
        /// <returns></returns>
        
        int GetWidth();
        /// <summary>
        /// Get the Hight of the table
        /// </summary>
        /// <returns></returns>
        
        int GetHeight();
        /// <summary>
        /// Get the cell data of the table ex: tablename.GetCellData(2,3);
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <returns></returns>
        
        String GetCellData(int Row, int Column);
        /// <summary>
        ///  Get row number with the cell text of the table ex: tablename.GetRowWithCellText(2,3);
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Column"></param>
        /// <param name="StartFromRow"></param>
        
        /// <returns></returns>
        int GetRowWithCellText(String Text, int Column=1, int StartFromRow=1);


        int GetRowWithCellMultipleText(String Text1, String Text2, int Column1, int Column2, int StartFromRow = 1);


        int GetRowWithCellMultipleTextBy3(String Text1, String Text2, string Text3, int Column1, int Column2, int Column3, int StartFromRow = 1);


        int GetRowWithCellMultipleTextBy5(String Text1, String Text2, string Text3, string Text4, string Text5,int Column1, int Column2, int Column3, int Column4, int Column5, int StartFromRow = 1);

        /// <summary>
        /// Get Css value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>Css value as string</returns>

        string GetCssValue(string prp);
        /// <summary>
        /// Geting the table row count
        /// </summary>
        /// <returns></returns>
        
        int GetRowCount();
        /// <summary>
        /// Select a row  ex: tableobj.SelectRow(1,3,0); OR tableobj.SelectRow(1); 
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="ColNum"></param>
        /// <param name="index"></param>
        
        void SelectRow(int rownum, int ColNum=1,int index=1);
        /// <summary>
        /// Getting Table Column count, parameter row number is optional
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        
        int GetColumnCount(int row =1);
        /// <summary>
        /// Getting Table Column names
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>    
        
        string GetColumnNames(int row=1);
        /// <summary>
        /// Getting a column number of a table . Ex: 
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="Row"></param>
        /// <param name="StartCol"></param>
        /// <returns></returns>
        
        int GetColumnNumber(String ColumnName,  int Row=1 , int StartCol=1 );
        /// <summary>
        /// double click on a table row
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="ColNum"></param>
        
        void DoubleClickRow(int rownum=1 , int ColNum=1);
        /// <summary>
        /// Right click on a table row
        /// </summary>
        /// <param name="rownum"></param>
        
        void RightClickOnRow(int rownum);
        /// <summary>
        /// Get IWebElement
        /// </summary>
        /// <returns>IWebElment</returns>
        
        IWebElement GetWebTable();

    }
}
