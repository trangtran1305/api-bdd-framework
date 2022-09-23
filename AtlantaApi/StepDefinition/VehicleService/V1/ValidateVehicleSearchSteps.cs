using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    [Binding]
    public class ValidateVehicleSearchSteps
    {

        private string _vehicleBodyName, _actualMessage, _apiVersion, _contextName, _isSuccess;
        static RequestUtils _requestUtils = new RequestUtils();
        int _actualStatusCode;

        private List<JToken> _lstVehicleTypes, _lstManufactures, _lstModels, _lstMakes = new List<JToken>();
        [Given(@"User has search vehicle bodyjson")]
        public void GivenUserHasAVehicleSearch(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _vehicleBodyName = paramValues["VehicleRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User sends request to Make list using (.*) and (.*) using (.*)")]
        public void WhenUserSendsRequestToMakeList(string method, string token, string key)
        {
            VehicleValidation.SendRequestTomakeList(_apiVersion, _contextName, _vehicleBodyName, method, token, key);
        }

        [When(@"User sends Vehicle Search request using (.*) and (.*)")]
        public void WhenUserSendsVehicleSearchRequestUsingMethodAndContext(string endpoint, string key)
        {
            VehicleValidation.ValidateUsingEndPoint(_apiVersion,_contextName,_vehicleBodyName,endpoint, key);
        }

        [When(@"The customer call vehicle search API Without Content using (.*)")]
        public void WhenTheCustomerCallVehicleSearchAPIWithoutContent(string key)
        {
            VehicleValidation.ValidateVehicleSearchRequest(_apiVersion,_contextName,_vehicleBodyName, key);
        }


        [When(@"The customer call vehicle search API using (.*)")]
        public void WhenTheCustomerCallVehicleSearchAPI(string key, Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _vehicleBodyName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase("null", lstPara.ResourcePath);
            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessage = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            string token = Common.GetToken();

            VehicleValidation.CallVehicleSerchAPI(_apiVersion, _contextName, _vehicleBodyName, table, key);
        }

        [When(@"User sends request to Get Model using (.*) and (.*) and (.*) and (.*)")]
        public void WhenUserSendsRequestToGetModel(string method, string token, string parameter, string key)
        {
            VehicleValidation.SendRequestToGetModel(_apiVersion, _contextName, method, token, parameter, key);

        }

        [When(@"User calls to Search API Using (.*)")]
        public void WhenUserCallsToSearchAPIUsing(string year)
        {
            VehicleValidation.ValidateSearchUsingYear(_apiVersion, _contextName, _vehicleBodyName, year);
        }


        //[When(@"User sends normal search request")]
        //public void WhenUserSendsNormalSearchRequest()
        //{
        //    VehicleValidation.SendNormalVehicleSearchRequest(_apiVersion, _contextName, _vehicleBodyName);
        //}

        [Then(@"The Vehicle search response should be record in Tracking DB")]
        public void ThenTheVehicleSearchResponseShouldBeRecordInTrackingDB()
        {
            VehicleValidation.CheckVehicleRecordInTrackingDB();
        }


        [Then(@"The Vehicle response should be shown exactly")]
        public void ThenTheVehicleResponseShouldBeShownExactly()
        {
            VehicleValidation.ValidateResponseBodyExactly();
        }


        [Then(@"The Vehicle response should be shown (.*) and (.*) and (.*)")]
        public void ThenTheResponsesShouldBeShownAs(string expectedStatusCode, string expectedMessage, string key)
        {
            VehicleValidation.Validation(expectedStatusCode.Replace(".", ""), expectedMessage.Replace(".", ""), key);
        }


        [Given(@"User sends Get Vehicle Type request for SG")]
        public void GivenUserSendsGetVehicleTypeRequest()
        {
            this.UserSendsGetRequest("VehicleTypes", HttpMethod.Get, "Valid");
        }

        //[Given(@"User sends Get Manufacturer request")]
        //public void GivenUserSendsGetManufacturerRequest()
        //{
        //    this.UserSendsGetRequest("ManufacturesList", HttpMethod.Get, "Valid");
        //}

        //[When(@"User sends Get request using (.*) and (.*) and (.*)")]
        //public void UserSendsGetRequest(string endpoint, string method, string token)
        //{
        //    var authorization = "";
        //    if (token.Equals("Valid"))
        //    {
        //        authorization = Common.GetToken();
        //    }
        //    if (token.Equals("Invalid"))
        //    {
        //        authorization = Common.GetToken() + "invalid";
        //    }

        //    var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
        //    SpecflowHelper specflowHelper = new SpecflowHelper();
        //    string url = "";
        //    switch (endpoint)
        //    {
        //        case "VehicleTypes":
        //            url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleTypes);
        //            break;

        //        case "ManufacturesList":
        //            url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ManufacturesList)
        //            .Replace("{VehicleTypeId}", _lstVehicleTypes[0]["Id"].ToString());
        //            break;
        //        case "ModelList":
        //            url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
        //            .Replace("{VehicleTypeID}", _lstVehicleTypes[0]["Id"].ToString())
        //            .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());
        //            break;
        //        case "MakeList":
        //            url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleMakeList);
        //            break;
        //        case "ModelList1":
        //            url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH).Replace("models", "models1");
        //            break;
        //        default:
        //            Console.WriteLine("No Endpoint Found");
        //            break;
        //    }

        //    RequestUtils requestUtils = new RequestUtils();
        //    var context = serviceInfoAndContext.Item3;
        //    var header = requestUtils.GetHeader(context, authorization);
        //    var response = requestUtils.SendRequest(method, url, "", header);
        //    string responseBody = response.Item1;
        //    if (String.IsNullOrEmpty(responseBody))
        //    {
        //        Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
        //        _actualMessage = response.Item2.ToString();
        //        _actualStatusCode = (int)response.Item2;
        //    }
        //    else
        //    {
        //        var jResponseBody = JObject.Parse(responseBody);
        //        _isSuccess = (String)jResponseBody["IsSuccess"];
        //        _actualStatusCode = (int)response.Item2;
        //        _actualMessage = ResponseUtils.GetResponseMessage(response);
        //        if (endpoint.Equals("VehicleTypes"))
        //        {
        //            _lstVehicleTypes = jResponseBody["ResultObj"].ToList();
        //        }
        //        else if (endpoint.Equals("ManufacturesList"))
        //        {
        //            _lstManufactures = jResponseBody["ResultObj"].ToList();
        //        }
        //        else if (endpoint.Equals("ModelList"))
        //        {
        //            _lstModels = jResponseBody["ResultObj"].ToList();
        //        }
        //        else if (endpoint.Equals("MakeList"))
        //        {
        //            _lstMakes = jResponseBody["ResultObj"].ToList();
        //        }
        //    }

        //}

        //[When(@"User sends Get Model request using (.*) and (.*)")]
        //public void WhenUserSendsGetModelRequest(int manufacturerId, int vehicleTypeId)
        //{
        //    string authorization = Common.GetToken();

        //    var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
        //    SpecflowHelper specflowHelper = new SpecflowHelper();
        //    string url = "";
        //    if (manufacturerId < 0 || manufacturerId > _lstManufactures.Count)
        //    {
        //        url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
        //        .Replace("{VehicleTypeID}", _lstVehicleTypes[0]["Id"].ToString())
        //        .Replace("{ManufacturerId}", "invalid");
        //    }
        //    else if (vehicleTypeId < 0 || vehicleTypeId > _lstVehicleTypes.Count)
        //    {
        //        url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
        //        .Replace("{VehicleTypeID}", "invalid")
        //        .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());
        //    }
        //    else
        //    {
        //        url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
        //       .Replace("{VehicleTypeID}", _lstVehicleTypes[vehicleTypeId]["Id"].ToString())
        //       .Replace("{ManufacturerId}", _lstManufactures[manufacturerId]["Id"].ToString());
        //    }
        //    RequestUtils requestUtils = new RequestUtils();
        //    var context = serviceInfoAndContext.Item3;
        //    var header = requestUtils.GetHeader(context, authorization);
        //    var response = requestUtils.SendRequest(HttpMethod.Get, url, "", header);
        //    string responseBody = response.Item1;
        //    _actualStatusCode = (int)response.Item2;
        //    if (_actualStatusCode == 200)
        //    {
        //        var jResponseBody = JObject.Parse(responseBody);
        //        _isSuccess = (String)jResponseBody["IsSuccess"];
        //        _actualMessage = ResponseUtils.GetResponseMessage(response);
        //        _lstModels = jResponseBody["ResultObj"].ToList();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
        //        _actualMessage = response.Item2.ToString();
        //    }

        //}

        //[Then(@"The (.*) response should be shown: (.*) and (.*) and (.*)")]
        //public void ThenTheResponseShouldBeShown(string endpoint, int expectedStatusCode, string expectedMessage, string isSuccess)
        //{
        //    if (isSuccess == "True")
        //    {
        //        Assert.Equal(isSuccess, _isSuccess);

        //        if (endpoint == "ManufacturesList")
        //        {
        //            Assert.True(_lstManufactures.Count() > 0);
        //        }
        //        if (endpoint == "VehicleTypes")
        //        {
        //            Assert.True(_lstVehicleTypes.Count() > 0);
        //        }
        //        if (endpoint == "ModelList")
        //        {
        //            Assert.True(_lstModels.Count() > 0);
        //        }
        //        if (endpoint == "MakeList")
        //        {
        //            Assert.True(_lstMakes.Count() > 0);
        //        }

        //    }
        //    Assert.Equal(expectedMessage, _actualMessage);
        //    Assert.Equal(expectedStatusCode, _actualStatusCode);
        //}

        [Given(@"User sends Get Manufacturer request of SG")]
        public void GivenUserSendsGetManufacturerRequest()
        {
            this.UserSendsGetRequest("ManufacturesList", HttpMethod.Get, "Valid");
        }

        [When(@"User sends SG Get request using (.*) and (.*) and (.*)")]
        public void UserSendsGetRequest(string endpoint, string method, string token)
        {
            var authorization = "";
            if (token.Equals("Valid"))
            {
                authorization = Common.GetToken();
            }
            if (token.Equals("Invalid"))
            {
                authorization = Common.GetToken() + "invalid";
            }

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            string url = "";
            switch (endpoint)
            {
                case "VehicleTypes":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleTypes);
                    break;

                case "ManufacturesList":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ManufacturesList)
                    .Replace("{VehicleTypeId}", _lstVehicleTypes[0]["Id"].ToString());
                    break;
                case "ModelList":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
                    .Replace("{VehicleTypeID}", _lstVehicleTypes[0]["Id"].ToString())
                    .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());
                    break;
                case "MakeList":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleMakeList);
                    break;
                case "ModelList1":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH).Replace("models", "models1");
                    break;
                default:
                    Console.WriteLine("No Endpoint Found");
                    break;
            }

            RequestUtils requestUtils = new RequestUtils();
            var context = serviceInfoAndContext.Item3;
            var header = requestUtils.GetHeader(context, authorization);
            var response = requestUtils.SendRequest(method, url, "", header);
            string responseBody = response.Item1;
            if (String.IsNullOrEmpty(responseBody))
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                _actualMessage = response.Item2.ToString();
                _actualStatusCode = (int)response.Item2;
            }
            else
            {
                var jResponseBody = JObject.Parse(responseBody);
                _isSuccess = (String)jResponseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
                _actualMessage = ResponseUtils.GetResponseMessage(response);
                if (endpoint.Equals("VehicleTypes"))
                {
                    _lstVehicleTypes = jResponseBody["ResultObj"].ToList();
                }
                else if (endpoint.Equals("ManufacturesList"))
                {
                    _lstManufactures = jResponseBody["ResultObj"].ToList();
                }
                else if (endpoint.Equals("ModelList"))
                {
                    _lstModels = jResponseBody["ResultObj"].ToList();
                }
                else if (endpoint.Equals("MakeList"))
                {
                    _lstMakes = jResponseBody["ResultObj"].ToList();
                }
            }

        }

        [When(@"User sends Get Model request of SG using (.*) and (.*)")]
        public void WhenUserSendsGetModelRequest(int manufacturerId, int vehicleTypeId)
        {
            string authorization = Common.GetToken();

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            string url = "";
            if (manufacturerId < 0 || manufacturerId > _lstManufactures.Count)
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
                .Replace("{VehicleTypeID}", _lstVehicleTypes[0]["Id"].ToString())
                .Replace("{ManufacturerId}", "invalid");
            }
            else if (vehicleTypeId < 0 || vehicleTypeId > _lstVehicleTypes.Count)
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
                .Replace("{VehicleTypeID}", "invalid")
                .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());
            }
            else
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListScenicMH)
               .Replace("{VehicleTypeID}", _lstVehicleTypes[vehicleTypeId]["Id"].ToString())
               .Replace("{ManufacturerId}", _lstManufactures[manufacturerId]["Id"].ToString());
            }
            RequestUtils requestUtils = new RequestUtils();
            var context = serviceInfoAndContext.Item3;
            var header = requestUtils.GetHeader(context, authorization);
            var response = requestUtils.SendRequest(HttpMethod.Get, url, "", header);
            string responseBody = response.Item1;
            _actualStatusCode = (int)response.Item2;
            if (_actualStatusCode == 200)
            {
                var jResponseBody = JObject.Parse(responseBody);
                _isSuccess = (String)jResponseBody["IsSuccess"];
                _actualMessage = ResponseUtils.GetResponseMessage(response);
                _lstModels = jResponseBody["ResultObj"].ToList();
            }
            else
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                _actualMessage = response.Item2.ToString();
            }

        }

        [When(@"User sends Get request of SG using (.*) and (.*) and (.*)")]
        public void UserSendsGetOfSGRequest(string endpoint, string method, string token)
        {
            var authorization = "";
            if (token.Equals("Valid"))
            {
                authorization = Common.GetToken();
            }
            if (token.Equals("Invalid"))
            {
                authorization = Common.GetToken() + "invalid";
            }

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            string url = "";
            switch (endpoint)
            {
                case "VehicleTypes":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleTypes);
                    break;

                case "ManufacturesList":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ManufacturesList)
                    .Replace("{VehicleTypeId}", _lstVehicleTypes[0]["Id"].ToString());
                    break;
                case "ModelList":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList)
                    .Replace("{VehicleTypeID}", _lstVehicleTypes[0]["Id"].ToString())
                    .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());
                    break;
                case "ModelListSG":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelListSG)
                    .Replace("{VehicleTypeID}", _lstVehicleTypes[0]["Id"].ToString())
                    .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());
                    break;
                case "MakeList":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleMakeList);
                    break;
                case "ModelList1":
                    url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList).Replace("models", "models1");
                    break;
                default:
                    Console.WriteLine("No Endpoint Found");
                    break;
            }

            RequestUtils requestUtils = new RequestUtils();
            var context = serviceInfoAndContext.Item3;
            var header = requestUtils.GetHeader(context, authorization);
            var response = requestUtils.SendRequest(method, url, "", header);
            string responseBody = response.Item1;
            if (String.IsNullOrEmpty(responseBody))
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                _actualMessage = response.Item2.ToString();
                _actualStatusCode = (int)response.Item2;
            }
            else
            {
                var jResponseBody = JObject.Parse(responseBody);
                _isSuccess = (String)jResponseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
                _actualMessage = ResponseUtils.GetResponseMessage(response);
                if (endpoint.Equals("VehicleTypes"))
                {
                    _lstVehicleTypes = jResponseBody["ResultObj"].ToList();
                }
                else if (endpoint.Equals("ManufacturesList"))
                {
                    _lstManufactures = jResponseBody["ResultObj"].ToList();
                }
                else if (endpoint.Equals("ModelList"))
                {
                    _lstModels = jResponseBody["ResultObj"].ToList();
                }
                else if (endpoint.Equals("MakeList"))
                {
                    _lstMakes = jResponseBody["ResultObj"].ToList();
                }
            }

        }

        [Then(@"The (.*) response of SG should be shown: (.*) and (.*) and (.*)")]
        public void ThenTheResponseShouldBeShown(string endpoint, int expectedStatusCode, string expectedMessage, string isSuccess)
        {
            if (isSuccess == "True")
            {
                Assert.Equal(isSuccess, _isSuccess);

                if (endpoint == "ManufacturesList")
                {
                    Assert.True(_lstManufactures.Count() > 0);
                }
                if (endpoint == "VehicleTypes")
                {
                    Assert.True(_lstVehicleTypes.Count() > 0);
                }
                if (endpoint == "ModelList")
                {
                    Assert.True(_lstModels.Count() > 0);
                }
                if (endpoint == "MakeList")
                {
                    Assert.True(_lstMakes.Count() > 0);
                }

            }
            Assert.Equal(expectedMessage, _actualMessage);
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }
    }
}
