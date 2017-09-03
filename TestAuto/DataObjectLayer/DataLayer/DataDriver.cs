using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.DataLayer
{
   public class DataDriver: IDataDriver
    {
        public DataDriver(IDBDataReader reader)
        {
            dbReader = reader;
            dataTable = new DataTable();

        }


        private IDBDataReader dbReader;//= (IDBDataReader)new DBDataReader(new DataConnObject.DataConnObjs().setNTeractDB());

        private DataTable dataTable;

        /// <summary>
        /// getting the Column value after executing the DB or XL Queuries
        /// 
        /// </summary>
        /// <param name="ColumnName"/><param name="Row"/>
        /// <returns/>
        /// <author>suresh racha</author>
        public string GetColumnValue(string ColumnName, int Row = 0)
        {
            string str = "";
            try
            {
                int count1 = this.dataTable.Rows.Count;
                int count2 = this.dataTable.Columns.Count;
                DataRow dataRow = this.dataTable.Rows[Row];
                for (int index = 0; index < count2; ++index)
                {
                    if (dataRow.Table.Columns[index].ToString().Trim().ToLower().Equals(ColumnName.Trim().ToLower()))
                    {
                        str = dataRow.ItemArray[index].ToString().Trim();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                return str;
            }
            return str;
        }

        /// <summary>
        /// Whether the Data reading from DB or XL is successfully or not
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// true/false
        /// </returns>
        /// <author>suresh racha</author>
        public bool IsDataReadSuccess()
        {
            return this.dataTable != null;
        }

        /// <summary>
        /// get the row count of result datatble
        /// 
        /// </summary>
        /// 
        /// <returns/>
        /// <author>suresh racha</author>
        public int GetRowsCount()
        {
            return this.dataTable.Rows.Count;
        }

        /// <summary>
        /// Reading the data from XL and stores in the DAtatable
        /// 
        /// </summary>
        /// <param name="FilePath"/><param name="SheetName"/><param name="FetchQuery"/><author>suresh racha</author>


        /// <summary>
        /// REading the data from xl file and returns the datatable
        /// 
        /// </summary>
        /// <param name="FilePath"/><param name="SheetName"/><param name="FetchQuery"/>
        /// <returns>
        /// datatable
        /// </returns>
        /// <author>suresh racha</author>


        /// <summary>
        /// Read the data from db
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        public void ReadDataFromDb(string sQuery)
        {
            this.dataTable = this.dbReader.ExecuteSelectQuery(sQuery);
            if (this.IsDataReadSuccess())
                return;
            this.dataTable = this.dbReader.ExecuteSelectQuery(sQuery);
        }

        /// <summary>
        /// read the data from db with db and user datails
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        public void ReadDataFromDb(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            this.dataTable = this.dbReader.ExecuteSelectQuery(ServerName, DatabaseName, UserId, Password, sQuery);
            if (this.IsDataReadSuccess())
                return;
            this.dataTable = this.dbReader.ExecuteSelectQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }

        /// <summary>
        /// Read the data from db and returns as DAtatable with db and user login details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/>
        /// <returns>
        /// datatable
        /// </returns>
        /// <author>suresh racha</author>
        public DataTable ReadDataFromDb_AsDataTable(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            this.ReadDataFromDb(ServerName, DatabaseName, UserId, Password, sQuery);
            return this.dataTable;
        }

        /// <summary>
        /// Read the data from db and returns as DAtatable
        /// 
        /// </summary>
        /// <param name="sQuery"/>
        /// <returns>
        /// datatable
        /// </returns>
        /// <author>suresh racha</author>
        public DataTable ReadDataFromDb_AsDataTable(string sQuery)
        {
            this.ReadDataFromDb(sQuery);
            return this.dataTable;
        }

        /// <summary>
        /// updating the db table
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        public void UpdateDbTable(string sQuery)
        {
            this.dbReader.ExecuteInserOrUpdateOrDeleteQuery(sQuery);
        }

        /// <summary>
        /// deleting the row from db table
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        public void DeleteDbTableRowOrRows(string sQuery)
        {
            this.dbReader.ExecuteInserOrUpdateOrDeleteQuery(sQuery);
        }

        /// <summary>
        /// insert a row in db table
        /// 
        /// </summary>
        /// <param name="sQuery"/><author>suresh racha</author>
        public void InserRowInDb(string sQuery)
        {
            this.dbReader.ExecuteInserOrUpdateOrDeleteQuery(sQuery);
        }

        /// <summary>
        /// update the db table with db table and user login details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        public void UpdateDbTable(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            this.dbReader.ExecuteInserOrUpdateOrDeleteQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }

        /// <summary>
        /// Delete db table row with db and login details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        public void DeleteDbTableRowOrRows(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            this.dbReader.ExecuteInserOrUpdateOrDeleteQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }

        /// <summary>
        /// insert a row in db table with db details and user details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/><author>suresh racha</author>
        public void InserRowInDb(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            this.dbReader.ExecuteInserOrUpdateOrDeleteQuery(ServerName, DatabaseName, UserId, Password, sQuery);
        }
    }
}
