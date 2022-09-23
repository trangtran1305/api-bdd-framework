using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CMBI.Tests
{
    public class TestVehicle : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CMBI_TestData.xlsx";      
        static string _sheetVehicle = "Vehicle";

        //[Theory]
        [MemberData(nameof(VehicleTestCases))]

        public void ExecuteVehicle(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> VehicleTestCases()
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
