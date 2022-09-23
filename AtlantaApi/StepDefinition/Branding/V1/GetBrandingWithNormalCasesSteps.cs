using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.Branding.V1
{
    [Binding]
    public class GetBrandingWithNormalCasesSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specflowHelper = new SpecflowHelper();
        int _actualStatusCode;
        string _actualMessage;
        private string _apiVersion;
        private string _contextName;

        [Given(@"User has Reference Branding Data body")]
        public void GivenUserHasReferenceBrandingDataBody(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }


        [When(@"User sends get branding request using (.*)")]
        public void WhenUserSendsGetBrandingRequest(string appUrl)
        {

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            var context = serviceInfoAndContext.Item3;
            var authorization = Common.GetToken();
            var header = _requestUtils.GetHeader(context, authorization);
            var url = _specflowHelper.GetUrlByString(appUrl);
            var responseBody = _requestUtils.SendRequest(HttpMethod.Get, url, header);
            _actualStatusCode = (int)responseBody.Item2;
            _actualMessage = ResponseUtils.GetResponseMessage(responseBody);
            var jResponseQuoteBody = JObject.Parse(responseBody.Item1);
            string resulObject = jResponseQuoteBody["ResultObj"].ToString();

        }
        
        [Then(@"Branding response should returns (.*) and (.*) and (.*)")]
        public void ThenBrandingResponseShouldReturns(int expectedStatusCode, string isSuccess, string expectedMessage)
        {
            Assert.Equal(_actualStatusCode, expectedStatusCode);
            Assert.Equal(_actualMessage, expectedMessage);
        }
    }
}
