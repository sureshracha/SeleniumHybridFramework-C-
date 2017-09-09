 

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.Reporting; 
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TestAutomation.Utilities;

namespace TestAutomation.Framework
{
    [TestClass]
    public class TestBase
    {
        private static int testCount = 0;
        private static HtmlReporter htmlReport = new HtmlReporter();
        private static string className_ = "";
         
        private Stopwatch per = new Stopwatch();
        private static string pkgName;
        private static string className;
        
        public static Logger logger;       
        
        
        private static MailReporter mailReporter;
        private static bool mailEnabled;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void InitiateAssembly(TestContext context)
        {
            TestBase.pkgName = context.FullyQualifiedTestClassName.Split('.')[0];
            if (TestBase.pkgName.Equals("TestAutomation"))
                return;
            string machineName = Environment.MachineName;
            string path = "C:\\\\TestResults";
            try
            {
                Directory.Delete(path, true);
                Console.WriteLine("Deleting existing TestResults directory and its contents");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Directory Found to Delete [Exception Message : " + ex.Message+ "]");
            }
            Directory.CreateDirectory(path + "\\\\Logs");
            string str = path + "\\\\Logs\\\\TestRunLog.html";
            TestBase.logger = new Logger(true);
            TestBase.logger.Info((object)"#############################################################");
            TestBase.logger.Info((object)"##################### Test Run Execution Started ######################");
            TestBase.logger.Info((object)"#############################################################");
            TestBase.htmlReport.initializeReport(TestBase.pkgName, Directory.GetCurrentDirectory().ToString());
            
            
            
            
        }

        [AssemblyCleanup]
        public static void CleanupAssembly()
        {
            if (TestBase.pkgName.Equals("OptumAutomationFramework"))
                return;
            TestBase.logger.Info((object)"#############################################################");
            TestBase.logger.Info((object)"##################### Test Run Execution Ends ########################");
            TestBase.logger.Info((object)"#############################################################");
            TestBase.htmlReport.concludeReport(TestBase.testCount);
            try
            {
                TestBase.mailEnabled = ConfigurationManager.AppSettings["MailReporting"].Equals("ON");
            }
            catch (Exception ex)
            {
                TestBase.mailEnabled = false;
                Console.WriteLine("[Exception Message : " + ex.Message + "]");
            }
            if (TestBase.mailEnabled)
            {
                TestBase.mailReporter = new MailReporter();
                
            }
            string str = "C:\\TestResults_History\\" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            string sourceDirName = "C:\\TestResults";
            Directory.CreateDirectory(str);
            DirActions.DirectoryCopy(sourceDirName, str, true);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            string testName = this.TestContext.TestName;
            TestBase.logger.Info((object)("<a name=\"" + testName + "\">****** Executing Test Case : " + testName + " *******"));
            this.per.Start();
            checked { ++TestBase.testCount; }
            
            TestBase.className = this.TestContext.FullyQualifiedTestClassName;
            if (!TestBase.className.Equals(TestBase.className_))
            {
                TestBase.className_ = TestBase.className;
                
            }
        }

        [TestCleanup]
        public void CleanupTest()
        {
            this.per.Stop();
            string timeElapsed = (string)(object)this.per.Elapsed.Hours + (object)":" + (string)(object)this.per.Elapsed.Minutes + ":" + (string)(object)this.per.Elapsed.Seconds;
            TestBase.logger.Info((object)("****** End of Test Case : " + this.TestContext.TestName + " *******"));
            this.per.Reset();
            string testStatus = ((object)this.TestContext.CurrentTestOutcome).ToString();
            if (testStatus.Equals("InProgress"))
                Thread.Sleep(5000);
            TestBase.htmlReport.updateReport(this.TestContext, timeElapsed);
            
            if (this.TestContext.CurrentTestOutcome != UnitTestOutcome.Failed)
                return;
            this.TestContext.AddResultFile(TestBase.logger.CaptureScreen());
        }

        public void InitializeScenario(string featureName, string testName)
        {
            TestBase.logger.Info((object)("<a name=\"" + testName + "\">****** Executing Test Scenario : " + testName + " *******"));
            this.per.Start();
            checked { ++TestBase.testCount; }
            
            TestBase.className = featureName;
            if (!TestBase.className.Equals(TestBase.className_))
            {
                TestBase.className_ = TestBase.className;
                
            }
        }

        public void CleanupScenario(string featureName, string testName, string status, string testId)
        {
            this.per.Stop();
            string timeElapsed = (string)(object)this.per.Elapsed.Hours + (object)":" + (string)(object)this.per.Elapsed.Minutes + ":" + (string)(object)this.per.Elapsed.Seconds;
            TestBase.logger.Info((object)("****** End of Test Scenario : " + testName + " *******"));
            this.per.Reset();
            TestBase.htmlReport.updateReportForScenario(status, featureName, testName, timeElapsed);
            string testStatus = status;
             
            
        }
    }
}
