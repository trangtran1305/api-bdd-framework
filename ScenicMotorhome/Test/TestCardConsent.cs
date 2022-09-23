using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ScenicMH.Tests
{
    public class TestCardConsent : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ScenicMHTestData.xlsx";      
        static string _sheetCardConsent = "CardConsent";

        [Theory]
        [MemberData(nameof(CardConsentTestCases))]

        public void ExecuteCardConsent(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> CardConsentTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetCardConsent);
            var actualResults = GetTestResultList(_dataFile, _sheetCardConsent);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
