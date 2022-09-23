using CNBike.Model;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Xunit;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CNBike.Pages
{
    public class BasePage
    {

        public static IWebDriver _driver => TestConfigs._driver;
        public TestConfigs _configs = new TestConfigs();
        By iconLoading = By.ClassName("loadingContainer");

        public WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        protected void addCookie(QuoteRequestModel data)
        {
            var cookie = JsonConvert.SerializeObject(data);
            _driver.Manage().Cookies.AddCookie(new Cookie("key", cookie));
        }

        protected QuoteRequestModel getCookie()
        {
            var stringCookie = _driver.Manage().Cookies.GetCookieNamed("key");
            return (stringCookie != null && !String.IsNullOrEmpty(stringCookie.Value)) 
                ? JsonConvert.DeserializeObject<QuoteRequestModel>(stringCookie.Value)
                : new QuoteRequestModel();
        }

        protected bool CheckElementExists(By locator)
        {
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(_driver.FindElements(locator));
            return elementList.Count > 0 ? true : false;
        }

        /// <summary>
        /// Navigates to the desired url
        /// </summary>
        protected void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Finds element by locator
        /// </summary>
        protected IWebElement Find(By locator)
        {
            return _driver.FindElement(locator);
        }

        /// <summary>
        /// Finds all elements by locator
        /// </summary>
        protected ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return _driver.FindElements(locator);
        }

        /// <summary>
        /// Wait for Ajax to load on the page
        /// </summary>
        /// <param name="maxWaitTimeInSeconds"></param>
        /// <returns>True if Ajax loads in given time,
        /// false if Ajax not present or doesn't load in time
        /// </returns>
        protected bool WaitForAjax(int maxWaitTimeInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
                wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Wait for page to finish loading
        /// </summary>
        /// <param name="maxWaitTimeInSeconds"></param>
        /// <returns>True if page load (document ready state) complete,
        ///  false if page doesn't load in the given time
        /// </returns>
        protected bool WaitForPageToLoad(int maxWaitTimeInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch (Exception)
            {
                return false;
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

        /// <summary>
        /// Wait for the element to be clickable
        /// </summary>
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

        /// <summary>
        /// Waits for the element text contains a specific string
        /// </summary>
        protected void WaitUntilElementTextContains(By locator, string strExpectedText, int maxWaitTimeInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            wait.Until(d => d.FindElement(locator).Text.Contains(strExpectedText));
        }

        /// <summary>
        /// Waits for the element text to present
        /// </summary>
        protected void WaitUntilElementTextPresent(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configs.GlobalConfig.WaitTimeSettings.Long));
            wait.Until(d => d.FindElement(locator).Text != string.Empty);
        }

        /// <summary>
        /// Waits for the element to exist in DOM before proceeding
        /// </summary>
        protected void WaitUntilElementExists(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElements(locator).Count > 0);
        }

        protected void WaitUntilElementNotDisplayed(By locator, int maxWaitTimeInSeconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            wait.Until(InvisibilityOfElementLocated(locator));
        }

        /// <summary>
        /// Waits for the textbox element to be available to input value
        /// </summary>
        protected void WaitUntilTextboxAvailable(By locator, int maxWaitTimeInSeconds)
        {
            while (String.IsNullOrEmpty(Find(locator).GetAttribute("value")))
            {
                if (maxWaitTimeInSeconds > 0)
                {
                    Find(locator).SendKeys("12ab");
                    Wait(500);
                    maxWaitTimeInSeconds -= 1;
                }
                else
                {
                    throw new Exception($"Textbox is still not available after ${maxWaitTimeInSeconds}");
                }
            }
            ClearText(locator);
        }

        protected void Wait(int waitTimeInSeconds)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(waitTimeInSeconds));
        }

        /// <summary>
        /// Clears the text from an element by locator
        /// </summary>
        protected void ClearText(By locator)
        {
            Find(locator).Clear();
        }

        /// <summary>
        /// Clicks element by webElement
        /// </summary>
        protected void Click(By locator)
        {
            WaitUntilElementClickable(locator, 20);
            Find(locator).Click();
            //Thread.Sleep(1000);

            //WaitForPageToLoad(30);
            //WaitForAjax(30);
        }
    

        /// <summary>
        /// Gets the text for the element by locator
        /// </summary>
        protected string GetElementText(By locator)
        {
            WaitUntilElementVisible(locator);
            WaitUntilElementTextPresent(locator);
            return Find(locator).Text;
        }

        /// <summary>
        /// Enters text by locator
        /// </summary>
        protected void TypeInElement(By locator, string inputText)
        {
            WaitUntilElementVisible(locator);
            Find(locator).SendKeys(inputText);
        }

        /// <summary>
        /// Moves the mouse to the given locator, and scrolls to it at the same time
        /// </summary>
        protected void ScrollToElement(By locator)
        {
            var element = Find(locator);
            var actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        /// <summary>
        /// Checks whether element is displayed by locator
        /// </summary>
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

        protected void ClickByJavascript(By locator)
        {
            IWebElement el = Find(locator);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", el);
        }
        protected bool IsElementHidden(By locator)
        {
            if (Find(locator).GetAttribute("class").Contains("hidden-all"))
            {
                return true;
            }
            return false;
        }
        public string GetWebReference()
        {
            Wait(1000);
            string webRef = "";
            string toBeSearched = "webref=";
            int ix = _driver.Url.IndexOf(toBeSearched);
            if (ix != -1)
            {
                webRef = _driver.Url.Substring(ix + toBeSearched.Length);
            }
            else
            {
                throw new Exception("Can not get Web Reference");
            }
            return webRef;
        }

        //Check input type
        public void CheckAssertData(By locator, string dataCompare, string type)
        {
            switch (type)
            {
                case TypeFormControl.Input:
                    CheckAssertDataInput(locator, dataCompare);
                    break;
                case TypeFormControl.DropDownList:
                    CheckAssertDataDropDown(locator, dataCompare);
                    break;
                case TypeFormControl.BtnYesNo:
                    CheckAssertClickBtn(locator);
                    break;
            }
        }

        //Assert  with btn Yes or No
        public void CheckAssertClickBtn(By locator)
        {
            Assert.True(checkBtnIsActive(locator).Equals(true));
        }
        //Assert  with type Input
        public void CheckAssertDataInput(By locator, string dataCompare)
        {
            Thread.Sleep(2000);
            Assert.True(!String.IsNullOrEmpty(dataCompare)
                ? getTextFromInput(locator).Equals(dataCompare, StringComparison.CurrentCultureIgnoreCase)
                : true);
        }
        //Assert  with type Dropdown or text promt
        public void CheckAssertDataDropDown(By locator, string dataCompare)
        {
            var actual = getTextFromDropdown(locator);
            Assert.True(!String.IsNullOrEmpty(dataCompare)
                ? actual.Equals(dataCompare, StringComparison.CurrentCultureIgnoreCase)
                : true);
        }
        // Check btn Active or Not
        public bool checkBtnIsActive(By locator)
        {
            return Find(locator).GetAttribute("class").Contains("isActive");
        }

        // get Data Form input to compare
        public string getTextFromInput(By locator)
        {
            var results = _driver.FindElement(locator).GetAttribute("value");
            return results;
        }
        // get Data Form Dropdown to compare
        public string getTextFromDropdown(By locator)
        {
            var results = _driver.FindElement(locator).Text;
            return results;

        }
		
		public void ScrollToPageEnd(string input)
        {
            if (input == "Yes")
            {
                BaseAction.ScrollToPageEnd();
            }
        }
		
		public void WaitForLoadingIconDisappear(By icoLoading)
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
                if (_driver.FindElements(icoLoading).Count > 0)
                {
                    wait.Until(drv => drv.FindElements(icoLoading).Count == 0);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
