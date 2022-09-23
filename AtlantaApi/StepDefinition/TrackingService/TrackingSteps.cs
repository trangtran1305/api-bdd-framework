using ANCarClassic.Pages;
using AtlantaApi.StepDefinition.PaymentService;
using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.StepDefinition.QuoteService.Quotes;
using AtlantaApi.StepDefinition.QuoteService.Recall;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using ProjectCore.GUICore.TestProvider;
using ProjectCore.SQL;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AtlantaApi.StepDefinition.TrackingService
{
    [Binding]
    public class TrackingSteps : Steps
    {
        private readonly FluentSqlClient<TrackingModel> _trackingSqlClient;
        private readonly FluentSqlClient<Quote> _quoteSqlClient;
        private static SpecflowHelper _specflowHelper = new SpecflowHelper();

        private readonly DateTime _startDate;
        RequestUtils _requestUtils = new RequestUtils();
        private string _requestBody, _recallRequestBody;
        private string _apiVersion, _contextName;
        string _affinityCode;
        private string _webHookBody, _quoteRequestBody, _registerPaymentRequestBody, _saveMarketingRequestBody, _saveDebitRequestBody, _savePaymentInfoRequestBody;
        private int _actualStatusCode;
        private string _uri, _sessionId = "", _webReference = "", _url, _actualMessages, _schemeCode = "", _paymentMethod;
        Tuple<string, System.Net.HttpStatusCode> _paymentResponse, _webHookResponse;
        Tuple<string, HttpStatusCode> _quoteResponse;
        TrackingFunctions trackingFunc = new TrackingFunctions();

        private List<ResultObject> lstResultObject = new List<ResultObject>();

        public TrackingSteps(ScenarioContext scenarioContext)
        {
            _startDate = DateTime.UtcNow;

            var sqlHelper = new SqlHelper();
            var trackingConnectionString = sqlHelper.GetConnectionString("TrackingDb");
            _trackingSqlClient = new FluentSqlClient<TrackingModel>(new DatabaseConnectionFactory(trackingConnectionString));
            _quoteSqlClient = new FluentSqlClient<Quote>(new DatabaseConnectionFactory(trackingConnectionString));
        }
        [Given(@"User has wrapUp table")]
        public void GivenUserHasPaymentOutcomeRequest(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _registerPaymentRequestBody = paramValues["PaymentRequestBody"];
            _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
            _saveDebitRequestBody = paramValues["SaveDebitRequestBody"];
            _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];
            _webHookBody = paramValues["WebHookBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
            _paymentMethod = paramValues["PaymentMethod"];
            _uri = paramValues["Uri"].Replace("//", "|");
            //Thread.Sleep(3000);

        }

        //[Given(@"User has Quote/PartialQuote body")]
        //public void GivenUserHasARequest(Table table)
        //{
        //    var paramValues = SpecflowHelper.TableToDictionary(table);
        //    _requestBody = paramValues["RequestBody"];
        //    _apiVersion = paramValues["ApiVersion"];
        //    _contextName = paramValues["ContextName"];
        //}
        //[Given(@"User has a Recall body")]
        //public void GivenUserHasRecallRequest(Table table)
        //{
        //    var paramValues = SpecflowHelper.TableToDictionary(table);
        //    _recallRequestBody = paramValues["RecallRequestBody"];
        //}

        //[Given(@"User has payment request body")]
        //public void GivenUserHasReferenceDataRequest(Table table)
        //{
        //    var paramValues = SpecflowHelper.TableToDictionary(table);
        //    _requestBody = paramValues["QuoteRequestBody"];
        //    _registerPaymentRequestBody = paramValues["PaymentRequestBody"];
        //    _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
        //    _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];

        //    _apiVersion = paramValues["ApiVersion"];
        //    _contextName = paramValues["ContextName"];
        //}
        [When(@"User send quote request with affinity (.*)")]
        public void WhenUserSendQuoteRequest(string affinity)
        {
            // send  save payment infor request
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1500);
            _sessionId = lstResultObject[0].SessionId.ToString();
            _webReference = lstResultObject[0].WebReference.ToString();
            _schemeCode = lstResultObject[0].SchemeCode.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            string baseUrl = _specflowHelper.GetBaseUrlFromConfig(_contextName);
            TestBase testBase = new TestBase();

            string url = $"{baseUrl}/aggrecall?pcd=SW8%201TF&brd=01/02/1980&webref={_webReference}&schemecode={_schemeCode}&affinity={affinity}";
            testBase.OpenDeepLink(url);
            testBase.CloseBrowser();
        }

        [When(@"User perform payment with affinity (.*) and (.*)")]
        public void WhenUserSendPaymentRequest(string affinity, string paymentMethod)
        {
            // send  save payment infor request
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1500);
            //_sessionId = lstResultObject[0].SessionId.ToString();
            _webReference = lstResultObject[0].WebReference.ToString();
            _schemeCode = lstResultObject[0].SchemeCode.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            string baseUrl = _specflowHelper.GetBaseUrlFromConfig(_contextName);

            string url = $"{baseUrl}/aggrecall?pcd=SW8%201TF&brd=01/02/1980&webref={_webReference}&schemecode={_schemeCode}&affinity={affinity}";

            TestBase testBase = new TestBase();
            testBase.OpenDeepLink(url);
            QuoteSummaryPage quoteSummaryPage = new QuoteSummaryPage();
            quoteSummaryPage.ClickPaymentMethod(paymentMethod);
            quoteSummaryPage.ClickQuoteSummaryContinue("Yes");
            testBase.WaitForLoadingIconDisappear();

            QuoteReviewPage quoteReviewPage = new QuoteReviewPage();
            quoteReviewPage.ClickAgreeButton("Yes");
            quoteReviewPage.ClickTermConfirmation("Yes");
            quoteReviewPage.ClickQuoteReviewContinue("Yes");
            testBase.WaitForLoadingIconDisappear();

            if (paymentMethod.ToLower() == "monthly")
            {
                DirectDebitPage directDebitPage = new DirectDebitPage();
                directDebitPage.InputAccountHolderName("hien");
                directDebitPage.InputSortCode1("40");
                directDebitPage.InputSortCode2("47");
                directDebitPage.InputSortCode3("84");
                directDebitPage.InputAccountNumber("70872490");
                directDebitPage.SelectCheckBoxConfirmation("Yes");
                directDebitPage.ClickDirecDebitContinue("Yes");
                testBase.WaitForLoadingIconDisappear();
            }
            //testBase.CloseBrowser();

            getSessionIdInQuoteResponse();
        }

        [When(@"User perform payment after DeepLink")]
        public async Task WhenUserSendPaymentAfterDeepLink(Table table)
        {
            // send  save payment infor request
            var lstPara = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            var authorization = Common.GetToken();
            var jsonPath = lstPara.Item2.Quotes + _quoteRequestBody;
            var url = _specflowHelper.GetUrlByString(lstPara.Item1.Quotes);
            var jsonBody = QuoteApiHelper.CreateRequestBodyWithDateChange(jsonPath);

            var fieldMappings = table.CreateSet<FieldMapping>().ToList(); 
            List<string> paramValues = new List<string>();
            List<string> lsParamNames = new List<string>();
            foreach (var fieldMapping in fieldMappings)
            {
                var fieldNames = QuoteApiHelper.CreateKeyList(fieldMapping);
                string value = fieldMapping.Value;
                lsParamNames.Add(fieldMapping.Description);
                paramValues.Add(value);
                var jobject = JObject.Parse(jsonBody);
                JsonHelper.EditValue(jobject, fieldNames, value);
                jsonBody = JsonConvert.SerializeObject(jobject);
            }
            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(lstPara.Item3, authorization);
            _quoteResponse = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);

            string respondBody = _quoteResponse.Item1;
            var jResponseBody = JObject.Parse(respondBody);
            //string sessionId = jResponseBody["ResultObj"]["SessionId"].ToString();
            _webReference = jResponseBody["ResultObj"]["WebReference"].ToString();
            _schemeCode = jResponseBody["ResultObj"]["PolicyProduct"][0]["Insurer"]["Scheme"]["Code"].ToString();
            //paramValues.Add(sessionId);
            paramValues.Add(_webReference);
            paramValues.Add(_schemeCode);
            lsParamNames.Add("webref");
            lsParamNames.Add("schemecode");
            string baseUrl = _specflowHelper.GetBaseUrlFromConfig(_contextName);
            //List<string> lsParamNames = new List<string> { "pcd", "brd", "webref", "schemecode", "affinity" };
            string deepLink = trackingFunc.CreateURL(baseUrl + "/aggrecall", lsParamNames, paramValues);
            //string url = $"{baseUrl}/aggrecall?pcd=SW8%201TF&brd=01/02/1980&webref={_webReference}&schemecode={_schemeCode}&affinity={affinity}";

            TestBase testBase = new TestBase();
            testBase.OpenDeepLink(deepLink);
            QuoteSummaryPage quoteSummaryPage = new QuoteSummaryPage();
            quoteSummaryPage.ClickPaymentMethod(_paymentMethod);
            quoteSummaryPage.ClickQuoteSummaryContinue("Yes");
            testBase.WaitForLoadingIconDisappear();

            QuoteReviewPage quoteReviewPage = new QuoteReviewPage();
            quoteReviewPage.ClickAgreeButton("Yes");
            quoteReviewPage.ClickTermConfirmation("Yes");
            quoteReviewPage.ClickQuoteReviewContinue("Yes");
            testBase.WaitForLoadingIconDisappear();

            if (_paymentMethod.ToLower() == "monthly")
            {
                DirectDebitPage directDebitPage = new DirectDebitPage();
                directDebitPage.InputAccountHolderName("hien");
                directDebitPage.InputSortCode1("40");
                directDebitPage.InputSortCode2("47");
                directDebitPage.InputSortCode3("84");
                directDebitPage.InputAccountNumber("70872490");
                directDebitPage.SelectCheckBoxConfirmation("Yes");
                directDebitPage.ClickDirecDebitContinue("Yes");
                testBase.WaitForLoadingIconDisappear();
            }
            testBase.CloseBrowser();
            _sessionId = await getSessionIdInQuoteResponse();
            
        }


        [When(@"User send WebHook request")]
        public void WhenUserSendWebHookRequest()
        {
            ParametersForRequest lstPatameterWebHook = Common.GetParametersForRequest(_apiVersion, _contextName, _webHookBody);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            Thread.Sleep(1000);
            _url = specflowHelper.GetUrlByString(_uri);
            var jsonBody = PaymentFunctions.CreateRequestBodyNormalCaseForWebHook(_sessionId, _webReference, lstPatameterWebHook.ResourcePath);
            _webHookResponse = _requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, lstPatameterWebHook.Header);
            _actualStatusCode = (int)_webHookResponse.Item2;
            _actualMessages = _webHookResponse.Item1.ToString();

        }

        [Then(@"Webhook response returns (.*) and (.*)")]
        public void ThenWebhookResponseReturn(int expectedStatusCode, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Contains(expectedMessages, _actualMessages);
        }

        [When(@"User send Quote/PartialQuote successfully")]
        public void WhenUserSendQuoteRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _requestBody);

            Dictionary<string, string> lstSessionIsWebReference = Common.GetSessionIdAndWebReference(lstPara.Token, _requestBody, _apiVersion, _contextName);
            lstSessionIsWebReference.TryGetValue("WebReference", out _webReference);
        }

        [When(@"User send Recall Quote successfully")]
        public void WhenUserSendRecallQuoteRequest()
        {
            ParametersForRequest lstPatameter = Common.GetParametersForRequest(_apiVersion, _contextName, _recallRequestBody);
            Dictionary<string, string> lstSessionIsWebReference = Common.GetSessionIdAndWebReference(lstPatameter.Token, _requestBody, _apiVersion, _contextName);
            lstSessionIsWebReference.TryGetValue("WebReference", out _webReference);
            string resourcePath = lstPatameter.ResourcePath;
            var jsonBody = RecallFunctions.CreateRequestBodyWithWebReferenceChange(resourcePath, _webReference);
            Thread.Sleep(1000);
            var recallResponse = _requestUtils.SendRequest(HttpMethod.Post, lstPatameter.Url, jsonBody, lstPatameter.Header);
            JObject jResponseQuoteBody = JObject.Parse(recallResponse.Item1);
            _affinityCode = jResponseQuoteBody["ResultObj"]["Risk"]["Affinity"].ToString();

        }

        [Then(@"RequestType is recorded successfully in Tracking Database")]
        public async void ThenRequestTypeIsRecordedSuccessfullyInTrackingDb()
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Where("RequestType", "Quote")
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);
            Thread.Sleep(5000);
            Assert.True(records.Count() >= 1);

        }

        [Then(@"AffinityCode is recorded successfully in Tracking Database")]
        public async void ThenAffinityCodeIsRecordedSuccessfullyInTrackingDb()
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                //.Where("AffinityCode", "6270")
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);
            Thread.Sleep(5000);
            Assert.True(records.Count() >= 2);

        }

        [Then(@"Result in Quote request is recorded successfully in Tracking Database (.*)")]
        public async void ThenResultInQuoteRequestIsRecordedSuccessfullyInTrackingDb(string result)
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Where("RequestType", "Quote")
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);

            var record = records.FirstOrDefault();
            var requestXML = record.RequestXML;
            requestXML = requestXML.Substring(requestXML.IndexOf("<results>") + 9, requestXML.IndexOf("</results>") - requestXML.IndexOf("<results>") - 9);
            Assert.True(requestXML == result);
        }

        [Then(@"Result in Buy request is recorded successfully in Tracking Database (.*)")]
        public async void ThenResultInBuyRequestIsRecordedSuccessfullyInTrackingDb(string result)
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Where("RequestType", "Buy")
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);

            var record = records.FirstOrDefault();
            var requestXML = record.RequestXML;
            requestXML = requestXML.Substring(requestXML.IndexOf("<results>") + 9, requestXML.IndexOf("</results>") - requestXML.IndexOf("<results>") - 9);
            Assert.True(requestXML == result);
        }

        [Then(@"SchemeCode in Quote response is recorded successfully in Tracking Database")]
        public async void ThenSchemeCodeInQuoteResponseIsRecordedSuccessfullyInTrackingDb()
        {
            var query = new Query("Quote")
                .Where("WebReference", _webReference)
                .OrderByDesc("DateCreated")
                .Take(1);
            var records = await _quoteSqlClient.Get(query);
            var record = records.FirstOrDefault();
            var quoteResponse = record.QuoteResponse;
            var schemeCode = JObject.Parse(quoteResponse)["PolicyProduct"][0]["Insurer"]["Scheme"]["Code"].ToString();

            //string schemeCode = quoteResponse.Substring(quoteResponse.IndexOf("<results>") + 9, quoteResponse.IndexOf("</results>") - quoteResponse.IndexOf("<results>") - 9);
            Assert.True(schemeCode == _schemeCode);
        }

        public async Task<string> getSessionIdInQuoteResponse()
        {
            var sessionId = "";
               await Task.Run(async () =>
            {
                var query = new Query("Quote")
                .Where("WebReference", _webReference)
                .Take(1)
                .OrderByDesc("DateCreated");
            
                var records = await _quoteSqlClient.Get(query);
                var record = records.FirstOrDefault();
                //_sessionId = record.SessionId.ToString();
                sessionId = record.SessionId.ToString();
            });
            return sessionId;
        }

        [Then(@"WebReference is recorded successfully in Tracking Database")]
        public async void ThenWebReferenceIsRecordedSuccessfullyInTrackingDb()
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);
            Thread.Sleep(5000);
            Assert.True(records.Count() >= 1);

        }
        [Then(@"AffinityCode should be same in Tracking Database")]
        public async void ThenAffinityCodeShouldBeSameInTrackingDb()
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);
            Thread.Sleep(5000);
            var record = records.FirstOrDefault();
            Assert.True(record.AffinityCode == _affinityCode);

        }

        [Then(@"IsError is showed in Tracking Database (.*)")]
        public async void ThenIsErrorIsRecordedSuccessfullyInTrackingDb(string isError)
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Where("IsError", isError)
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);
            Thread.Sleep(5000);
            Assert.True(records.Count() >= 1);

        }

        [Then(@"Saving Content is XML format in Tracking Database")]
        public async void ThenSavingContentIsXMLFormatInTrackingDb()
        {
            var query = new Query("Tracking")
                .Where("WebReference", _webReference)
                .Take(1)
                .OrderByDesc("DateCreated");
            var records = await _trackingSqlClient.Get(query);
            Thread.Sleep(5000);
            var record = records.FirstOrDefault();
            var responseXML = record.ResponseXML;
            bool isXMLFormat = responseXML.Contains("?xml version=");
            Assert.True(isXMLFormat);

        }


    }
}
