using AtlantaApi.Utils;
using ProjectCore.ApiCore.Common;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    [Binding]
    public class GetVehicleLookUpSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specFlowHelper = new SpecflowHelper();
        private string _contextName, _apiVersion, _jsonFileName;
        private string _actualMessage;
        private int _actualStatusCode;

        [Given(@"User has vehicle look up body as")]
        public void GivenUserHasVehicleLookUpBodyAs(Table table)
        {
            var lsParams = SpecflowHelper.TableToDictionary(table);
            _contextName = lsParams["Context"];
            _apiVersion = lsParams["ApiVersion"];
            _jsonFileName = lsParams["RequestBody"];
        }
        
        [When(@"The user sends a request to get vehicle look up")]
        public void WhenTheUserSendsARequestToGetVehicleLookUp()
        {
            var token = Common.GetToken();
            var serviceAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            var jsonBody = Common.ReadFileJson(_jsonFileName, _apiVersion, _contextName);
            var context = serviceAndContext.Item3;
            var url = _specFlowHelper.GetUrlByString(serviceAndContext.Item1.VehicleSearch);
            var header = _requestUtils.GetHeader(context, token);
            var respond = _requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            _actualMessage = ResponseUtils.GetResponseMessage(respond);
            _actualStatusCode = ResponseUtils.GetResponseCode(respond);
        }
        
        [Then(@"The respond should be (.*) and (.*)")]
        public void ThenTheRespondShouldBeAnd(string expectedMessage, int expectedStatusCode)
        {
            Assert.Equal(expectedMessage, _actualMessage);
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }
    }
}
