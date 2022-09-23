using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestAboutYou : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";      
        static string _sheetAboutYou = "AboutYou";

        [Theory]
        [MemberData(nameof(AboutYouTestCases))]

        public void ExecuteAboutYou(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public  static IEnumerable<object[]> AboutYouTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetAboutYou);
            var actualResults = GetTestResultList(_dataFile, _sheetAboutYou);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }           
        }

    }
}
