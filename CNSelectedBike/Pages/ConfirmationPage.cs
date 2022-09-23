using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    class ConfirmationPage : BasePage
    {
        By confirmationTitle = By.XPath("//title[contains(text(), 'Confirmation')]");

        public void VerifyConfirmationPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input == "Yes")
            {
                Thread.Sleep(1000);
                var ele = _driver.FindElements(confirmationTitle);
                Assert.True(ele.Count > 0);
            }
        }

        
    }
}
