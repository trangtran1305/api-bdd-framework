using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ANCarClassic.Tests
{
    public class TestProposer : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ANCarClassic_TestData.xlsx";      
        static string _sheetName = "Proposer";

        [Theory]
        [MemberData(nameof(TestCases))]

        public void ExecuteProposer(string testCaseId, string description, string testResult)
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
