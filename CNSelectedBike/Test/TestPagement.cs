using CNSBike.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CNSBike.Test
{
    public class TestPagement : TestDataProviderBase
    {
        static string _dataFile = Directory.GetCurrentDirectory() + "\\TestData\\CNSBikeTestData.xlsx";
        static string _sheetPayment = "Payment";

        [Theory]
        [MemberData(nameof(PaymentTestCases))]

        public void ExecutePayment(string testCaseId, string description, string testResult)
        {
            Assert.Equal("Passed", testResult);
        }
        public static IEnumerable<object[]> PaymentTestCases()
        {
            Console.WriteLine("Starting automation test suite with: " + _sheetPayment);
            var actualResults = GetTestResultList(_dataFile, _sheetPayment);
            foreach (var actualResult in actualResults)
            {
                yield return new object[] { actualResult.TestCaseID, actualResult.Description, actualResult.TestResult };
            }
        }

    }
}
