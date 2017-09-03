using System.Configuration;

namespace TestAutomation.DataLayer.DataConnObject
{
    public class DataConnObjs
    {
        public string DBServer;
        public string DBName;
        public string UserName;
        public string Pass;      
         

        public DataConnObjs setSysBD(string server)
        {
            this.DBServer = server;//(string)ConfigurationManager.AppSettings["dbserver"];
            this.DBName = (string)ConfigurationManager.AppSettings["dbname"];
            this.UserName = (string)ConfigurationManager.AppSettings["dbuserid"];
            this.Pass = (string)ConfigurationManager.AppSettings["dbpassword"];
            return this;
        }

    }
}
