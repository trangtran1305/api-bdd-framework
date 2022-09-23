using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestYourCover : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetYourCover = "YourCover";

        [Theory]
        [MemberData(nameof(YourCoverTestCases))]

        public void ExecuteYourCover(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> YourCoverTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetYourCover);
            var actualResults = GetTestResultList(_dataFile, _sheetYourCover);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
