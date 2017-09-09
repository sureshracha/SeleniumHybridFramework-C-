using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using OpenQA.Selenium;
using TestAutomation.Interfaces;


using TestAutomation.ObjectLocators;
using System.Collections;

namespace TestAutomation.WebDriver
{
    public class WebTable : IWebTable
    {
        IObjectLocator locator;
         WebdriverImp wr;
        IWebDriver driver = null;
        IWebElement Table;

        /// <summary>
        /// getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="prp"></param>
        /// <returns></returns>
        
        public string GetPropertyValue(string prp)
        {
            if (IsExist())
            {
                if (this.driver == null)
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                
                   

                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        int RowCount, ColumnCount;

        /// <summary>
        /// Constructor takes findby and value as param
        /// </summary>
        ///  <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public WebTable(Browser browser, FindBy type, string value)
        {
            this.driver = browser.GetBrowser();
            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        
        /// <summary>
        /// Get Css value from the button
        /// </summary>
        /// <param name="prp"></param>
        /// <returns>Css value as string</returns>
        
        public string GetCssValue(string prp)
        {
            if (IsExist())
            {
                return this.wr.GetCssValue(this.locator, prp);
            }
            return "";
        }
       
         
        /// <summary>
        /// click method which clicks on the table
        /// </summary>
        

        public void Click()
        {
            if (IsExist())
            {
                this.Table.Click();
            }
        }

        /// <summary>
        /// Getting the Locator as return value
        /// </summary>
        /// <returns></returns>
        
        public IObjectLocator GetLocator()
        {
            return this.locator;
        }
        /// <summary>
        /// Set the locator values example ObjectName.SetLocatorValues("id","txtUserName");
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        
        public void SetLocatorValues(FindBy type, string value)
        {

            Hashtable htbl = new Hashtable();
            htbl[type.ToString()] = value.Trim();
            IObjectLocator l = new ObjectLocator(htbl);
            this.locator = l;

        }
        /// <summary>
        /// Getting property vlaues like text,value,tagname and so on...
        /// </summary>
        /// <param name="prp"></param>
        /// <returns></returns>
        
        public string GetPropertyValue(GetBy prp)
        {
            if (IsExist())
            {
               
                return this.wr.GetElementPropertyValue(this.locator, prp);
            }
            return "";
        }
        /// <summary>
        /// Get the boolean value (true/false) whether the table is enabled or displayed (Enabled => true, disabled => false)
        /// </summary>
        /// <returns></returns>
        
        public bool IsEnabled()
        {


            try
            {

                if (this.driver == null)
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                
                   

                this.Table = this.wr.GetElement(this.locator);

                return this.Table.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Get the boolen value (true/false) whether the table is enabled or displayed (existed => true, not existed => false)
        /// </summary>
        /// <returns></returns>
        
        public bool IsExist()
        {
            try
            {

                if (this.driver == null)
                {
                    this.wr = new WebdriverImp(new Browser().GetBrowser());
                }
                
                   

                this.Table = this.wr.GetElement(this.locator);

               
                if (this.Table.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }


        }
        /// <summary>
        /// Get the cell data of the table ex: tablename.GetCellData(2,3);
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <returns></returns>
        
        public String GetCellData(int Row, int Column)
        {
            IList<IWebElement> CellData = new List<IWebElement>();
            if (IsExist())
            {
                IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));                

                
                CellData = rows[Row].FindElements(By.TagName("td"));

                if(CellData.Count == 0  )
                    CellData = rows[Row].FindElements(By.TagName("th"));

                if (this.driver == null)
                    this.driver = new Browser().GetBrowser();


                IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
                var cName = executor.ExecuteScript("return arguments[0].innerText", CellData[Column]);
                
                if (cName != null)
                {
                    string cValue = cName.ToString();
                    if (cValue.Contains('\n') || cValue.Contains('\r'))
                    {
                        cValue = cValue.Replace("\n", "");
                        cValue = cValue.Replace("\r", "");
                    }
                    return cValue;
                }                

               
            }
            return "";
          
        }
        /// <summary>
        ///  Get row number with the cell text of the table ex: tablename.GetRowWithCellText(2,3);
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Column"></param>
        /// <param name="StartFromRow"></param>
        
        /// <returns></returns>

        public int GetRowWithCellText(String Text, int Column =1, int StartFromRow = 1)
        {
            int rcnt = this.GetRowCount();
            string txt2match = Text.ToLower().Replace("  ", " ").Trim();
            for (int j = StartFromRow; j < rcnt; j++)
            {
                string txt2search = this.GetCellData(j, Column).ToLower().Replace("  ", " ").Trim();
                if (txt2search == txt2match)
                {
                    return j;
                }
            }
            return 0;
        }

        public int GetRowWithCellMultipleText(String Text1, String Text2,  int Column1, int Column2, int StartFromRow = 1)
        {
            int rcnt = this.GetRowCount();

            for (int j = StartFromRow; j < rcnt; j++)
            {
                if (this.GetCellData(j, Column1).ToLower().Replace("  ", " ").Equals(Text1.ToLower())
                    && (this.GetCellData(j,Column2)).ToLower().Replace("  "," ").Equals(Text2.ToLower() ))
                {
                    return j;
                }
            }
            return 0;
        }




        public int GetRowWithCellMultipleTextBy3(String Text1, String Text2, string Text3, int Column1, int Column2, int Column3, int StartFromRow = 1)
        {
            int rcnt = this.GetRowCount();

            for (int j = StartFromRow; j < rcnt; j++)
            {
                if (this.GetCellData(j, Column1).ToLower().Replace("  ", " ").Equals(Text1.ToLower())
                    && (this.GetCellData(j, Column2)).ToLower().Replace("  ", " ").Equals(Text2.ToLower())
                    && (this.GetCellData(j,Column3)).ToLower().Replace("  "," ").Equals(Text3.ToLower()))
                {
                    return j;
                }
            }
            return 0;
        }

       public int GetRowWithCellMultipleTextBy5(String Text1, String Text2, string Text3, string Text4, string Text5, int Column1, int Column2, int Column3, int Column4, int Column5, int StartFromRow = 1)
        {
            int rcnt = this.GetRowCount();

            for (int j = StartFromRow; j<rcnt; j++)
            {
                if (this.GetCellData(j, Column1).ToLower().Replace("  ", " ").Equals(Text1.ToLower())
                    && (this.GetCellData(j, Column2)).ToLower().Replace("  ", " ").Equals(Text2.ToLower())
                    && (this.GetCellData(j, Column3)).ToLower().Replace("  "," ").Equals(Text3.ToLower())
                    && (this.GetCellData(j, Column4)).ToLower().Replace("  "," ").Equals(Text4.ToLower())
        
                    && (this.GetCellData(j, Column5)).ToLower().Replace("  "," ").Equals(Text5.ToLower()))
                {
                    return j;
                }
}
            return 0;
        }

        public int GetRowWithCellText1(String Text, int Column = 1, int StartFromRow = 1)
        {
            int rcnt = this.GetRowCount();
            int colcnt = this.GetColumnCount(1);

            for (int j = StartFromRow; j < rcnt; j++)
            {

                
                if (this.GetCellData(j, Column).ToLower().Equals(Text.ToLower()))
                {
                    return j;
                }


            }
            return 0;
        }
        /// <summary>
        /// Geting the table row count
        /// </summary>
        /// <returns></returns>
        
        public int GetRowCount()
        {
            if (IsExist())
            {
                IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));
                if (rows.Count() == 0)
                {
                    this.RowCount = 0;
                    return 0;

                }
                else
                {
                    this.RowCount = rows.Count();
                    return this.RowCount;
                }
            }
            return 0;
        }
        /// <summary>
        /// Select a row  ex: tableobj.SelectRow(1,3,0); OR tableobj.SelectRow(1); 
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="ColNum"></param>
        /// <param name="index"></param>
        
        public void SelectRow(int rownum, int ColNum = 1, int index = 0)
        {

            if (IsExist())
            {
                try
                {
                    IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));
                    if (rows.Count() != 0)
                    {
                        if (rows[rownum].Enabled.Equals(true))
                            ClickRow(rows[rownum]);
                    }
                }catch (Exception) { }
            }


        }
        /// <summary>
        /// Getting Table Column count, parameter row number is optional
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        
        public int GetColumnCount(int row = 1)
        {
            if (IsExist())
            {
                IList<IWebElement> cells = new List<IWebElement>();
                IList <IWebElement> rows = this.Table.FindElements(By.TagName("tr"));

                try
                {
                    cells = rows[row].FindElements(By.TagName("td"));

                }catch (Exception) { }

                if (cells.Count() == 0)
                {
                    cells = rows[row - 1].FindElements(By.TagName("th"));
                }


                this.ColumnCount = cells.Count();

            }
            else
                this.ColumnCount = 0;

            return this.ColumnCount;
        }
        /// <summary>
        /// Getting Table Column names
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>    
        
        public string GetColumnNames(int row = 1)
        {
            string columnames = "";


            if (IsExist())
            {
                
                IList<IWebElement> cells = new List<IWebElement>();
                IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));

                try
                {
                    cells = rows[row - 1].FindElements(By.TagName("th"));

                }
                catch (Exception) { }

                if (cells.Count() == 0)
                {
                    return columnames;
                }
                else
                {
                    for(int i=0; i<cells.Count; i++)
                    {
                        if (this.driver == null)
                            this.driver = new Browser().GetBrowser();
                       

                        IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
                        var cName = executor.ExecuteScript("return arguments[0].innerText", cells[i]);


                        if (cName != null)
                        {
                            string cText = cName.ToString();
                            if (!(cText.Contains("[[") && cText.Contains("]]")))
                                columnames = columnames + cName.ToString() + ";";
                        }
                    }
                    
                    columnames =  columnames.Remove(columnames.Length-1,1);

                    return columnames;
                }

            }
            else
                return columnames;

        }
        /// <summary>
        /// Getting a column number of a table . Ex: 
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="Row"></param>
        /// <param name="StartCol"></param>
        /// <returns></returns>
        
        public int GetColumnNumber(String ColumnName,  int Row = 1, int StartCol = 1)
        {

            int colcnt = GetColumnCount(Row);
           
            if (IsExist())
            {
               
                IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));
                IList<IWebElement> CellData = rows[Row - 1].FindElements(By.TagName("th"));
               
                    for (int i = StartCol; i < colcnt; i++)
                    {
                        if (this.driver == null)
                        this.driver = new Browser().GetBrowser();
                    

                    IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
                        var cName = executor.ExecuteScript("return arguments[0].innerText", CellData[i]);

                        string cText = "";
                        if (cName != null)
                        {
                            cText = cName.ToString();

                            if (cText.ToLower().Trim().Equals(ColumnName.ToLower().Trim()))
                            {
                              return i;
                                
                            }
                        }
                }

            }
            return 0;
        }

        /// <summary>
        /// double click on a table row
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="ColNum"></param>
        

        public void DoubleClickRow(int rownum = 1, int Column = 1)
        {
            if (IsExist())
            {
                IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));
                if (rows.Count == 0)
                {
                    rows = Table.FindElements(By.TagName("th"));
                    if (rows.Count != 0)
                        this.wr.DoubleClick(rows[rownum]);
                }
                else
                    this.wr.DoubleClick(rows[rownum]);
            }
        }
        /// <summary>
        /// Right click on a table row
        /// </summary>
        /// <param name="rownum"></param>
        
        public void RightClickOnRow(int rownum)
        {
            if (IsExist())
            {
                IList<IWebElement> rows = this.Table.FindElements(By.TagName("tr"));
                if (rows.Count == 0)
                {
                    rows = this.Table.FindElements(By.TagName("th"));
                    if (rows.Count != 0)
                        this.wr.RightClick(rows[rownum]);

                }
                else
                    this.wr.RightClick(rows[rownum]);
                
            }
        }
        /// <summary>
        /// Get the X position value
        /// </summary>
        /// <returns></returns>
        
        public int GetX()
        {
           
            if (IsExist())
            {
                Point Location = this.Table.Location;
                return Location.X;
            }
            return 0;

        }
        /// <summary>
        /// Get the Y position value
        /// </summary>
        /// <returns></returns>
        
        public int GetY()
        {
           
            if (IsExist())
            {
                Point Location = this.Table.Location;
                return Location.X;
            }
            return 0;
        }
        /// <summary>
        /// Get the Width of the table 
        /// </summary>
        /// <returns></returns>
        
        public int GetWidth()
        {
             
            if (IsExist())
            {
                Size Si = this.Table.Size;
                return Si.Width;
            }
            return 0;
        }
        /// <summary>
        /// Get the Hight of the table
        /// </summary>
        /// <returns></returns>
        
        public int GetHeight()
        { 
            if (IsExist())
            {
                Size Si = this.Table.Size;
                return Si.Height;
            }
            return 0;
        }



        public void JsClick()
        {
            if (this.driver == null)
                this.driver = new Browser().GetBrowser();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", GetWebTable());
        }

        public void ClickRow(IWebElement RowN)
        {
            if (this.driver == null)
                this.driver =  new Browser().GetBrowser();
            

            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].click();", RowN);
        }

 
        public IWebElement GetWebTable()
        {
            IsExist();
            return this.Table;
             
        }
        

        

    }
}
