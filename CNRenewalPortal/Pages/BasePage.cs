using CNRenewalPortal.Pages.GuiModelData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using CNRenewalPortal.Pages;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CNRenewalPortal.Pages
{
    //Should put all common actions here
    public class BasePage
    {
        public IWebDriver _driver => TestConfigs._driver;
        public TestConfigs _configs = new TestConfigs();
        public PageHelper _pageHelper = new PageHelper();
        public static string _baseUrl = "";
        public static string _webReference = "";
        Button btnNext = new Button(By.Id("btnNext"));
        Button btnCover_Next = new Button(By.Id("Cover_Next"));
        By iconLoading = By.ClassName("loadingContainer");

        public void ClickNextButton(string input)
        {
            Thread.Sleep(5000);
            btnNext.Click();
            PageActions.ByPassTrialSifinity();
        }

        public void Refresh()
        {
            Thread.Sleep(2000);
            _driver.Navigate().Refresh();
        }

        public void ClickCoverNext(string input)
        {
            if (input.Equals("Yes"))
            {
                Thread.Sleep(5000);
                var buttonTitle = btnCover_Next.GetText();
                btnCover_Next.Click();
                PageActions.ByPassTrialSifinity();
                if (buttonTitle.Equals("Get Quote"))
                {
                    Thread.Sleep(10000);
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
        protected void WaitUntilElementClickable(By locator, int maxWaitTimeInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            wait.Until(ElementToBeClickable(locator));
        }

        /// <summary>
        /// Waits for the element to be visible before proceeding
        /// </summary>
        protected void WaitUntilElementVisible(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configs.GlobalConfig.WaitTimeSettings.Long));
            wait.Until(ElementIsVisible(locator));
        }

        protected void WaitUntilElementTextContains(By locator, string strExpectedText, int maxWaitTimeInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            wait.Until(d => d.FindElement(locator).Text.Contains(strExpectedText));
        }

        protected void WaitUntilElementTextPresent(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configs.GlobalConfig.WaitTimeSettings.Long));
            wait.Until(d => d.FindElement(locator).Text != string.Empty);
        }

        protected void WaitUntilElementNotDisplayed(By locator, int maxWaitTimeInSeconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            wait.Until(InvisibilityOfElementLocated(locator));
        }
        protected string GetElementText(By locator)
        {
            WaitUntilElementVisible(locator);
            WaitUntilElementTextPresent(locator);
            return Find(locator).Text;
        }
        protected void ScrollToElement(By locator)
        {
            var element = Find(locator);
            var actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        protected void Click(By locator)
        {
            ScrollToElement(locator);
            WaitUntilElementClickable(locator, 20);
            Find(locator).Click();
            Thread.Sleep(1000);

        }
        protected void ClickByJavascript(By locator)
        {
            IWebElement el = Find(locator);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", el);
        }
        protected long GetElementTextByJS(string id)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            return (long)js.ExecuteScript("return document.getElementById('" + id + "').value.length;");
        }

       
    }
}
