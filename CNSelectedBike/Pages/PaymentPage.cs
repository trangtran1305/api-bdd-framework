using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    class PaymentPage : BasePage
    {
        By lblTitle = By.XPath("//*[contains(text(), 'Your Payment')]");
        By lblWebRef = By.XPath("//div[contains(@class, 'text-quote-reference')]/b");
        By lblMonthPrice = By.XPath("//div[@class='total-monthly-payment']/div[@class='head']");
        By btnConfirm = By.CssSelector("#ConfirmButton");
        By btnContinueToDeposit = By.XPath("//button[@name='next.y']");
        By btnBack = By.XPath("//button[@name='back.y']");
        By lblCDLTitle = By.XPath("//*[@class='panel-title' and contains(text(), 'Your Card Details For Your Payment')]");
        static By txtPayCardNumberSelector = By.XPath("//input[@id='PayCardNumber']");
        private Textbox txtPayCardNumber = new Textbox(txtPayCardNumberSelector);
        private Textbox txtPayCardHolder = new Textbox(By.XPath("//input[@id='PayCardHolder']"));
        private Textbox txtCardSecurityCode = new Textbox(By.XPath("//input[@id='CardSecurityCode']"));
        private Combobox cbPayCardExpireSplitMM = new Combobox(By.Id("PayCardExpireSplitMM"));
        private Combobox cbPayCardExpireSplitYY = new Combobox(By.Id("PayCardExpireSplitYY"));
        public void ClickConfirmButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnConfirm);
            }
        }

        public void ClickContinueToDepositButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnContinueToDeposit);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();

            }
        }

        public void ClickBackButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnBack);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void InputPayCardNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(txtPayCardNumberSelector);
                txtPayCardNumber.Clear();
                txtPayCardNumber.Input(input);
            }
        }
        public void InputPayCardHolder(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtPayCardHolder.Clear();
                txtPayCardHolder.Input(input);
            }
        }
        public void InputCardSecurityCode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtCardSecurityCode.Clear();
                txtCardSecurityCode.Input(input);
            }
        }
        public void InputPayCardExpire(string input)
        {
            if (input != "")
            {
                string[] date = input.Split("/");
                string part1 = date[0];
                string part2 = date[1];

                cbPayCardExpireSplitMM.Click();
                By optMonth = By.XPath($"(//option[text()='{date[0]}'])[2]");
                Thread.Sleep(500);
                _driver.FindElement(optMonth).Click();
                cbPayCardExpireSplitYY.Click();
                Thread.Sleep(500);
                By optYear = By.XPath($"(//option[text()='{date[1]}'])[1]");
                _driver.FindElement(optYear).Click();
            }
        }
        

        public void VerifyPaymentPrice(string input)
        {
            if (input == "Yes")
            {
                string actualText = BaseAction.FindElement(lblMonthPrice).Text;
                Assert.Contains("Total monthly payment", actualText);
                Assert.Contains(_monthlyPrice, actualText);
            }
        }

        public void VerifyPaymentPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input == "Yes")
            {
                Thread.Sleep(1000);
                var e = _driver.FindElements(lblTitle);
                Assert.True(e.Count > 0);
            }
        }

        public void VerifyWebReference(string input)
        {
            if(input == "Yes")
            {
                string actualRef = BaseAction.FindElement(lblWebRef).Text;
                Assert.Equal(_webRerence, actualRef);
            }
        }

        public void VerifyCDLPaymentPageTitle(string input)
        {
            if (input == "Yes")
            {
                bool isDisplayed = IsElementDisplayed(lblCDLTitle);
                Assert.True(isDisplayed);
            }
        }
    }
}
