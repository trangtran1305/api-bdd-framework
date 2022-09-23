using ScenicMH.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using System.Linq;

namespace ScenicMH.Pages
{
    public class CardConsentPage : BasePage
    {
        private Button btnCardPageContinueButton = new Button(By.Id("CardPageContinueButton"));
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

        public void BackFromQuoteReviewToQuoteSummary(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _driver.Navigate().Back();
                Thread.Sleep(2000);
            }
        }
        public void ClickCardPageContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnCardPageContinueButton.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(3000);
                WriteLogIfTechnicalError();
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
                Assert.True(IsElementDisplayed(By.Id("CardPageContinueButton")));
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
