using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.DataLayer
{/// <summary>
 /// DB Reading , select,insert, update and delete basic operations
 ///             Author : Suresh Racha
 /// 
 /// </summary>
    public interface IDBDataReader
    {
        DataTable ExecuteSelectQuery(string sQuery);

        DataTable ExecuteSelectQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);

        void ExecuteInserOrUpdateOrDeleteQuery(string sQuery);

        void ExecuteInserOrUpdateOrDeleteQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery);
    }
}
