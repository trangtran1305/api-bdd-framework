using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.QuoteService
{
    [Binding]
    public class CheckInvalidEndpointAndMethodSteps
    {
        private string _authorization = "";
        private int _actualStatusCode = 0;
        private string _actualMessage = "";
        private string _url = "";
        public string _requestBodyName;
        private string _context;
        private string _apiVersion;
        private string _contextName = "";
        SpecflowHelper _specflowHelper = new SpecflowHelper();
        private readonly ScenarioContext _scenarioContext;

        public CheckInvalidEndpointAndMethodSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
        }
        [Given(@"User has got token successful")]
        public void GivenUserHasGotTokenSuccessful()
        {
            _authorization = Common.GetToken();
        }
        
        [When(@"User send request with invalid endpoint (.*) or method (.*) of version (.*) with context (.*)")]
        public void WhenUserSendRequestWithInvalidEndpoint(string endpoint, string method, string apiVersion, string contextName)
        {
            var requestUtils = new RequestUtils();
            string token = Common.GetToken();
            string context = "";
            if (!String.IsNullOrEmpty(contextName))
            {
                 context = _specflowHelper.GetContextFromConfig(contextName);
            }

            _url = _specflowHelper.GetUrlByString(endpoint);
            var response = requestUtils.SendRequest(method, _url, null, requestUtils.GetHeader(context, token));
            _actualStatusCode = (int)response.Item2;
            if (_actualStatusCode == 400)
            {
                _actualMessage = ResponseUtils.GetResponseMessage(response);
            }
            else
            _actualMessage = response.Item2.ToString();

        }

        [Then(@"The response returns (.*)")]
        public void ThenTheResponseReturns(int expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }

        [Then(@"Response returns (.*) and (.*)")]
        public void ThenResponseReturnsAndValidate(int expectedStatusCode, string expectedMessage)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessage, _actualMessage);

        }

        [Given(@"User has a quote service")]
        public void GivenUserHasAQuoteService(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
             _contextName = paramValues["Context"];
            _requestBodyName = paramValues["QuoteRequestBody"];
        }

        [When(@"User send a valid quote service")]
        public void WhenUserSendAValidQuoteService()
        {
            string jsonBody = QuoteApiHelperPrepurchase.CreateRequestBodyWithDateChange(_requestBodyName,_apiVersion,_contextName);

            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(_context, _authorization);
            var response = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            _actualStatusCode = (int)response.Item2;
            if (_actualStatusCode == 200)
            {
                var jResponseQuoteBody = JObject.Parse(response.Item1);

                var sessionId = jResponseQuoteBody["ResultObj"]["SessionId"].ToString();
                var webReference = jResponseQuoteBody["ResultObj"]["WebReference"].ToString();

                _scenarioContext.Set(sessionId, "sessionId");
                _scenarioContext.Set(webReference, "webReference");
            }
        }

    }
}
