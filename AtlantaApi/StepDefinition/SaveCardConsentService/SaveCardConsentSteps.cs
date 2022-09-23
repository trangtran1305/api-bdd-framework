using TechTalk.SpecFlow;

using System;
using System.Collections.Generic;
using System.Text;
using ProjectCore.ApiCore.Common;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Xunit;
using System.Threading;
using AtlantaApi.StepDefinition.QuoteService;

namespace AtlantaApi.StepDefinition.SaveCardConsentService
{
    [Binding]
    class SaveCardConsentSteps : Steps
    {
        RequestUtils requestUtils = new RequestUtils();
        private int _actualStatusCode = 0;
        private bool _actualIsSuccess;
        private string _actualMessages, _saveCardConsentRequestBody, _quoteRequestBody;
        private string _apiVersion, _contextName, _cardConsentApiVersion;

        [Given(@"User has Save Card Consent body")]
        public void GivenUserHasSaveCardConsentRequest(Table saveDebitTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(saveDebitTable);
            _saveCardConsentRequestBody = paramValues["SaveCardConsentRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [Given(@"User has Save Card Consent body for SG")]
        public void GivenUserHasSaveCardConsentBodyForSG(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _saveCardConsentRequestBody = paramValues["SaveCardConsentRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["QuoteApiVersion"];
            _cardConsentApiVersion = paramValues["CardConsentApiVersion"];
            _contextName = paramValues["ContextName"];
        }


        [When(@"User send Save Card Consent normal case")]
        public void WhenUserSendSaveCardConsentRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveCardConsentRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Card Consent normal case for SG")]
        public void WhenUserSendSaveCardConsentRequestForSG()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_cardConsentApiVersion, _contextName, _saveCardConsentRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Card Consent Read Body File for SG")]
        public void WhenUserSendSaveCardConsentReadBodyFileForSG()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_cardConsentApiVersion, _contextName, _saveCardConsentRequestBody);
            //string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = Common.ReadFileJson(_saveCardConsentRequestBody, _apiVersion, _contextName);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }


        [When(@"User send Save Card Consent Read Body File")]
        public void WhenUserSendSaveCardConsentRequestReadBodyFile()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveCardConsentRequestBody);
            //string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = Common.ReadFileJson(_saveCardConsentRequestBody, _apiVersion, _contextName);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }
        [When(@"User send Save Card Consent request")]
        public void WhenUserSendValidSaveCardConsentRequest(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveCardConsentRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_saveCardConsentRequestBody, table, sessionId, _apiVersion, _contextName);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            Thread.Sleep(1000);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        [When(@"User send Save Card Consent request for SG")]
        public void WhenUserSendValidSaveCardConsentRequestForSG(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_cardConsentApiVersion, _contextName, _saveCardConsentRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_saveCardConsentRequestBody, table, sessionId, _apiVersion, _contextName);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            Thread.Sleep(1000);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        [Then(@"Save Card Consent response returns (.*) and (.*)")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode,  string expectedMessage)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessage.Replace(".",""), _actualMessages.Replace(".", ""));
        }

    }
}
