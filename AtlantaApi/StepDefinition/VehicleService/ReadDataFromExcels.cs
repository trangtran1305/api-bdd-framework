using AtlantaApi.Utils;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AtlantaApi.StepDefinition.VehicleService
{
    class ReadDataFromExcels
    {
        public static List<string> ReadDataBySheetName(string fileName, string sheetName, string header, string apiVersion, string contextName)
        {
            string filePath = Common.GetPathFile(fileName, apiVersion, contextName);
            FileInfo fileInfo = new FileInfo(filePath);
            List<string> lsData = new List<string>();
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet;
            worksheet = package.Workbook.Worksheets[sheetName];
            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;
            for (int i = 1; i < columns; i++)
            {
                if (worksheet.Cells[1, i].Value.ToString().Equals(header))
                {
                    int j = 2;
                    while (j <= rows)
                    {
                        lsData.Add(worksheet.Cells[j, i].Value.ToString());
                        j++;
                    }
                }

            }
            return lsData;
        }

        public static List<string> GetVehicleData(string fileName, string sheetName, string apiVersion, string contextName)
        {
            List<string> vehicleDatas = new List<string>();
            string filePath = Common.GetPathFile(fileName, apiVersion, contextName);
            FileInfo fileInfo = new FileInfo(filePath);
            List<string> lsData = new List<string>();
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet;
            worksheet = package.Workbook.Worksheets[sheetName];
            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;
            int j = 2;
            while (j < rows+1)
            {
                string s = worksheet.Cells[j, 1].Value.ToString() + "/" + worksheet.Cells[j, 2].Value.ToString() + "/" + worksheet.Cells[j, 3].Value.ToString() + "/" + worksheet.Cells[j, 4].Value.ToString();
                vehicleDatas.Add(s);
                j++;
            }

            return vehicleDatas;
        }
    }

    class WriteDataToExcels
    {
        public static void WriteDataToSheetName(string fileName, string sheetName, string header, string apiVersion, string contextName, int range, List<string> value)
        {
            string filePath = Common.GetPathFile(fileName, apiVersion, contextName);
            FileInfo fileInfo = new FileInfo(filePath);
            List<string> lsData = new List<string>();
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet;
            worksheet = package.Workbook.Worksheets[sheetName];
            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;
            for (int i = 1; i < columns+1; i++)
            {
                if (worksheet.Cells[1, i].Value.ToString().Equals(header))
                {
                    int j = 0;
                    int k = 2;
                    while (j<value.Count)
                    {
                        worksheet.SetValue(k, i, value[j]);
                        k++;
                        j++;
                    }
                }
            }
            package.SaveAs(fileInfo);
        }
    }
}
