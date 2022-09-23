using AtlantaApi.StepDefinition.QuoteService.Quotes;
//using AtlantaApi.StepDefinition.TrackingService;
using AtlantaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AtlantaApi.StepDefinition.QuoteService.Recall
{
    public class RecallFunctions
    {

        public static string CreateRequestBodyWithWebReferenceChange(string filePath, string webReference)
        {
            var jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["WebReference"] = webReference;
            //var jobject = JObject.Parse(jsonBody);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }
        public static string CreateRequestBodyWithParametersChange(string filePath, string webReference, string postCode, string dateOfBirth)
        {
            var jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["WebReference"] = webReference;
            jObject["PostCode"] = postCode;
            jObject["DateOfBirth"] = dateOfBirth;
            //var jobject = JObject.Parse(jsonBody);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }

        public static string CreateRequestBodyWithDataChange(string jsonBody, Table table)
        {
            //var jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = new List<string>();
            if (!String.IsNullOrEmpty(fieldMapping.Level1)) fieldNames.Add(fieldMapping.Level1);
            string value = fieldMapping.Value;            
            JsonHelper.EditValue(jObject, fieldNames, value);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }
        //public static string CreateRequestBodyForRecallWithDataChange(string requestBodyName, Table table, string webReference, string filePath)
        //{
        //    if (webReference.Equals("null"))
        //    {
        //        webReference = null;
        //    }
        //    string jsonBody = File.ReadAllText(filePath);
        //    var jObject = JObject.Parse(jsonBody);
        //    FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
        //    var fieldNames = QuoteApiHelperPrepurchase.CreateKeyList(fieldMapping);
        //    string value = fieldMapping.Value;

        //    if (fieldNames[fieldNames.Count - 1].Equals("WebReference"))
        //    {
        //        if (value.Equals("null"))
        //        {
        //            value = null;
        //        }
        //        jObject["WebReference"] = value;
        //    }
        //    else
        //    {
        //        JsonHelper.EditValue(jObject, fieldNames, value);
        //        jObject["WebReference"] = webReference;

        //    }
        //    jsonBody = JsonConvert.SerializeObject(jObject);
        //    return jsonBody;
        //}

        public static string GetDoQuoteInRecallResponse(Tuple<string, System.Net.HttpStatusCode> recallResponse)
        {
            var jResponseQuoteBody = JObject.Parse(recallResponse.Item1);
            string doQuote = jResponseQuoteBody["ResultObj"]["DoQuote"].ToString();
            return doQuote;
        }

        //public static List<string> GetWebReferPostCodeDateOfBirth(List<TrackingModel> records)
        //{
        //    List<string> lstResult = new List<string>();
        //    XmlDocument doc = new XmlDocument();
        //    XmlNodeList policyStartDateList;
        //    XmlNodeList postCodeList;
        //    XmlNodeList dateOfBirthList;
        //    DateTime today = DateTime.Now;
        //    foreach (var record in records)
        //    {
        //        var requestXML = record.RequestXML;
        //        Thread.Sleep(2000);
        //        if (requestXML != null && requestXML != "")
        //        {
        //            doc.LoadXml(requestXML);
        //            try
        //            {
        //                policyStartDateList = doc.GetElementsByTagName("startDate");
        //                if (policyStartDateList.Count == 0)
        //                {
        //                    policyStartDateList = doc.GetElementsByTagName("inceptionDate");
        //                }
        //            }
        //            catch (Exception )
        //            {
        //                policyStartDateList = doc.GetElementsByTagName("inceptionDate");
        //            }
        //            string startDate = policyStartDateList[0].InnerText;
        //            DateTime oDate = Convert.ToDateTime(startDate);
        //            var policyStartDateShort = oDate.ToShortDateString();
        //            var todayDateShort = today.ToShortDateString();
        //            var policyStartDate = Convert.ToDateTime(policyStartDateShort);
        //            var dateToday = Convert.ToDateTime(todayDateShort);
        //            if (policyStartDate < dateToday)
        //            {

        //                postCodeList = doc.GetElementsByTagName("postCode");
        //                dateOfBirthList = doc.GetElementsByTagName("dateOfBirth");
        //                lstResult.Add(record.WebReference);
        //                lstResult.Add(postCodeList[0].InnerText);
        //                lstResult.Add(dateOfBirthList[0].InnerText);
        //                break;

        //            }

        //        }
        //    }
        //    return lstResult;

        //}
    }
}
