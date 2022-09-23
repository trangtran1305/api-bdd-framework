using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestRiderHistory : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetRiderHistory = "RiderHistory";

        [Theory]
        [MemberData(nameof(RiderHistoryTestCases))]

        public void ExecuteRiderHistory(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> RiderHistoryTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetRiderHistory);
            var actualResults = GetTestResultList(_dataFile, _sheetRiderHistory);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
