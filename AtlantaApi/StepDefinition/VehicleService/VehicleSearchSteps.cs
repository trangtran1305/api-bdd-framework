using AtlantaApi.Utils;
using System;
using TechTalk.SpecFlow;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using AtlantaApi.StepDefinition.QuoteService.Quotes;
using TechTalk.SpecFlow.Assist;
using System.IO;
using System.Collections.Generic;

namespace AtlantaApi.StepDefinition.VehicleService
{
    [Binding]
    public class VehicleSearchSteps : Steps
    {
        private string _vehicleBodyName, _resourcePath, _url;
        private string _actualMessages, _isSuccess;
        private int _actualStatusCode;
        private string _apiVersion;
        private string _contextName;
        private Tuple<string, System.Net.HttpStatusCode> _vehicleResponse;
        private List<JToken> _lstVehicleTypes, _lstManufactures, _lstModels, _lstMakes = new List<JToken>();


        private string _make;

        SpecflowHelper _specflowHelper = new SpecflowHelper();
        RequestUtils _requestUtils = new RequestUtils();
        //private Tuple<string, System.Net.HttpStatusCode> _vehicleResponse;

        [Given(@"User has search vehicle body")]
        public void GivenUserHasAVehicleSearch(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _vehicleBodyName = paramValues["VehicleRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(paramValues["ApiVersion"], paramValues["ContextName"]);
            _resourcePath = serviceInfoAndContext.Item2.VehicleService;
            _contextName = serviceInfoAndContext.Item3;
            SpecflowHelper _specflowHelper = new SpecflowHelper();
            _url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleSearch);
        }


        [Given(@"User has vehicle info")]
        public void GivenUserHasVehicleInfo(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
            //var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(paramValues["ApiVersion"], paramValues["ContextName"]);
            //_resourcePath = serviceInfoAndContext.Item2.VehicleService;
            //_contextName = serviceInfoAndContext.Item3;
            //SpecflowHelper _specflowHelper = new SpecflowHelper();
            //_url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleSearch);
        }
        public Tuple<string, System.Net.HttpStatusCode> VehicleSearchNormalCase(string jsonBodyName, string apiVersion, string contextName, string token)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            RequestUtils requestUtils = new RequestUtils();
            var jsonPath = _resourcePath + _vehicleBodyName;
            var requestJsonFilePath = FileUtils.GetPayLoadSource(jsonPath);
            var jsonBody = File.ReadAllText(requestJsonFilePath);
            var header = requestUtils.GetHeader(contextName, token);
            Tuple<string, System.Net.HttpStatusCode> response = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            return response;
        }

        //[When(@"User send Vehicle Search service normal case with (.*)")]
        //public void WhenTheCustomerCallVehicleSearchNormalCase(string make)
        //{
        //    var _token = Common.GetToken();
        //    _vehicleResponse = VehicleSearchNormalCase(_vehicleBodyName, _apiVersion, _contextName, _token);
        //    _actualStatusCode = (int)_vehicleResponse.Item2;
        //    if (_actualStatusCode == 204)
        //    {
        //        _actualMessages = _vehicleResponse.Item2.ToString();
        //    }
        //    else
        //    {
        //        _actualMessages = ResponseUtils.GetResponseMessage(_vehicleResponse);
        //    }
        //    _make = make;

        //}

        [When(@"User send Vehicle Search service invalid token")]
        public void WhenTheCustomerCallVehicleSearchInvalidToken()
        {
            string token = Common.GetToken();
            token = token + "abc";
            _vehicleResponse = VehicleSearchNormalCase(_vehicleBodyName, _apiVersion, _contextName, token);
            _actualStatusCode = (int)_vehicleResponse.Item2;
            if (_actualStatusCode == 204 || _actualStatusCode == 401)
            {
                _actualMessages = _vehicleResponse.Item2.ToString();
            }
            else
            {
                _actualMessages = ResponseUtils.GetResponseMessage(_vehicleResponse);
            }

        }

        [When(@"User send Vehicle Search service normal case")]
        public void WhenTheCustomerCallVehicleSearchNormalCase()
        {
            string token = Common.GetToken();
            _vehicleResponse = VehicleSearchNormalCase(_vehicleBodyName, _apiVersion, _contextName, token);
            _actualStatusCode = (int)_vehicleResponse.Item2;
            if (_actualStatusCode != 200)
            {
                _actualMessages = _vehicleResponse.Item2.ToString();
            }
            else
            {
                _actualMessages = ResponseUtils.GetResponseMessage(_vehicleResponse);
            }
        }

        [When(@"User send Vehicle Search data change")]
        public void WhenTheCustomerCallVehicleSearchDataChange(Table table)
        {
            var token = Common.GetToken();
            var jsonPath = _resourcePath + _vehicleBodyName;
            var requestJsonFilePath = FileUtils.GetPayLoadSource(jsonPath);
            var jsonBody = File.ReadAllText(requestJsonFilePath);
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = QuoteApiHelper.CreateKeyList(fieldMapping);
            string value = fieldMapping.Value;
            value = value.Replace("\\b", " ");
            var jobject = JObject.Parse(jsonBody);
            JsonHelper.EditValue(jobject, fieldNames, value);
            jsonBody = JsonConvert.SerializeObject(jobject);
            var requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(_contextName, token);
            var response = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            _actualStatusCode = (int)response.Item2;
            _actualMessages = ResponseUtils.GetResponseMessage(response);
        }
        

        [Then(@"The Vehicle response should show (.*) and (.*)")]
        public void ThenTheResponsesShouldBeShownAs(string expectedStatusCode, string expectedMessage)
        {
            expectedMessage = expectedMessage.Replace(".", "");
            Assert.Equal(expectedMessage, _actualMessages.Replace(".", ""));
            Assert.Equal(expectedStatusCode, _actualStatusCode.ToString());
        }

        //[Then(@"The Vehicle response format should be shown exactly (.*)")]
        //public void ThenVehicleResponseFormatExactly1(string typeOfValidate)
        //{
        //    var jResponseQuoteBody = JObject.Parse(_vehicleResponse.Item1);
        //    var jTokenVehicle = jResponseQuoteBody.SelectToken("$..Vehicles");
        //    var jTokenYearOfManufactures = jResponseQuoteBody.SelectToken("$..YearOfManufactures");
        //    var jTokenFuelTypes = jResponseQuoteBody.SelectToken("$..FuelTypes");
        //    var jTokenTransmissions = jResponseQuoteBody.SelectToken("$..Transmissions");
        //    List<JToken> lstVehicle = jTokenVehicle.ToList();
        //    List<JToken> lstYearOfManufactures = jTokenYearOfManufactures.ToList();
        //    List<JToken> lstFuelTypes = jTokenFuelTypes.ToList();
        //    List<JToken> lstTransmissions = jTokenTransmissions.ToList();

        //    switch (typeOfValidate)
        //    {
        //        case "format":
        //            //Validate FuelType format
        //            VehicleCommon.CheckFuelTypesFormat(lstFuelTypes);
        //            //Validate Transmission format
        //            VehicleCommon.CheckTransmissionFormat(lstTransmissions);
        //            //Validate YearOfManufactures format
        //            VehicleCommon.CheckYearOfManufactureFormat(lstYearOfManufactures);
        //            //Validate Vihicle List Format
        //            VehicleCommon.CheckListVehicleFormat(lstVehicle, _make);
        //            break;
        //        case "CompareYearOfManufactors":
        //            //Validate year in Vehicle list is same with YearOfManufactures
        //            VehicleCommon.CompareYearOfManufactors(lstVehicle, lstYearOfManufactures);
        //            break;
        //        case "ValidateTransmissionTypesByFuelTypes":
        //            //Validate TranmistionTypes and FuelTypes Responses are mapping
        //            VehicleCommon.ValidateTransmissionTypesByFuelTypes(lstTransmissions, lstFuelTypes, jTokenTransmissions, jTokenFuelTypes);
        //            break;
        //        case "VerifyYearOfManufactureFuelTypesAndTransmissionTypes":
        //            //Validate response returns Tranmisstion types and Fuel types following Year Of Manufactures
        //            VehicleCommon.VerifyYearOfManufactureFuelTypesAndTransmissionTypes(lstTransmissions, lstYearOfManufactures, lstFuelTypes);
        //            break;
        //        default:
        //            Console.WriteLine("No TestCase Found");
        //            break;
        //    }
        //    Console.WriteLine("Debug");
        //}        

        [When(@"User sends Get Manufacturers request using (.*) and (.*) and (.*)")]
        public void UserSendsGetManufacturersRequest(string endpoint, string method, string token)
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
            string url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures);
            RequestUtils requestUtils = new RequestUtils();
            var context = serviceInfoAndContext.Item3;
            var header = requestUtils.GetHeader(context, authorization);
            var response = requestUtils.SendRequest(method, url, "", header);
            string responseBody = response.Item1;
            if (String.IsNullOrEmpty(responseBody))
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                _actualMessages = response.Item2.ToString();
                _actualStatusCode = (int)response.Item2;
            }
            else
            {
                var jResponseBody = JObject.Parse(responseBody);
                _isSuccess = (String)jResponseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
                _actualMessages = ResponseUtils.GetResponseMessage(response);
                _lstManufactures = jResponseBody["ResultObj"].ToList();
            }
        }
        [When(@"User sends Get Manufacturers normal case")]
        public void UserSendsGetManufacturersNormalCase(string endpoint, string method, string token)
        {
            UserSendsGetManufacturersRequest("ManufacturesList", HttpMethod.Get, "Valid");
        }

        [When(@"User sends Get Models request using (.*) and (.*) and (.*) and (.*)")]
        public void UserSendsGetModelRequest(string endpoint, string method, string token, string manufacturerId)
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
            if (endpoint == "ModelList")
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList)
                        .Replace("{ManufacturerId}", manufacturerId);
            }
            else if (endpoint == "Models")
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Models);
            }
            else
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Models).Replace("models", "models1");
            }
            RequestUtils requestUtils = new RequestUtils();
            var context = serviceInfoAndContext.Item3;
            var header = requestUtils.GetHeader(context, authorization);
            var response = requestUtils.SendRequest(method, url, "", header);
            string responseBody = response.Item1;
            if (String.IsNullOrEmpty(responseBody))
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                _actualMessages = response.Item2.ToString();
                _actualStatusCode = (int)response.Item2;
            }
            else
            {
                var jResponseBody = JObject.Parse(responseBody);
                _isSuccess = (String)jResponseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
                _actualMessages = ResponseUtils.GetResponseMessage(response);
                _lstModels = jResponseBody["ResultObj"].ToList();
            }
        }
        [Given(@"User sends Get Vehicle Type request")]
        public void GivenUserSendsGetVehicleTypeRequest()
        {
            this.UserSendsGetRequest("VehicleTypes", HttpMethod.Get, "Valid");
        }

        [Given(@"User sends Get Manufacturer request")]
        public void GivenUserSendsGetManufacturerRequest()
        {
            this.UserSendsGetRequest("ManufacturesList", HttpMethod.Get, "Valid");
        }

        [When(@"User sends Get request using (.*) and (.*) and (.*)")]
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
                _actualMessages = response.Item2.ToString();
                _actualStatusCode = (int)response.Item2;
            }
            else
            {
                var jResponseBody = JObject.Parse(responseBody);
                _isSuccess = (String)jResponseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
                _actualMessages = ResponseUtils.GetResponseMessage(response);
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

        [When(@"User sends Get Model request using (.*) and (.*)")]
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
                _actualMessages = ResponseUtils.GetResponseMessage(response);
                _lstModels = jResponseBody["ResultObj"].ToList();
            }
            else
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                _actualMessages = response.Item2.ToString();
            }

        }
        [Then(@"The (.*) response should be shown: (.*) and (.*) and (.*)")]
        public void ThenTheResponseShouldBeShown(string endpoint, int expectedStatusCode, string expectedMessage, string isSuccess)
        {
            if (isSuccess == "True")
            {
                Assert.Equal(isSuccess, _isSuccess);

                if (endpoint == "ManufacturesList")
                {
                    Assert.True(_lstManufactures.Count() > 0);
                }
                if (endpoint == "ModelList")
                {
                    Assert.True(_lstModels.Count() > 0);
                }

            }
            Assert.Equal(expectedMessage, _actualMessages);
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }

    }
}
