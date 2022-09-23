using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    public class ConfirmationPage : BasePage
    {
        By confirmationTitle = By.XPath("//title[contains(text(), 'Confirmation')]");

        public void VerifyConfirmationPageTitle(string input)
        {
            if (input == "Yes")
            {
                Thread.Sleep(1000);
                var ele = _driver.FindElements(confirmationTitle);
                Assert.True(ele.Count > 0);
            }
        }
    }
}

//form[@id='DirectDebit_Form']//span[text()='Total monthly payment']