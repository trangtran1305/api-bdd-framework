using AtlantaApi.StepDefinition.ReferenceDataService;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AtlantaApi.StepDefinition.QuoteService.Quotes.V0
{
    [Binding]
    public class QuoteSingleFieldDataValidationCasesSteps
    {
        private string _message, _url, _resourcePath, _jsonFileName, _context;
        private int _statusCode;
        SpecflowHelper _specflowHelper = new SpecflowHelper();

        [Given(@"The customer has")]
        public void GivenTheCustomerHas(Table urlTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(urlTable);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(paramValues["ApiVersion"], paramValues["Context"]);
            _resourcePath = serviceInfoAndContext.Item2.Quotes;
            _context = serviceInfoAndContext.Item3;
            var endpoint = paramValues["Url"];
            if (endpoint.Equals("QuoteApi"))
            {
                _url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Quotes);
            }
            else if (endpoint.Equals("PartialQuote"))
            {
                _url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.StorePartialQuote);
            }
            _jsonFileName = paramValues["JsonBodyFile"];
        }

        [When(@"The customer call quote API")]
        public void WhenTheCustomerCallQuoteAPI(Table table)
        {
            var authorization = Common.GetToken();
            var jsonPath = _resourcePath + _jsonFileName;
            var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonPath);
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = QuoteApiHelper.CreateKeyList(fieldMapping);
            string value = fieldMapping.Value;
            var jobject = JObject.Parse(jsonBody);
            if (value.Contains("File: "))
            {
                jobject = QuoteApiHelper.AddJsonToBody(jobject, fieldNames, value, _resourcePath);
            }
            else
            {
                JsonHelper.EditValue(jobject, fieldNames, value);
            }
            jsonBody = JsonConvert.SerializeObject(jobject);
            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(_context, authorization);
            var quoteResponse = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            _statusCode = (int)quoteResponse.Item2;
            _message = ResponseUtils.GetResponseMessage(quoteResponse);
            if (String.IsNullOrEmpty(_message))
            {
                _message = quoteResponse.Item2.ToString();
            }
        }

        [When(@"The customer call quote validation with (.*) and (.*)")]
        public void WhenTheCustomerCallQuoteAPIValidation(string path, string value)
        {
            var authorization = Common.GetToken();
            var jsonPath = _resourcePath + _jsonFileName;
            var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonPath);
            //var paramValues = SpecflowHelper.TableToDictionary(table);
            //string path = paramValues["Path"];
            //string value = paramValues["Value"];
            //FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            List<string> fieldNames = path.Split(".").ToList();
            var jobject = JObject.Parse(jsonBody);
            if (value.Contains("File: "))
            {
                jobject = QuoteApiHelper.AddJsonToBody(jobject, fieldNames, value, _resourcePath);
            }
            else
            {
                JsonHelper.EditValue(jobject, fieldNames, value);
            }
            jsonBody = JsonConvert.SerializeObject(jobject);
            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(_context, authorization);
            var quoteResponse = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            _statusCode = (int)quoteResponse.Item2;
            _message = ResponseUtils.GetResponseMessage(quoteResponse);
            if (String.IsNullOrEmpty(_message))
            {
                _message = quoteResponse.Item2.ToString();
            }
        }

        [When(@"The customer call quote validation with (.*)")]
        public void WhenTheCustomerCallQuoteAPIValidationExcel(string fileName)
        {
            var filePath = _resourcePath + fileName;
            var path = FileUtils.GetPayLoadSource(filePath);

            var referenceDataHelper = new ReferenceDataHelper();
            List<string> lstSheetName = new List<string>();
            lstSheetName = referenceDataHelper.GetSheetsName(path);
            if (lstSheetName.Count == 0)
            {
                Assert.Equal("File is valid and Property Copy to Output Directory is Copy always", "Data file is invalid, please check properties and existance of file!");
            }
            else
            {
                int _diff = 0;
                string testResultFilePath = path.Replace(".xlsx", "TestResult") + (".xlsx");
                var fileInfo = new FileInfo(testResultFilePath);
                if (fileInfo.Exists)
                    fileInfo.Delete();
                for (int i = 0; i < lstSheetName.Count; i++)
                {
                    List<QuoteValidationData> lstItems = new List<QuoteValidationData>();
                    var lstDataExcel = QuoteApiHelper.GetDataFromExcelFile(path, lstSheetName[i]);

                    for (int j = 0; j < lstDataExcel.Count; j++)
                    {
                        //string jsonPath = lstDataExcel[j].Path.ToLower();
                        string jsonPath = lstDataExcel[j].Path;
                        string value = lstDataExcel[j].Value;
                        string expectedMsg = lstDataExcel[j].ExpectedMessage.Trim();
                        string expectedStt = lstDataExcel[j].ExpectedStatusCode;
                        QuoteValidationData testcase = new QuoteValidationData();
                        testcase.TestcaseId = lstDataExcel[j].TestcaseId;
                        //testcase.Path = jsonPath.ToLower();
                        testcase.Path = jsonPath;
                        testcase.BugID = lstDataExcel[j].BugID;


                        List<string> fieldNames = jsonPath.Split(".").ToList();
                        if (!String.IsNullOrEmpty(testcase.Path))
                        {
                            if(String.IsNullOrEmpty(testcase.BugID))
                            {
                                expectedMsg = expectedMsg.Replace("[Field name]", fieldNames.Last())
                                    .Replace("[fieldname]", fieldNames.Last()).Replace("[field name]", fieldNames.Last()).ToLower()
                                    .Replace(".", "");
                                testcase.ExpectedMessage = expectedMsg;
                                testcase.ExpectedStatusCode = expectedStt;

                                var authorization = Common.GetToken();
                                var jsonFilePath = _resourcePath + _jsonFileName;
                                //var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonFilePath).ToLower();
                                var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonFilePath);

                                var jobject = JObject.Parse(jsonBody);
                                Boolean isPathValid = true;
                                if (value.Equals("future"))
                                {
                                    value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                                }
                                testcase.Value = value;
                                if (value.Contains("File: "))
                                {
                                    jobject = QuoteApiHelper.GetJsonBody(jobject, fieldNames, value, _resourcePath);
                                }
                                else
                                {
                                    isPathValid = JsonHelper.EditValueValidation(jobject, fieldNames, value);
                                }
                                if (isPathValid)
                                {
                                    jsonBody = JsonConvert.SerializeObject(jobject);
                                    var requestUtils = new RequestUtils();
                                    var header = requestUtils.GetHeader(_context, authorization);
                                    var quoteResponse = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
                                    var actualStatusCode = (int)quoteResponse.Item2;
                                    var actualMessage = ResponseUtils.GetResponseMessage(quoteResponse).ToLower().Replace(".", "").Trim();
                                    testcase.ActualStatusCode = actualStatusCode.ToString();
                                    testcase.ActualMessage = actualMessage;
                                    if (actualMessage == expectedMsg && actualStatusCode.ToString() == expectedStt)
                                    {
                                        testcase.Result = "Passed";
                                    }
                                    else
                                    {
                                        testcase.Result = "Failed";
                                        _diff++;
                                    }
                                }
                                else
                                {
                                    testcase.Result = "Failed: Json Path does not exist in quote body";
                                    _diff++;
                                }
                            }  
                            else
                            {
                                testcase.Result = "Please check bug on Jira by BugID";
                            }

                            lstItems.Add(testcase);
                        }
                    }
                    QuoteApiHelper.ExportDataToExcelFile(lstItems, testResultFilePath, lstSheetName[i]);
                }// end of a sheet

                Assert.Equal(0, _diff);
            }
        }


        [Then(@"The message should be shown (.*),(.*),""(.*)""")]
        public void ThenTheMessageShouldBeShown(int statusCode, string isSuccess, string expectedMessage)
        {
            expectedMessage = expectedMessage.Replace(".", "").Replace(",", "").Replace(" ", "").Replace(" ", "").ToLower();
            _message = _message.Replace(".", "").Replace(",", "").Replace(" ", "").ToLower();
            //expectedMessage = Common.FormatString(expectedMessage);
            //_message = Common.FormatString(_message);
            bool isTrue = _message.Contains(expectedMessage);
            Assert.Equal(statusCode, _statusCode);
            Assert.Contains(expectedMessage, _message);
            Thread.Sleep(100);
        }

        [Then(@"The Quote response should be shown (.*),(.*),(.*)")]
        public void ThenTheQuoteShouldBeShown(int statusCode, string isSuccess, string expectedMessage)
        {
            expectedMessage = expectedMessage.Replace(".", "").Replace(",", "").ToLower();
            _message = _message.Replace(".", "").Replace(",", "").ToLower();
            expectedMessage = Common.FormatString(expectedMessage);
            _message = Common.FormatString(_message);

            Assert.Equal(expectedMessage, _message);
            Assert.Equal(statusCode, _statusCode);
            //By pass the limited 100 request per second
            Thread.Sleep(100);
        }
        [When(@"The customer call quote API normal case")]
        public void WhenTheCustomerCallQuoteAPINormalCase()
        {
            var authorization = Common.GetToken();
            var jsonPath = _resourcePath + _jsonFileName;
            var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonPath);
            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(_context, authorization);
            var quoteResponse = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);

            _statusCode = (int)quoteResponse.Item2;
            _message = ResponseUtils.GetResponseMessage(quoteResponse);
            if (String.IsNullOrEmpty(_message))
            {
                _message = quoteResponse.Item2.ToString();
            }
        }

        [When(@"The customer call quote API validate (.*) and (.*)")]
        public void WhenTheCustomerCallQuoteAPIInvalidEndpointOrMethod(string endpoint, string method)
        {
            var authorization = Common.GetToken();
            var jsonPath = _resourcePath + _jsonFileName;
            var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonPath);
            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(_context, authorization);
            _url = _specflowHelper.GetUrlByString(endpoint);
            var quoteResponse = requestUtils.SendRequest(method, _url, jsonBody, header);
            _statusCode = (int)quoteResponse.Item2;
            if (_statusCode == 400)
            {
                _message = ResponseUtils.GetResponseMessage(quoteResponse);
            }
            else
                _message = quoteResponse.Item2.ToString();
        }

        [When(@"The customer call quote API missing context")]
        public void WhenTheCustomerCallQuoteAPIMissingContext()
        {
            var authorization = Common.GetToken();
            var jsonPath = _resourcePath + _jsonFileName;
            var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonPath);
            var requestUtils = new RequestUtils();
            var header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json");
            header.Add("Authorization", authorization);
            var quoteResponse = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            _statusCode = (int)quoteResponse.Item2;
            _message = ResponseUtils.GetResponseMessage(quoteResponse);
            if (String.IsNullOrEmpty(_message))
            {
                _message = quoteResponse.Item2.ToString();
            }
        }
    }
}
