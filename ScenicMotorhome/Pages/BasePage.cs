using ScenicMH.Pages.GuiModelData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using log4net;
using ProjectCore.Utils;

namespace ScenicMH.Pages
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
        //hien add 0606
        public static string _webReference = "";

        Button btnNext = new Button(By.Id("btnNext"));
        Button btnCover_Next = new Button(By.Id("Cover_Next"));
        By iconLoading = By.ClassName("loadingContainer");
        By btnTechnicalErrorContinue = By.Id("TechnicalErrorReturn");

        public void ClickNextButton(string input)
        {
            //Thread.Sleep(5000);
            btnNext.Click();
            PageActions.ByPassTrialSifinity();
        }
        public void ClickCoverNext(string input)
        {
            if (input.Equals("Yes"))
            {
                //Thread.Sleep(5000);
                var buttonTitle = btnCover_Next.GetText();
                btnCover_Next.Click();
                PageActions.ByPassTrialSifinity();
                if (buttonTitle.Equals("Get Quote"))
                {
                    //Thread.Sleep(10000);
                }
            }

        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                WaitUntilElementExists(locator);
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
        protected void WaitUntilElementExists(By locator)
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

        protected IWebElement Find(By locator)
        {
            return _driver.FindElement(locator);
        }

        public string GetValueFromCombobox(By element)
        {
            IWebElement comboBox = _driver.FindElement(element);
            SelectElement selectedValue = new SelectElement(comboBox);
            return selectedValue.SelectedOption.Text;
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

        //public void WaitElementClickable(By locator)
        //{
        //    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        //    wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        //}

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

    }
}
