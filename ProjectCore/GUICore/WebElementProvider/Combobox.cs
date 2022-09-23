using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectCore.GUICore.WebElementProvider;
using System.Threading;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class Combobox: Element
    {
        public Combobox(By locator):base(locator)
        {                       
            
        }

        public void SelectByText(string selectedValue)
        {
            Find(Locator).Click();
            var selector = By.XPath($"//div[@role='option']/span[text()='{selectedValue}']");
            WaitUntilElementClickable(selector);
            WaitUntilElementExist(selector);
            BaseAction.FindAndClick(selector);
        }

        public void Input(string value)
        {
            var id = Locator.ToString().Split(": ")[1];
            var xpath = By.XPath($"//*[@id='{id}']//input");
            WaitForClickable(xpath);
            Driver.FindElement(xpath).SendKeys(value);
            Driver.FindElement(By.XPath($"//div[@role='option']/span[text()='{value}']")).Click();
        }
        public void Filter(By locator, string selection)
        {
            var element = Driver.FindElement(locator);
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Build().Perform();
            foreach (char c in selection)
            {
                action = new Actions(Driver);
                action.SendKeys(c.ToString());
                action.Build().Perform();
            }

        }
        public string GetInnerText()
        {
            var ele = Driver.FindElement(Locator).FindElement(By.XPath("./div/div/div[2]/span[2]"));
            return ele.Text;
        }

        public void Click()
        {
            Find(_locator).Click();
            //Thread.Sleep(1000);
        }
    }
}
