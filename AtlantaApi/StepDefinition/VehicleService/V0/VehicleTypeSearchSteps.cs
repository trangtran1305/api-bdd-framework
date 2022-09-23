using ProjectCore.ApiCore.Common;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.VehicleService.V0
{
    [Binding]
    class VehicleTypeSearchSteps
    {

        private string _vehicleBodyName;
        private string _apiVersion;
        private string _contextName;

        [Given(@"User has vehicle Type bodyjson")]
        public void GivenUserHasVehicleTypeBodyjson(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _vehicleBodyName = paramValues["VehicleRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User sends Search Vehicle Type request using (.*) and (.*) and (.*)")]
        public void WhenUserSendsSearchVehicleTypeRequestUsingAnd(string endpoint, string method, string key)
        {
            VehicleValidation.SendSearchVehicleType(_apiVersion, _contextName, _vehicleBodyName, endpoint, method, key);
        }

        [When(@"User sends Get Model request using (.*) with (.*) and (.*) and (.*)")]
        public void WhenUserSendsGetModelRequestUsingWithAnd(string method, string vehicleType, string manufacturerName, string key)
        {
            VehicleValidation.SendGetModelRequest(_apiVersion, _contextName, _vehicleBodyName,method, vehicleType, manufacturerName, key);
        }

        [When(@"User sends Get Model request with (.*) and (.*) and (.*) and (.*)")]
        public void WhenUserSendsGetModelRequestWithAndAndAnd(string vehicleType, string manufacturerName, string token, string key)
        {
            VehicleValidation.GetModelByAuthentication(_apiVersion, _contextName, _vehicleBodyName, token, vehicleType, manufacturerName, key);
        }


        [When(@"User sends Get Base Vehicle request using (.*) and (.*) and (.*)")]
        public void WhenUserSendsGetBaseVehicleRequestUsingAnd(string endpoint, string method, string key)
        {
            VehicleValidation.GetBaseVehicle(_apiVersion, _contextName, _vehicleBodyName, method, endpoint, key);
        }

        [Then(@"The response should be shown (.*) and (.*) and (.*)")]
        public void ThenTheResponseShouldBeShownAnd(string statusCode, string message, string key)
        {
            VehicleValidation.Validation(statusCode, message, key);
        }

    }
}
