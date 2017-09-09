using System;
 

namespace TestAutomation.ObjectLocators
{
    /// <summary>
    /// Object Locator interface
    /// </summary>
    public interface IObjectLocator
    {
        /// <summary>
        /// Getting the identifier
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetIdentifier(string key);
        /// <summary>
        /// Setting an Identifier
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetIdentifier(string key, string value);

    }
}
