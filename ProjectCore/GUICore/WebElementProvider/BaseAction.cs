using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectCore.Configurations;
using ProjectCore.Utils;
using System;
using System.Collections.Generic;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class BaseAction
    {
        public static void HoverOnElement(By by)
        {
            IWebDriver driver = TestConfigs._driver;
            IWebElement element = driver.FindElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
        }
        public static void MoveTo(IWebElement element)
        {
            IWebDriver driver = TestConfigs._driver;
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
        }

        public static IWebElement FindElement(By by)
        {
            IWebDriver driver = TestConfigs._driver;
            IWebElement ele = driver.FindElement(by);
            return ele;
        }

        public static IWebElement FindElementIn(IWebElement container, By by)
        {
            IWebElement ele = container.FindElement(by);
            return ele;
        }

        public static List<IWebElement> FindElements(By by)
        {
            WaitUtil.WaitForElementsVisible(by);
            IReadOnlyCollection<IWebElement> collection = TestConfigs._driver.FindElements(by);
            List<IWebElement> eles = new List<IWebElement>(collection);
            return eles;
        }

        public static List<IWebElement> FindElementsIn(IWebElement container, By by)
        {
            WaitUtil.WaitForElementsVisible(by);
            IReadOnlyCollection<IWebElement> collection = container.FindElements(by);
            List<IWebElement> eles = new List<IWebElement>(collection);
            return eles;
        }

        public static void FindAndClick(By by)
        {
            //find element
            IWebElement element = FindElement(by);

            //click element
            if (element != null)
            {
                //Wait
                WaitUtil.WaitForElementClickable(element);

                //click
                try
                {
                    //move to element Actions(TestConfigs._driver);
                    Actions actions = new Actions(TestConfigs._driver);
                    actions.MoveToElement(element).Build().Perform();

                    //click
                    element.Click();
                }
                catch (ElementNotInteractableException)
                {
                    IJavaScriptExecutor javascript = (IJavaScriptExecutor)TestConfigs._driver;
                    javascript.ExecuteScript("arguments[0].click();", element);
                }
            }
        }

        public static void Click(IWebElement element)
        {
            //Wait
            WaitUtil.WaitForElementClickable(element);

            //click
            try
            {
                //move to element
                Actions actions = new Actions(TestConfigs._driver);
                actions.MoveToElement(element).Build().Perform();

                //click
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                //Close tip which overlaps the element, than click again
                FindElement(By.XPath("//*[text()='Got it']")).Click();

                //move to element
                Actions actions = new Actions(TestConfigs._driver);
                actions.MoveToElement(element).Build().Perform();

                //click
                element.Click();
            }
            catch (ElementNotInteractableException)
            {
                IJavaScriptExecutor javascript = (IJavaScriptExecutor)TestConfigs._driver;
                javascript.ExecuteScript("arguments[0].click();", element);
            }

        }

        public static IWebElement ClickInNestedElement(IWebElement container, By by)
        {
            IWebElement ele = container.FindElement(by);
            ele.Click();
            return ele;
        }

        public static String ReadText(IWebElement element)
        {
            String text = element.Text;
            return text;
        }

        public static IWebElement SetText(By by, String text)
        {
            IWebElement ele = WaitUtil.WaitForElementVisible(by);
            ele.Clear();
            ele.SendKeys(text);
            return ele;
        }
        public static void SetText(IWebElement ele, String text)
        {
            ele.Clear();
            ele.SendKeys(text);
        }

        public static IWebElement SetTextInNestedElement(IWebElement container, By by, String text)
        {
            IWebElement ele = container.FindElement(by);
            ele.Clear();
            ele.SendKeys(text);
            return ele;
        }

        public static void ScrollToPageEnd()
        {
            ((IJavaScriptExecutor)TestConfigs._driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }
    }
}
