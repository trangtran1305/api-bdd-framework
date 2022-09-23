using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ANCarClassic.Tests
{
    public class TestDirectDebit : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ANCarClassic_TestData.xlsx";      
        static string _sheetDirectDebit = "DirectDebit";

        [Theory]
        [MemberData(nameof(VehicleTestCases))]

        public void ExecuteDirectDebit(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> VehicleTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetDirectDebit);
            var actualResults = GetTestResultList(_dataFile, _sheetDirectDebit);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
