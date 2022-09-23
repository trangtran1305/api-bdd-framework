using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestMotocycleSummary : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetMotocycleSummary = "MotocycleSummary";

        [Theory]
        [MemberData(nameof(MotocycleSummaryTestCases))]

        public void ExecuteMotocycleSummary(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> MotocycleSummaryTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetMotocycleSummary);
            var actualResults = GetTestResultList(_dataFile, _sheetMotocycleSummary);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
