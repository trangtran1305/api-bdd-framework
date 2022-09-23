using AtlantaApi.Utils;
using ProjectCore.ApiCore.Common;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.AddressService.V1
{
    [Binding]
    public class AddressInvalidRequestCasesSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specflowHelper = new SpecflowHelper(); 
        int _actualStatusCode;
        [When(@"User send request with invalid endpoint (.*) or method (.*) with (.*) and (.*)")]
        public void WhenUserSendRequestWithInvalidEndpointOrMethod(string endpoint, string method, string inputApiVersion, string inputContext)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(inputApiVersion, inputContext);            
            var context = serviceInfoAndContext.Item3;
            var authorization = Common.GetToken();
            var header = _requestUtils.GetHeader(context, authorization);
            var url = _specflowHelper.GetUrlByString(endpoint);
            var addressResponse = _requestUtils.SendRequest(method, url, null, header);
            _actualStatusCode = (int)addressResponse.Item2;          
        }

        [Then(@"The service response returns (.*)")]
        public void ThenTheResponseReturns(int expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }
    }
}
