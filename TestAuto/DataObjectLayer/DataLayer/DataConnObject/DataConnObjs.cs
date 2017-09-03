using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.DataLayer.DataConnObject
{
    public class DataConnObjs
    {
        public string DBServer;
        public string DBName;
        public string UserName;
        public string Pass;

        //public DataConnObjs setAutoDBobj()
        //{
        //    this.DBServer = (string)ConfigurationManager.AppSettings["AutoDBServe"];
        //    this.DBName = (string)ConfigurationManager.AppSettings["AutoDBName"];
        //    this.UserName = (string)ConfigurationManager.AppSettings["AutoDBUser"];
        //    this.Pass = (string)ConfigurationManager.AppSettings["AutoDBPass"];
        //    return this;
        //}

        public DataConnObjs setNTeractDB()
        {
            this.DBServer = (string)ConfigurationManager.AppSettings["nteractDbserv"];
            this.DBName = (string)ConfigurationManager.AppSettings["nteractDbname"];
            this.UserName = (string)ConfigurationManager.AppSettings["dbuserid"];
            this.Pass = (string)ConfigurationManager.AppSettings["dbpassword"];
            return this;
        }

        public DataConnObjs setSysBD(string server)
        {
            this.DBServer = server;//(string)ConfigurationManager.AppSettings["dbserver"];
            this.DBName = (string)ConfigurationManager.AppSettings["dbname"];
            this.UserName = (string)ConfigurationManager.AppSettings["dbuserid"];
            this.Pass = (string)ConfigurationManager.AppSettings["dbpassword"];
            return this;
        }

        //public class AutoDBOb :DataConnObjs
        //{
           
        //}

        //public class NTeractDB : DataConnObjs
        //{

        //}

        //public class SysDB : DataConnObjs
        //{

        //}



  





    }
}
