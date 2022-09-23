using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestAddMotorcycle : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetAddMotorcycle = "AddMotorcycle";

        [Theory]
        [MemberData(nameof(AddMotorcycleTestCases))]

        public void ExecuteAddMotorcycle(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> AddMotorcycleTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetAddMotorcycle);
            var actualResults = GetTestResultList(_dataFile, _sheetAddMotorcycle);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
