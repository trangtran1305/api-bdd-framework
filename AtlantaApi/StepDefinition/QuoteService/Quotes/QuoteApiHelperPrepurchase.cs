using AtlantaApi.StepDefinition.QuoteService.Quotes;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.QuoteService
{
    public class QuoteApiHelperPrepurchase

    {
        public static JObject AddJsonToBody(string requestBodyName,JObject originalBody, string value, string apiVersion, string contextName)
        {
            var fileNameToAdd = value.Replace("File: ", "").Trim();
            string resourcePath = "";
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            resourcePath = PrepurchaseFunctions.ReturnPrepuchasePath(requestBodyName, serviceInfoAndContext);
            fileNameToAdd = Common.FormatString(fileNameToAdd);
            var filePathToAdd = FileUtils.GetPayLoadSource(resourcePath + fileNameToAdd);
            var stringToAdd = File.ReadAllText(filePathToAdd);
             originalBody = JObject.Parse(stringToAdd);

            return originalBody;
        }

        public static JObject AddJsonToBody(JObject originalBody,string resourcePath, List<string> fieldNames, string value, string apiVersion, string contextName)
        {
            var fileNameToAdd = value.Replace("File: ", "").Trim();
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);

            var filePathToAdd = FileUtils.GetPayLoadSource(resourcePath + fileNameToAdd);
            var stringToAdd = File.ReadAllText(filePathToAdd);
            var objectToAdd = JObject.Parse(stringToAdd);
            string path = JsonHelper.GetPath(originalBody, fieldNames);
            originalBody.SelectToken(path).Replace(objectToAdd.SelectToken(fieldNames[fieldNames.Count - 1]));

            return originalBody;
        }
        public static string CreateRequestBodyWithQuoteChange(string fileName,string sessionId,string webReference, string version, string contextName)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(version, contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            var resourcePath = serviceInfoAndContext.Item2.Quotes;
            var requestJsonFilePath = FileUtils.GetPayLoadSource(resourcePath + fileName);
            var jsonBody = File.ReadAllText(requestJsonFilePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["SessionId"] = sessionId;
            jObject["WebReference"] = webReference;
            var jobject = JObject.Parse(jsonBody);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }

        public static string CreateRequestBodyWithDateChange(string fileName, string version, string contextName)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(version, contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            var resourcePath = serviceInfoAndContext.Item2.Quotes;
            var requestJsonFilePath = FileUtils.GetPayLoadSource(resourcePath + fileName);
            var body = File.ReadAllText(requestJsonFilePath);
            string policyStartDate = DateTime.Now.ToString("yyyy-MM-dd");
            body = body.Replace("<<PolicyStartDate>>", policyStartDate);
            var transformedBody = body
                .ReplaceHolder(new
                {
                    StartDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fffffffzzz"),
                    ExpiryDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                });

            string futureDate = DateTime.Now.ToString("yyyy-MM-dd");
            transformedBody = transformedBody.Replace("<PolicyStartDate>", futureDate);
            return transformedBody;
        }

        public String GetJsonFilePath(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            return FileUtils.GetPayLoadSource(ServiceVersion.V0 + paramValues["JSON"]);
        }

        public String GetMethod(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            return paramValues["Method"];
        }
        public static List<string> CreateKeyList(FieldMapping fieldMapping)
        {
            var result = new List<string>();
            if (!String.IsNullOrEmpty(fieldMapping.Level1)) result.Add(fieldMapping.Level1);
            if (!String.IsNullOrEmpty(fieldMapping.Level2)) result.Add(fieldMapping.Level2);
            if (!String.IsNullOrEmpty(fieldMapping.Level3)) result.Add(fieldMapping.Level3);
            if (!String.IsNullOrEmpty(fieldMapping.Level4)) result.Add(fieldMapping.Level4);
            if (!String.IsNullOrEmpty(fieldMapping.Level5)) result.Add(fieldMapping.Level5);
            if (!String.IsNullOrEmpty(fieldMapping.Level6)) result.Add(fieldMapping.Level6);
            if (!String.IsNullOrEmpty(fieldMapping.Level7)) result.Add(fieldMapping.Level7);
            if (!String.IsNullOrEmpty(fieldMapping.Level8)) result.Add(fieldMapping.Level8);
            if (!String.IsNullOrEmpty(fieldMapping.Level9)) result.Add(fieldMapping.Level9);
            return result;
        }
    }

    public class QuoteDb
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string WebReference { get; set; }
        public string QuoteResponse { get; set; }
        public string PurchaseDetails { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int IsLock { get; set; }
        public string QuoteRequest { get; set; }
    }

    public class TrackingDb
    {
        public string Id { get; set; }
        public string InternalId { get; set; }
        public string WebReference { get; set; }
        public string CompanyCode { get; set; }
        public string PolicyType { get; set; }
        public string AffinityCode { get; set; }
        public string RequestType { get; set; }
        public string RequestXML { get; set; }
        public string ResponseXML { get; set; }
        public string ElapsedTime { get; set; }
        public DateTime DateCreated { get; set; }
        public string EmailSent { get; set; }
        public string RowVers { get; set; }
        public string TrackingOrder { get; set; }
        public string IsError { get; set; }
    }
    public class PurchaseDetails
    {
        public string Debit { get; set; }
        public string MarketingInfo { get; set; }
        public string PaymentInfo { get; set; }
        public string ExtraInfo { get; set; }
    }
   
}
