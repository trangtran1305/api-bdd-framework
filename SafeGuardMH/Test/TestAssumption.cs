using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SafeGuardMH.Tests
{
    public class TestAssumption : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\SafeguardMHTestData.xlsx";
        static string _sheetVehicle = "Assumption";

        [Theory] 
        [MemberData(nameof(AssumptionTestCases))]
        public void ExecuteVehicle(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> AssumptionTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetVehicle);
            var actualResults = GetTestResultList(_dataFile, _sheetVehicle);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
}
