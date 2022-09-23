using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestAssumptions : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetAssumptions = "Assumptions";

        [Theory]
        [MemberData(nameof(AssumptionsTestCases))]

        public void ExecuteAssumptions(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> AssumptionsTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetAssumptions);
            var actualResults = GetTestResultList(_dataFile, _sheetAssumptions);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
