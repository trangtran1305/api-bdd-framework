using AtlantaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace AtlantaApi.StepDefinition.VehicleService
{
    class VehicleCommon
    {
        
        
        public static string GetVehicleURL(string jsonBodyName, string apiVersion, string contextName)
        {
            string url = "";
            SpecflowHelper specflowHelper = new SpecflowHelper();

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            if (jsonBodyName.ToLower().Contains("vehiclesearch"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleSearch);

            }
            else if (jsonBodyName.ToLower().Contains("manufactures"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures);
            }
            return url;
        }
        public static Tuple<string, System.Net.HttpStatusCode> VehicleSearchNormalCase(string jsonBodyName, string apiVersion, string contextName, string token)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            RequestUtils requestUtils = new RequestUtils();
            string url = GetVehicleURL(jsonBodyName, apiVersion, contextName);
            string jsonBody = Common.ReadFileJson(jsonBodyName, apiVersion, contextName);
            var context = specflowHelper.GetContextFromConfig(contextName);
            var header = requestUtils.GetHeader(context, token);

            Tuple<string, System.Net.HttpStatusCode> response = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            return response;
        }

        public static void CheckFuelTypesFormat(List<JToken> lstFuelTypes)
        {
            foreach (var fuelTypes in lstFuelTypes)
            {
                var year = fuelTypes["Year"];
                var Types = fuelTypes["Types"];
                if (Types is JArray)
                {
                    foreach (string type in Types)
                    {
                        Assert.True(type == "P" || type == "D" || type == "E");
                    }

                }
            }
        }

        public static void CheckTransmissionFormat(List<JToken> lstTransmissions)
        {
            foreach (var transmissions in lstTransmissions)
            {
                var year = transmissions["Year"];
                var transmissionTypes = transmissions["TransmissionTypes"];
                Regex regexYear = new Regex(@"[\d]");
                Assert.Matches(regexYear, year.ToString());

                if (transmissionTypes is JArray)
                {
                    foreach (var type in transmissionTypes)
                    {
                        var fuelType = type["FuelType"];
                        var types = type["Types"];
                    }

                }
            }
        }

        public static void CheckYearOfManufactureFormat(List<JToken> lstYearOfManufactures)
        {
            List<int> lstIntYearOfManufactures = new List<int>();
            foreach (var year in lstYearOfManufactures)
            {
                lstIntYearOfManufactures.Add(Int32.Parse(year.ToString()));
            }
            for (int i = 0; i < lstIntYearOfManufactures.Count - 1; i++)
            {
                Assert.True(lstIntYearOfManufactures[i] > lstIntYearOfManufactures[i + 1]);
            }

        }
        public static Tuple<string, System.Net.HttpStatusCode> VehicleSearch(string jsonBodyName, List<string> fieldNames, string value, string apiVersion, string contextName, string token)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            RequestUtils requestUtils = new RequestUtils();
            string url = GetVehicleURL(jsonBodyName, apiVersion, contextName);
            string jsonBody = Common.ReadFileJson(jsonBodyName, apiVersion, contextName);
            var jObject = JObject.Parse(jsonBody);
            JsonHelper.EditValue(jObject, fieldNames, value);
            jsonBody = JsonConvert.SerializeObject(jObject);
            var context = specflowHelper.GetContextFromConfig(contextName);
            var header = requestUtils.GetHeader(context, token);

            Tuple<string, System.Net.HttpStatusCode> response = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            return response;
        }
        public static void CheckListVehicleFormat(List<JToken> lstVehicle, string _make)
        {
            foreach (var item in lstVehicle)
            {
                string make = item["Make"].ToString();
                string model = item["Model"].ToString();
                string YearOfManufactures = item["YearOfManufacture"].ToString();
                string FuelType = item["FuelType"].ToString();
                string Transmission = item["Transmission"].ToString();
                Assert.True(!String.IsNullOrEmpty(make) && !String.IsNullOrEmpty(model) && !String.IsNullOrEmpty(YearOfManufactures) &&
                    !String.IsNullOrEmpty(FuelType) && !String.IsNullOrEmpty(Transmission));
                Assert.Equal(make, _make);
            }

        }
        public static void VerifyYearOfManufactureFuelTypesAndTransmissionTypes(List<JToken> lstTransmissions, List<JToken> lstYearOfManufactures, List<JToken> lstFuelTypes)
        {
            Assert.True(lstFuelTypes.Count == lstTransmissions.Count);
            Assert.True(lstFuelTypes.Count == lstYearOfManufactures.Count);
        }

        public static void ValidateTransmissionTypesByFuelTypes(List<JToken> lstTransmissions, List<JToken> lstFuelTypes, JToken jTokenTransmissions, JToken JjTokenFuelTypes)
        {

            JObject _json = new JObject();
            List<JToken> newLstFromTranmission = new List<JToken>();
            List<JToken> newLstFromFuelTyes = new List<JToken>();
            for (int i = 0; i < lstTransmissions.Count; i++)
            {
                _json = jTokenTransmissions[i].ToObject<JObject>();
                string fuelTypes = _json["TransmissionTypes"][0]["FuelType"].ToString();
                Vehicle vh = new Vehicle();
                vh.Year = (int)_json["Year"];
                vh.Types = fuelTypes;
                string json = JsonConvert.SerializeObject(vh);
                newLstFromTranmission.Add(json);
            }

            for (int i = 0; i < lstFuelTypes.Count; i++)
            {
                _json = JjTokenFuelTypes[i].ToObject<JObject>();
                string types = _json["Types"].ToString();
                Vehicle vh = new Vehicle();
                vh.Year = (int)_json["Year"]; ;
                vh.Types = types.Replace("[\r\n  \"", "").Replace("\"\r\n]", "");
                string json = JsonConvert.SerializeObject(vh);
                newLstFromFuelTyes.Add(json);
            }
            var result = ScrambledEquals(newLstFromFuelTyes, newLstFromTranmission);
            Assert.True(result);

        }

        public static void CompareYearOfManufactors(List<JToken> lstVehicle, List<JToken> lstYearOfManufactures)
        {
            var _lstYearOfVehicle = new List<int>();
            var _lstYearOfManufactures = new List<int>();
            JObject _json = new JObject();
            for (int i = 0; i < lstVehicle.Count; i++)
            {
                _json = lstVehicle[i].ToObject<JObject>();
                int _yearMin = (int)_json["From"];
                int _yearMax = (int)_json["To"];
                _lstYearOfVehicle.Add(_yearMin);
                _lstYearOfVehicle.Add(_yearMax);
            }
            for (int i = 0; i < lstYearOfManufactures.Count; i++)
            {
                _lstYearOfManufactures.Add((int)lstYearOfManufactures[i]);
            }
            _lstYearOfVehicle.Sort();
            _lstYearOfManufactures.Sort();
            string firstYear = FindFirstElement(_lstYearOfVehicle);
            string lastYear = FindLastElement(_lstYearOfVehicle);
            Assert.Equal(FindFirstElement(_lstYearOfVehicle), FindFirstElement(_lstYearOfManufactures));
            Assert.Equal(FindLastElement(_lstYearOfVehicle), FindLastElement(_lstYearOfManufactures));
        }
        public static string FindFirstElement(List<int> listItem)
        {
            string firstElement = listItem[0].ToString();
            return firstElement;
        }

        public static string FindLastElement(List<int> listItem)
        {
            string lastElement = listItem[listItem.Count - 1].ToString();
            return lastElement;
        }

        public static bool ScrambledEquals(List<JToken> x, List<JToken> y)
        {
            return x.Count == y.Count && !x.Except(y).Any();
        }
        public static string CreateRequestBodyWithDateChange(string jsonFile)
        {
            var requestJsonFilePath = FileUtils.GetPayLoadSource(jsonFile);
            var body = File.ReadAllText(requestJsonFilePath);
            body = body.Replace("\\b", " ");
            return body;
        }



    }

}
