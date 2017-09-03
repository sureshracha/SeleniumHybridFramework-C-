
using DataObjectLayer.BuisnessObjects;
using TestAutomation.DataLayer.DataDriver;
using TestAutomation.DataLayer.DataReaders;
using TestAutomation.DataLayer.Interfaces;

namespace efrAutomation.DataLayer
{

    public class CommonSqlStmts
    {
        IDbDataReader reader = new DbDataReader();
        private IDataDriver driver;
        Environment env = new Environment();
        public CommonSqlStmts()
        {
            
            reader = new DbDataReader( env.connectionstring);
            driver = new DataDriver();
        }

        public string GetCustomLabelName(string fieldlabelname)
        {
            string squery = $"select empname from emptable where empid = '{fieldlabelname}'";
            driver.ReadDataFromDb(squery);
            return driver.GetColumnValue("empname");

        }

        public IDataDriver GetDriver()
        {
            return driver;
        }


        


    }

     


}
