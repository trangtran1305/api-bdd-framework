using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    class DirectDebitPage : BasePage
    {
        By confirmationTitle = By.XPath("//title[contains(text(), 'Confirmation')]");
        By lblTitle = By.XPath("//*[contains(text(), 'Setting up your Direct Debit')]");
        By lblWebRef = By.XPath("//div[contains(@class, 'text-quote-reference')]/b");
        By lblMonthPrice = By.XPath("//div[@class='total-monthly-payment']/div[@class='head']");
        static By txtAccountNameSelector = By.XPath("//input[@id='AccountHolderName']");
        private Textbox txtAccountName =new Textbox(txtAccountNameSelector);
        By txtSortCode1 = By.Id("SortCode1");
        By txtSortCode2 = By.Id("SortCode2");
        By txtSortCode3 = By.Id("SortCode3");
        By txtAccountNumber = By.Id("AccountNumber");
        By btnConfirm = By.XPath("//button[@id='ConfirmButton']");
        By btnDirecDebitPageContinue = By.Id("DirecDebitPageContinue");
        By btnBack = By.Id("DirectDebitPageBack");
        //By btnBack = By.CssSelector("#DirectDebitPageBack");
        //By lblCDLTitle = By.XPath("//*[@class='panel-title' and contains(text(), 'Your Card Details For Your Payment')]");
        //private Textbox txtPayCardNumber = new Textbox(By.Id("PayCardNumber"));
        //private Textbox txtPayCardHolder = new Textbox(By.Id("PayCardHolder"));
        //private Textbox txtCardSecurityCode = new Textbox(By.Id("CardSecurityCode"));
        //private Combobox cbPayCardExpireSplitMM = new Combobox(By.Id("PayCardExpireSplitMM"));
        //private Combobox cbPayCardExpireSplitYY = new Combobox(By.Id("PayCardExpireSplitYY"));
        public void ClickConfirmButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnConfirm);
                Thread.Sleep(500);
            }
        }

        public void ClickDirecDebitPageContinue(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnDirecDebitPageContinue);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();

            }
        }

        public void ClickBackButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnBack);
                Thread.Sleep(1000);
                ClickContinueOnTrialPage();
            }
        }


        public void InputAccountName(string input)
        {
            if (input != "")
            {
                Thread.Sleep(1000);
                //BaseAction.SetText(txtAccountName, input);
                txtAccountName.Clear();
                txtAccountName.Input(input);
            }
        }

        public void InputSortCode(string input)
        {
            if (input != "")
            {
                string[] codePart = input.Split("-");
                string part1 = codePart[0];
                string part2 = codePart[1];
                string part3 = codePart[2];
                //txtSortCode1.Input(input);
                //txtSortCode2.Input(input);
                //txtSortCode3.Input(input);
                BaseAction.SetText(txtSortCode1, part1);
                BaseAction.SetText(txtSortCode2, part2);
                BaseAction.SetText(txtSortCode3, part3);
            }
        }

        public void InputAccountNumber(string input)
        {
            if (input != "")
            {
                BaseAction.SetText(txtAccountNumber, input);
                //txtAccountNumber.Input(input);
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

        public void VerifyDirectDebitPageTitle(string input)
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

        //public void VerifyCDLPaymentPageTitle(string input)
        //{
        //    if (input == "Yes")
        //    {
        //        bool isDisplayed = IsElementDisplayed(lblCDLTitle);
        //        Assert.True(isDisplayed);
        //    }
        //}
    }
}
