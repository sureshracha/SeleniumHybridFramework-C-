using System;

namespace excel.application
{
    /// <summary>
    /// Basic reading operations on Excel as DB and storing in Data row and data as sting 
    /// Author : Bulusu
    /// </summary>
    public interface IExcel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool OpenExcelConnection();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool CloseExcelConnection();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Data.DataTable GetQueriedRows(string sTableName, string sQueryWhereClauseCondition);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Data.DataRow GetQueriedRow(string sTableName, string sQueryWhereClauseCondition);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetCellDataAsString(string sSheetName, int iRowNumber, string sColumnName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Data.DataTable GetSheetAsTable(string sSheetName);
       

    }
}