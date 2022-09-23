using AtlantaApi.Utils;
using ProjectCore.ApiCore.Common;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.Branding.V1
{
    [Binding]
    public class GetBrandingPhoneSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specflowHelper = new SpecflowHelper();
        int _actualStatusCode;
        string _actualMessage;
        private string _apiVersion;
        private string _contextName;

        [Given(@"User has Reference Branding data body")]
        public void GivenUserHasReferenceBrandingDataBody(Table table)
        {
            var lsParams = SpecflowHelper.TableToDictionary(table);
            _apiVersion = lsParams["ApiVersion"];
            _contextName = lsParams["ContextName"];
        }
        
        [When(@"User send branding request to get phone number")]
        public void WhenUserSendBrandingRequestToGetPhoneNumber()
        {
            var serviceAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            var context = serviceAndContext.Item3;
            var authorization = Common.GetToken();
            var header = _requestUtils.GetHeader(context, authorization);
            string _url = _specflowHelper.GetUrlByString(serviceAndContext.Item1.BrandingPhone);
            var respondBody = _requestUtils.SendRequest(HttpMethod.Get, _url, header);
            _actualMessage = ResponseUtils.GetResponseMessage(respondBody);
            _actualStatusCode = ResponseUtils.GetResponseCode(respondBody);

        }
        
        [Then(@"Branding respond should return  (.*) and (.*) and (.*)")]
        public void ThenBrandingResponseShouldReturns(int expectedStatusCode, string isSuccess, string expectedMessage)
        {
            Assert.Equal(_actualMessage, expectedMessage);
            Assert.Equal(_actualStatusCode, expectedStatusCode);
        }
    }
}
