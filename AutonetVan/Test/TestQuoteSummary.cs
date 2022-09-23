using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ANCarClassic.Tests
{
    public class TestQuoteSummary : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ANCarClassic_TestData.xlsx";      
        static string _sheetQuoteSummary = "QuoteSummary";

        [Theory]
        [MemberData(nameof(QuoteSummaryTestCases))]

        public void ExecuteQuoteSummary(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> QuoteSummaryTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetQuoteSummary);
            var actualResults = GetTestResultList(_dataFile, _sheetQuoteSummary);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
