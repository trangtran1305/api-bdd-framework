using CNSBike.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestConfirmation : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";
        static string _sheetPayment = "Confirmation";

        [Theory]
        [MemberData(nameof(TestCases))]

        public void ExecuteConfirmation(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> TestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetPayment);
            var actualResults = GetTestResultList(_dataFile, _sheetPayment);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
}
