using TechTalk.SpecFlow;

using System;
using System.Collections.Generic;
using System.Text;
using ProjectCore.ApiCore.Common;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Xunit;
using System.Threading;

namespace AtlantaApi.StepDefinition.QuoteService.Prepurchase
{
    [Binding]
    class SaveMarketingSteps : Steps
    {
        RequestUtils requestUtils = new RequestUtils();
        private int _actualStatusCode = 0;
        private bool _actualIsSuccess;
        private string _actualMessages, _saveDebitRequestBody, _quoteRequestBody;
        private string _apiVersion, _contextName;

        [Given(@"User has Save Debit body")]
        public void GivenUserHasSaveDebitRequest(Table saveDebitTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(saveDebitTable);
            _saveDebitRequestBody = paramValues["SaveDebitRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User send Save Debit normal case")]
        public void WhenUserSendSaveDebitRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId,lstPara.ResourcePath);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Debit request for SG")]
        public void WhenUserSendSaveDebitRequestForSG(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            //Thread.Sleep(1000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_saveDebitRequestBody, table, sessionId, _apiVersion, _contextName);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            Thread.Sleep(1000);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse1>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        [When(@"User send Save Debit with old sessionID")]
        public void WhenUserSendSaveDebitWithOldSessionID()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            string oldSessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(oldSessionId, lstPara.ResourcePath);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Debit with old sessionId")]
        public void WhenUserSendSaveDebitWithOldSessionId()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            string oldSessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(oldSessionId, lstPara.ResourcePath);
            //Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            //Thread.Sleep(1000);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Debit request")]
        public void WhenUserSendValidPrepurchaseRequest(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_saveDebitRequestBody, table, sessionId, _apiVersion, _contextName);
            //Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            Thread.Sleep(1000);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }
        [Then(@"Save Debit response returns (.*) and (.*) and (.*)")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode,bool expectedIsSuccess, string expectedMessage)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedIsSuccess, _actualIsSuccess);
            Assert.Equal(expectedMessage.Replace(".", ""), _actualMessages.Replace(".", ""));
        }

        [When(@"User send Save Debit request with (.*)")]
        public void WhenUserSendValidPrepurchaseRequestWithSessionId(string input)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            string sessionId="";
            if (input.ToLower().Equals("valid"))
            {
                sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            }
            else if (input.ToLower().Equals("old"))
            {
               string  oldSessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
               sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
                sessionId = oldSessionId;
            }
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);

        }
    }
}
