using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.WebElementProvider
{
    public abstract class Element
    {
        public static IWebDriver Driver => TestConfigs._driver;
        public int WaitTimeSetting; 
        protected By _locator;
        public Element(By locator=null)
        {
            _locator = locator;
        }       

        public By Locator
        {
            get
            {
                LocatorIsNotNullCheck(_locator);
                return _locator;
            }
        }

        public IWebElement Find()
        {
            WaitUntilElementVisible(Locator, 5);
            return Driver.FindElement(Locator);
        }

        public bool IsPresent()
        {
            return Find().Displayed;
        }

        public string GetText()
        {
            return Find().Text;
        }

        public string GetPopulatedValue()
        {
            return Find().GetAttribute("value");
        }

        public string GetAttributeValue(string attributeName)
        {
            return Find().GetAttribute(attributeName);
        }
        public virtual void Hover()
        {
            Hover(Locator);
        }
        public virtual void Hover(By locator)
        {
            Actions ac = new Actions(Driver);
            ac.MoveToElement(Find(locator)).Build().Perform();
        }
        public virtual IWebElement Find(By locator) {
            WaitUntilElementClickable(Locator, 3);
            return Driver.FindElement(locator);
        }


        public void LocatorIsNotNullCheck(By locator)
        {
            if (locator == null)
            {
                throw new InvalidOperationException("Component was not initialized with locator. Provide it to the constructor or call method with the locator.");


            }
        }
        public static IWebElement WaitUntilElementVisible(By locator, double timeout = 0)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (Exception ex)
            {
                throw new Exception(
                   "Element with locator: '" + locator + "' was not found in current context page."
                   + "\n" + ex);
            }
        }
        public static IWebElement WaitUntilElementClickable(By locator, double timeout =0 )
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception ex)
            {
                throw new Exception(
                   "Element with locator: '" + locator + "' was not found in current context page."
                   + "\n" + ex);
            }
        }
        public static IWebElement WaitUntilElementExist(By locator, double timeout = 0)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (Exception ex)
            {
                throw new Exception(
                   "Element with locator: '" + locator + "' was not found in current context page."
                   + "\n" + ex);
            }
        }
        private static IWebElement WaitByTime(By locator, double timeOut=0, bool isThrowException = false)
        {
            IWebElement element = null;
            try
            {
                element = WaitUntilElementClickable(locator, timeOut);
                return element;
            }
            catch (Exception e)
            {
                if (isThrowException)
                {
                    throw new Exception(e.Message);
                }
            }
            return element;
        }
        public static IWebElement WaitForClickable(By by, double longTime = 0)
        {
            //This funtion is wait for element is clickable and by pass the trial sitefinity page
            IWebElement element;
            double shortTime = longTime * 0.1;
            longTime *= 0.8;

            element = WaitByTime(by, shortTime);
            if (element != null)
            {
                return element;
            }
            PageActions.ByPassTrialSifinity();
            element = WaitByTime(by, longTime);
            if (element != null)
            {
                return element;
            }
            PageActions.ByPassTrialSifinity();
            element = WaitByTime(by, shortTime, true);
            return element;
        }
    }
}
