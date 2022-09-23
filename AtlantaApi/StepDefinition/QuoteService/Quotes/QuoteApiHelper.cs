using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.QuoteService.Quotes
{
    public class QuoteApiHelper
    {
        public static JObject GetJsonBody(JObject originalBody, List<string> fieldNames, string value, string resourcePath)
        {
            var fileNameToAdd = value.Replace("File: ", "").Trim();
            //var filePathToAdd = FileUtils.GetPayLoadSource(resourcePath + fileNameToAdd);
            var jsonBody = CreateRequestBodyWithDateChange(resourcePath + fileNameToAdd);
            originalBody = JObject.Parse(jsonBody);
            //string path = JsonHelper.GetPath(originalBody, fieldNames);
            //originalBody.SelectToken(path).Replace(objectToAdd.SelectToken(fieldNames[fieldNames.Count - 1]));
            return originalBody;
        }

        public static JObject AddJsonToBody(JObject originalBody, List<string> fieldNames, string value, string resourcePath)
        {
            var fileNameToAdd = value.Replace("File: ", "").Trim();
            var filePathToAdd = FileUtils.GetPayLoadSource(resourcePath + fileNameToAdd);
            var stringToAdd = File.ReadAllText(filePathToAdd);
            var objectToAdd = JObject.Parse(stringToAdd);
            string path = JsonHelper.GetPath(originalBody, fieldNames);
            originalBody.SelectToken(path).Replace(objectToAdd.SelectToken(fieldNames[fieldNames.Count - 1]));
            return originalBody;
        }


        public static string CreateRequestBodyWithDateChange(string jsonFile)
        {
            var requestJsonFilePath = FileUtils.GetPayLoadSource(jsonFile);
            var body = File.ReadAllText(requestJsonFilePath);
            string policyStartDate = DateTime.Now.ToString("yyyy-MM-dd");
            string startDate = DateTime.Now.ToString("yyyy-MM-dd");
            string expiryDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            body = body.Replace("<<PolicyStartDate>>", policyStartDate);
            body = body.Replace("<<StartDate>>", startDate);
            body = body.Replace("<<ExpiryDate>>", expiryDate);
            //var transformedBody = body
            //    .ReplaceHolder(new
            //    {
            //        startDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddThh:mm:ss.fffffffzzz"),
            //        expiryDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-ddThh:mm:ss.fffffffzzz"),
            //    });

            string futureDate = DateTime.Now.ToString("yyyy-MM-dd");
            body = body.Replace("<PolicyStartDate>", futureDate);
            return body;
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

        public static List<QuoteValidationData> GetDataFromExcelFile(string filePath, string sheetName)
        {
            var valueList = new List<QuoteValidationData>();
            if (File.Exists(filePath))
            {
                // var excel = new ExcelQueryFactory()
                var fInfo = new FileInfo(filePath);
                using (var package = new ExcelPackage(fInfo))
                {
                    var worksheet = package.Workbook.Worksheets[sheetName];
                    var colCount = worksheet.Dimension.Columns;
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string testcaseId = "";
                        string path = "";
                        string value = "";
                        string expectedMessage = "";
                        string expectedStt = "";
                        string actualMessage = "";
                        string actualSttCode = "";
                        string result = "";
                        string bugId = "";
                        try
                        {
                            //if (!String.IsNullOrEmpty(worksheet.Cells[row, 1].Value.ToString()))
                            //{
                                try
                                {
                                    testcaseId = worksheet.Cells[row, 1].Value.ToString().Trim();
                                }
                                catch (Exception ex)
                                {
                                    testcaseId = "";
                                }
                                try
                                {
                                    path = worksheet.Cells[row, 2].Value.ToString().Trim();
                                }
                                catch (Exception ex)
                                {
                                    path = "";
                                }
                                try
                                {
                                    value = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    
                                }
                                catch (Exception ex)
                                {
                                    value = "";
                                }
                                try
                                {
                                    expectedMessage = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    
                                }
                                catch (Exception ex)
                                {
                                    expectedMessage = "";
                                }
                                try
                                {
                                    expectedStt = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    
                                }
                                catch (Exception ex)
                                {
                                    expectedStt = "";
                                }
                                try
                                {
                                    if (!String.IsNullOrEmpty(worksheet.Cells[row, 6].Value.ToString()))
                                    {
                                        bugId = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    bugId = "";
                                }
                            //try
                            //{
                            //    if (!String.IsNullOrEmpty(worksheet.Cells[row, 7].Value.ToString()))
                            //    {
                            //        result = worksheet.Cells[row, 7].Value.ToString().Trim();
                            //    }

                            //}
                            //catch (Exception ex)
                            //{
                            //    result = "";
                            //}
                        }
                       // }
                        catch (Exception ex)
                        {
                            testcaseId = "";
                        }

                        valueList.Add(new QuoteValidationData
                        {
                            TestcaseId = testcaseId,
                            Path = path,
                            Value = value,
                            ExpectedMessage = expectedMessage,
                            ExpectedStatusCode = expectedStt,
                            ActualMessage = actualMessage,
                            ActualStatusCode = actualSttCode,
                            Result = result,
                            BugID = bugId
                        });
                    }
                }
            }
            return valueList;
        }

        public static void ExportDataToExcelFile(List<QuoteValidationData> lstData, string destination, string sheetName)
        {
            var fInfo = new FileInfo(destination);
            var workbook = new ExcelPackage();
            using (var pck = new ExcelPackage(fInfo))
            {
                var mi = typeof(QuoteValidationData)
                    .GetProperties()
                    .Where(pi => pi.Name != "Col1")
                    .Select(pi => (MemberInfo)pi)
                    .ToArray();
                var worksheet = pck.Workbook.Worksheets.Add(sheetName);

                worksheet.Cells.LoadFromCollection(
                    lstData
                    , true
                    , TableStyles.Dark1
                    , BindingFlags.Public | BindingFlags.Instance
                    , mi);
                pck.Save();
            }
        }
    }


    public class QuoteDb
    {
        public Guid SessionId { get; set; }
        public string WebReference { get; set; }
        public string QuoteResponse { get; set; }
        public string PurchaseDetails { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int IsLock { get; set; }
    }
    public class FieldMapping
    {
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public string Level5 { get; set; }
        public string Level6 { get; set; }
        public string Level7 { get; set; }
        public string Level8 { get; set; }
        public string Level9 { get; set; }
        public string Value { get; set; }
        public string Description { get; internal set; }
    }

    public class QuoteValidationData
    {
        public string TestcaseId { get; set; }
        public string Path { get; set; }
        public string Value { get; set; }
        public string ExpectedMessage { get; set; }
        public string ExpectedStatusCode { get; set; }
        public string ActualMessage { get; set; }
        public string ActualStatusCode { get; set; }
        public string Result { get; set; }
        public string BugID { get; set; }

    }
    
}
