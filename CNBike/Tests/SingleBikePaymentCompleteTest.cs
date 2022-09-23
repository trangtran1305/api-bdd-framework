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
    public class SingleBikePaymentCompleteTest
    {      
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\RegressiontestData.xlsx";
        static string _sheetName = "SingleBikePaymentComplete";
        static string _expectedResult = "Passed";

        [Theory]
        [MemberData(nameof(GetSingleBikeJourneyData))]     

        public void TestSingleBikeComplete(string testCaseID, string testCaseDesc, string testResult)
        {           
            Assert.Equal(_expectedResult, testResult);
        }
       
        public static IEnumerable<object[]> GetSingleBikeJourneyData()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetName);
            var actualResults = GetTestResultList(_dataFile, _sheetName);
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
