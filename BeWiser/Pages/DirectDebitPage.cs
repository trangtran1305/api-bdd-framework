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
    public class DirectDebitPage : BasePage
    {
        public static By btnDirecDebitPageContinueSelector = By.Id("DirecDebitPageContinue");
        private Button btnDirecDebitPageContinue = new Button(btnDirecDebitPageContinueSelector);
        private Button btnDirectDebitPageBack = new Button(By.Id("btnBack"));
        private Textbox txtAccountHolderName = new Textbox(By.Id("AccountHolderName"));
        private Textbox txtSortCode1 = new Textbox(By.Id("SortCode1"));
        private Textbox txtSortCode2 = new Textbox(By.Id("SortCode2"));
        private Textbox txtSortCode3 = new Textbox(By.Id("SortCode3"));
        private Textbox txtAccountNumber = new Textbox(By.Id("AccountNumber"));
        By totalPayment = By.Id("MonthlyAmount");
        By deposit = By.Id("Deposit");
        By then11Instalmens = By.Id("NumberOfPayment");
        By financeCharge = By.Id("FinanceCharge");
        By totalPayable = By.Id("TotalPayable");
        By aPR = By.Id("APR");
        By interestRate = By.Id("InterestRate");
        By btnConfirmation = By.Id("ConfirmButton");
        public void ClickDirecDebitContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnDirecDebitPageContinue.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(1000);
            }
        }
        public void ClickDirectDebitBack(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnDirectDebitPageBack.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(1000);
            }
        }
        public void VerifyDirectDebitPageDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(3000);
                Assert.True(IsElementDisplayed(By.Id("DirecDebitPageContinue")));
            }
        }
        public void InputAccountHolderName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtAccountHolderName.Clear();
                txtAccountHolderName.Input(input);
            }
        }
        public void InputSortCode1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtSortCode1.Input(input);
            }
        }
        public void InputSortCode2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtSortCode2.Input(input);
            }
        }
        public void InputSortCode3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtSortCode3.Input(input);
            }
        }
        public void InputAccountNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtAccountNumber.Input(input);
            }
        }
        public void SelectCheckBoxConfirmation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _driver.FindElement(btnConfirmation).Click();
            }
        }
        public void VerifyWebReferenceShowExactly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string web = _driver.FindElement(By.XPath("//div[contains(@class,'text-quote-reference')]/b")).Text.Trim();

                string webQuoteReview = _informationQuote.WebReference;
                    Assert.Equal(webQuoteReview, web);
            }
        }
        public void VerifyTotalPaymentShowExactly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string depositDirectDebit = _driver.FindElement(deposit).Text.Trim();
                string then11InstalmensDirectDebit = _driver.FindElement(then11Instalmens).Text.Trim();
                string financeChargeDirectDebit = _driver.FindElement(financeCharge).Text.Trim();
                string totalPayableDirectDebit = _driver.FindElement(totalPayable).Text.Trim();
                string aPRDirectDebit = _driver.FindElement(aPR).Text.Trim();
                string interestRateDirectDebit = _driver.FindElement(interestRate).Text.Trim();

                Assert.Equal(_informationQuote.Deposit, depositDirectDebit);
                Assert.Equal(_informationQuote.Then11InstalmentsOf, then11InstalmensDirectDebit);
                Assert.Equal(_informationQuote.FinanceCharge, financeChargeDirectDebit);
                Assert.Equal(_informationQuote.TotalAmountPayable, totalPayableDirectDebit);
                Assert.Equal(_informationQuote.APRRepresentative, aPRDirectDebit);
                Assert.Equal(_informationQuote.InterestRate, interestRateDirectDebit);
            }
        }
    }
}
