using AtlantaApi.Utils;
using Newtonsoft.Json;
using ProjectCore.ApiCore.Common;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.QuoteService.Prepurchase
{
    [Binding]
    public class SaveMarketingStep : Steps
    {
        RequestUtils requestUtils = new RequestUtils();
        private int _actualStatusCode = 0;
        private bool _actualIsSuccess;
        private string _actualMessages, _saveMarketingRequestBody, _quoteRequestBody;
        private string _apiVersion, _contextName;

        [Given(@"User has Save Marketing body")]
        public void GivenUserHasSaveMarketingRequest(Table saveMarketingTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(saveMarketingTable);
            _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User send Save Marketing normal case")]
        public void WhenUserSendSaveMarketingRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Marketing with old sessionID")]
        public void WhenUserSendSaveMarketingWithOldSessionID()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string oldSessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(oldSessionId, lstPara.ResourcePath);
            //Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Marketing with old sessionId")]
        public void WhenUserSendSaveMarketingWithOldSessionId()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string oldSessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(oldSessionId, lstPara.ResourcePath);
            //Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Save Marketing request")]
        public void WhenUserSendASaveMarketingRequest(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            Thread.Sleep(2000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_saveMarketingRequestBody, table, sessionId, _apiVersion, _contextName);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }
        [Then(@"Save Marketing response returns (.*) and (.*) and (.*)")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode, bool expectedIsSuccess, string expectedMessage)
        {
            expectedMessage = expectedMessage.Replace(".", "").Replace(",", "").ToLower();
            _actualMessages = _actualMessages.Replace(".", "").Replace(",", "").ToLower();
            bool isTrue = _actualMessages.Contains(expectedMessage);
            Assert.Equal(expectedMessage, _actualMessages);
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedIsSuccess, _actualIsSuccess);
        }

        [When(@"User send Save Marketing request with (.*)")]
        public void WhenUserSendASaveMarketingRequestSessionIdCheck(string input)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string sessionId = "";// Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            if (input.ToLower().Equals("valid"))
            {
                sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            }
            else if (input.ToLower().Equals("old"))
            {
                string oldSessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
                sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
                sessionId = oldSessionId;
            }
            Thread.Sleep(1000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }
    }
}
