using OpenQA.Selenium;
using System;
using System.Data;
using TestAutomation.Framework;

namespace TestAutomation.TestUtils
{
    public class CommonUtils:TestBase
    {
         

       
        private readonly string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

        public CommonUtils()
        {
            
        }
        
        public string getexcelTestDataFilePath(string fileName)
        {
            string filePath = baseDir + @"\\TestData\\Excel_Sheet\\" + fileName;
            return filePath;
        }

        public string getResourceTestDataFilePath(string fileName)
        {
            string filePath = baseDir + @"\\TestData\\Resource_Files\\" + fileName;
            return filePath;
        }
               

    }

   
}
