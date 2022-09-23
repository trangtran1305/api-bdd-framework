using CNRenewalPortal.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    public class AssumptionPage : BasePage
    {
        private Button btnContinueToVerificationPage = new Button(By.XPath("//button[contains(text(), 'Continue')]"));
        private By titlePage = By.XPath("//*[text()='Purchase Failed']");
      
        public void ClickContinueToVerificationPage(string input)
        {
            btnContinueToVerificationPage.Click();

        }

        public void VerifyAssumptionPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var result = _driver.Title.Contains("Assumption Page");
                Assert.True(result);
            }
        }
 
    }
}

