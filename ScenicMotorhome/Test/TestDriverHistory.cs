using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ScenicMH.Tests
{
    public class TestDriverHistory : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ScenicMHTestData.xlsx";      
        static string _sheetName = "DriverHistory";

        [Theory]
        [MemberData(nameof(TestCases))]

        public void ExecuteDriverHistory(string testCaseId, string description, string testResult)
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
