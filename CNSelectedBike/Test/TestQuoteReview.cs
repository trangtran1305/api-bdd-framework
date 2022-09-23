using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestQuoteReview : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";
        static string _sheetQuoteReview = "QuoteReview";

        [Theory]
        [MemberData(nameof(QuoteReviewTestCases))]

        public void ExecuteQuoteReview(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> QuoteReviewTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetQuoteReview);
            var actualResults = GetTestResultList(_dataFile, _sheetQuoteReview);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
}
