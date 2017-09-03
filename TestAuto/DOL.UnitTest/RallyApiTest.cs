using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rally.RestApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Rally.RestApi.Json;
using Rally.RestApi.Response;
using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Rally.RestApi.Logic;
using System.Globalization;

namespace DOL.UnitTest
{
    [TestClass]
   public class RallyApiTest
    {
        string username = "jonik.cannon@optum.com";
        string password = "Tigers83";
        string serverURL = "https://rally1.rallydev.com/#/50544389240d";
        [TestMethod]
        public void RallyTest()
        {
            RallyRestApi restApi = new RallyRestApi();

           /* restApi.WsapiVersion = "v1.6"*/;
            restApi.AuthenticateWithApiKey("_ohEzikAMTceyleYUnqi8Sxon5kFNYk1SgvunNdLoE", "https://rally1.rallydev.com/slm/webservice/v2.0/security/authorize");

           // restApi.Authenticate(username, password, serverURL,null,false);
            DynamicJsonObject toCreate = new DynamicJsonObject();
            //toCreate["Name"] = "Automaiton Test";
            //CreateResult createResults = restApi.Create("defect", toCreate);


            //Request workspacRequest = new Request("WorkSpace");
            //workspacRequest.Query = new Query("");
            //QueryResult workspaceResults = restApi.Query(workspacRequest);

            //var workspace = workspaceResults.Results.FirstOrDefault();

            toCreate["Date"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            toCreate["TestCase"] = "/testcase/122874377132";
            toCreate["Notes"] = "This is a test";
            toCreate["Build"] = "7.1.1";
            toCreate["Verdict"] = "Pass";
            
            CreateResult cr = restApi.Create("TestCaseResult", toCreate);
        }

        [TestMethod]
        public void QueryTestCase()
        {
            RallyRestApi restApi = new RallyRestApi();

            restApi.AuthenticateWithApiKey("_ohEzikAMTceyleYUnqi8Sxon5kFNYk1SgvunNdLoE", "https://rally1.rallydev.com/");
            // DynamicJsonObject qryTestCase = new DynamicJsonObject();
           // restApi.WebServiceUrl = "https://rally1.rallydev.com/slm/webservice/v2.0/";
            Request testCase = new Request("TestCase");
            testCase.Fetch = new List<string> { "Name","FormattedID" };

           
            testCase.Query = new Query("FormattedID", Query.Operator.Equals, "TC14725");
            QueryResult tcResult = restApi.Query(testCase);
            //var id = tcResult.Results.FirstOrDefault();
            DynamicJsonObject obj = tcResult.Results.FirstOrDefault();
            var str = obj.ToDictionary();

            var id =str["_ref"].ToString().Replace("https://rally1.rallydev.com/slm/webservice/v2.0/testcase/","");
            //qryTestCase["c_TCExternalID "] = "TC14725";
            //CreateResult cr = restApi.Query()



        }

        [TestMethod]
        public void RallyLogicTest()
        {
            Logic rallyLogic = new Logic();
           string refId = rallyLogic.GetTestCaseFormattedId("TC14725");
            rallyLogic.CreateTestCaseResults(refId, "testbuild", "Pass", "This is a test for the notes");
        }
    }
}
