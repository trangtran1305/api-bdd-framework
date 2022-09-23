using CNSBike.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestRetrieveQuote : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";
        static string _sheetRetrieveQuote = "RetrieveQuote";

        [Theory]
        [MemberData(nameof(RetrieveQuoteTestCases))]

        public void ExecuteRetrieveQuote(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> RetrieveQuoteTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetRetrieveQuote);
            var actualResults = GetTestResultList(_dataFile, _sheetRetrieveQuote);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }
    }
}
