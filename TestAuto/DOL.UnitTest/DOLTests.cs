using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Repository;
using NUnit.Framework;
using DataObjectLayer.BuisnessObjects;
using OptumAutomationFramework.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptumAutomationFramework.Reportings;
using System.Xml;

namespace DOL.UnitTest
{
    [TestClass]
    public class DOLTests
    {
        [TestMethod]
        public void DBTest()
        {
            try
            {
                RepositoryBase repo = new RepositoryBase();
                var DBObjs = new DataObjects();
                DBObjs.SetBoDataObject();
            }
            catch (Exception ex)
            {
            }
        }


        [TestMethod]
        public void GetFeatureTest()
        {
            RepositoryBase repo = new RepositoryBase();
            FeaturesRepo frepo = new FeaturesRepo();
            var feature = frepo.GetFeature("adjustment");

        }


        [TestMethod]
        public void XMLoggerTest()
        {
            var logger = new XMLogger();
            logger.MachineName = Environment.MachineName;
            logger.PassFail = "Pass";
            logger.TestCaseId = "TC14725";
           // logger.TestUserStory = "US123456";
            logger.TimeElapse = "10:30";
            logger.Environment = "Regression";
            logger.Feature = "Test Feature";
            logger.CreateXMLDoc();
            

            logger.CreateStepElement("SmokeTest");
            logger.CreateStepChildElement("This is a test ", "SmokeTest");
            logger.CreateStepChildElement("Another Test", "SmokeTest");

           var tt = logger.xdoc.OuterXml;
        }


        [TestMethod]
        public void AutoResultsTest()
        {
            var repo = new EFRAutoResultsRepo();
           var lst = repo.GetAutomationResults(6, null, null);
            NUnit.Framework.Assert.IsNotNull(lst);
        }

        [TestMethod]
        public void AutoResultsDateParmsTest()
        {
            var repo = new EFRAutoResultsRepo();
            var lst = repo.GetAutomationResults(6, DateTime.Parse("2017-07-31 12:26:21.000"), DateTime.Parse("2017-08-16 08:56:48.000"));
            NUnit.Framework.Assert.IsNotNull(lst);
        }

    }
}
