using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    public class PaymentGatewayPage : BasePage
    {
        By lblTitle = By.XPath("//*[contains(text(), 'Your Payment')]");
        By lblWebRef = By.XPath("//div[contains(@class, 'text-quote-reference')]/b");
        By lblMonthPrice = By.XPath("//div[@class='total-monthly-payment']/div[@class='head']");
        By btnConfirm = By.CssSelector("#ConfirmButton");
        By btnContinueToDeposit = By.XPath("//button[@name='next.y']");
        By btnBack = By.XPath("//button[@name='back.y']");
        By lblCDLTitle = By.XPath("//*[@class='panel-title' and contains(text(), 'Your Card Details For Your Payment')]");
        static By txtPayCardNumberSelector = By.XPath("//input[@id='PayCardNumber']");
        private By txtPayCardHolder = By.XPath("//input[@id='PayCardHolder']");
        private By txtCardSecurityCode = By.XPath("//input[@id='CardSecurityCode']");
        private By cbPayCardExpireSplitMM = By.Id("PayCardExpireSplitMM");
        private By cbPayCardExpireSplitYY = By.Id("PayCardExpireSplitYY");
        public void ClickConfirmButton(string input)
        {
            if (input == "Yes")
            {
                Click(btnConfirm);
            }
        }

        public void ClickContinueToDepositButton(string input)
        {
            if (input == "Yes")
            {
                Click(btnContinueToDeposit);
                WaitForLoadingIconDisappear();
            }
        }

        public void ClickBackButton(string input)
        {
            if (input == "Yes")
            {
                Click(btnBack);
                WaitForLoadingIconDisappear();
            }
        }
        public void InputPayCardNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(txtPayCardNumberSelector);
                //txtPayCardNumber.Clear();
                TypeInElement(txtPayCardNumberSelector, input);
            }
        }
        public void InputPayCardHolder(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //txtPayCardHolder.Clear();
                TypeInElement(txtPayCardHolder,input);
            }
        }
        public void InputCardSecurityCode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //txtCardSecurityCode.Clear();
                TypeInElement(txtCardSecurityCode,input);
            }
        }
        public void InputPayCardExpire(string input)
        {
            if (input != "")
            {
                string[] date = input.Split("/");
                string part1 = date[0];
                string part2 = date[1];

                Click(cbPayCardExpireSplitMM);
                By optMonth = By.XPath($"(//option[text()='{date[0]}'])[2]");
                Thread.Sleep(500);
                Click(optMonth);
                Click(cbPayCardExpireSplitYY);
                Thread.Sleep(500);
                By optYear = By.XPath($"(//option[text()='{date[1]}'])[1]");
                Click(optYear);
            }
        }


        
        public void VerifyPaymentPageTitle(string input)
        {
            if (input == "Yes")
            {
                Thread.Sleep(1000);
                var e = _driver.FindElements(lblTitle);
                Assert.True(e.Count > 0);
            }
        }

        
    }
}
