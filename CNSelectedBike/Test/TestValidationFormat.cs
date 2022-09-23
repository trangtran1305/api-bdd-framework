using System.Collections.Generic;
using System.IO;
using Xunit;

namespace CNSBike.Tests
{
    public class TestValidationFormat:TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";
        static string _sheetValidationFormat = "Validation Format";

        //[Theory]
        [MemberData(nameof(ValidationFormatTestCases))]

        public void ExecuteValidationFormat(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> ValidationFormatTestCases()
        {
            var actualResults = GetTestResultList(_dataFile, _sheetValidationFormat);

            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
    
}
