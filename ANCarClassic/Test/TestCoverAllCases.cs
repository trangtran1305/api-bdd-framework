using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ANCarClassic.Tests
{
    public class TestCoverAllCases : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\ANCarClassic_TestData.xlsx";
        static string _sheetCoverAllCases = "CoverAllCases";

        //[Theory]
        [MemberData(nameof(CoverAllTestCases))]

        public void ExecuteCoverCases(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> CoverAllTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetCoverAllCases);
            var actualResults = GetTestResultList(_dataFile, _sheetCoverAllCases);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
}
