using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.ReferenceDataService
{
    [Binding]
    public class ReferenceDataSteps : Steps
    {
        SpecflowHelper _specflowHelper = new SpecflowHelper();
        private RequestUtils _requestUtils = new RequestUtils();
        private int _actualStatusCode;
        private string _actualMessages, _apiVersion, _contextName, _referenceDataRequestBody;

        [Given(@"User has Reference Data body")]
        public void GivenUserHasReferenceDataRequest(Table prepurchaseTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(prepurchaseTable);
            _referenceDataRequestBody = paramValues["ReferenceDataRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }
        [When(@"User send invalid metadata request with (.*) and (.*)")]
        public void WhenUserSendInvalidMetadataRequestWith(string endpoint, string contextName)
        {
            string token = Common.GetToken();
            var context = _specflowHelper.GetContextFromConfig(contextName);
            var header = _requestUtils.GetHeader(context, token);
            string url = _specflowHelper.GetUrlByString(endpoint);
            string jsonBody = Common.ReadFileJson(_referenceDataRequestBody, _apiVersion, contextName);
            var response = _requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            _actualStatusCode = (int)response.Item2;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }

        [When(@"User send Reference Data Metadata request")]
        public void WhenUserSendReferenceDataMetadataRequestWith(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _referenceDataRequestBody);
            string jsonBody = ReferenceDataFunctions.CreateRequestReferenceDataBody(_referenceDataRequestBody,table, _apiVersion, _contextName);
            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualStatusCode = (int)response.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = response.Item2.ToString();
            }
            else
                _actualMessages = ResponseUtils.GetResponseMessage(response);
        }
        [When(@"User send metadata request with excel file (.*)")]
        public void WhenUserSendMetadataRequestWithExcelFile(string fileName)
        {
            ReferenceDataFunctions.VerifyDatabaseAreMappedWithDataFile(fileName, _referenceDataRequestBody, _apiVersion, _contextName);
        }
        [When(@"User send metadata request to order data with excel file (.*)")]
         public void WhenUserSendMetadataRequesToOrderDatatWithExcelFile(string fileName)
        {
            ReferenceDataFunctions.VerifyTransformedOrdered(fileName, _referenceDataRequestBody, _apiVersion, _contextName);
        }
        [When(@"User send Reference Data Metadata request with normal case")]
        public void WhenUserSendReferenceDataMetadataRequestWithNormalCase()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _referenceDataRequestBody);
            string jsonBody = Common.ReadFileJson(_referenceDataRequestBody, _apiVersion, _contextName);
            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualStatusCode = (int)response.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = response.Item2.ToString();
            }
            else
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }
        [Then(@"The Reference Data response should be shown (.*) and (.*)")]
        public void ThenVeicleResponseReturn(int expectedStatusCode, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessages.Replace(".",""), _actualMessages.Replace(".", ""));
        }
    }
}
