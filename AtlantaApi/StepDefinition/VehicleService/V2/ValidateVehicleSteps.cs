using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.VehicleService.V2
{
    [Binding]
    public class ValidateVehicleSteps
    {
        private string _token;
        private string _url;
        private string _vehicleBodyName;
        private string _apiVersion;
        private string _contextName;
        private string _actualMessages;
        private int _actualStatusCode;
        private string _make;

        SpecflowHelper _specflowHelper = new SpecflowHelper();
        RequestUtils _requestUtils = new RequestUtils();
        private Tuple<string, System.Net.HttpStatusCode> _vehicleResponse;

        [Given(@"User has vehicle body")]
        public void GivenUserHasAVehicleBody(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _vehicleBodyName = paramValues["VehicleRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User send Vehicle Search service normal case with (.*)")]
        public void WhenTheCustomerCallVehicleSearchNormalCase(string make)
        {
            _token = Common.GetToken();
            _vehicleResponse = VehicleCommon.VehicleSearchNormalCase(_vehicleBodyName, _apiVersion, _contextName, _token);
            _actualStatusCode = (int)_vehicleResponse.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = _vehicleResponse.Item2.ToString();

            }
            else

                _actualMessages = ResponseUtils.GetResponseMessage(_vehicleResponse);
            _make = make;

        }

        [Then(@"Response format shown (.*)")]
        public void ThenResponseFormatShown(string typeOfValidate)
        {
            var jResponseQuoteBody = JObject.Parse(_vehicleResponse.Item1);
            var jTokenVehicle = jResponseQuoteBody.SelectToken("$..Vehicles");
            var jTokenYearOfManufactures = jResponseQuoteBody.SelectToken("$..YearOfManufactures");
            var jTokenFuelTypes = jResponseQuoteBody.SelectToken("$..FuelTypes");
            var jTokenTransmissions = jResponseQuoteBody.SelectToken("$..Transmissions");
            List<JToken> lstVehicle = jTokenVehicle.ToList();
            List<JToken> lstYearOfManufactures = jTokenYearOfManufactures.ToList();
            List<JToken> lstFuelTypes = jTokenFuelTypes.ToList();
            List<JToken> lstTransmissions = jTokenTransmissions.ToList();

            switch (typeOfValidate)
            {
                case "format":
                    //Validate FuelType format
                    VehicleCommon.CheckFuelTypesFormat(lstFuelTypes);
                    //Validate Transmission format
                    VehicleCommon.CheckTransmissionFormat(lstTransmissions);
                    //Validate YearOfManufactures format
                    VehicleCommon.CheckYearOfManufactureFormat(lstYearOfManufactures);
                    //Validate Vihicle List Format
                    VehicleCommon.CheckListVehicleFormat(lstVehicle, _make);
                    break;
                case "CompareYearOfManufactors":
                    //Validate year in Vehicle list is same with YearOfManufactures
                    VehicleCommon.CompareYearOfManufactors(lstVehicle, lstYearOfManufactures);
                    break;
                case "ValidateTransmissionTypesByFuelTypes":
                    //Validate TranmistionTypes and FuelTypes Responses are mapping
                    VehicleCommon.ValidateTransmissionTypesByFuelTypes(lstTransmissions, lstFuelTypes, jTokenTransmissions, jTokenFuelTypes);
                    break;
                case "VerifyYearOfManufactureFuelTypesAndTransmissionTypes":
                    //Validate response returns Tranmisstion types and Fuel types following Year Of Manufactures
                    VehicleCommon.VerifyYearOfManufactureFuelTypesAndTransmissionTypes(lstTransmissions, lstYearOfManufactures, lstFuelTypes);
                    break;
                default:
                    Console.WriteLine("No TestCase Found");
                    break;
            }
            Console.WriteLine("Debug");
        }

        [Then(@"The Vehicle response format (.*)")]
        public void ThenVehicleResponseFormat(string typeOfValidate)
        {
            var jResponseQuoteBody = JObject.Parse(_vehicleResponse.Item1);
            var jTokenVehicle = jResponseQuoteBody.SelectToken("$..ResultObj");
            List<JToken> lstVehicle = jTokenVehicle.ToList();
            foreach (var item in lstVehicle)
            {
                var abiCode = item.SelectToken("$..AbiCode").ToString();
                var make = item.SelectToken("$..Make").ToString();
                var model = item.SelectToken("$..Model").ToString();
                var engineCc = item.SelectToken("$..EngineCc").ToString();
                var yearOfManufactures = item.SelectToken("$..YearOfManufacture").ToString();
                var fuelTypes = item.SelectToken("$..FuelType").ToString();
                var transmissions = item.SelectToken("$..Transmission").ToString();

                switch (typeOfValidate)
                {
                    case "AllField":
                        CheckAbiCodeFormat(abiCode);
                        CheckMakeFormat(make);
                        CheckModelFormat(model);
                        CheckEngineCcFormat(engineCc);
                        CheckFuelTypesFormat(fuelTypes);
                        CheckTransmissionFormat(transmissions);
                        CheckYearOfManufactureFormat(yearOfManufactures);
                        break;
                    case "VehicleList":
                        CheckAbiCodeFormat(abiCode);
                        CheckMakeFormat(make);
                        CheckModelFormat(model);
                        CheckEngineCcFormat(engineCc);
                        CheckFuelTypesFormat(fuelTypes);
                        CheckTransmissionFormat(transmissions);
                        CheckYearOfManufactureFormat(yearOfManufactures);
                        break;
                    case "YearOfManufacture":
                        CheckYearOfManufactureFormat(yearOfManufactures);
                        break;
                    case "FuelTypes":
                        CheckFuelTypesFormat(fuelTypes);
                        break;
                    case "Transmission":
                        CheckTransmissionFormat(transmissions);
                        break;
                }
            }
        }
        public void CheckFuelTypesFormat(string fuelType)
        {
            Assert.True(!String.IsNullOrEmpty(fuelType));
        }
        public void CheckTransmissionFormat(string transmission)
        {
            Assert.True(!String.IsNullOrEmpty(transmission));
        }
        public void CheckYearOfManufactureFormat(string yearOfManufacture)
        {
            Assert.True(!String.IsNullOrEmpty(yearOfManufacture));
        }
        public void CheckAbiCodeFormat(string abiCode)
        {
            Assert.True(!String.IsNullOrEmpty(abiCode));
        }
        public void CheckMakeFormat(string make)
        {
            Assert.True(!String.IsNullOrEmpty(make));
        }
        public void CheckModelFormat(string model)
        {
            Assert.True(!String.IsNullOrEmpty(model));
        }
        public void CheckEngineCcFormat(string engineCc)
        {
            Assert.True(!String.IsNullOrEmpty(engineCc));
        }
    }
}
