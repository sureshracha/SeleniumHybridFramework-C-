using DataObjectLayer.DataLayer.DataConnObject;
using DataObjectLayer.BuisnessObjects.Entites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.DataLayer
{
   public  class DBDataReader: IDBDataReader
    {
        private readonly SqlConnection conn = new SqlConnection();
        private  DataTable table = new DataTable();
        private string ServerName;
        private string DatabaseName;
        private string UserId;
        private string Password;


        public DBDataReader(Environments env)
        {
            this.conn.ConnectionString = env.connectionString;
            //table = new DataTable();
        }


        /// <summary>
        /// Setting the DB connection details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/>
        //public void SetDbDetails(string ServerName, string DatabaseName, string UserId, string Password)
        //{
        //    this.ServerName = ServerName;
        //    this.DatabaseName = DatabaseName;
        //    this.UserId = UserId;
        //    this.Password = Password;
        //    string[] strArray = new string[9];
        //    int index1 = 0;
        //    string str1 = "Server=";
        //    strArray[index1] = str1;
        //    int index2 = 1;
        //    string str2 = ((object)this.ServerName.Trim()).ToString();
        //    strArray[index2] = str2;
        //    int index3 = 2;
        //    string str3 = ";DataBase=";
        //    strArray[index3] = str3;
        //    int index4 = 3;
        //    string str4 = ((object)this.DatabaseName.Trim()).ToString();
        //    strArray[index4] = str4;
        //    int index5 = 4;
        //    string str5 = ";Trusted_Connection=no;User ID=";
        //    strArray[index5] = str5;
        //    int index6 = 5;
        //    string str6 = ((object)this.UserId.Trim()).ToString();
        //    strArray[index6] = str6;
        //    int index7 = 6;
        //    string str7 = ";Password=";
        //    strArray[index7] = str7;
        //    int index8 = 7;
        //    string str8 = ((object)this.Password.Trim()).ToString();
        //    strArray[index8] = str8;
        //    int index9 = 8;
        //    string str9 = ";";
        //    strArray[index9] = str9;
        //    this.conn.ConnectionString = string.Concat(strArray);
        //}

        /// <summary>
        /// setting db connection detsils from app config
        /// 
        /// </summary>




        /// <summary>
        /// Executing the Select query
        /// 
        /// </summary>
        /// <param name="sQuery"/>
        /// <returns/>
        public DataTable ExecuteSelectQuery( string sQuery)
        {
            //this.SetDbDetails(this.conn.ConnectionString);
            this.RunQuery(sQuery, "select");
            return this.table;
        }

        /// <summary>
        /// Running all the queries..
        /// 
        /// </summary>
        /// <param name="sQuery"/><param name="isInsDelUpd"/>
        private void RunQuery(string sQuery, string isInsDelUpd)
        {
            SqlDataReader sqlDataReader = (SqlDataReader)null;
            try
            {
                this.table = new DataTable();
                this.conn.Open();
                sqlDataReader = new SqlCommand(sQuery, this.conn).ExecuteReader();
                if (!isInsDelUpd.Trim().Equals("select"))
                    return;
                for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
                    this.table.Columns.Add(new DataColumn(((object)sqlDataReader.GetName(ordinal).Trim()).ToString(), typeof(string))
                    {
                        DefaultValue = (object)string.Empty
                    });
                while (sqlDataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
                        row[sqlDataReader.GetName(ordinal)] = sqlDataReader[ordinal];
                    this.table.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                if (this.conn != null)
                    this.conn.Close();
            }
        }

        /// <summary>
        /// Execute Insert of Update or Delete a DB Query
        /// 
        /// </summary>
        /// <param name="sQuery"/>
        public void ExecuteInserOrUpdateOrDeleteQuery(string sQuery)
        {
            //this.SetDbDetails();
            this.RunQuery(sQuery, "insert");
        }

        /// <summary>
        /// Executing the Select query with db details and user details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/>
        /// <returns/>
        public DataTable ExecuteSelectQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
           // this.SetDbDetails(ServerName, DatabaseName, UserId, Password);
            this.RunQuery(sQuery, "select");
            return this.table;
        }

        /// <summary>
        /// Executing the Select query with db details and user details with db details and user details
        /// 
        /// </summary>
        /// <param name="ServerName"/><param name="DatabaseName"/><param name="UserId"/><param name="Password"/><param name="sQuery"/>
        public void ExecuteInserOrUpdateOrDeleteQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            //this.SetDbDetails(ServerName, DatabaseName, UserId, Password);
            this.RunQuery(sQuery, "insert");
        }
    }
}
