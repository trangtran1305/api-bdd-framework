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
    public class CardConsentPage : BasePage
    {
        private static By btnCardPageContinueButtonSelector = By.XPath("//*[@name='next.y']");
        private Button btnCardPageContinueButton = new Button(btnCardPageContinueButtonSelector);
        private By title = By.XPath("//h2[contains(text(), 'Your insurance quote')]");
        By txtCardBelongToPolicyHolder = By.XPath("//*[@id='CardPageProposerIsCardHolder']/div/label/p");
        By txtAssumptiveText  = By.XPath("/html/body/div/section/app-scenic-card-page/section/section/h4");
        //Q1
        private Button btnCardPageProposerIsCardHolderYes = new Button(By.Id("CardPageProposerIsCardHolderYes"));
        private Button btnCardPageProposerIsCardHolderNo = new Button(By.Id("CardPageProposerIsCardHolderNo"));
        //Q3
        private Button btnCardPageCardStoreConsentYes = new Button(By.Id("CardPageCardStoreConsentYes"));
        private Button btnCardPageCardStoreConsentNo = new Button(By.Id("CardPageCardStoreConsentNo"));
        //Q2
        private Button btnCardPageCardAutoResuseConsentYes = new Button(By.Id("CardPageCardAutoResuseConsentYes"));
        private Button btnCardPageCardAutoResuseConsentNo = new Button(By.Id("CardPageCardAutoResuseConsentNo"));
        static By txtPayCardNumberSelector = By.XPath("//input[@id='PayCardNumber']");
        private Textbox txtPayCardNumber = new Textbox(txtPayCardNumberSelector);
        private Textbox txtPayCardHolder = new Textbox(By.XPath("//input[@id='PayCardHolder']"));
        private Textbox txtCardSecurityCode = new Textbox(By.XPath("//input[@id='CardSecurityCode']"));
        private Combobox cbPayCardExpireSplitMM = new Combobox(By.Id("PayCardExpireSplitMM"));
        private Combobox cbPayCardExpireSplitYY = new Combobox(By.Id("PayCardExpireSplitYY"));

        public void InputPayCardNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(2000);
                WaitUntilElementVisible(txtPayCardNumberSelector);
                txtPayCardNumber.Clear();
                txtPayCardNumber.Input(input);
                //BaseAction.SetText(txtAccountName, input);
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
                By optMonth = By.XPath($"//*[text()='{date[0]}']");
                WaitUntilElementVisible(optMonth);
                //Thread.Sleep(200);
                _driver.FindElement(optMonth).Click();
                cbPayCardExpireSplitYY.Click();
                //Thread.Sleep(200);
                By optYear = By.XPath($"//*[text()='{date[1]}']");
                WaitUntilElementVisible(optYear);
                _driver.FindElement(optYear).Click();
            }
        }
        public void BackFromQuoteReviewToQuoteSummary(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _driver.Navigate().Back();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(1000);
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
        public void SelectCardStoreConsent(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCardPageCardStoreConsentYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCardPageCardStoreConsentNo.Click();
            }
        }
        public void SelectCardBelongToPolicyHolder(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCardPageProposerIsCardHolderYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCardPageProposerIsCardHolderNo.Click();
            }
        }
        public void SelectCardAutoResuseConsent(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCardPageCardAutoResuseConsentYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCardPageCardAutoResuseConsentNo.Click();
            }
        }
        public void VerifyCardConsentPageDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(btnCardPageContinueButtonSelector));
            }
        }
        public void VerifyCardBelongToPolicyHolderDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtCardBelongToPolicyHolder));
            }
        }
        public void VerifyAssumptiveTextDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtAssumptiveText));
            }
        }
        public void VerifyCardAutoResuseConsentStatus(string input)
        {
            if (input.Equals("Yes"))
            {
                string status = btnCardPageCardAutoResuseConsentYes.GetAttributeValue("class");
                Assert.Equal("isActive", status);
            }
            else if (input.Equals("No"))
            {
                string status = btnCardPageCardAutoResuseConsentNo.GetAttributeValue("class");
                Assert.Equal("isActive", status);

            }
        }
        public void VerifyCardAutoResuseConsentDisappeared(string input)
        {
            if (input.Equals("Yes"))
            {
                var ele = _driver.FindElements(By.Id("CardPageCardAutoResuseConsentYes"));
                Assert.True(ele.Count==0);
            }
            else if (input.Equals("No"))
            {
                var ele = _driver.FindElements(By.Id("CardPageCardAutoResuseConsentNo"));
                Assert.True(ele.Count == 0);
            }
        }
        public void VerifyCardStoreConsentDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
               Assert.True(IsElementDisplayed(By.Id("CardPageCardStoreConsentYes")));
            }
        }
        public void VerifyCardStoreConsentStatus(string input)
        {
            if (input.Equals("Yes"))
            {
                string status = btnCardPageCardStoreConsentYes.GetAttributeValue("class");
                Assert.Equal("isActive", status);
            }
            else if (input.Equals("No"))
            {
                string status = btnCardPageCardStoreConsentNo.GetAttributeValue("class");
                Assert.Equal("isActive", status);

            }
        }
        public void VerifyCardStoreConsentDisappeared(string input)
        {
            if (input.Equals("Yes"))
            {
                var ele = _driver.FindElements(By.Id("CardPageCardStoreConsentYes"));
                Assert.True(ele.Count == 0);
            }
            else if (input.Equals("No"))
            {
                var ele = _driver.FindElements(By.Id("CardPageCardStoreConsentNo"));
                Assert.True(ele.Count == 0);
            }
        }
        public void VerifyWebReferenceShowedExactly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string webRefer = _driver.FindElement(By.XPath("//*[@class='quote-reference']/h4")).Text.Split(":").Last().Trim();
                string webReferQuoteReview = _informationQuote.WebReference;
                Assert.Equal(webRefer, webReferQuoteReview);
            }
        }
        public void VerifyTotalAnnualPaymentShowedExactly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string totalAnnualPayment = _driver.FindElement(By.XPath("//*[@class='text-primary text-normal d-flex']/h2")).Text.Trim();
                string totalAnnualPaymentQuoteReview = _informationQuote.TotalAnnualPayment;
                Assert.Equal(totalAnnualPayment, totalAnnualPaymentQuoteReview);
            }
        }
    }
}
