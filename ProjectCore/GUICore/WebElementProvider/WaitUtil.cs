using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using System;

namespace ProjectCore.Utils
{
    class WaitUtil
    {
        public static WebDriverWait GetWait(int timeOutInSecond = 1)
        {
            IWebDriver driver = TestConfigs._driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSecond));
            return wait;
        }

        public static IWebElement WaitForElementVisible(By by)
        {
            IWebElement ele = null;
            try
            {
                ele = GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception) { }
            return ele;
        }

        public static IWebElement WaitForElementClickable(By by)
        {
            IWebElement ele = null;
            try
            {
                ele = GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception)
            {

            }
            return ele;
        }

        public static void WaitForElementClickable(IWebElement element)
        {
            try
            {
                GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception) { }
        }

        public static void WaitForElementsVisible(By by)
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }
    }
}
