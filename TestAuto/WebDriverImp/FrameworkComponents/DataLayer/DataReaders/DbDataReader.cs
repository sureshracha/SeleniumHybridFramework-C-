using System.Data;

using TestAutomation.DataLayer.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace TestAutomation.DataLayer.DataReaders
{
    /// <summary>
    /// DB Data Reader
    /// </summary>
    public class DbDataReader : IDbDataReader 
    {
        private string ServerName,DatabaseName,UserId,Password;
        readonly private SqlConnection conn = new SqlConnection();
        readonly private DataTable table = new DataTable();

        public DbDataReader(string connectionString)
        {
            this.conn.ConnectionString =  connectionString;
        }

        public DbDataReader()
        {
            
        }

        /// <summary>
        /// Setting the DB connection details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        public void SetDbDetails(string ServerName,string DatabaseName,string UserId,string Password)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.UserId = UserId;
            this.Password = Password;
            string connstring;
            
            connstring = "Server=" + this.ServerName.Trim().ToString() + ";DataBase=" + this.DatabaseName.Trim().ToString() + ";Trusted_Connection=no;USer ID=" + this.UserId.Trim().ToString() + ";Password=" + this.Password.Trim().ToString() + ";";
            conn.ConnectionString = connstring;

        }
        /// <summary>
        /// setting db connection detsils from app config
        /// </summary>
        public void SetDbDetails()
        {
            this.ServerName = ConfigurationManager.AppSettings["dbserver"].ToString().Trim();
            this.DatabaseName = ConfigurationManager.AppSettings["dbname"].ToString().Trim(); 
            this.UserId = ConfigurationManager.AppSettings["dbuserid"].ToString().Trim(); 
            this.Password = ConfigurationManager.AppSettings["dbpassword"].ToString().Trim(); 

            string connstring;

            
            connstring = "Server=" + this.ServerName.Trim().ToString() + ";DataBase=" + this.DatabaseName.Trim().ToString() + ";Trusted_Connection=no;USer ID=" + this.UserId.Trim().ToString() + ";Password=" + this.Password.Trim().ToString() ;
            this.conn.ConnectionString = connstring;

        }
        /// <summary>
        /// Executing the Select query
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        public DataTable ExecuteSelectQuery(string sQuery)
        {
            SetDbDetails();
            RunQuery(sQuery,"select");
            return table;
        }
        /// <summary>
        /// Running all the queries..
        /// </summary>
        /// <param name="sQuery"></param>
        /// <param name="isInsDelUpd"></param>
        private  void  RunQuery(string sQuery,string isInsDelUpd)
        {
            SqlDataReader rdr = null;
            try
            {
                // 2. Open the connection
                this.conn.Open();

                SqlCommand cmd = new SqlCommand(sQuery, this.conn);
                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();
                if (isInsDelUpd.Trim().Equals("select"))
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        DataColumn oDataColumn = new DataColumn(rdr.GetName(i).Trim().ToString(), typeof(string));
                        //setting the default value of empty.string to newly created column
                        oDataColumn.DefaultValue = string.Empty;

                        //adding the newly created column to the table
                        table.Columns.Add(oDataColumn);
                    }

                    while (rdr.Read())
                    {
                        DataRow oDataRow = table.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            oDataRow[rdr.GetName(i)] = rdr[i];

                        }

                        table.Rows.Add(oDataRow);
                    }
                }
            }
            catch(System.Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
                
            }
        }
 

       /// <summary>
       /// Execute Insert of Update or Delete a DB Query
       /// </summary>
       /// <param name="sQuery"></param>
        public void ExecuteInserOrUpdateOrDeleteQuery(string sQuery)
        {
            SetDbDetails();
            RunQuery(sQuery,"insert");
        }
        /// <summary>
        /// Executing the Select query with db details and user details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        public DataTable ExecuteSelectQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            SetDbDetails(ServerName, DatabaseName, UserId, Password);
            RunQuery(sQuery,"select");
            return table;

        }
        /// <summary>
        /// Executing the Select query with db details and user details with db details and user details
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="sQuery"></param>
        public void ExecuteInserOrUpdateOrDeleteQuery(string ServerName, string DatabaseName, string UserId, string Password, string sQuery)
        {
            SetDbDetails(ServerName, DatabaseName, UserId, Password);
            RunQuery(sQuery,"insert");

        }
 



    }
}
