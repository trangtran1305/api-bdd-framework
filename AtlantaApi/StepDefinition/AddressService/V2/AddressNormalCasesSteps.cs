using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.AddressService.V1
{
    [Binding]
    public class AddressNormalCasesSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specflowHelper = new SpecflowHelper();
        private string _actualMessage;
        int _actualStatusCode;
        string _resourcePath;
        string _responseBody;

        [When(@"User send address service with (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenUserSendAddressServiceWithAnd(string postCode, string houseNumber,string policyType, string inputApiVersion, string inputContext)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(inputApiVersion, inputContext);
            var urlByVersion = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Address);
            _resourcePath = serviceInfoAndContext.Item2.Address;
            string url = "";
            if (postCode.Equals("missing"))
            {
                url= urlByVersion.Replace("postcode={postCode}&", "").Replace("{houseNumber}", houseNumber).Replace("{policyType}", policyType);
            } else if (houseNumber.Equals("missing"))
            {
                url = urlByVersion.Replace("{postCode}", postCode).Replace("houseNumber={houseNumber}&", "").Replace("{policyType}", policyType);
            }
            else if (policyType.Equals("missing"))
            {
                url = urlByVersion.Replace("{postCode}", postCode).Replace("houseNumber={houseNumber}", houseNumber).Replace("policyType={policyType}","");
            }
            else
            {
                url = urlByVersion.Replace("{postCode}", postCode).Replace("{houseNumber}", houseNumber).Replace("{policyType}", policyType);
            }           
            var context = serviceInfoAndContext.Item3;
            string authorization = Common.GetToken();
            var header = _requestUtils.GetHeader(context, authorization);
            header.Add("X-Forwarded-For", "183.91.2.199");
            var addressResponse = _requestUtils.SendRequest(HttpMethod.Get, url, null, header);
            _responseBody = addressResponse.Item1;
            _actualStatusCode = (int)addressResponse.Item2;
            _actualMessage = ResponseUtils.GetResponseMessage(addressResponse);            
        } 
        
        [Then(@"The service response returns (.*) and (.*)")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode, string expectedMessage)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessage.Replace(".",""), _actualMessage.Replace(".", ""));
        }
        
        [Then(@"The response body is displayed successfully (.*)")]
        public void ThenTheResponseBodyIsDisplayedSuccessfully(string expectedResponseBodyName)
        {
            var expectedAddressPath = FileUtils.GetPayLoadSource(_resourcePath + expectedResponseBodyName);
            var expectResponseBody = JObject.Parse(File.ReadAllText(expectedAddressPath));
            var expectedAddress = expectResponseBody["ResultObj"]["Addresses"][0];
            var actualAddress = JObject.Parse(_responseBody)["ResultObj"]["Addresses"][0];
            Dictionary<string, string> dictObjExpectedAddress = expectedAddress.ToObject<Dictionary<string, string>>();
            Dictionary<string, string> dictObjActualAddress = actualAddress.ToObject<Dictionary<string, string>>();
            
            var result = dictObjExpectedAddress.Keys.Except(dictObjActualAddress.Keys).ToList();
            Assert.True(result.Count==0);
        }
    }
}
