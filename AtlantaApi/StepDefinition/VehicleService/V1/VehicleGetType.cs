using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Xunit;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    class VehicleGetType
    {
        private static string _actualMessage;
        private static int _actualStatusCode;
        private static JToken _responseResult;
        private static List<string> _lstVehicleTypeExcel;
        private static List<string> _lstTypeIDResponse;
        private static List<string> _lstTypeDescription;
        private static List<string> _lstManuID;
        private static List<string> _lstManuDescription;
        private static List<string> _lstUrl;
        private static bool _VerifyDugModel;
        private static bool _lstMakeModelDUQTypeValidation;
        private static List<string> _lstMakeModelDUQManValidation;
        private static List<string> _lstBaseVehicleValidation;
        private static List<string> _differentModelValidation;
        private static int _countDifference = 0;
        private static  List<string> _testResult = new List<string>();

        //private static Dictionary<string, List<string>> _dictionary;
        //private static Dictionary<string, List<string>> _stringDictionary;
        private static bool _resultToVerify;
        private static string _url;
        private static Dictionary<string, string> _dicVehicleType;

        static SpecflowHelper _specflowHelper = new SpecflowHelper();
        static RequestUtils _requestUtils = new RequestUtils();

        private static Dictionary<string, List<string>> _dictionary = new Dictionary<string, List<string>>();
        private static Dictionary<string, List<string>> _stringDictionary = new Dictionary<string, List<string>>();

        public static void SendGetTypeRequest(string apiVersion, string contextName, string vehicleBodyName, string requestType, string sheetName)
        {

            _lstVehicleTypeExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, "VehicleTypes", "Vehicle Type", apiVersion, contextName);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var response = _requestUtils.SendRequest(HttpMethod.Get, lstPara.Url, "", lstPara.Header);
            _url = lstPara.Url;
            _actualMessage = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var jResponseQuoteBody = JObject.Parse(response.Item1);
            _responseResult = jResponseQuoteBody["ResultObj"];
            _lstTypeDescription = new List<string>();
            _lstTypeIDResponse = new List<string>();
            _dicVehicleType = new Dictionary<string, string>();
            for (int i = 0; i < _responseResult.Count(); i++)
            {
                _lstTypeDescription.Add(_responseResult[i]["Description"].ToString());
                _lstTypeIDResponse.Add(_responseResult[i]["Id"].ToString());
                _dicVehicleType.Add(_responseResult[i]["Id"].ToString(), _responseResult[i]["Description"].ToString());
            }
            List<string> testResult = new List<string>();
            List<string> dataInResponse = new List<string>();
            List<string> dataInExcel = new List<string>();
            _lstTypeDescription.Sort();
            _lstVehicleTypeExcel.Sort();
            for (int i = 0; i < _lstTypeDescription.Count; i++)
            {

                if (!_lstTypeDescription[i].Trim().ToLower().Contains(_lstVehicleTypeExcel[i].Trim().ToLower()))
                {
                    string a = _lstTypeDescription[i].Trim().ToLower();
                    string b = _lstVehicleTypeExcel[i].Trim().ToLower();
                    testResult.Add("Failed");
                    _countDifference = _countDifference + 1;
                }
                else
                    testResult.Add("Passed");
                dataInResponse.Add(_lstTypeDescription[i]);
                dataInExcel.Add(_lstVehicleTypeExcel[i]);

            }
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "VehicleTypes", "Result", apiVersion, contextName, _lstVehicleTypeExcel.Count, testResult);
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "VehicleTypes", "DataInResponse", apiVersion, contextName, _lstVehicleTypeExcel.Count, dataInResponse);
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "VehicleTypes", "DataInExcel", apiVersion, contextName, _lstVehicleTypeExcel.Count, dataInResponse);

            _resultToVerify = _lstVehicleTypeExcel.Intersect(_lstTypeDescription).Any();
        }

        public static void GetManufactures(string apiVersion, string contextName, string vehicleBodyName, string requestType)
        {
            _lstManuDescription = new List<string>();
            _dictionary = new Dictionary<string, List<string>>();
            _stringDictionary = new Dictionary<string, List<string>>();
            Debug.WriteLine(_lstTypeDescription);
            List<string> lstManufacturersExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, "Make_Model_DUQ", "Manufacturer", apiVersion, contextName);
            List<string> lstDugTypeExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, "Make_Model_DUQ", "Type", apiVersion, contextName);
            List<string> uniqueListDugTypeExcel = lstDugTypeExcel.Distinct().ToList();
            _lstMakeModelDUQTypeValidation = _lstTypeDescription.Intersect(uniqueListDugTypeExcel).Any();
            _lstUrl = new List<string>();
            string url = GetURL(requestType);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            Dictionary<string, List<string>> dicManufacture = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> dicManufactureFromResponse = new Dictionary<string, List<string>>();
            for (int i = 0; i < _lstTypeIDResponse.Count; i++)
            {
                _lstManuID = new List<string>();
                List<string> myNewlist = new List<string>();
                for (int t = 0; t < lstDugTypeExcel.Count; t++)
                {
                    string string1 = _dicVehicleType[_lstTypeIDResponse[i]];
                    string string2 = lstDugTypeExcel[t];
                    string string3 = lstManufacturersExcel[t];
                    if (string1.Equals(string2))
                    {
                        myNewlist.Add(lstManufacturersExcel[t]);
                    }
                }
                dicManufacture.Add(_dicVehicleType[_lstTypeIDResponse[i]], myNewlist.Distinct().ToList());
                List<string> lstManResponse = new List<string>();
                string manUrl = url.Replace("{Id}", _lstTypeIDResponse[i]);
                _lstUrl.Add(manUrl);
                var manufactureResponse = _requestUtils.SendRequest(HttpMethod.Get, manUrl, "", lstPara.Header);
                Thread.Sleep(100);
                if (manufactureResponse.Item1.ToString().Equals(""))
                {
                    Debug.WriteLine("Request " + manUrl + " is error");
                }
                else
                {
                    var manufactureResponseBody = JObject.Parse(manufactureResponse.Item1);
                    var result = manufactureResponseBody["ResultObj"];

                    for (int J = 0; J < result.Count(); J++)
                    {
                        _lstManuDescription.Add(result[J]["Description"].ToString());
                        _lstManuID.Add(result[J]["Id"].ToString());
                        lstManResponse.Add(result[J]["Description"].ToString());
                    }
                    dicManufactureFromResponse.Add(_dicVehicleType[_lstTypeIDResponse[i]], lstManResponse);
                }
                lstManufacturersExcel.Sort();
                _lstManuDescription.Sort();
                
                _dictionary.Add(_lstTypeIDResponse[i], _lstManuID.Distinct().ToList());
                _stringDictionary.Add(_lstTypeIDResponse[i], lstManResponse);
            }
            _lstMakeModelDUQManValidation = lstManufacturersExcel.Except(_lstManuDescription).ToList();
            Console.WriteLine("Error at: " + _lstMakeModelDUQManValidation);
        }

        public static void GetModel(string apiVersion, string contextName, string vehicleBodyName, string requestType)
        {
            List<string> myListDataExcel = new List<string>();
            List<string> vehicleDatasResponse = new List<string>();
            myListDataExcel = ReadDataFromExcels.GetVehicleData(vehicleBodyName, "Make_Model_DUQ", apiVersion, contextName);
            string requestUrl = GetURL(requestType);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            List<string> lstManExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, "Make_Model_DUQ", "Manufacturer", apiVersion, contextName);
            List<string> dugModelResponse = new List<string>();
            List<string> dugNumberResponse = new List<string>();

            List<string> lstDugModelExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, "Make_Model_DUQ", "Model", apiVersion, contextName);
            List<string> lstDugNumberExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, "Make_Model_DUQ", "DuqNumber", apiVersion, contextName);
            for (int i = 0; i < _lstTypeIDResponse.Count; i++)
            {
                List<string> items = new List<string>();
                items =  _dictionary[_lstTypeIDResponse[i]];
                List<string> manNameResponse = new List<string>();
                manNameResponse = _stringDictionary[_lstTypeIDResponse[i]];
                for (int j = 0; j < items.Count; j++)
                {
                    string Url = requestUrl.Replace("{Id}", items[j]).Replace("{typeId}", _lstTypeIDResponse[i]);
                    var modelRequest = _requestUtils.SendRequest(HttpMethod.Get, Url, "", lstPara.Header);
                    Thread.Sleep(100);
                    if (modelRequest.Item1.ToString().Equals(""))
                    {
                        Debug.WriteLine("Request " + Url + " is error");
                    }
                    else
                    {
                        var modelResponse = JObject.Parse(modelRequest.Item1);
                        var result = modelResponse["ResultObj"];
                        if (String.IsNullOrEmpty(result.ToString()))
                        {
                            Assert.Equal("Result cannot be null", result.ToString());
                        }
                        else
                        {
                            for (int k = 0; k < result.Count(); k++)
                            {
                                dugModelResponse.Add(result[k]["Description"].ToString());
                                dugNumberResponse.Add(result[k]["Value"].ToString());
                                string s1 = _dicVehicleType[_lstTypeIDResponse[i]] + "/" + manNameResponse[j] + "/" + result[k]["Description"].ToString() + "/" + result[k]["Value"].ToString();
                                vehicleDatasResponse.Add(s1);
                            }
                        }
                    }
                }
            }
            vehicleDatasResponse.Sort();
            myListDataExcel.Sort();

            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "Make_Model_DUQ", "ModelInResponse", apiVersion, contextName, vehicleDatasResponse.Count, vehicleDatasResponse);
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "Make_Model_DUQ", "ModelInExcel", apiVersion, contextName, myListDataExcel.Count, myListDataExcel);

            List<string> testResult = new List<string>();
            List<string> dataInResponse = new List<string>();
            List<string> dataInExcel = new List<string>();
            for (int i = 0; i < myListDataExcel.Count; i++)
            {

                if (vehicleDatasResponse[i].Trim().ToLower().Contains(myListDataExcel[i].Trim().ToLower()))
                {
                    testResult.Add("Passed");
                }
                else
                {
                    testResult.Add("Failed");
                    _countDifference = _countDifference + 1;
                }
                dataInResponse.Add(vehicleDatasResponse[i]);
                dataInExcel.Add(myListDataExcel[i]);
            }
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "Make_Model_DUQ", "ModelResult", apiVersion, contextName, lstManExcel.Count, testResult);
            _differentModelValidation = myListDataExcel.Except(vehicleDatasResponse).ToList();
            //var _differentModelValidation2 = vehicleDatasResponse.Except(myListDataExcel).ToList();
            Boolean _modelListValidation = testResult.Contains("Failed");
            int index = testResult.IndexOf("Failed");
        }

        public static void GetBaseVehicle(string apiVersion, string contextName, string vehicleBodyName, string requestType, string sheetName)
        {
            List<string> lstBaseVehicleExcel = ReadDataFromExcels.ReadDataBySheetName(vehicleBodyName, sheetName, "Base Vehicle", apiVersion, contextName);
            List<string> lstBaseVehicleResponse = new List<string>();
            string url = GetURL(requestType);
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, vehicleBodyName);
            var response = _requestUtils.SendRequest(HttpMethod.Get, url, "", lstPara.Header);
            Thread.Sleep(100);
            var baseVehicleResponseBody = JObject.Parse(response.Item1);
            var result = baseVehicleResponseBody["ResultObj"];
            List<string> dataInResponse = new List<string>();
            List<string> dataInExcel = new List<string>();
            lstBaseVehicleExcel.Sort();

            for (int i = 0; i < result.Count(); i++)
            {

                lstBaseVehicleResponse.Add(result[i]["Description"].ToString());
            }
            lstBaseVehicleResponse.Sort();
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "BaseVehicles", "DataInResponse", apiVersion, contextName, lstBaseVehicleExcel.Count, lstBaseVehicleExcel);
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "BaseVehicles", "DataInExcel", apiVersion, contextName, lstBaseVehicleResponse.Count, lstBaseVehicleResponse);

            for (int i = 0; i < lstBaseVehicleExcel.Count; i++)
            {

                if (lstBaseVehicleResponse[i].Trim().ToLower().Contains(lstBaseVehicleExcel[i].Trim().ToLower()))
                {
                    _testResult.Add("Passed");
                }
                else
                {
                    _testResult.Add("Failed");
                    _countDifference = _countDifference + 1;
                }
                dataInResponse.Add(lstBaseVehicleResponse[i]);
                dataInExcel.Add(lstBaseVehicleExcel[i]);
            }
            WriteDataToExcels.WriteDataToSheetName(vehicleBodyName, "BaseVehicles", "Result", apiVersion, contextName, lstBaseVehicleExcel.Count, _testResult);
            
            _lstBaseVehicleValidation = lstBaseVehicleExcel.Except(lstBaseVehicleResponse).ToList();
        }

        public static void VerifyResponse()
        {
            Assert.True(_resultToVerify);
        }

        public static void VerifyMakeModelDUQ()
        {
            //Assert.True(_lstMakeModelDUQTypeValidation);
            Assert.True(_lstMakeModelDUQManValidation.Count == 0);
        }

        public static void VefiryBaseVehicles()
        {
            Assert.True(_countDifference == 0);
        }

        public static void VerifyGetModel()
        {
            //Assert.True(_differentModelValidation.Count == 0);
            Assert.True(_countDifference == 0);
        }

        public static string GetURL(string requestType)
        {
            Console.WriteLine("url-------", _url);
            if (requestType.Equals("manufacturer"))
            {
                _url = _url.Replace("vehicle-types", "manufactures?vehicleTypeId={Id}");
            }
            if (requestType.Equals("model"))
            {
                _url = _url.Replace("manufactures?vehicleTypeId={Id}", "models?manufacturerId={Id}&VehicleTypeId={typeId}").Replace("vehicle-types", "models?manufacturerId={Id}&VehicleTypeId={typeId}");
            }
            if (requestType.Equals("basevehiclemake"))
            {
                _url = _url.Replace("vehicle-types", "basevehiclemake");
            }
            return _url;
        }
    }

}
