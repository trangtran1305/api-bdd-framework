using SafeGuardMH.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using System.Linq;

namespace SafeGuardMH.Pages
{
    public class CardConsentPage : BasePage
    {
        private Button btnCardPageContinueButton = new Button(By.Id("CardPageContinueButton"));
        private By title = By.XPath("//h2[contains(text(), 'Your insurance quote')]");
        By txtCardBelongToPolicyHolder = By.XPath("//*[@id='CardPageProposerIsCardHolder']");
        By txtAssumptiveText = By.XPath("/html/body/div/section/app-scenic-card-page/section/section/h4");
        //Q1
        private Button btnCardPageProposerIsCardHolderYes = new Button(By.Id("CardPageProposerIsCardHolderYes"));
        private Button btnCardPageProposerIsCardHolderNo = new Button(By.Id("CardPageProposerIsCardHolderNo"));
        //Q3
        private Button btnCardPageCardStoreConsentYes = new Button(By.Id("CardPageCardStoreConsentYes"));
        private Button btnCardPageCardStoreConsentNo = new Button(By.Id("CardPageCardStoreConsentNo"));
        //Q2
        private Button btnCardPageCardAutoResuseConsentYes = new Button(By.Id("CardPageCardAutoResuseConsentYes"));
        private Button btnCardPageCardAutoResuseConsentNo = new Button(By.Id("CardPageCardAutoResuseConsentNo"));

        //Q2 Direct debit
        private Button btnCardPageCardAutoRenewConsentYes = new Button(By.Id("CardPageCardAutoRenewConsentYes"));
        private Button btnCardPageCardAutoRenewConsentNo = new Button(By.Id("CardPageCardAutoRenewConsentNo"));

        private Checkbox cbCardBelongToThePolicyHolder = new Checkbox(By.CssSelector(".mr-3"));
        private Label lblContent1 = new Label(By.CssSelector("h4.text-bold"));
        private Label lblContent2 = new Label(By.CssSelector("span.row.ml-1"));
        private Label lblContent3 = new Label(By.CssSelector("h4.text-font-md"));

        private LinkText linkFindOutMore = new LinkText(By.CssSelector("div.text-primary.text-bold"));
        private Label lblFindOutMore = new Label(By.CssSelector("div.find-out-more"));
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
                Assert.True(IsElementDisplayed(By.CssSelector(".mr-3 > img")));
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
                Assert.True(ele.Count == 0);
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

        public void VerifyQ1IsCheckedOnLandingThePage(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.True(_driver.FindElement(By.CssSelector(".mr-3 > img")).Displayed);
            }
        }

        public void VerifyYesIsPreselectedToQ2OnLandingThePage(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("isActive", btnCardPageCardAutoRenewConsentYes.GetAttributeValue("class"));
            }
        }

        public void ChooseNoToQ2(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                btnCardPageCardAutoRenewConsentNo.Click();
            }
        }

        public void VerifyUserCanSelectNoToQ2(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("isActive", btnCardPageCardAutoRenewConsentNo.GetAttributeValue("class"));
            }
        }
        public void UntickQ1(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                cbCardBelongToThePolicyHolder.Click();
            }
        }
        public void VerifyQ2AndTitleIsHiddenWhenUncheckingQ1(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.False(IsElementDisplayed(By.Id("CardPageCardAutoResuseConsentYes")));
                Assert.False(IsElementDisplayed(By.Id("CardPageCardAutoResuseConsentNo")));
            }
        }

        public void VerifyQ2AndTitleIsDisplayedWhenRecheckingQ1(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Thread.Sleep(1000);
                Assert.True(IsElementDisplayed(By.Id("CardPageCardAutoResuseConsentYes")));
                Assert.True(IsElementDisplayed(By.Id("CardPageCardAutoResuseConsentNo")));
            }
        }

        public void VerifyNewContentIsUnderShowingAllTimeUnderQ2(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("  What if I change my mind?", lblContent1.GetText());
                Assert.Equal("No need to worry, it's quick and easy to let us know -  \r\nfind out more", lblContent2.GetText());
                Assert.Equal(" You are using this card to pay for the deposit for your insurance, the remaining balance will be paid by Direct Debit. We will securely store these card details just in case there is a future change to your policy which you don’t want to add to your Direct Debit or for any other amounts that may become due. If you’d prefer we didn’t store these card details please call and let us know. ", lblContent1.GetText());
            }
        }

        public void ClickFindOutMoreLink(string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                linkFindOutMore.Click();
            }
        }

        public void VerifyFindOutMoreContentExpaned(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.True(lblFindOutMore.IsPresent());
            }
        }

        public void VerifyFindOutMoreContentColapsed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Empty(_driver.FindElements(By.CssSelector("div.find-out-more")));
            }
        }
    }
}
