using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AtlantaApi.Utils
{
    internal class ExcelUtils
    {
        public static List<T> ReadExcel<T>(String path)
        {
            DataTable data = ReadExcel(path);
            return ToCollection<T>(data);
        }

        public static DataTable ReadExcel(String path)
        {
            FileInfo fileInfo = new FileInfo(path);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            // get number of rows and columns in the sheet
            int rows = worksheet.Dimension.Rows; // 20
            int columns = worksheet.Dimension.Columns; // 7
            DataTable tbl = new DataTable();
            for (int i = 1; i <= 7; i++)
            {
                tbl.Columns.Add(worksheet.Cells[1, i].Value.ToString());
            }
            // loop through the worksheet rows and columns
            for (int i = 2; i <= rows; i++)
            {
                DataRow row = tbl.NewRow();
                for (int j = 1; j <= 7; j++)
                {
                    row[j - 1] = worksheet.Cells[i, j].Value.ToString();
                }
                tbl.Rows.Add(row);
            }
            return tbl;
        }

        public static List< DataTable> ReadExcelAllSheets(String path)
        {
            FileInfo fileInfo = new FileInfo(path);
            List<DataTable> lstData = new List<DataTable>();
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet;
            for (int k = 0; k < package.Workbook.Worksheets.Count; k++)
            {
                worksheet = package.Workbook.Worksheets[k];

                // get number of rows and columns in the sheet
                int rows = worksheet.Dimension.Rows; // 20
                int columns = worksheet.Dimension.Columns; // 7
                DataTable tbl = new DataTable();
                for (int i = 1; i <= 7; i++)
                {
                    tbl.Columns.Add(worksheet.Cells[1, i].Value.ToString());
                }
                // loop through the worksheet rows and columns
                for (int i = 2; i <= rows; i++)
                {
                    DataRow row = tbl.NewRow();
                    for (int j = 1; j <= 7; j++)
                    {
                        row[j - 1] = worksheet.Cells[i, j].Value.ToString();
                    }
                    tbl.Rows.Add(row);
                }
                lstData.Add(tbl);
            }
            

            return lstData;
        }

    
    public static List<T> ToCollection<T>(DataTable dt)
        {
            List<T> lst = new List<T>();
            Type tClass = typeof(T);
            PropertyInfo[] pClass = tClass.GetProperties();
            List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
            T cn;
            foreach (DataRow item in dt.Rows)
            {
                cn = (T)Activator.CreateInstance(tClass);
                foreach (PropertyInfo pc in pClass)
                {
                    // Can comment try catch block.
                    try
                    {
                        DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                        if (d != null)
                            pc.SetValue(cn, item[pc.Name], null);
                    }
                    catch
                    {
                    }
                }
                lst.Add(cn);
            }
            return lst;
        }
    }
}