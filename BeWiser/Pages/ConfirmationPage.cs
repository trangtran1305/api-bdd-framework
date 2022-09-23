using BeWiser.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using System.Linq;

namespace BeWiser.Pages
{
    public class ConfirmationPage : BasePage
    {
        private By title = By.XPath("//title[contains(text(),'Confirmation')]");

        private Button btnConfirmationPageNext = new Button(By.XPath("//title[contains(text(),'Confirmation')]"));
        private By lbLegalProtectionOpex = By.XPath("//*[contains(text(),'Motor Legal Expenses Cover')]");
        private By lbBreakdownEuropeanCoverOpex = By.XPath("//*[contains(text(),'European Cover')]");
        public void VerifyConfirmationPageDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExist(title);
                Assert.True(_driver.FindElements(title).Count > 0);
            }
        }

        public void VerifyLegalCoverOpexDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(lbLegalProtectionOpex));
            }
        }

        public void VerifyBreakdownCoverOpexDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(lbBreakdownEuropeanCoverOpex));
            }
        }
    }
}
