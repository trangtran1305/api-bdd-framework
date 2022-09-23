using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class LinkText:Element
    {
        public LinkText(By locator) : base(locator)
        {
        }
        public void Click()
        {
            Find(_locator).Click();
        }
    }
}
