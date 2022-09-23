using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    class DirectDebitDetailsPage : BasePage 
    {
        private By pageTitle = By.XPath("//title[contains(text(), 'Direct Debit')]");
        private By cbSecci = By.Id("DirectDebitConfirmSECCI");
        private By secciError = By.Id("AcceptSECCI-error");
        private By acceptAffordabilityError = By.Id("AcceptAffordability-error");
        private By cbAffordability = By.Id("DirectDebitConfirmAffordability");
        private Textbox txbAcountName = new Textbox(By.Id("AccountHolderName"));
        private Textbox txbAcountNumber = new Textbox(By.Id("AccountNumber"));
        private Textbox txbSortCode = new Textbox(By.Id("SortCode"));
        private Textbox txbBankBuidingSocietyName = new Textbox(By.Id("BankBuildingSocietyName"));
        private By btnContinue = By.Id("DDBankDetailsContinueButton");
        private By btnBack = By.Id("DDBankDetailsBackButton");
        private By lblReferenceNumber = By.XPath("//*[contains(text(), 'Reference Number')]/b");
        private By txtFirstSortCoder = By.Id("FirstSortCode");
        private By txtSecondSortCoder = By.Id("SecondSortCode");
        private By txtThirdSortCoder = By.Id("ThirdSortCode");

        public void VerifyDirectDebitDetailsPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                if (input.Equals("Yes"))
                {
                    Thread.Sleep(1000);
                    var count = _driver.FindElements(pageTitle).Count;
                    Assert.True(count > 0);
                }
            }

        }
        public void InputAndVerifyBankSortCodeFocusBahviour(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string[] bankSortCode = input.Split('-');
                Find(txtFirstSortCoder).SendKeys(bankSortCode[0]);
                var focusEleId = _driver.SwitchTo().ActiveElement().GetAttribute("id");
                Assert.Equal(Find(txtSecondSortCoder).GetAttribute("id"), focusEleId);
                Find(txtSecondSortCoder).SendKeys(bankSortCode[1]);
                focusEleId = _driver.SwitchTo().ActiveElement().GetAttribute("id");
                Assert.Equal(Find(txtThirdSortCoder).GetAttribute("id"), focusEleId);
                Find(txtThirdSortCoder).SendKeys(bankSortCode[2]);
            }

        }
        public void SelectCheckboxAcceptSecci(string input)
        {
            if (input.Equals("Yes"))
            {
                ClickByJavascript(cbSecci);
            }
        }
        public void SelectCheckboxAcceptAffordability(string input)
        {
            if (input.Equals("Yes"))
            {
                ClickByJavascript(cbAffordability);
            }
        }
        public void InputAccountName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {               
                txbAcountName.Input(input);
            }
        }
        public void InputAccountNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txbAcountNumber.Input(input);
            }
        }
        public void InputSortCode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string[] bankSortCode = input.Split('-');
                Find(txtFirstSortCoder).SendKeys(bankSortCode[0]);
                Find(txtSecondSortCoder).SendKeys(bankSortCode[1]);
                Find(txtThirdSortCoder).SendKeys(bankSortCode[2]);
            }
        }
        public void InputBankBuildingSocietyName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txbBankBuidingSocietyName.Input(input);
            }
        }
        public void ClickContinue(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnContinue);
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }
        public void ClickBack(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnBack);
                Thread.Sleep(2000);
            }
        }

        public void VerifyReferenceNumber(string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                Assert.Equal(GetElementText(lblReferenceNumber), input);
            }
        }

        public void VerifyBankSortCode(string input)
        {
            if(input.Equals("Yes"))
            {
                IsElementDisplayed(txtFirstSortCoder);
                IsElementDisplayed(txtSecondSortCoder);
                IsElementDisplayed(txtThirdSortCoder);
            }
        }


    }
}
