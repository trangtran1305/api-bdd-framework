using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ANCarClassic.Tests
{
    public class TestConfirmation : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ANCarClassic_TestData.xlsx";      
        static string _sheetConfirmation = "Confirmation";

        [Theory]
        [MemberData(nameof(ConfirmationTestCases))]

        public void ExecuteConfirmation(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> ConfirmationTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetConfirmation);
            var actualResults = GetTestResultList(_dataFile, _sheetConfirmation);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
