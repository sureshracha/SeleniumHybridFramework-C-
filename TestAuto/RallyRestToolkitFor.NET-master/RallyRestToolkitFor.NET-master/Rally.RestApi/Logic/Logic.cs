using Rally.RestApi.Json;
using Rally.RestApi.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.RestApi.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class Logic
    {
        RallyRestApi restApi = new RallyRestApi();
        /// <summary>
        /// 
        /// </summary>
        public string APIKey = ConfigurationManager.AppSettings["RallyApiKey"].ToString();
        /// <summary>
        /// 
        /// </summary>
        public string RallyServer = ConfigurationManager.AppSettings["RallyServer"].ToString();
        /// <summary>
        /// 
        /// </summary>
        public Logic()
        {
            restApi.AuthenticateWithApiKey(APIKey, RallyServer);
        }
       
        /// <summary>
        /// Gets the ref id for a test case
        /// </summary>
        /// <param name="testCaseId"></param>
        /// <returns></returns>
        public string GetTestCaseFormattedId(string testCaseId)
        {
            var tcRefId = string.Empty;
            try
            {
                Request testCase = new Request("TestCase");
                testCase.Fetch = new List<string> { "Name", "FormattedID" };
                testCase.Query = new Query("FormattedID", Query.Operator.Equals, testCaseId);
                QueryResult tcResult = restApi.Query(testCase);
                if (tcResult.TotalResultCount == 1)
                {
                    DynamicJsonObject obj = tcResult.Results.FirstOrDefault();
                    var str = obj.ToDictionary();
                    tcRefId = str["_ref"].ToString().Replace(restApi.WebServiceUrl + "/testcase/", "");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tcRefId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TestCaseId"></param>
        /// <param name="Build"></param>
        /// <param name="Verdict"></param>
        /// <param name="Notes"></param>
        public bool CreateTestCaseResults(string TestCaseId, string Build, string Verdict, string Notes)
        {
            try
            {
                DynamicJsonObject createTCResults = new DynamicJsonObject();
                createTCResults["Date"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                createTCResults["TestCase"] = "/testcase/" + GetTestCaseFormattedId(TestCaseId);
                createTCResults["Notes"] = Notes;
                createTCResults["Build"] = Build;
                createTCResults["Verdict"] = ParseVerdict(Verdict);
                CreateResult cr = restApi.Create("TestCaseResults", createTCResults);
                return cr.Success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Parses test outcome to return value used by rally
        /// 
        /// </summary>
        /// <param name="TestOutCome"></param>
        /// <returns></returns>
        public string ParseVerdict(string TestOutCome)
        {
            var parsedVerdict = string.Empty;
            switch (TestOutCome.ToLower())
            {
                case "passed":
                    parsedVerdict= "Pass";
                    break;
                case null:
                case "failed":
                    parsedVerdict = "Fail";
                    break;
                case "inconclusive":
                    parsedVerdict = "Inconclusive";
                    break;
                case "error":
                    parsedVerdict = "Error";
                    break;

            }
            return parsedVerdict;
        }

    }
}
