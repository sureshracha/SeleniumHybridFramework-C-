using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.DataLayer
{
    public interface IDataDriver
    {

        /// <summary>
        /// this is used to get the DataTable column value after getting the data to the datatable
        /// 
        /// </summary>
        /// <param name="ColumnName"/><param name="Row"/><author>Suresh Racha</author>
        /// <returns>
        /// string value
        /// </returns>
        string GetColumnValue(string ColumnName, int Row = 0);

        /// <summary>
        /// this is used to get the total rows count after execution of a query(DB or Excel)
        /// 
        /// </summary>
        /// <author>Suresh Racha</author>
        /// <returns>
        /// Row Count as int
        /// </returns>
        int GetRowsCount();

        /// <summary>
        /// this is used to Read the data from XL file and stores in the DataTable
        /// 
        /// </summary>
        /// <param name="FilePath"/><param name="SheetName"/><param name="FetchQuery"/><author>Suresh Racha </author>
        //void ReadDataFromXl(string FilePath, string SheetName, string FetchQuery);

        ///// <summary>
        ///// this is used to Read the data from XL file and returns the DataTable
        ///// 
        ///// </summary>
        ///// <param name="FilePath"/><param name="SheetName"/><param name="FetchQuery"/>
        ///// <returns>
        ///// DataTable
        ///// </returns>
        ///// <author>Suresh Racha </author>
        //DataTable ReadDataFromXl_AsDataTable(string FilePath, string SheetName, string FetchQuery);

        /// <summary>
        /// Read the data from db
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        void ReadDataFromDb(string sQuery);

        /// <summary>
        /// read the data from db with db and user datails
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        void ReadDataFromDb(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

        /// <summary>
        /// Read the data from db and returns as DAtatable with db and user login details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/>
        /// <returns>
        /// datatable
        /// </returns>
        /// <author>suresh racha</author>
        DataTable ReadDataFromDb_AsDataTable(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

        /// <summary>
        /// Read the data from db and returns as DAtatable
        /// 
        /// </summary>
        /// <param name="sQuery"/>
        /// <returns>
        /// datatable
        /// </returns>
        /// <author>suresh racha</author>
        DataTable ReadDataFromDb_AsDataTable(string sQuery);

        /// <summary>
        /// updating the db table
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        void UpdateDbTable(string sQuery);

        /// <summary>
        /// deleting the row from db table
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        void DeleteDbTableRowOrRows(string sQuery);

        /// <summary>
        /// insert a row in db table
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        void InserRowInDb(string sQuery);

        /// <summary>
        /// update the db table with db table and user login details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        void UpdateDbTable(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

        /// <summary>
        /// Delete db table row with db and login details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        void DeleteDbTableRowOrRows(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

        /// <summary>
        /// insert a row in db table with db details and user details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        void InserRowInDb(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

        /// <summary>
        /// Whether the Data reading from DB or XL is successfully or not
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// true/false
        /// </returns>
        /// <author>suresh racha</author>
        bool IsDataReadSuccess();
    }
}
