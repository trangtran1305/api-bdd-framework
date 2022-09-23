using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.APICore.Common;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    [Binding]
    public class GetVehicleLookupByVRNSteps
    {
        private RequestUtils _requestUtils = new RequestUtils();
        private SpecflowHelper _specFlowHelper = new SpecflowHelper();
        private string _contextName, _apiVersion, _endpoint, _url;
        private string _actualMessage;
        private int _actualStatusCode;
        private Tuple<string, HttpStatusCode> respond;

        [Given(@"A request vehicle lookup by VRN has")]
        public void GivenARequestVehicleLookupByVRNHas(Table table)
        {
            var lsParams = SpecflowHelper.TableToDictionary(table);
            _contextName = lsParams["Context"];
            _apiVersion = lsParams["APIVersion"];
            _endpoint = lsParams["Endpoint"];

        }

        [When(@"An user sends the request with Reg Number is ""(.*)""")]
        public void WhenAnUserSendsTheRequestWithRegNumberIs(string vrn)
        {
            var serviceAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            if (_endpoint.Equals("VehicleLookupVRN"))
            {
                _url = _specFlowHelper.GetUrlByString(serviceAndContext.Item1.Lookup);
            }
            var context = serviceAndContext.Item3;
            var url = _url.Replace("{RegistrationNumber}", vrn);
            var token = Common.GetToken();
            var header = _requestUtils.GetHeader(context, token);
            respond = _requestUtils.SendRequest(HttpMethod.Get, url, header);
            _actualMessage = ResponseUtils.GetResponseMessage(respond);
            _actualStatusCode = ResponseUtils.GetResponseCode(respond);
        }

        [Then(@"The response should have (.*), ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenTheResponseShouldHave(int statusCode, string message, string make, string model, string engine, string fromToYear, string manufacture, string fuel, string transmission, string abiCode, string cdlCode, string registratinDate)
        {
            Assert.Equal(message, _actualMessage);
            Assert.Equal(statusCode, _actualStatusCode);
            var vehicle = ResponseUtils.GetVehicleLookupVRN(respond);
            Assert.Equal(make, vehicle.Make);
            Assert.Equal(model, vehicle.Model);
            Assert.Equal(engine, vehicle.Engine);
            Assert.Equal(fromToYear, vehicle.FromToYear);
            Assert.Equal(manufacture, vehicle.ManufactureDate);
            Assert.Equal(fuel, vehicle.Fuel);
            Assert.Equal(transmission, vehicle.Transmission);
            Assert.Equal(abiCode, vehicle.AbiCode);
            Assert.Equal(cdlCode, vehicle.CdlCode);
            Assert.Equal(registratinDate, vehicle.RegistrationDate);
        }

       

        [Then(@"The response should have (.*), ""(.*)""")]
        public void ThenTheResponseShouldHave(int statusCode, string message)
        {
            Assert.Equal(message, _actualMessage);
            Assert.Equal(statusCode, _actualStatusCode);
        }
    }
}
