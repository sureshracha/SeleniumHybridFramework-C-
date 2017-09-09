using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using excel.application;

 
namespace TestAutomation.DataLayer.DataReaders
{
    /// <summary>
    ///     To cater the needs of maintening test data in excel and reading back 
    ///     that data using common methods.
    /// </summary>
    //public class Excel
    public class Excel : IExcel 
    {
        OleDbDataAdapter da;
        OleDbConnection con;
        static DataSet ds;
       
        string sDbCon;
        string filePath;
        public static string sheetName;
        /// <summary>
        /// excel
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <param name="sSheetName"></param>
        public Excel(string sFilePath, string sSheetName)
        {
            {
                if (!string.IsNullOrEmpty(sFilePath))
                {
                    try
                    {
                        this.filePath = sFilePath;
                        this.sDbCon = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0};Extended Properties='Excel 12.0 Xml;Readonly=False;'", sFilePath);
                        ds = new DataSet();
                        con = new OleDbConnection(sDbCon);
                        con.Open();
                         
                        string query = string.Format("SELECT * FROM [{0}]", sSheetName + "$");



                        var dataTable = new DataTable();
                       
                        dataTable.TableName = sSheetName;  
                        da = new OleDbDataAdapter(query, con);
                        da.Fill(dataTable);
                        ds.Tables.Add(dataTable);

                        
                        dataTable = null;
                        
                    }
                     
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                         
                    }

                    
                }
                else { Console.WriteLine("invalid file path:{0}", sFilePath); }
            }
        }
        /// <summary>
        /// getting rows with querie
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sQueryWhereClauseCondition"></param>
        /// <returns></returns>
        public DataTable GetQueriedRows(string sTableName, string sQueryWhereClauseCondition)
        {
            DataTable dt = null;
            
            DataTable tempDataTable;

            if (!string.IsNullOrEmpty(sTableName) && !string.IsNullOrEmpty(sQueryWhereClauseCondition))
            {
                try
                {
                    tempDataTable = ds.Tables[sTableName];
                    
                    dt = tempDataTable.Select(sQueryWhereClauseCondition).CopyToDataTable();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                     
                }
            }
            else { Console.WriteLine("Invalid parameters TableName:{0}, Query:{1}", sTableName, sQueryWhereClauseCondition); }

            return dt;
        }
        /// <summary>
        /// get the rowdata
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sQueryWhereClauseCondition"></param>
        /// <returns></returns>
        public DataRow GetQueriedRow(string sTableName, string sQueryWhereClauseCondition)
        {
            DataTable tempDataTable = new DataTable();
            DataRow resultRow = null;
            

            if (!string.IsNullOrEmpty(sTableName) && !string.IsNullOrEmpty(sQueryWhereClauseCondition))
            {
                try
                {
                    tempDataTable = ds.Tables[sTableName];
                  
                    resultRow = tempDataTable.Select(sQueryWhereClauseCondition).CopyToDataTable().Rows[0];
                    if (resultRow != null)
                        return resultRow;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                  
                }
            }
            else { Console.WriteLine("Invalid parameters TableName:{0}, Query:{1}", sTableName, sQueryWhereClauseCondition); }

            return resultRow;
        }
        /// <summary>
        /// gettting the cell data as string
        /// </summary>
        /// <param name="sSheetName"></param>
        /// <param name="iRowNumber"></param>
        /// <param name="sColumnName"></param>
        /// <returns></returns>
        public string GetCellDataAsString(string sSheetName, int iRowNumber, string sColumnName)
        {
            DataTable tempDataTable = new DataTable();
            string cellValue = null;
            if (!string.IsNullOrEmpty(sSheetName) && (iRowNumber.Equals("")) && !string.IsNullOrEmpty(sColumnName))
            {
                try
                {
                    tempDataTable = ds.Tables[sSheetName + "$"];
                    
                    cellValue = tempDataTable.Rows[iRowNumber][sColumnName].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else { Console.WriteLine("Invalid parameters TableName:{0}, Query:{1}, Column:{2}", sSheetName, iRowNumber, sColumnName); }

            return cellValue;
        }
        /// <summary>
        /// getting sheet as datatable
        /// </summary>
        /// <param name="sSheetName"></param>
        /// <returns></returns>
        public DataTable GetSheetAsTable(string sSheetName)
        {
            DataTable dt = null;
            return dt;
        }
        
        /// <summary>
        /// close the excel connection
        /// </summary>
        /// <returns></returns>
        public bool CloseExcelConnection()
        {
            bool isConnectionClosed = false;
            ConnectionState state = con.State;

            if (state == ConnectionState.Open)
            {
                con.Close();
                isConnectionClosed = true;
            }

            return isConnectionClosed;

        }
        /// <summary>
        /// open excel connection
        /// </summary>
        /// <returns></returns>
        public bool OpenExcelConnection()
        {
            bool isConnectionOpened = false;
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    try
                    {
                        con = new OleDbConnection(sDbCon);
                        con.Open();
                    }
                   
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                }
                else { Console.WriteLine("invalid file path:{0}", filePath); }
            }
            return isConnectionOpened;
        }

        
    }


}
