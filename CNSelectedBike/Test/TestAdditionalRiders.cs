using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestAdditionalRiders : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetAdditionalRiders = "AdditionalRiders";

        [Theory]
        [MemberData(nameof(AdditionalRidersTestCases))]

        public void ExecuteAdditionalRiders(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> AdditionalRidersTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetAdditionalRiders);
            var actualResults = GetTestResultList(_dataFile, _sheetAdditionalRiders);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
