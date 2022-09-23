using ProjectCore.GUICore.TestProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SafeGuardMH.Tests
{
    public class TestDataProviderBase
    {       
        public static List<ActualResult> GetTestResultList(string dataFile, string dataSheet)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().Where(x => x.Namespace == "SafeGuardMH.Pages").ToList();
            var testBase = new TestBase();
           var actualResults = testBase.RunTestSuites(dataFile, dataSheet, type);
            return actualResults;
        }
    }
}