using System;
using System.Data;

namespace TestAutomation.DataLayer.Interfaces
{
    /// <summary>
    /// DB Reading , select,insert, update and delete basic operations
    /// </summary>
    public interface IDbDataReader
    {
        /// <summary>
        /// execute the select query with default db details
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        DataTable ExecuteSelectQuery(string sQuery);
        /// <summary>
        /// execute the select query with db details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        DataTable ExecuteSelectQuery(string ServerName, string DatabaseName, string UserId, string Password,string sQuery);
        /// <summary>
        /// Execute the insert of update or delete query with default db details
        /// </summary>
        /// <param name="sQuery"></param>
        void ExecuteInserOrUpdateOrDeleteQuery(string sQuery);
        /// <summary>
        /// Execute the insert of update or delete query with  db details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        void ExecuteInserOrUpdateOrDeleteQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

    }
}