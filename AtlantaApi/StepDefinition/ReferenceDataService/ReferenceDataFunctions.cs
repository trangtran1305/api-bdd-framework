using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.StepDefinition.QuoteService.Quotes;
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
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AtlantaApi.StepDefinition.ReferenceDataService
{
    public class ReferenceDataFunctions
    {
        static SpecflowHelper _specflowHelper = new SpecflowHelper();
        static RequestUtils _requestUtils = new RequestUtils();

        public static Dictionary<string, string> GetReferenceHeader(string context, string authorization = null)
        {
            var headerDict = new Dictionary<string, string>();
            headerDict.Add("Context", context);
            if (authorization != null)
            {
                headerDict.Add("Authorization", authorization);
            }

            return headerDict;
        }
        public static string GetReferenceDataURL(string jsonBodyName, string apiVersion, string contextName)
        {
            string url = "";
            SpecflowHelper specflowHelper = new SpecflowHelper();

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            if (jsonBodyName.ToLower().Contains("metadata"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ReferenceDataMetadata);

            }
            else if (jsonBodyName.ToLower().Contains("keyword"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ReferenceDataByKeyword);

            }
            return url;
        }

        public static string CreateRequestReferenceDataBody(string requestBodyName, Table table, string apiVersion, string contextName)
        {
            string jsonBody = Common.ReadFileJson(requestBodyName, apiVersion, contextName);
            var jObject = JObject.Parse(jsonBody);
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = QuoteApiHelper.CreateKeyList(fieldMapping);
            string value = fieldMapping.Value;

            if (value.Contains("File: "))
            {
                jObject = QuoteApiHelperPrepurchase.AddJsonToBody(requestBodyName, jObject, value, apiVersion, contextName);
            }
            else
            {
                JsonHelper.EditValue(jObject, fieldNames, value);
            }
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }

        public static string CreateRequestBodyWithReferenceTypesChange(string requestBodyName, string value, string version, string contextName)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(version, contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            var requestJsonFilePath = Common.GetPathFile(requestBodyName, version, contextName);
            var jsonBody = File.ReadAllText(requestJsonFilePath);
            var jObject = JObject.Parse(jsonBody);
            jObject.SelectToken("$..ReferenceType").Replace(value);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }

        //public static void VerifyDatabaseAreMappedWithDataFile(string fileName, string referenceDataRequestBody, string apiVersion, string contextName)
        //{

        //    ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, referenceDataRequestBody);
        //    string filePath = Common.GetPathFile(fileName, apiVersion, contextName);

        //    var referenceDataHelper = new ReferenceDataHelper();
        //    List<string> lstSheetName = new List<string>();
        //    lstSheetName = referenceDataHelper.GetSheetsName(filePath);
        //    if (lstSheetName.Count == 0)
        //    {
        //        Assert.Equal("Valid", "Data file is invalid");
        //    }
        //    else
        //    {
        //        string testResultFilePath = filePath.Replace(".xlsx", "TestResult") + (".xlsx");
        //        var fileInfo = new FileInfo(testResultFilePath);
        //        if (fileInfo.Exists)
        //            fileInfo.Delete();
        //        string referenceType;
        //        int _diff = 0;
        //        for (int i = 0; i < lstSheetName.Count; i++)
        //        {
        //            List<ReferenceTypeValue> lstItems = new List<ReferenceTypeValue>();
        //            referenceType = lstSheetName[i];
        //            var lstDataExcel = referenceDataHelper.GetDataFromExcelFile(filePath, referenceType);
        //            string jsonBody = ReferenceDataFunctions.CreateRequestBodyWithReferenceTypesChange(referenceDataRequestBody, referenceType, apiVersion, contextName);
        //            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
        //            int actualStatusCode = (int)response.Item2;
        //            string actualMessages = ResponseUtils.GetResponseMessage(response);

        //            if (actualStatusCode == 200)
        //            {
        //                var jResponse = JObject.Parse(response.Item1);
        //                var jTokenValues = jResponse.SelectToken("$..Values");
        //                List<ReferenceTypeValue> lstValuesResponse = new List<ReferenceTypeValue>();
        //                if (jTokenValues is JArray)
        //                {
        //                    foreach (var reference in jTokenValues)
        //                    {
        //                        var name = reference["Name"];
        //                        var value = reference["Value"];
        //                        ReferenceTypeValue item = new ReferenceTypeValue();
        //                        item.SourceText = name.ToString();
        //                        item.SourceValue = value.ToString();
        //                        lstValuesResponse.Add(item);
        //                    }
        //                }
        //                for (int j = 0; j < lstDataExcel.Count; j++)
        //                {
        //                    string categoryNameExcel = lstDataExcel[j].CategoryName;
        //                    string sourceTextExcel = lstDataExcel[j].SourceText;
        //                    string sourceValueExcel = lstDataExcel[j].SourceValue;
        //                    string sortOrderExcel = lstDataExcel[j].SortOrder;
        //                    string transformedTextExcel = lstDataExcel[j].TransformedText;
        //                    string transformedOrderExcel = lstDataExcel[j].TransformedOrder;
        //                    string isShowExcel = lstDataExcel[j].Show;
        //                    ReferenceTypeValue itemOrder = new ReferenceTypeValue();

        //                    if (!String.IsNullOrEmpty(transformedTextExcel) && isShowExcel == "1" && !String.IsNullOrEmpty(transformedOrderExcel))
        //                    {
        //                        itemOrder.SourceValue = sourceValueExcel;
        //                        itemOrder.SourceText = transformedTextExcel;
        //                        lstItems.Add(itemOrder);
        //                    }
        //                    else if (!String.IsNullOrEmpty(transformedTextExcel) && isShowExcel == "1" && String.IsNullOrEmpty(transformedOrderExcel))
        //                    {
        //                        itemOrder.SourceValue = sourceValueExcel;
        //                        itemOrder.SourceText = transformedTextExcel;
        //                        lstItems.Add(itemOrder);
        //                    }
        //                    else if (String.IsNullOrEmpty(transformedTextExcel) && (isShowExcel != "0") && sortOrderExcel != "" && sortOrderExcel != "NA")
        //                    {
        //                        itemOrder.SourceValue = sourceValueExcel;
        //                        itemOrder.SourceText = sourceTextExcel;
        //                        lstItems.Add(itemOrder);
        //                    }
        //                    else if (sortOrderExcel == "NA")
        //                    {
        //                        itemOrder.SourceValue = sourceValueExcel;
        //                        itemOrder.SourceText = sourceTextExcel;
        //                        lstItems.Add(itemOrder);
        //                    }
        //                }
        //                lstItems = lstItems.OrderBy(o => o.SourceValue).ToList();
        //                lstValuesResponse = lstValuesResponse.OrderBy(o => o.SourceValue).ToList();
        //                for (int k = 0; k < lstValuesResponse.Count; k++)
        //                {
        //                    //ReferenceTypeOrder itemOrder = new ReferenceTypeOrder();
        //                    if (lstValuesResponse[k].SourceValue == lstItems[k].SourceValue && lstValuesResponse[k].SourceText == lstItems[k].SourceText)
        //                    {
        //                        lstItems[k].TestResult = "Passed";
        //                        lstItems[k].ActualValue = lstValuesResponse[k].SourceValue;
        //                        lstItems[k].ActualText = lstValuesResponse[k].SourceText;
        //                    }
        //                    else
        //                    {
        //                        lstItems[k].TestResult = "Failed";
        //                        lstItems[k].ActualValue = lstValuesResponse[k].SourceValue;
        //                        lstItems[k].ActualText = lstValuesResponse[k].SourceText;
        //                        _diff++;
        //                    }
        //                    //lstOrder.Add(itemOrder);
        //                }
        //                referenceDataHelper.ExportDataToExcelFile(lstItems, testResultFilePath, referenceType);
        //            }
        //        }// end of a sheet
        //        Assert.Equal(0,_diff);

        //    }

        //}
        //public static void VerifyTransformedOrdered(string fileName, string referenceDataRequestBody, string apiVersion, string contextName)
        //{
        //    ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, referenceDataRequestBody);
        //    string filePath = Common.GetPathFile(fileName, apiVersion, contextName);

        //    var referenceDataHelper = new ReferenceDataHelper();
        //    List<string> lstSheetName = new List<string>();
        //    lstSheetName = referenceDataHelper.GetSheetsName(filePath);
        //    if (lstSheetName.Count == 0)
        //    {
        //        Assert.Equal("Valid", "Data file is invalid");
        //    } else
        //    {

        //        int _diff = 0;
        //        string testResultFilePath = filePath.Replace(".xlsx", "OrderTestResult") + (".xlsx");
        //        var fileInfo = new FileInfo(testResultFilePath);
        //        if (fileInfo.Exists)
        //            fileInfo.Delete();
        //        string referenceType;
        //        for (int i = 0; i < lstSheetName.Count; i++)
        //        {
        //            List<ReferenceTypeOrder> lstOrder = new List<ReferenceTypeOrder>();
        //            referenceType = lstSheetName[i];
        //            var lstDataExcel = referenceDataHelper.GetDataFromExcelFile(filePath, referenceType);
        //            string jsonBody = ReferenceDataFunctions.CreateRequestBodyWithReferenceTypesChange(referenceDataRequestBody, referenceType, apiVersion, contextName);
        //            var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
        //            int actualStatusCode = (int)response.Item2;
        //            string actualMessages = ResponseUtils.GetResponseMessage(response);
        //            if (actualStatusCode == 200)
        //            {
        //                var jResponse = JObject.Parse(response.Item1);
        //                var jTokenValues = jResponse.SelectToken("$..Values");
        //                List<ReferenceTypeValue> lstValuesResponse = new List<ReferenceTypeValue>();

        //                if (jTokenValues is JArray)
        //                {
        //                    foreach (var reference in jTokenValues)
        //                    {
        //                        var name = reference["Name"];
        //                        var value = reference["Value"];
        //                        ReferenceTypeValue itemReferenceType = new ReferenceTypeValue();
        //                        itemReferenceType.SourceText = name.ToString();
        //                        itemReferenceType.SourceValue = value.ToString();
        //                        lstValuesResponse.Add(itemReferenceType);
        //                    }
        //                }
        //                for (int j = 0; j < lstDataExcel.Count; j++)
        //                {
        //                    string categoryNameExcel = lstDataExcel[j].CategoryName;
        //                    string sourceTextExcel = lstDataExcel[j].SourceText;
        //                    string sourceValueExcel = lstDataExcel[j].SourceValue;
        //                    string sortOrderExcel = lstDataExcel[j].SortOrder;
        //                    string transformedTextExcel = lstDataExcel[j].TransformedText;
        //                    string transformedOrderExcel = lstDataExcel[j].TransformedOrder;
        //                    string isShowExcel = lstDataExcel[j].Show;

        //                    ReferenceTypeOrder itemOrder = new ReferenceTypeOrder();
        //                    itemOrder.Source = sourceValueExcel.ToString();

        //                    if (!String.IsNullOrEmpty(transformedTextExcel) && isShowExcel == "1" && !String.IsNullOrEmpty(transformedOrderExcel))
        //                    {
        //                        itemOrder.Order = Int32.Parse(transformedOrderExcel);
        //                        lstOrder.Add(itemOrder);
        //                    }
        //                    else if (!String.IsNullOrEmpty(transformedTextExcel) && isShowExcel == "1" && String.IsNullOrEmpty(transformedOrderExcel))
        //                    {
        //                        itemOrder.Order = Int32.Parse(sortOrderExcel);
        //                        lstOrder.Add(itemOrder);
        //                    }
        //                    else if (String.IsNullOrEmpty(transformedTextExcel) && (isShowExcel != "0") && sortOrderExcel !="" && sortOrderExcel != "NA")
        //                    {
        //                        itemOrder.Order = Int32.Parse(sortOrderExcel);
        //                        lstOrder.Add(itemOrder);
        //                    }
        //                    else if (sortOrderExcel == "NA")
        //                    {
        //                        itemOrder.Source = lstValuesResponse[j].SourceValue;
        //                        lstOrder.Add(itemOrder);
        //                    }


        //                }
        //                lstOrder = lstOrder.OrderBy(o => o.Order).ToList();
        //                //lstOrder = lstOrder.OrderBy(o => o.Order).ToList();
        //                //lstOrder.Sort((x, y) => x.Order.CompareTo(y.Order));

        //                for (int k = 0; k < lstValuesResponse.Count; k++)
        //                {
        //                    ReferenceTypeOrder itemOrder = new ReferenceTypeOrder();
        //                    if (lstValuesResponse[k].SourceValue == lstOrder[k].Source)
        //                    {
        //                        lstOrder[k].TestResult = "Passed";
        //                    }
        //                    else
        //                    {
        //                        lstOrder[k].TestResult = "Failed";
        //                        lstOrder[k].Actual = "Wrong order data";
        //                        _diff++;
        //                    }
        //                    //lstOrder.Add(itemOrder);
        //                }
        //                referenceDataHelper.ExportDataOrderToExcelFile(lstOrder, testResultFilePath, referenceType);
        //            }
        //        }//end of a sheet

        //        Assert.Equal(0, _diff);
        //    }
        public static void VerifyDatabaseAreMappedWithDataFile(string fileName, string referenceDataRequestBody, string apiVersion, string contextName)
        {

            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, referenceDataRequestBody);
            string filePath = Common.GetPathFile(fileName, apiVersion, contextName);

            var referenceDataHelper = new ReferenceDataHelper();
            List<string> lstSheetName = new List<string>();
            lstSheetName = referenceDataHelper.GetSheetsName(filePath);
            if (lstSheetName.Count == 0)
            {
                Assert.Equal("Valid", "Data file is invalid");
            }
            else
            {
                string testResultFilePath = filePath.Replace(".xlsx", "TestResult") + (".xlsx");
                var fileInfo = new FileInfo(testResultFilePath);
                if (fileInfo.Exists)
                    fileInfo.Delete();
                string referenceType;
                int _diff = 0;
                for (int i = 0; i < lstSheetName.Count; i++)
                {
                    List<ReferenceTypeValue> lstItems = new List<ReferenceTypeValue>();
                    referenceType = lstSheetName[i];
                    var lstDataExcel = referenceDataHelper.GetDataFromExcelFile(filePath, referenceType);
                    string jsonBody = ReferenceDataFunctions.CreateRequestBodyWithReferenceTypesChange(referenceDataRequestBody, referenceType, apiVersion, contextName);
                    var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
                    //Thread.Sleep(200);
                    int actualStatusCode = (int)response.Item2;
                    string actualMessages = ResponseUtils.GetResponseMessage(response);

                    if (actualStatusCode == 200)
                    {
                        var jResponse = JObject.Parse(response.Item1);
                        var jTokenValues = jResponse.SelectToken("$..Values");
                        List<ReferenceTypeValue> lstValuesResponse = new List<ReferenceTypeValue>();
                        if (jTokenValues is JArray)
                        {
                            foreach (var reference in jTokenValues)
                            {
                                var name = reference["Name"];
                                var value = reference["Value"];
                                ReferenceTypeValue item = new ReferenceTypeValue();
                                item.SourceText = name.ToString().Trim();
                                item.SourceValue = value.ToString().Trim();
                                lstValuesResponse.Add(item);
                            }
                        }
                        for (int j = 0; j < lstDataExcel.Count; j++)
                        {
                            string categoryNameExcel = lstDataExcel[j].CategoryName;
                            string sourceTextExcel = lstDataExcel[j].SourceText.Trim();
                            string sourceValueExcel = lstDataExcel[j].SourceValue.Trim();
                            string sortOrderExcel = lstDataExcel[j].SortOrder;
                            string transformedTextExcel = lstDataExcel[j].TransformedText.Trim();
                            string transformedOrderExcel = lstDataExcel[j].TransformedOrder.Trim();
                            string isShowExcel = lstDataExcel[j].Show;
                            ReferenceTypeValue itemOrder = new ReferenceTypeValue();
                            itemOrder.BugID = lstDataExcel[j].BugID;
                            if (!String.IsNullOrEmpty(transformedTextExcel) && isShowExcel != "0")
                            {
                                itemOrder.SourceValue = sourceValueExcel;
                                itemOrder.SourceText = transformedTextExcel;
                                lstItems.Add(itemOrder);
                            }
                            else if (String.IsNullOrEmpty(transformedTextExcel) && (isShowExcel != "0") && sourceValueExcel != "")
                            {
                                itemOrder.SourceValue = sourceValueExcel;
                                itemOrder.SourceText = sourceTextExcel;
                                lstItems.Add(itemOrder);
                            }
                        }
                        lstItems = lstItems.OrderBy(o => o.SourceValue).ToList();
                        lstValuesResponse = lstValuesResponse.OrderBy(o => o.SourceValue).ToList();

                        if (lstValuesResponse.Count != lstItems.Count)
                        {
                            var count = lstValuesResponse.Count;
                            for (int r = 0; r < count; r++)
                            {
                                var index1 = lstItems.FindIndex(item => item.SourceValue == lstValuesResponse[r].SourceValue);
                                var index2 = lstItems.FindIndex(item => item.SourceText == lstValuesResponse[r].SourceText);
                                if (index1 >= 0 || index2 >= 0)
                                {
                                    var index = (index1 > 0) ? index1 : index2;
                                    if (lstValuesResponse[r].SourceValue == lstItems[index].SourceValue && lstValuesResponse[r].SourceText == lstItems[index].SourceText)
                                    {
                                        lstItems[index].TestResult = "Passed";
                                    }
                                    else
                                    {
                                        lstItems[index].TestResult = "Failed: not matched";
                                        _diff++;
                                    }
                                    lstItems[index].ActualValue = lstValuesResponse[r].SourceValue;
                                    lstItems[index].ActualText = lstValuesResponse[r].SourceText;
                                }
                                else
                                {
                                    if (lstValuesResponse.Count > lstItems.Count)
                                    {
                                        ReferenceTypeValue itemOrder = new ReferenceTypeValue();
                                        itemOrder.TestResult = "Failed: Redundant in comparision with ref data";
                                        itemOrder.ActualValue = lstValuesResponse[r].SourceValue;
                                        itemOrder.ActualText = lstValuesResponse[r].SourceText;
                                        lstItems.Add(itemOrder);
                                        _diff++;
                                    }
                                    else
                                    {

                                        lstItems[r].TestResult = "Failed: Not match any item in ref data";
                                        lstItems[r].ActualValue = lstValuesResponse[r].SourceValue;
                                        lstItems[r].ActualText = lstValuesResponse[r].SourceText;
                                        _diff++;
                                    }
                                }

                            }
                            for (int n = 0; n < lstItems.Count; n++)
                            {
                                if (String.IsNullOrEmpty(lstItems[n].TestResult))
                                {
                                    lstItems[n].TestResult = "Failed: not match with response";
                                    _diff++;
                                }
                            }

                        }
                        else
                        {
                            for (int k = 0; k < lstValuesResponse.Count; k++)
                            {
                                if (lstValuesResponse[k].SourceValue == lstItems[k].SourceValue && lstValuesResponse[k].SourceText == lstItems[k].SourceText)
                                {
                                    lstItems[k].TestResult = "Passed";
                                    lstItems[k].ActualValue = lstValuesResponse[k].SourceValue;
                                    lstItems[k].ActualText = lstValuesResponse[k].SourceText;
                                }
                                else
                                {
                                    lstItems[k].TestResult = "Failed. Please refer BugID";
                                    lstItems[k].ActualValue = lstValuesResponse[k].SourceValue;
                                    lstItems[k].ActualText = lstValuesResponse[k].SourceText;
                                    //lstItems[k].BugID = lstDataExcel[k].BugID;

                                    if (String.IsNullOrEmpty(lstItems[k].BugID))
                                    {
                                        lstItems[k].TestResult = "Failed";
                                        _diff++;
                                    }
                                }
                            }
                        }
                        referenceDataHelper.ExportDataToExcelFile(lstItems, testResultFilePath, referenceType);
                    }
                }// end of a sheet
                Assert.Equal(0, _diff);
            }
        }
        public static void VerifyTransformedOrdered(string fileName, string referenceDataRequestBody, string apiVersion, string contextName)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, referenceDataRequestBody);
            string filePath = Common.GetPathFile(fileName, apiVersion, contextName);

            var referenceDataHelper = new ReferenceDataHelper();
            List<string> lstSheetName = new List<string>();
            lstSheetName = referenceDataHelper.GetSheetsName(filePath);
            if (lstSheetName.Count == 0)
            {
                Assert.Equal("Valid", "Data file is invalid");
            }
            else
            {
                int _diff = 0;
                string testResultFilePath = filePath.Replace(".xlsx", "OrderTestResult") + (".xlsx");
                var fileInfo = new FileInfo(testResultFilePath);
                if (fileInfo.Exists)
                    fileInfo.Delete();
                string referenceType;
                for (int i = 0; i < lstSheetName.Count; i++)
                {
                    List<ReferenceTypeOrder> lstOrderExcel = new List<ReferenceTypeOrder>();
                    referenceType = lstSheetName[i];
                    var lstDataExcel = referenceDataHelper.GetDataFromExcelFile(filePath, referenceType);
                    string jsonBody = ReferenceDataFunctions.CreateRequestBodyWithReferenceTypesChange(referenceDataRequestBody, referenceType, apiVersion, contextName);
                    var response = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
                    //Thread.Sleep(200);
                    int actualStatusCode = (int)response.Item2;
                    string actualMessages = ResponseUtils.GetResponseMessage(response);
                    if (actualStatusCode == 200)
                    {
                        var jResponse = JObject.Parse(response.Item1);
                        var jTokenValues = jResponse.SelectToken("$..Values");
                        List<ReferenceTypeValue> lstValuesResponse = new List<ReferenceTypeValue>();

                        if (jTokenValues is JArray)
                        {
                            foreach (var reference in jTokenValues)
                            {
                                var name = reference["Name"];
                                var value = reference["Value"];
                                ReferenceTypeValue itemReferenceType = new ReferenceTypeValue();
                                itemReferenceType.SourceText = name.ToString().Trim();
                                itemReferenceType.SourceValue = value.ToString().Trim();
                                lstValuesResponse.Add(itemReferenceType);
                            }
                        }
                        // run through out all sheets and get data that expected to be shown in response, save data in lstOrderExcel
                        for (int j = 0; j < lstDataExcel.Count; j++)
                        {
                            string categoryNameExcel = lstDataExcel[j].CategoryName;
                            string sourceTextExcel = lstDataExcel[j].SourceText.Trim();
                            string sourceValueExcel = lstDataExcel[j].SourceValue.Trim();
                            string sortOrderExcel = lstDataExcel[j].SortOrder;
                            string transformedTextExcel = lstDataExcel[j].TransformedText.Trim();
                            string transformedOrderExcel = lstDataExcel[j].TransformedOrder;
                            string isShowExcel = lstDataExcel[j].Show;

                            ReferenceTypeOrder itemOrder = new ReferenceTypeOrder();
                            itemOrder.BugID = lstDataExcel[j].BugID;
                            itemOrder.SourceValue = sourceValueExcel.ToString();
                            // Ignore order if sortOrderExcel and transformedOrderExcel are empty
                            if (isShowExcel != "0" && sourceValueExcel != "" && ((sortOrderExcel == "" && transformedOrderExcel == "")
                                || sortOrderExcel.ToLower() == "alphabetical" || transformedOrderExcel.ToLower() == "alphabetical"))
                            {
                                if (!String.IsNullOrEmpty(transformedTextExcel))
                                {
                                    itemOrder.SourceText = transformedTextExcel;
                                }
                                else
                                {
                                    itemOrder.SourceText = sourceTextExcel;
                                }
                                itemOrder.SourceValue = sourceValueExcel;
                                lstOrderExcel.Add(itemOrder);
                            }
                            // Actual order should be transformedOrderExcel if there is transformedOrderExcel
                            else if (isShowExcel != "0" && sourceValueExcel != "" && !String.IsNullOrEmpty(transformedOrderExcel))
                            {
                                itemOrder.Order = Int32.Parse(transformedOrderExcel);
                                lstOrderExcel.Add(itemOrder);
                            }
                            // else Actual order should be sortOrderExcel
                            else if (isShowExcel != "0" && sourceValueExcel != "" && sortOrderExcel != "")
                            {
                                itemOrder.Order = Int32.Parse(sortOrderExcel);
                                lstOrderExcel.Add(itemOrder);
                            }
                        }
                        if (lstOrderExcel[0].Order != lstOrderExcel[1].Order)
                        {
                            lstOrderExcel = lstOrderExcel.OrderBy(o => o.Order).ToList();
                        }
                        else
                        {
                            lstOrderExcel = lstOrderExcel.OrderBy(o => o.SourceValue).ToList();
                            lstValuesResponse = lstValuesResponse.OrderBy(o => o.SourceValue).ToList();
                        }
                        // check when number of responsed items are different
                        var baseCount = lstValuesResponse.Count;
                        if (baseCount != lstOrderExcel.Count)
                        {
                            for (int r = 0; r < baseCount; r++)
                            {
                                // if responsed item existed in ref data, index is index of responsed items in ref data
                                var index = lstOrderExcel.FindIndex(item => item.SourceValue == lstValuesResponse[r].SourceValue);
                                if (index >= 0)
                                {
                                    if (lstValuesResponse[r].SourceValue == lstOrderExcel[index].SourceValue)
                                    {
                                        lstOrderExcel[index].TestResult = "Passed";
                                    }
                                    else
                                    {
                                        lstOrderExcel[index].TestResult = "Failed: not matched";
                                        _diff++;
                                    }
                                    lstOrderExcel[index].Actual = lstValuesResponse[r].SourceValue;
                                }
                                else
                                {
                                    if (baseCount > lstOrderExcel.Count)
                                    {
                                        ReferenceTypeOrder item = new ReferenceTypeOrder();
                                        item.TestResult = "Failed: Redundant when compare with ref data";
                                        item.Actual = lstValuesResponse[r].SourceValue;
                                        lstOrderExcel.Add(item);
                                        _diff++;
                                    }
                                    else
                                    {

                                        lstOrderExcel[r].TestResult = "Failed: data in response not match source in ref data";
                                        lstOrderExcel[r].Actual = lstValuesResponse[r].SourceValue;
                                        _diff++;
                                    }
                                }
                            }
                            // in case data in ref data not existed in response: need to mark in ref data also
                            for (int n = 0; n < lstOrderExcel.Count; n++)
                            {
                                if (String.IsNullOrEmpty(lstOrderExcel[n].TestResult))
                                {
                                    lstOrderExcel[n].TestResult = "Failed: data not show in actual response";
                                    _diff++;
                                }
                            }
                        }
                        // Number of responsed items are matched, them compare data
                        else
                        {
                            for (int k = 0; k < baseCount; k++)
                            {
                                if (lstValuesResponse[k].SourceValue == lstOrderExcel[k].SourceValue)
                                {
                                    lstOrderExcel[k].TestResult = "Passed";
                                }
                                else
                                {
                                    lstOrderExcel[k].TestResult = "Failed. Please refer BugID"; 
                                    if (String.IsNullOrEmpty(lstOrderExcel[k].BugID))
                                    {
                                        lstOrderExcel[k].TestResult = "Failed";
                                        _diff++;
                                    }
                                }
                                lstOrderExcel[k].Actual = lstValuesResponse[k].SourceValue;
                            }
                        }
                        referenceDataHelper.ExportDataOrderToExcelFile(lstOrderExcel, testResultFilePath, referenceType);
                    }
                }//end of a sheet

                Assert.Equal(0, _diff);
            }
        }
    }
    
}
