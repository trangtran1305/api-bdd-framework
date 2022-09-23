using log4net;
using OfficeOpenXml;
using ProjectCore.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectCore.GUICore.TestProvider
{
    public class TestBaseHelper
    {

        public ILog logger = Log4NetHelper.GetLogger(typeof(TestBaseHelper));

        public List<TestCaseForRun> CreateTestCasesForRun(List<OriginalTestCase> testCases)
        {
            var testCaseForRuns = new List<TestCaseForRun>();
            if (testCases != null)
            {
                foreach (var testCase in testCases)
                {
                    var testCaseForRun = new TestCaseForRun();
                    testCaseForRun.TestCaseID = testCase.TestCaseID;
                    testCaseForRun.Description = testCase.Description;
                    testCaseForRun.TestStepsGroups = CreateTestStepsGroup(testCase.TestSteps);
                    testCaseForRuns.Add(testCaseForRun);
                }
            }

            return testCaseForRuns;
        }

        //Get Data from excel file by sheet
        public string[,] GetDataTableFromExcel(string dataFile, string dataSheet)
        {
            string[,] dataTable = null;
            try
            {
                if (File.Exists(dataFile))
                {
                    var fileInfo = new FileInfo(dataFile);
                    var package = new ExcelPackage(fileInfo);
                    var sheetName = package.Workbook.Worksheets[dataSheet];
                    if(sheetName == null)
                    {
                        logger.Error("Could not find data sheet: "+ dataSheet);
                        return null;
                    }
                    int rows = sheetName.Dimension.Rows;
                    int columns = sheetName.Dimension.Columns;
                    dataTable = new string[rows, columns];

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            var value = sheetName.Cells[i + 1, j + 1].Text;
                            if (string.IsNullOrEmpty(value))
                            {
                                dataTable[i, j] = "";
                            }
                            else
                            {
                                dataTable[i, j] = sheetName.Cells[i + 1, j + 1].Text;
                            }
                        }
                    }
                }
                else
                {
                    logger.Error("Data file is not existed.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in reading data file: (file: {dataFile}, sheet: {dataSheet})");
                throw ex;
            }
            return dataTable;
        }

        //Convert test case from excel to OriginalTestCase
        public List<OriginalTestCase> GetTestScenario(string[,] dataTable)
        {
            var originalTestCases = new List<OriginalTestCase>();
            if (dataTable != null)
            {
                for (int colIndex = 0; colIndex < dataTable.GetLength(1) - 2; colIndex++)
                {
                    var testCase = new OriginalTestCase();

                    if (string.Equals(dataTable[2, colIndex + 2], "Yes", StringComparison.CurrentCultureIgnoreCase))
                    {
                        testCase.TestCaseID = dataTable[0, colIndex + 2];
                        testCase.Description = dataTable[1, colIndex + 2];
                        testCase.TestSteps = new List<TestStep>();
                        var testStep = new TestStep();

                        for (int rowIndex = 4; rowIndex < dataTable.GetLength(0); rowIndex++)
                        {
                            if (!String.IsNullOrEmpty(dataTable[rowIndex, 0]))
                            {
                                testCase.TestSteps.Add(
                                new TestStep
                                {
                                    StepId = dataTable[rowIndex, 0],
                                    StepName = dataTable[rowIndex, 1],
                                    StepData = dataTable[rowIndex, colIndex + 2]
                                }
                                );
                            }
                        }
                        originalTestCases.Add(testCase);
                    }
                }
            }
            return originalTestCases;
        }

        //Create test steps groups for run test
        public List<TestStepsGroup> CreateTestStepsGroup(List<TestStep> testSteps)
        {
            var testStepsGroups = new List<TestStepsGroup>();
            try
            {
                var mainIds = GetMainTestSteps(testSteps);

                foreach (var mainId in mainIds)
                {
                    var stepsGroup = new TestStepsGroup();
                    var subSteps = new List<TestStep>();
                    var mainStep = new TestStep();

                    foreach (var step in testSteps)
                    {
                        string id = ReplaceSpaces(step.StepId);
                        if (string.Equals(mainId, id, StringComparison.CurrentCultureIgnoreCase))
                        {
                            mainStep.StepId = id;
                            mainStep.StepName = step.StepName;
                            mainStep.StepData = step.StepData;
                        }

                        if ((IsIntegerNumber(id) == false) && mainId.Equals(GetIntegerPart(id, ".")))
                        {
                            subSteps.Add(new TestStep { StepId = id, StepName = step.StepName, StepData = step.StepData });
                        }
                    }
                    stepsGroup.MainStep = mainStep;
                    stepsGroup.SubSteps = subSteps;
                    testStepsGroups.Add(stepsGroup);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Test Steps are incorect");
                throw ex;
            }

            return testStepsGroups;
        }

        //Get main step by id
        public List<string> GetMainTestSteps(List<TestStep> testSteps)
        {
            var mainStepIds = new List<string>();
            try
            {
                if (testSteps != null)
                {
                    foreach (var step in testSteps)
                    {
                        string id = step.StepId.Replace(" ", "");
                        if (IsIntegerNumber(id) == true)
                        {
                            mainStepIds.Add(id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Main steps are incorrect.");
                throw ex;
            }

            return mainStepIds;
        }

        public string GetIntegerPart(string input, string charAt)
        {
            string result = "";
            if (!String.IsNullOrEmpty(input))
            {
                result = input.Substring(0, input.IndexOf(charAt));
            }
            return result;
        }

        public bool IsIntegerNumber(string id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (Char.IsDigit(id[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public string ReplaceSpaces(string input)
        {
            return input.Replace(" ", "");
        }

        public string GetPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}