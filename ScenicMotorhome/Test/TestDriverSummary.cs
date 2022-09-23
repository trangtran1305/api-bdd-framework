using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ScenicMH.Tests
{
    public class TestDriverSummary : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ScenicMHTestData.xlsx";      
        static string _sheetDriverSummary = "DriverSummary";

        [Theory]
        [MemberData(nameof(VehicleTestCases))]

        public void ExecuteDriverSummary(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> VehicleTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetDriverSummary);
            var actualResults = GetTestResultList(_dataFile, _sheetDriverSummary);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
}
