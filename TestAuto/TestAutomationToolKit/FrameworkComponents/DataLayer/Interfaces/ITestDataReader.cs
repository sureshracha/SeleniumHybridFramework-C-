using System;
using System.Collections.Generic;
 

namespace TestAutomation.Locators.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestDataReader
    {

         /// <summary>
         /// 
         /// </summary>
         /// <param name="columnName"></param>
         /// <returns></returns>
        String GetDataAsString(String columnName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowName"></param>
        /// <returns></returns>
        String GetDataAsString(String columnName, String rowName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        List<String> GetDataAsList(String columnName);

    }
}
