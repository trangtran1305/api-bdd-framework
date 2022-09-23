using CNRenewalPortal.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    public class ConfirmationPage : BasePage
    {
        private By title = By.XPath("//*[contains(text(), 'Payment Complete')]");
        
        public void VerifyConfirmationPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var count  = _driver.FindElements(title).Count;
                Assert.True(count > 0);
            }
        }
 
    }
}

