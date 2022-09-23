using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.Utils;
using ProjectCore.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace ProjectCore.GUICore.TestProvider
{
    public class TestBase
    {
        public TestConfigs _configs = new TestConfigs();
        public IWebDriver _driver;
        public ILog logger = Log4NetHelper.GetLogger(typeof(TestBase));
        private string _sheetName;
        private string url;
        By iconLoading = By.ClassName("loadingContainer");
        By btnTechnicalErrorContinue = By.Id("TechnicalErrorReturn");
        By btnContinueOnTrialPage = By.XPath("//a[contains(text(),'Sitefinity')]");
        public void OpenBrowser()
        {            
            var globalSettings = _configs.GlobalConfig;
            url = globalSettings.BaseUrl;
            var driverList = globalSettings.Browser.DriverTypeList;
            KillChromeDriver();
            foreach (var driver in driverList)
            {
                if (driver.Value.ToString() == "true")
                {
                    _driver = TestConfigs.InitDriver(driver.Name,driver.UserProfilePreferences, driver.Arguments);
                    _driver.Manage().Window.Maximize();
                    _driver.Url = url;                    
                }
            }
        }
        public void OpenDeepLink(string url)
        {
            var globalSettings = _configs.GlobalConfig;
            //url = globalSettings.BaseUrl;
            var driverList = globalSettings.Browser.DriverTypeList;
            KillChromeDriver();
            foreach (var driver in driverList)
            {
                if (driver.Value.ToString() == "true")
                {
                    _driver = TestConfigs.InitDriver(driver.Name, driver.UserProfilePreferences, driver.Arguments);
                    _driver.Manage().Window.Maximize();
                    _driver.Url = url;
                    WaitForLoadingIconDisappear();
                    ClickContinueOnTrialPage();
                    WriteLogIfTechnicalError();
                }
            }
        }
        public void WriteLogIfTechnicalError()
        {
            var ele1 = _driver.FindElements(btnTechnicalErrorContinue);
            var ele2 = _driver.FindElements(By.XPath("//*[contains(text(), 'Technical Error')]"));
            if (ele1.Count > 0 || ele2.Count > 0)
            {
                logger.Info("============ Technical Error URL: " + _driver.Url);
            }
        }
        public void ClickContinueOnTrialPage()
        {
            if (_driver.FindElements(btnContinueOnTrialPage).Count > 0)
            {
                _driver.Navigate().Refresh();
                WaitForLoadingIconDisappear();
                //_driver.FindElement(btnContinueOnTrialPage).Click();
                //Thread.Sleep(1000);
            }
        }
        public void WaitForLoadingIconDisappear()
        {
            try
            {
                //wait to see loading icon if any
                if (_driver.FindElements(iconLoading).Count == 0)
                {
                    Thread.Sleep(1500);
                }

                //Wait loading icon disappear
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                if (_driver.FindElements(iconLoading).Count > 0)
                {
                    wait.Until(drv => drv.FindElements(iconLoading).Count == 0);
                }
            }
            catch (Exception)
            {

            }
        }
        public List<ActualResult> RunTestSuites(string filePath, string sheetName, List<Type> assemblyType)
        {
            _sheetName = sheetName;
            var actualResults = new List<ActualResult>();
            var testBaseHelper = new TestBaseHelper();
            var dataTable = testBaseHelper.GetDataTableFromExcel(filePath, sheetName);
            if (dataTable == null)
            {
                Console.WriteLine("Data is invalid in sheet: " + sheetName);
                return null;
            }
            else
            {
                var originalTestCases = testBaseHelper.GetTestScenario(dataTable);
                var testCaseForRuns = testBaseHelper.CreateTestCasesForRun(originalTestCases);
                foreach (var test in testCaseForRuns)
                {
                    Console.WriteLine("Starting test case: " + test.TestCaseID);
                    actualResults.Add(RunTestCase(test, assemblyType));
                }
            }
            
            return actualResults;
        }
         
        public ActualResult RunTestCase(TestCaseForRun testCase, List<Type> assemblyType)
        {
            logger.Info("START TESTCASE: [" + _sheetName + "]_" + testCase.TestCaseID);

            var isChecked = true;
            if (testCase == null)
            {
                isChecked = false;
                return null;
            }else
            {
                string currentMethod = "";
                string currentPage = "";
                try
                {
                    OpenBrowser();
                    //Thread.Sleep(5000);
                    foreach (var testStepsGroup in testCase.TestStepsGroups)
                    {
                        if (string.Equals(testStepsGroup.MainStep.StepData.Trim(), "Required", StringComparison.CurrentCultureIgnoreCase))
                        {
                            var className = testStepsGroup.MainStep.StepName.CapSentences().Replace(" ", "");
                            //Create new object by class name
                            var type = assemblyType.FirstOrDefault(x => x.Name == className);

                            var obj = Activator.CreateInstance(type);

                            foreach (var subStep in testStepsGroup.SubSteps)
                            {
                              if (!string.Equals(subStep.StepData, "Not Required", StringComparison.CurrentCultureIgnoreCase))
                                {                                    
                                    var methodName = subStep.StepName.CapSentences().Replace(" ", "").Replace("_", "");
                                    var parameters = new object[] { subStep.StepData };                                   
                                    
                                    //Log
                                    currentMethod = methodName;
                                    currentPage = obj.GetType().ToString();

                                    String paraValue = parameters[0].ToString();
                                    if(!String.IsNullOrEmpty(paraValue))
                                    {
                                        Console.WriteLine("Run test step: " + currentMethod);
                                        logger.Debug(" Run step: " + currentMethod + " - with value: " + paraValue + " - in page: " + currentPage);
                                    }

                                    //Call method
                                    var debugObject = obj.GetType().GetMethod(methodName).Invoke(obj, parameters);
                                }
                            }
                        }
                    }
                    CloseBrowser();
                }
                catch (Exception e)
                {
                    isChecked = false;
                    Console.WriteLine("Run test step: " + currentMethod);
                    String screenshot = TakeScreenshot("log", "[" + _sheetName + "]_" + testCase.TestCaseID);
                    logger.Error("Failed at step: " + currentMethod + " in page: " + currentPage);
                    logger.Error("Reason: " + e);
                    logger.Error("[SCREENSHOT]: " + screenshot);
                    
                    CloseBrowser();
                }
            }
            var actualResult = new ActualResult
            {
                TestCaseID = testCase.TestCaseID,
                Description = testCase.Description,
                TestResult = isChecked == true ? "Passed" : "Failed",
            };
            logger.Info("END TESTCASE: " + testCase.TestCaseID + ": " + actualResult.TestResult);
            logger.Info("================================================================\n");

            return actualResult;
        }

        public void CloseBrowser()
        {
            var a = _driver.Manage().Cookies.GetCookieNamed("key");
            _driver.Quit();
            _driver.Dispose();
            _driver = null;
        }

        public void KillChromeDriver()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }

        public String TakeScreenshot(String path, String screenshotName)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string subPath = path + "\\" + DateTime.Now.ToString("MMMMdd") + "_" + url.Substring(8, 3);
            Directory.CreateDirectory(subPath);

            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshotName = screenshotName + ".png";
            screenshot.SaveAsFile(subPath + "\\" + screenshotName, ScreenshotImageFormat.Png);

            String screenshotPath = Directory.GetCurrentDirectory() + "\\" + subPath + "\\" + screenshotName;
            screenshotPath = screenshotPath.Replace("\\", "/");
            return screenshotPath;
        }
    }
}