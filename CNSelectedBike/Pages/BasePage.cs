using CNSBike.Pages.GuiModelData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace CNSBike.Pages
{
    //Should put all common actions here
    public class BasePage
    {
        public IWebDriver _driver => TestConfigs._driver;
        public TestConfigs _configs = new TestConfigs();
        public PageHelper _pageHelper = new PageHelper();
        public static YourMotorcycleData _yourMotorcycleData;
        public static AboutYouData _aboutYouData;
        public static AdditionalRiderData _additionalRiderData;
        public static RiderHistoryData _riderHistoryData;
        public static YourCoverData _yourCoverData;
        public static string _webRerence;
        public static string _monthlyPrice;

        By icoLoading = By.ClassName("loadingContainer");

        Button btnNext = new Button(By.Id("btnNext"));
        Button btnCover_Next = new Button(By.Id("Cover_Next"));
        By btnContinueOnTrialPage = By.XPath("/html/body/div/p/a");
        private By yourCoverPageProgressBar = By.Id("ProgressBarYourCover");

        By btnBarAboutYou = By.CssSelector("#ProgressBarAboutYou");
        By btnBarYourCover = By.CssSelector("#ProgressBarYourCover");

        public void SelectAboutYou(string input)
        {
            if(input == "Yes")
            {
                BaseAction.FindAndClick(btnBarAboutYou);
            }
        }

        public void SelectYourCover(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnBarYourCover);
            }
        }

        public void ClickNextButton(string input)
        {
            Thread.Sleep(1000);
            btnNext.Click();
            PageActions.ByPassTrialSifinity();
            WaitForLoadingIconDisappear();
        }
        public void ClickContinueOnTrialPage()
        {
            if (_driver.FindElements(btnContinueOnTrialPage).Count > 0)
            {
                _driver.FindElement(btnContinueOnTrialPage).Click();
                Thread.Sleep(1000);
            }
        }
        public void ClickCoverNext(string input)
        {
            if (input.Equals("Yes"))
            {
                Thread.Sleep(1000);
                var buttonTitle = btnCover_Next.GetText();
                btnCover_Next.Click();
                PageActions.ByPassTrialSifinity();
                WaitForLoadingIconDisappear();
                //if (buttonTitle.Equals("Get Quote"))
                //{
                //    Thread.Sleep(5000);
                //}
            }

        }
        public void ClickYourCoverOnProgressBar(string input)
        {
            if (input.Equals("Yes"))
            {
                _driver.FindElement(yourCoverPageProgressBar).Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
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

        /// <summary>
        /// Waits for the element to exist in DOM before proceeding
        /// </summary>
        protected void WaitUntilElementExists(By locator)
        {
            Thread.Sleep(1000);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElements(locator).Count > 0);
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

        public string GetCurrnetURL()
        {
            return _driver.Url;
        }

        //public void Click(By locator)
        //{
        //    WaitElementClickable(locator);
        //    _driver.FindElement(locator).Click();
        //}

        public void WaitForLoadingIconDisappear()
        {
            try
            {
                //wait to see loading icon if any
                if (_driver.FindElements(icoLoading).Count == 0)
                {
                    Thread.Sleep(1500);
                }

                //Wait loading icon disappear
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                Thread.Sleep(200);
                if (_driver.FindElements(icoLoading).Count > 0)
                {
                    wait.Until(drv => drv.FindElements(icoLoading).Count == 0);
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
            if(resoucePath != "")
            {
                string url = _configs.GlobalConfig.BaseUrl + resoucePath;
                _driver.Navigate().GoToUrl(url);
            }
        }
    }
}
