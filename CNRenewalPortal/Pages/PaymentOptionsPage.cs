using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    class PaymentOptionsPage : BasePage
    {
        private string titleText = "Your Payment Options";
        private By pageTitle = By.XPath("//h2[@class='title po']");
        private By btnAnnualSelect = By.Id("AnnualPaymentSelect");
        private By btnMonthlySelect = By.Id("MonthlyPaymentSelect");
        private By btnFuturePaymentYes = By.Id("StoreCardYes");
        private By btnFuturePaymentNo = By.Id("StoreCardNo");
        private By btnBack = By.XPath("//button[contains(text(),'Back')]");
        private By btnContinue = By.Id("PaymentOptionsMakePaymentButton");
        private By selectPaymentOptionMessage = By.Id("SelectPaymentOptionMess");
        private By storeCardMessage = By.Id("StoreCardMessage");
        private By cbSendDocument = By.Id("SendPaperDocument");
        private By cbConfirmCorrectInformation = By.Id("ConfirmCorrectInformation");
        private By confirmCorrectInformationMessage = By.XPath("//div[@id='ConfirmCorrectInformationMessage']/p");
        private By lblPaymentAnnualTitle = By.XPath("//*[@id='PaymentPanelAnnualPaymentPremium']//preceding-sibling::h2");
        private By lblPaymentMonthlyTitle = By.XPath("//*[@id='PaymentPanelMonthlyPaymentPremium']//preceding-sibling::h2");
        private By lblRenewalDate = By.XPath("//*[@id='//div[@class='your-renweal']//p");
        private By lblDeposit = By.Id("PaymentPanelDeposit");
        private By lblFinanceCharge = By.Id("PaymentPanelFinanceCharge");
        private By lblTotalPayment = By.Id("PaymentPanelTotalPayable");
        private By lblAPR = By.Id("PaymentPanelAPR");
        private By lblInterestRate = By.Id("PaymentPanelInterestRate");
        private static InstalmntPayment ip;

        public void VerifyPaymentOptionsPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                Thread.Sleep(2000);
                var result = GetElementText(pageTitle);
                Assert.Equal(titleText, result);
            }
        }
        public void ClickPaymentType(string input)
        {
            if (string.Equals(input.Trim(), "Annual", StringComparison.CurrentCultureIgnoreCase))
            {
                Click(btnAnnualSelect);
            }
            else if(string.Equals(input.Trim(), "Monthly", StringComparison.CurrentCultureIgnoreCase))
            {
                Click(btnMonthlySelect);
            }
        }
        public void VerifySelectPaymentOptionMessageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var count = _driver.FindElements(selectPaymentOptionMessage).Count;
                Assert.True(count > 0);
            }
        }
        public void ClickMakeFuturePayment(string input)
        {
            if (input.Equals("Yes"))
            {
                ClickByJavascript(btnFuturePaymentYes);
            }
            else if (input.Equals("No"))
            {
                ClickByJavascript(btnFuturePaymentNo);
            }
        }
        public void VerifyStoreCardMessageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var count = _driver.FindElements(storeCardMessage).Count;
                Assert.True(count > 0);
            }
        }
        public void SelectCheckboxSendDocument(string input)
        {
            if (input.Equals("Yes"))
            {
               ClickByJavascript(cbSendDocument);
            }         
        }
        public void SelectCheckboxConfirmYourDetail(string input)
        {
            if (input.Equals("Yes"))
            {
                ClickByJavascript(cbConfirmCorrectInformation);
            }            
        }
        public void VerifyConfirmCorrectInformationMessageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var result = GetElementText(confirmCorrectInformationMessage);
                Assert.Equal(result, "Please tick to confirm this statement before continuing");
            }
        }
        public void ClickContinue(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnContinue);
                WaitForLoadingIconDisappear();
            }
        }
        public void ClickBack(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnBack);
                Thread.Sleep(3000);
            }
        }
        public void VerifyThirdPartyPaymentPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
              //Continue
            }
        }

        public void VerifyAnnualPaymentLabel(string input)
        {
            if(input.Equals("Yes"))
            {
                Assert.Equal(GetElementText(lblPaymentAnnualTitle), "Annual payment");
            }
        }

        public void VerifyMonthlyPaymentLabel(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Contains(GetElementText(lblPaymentMonthlyTitle), "monthly payments of");
            }
        }

        public void VerifyRenewalDateLabel(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Contains(GetElementText(lblRenewalDate), "Your renewal is due on");
            }
        }

        public void RefeshPage(string input)
        {
            if (input.Equals("Yes"))
            {
                Refresh();
            }
        }

        public void CheckDataDisplayOnPaymentOptionsPage(string input)
        {
            if(input.Equals("Yes"))
            {
                Assert.Equal(ip.Deposit, GetElementText(lblDeposit));
                Assert.Equal(ip.FinanceCharge, GetElementText(lblFinanceCharge));
                Assert.Equal(ip.TotalAmountPayable, GetElementText(lblTotalPayment));
                Assert.Equal(ip.APRRepresentative, GetElementText(lblAPR));
                Assert.Equal(ip.InterestRate, GetElementText(lblInterestRate));
            }
        }


        public void GetInstalmntPaymentInfo(string input)
        {
            if (input.Equals("Yes"))
            {
                string deposit = GetElementText(lblDeposit);
                string financeChange = GetElementText(lblFinanceCharge);
                string totalAmount = GetElementText(lblTotalPayment);
                string apr = GetElementText(lblAPR);
                string interest = GetElementText(lblInterestRate);
                ip = new InstalmntPayment
                {
                    Deposit = deposit,
                    FinanceCharge = financeChange,
                    TotalAmountPayable = totalAmount,
                    APRRepresentative = apr,
                    InterestRate = interest
                };
            }
        }

    }

    public class InstalmntPayment
    {
        public string Deposit { get; set; }
        public string FinanceCharge  { get; set; }
        public string TotalAmountPayable{ get; set; }
        public string APRRepresentative { get; set; }
        public string InterestRate { get; set; }
    }
}
