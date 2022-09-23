using CNRenewalPortal.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    public class PaymentGatewayPage : BasePage
    {
        static By txtPayCardNumberSelector = By.XPath("//input[@id='PayCardNumber']");
        private Textbox txtPayCardNumber = new Textbox(txtPayCardNumberSelector);
        private Textbox txtPayCardHolder = new Textbox(By.XPath("//input[@id='PayCardHolder']"));
        private Textbox txtCardSecurityCode = new Textbox(By.XPath("//input[@id='CardSecurityCode']"));
        private Combobox cbPayCardExpireSplitMM = new Combobox(By.Id("PayCardExpireSplitMM"));
        private Combobox cbPayCardExpireSplitYY = new Combobox(By.Id("PayCardExpireSplitYY"));

        private static By btnCardPageContinueButtonSelector = By.XPath("//*[@name='next.y']");
        private Button btnCardPageContinueButton = new Button(btnCardPageContinueButtonSelector);
        private By pageTitle = By.XPath("//title[text()='Card Payment']");
        private Button btnBack = new Button(By.XPath("//button[@name='back.y']"));
        public void InputPayCardNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(2000);
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
                Thread.Sleep(200);
                _driver.FindElement(optMonth).Click();
                cbPayCardExpireSplitYY.Click();
                Thread.Sleep(200);
                By optYear = By.XPath($"(//option[text()='{date[1]}'])[1]");
                _driver.FindElement(optYear).Click();
            }
        }
        public void ClickCardPageContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnCardPageContinueButton.Click();
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }

        public void ClickBack(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnBack.Click();
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }
        public void VerifyPaymentGatewayPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                Thread.Sleep(1500);
                var count = _driver.FindElements(pageTitle).Count;
                Assert.True(count > 0);
            }
        }
 
    }
}

