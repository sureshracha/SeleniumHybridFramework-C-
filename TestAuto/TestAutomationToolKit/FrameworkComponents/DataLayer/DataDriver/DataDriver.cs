using System;
using excel.application;
using System.Data;
using TestAutomation.DataLayer.Interfaces;
using TestAutomation.DataLayer.DataReaders;

namespace TestAutomation.DataLayer.DataDriver
{
    /// <summary>
    /// Data Driver to read the data from xl and db
    /// </summary>
    /// <author>suresh racha</author>
    public class DataDriver : IDataDriver 
    {
        
        IExcel excel;
        readonly IDbDataReader dbReader = new DbDataReader();
        

        private DataTable dataTable = null;

        /// <summary>
        /// getting the Column value after executing the DB or XL Queuries
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="Row"></param>
        /// <returns></returns>
        /// <author>suresh racha</author>
        public String GetColumnValue(String ColumnName, int Row = 0)
        {
            String ColData = "";
            try
            {
                int columncount = dataTable.Columns.Count;
                DataRow datarow = null;
                datarow = (dataTable.Rows[Row]);

                for (int j = 0; j < columncount; j++)
                {
                    if (datarow.Table.Columns[j].ToString().Trim().ToLower().Equals(ColumnName.Trim().ToLower()) == true)
                    {
                        ColData = datarow.ItemArray[j].ToString().Trim();
                        break;
                    }

                }

            }
            catch (Exception) { return ColData; }
            return ColData;

        }
        /// <summary>
        /// Whether the Data reading from DB or XL is successfully or not
        /// </summary>
        /// <returns>true/false</returns>
        /// <author>suresh racha</author>
        public bool IsDataReadSuccess()
        {
            if (dataTable == null)
                return false;
            return true;
        }
        /// <summary>
        /// get the row count of result datatble
        /// </summary>
        /// <returns></returns>
        /// <author>suresh racha</author>
        public int GetRowsCount()
        {
            return dataTable.Rows.Count;
        }
        /// <summary>
        /// Reading the data from XL and stores in the DAtatable
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="SheetName"></param>
        /// <param name="FetchQuery"></param>
        /// <author>suresh racha</author>
        public void ReadDataFromXl(String FilePath, String SheetName, String FetchQuery)
        {
            
            excel = new Excel(FilePath, SheetName);
            dataTable = excel.GetQueriedRows(SheetName, FetchQuery);
        } // Read excel ends
        /// <summary>
        /// REading the data from xl file and returns the datatable
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="SheetName"></param>
        /// <param name="FetchQuery"></param>
        /// <returns>datatable</returns>
        /// <author>suresh racha</author>
        public DataTable  ReadDataFromXl_AsDataTable(String FilePath, String SheetName, String FetchQuery)
        {

            ReadDataFromXl(FilePath, SheetName, FetchQuery);
            return dataTable;

        } //
        /// <summary>
        /// Read the data from db 
        /// </summary>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void ReadDataFromDb(string sQuery)
        {
            
            dataTable = dbReader.ExecuteSelectQuery(sQuery);
            if(!IsDataReadSuccess())
                dataTable = dbReader.ExecuteSelectQuery(sQuery);
        }
        /// <summary>
        /// read the data from db with db and user datails
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void ReadDataFromDb(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            
            dataTable = dbReader.ExecuteSelectQuery(ServerName, DatabaseName, UserId, Password, sQuery);
            if (!IsDataReadSuccess())
                dataTable = dbReader.ExecuteSelectQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }
        /// <summary>
        /// Read the data from db and returns as DAtatable with db and user login details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <returns>datatable</returns>
        /// <author>suresh racha</author>
        public DataTable  ReadDataFromDb_AsDataTable(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            ReadDataFromDb(ServerName, DatabaseName, UserId, Password, sQuery);
            return dataTable;
        }
        /// <summary>
        ///  Read the data from db and returns as DAtatable
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns>datatable</returns>
        /// <author>suresh racha</author>
        public DataTable  ReadDataFromDb_AsDataTable(string sQuery)
        {
            
            ReadDataFromDb(sQuery);
            return dataTable;
        }
        /// <summary>
        /// updating the db table
        /// </summary>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void UpdateDbTable(string sQuery)
        {
            
            dbReader.ExecuteInserOrUpdateOrDeleteQuery(sQuery);

        }
        /// <summary>
        /// deleting the row from db table
        /// </summary>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void DeleteDbTableRowOrRows(string sQuery)
        {
            
            dbReader.ExecuteInserOrUpdateOrDeleteQuery(sQuery);
        }
        /// <summary>
        /// insert a row in db table
        /// </summary>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void InserRowInDb(string sQuery)
        {
            
            dbReader.ExecuteInserOrUpdateOrDeleteQuery(sQuery);
        }
        /// <summary>
        /// update the db table with db table and user login details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void UpdateDbTable(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            
            dbReader.ExecuteInserOrUpdateOrDeleteQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }
        /// <summary>
        /// Delete db table row with db and login details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void DeleteDbTableRowOrRows(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            
            dbReader.ExecuteInserOrUpdateOrDeleteQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }
        /// <summary>
        /// insert a row in db table with db details and user details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <author>suresh racha</author>
        public void InserRowInDb(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            
            dbReader.ExecuteInserOrUpdateOrDeleteQuery(ServerName, DatabaseName, UserId, Password, sQuery); ;
        }

    } 

}//namespace






