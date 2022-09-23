using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestRiderSummary : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetRiderSummary = "RiderSummary";

        [Theory]
        [MemberData(nameof(RiderSummaryTestCases))]

        public void ExecuteRiderSummary(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> RiderSummaryTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetRiderSummary);
            var actualResults = GetTestResultList(_dataFile, _sheetRiderSummary);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
