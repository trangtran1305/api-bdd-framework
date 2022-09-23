using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.StepDefinition.QuoteService.Quotes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AtlantaApi.StepDefinition.PaymentService
{
    class PaymentFunctions
    {
        public static string CreateRequestBodyForRegisterPayment(string filePath, string sessionId)
        {
            string jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["SessionId"] = sessionId;
            var jobject = JObject.Parse(jsonBody);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }

        public static string CreateRequestBodyNormalCaseForWebHook(string sessionId, string webReference, string filePath)
        {
            if (sessionId.Equals("null"))
            {
                sessionId = null;
            }
            string jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["SessionID"] = sessionId;
            jObject["WebReference"] = webReference;
            var jobject = JObject.Parse(jsonBody);
            var kvList = jObject
                  .Properties()
                  .Select(p => $"{p.Name}={WebUtility.UrlEncode(p.Value.Value<string>())}");

            var formBody = string.Join('&', kvList);

            //const string tempFile = "temp_wrapUp.body";

            //File.WriteAllText(tempFile, formBody);
            return formBody;
        }

        public static string CreateRequestBodyForWebHook(string requestBodyName, Table table, string sessionId, string webReference, string filePath)
        {
            if (sessionId.Equals("null"))
            {
                sessionId = null;
            }
            string jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["SessionID"] = sessionId;
            jObject["WebReference"] = webReference;

            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = QuoteApiHelperPrepurchase.CreateKeyList(fieldMapping);
            string value = fieldMapping.Value;
            var today = DateTime.Now;
            if (value.Contains(">CurrentMonth"))
            {
                value = today.AddMonths(1).Month.ToString();
            } else if (value.Contains("<CurrentMonth"))
            {
                value = today.AddMonths(-1).Month.ToString();
            }
            else if (value.Contains(">CurrentYear"))
            {
                value = today.AddYears(1).Year.ToString();
            }
            else if (value.Contains("<CurrentYear"))
            {
                value = today.AddYears(-1).Year.ToString();
            }

            JsonHelper.EditValue(jObject, fieldNames, value);
            var jobject = JObject.Parse(jsonBody);
            var kvList = jObject
                  .Properties()
                  .Select(p => $"{p.Name}={WebUtility.UrlEncode(p.Value.Value<string>())}");

            var formBody = string.Join('&', kvList);


            return formBody;
        }
    }
}
