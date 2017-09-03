using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.Framework;
 

namespace TestAutomation.TestUtils
{
    [TestClass]
    public class SetUp
    {
        
        public SetUp() { }

       
        public TestContext TestContext { get; set; }
        

        [AssemblyInitialize]
        public static void SetupIntegrationTests(TestContext context)
        {            
            TestBase.InitiateAssembly(context); 
        }

        [AssemblyCleanup]
        public static void TeardownIntegrationTests()
       { 
            TestBase.CleanupAssembly();
        }

        [TestMethod]
        [DeploymentItem("log4net.config")]            
        [DeploymentItem("TestData\\", "TestData\\")]         
        [DeploymentItem("IEDriverServer.exe")]
        [DeploymentItem("chromedriver.exe")]
        [TestCategory("Smoke"), TestCategory("Regression"), TestCategory("Insprint")]
        public void BaseTest()
        {

            
            //This method is required to add the above deployment Items. This feature enables the tests to be run from command line.
            // Any new category created should be added to this test.

        }

    }
}
