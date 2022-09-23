using CNRenewalPortal.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    public class ErrorPage : BasePage
    {
        private By titlePruchaseFailPage = By.XPath("//*[text()='Purchase Failed']");
      
        

        public void VerifyPurchaseFailedPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var count = _driver.FindElements(titlePruchaseFailPage).Count;
                Assert.True(count > 0);
            }
        }
 
    }
}

