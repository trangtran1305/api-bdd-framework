using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

using OfficeOpenXml.FormulaParsing;
using OfficeOpenXml.Table;

namespace AtlantaApi.StepDefinition.ReferenceDataService
{
    public class ReferenceDataHelper : Steps
    {
        public List<ReferenceDataExcelModel> GetDataFromExcelFile(string filePath, string sheetName)
        {
            var valueList = new List<ReferenceDataExcelModel>();
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
                        string categoryName = "";
                        string sourceText = "";
                        string sourceValue = "";
                        string sortOrder = "";
                        string transformedText = "";
                        string transformedOrder = "";
                        string show = "";
                        string bugId = "";
                        try
                        {
                            //if (!String.IsNullOrEmpty(worksheet.Cells[row, 1].Value.ToString().Trim()))
                            //{
                                categoryName = worksheet.Cells[row, 1].Value.ToString();
                                try
                                {
                                    //if (!String.IsNullOrEmpty(worksheet.Cells[row, 2].Value.ToString()))
                                    //{
                                        sourceText = worksheet.Cells[row, 2].Value.ToString();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    sourceText = "";
                                }
                                try
                                {
                                    //if (!String.IsNullOrEmpty(worksheet.Cells[row, 3].Value.ToString()))
                                    //{
                                        sourceValue = worksheet.Cells[row, 3].Value.ToString();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    sourceValue = "";
                                }
                                try
                                {
                                    //if (!String.IsNullOrEmpty(worksheet.Cells[row, 4].Value.ToString()))
                                    //{
                                        sortOrder = worksheet.Cells[row, 4].Value.ToString();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    sortOrder = "";
                                }
                                try
                                {
                                    //if (worksheet.Cells[row, 5] != null)
                                    //{
                                        transformedText = worksheet.Cells[row, 5].Value.ToString();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    transformedText = "";
                                }
                                try
                                {
                                    //if (!String.IsNullOrEmpty(worksheet.Cells[row, 6].Value.ToString()))
                                    //{
                                        transformedOrder = worksheet.Cells[row, 6].Value.ToString();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    transformedOrder = "";
                                }
                                try
                                {
                                    //if (!String.IsNullOrEmpty(worksheet.Cells[row, 7].Value.ToString()))
                                    //{
                                        show = worksheet.Cells[row, 7].Value.ToString();
                                    //}

                                }
                                catch (Exception ex)
                                {
                                    show = "";
                                }
                                try
                                {
                                    //if (!String.IsNullOrEmpty(worksheet.Cells[row, 7].Value.ToString()))
                                    //{
                                    bugId = worksheet.Cells[row, 8].Value.ToString();
                                    //}

                                }
                                catch (Exception ex)
                                {
                                    bugId = "";
                                }

                            valueList.Add(new ReferenceDataExcelModel
                                {
                                    CategoryName = categoryName,
                                    SourceText = sourceText,
                                    SourceValue = sourceValue,
                                    SortOrder = sortOrder,
                                    TransformedText = transformedText,
                                    TransformedOrder = transformedOrder,
                                    Show = show,
                                    BugID = bugId
                            });
                            //}
                        }
                        catch (Exception ex)
                        {
                            categoryName = "";
                        }
                    }
                }
            }
            return valueList.OrderBy(x => x.CategoryName).ToList();
        }
        public List<string> GetSheetsName(string filePath)
        {
            List<string> lstSheetName = new List<string>();

            if (File.Exists(filePath))
            {
                var fInfo = new FileInfo(filePath);
                var package = new ExcelPackage(fInfo);
                foreach (var workSheet in package.Workbook.Worksheets)
                {
                    lstSheetName.Add(workSheet.Name);
                }
            }
            return lstSheetName;
        }

        public void ExportDataToExcelFile(List<ReferenceTypeValue> lstData, string destination, string sheetName)
        {
            var fInfo = new FileInfo(destination);
            var workbook = new ExcelPackage();
            using (var pck = new ExcelPackage(fInfo))
            {
                var mi = typeof(ReferenceTypeValue)
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

        public void ExportDataOrderToExcelFile(List<ReferenceTypeOrder> lstData, string destination, string sheetName)
        {
            var fInfo = new FileInfo(destination);
            var workbook = new ExcelPackage();
            using (var pck = new ExcelPackage(fInfo))
            {
                var mi = typeof(ReferenceTypeOrder)
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
   
    public class ReferenceDataExcelModel    
    {
        public string CategoryName { get; set; }
        public string SourceText { get; set; }
        public string SourceValue { get; set; }
        public string SortOrder { get; set; }
        public string TransformedText { get; set; }
        public string TransformedOrder { get; set; }
        public string Show { get; set; }
        public string TestResult { get; set; }
        public string Actual { get; set; }
        public string BugID { get; set; }
    }
    public class ReferenceTypeValue
    {
        public string SourceValue { get; set; }
        public string ActualValue { get; set; }
        public string SourceText { get; set; }
        public string ActualText { get; set; }
        public string TestResult { get; set; }
        public string BugID { get; internal set; }
    }
    public class ReferenceTypeOrder
    {
        public string SourceValue { get; set; }
        public string SourceText { get; set; }
        public int Order { get; set; }
        public string Actual { get; set; }
        public string TestResult { get; set; }
        public string BugID { get; internal set; }
    }
}
