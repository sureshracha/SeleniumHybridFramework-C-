

namespace TestAutomation.ObjectLocators
{
    /// <summary>
    /// Object locator reader
    /// </summary>
    public interface IObjectLocatorReader
    {
        /// <summary>
        /// Getting the locator by sending the filename and element to find
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="elementToFind"></param>
        /// <returns></returns>
        IObjectLocator GetLocator(string fileName, string elementToFind);
    }
}
