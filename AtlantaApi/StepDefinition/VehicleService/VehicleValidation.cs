using AtlantaApi.StepDefinition.QuoteService.Quotes;
using AtlantaApi.StepDefinition.VehicleService;
using AtlantaApi.StepDefinition.VehicleService.V1;
using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AtlantaApi.StepDefinition
{
    [Binding]
    public class VehicleValidation : Steps
    {
        private static string _actualMessage;
        private static int _actualStatusCode;
        private static string _isSuccess;
        private static string _context;
        private static string _url;
        private static string _token;
        private static Dictionary<string, string> _paramforValidation = new Dictionary<string, string>();
        private static Dictionary<string, JObject> _JDVLAResponse = new Dictionary<string, JObject>();

        static SpecflowHelper _specflowHelper = new SpecflowHelper();
        static RequestUtils _requestUtils = new RequestUtils();
        private static Tuple<string, System.Net.HttpStatusCode> _vehicleResponse;
        private static dynamic _requestLog;
        private static List<JToken> _lstVehicleTypes, _lstManufactures, _lstModels;

        public static void SendRequestTomakeList(string apiVersion, string contextName, string vehicleBodyName, string method, string token, string key)
        {
            if (token.Equals("Yes"))
            {
                _token = Common.GetToken();
            }
            if (token.Equals("No"))
            {
                _token = null;
            }
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            var context = serviceInfoAndContext.Item3;
            var header = _requestUtils.GetHeader(context, _token);
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(method, url, null, header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }

        
        public static void ValidateUsingEndPoint(string apiVersion, string contextName, string vehicleBodyName, string endpoint, string key)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            _url = _specflowHelper.GetUrlByString(endpoint);           
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase("null",lstPara.ResourcePath);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, lstPara.Header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }

        public static void SendRequestToGetModel(string apiVersion, string contextName, string method, string token, string parameter, string key)
        {           
            if (token.Equals("Yes"))
            {
                _token = Common.GetToken();
            }
            else
            {
                _token = Common.GetToken() + "acas";
            }

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            _context = serviceInfoAndContext.Item3;
            var header = _requestUtils.GetHeader(_context, _token);
            string endpoint = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList);
            if (!parameter.Equals(""))
            {
                _url = endpoint + "?ManufacturerId=" + parameter;
            }
            else
            {
                _url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList);
            }
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(method, _url, null, header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }
        

        public static void ValidateSearchUsingYear(string apiVersion, string contextName, string vehicleBodyName, string year)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase("null", lstPara.ResourcePath);
            string _jsonBody = jsonBody.Replace("2019", year);
            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, _jsonBody, lstPara.Header);
            _actualMessage = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
        }

        public static void ValidateVehicleSearchRequest(string apiVersion, string contextName, string vehicleBodyName, string key)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase("null", lstPara.ResourcePath);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }

        //public static void SendNormalVehicleSearchRequest(string apiVersion, string contextName, string vehicleBodyName)
        //{            
        //    string token = Common.GetToken();           
        //    _vehicleResponse = VehicleSearchNormalCase(vehicleBodyName, apiVersion, contextName, token);           
        //}

        public static void ValidateResponseBodyExactly()
        {
            var jResponseVehicleBody = JObject.Parse(_vehicleResponse.Item1);
            var jTokenVehicle = jResponseVehicleBody.SelectToken("$..ResultObj");
            List<JToken> lstVehicle = jTokenVehicle.ToList();
            foreach (var item in lstVehicle)
            {
                string make = item["Make"].ToString();
                string model = item["Model"].ToString();
                string YearOfManufactures = item["YearOfManufacture"].ToString();
                string FuelType = item["FuelType"].ToString();
                string Transmission = item["Transmission"].ToString();
                Assert.True(!String.IsNullOrEmpty(make) && !String.IsNullOrEmpty(model) && !String.IsNullOrEmpty(YearOfManufactures) &&
                    !String.IsNullOrEmpty(FuelType) && !String.IsNullOrEmpty(Transmission));
            }
            Thread.Sleep(1000);
        }

        public static void SendDVLARequest(string apiVersion, string contextName, string registrationNumber, int requestTime, string key)
        {
            var token = Common.GetToken();
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            var context = serviceInfoAndContext.Item3;
            var header = _requestUtils.GetHeader(context, token);
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Lookup);
            url = url.Replace("{RegistrationNumber}", registrationNumber);
            Tuple<string, System.Net.HttpStatusCode> response = null;
            for (int i=0; i< requestTime; i++)
            {
                RequestUtils requestUtils = new RequestUtils();
                response = requestUtils.SendRequest(HttpMethod.Get, url, "", header);               
            }
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(1000);
            if (_paramforValidation[key + "StatusCode"].Equals("200"))
            {
                _JDVLAResponse.Add(key, JObject.Parse(response.Item1));
            }
            _requestLog = VehicleDVLADatabase.GetRequestLogRecord(registrationNumber);
            Thread.Sleep(1000);
        }

        public static void CheckVehicleRecordInTrackingDB()
        {
            VehicleTrackingDatabase.GetTrackingInformation("VehicleSearchByDetails");
        }

        public static void SendSearchVehicleType(string apiVersion, string contextName, string vehecleBodyName, string endpoint, string method, string key)
        {
            Thread.Sleep(2000);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehecleBodyName);
            string url = _specflowHelper.GetUrlByString(endpoint);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(method,url ,"", lstPara.Header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
        }

        public static void ValidateDVLAResponseWithCacheDB(string expectedMessage, string expectedStatusCode, string registrationNumber, string key)
        {
            if (_paramforValidation[key + "StatusCode"].Equals("200"))
            {
                JObject jResponseDVLABody = _JDVLAResponse[key];
                string make = jResponseDVLABody["ResultObj"][0]["Make"].ToString();
                string model = jResponseDVLABody["ResultObj"][0]["Model"].ToString();
                string engine = jResponseDVLABody["ResultObj"][0]["Engine"].ToString();
                string fromYear = jResponseDVLABody["ResultObj"][0]["FromToYear"].ToString();
                string type = jResponseDVLABody["ResultObj"][0]["Type"].ToString();
                var databaseInfos = VehicleDVLADatabase.GetDVLAInfoFromDatabase(registrationNumber);
                Assert.Equal(databaseInfos.Item1, make);
                Assert.Equal(databaseInfos.Item2, model);
                Assert.Equal(databaseInfos.Item3, engine);
                Assert.Equal(databaseInfos.Item4, fromYear);
                Assert.Equal(databaseInfos.Item5, type);
            }
            else
            { 
                Assert.Equal(expectedMessage, _paramforValidation[key + "Message"]);
                Assert.Equal(expectedStatusCode, _paramforValidation[key + "StatusCode"]);
            }
            Thread.Sleep(1000);
        }

        public static void SendGetModelRequest(string apiVersion, string contextName, string vehicleBodyName, string method, string vehicleType, string manufacturerName, string key)
        {
            Thread.Sleep(2000);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            string url = lstPara.Url.Replace("{vehicleType}", vehicleType).Replace("{manufacturerName}", manufacturerName);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(method, url, "", lstPara.Header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }

        public static void GetModelByAuthentication(string apiVersion, string contextName, string vehicleBodyName, string token, string vehicleType, string manufacturerName, string key)
        {
            Thread.Sleep(2000);
            string authentication;
            if (token.Equals("Yes"))
            {
                authentication = Common.GetToken();
            }
            else
            {
                authentication = "";
            }
            
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            var context = serviceInfoAndContext.Item3;
            var header = _requestUtils.GetHeader(context, authentication);
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList);
            string endpoint = url.Replace("{vehicleType}", vehicleType).Replace("{manufacturerName}", manufacturerName);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(HttpMethod.Get, endpoint, "", header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }
        public static void CallVehicleSerchAPI(string apiVersion, string contextName, string vehicleBodyName, Table table, string key)
        {
            string token = Common.GetToken();
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = QuoteApiHelper.CreateKeyList(fieldMapping);
            string value = fieldMapping.Value;
            value = value.Replace("\\b", " ");
            _vehicleResponse = VehicleCommon.VehicleSearch(vehicleBodyName, fieldNames, value, apiVersion, contextName, token);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(_vehicleResponse));
            _paramforValidation.Add(key + "StatusCode", ((int)_vehicleResponse.Item2).ToString());
            Thread.Sleep(2000);
        }

        public static void GetBaseVehicle(string apiVersion, string contextName, string vehicleBodyName, string method, string endpoint, string key)
        {
            Thread.Sleep(2000);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            string url = _specflowHelper.GetUrlByString(endpoint);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(method,url ,"", lstPara.Header);
            _paramforValidation.Add(key + "Message", ResponseUtils.GetResponseMessage(response));
            _paramforValidation.Add(key + "StatusCode", ((int)response.Item2).ToString());
            Thread.Sleep(2000);
        }

        // hien
        public static void GetVehicleTypesNormalCase(string apiVersion, string contextName, string vehicleBodyName)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            RequestUtils requestUtils = new RequestUtils();
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleTypes);
            var response = requestUtils.SendRequest(HttpMethod.Get, url, "", lstPara.Header);
            var baseVehicleResponseBody = JObject.Parse(response.Item1);
            var result = baseVehicleResponseBody["ResultObj"];
            _lstVehicleTypes = new List<JToken>();
            _lstVehicleTypes = result.ToList();
        }

        public static void GetVehicleTypes(string apiVersion, string contextName, string vehicleBodyName,string method, string token )
        {
            if (token.Equals("Valid"))
            {
                _token = Common.GetToken();
            }
            if (token.Equals("Invalid"))
            {
                _token = Common.GetToken() + "invalid";
            }
            SpecflowHelper specflowHelper = new SpecflowHelper();
            RequestUtils requestUtils = new RequestUtils();
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleTypes);
            var response = requestUtils.SendRequest(method, url, "", lstPara.Header);
            //var baseVehicleResponseBody = JObject.Parse(response.Item1);
            if (response.Item1.ToString() != "")
            {
                var responseBody = JObject.Parse(response.Item1);

                var result = responseBody["ResultObj"];
                _lstVehicleTypes = new List<JToken>();
                _lstVehicleTypes = result.ToList();
                _isSuccess = (String)responseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
            }
            _actualMessage = ResponseUtils.GetResponseMessage(response);
            if (String.IsNullOrEmpty(_actualMessage))
            {
                _actualMessage = response.Item2.ToString();
            }
        }

        public static void GetMakeListNormalCase(string apiVersion, string contextName, string vehicleBodyName)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            RequestUtils requestUtils = new RequestUtils();
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures)
                .Replace("{VehicleTypeId}", _lstVehicleTypes[0]["Id"].ToString());
            var response = requestUtils.SendRequest(HttpMethod.Get, url, "", lstPara.Header);
            var responseBody = JObject.Parse(response.Item1);
            var result = responseBody["ResultObj"];
            _lstManufactures = new List<JToken>();
            _lstManufactures = result.ToList();
        }
        //hien
        public static void SendRequestToGetMakeList(string apiVersion, string contextName, string vehicleBodyName, string method, string token)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures)
                .Replace("{VehicleTypeId}",_lstVehicleTypes[0]["Id"].ToString());
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(method, url, null, lstPara.Header);
            if (response.Item1.ToString() != "")
            {
                var responseBody = JObject.Parse(response.Item1);
            
                var result = responseBody["ResultObj"];
                _lstManufactures = new List<JToken>();
                _lstManufactures = result.ToList();
                _isSuccess = (String)responseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
            }
            _actualMessage = ResponseUtils.GetResponseMessage(response);
            if (String.IsNullOrEmpty(_actualMessage))
            {
                _actualMessage = response.Item2.ToString();
            }

        }

        public static void SendRequestToGetModelList(string apiVersion, string contextName, string vehicleBodyName, string method, string token)
        {
            if (token.Equals("Valid"))
            {
                _token = Common.GetToken();
            }
            if (token.Equals("Invalid"))
            {
                _token = Common.GetToken() + "invalid";
            }
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);

            RequestUtils requestUtils = new RequestUtils();
            var header = requestUtils.GetHeader(contextName, _token);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList)
                .Replace("{VehicleTypeId}", _lstVehicleTypes[0]["Id"].ToString())
                .Replace("{ManufacturerId}", _lstManufactures[0]["Id"].ToString());

            var response = requestUtils.SendRequest(method, url, null, header);
            if (response.Item1.ToString() != "")
            {
                var responseBody = JObject.Parse(response.Item1);

                var result = responseBody["ResultObj"];
                _lstModels = new List<JToken>();
                _lstModels = result.ToList();
                _isSuccess = (String)responseBody["IsSuccess"];
                _actualStatusCode = (int)response.Item2;
            }
            if (String.IsNullOrEmpty(_actualMessage))
            {
                _actualMessage = response.Item2.ToString();
            } else
            {
                _actualMessage = ResponseUtils.GetResponseMessage(response);
            }

        }

        //hien
        //public static void Validation(string checkItem, int expectedStatusCode, string expectedMessage, string isSuccess)
        //{
        //    Thread.Sleep(4000);
        //    if (isSuccess == "True")
        //    {
        //        Assert.Equal(isSuccess, _isSuccess);
        //        Assert.Equal(expectedStatusCode, _actualStatusCode);
        //        if (checkItem == "Manufaturer")
        //        {
        //            Assert.True(_lstManufactures.Count() > 0);
        //        }
        //        if (checkItem == "VehicleType")
        //        {
        //            Assert.True(_lstVehicleTypes.Count() > 0);
        //        }
        //        if (checkItem == "Model")
        //        {
        //            Assert.True(_lstModels.Count() > 0);
        //        }

        //    }
        //    Assert.Equal(expectedMessage, _actualMessage);

        //}
        //hien end

        public static void Validation(string expectedStatusCode, string expectedMessage, string key)
        {
            Thread.Sleep(2000);
            string message = _paramforValidation[key + "Message"];
            string statusCode = _paramforValidation[key + "StatusCode"];
            Assert.Equal(expectedMessage, message.Replace(".", ""));
            Assert.Equal(expectedStatusCode, statusCode);
            
        }

        public static void ValidateRequestLog(string expectedStatusCode, string registrationNumber, string key)
        {
            string statusCode = _paramforValidation[key + "StatusCode"];
            Assert.Equal(expectedStatusCode, statusCode);
            Assert.True(_requestLog.Count>0);
        }
    }

}
