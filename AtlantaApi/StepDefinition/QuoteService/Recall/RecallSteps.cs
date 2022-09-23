using TechTalk.SpecFlow;


using System.Collections.Generic;
using System.Text;
using ProjectCore.ApiCore.Common;
using AtlantaApi.Utils;
using Xunit;
using System;
using ProjectCore.SQL;
using System.Threading;
using SqlKata;
using System.Linq;
using System.Xml;
using AtlantaApi.StepDefinition.QuoteService.Quotes;
using ProjectCore.ApiCore.Helper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TechTalk.SpecFlow.Assist;
using System.IO;

namespace AtlantaApi.StepDefinition.QuoteService.Recall
{
    [Binding]
    class RecallSteps : Steps
    {
        //private readonly FluentSqlClient<TrackingModel> _trackingSqlClient;
        SpecflowHelper _specflowHelper = new SpecflowHelper();
        private RequestUtils _requestUtils = new RequestUtils();
        private int _actualStatusCode;
        private string _apiVersion, _contextName, _quoteRequestBody, _recallRequestBody, _webReference, _actualMessages,_postCode,_dateOfBirth;
        Tuple<string, System.Net.HttpStatusCode> _recallResponse;
        private readonly DateTime _startDate;
        //public RecallSteps(ScenarioContext scenarioContext)
        //{
        //    _startDate = DateTime.Now;

        //    var sqlHelper = new SqlHelper();
        //    var trackingConnectionString = sqlHelper.GetConnectionString("TrackingDb");
        //    _trackingSqlClient = new FluentSqlClient<TrackingModel>(new DatabaseConnectionFactory(trackingConnectionString));
        //}


        [Given(@"User has recall body")]
        public void GivenUserHasReferenceDataRequest(Table prepurchaseTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(prepurchaseTable);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _recallRequestBody = paramValues["RecallRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User send recall service")]
        public void WhenUserSendARecallRequest()
        {
            ParametersForRequest lstPatameter = Common.GetParametersForRequest(_apiVersion, _contextName, _recallRequestBody);
            Dictionary<string, string> lstSessionIsWebReference = Common.GetSessionIdAndWebReference(lstPatameter.Token, _quoteRequestBody, _apiVersion, _contextName);
            lstSessionIsWebReference.TryGetValue("WebReference", out _webReference);
            string resourcePath = lstPatameter.ResourcePath;
            var jsonBody = RecallFunctions.CreateRequestBodyWithWebReferenceChange(resourcePath, _webReference);
            Thread.Sleep(1000);
            _recallResponse = _requestUtils.SendRequest(HttpMethod.Post, lstPatameter.Url, jsonBody, lstPatameter.Header);
            _actualStatusCode = (int)_recallResponse.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = _recallResponse.Item2.ToString();
            }
            else
                _actualMessages = ResponseUtils.GetResponseMessage(_recallResponse);
        }


        //[Then(@"Check Data in Tracking Database (.*) (.*)")]
        //public async void ThenGetDataInTrackingDb(string companyCode, string policyType)
        //{
        //    var todayDate = _startDate.ToShortDateString();

        //    var query = new Query("Tracking")
        //         .Where("RequestType", "Quote")
        //         .Where("CompanyCode", companyCode)
        //           .Where("PolicyType", policyType)
        //        .Take(5);
        //    var records = await _trackingSqlClient.Get(query);
        //    List<string> lstParameter = RecallFunctions.GetWebReferPostCodeDateOfBirth(records);
        //    _webReference = lstParameter[0];
        //    _postCode = lstParameter[1];
        //    _dateOfBirth = lstParameter[2];
        //    ParametersForRequest lstPatameter = Common.GetParametersForRequest(_apiVersion, _contextName, _recallRequestBody);
        //    string resourcePath = lstPatameter.ResourcePath;
        //    var jsonBody = RecallFunctions.CreateRequestBodyWithParametersChange(resourcePath, _webReference, _postCode, _dateOfBirth);
        //    _recallResponse = _requestUtils.SendRequest(HttpMethod.Post, lstPatameter.Url, jsonBody, lstPatameter.Header);
        //    _actualStatusCode = (int)_recallResponse.Item2;
        //    string valueActual = RecallFunctions.GetDoQuoteInRecallResponse(_recallResponse);
        //    Assert.Equal("False", valueActual);
        //}

        [When(@"User send recall service with data change")]
        public void WhenUserSendRecallServiceWithChangeData(Table table)
        {
            string webReference;
            ParametersForRequest lstPatameter = Common.GetParametersForRequest(_apiVersion, _contextName, _recallRequestBody);
            Dictionary<string, string> lstSessionIsWebReference = Common.GetSessionIdAndWebReference(lstPatameter.Token, _quoteRequestBody, _apiVersion, _contextName);
            lstSessionIsWebReference.TryGetValue("WebReference", out webReference);
            string resourcePath = lstPatameter.ResourcePath;
            var jsonBody = RecallFunctions.CreateRequestBodyWithWebReferenceChange(resourcePath, webReference);
            jsonBody = RecallFunctions.CreateRequestBodyWithDataChange(jsonBody, table);
            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPatameter.Url, jsonBody, lstPatameter.Header);
            _actualStatusCode = (int)response.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = response.Item2.ToString();
            }
            else
                _actualMessages = ResponseUtils.GetResponseMessage(response);
        }
        [Then(@"Recall response returns (.*) and (.*)")]
        public void ThenRecallResponseReturn(int expectedStatusCode, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessages.Replace(".", ""), _actualMessages.Replace(".", ""));
        }

        [Then(@"Recall response returns DoQuote value (.*)")]
        public void ThenReCallReturnDoQuote(string valueExpected)
        {
            string valueActual = RecallFunctions.GetDoQuoteInRecallResponse(_recallResponse);
            Assert.Equal(valueExpected, valueActual);
        }
    }
}
