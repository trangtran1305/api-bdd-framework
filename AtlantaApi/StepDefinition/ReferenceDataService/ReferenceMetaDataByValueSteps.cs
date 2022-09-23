using AtlantaApi.Utils;
using ProjectCore.ApiCore.Common;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.ReferenceDataService
{
    [Binding]
    public class GetReferenceMetaDataByValueSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specFlowHelper = new SpecflowHelper();
        private string _contextName;
        private string _apiVersion;
        private string _jsonFileName;
        private string _actualMessage;
        private int _actualStatusCode;

        [Given(@"User has Reference Meta Data body")]
        public void GivenUserHasReferenceMetaDataBody(Table table)
        {
            var lsParams = SpecflowHelper.TableToDictionary(table);
            _contextName = lsParams["ContextName"];
            _apiVersion = lsParams["ApiVersion"];
            _jsonFileName = lsParams["ReferenceDataRequestBody"];
        }
        
        [When(@"User sends reference request by key")]
        public void WhenUserSendsReferenceRequestByKey()
        {
            var token = Common.GetToken();
            var serviceAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            var context = serviceAndContext.Item3;
            var url = _specFlowHelper.GetUrlByString(serviceAndContext.Item1.ReferenceDataByValue);
            var jsonBody= Common.ReadFileJson(_jsonFileName, _apiVersion, _contextName);
            var header = _requestUtils.GetHeader(context, token);
            var respondBody = _requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            _actualMessage = ResponseUtils.GetResponseMessage(respondBody);
            _actualStatusCode = ResponseUtils.GetResponseCode(respondBody);
        }
        
        [Then(@"The Reference Meta Data response should be shown (.*) and (.*)")]
        public void ThenTheReferenceMetaDataResponseShouldBeShown(string expectedMessage, int expectedStatusCode)
        {
            Assert.Equal(expectedMessage, _actualMessage);
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }
    }
}
