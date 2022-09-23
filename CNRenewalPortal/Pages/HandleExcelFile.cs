using CNRenewalPortal.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectCore.Utils;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace CNRenewalPortal.Pages
{
    public class HandleExcelFile
    {
        public static PageHelper _pageHelper = new PageHelper();
        private static string sourcePath = AppDomain.CurrentDomain.BaseDirectory + "TestData"; // TestData path in bin/debug/netcoreapp2.2 folder
        private static string destPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.2\\", "") + "\\TestData"; // get the TestData folder in the project

        public static Verification GetDataFromExcelFile(string fileName, string sheetName)
        {
            try
            {
                string filePath = FileSearch.GetFullPath("TestData") + "\\" + fileName;
                var fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists)
                    throw new Exception($"Can't find the excel file at path {filePath}");
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[sheetName];
                    var rowCount = worksheet.Dimension.End.Row;
                    for (int row = 0; row < rowCount; row++)
                    {
                        try
                        {
                            // check if the isLock != 0 or = 1, then ignore the row
                            var a = worksheet.Cells[row + 2, (int)PaymentInfoSheet.FirstName].Value.ToString();
                            if (worksheet.Cells[row + 2, (int)PaymentInfoSheet.IsLock].Value.ToString().Trim() != "0")
                            {
                                continue;
                            }
                            // set value của islock = 1 after getting the it's record row
                            worksheet.Cells[row + 2, (int)PaymentInfoSheet.IsLock].Value = "1";
                            return new Verification
                            {
                                ReferenceNumber = worksheet.Cells[row + 2, (int)PaymentInfoSheet.ReferenceNumber].Value.ToString().Trim(),
                                FirstName = worksheet.Cells[row + 2, (int)PaymentInfoSheet.FirstName].Value.ToString().Trim(),
                                LastName = worksheet.Cells[row + 2, (int)PaymentInfoSheet.LastName].Value.ToString().Trim(),
                                Email = worksheet.Cells[row + 2, (int)PaymentInfoSheet.Email].Value.ToString().Trim(),
                                Day = worksheet.Cells[row + 2, (int)PaymentInfoSheet.Day].Value.ToString().Trim(),
                                Month = worksheet.Cells[row + 2, (int)PaymentInfoSheet.Month].Value.ToString().Trim(),
                                Year = worksheet.Cells[row + 2, (int)PaymentInfoSheet.Year].Value.ToString().Trim(),
                            };
                        }
                        catch (NullReferenceException ne)
                        {
                            Console.WriteLine("All payment data info in the data file have already used. Please insert more");
                            throw ne;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            package.Save();
                            CopyChangesToTheDataFile(sourcePath, destPath, fileName);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;

            }
            return null;
        }

        public static void CopyChangesToTheDataFile(string sourcePath, string targetPath, string fileName)
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.Directory.CreateDirectory(targetPath);
            System.IO.File.Copy(sourceFile, destFile, true);
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }
    }

    public enum PaymentInfoSheet
    {
        FirstName = 1,
        LastName,
        Email,
        ReferenceNumber,
        Day,
        Month,
        Year,
        IsLock
    }
}



