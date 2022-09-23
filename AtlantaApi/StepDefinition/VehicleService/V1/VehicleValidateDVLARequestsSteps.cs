using ProjectCore.ApiCore.Common;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    [Binding]
    public class VehicleValidateDVLARequestsSteps
    {

        private string _apiVersion;
        private string _contextName;
        [Given(@"User has DVLA infos")]
        public void GivenUserHasDVLAInfos(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User sends DVLA Get Request using (.*) and (.*) and (.*) using (.*)")]
        public void WhenUserSendsDVLAGetRequest(string registrationNumber, int requestTime, string isToday, string key)
        {

            if (isToday.Equals("Yes"))
            {
                VehicleDVLADatabase.UpdateExpiresDateTime(registrationNumber);
            }
            if (isToday.Equals("No"))
            {
                VehicleDVLADatabase.DecreaseExpiresDateTime(registrationNumber);
            }
            VehicleValidation.SendDVLARequest(_apiVersion, _contextName, registrationNumber, requestTime, key);        
        }

        [When(@"User sends DVLA Get Request with (.*) and (.*) using (.*)")]
        public void WhenUserSendsDVLAGetRequestUsing(string registrationNumber, int requestTime, string key)
        {
            /** incase want to delete the record on RequestLog table, un-comment these items **/
            //VehicleDVLADatabase.DecreaseExpiresDateTime(registrationNumber);
            //VehicleDVLADatabase.DeleteRecordOnRequestLog("0.0.0.0");
            VehicleValidation.SendDVLARequest(_apiVersion, _contextName, registrationNumber, requestTime, key);

        }

        [When(@"User sends DVLA Get Request with (.*) not found in CDL using (.*)")]
        public void WhenUserSendsDVLAGetRequestWithNotFoundInCDL(string registrationNumber, string key)
        {
            VehicleValidation.SendDVLARequest(_apiVersion, _contextName, registrationNumber, 1, key);
        }

        [Then(@"The Response should be mapping with RequestLog record and (.*) using (.*) and (.*)")]
        public void ThenTheResponseShouldBeMappingWithRequestLogRecordAndAnd(string statusCode, string registrationNumber, string key)
        {
            VehicleValidation.ValidateRequestLog(statusCode, registrationNumber, key);
        }


        [Then(@"The Response should be mapping with CacheDB record and (.*) and (.*) using (.*) and (.*)")]
        public void ThenTheResponseShouldBeMappingWithCacheDBRecord(string message, string statuscode, string registrationNumber, string key)
        {
            VehicleValidation.ValidateDVLAResponseWithCacheDB(message, statuscode, registrationNumber, key);
        }
    }
}
