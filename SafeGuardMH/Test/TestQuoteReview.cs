using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SafeGuardMH.Tests
{
    public class TestQuoteReview : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\SafeguardMHTestData.xlsx";      
        static string _sheetName = "QuoteReview";

        [Theory]
        [MemberData(nameof(TestCases))]

        public void ExecuteQuoteReview(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> TestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetName);
            var actualResults = GetTestResultList(_dataFile, _sheetName);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
