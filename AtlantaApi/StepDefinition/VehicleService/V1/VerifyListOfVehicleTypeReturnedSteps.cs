using ProjectCore.ApiCore.Common;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    [Binding]
    public class VerifyListOfVehicleTypeReturnedWhenNoErrorSteps
    {

        private string _fileName;
        private string _apiVersion;
        private string _contextName;
        [Given(@"User has Vehicle Type API Information")]
        public void GivenUserHasVehicleTypeAPIInformation(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _fileName = paramValues["DataFile"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }


        [When(@"User sends get Vehicle Type request with (.*) and (.*)")]
        public void WhenUserSendsGetVehicleTypeRequest(string requestType, string sheetName)
        {
            VehicleGetType.SendGetTypeRequest(_apiVersion, _contextName, _fileName, requestType, sheetName);
            if (requestType.Equals("basevehiclemake"))
            {
                VehicleGetType.GetBaseVehicle(_apiVersion, _contextName, _fileName, requestType, sheetName);
            }
            else if (requestType.Equals("manufacturer"))
            {
                VehicleGetType.GetManufactures(_apiVersion, _contextName, _fileName, requestType);
            }
            else if (requestType.Equals("model"))
            {
                VehicleGetType.GetManufactures(_apiVersion, _contextName, _fileName, "manufacturer");
                VehicleGetType.GetModel(_apiVersion, _contextName, _fileName, requestType);
            }
           
        }
        
        [Then(@"The response should be shown as per Data File using (.*)")]
        public void ThenTheResponseShouldBeShownAsPerDataFile(string requestType)
        {
            
            if (requestType.Equals("manufacturer"))
            {
                VehicleGetType.VerifyMakeModelDUQ();
            }
            if (requestType.Equals("basevehiclemake"))
            {
                VehicleGetType.VefiryBaseVehicles();
            }
            if (requestType.Equals("vehicletypes"))
            {
                VehicleGetType.VerifyResponse();
            }
            if (requestType.Equals("model"))
            {
                VehicleGetType.VerifyGetModel();
            }
        }
    }
}
