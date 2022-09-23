using BeWiser.Pages.GuiModelData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using log4net;
using ProjectCore.Utils;

namespace BeWiser.Pages
{
    //Should put all common actions here
    public class BasePage
    {
        public IWebDriver _driver => TestConfigs._driver;
        public TestConfigs _configs = new TestConfigs();
        public PageHelper _pageHelper = new PageHelper();
        public ILog logger = Log4NetHelper.GetLogger(typeof(BasePage));
        public static VehicleData _yourVehicleData;
        public static AboutYouData _aboutYouData;
        public static AdditionalDriverData _additionalDriverData;
        public static InformationQuote _informationQuote;
        public static DriverHistoryData _driverHistoryData;
        public static YourCoverData _yourCoverData;
        public static string _webReference = "";

        Button btnNext = new Button(By.Id("btnNext"));
        Button btnCover_Next = new Button(By.Id("Cover_Next"));
        By iconLoading = By.ClassName("loadingContainer");
        By btnTechnicalErrorContinue = By.Id("TechnicalErrorReturn");
        By btnContinueOnTrialPage = By.XPath("//a[contains(text(),'Sitefinity')]");

        
        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                WaitUntilElementVisible(locator);
                return Find(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        protected bool IsElementBehind(By locator)
        {
            var eles = _driver.FindElements(locator);
            return eles.Count == 0;
        }

        /// <summary>
        /// Waits for the element to exist in DOM before proceeding
        /// </summary>
        protected void WaitUntilElementVisible(By locator)
        {
            try { 
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                //wait.Until(drv => drv.FindElement(locator));
            
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (ElementNotVisibleException)
            {

            }
        }
        protected void WaitUntilElementExist(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                //wait.Until(drv => drv.FindElement(locator));

                wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (ElementNotVisibleException)
            {

            }
        }

        protected IWebElement Find(By locator)
        {
            return _driver.FindElement(locator);
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

        public void ScrollToPageEnd(string input)
        {
            if (input == "Yes")
            {
                BaseAction.ScrollToPageEnd();
            }
        }

        public void NavigateTo(string resoucePath)
        {
            if (resoucePath != "")
            {
                string url = _configs.GlobalConfig.BaseUrl + resoucePath;
                _driver.Navigate().GoToUrl(url);
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
    }
}
