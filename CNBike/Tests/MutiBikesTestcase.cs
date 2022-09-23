using ProjectCore.GUICore.TestProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace CNBike.Tests
{
    public class MultiBikesTestcase 
    {      
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\RegressiontestData.xlsx";
        static string _sheetMultiBikesWithABICode = "Multi Bikes with ABI code"; 
        static string _sheetMultiBikesWithABIDumpCode = "Multi Bike _with ABI Dump code";
        static string _expectedResult = "Passed";

        [Theory]
        [MemberData(nameof(GetMultiBikeWithABICodeData))]
        [MemberData(nameof(GetMultiBikesWithABIDumpCodeData))]

        public void TestMultiBikes(string testCaseID, string testCaseDesc, string testResult)
        {           
            Assert.Equal(_expectedResult, testResult);
        }
       
        public static IEnumerable<object[]> GetMultiBikeWithABICodeData()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetMultiBikesWithABICode);
            var actualResults = GetTestResultList(_dataFile, _sheetMultiBikesWithABICode);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }
        public static IEnumerable<object[]> GetMultiBikesWithABIDumpCodeData()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetMultiBikesWithABIDumpCode);
            var actualResults = GetTestResultList(_dataFile, _sheetMultiBikesWithABIDumpCode);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

        public static List<ActualResult> GetTestResultList(string dataFile, string dataSheet)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().Where(x => x.Namespace == "CNBike.Pages").ToList();
            var testBase = new TestBase();
            var actualResults = testBase.RunTestSuites(dataFile, dataSheet, type);

            var list = new List<ActualResult>();
            foreach (var actualResult in actualResults)
            {
                list.Add(actualResult);
            }
            return list;
        }




    }
}
