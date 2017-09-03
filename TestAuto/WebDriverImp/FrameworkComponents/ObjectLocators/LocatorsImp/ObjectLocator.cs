using System.Collections;

namespace TestAutomation.ObjectLocators
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectLocator : IObjectLocator
    {
        
        private Hashtable identifiersTable;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifiersTable"></param>
        public ObjectLocator(Hashtable identifiersTable)
        {
            this.identifiersTable = identifiersTable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetIdentifier(string key)
        {
            return identifiersTable[key].ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetIdentifier(string key, string value)
        {
            identifiersTable[key]= value;
        }
    }
}
