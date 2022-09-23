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
    public class QuoteSummaryPage : BasePage
    {
        private Button btnQuoteSummaryBack = new Button(By.Id("QuoteSummaryEditQuote"));
        By webReference = By.Id("Webreference");
        By firstName = By.XPath("//*[@class='thank-text']/span");
        private Button btnAnnualPaymentUnselect = new Button(By.Id("PaymentPanelAnnualPaymentUnselect"));
        private Button btnAnnualPaymentSelect = new Button(By.Id("PaymentPanelAnnualPaymentSelect"));
        private Button btnMonthlyPaymentSelect = new Button(By.Id("PaymentPanelMonthlyPaymentSelect"));
        private Button btnQuoteSummaryContinue = new Button(By.Id("QuoteSummaryContinue"));
        private Button btnDLPOpExSelectButton = new Button(By.Id("DLPOpExSelectButton"));
        private Button btnBrkDwnEUOpExSelectButton = new Button(By.Id("BrkDwnEUOpExSelectButton"));
        private Button btnBrkDwnOpExSelectButton = new Button(By.Id("BrkDwnOpExSelectButton"));
        private Button btnProtectNCBSelect = new Button(By.Id("ProtectNCBSelect"));
        private Button btnProtectNCBNo = new Button(By.Id("ProtectNCBNo"));
        private Button btnVoluntaryExcess4 = new Button(By.Id("VoluntaryExcess4"));
        By btnProtectNCBSelected = By.Id("ProtectNCBSelected");
        By txtQuotePaymentBasketCoverType = By.Id("QuotePaymentBasketCoverType");
        By txtQuotePaymentBasketPremium = By.Id("QuotePaymentBasketPremium");
        By txtPaymentPanelAnnualPaymentPremium = By.Id("PaymentPanelAnnualPaymentPremium");
        By txtQuotePaymentBasketNCBYear = By.XPath("//*[@class='payment-detail__item--inline']/span[.=' - Protected']");
        By txtVoluntaryExcessValue = By.Id("QuotePaymentBasketVoluntaryExcess");
        By txtTotalPaymentText = By.XPath("//*[@class='annual-section col-12 col-md-6']/h3[. ='Total payment']");
        By txtQuotePaymentBasketTotalAnnualPayment = By.Id("QuotePaymentBasketTotalAnnualPayment");
        By txtSinglePaymentCreditOrDebitCard = By.XPath("//*[@class='payment-detail']/h4[. ='A single payment today by Credit or Debit card']");
        By txtInsurancePrices = By.XPath("//*[@class='payment-detail']/h4[@class='payment-detail__note text-bold']");
        By txtPaymentPanelDeposit = By.XPath("//*[@id='PaymentPanelDeposit']/span");
        By txtPaymentPanelFinanceCharge = By.XPath("//*[@id='PaymentPanelFinanceCharge']/span");
        By txtPaymentPanelTotalPayable = By.XPath("//*[@id='PaymentPanelTotalPayable']/span");
        By txtPaymentPanelAPR = By.XPath("//*[@id='PaymentPanelAPR']/span");
        By txtPaymentPanelInterestRate = By.XPath("//*[@id='PaymentPanelInterestRate']/span");
        By txtPaymentPanelMonthlyPaymentPremium = By.Id("PaymentPanelMonthlyPaymentPremium");
        By txtLegalCover = By.Id("DLPOpExAmount");
        By txtBreakdownWithEUCover = By.Id("BrkDwnEUOpExAmount");

        By txtQuotePaymentBasketDeposit = By.Id("QuotePaymentBasketDeposit");
        By txtQuotePaymentBasketMonthlyAmount = By.Id("QuotePaymentBasketMonthlyAmount");
        By txtQuotePaymentBasketFinanceCharge = By.Id("QuotePaymentBasketFinanceCharge");
        By txtQuotePaymentBasketTotalPayable = By.Id("QuotePaymentBasketTotalPayable");
        By txtQuotePaymentBasketAPR = By.Id("QuotePaymentBasketAPR");
        By txtQuotePaymentBasketInterestRate = By.Id("QuotePaymentBasketInterestRate");
        By txtQuotePaymentBasketLegalCover = By.Id("QuotePaymentBasketLegalCover");
        By txtQuotePaymentBasketBreakdownWithEUCover = By.Id("QuotePaymentBasketBreakdownWithEUCover");

        #region Action

        public void BackFromQuoteToHistory(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnQuoteSummaryBack.Click();
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }
        public void ClickPaymentMethod(string input)
        {
            if (input.Contains("Annual"))
            {
                btnAnnualPaymentSelect.Click();
            }
            else if (input.Contains("Month"))
            {
                btnMonthlyPaymentSelect.Click();
            }
        }
        public void ClickQuoteSummaryContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(1000);
                btnQuoteSummaryContinue.Click();
                WaitForLoadingIconDisappear();
                WaitUntilElementExists(QuoteReviewPage.Quote_Review_Form);
            }
        }
        public void ClickOpExSelected(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnDLPOpExSelectButton.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(2000);
                btnBrkDwnEUOpExSelectButton.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(2000);
            }
        }
        public void ClickProtectNCBSelect(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProtectNCBSelect.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(4000);
            }
            else if (input.Equals("No thanks"))
            {
                btnProtectNCBNo.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(3000);
            }
        }
        public void ClickVoluntaryExcess4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnVoluntaryExcess4.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(5000);
            }
        }

        public void GetTotalPaymentAnnual(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(txtQuotePaymentBasketTotalAnnualPayment);
                //Thread.Sleep(1000);
                string paymentQuoteBasket = _driver.FindElement(txtQuotePaymentBasketTotalAnnualPayment).Text.Trim();

                _informationQuote = new GuiModelData.InformationQuote();
                _informationQuote.TotalAnnualPayment = paymentQuoteBasket;
            }

        }
        public void GetTotalPaymentMonthly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string paymentQuoteBasket = _driver.FindElement(txtQuotePaymentBasketTotalAnnualPayment).Text.Trim();
                string depositQuoteBasket = _driver.FindElement(txtQuotePaymentBasketDeposit).Text.Trim();
                string then11InstalmsQuoteBasket = _driver.FindElement(txtQuotePaymentBasketMonthlyAmount).Text.Trim();
                string financeChargeQuoteBasket = _driver.FindElement(txtQuotePaymentBasketFinanceCharge).Text.Trim();
                string totalPayableQuoteBasket = _driver.FindElement(txtQuotePaymentBasketTotalPayable).Text.Trim();
                string aPRQuoteBasket = _driver.FindElement(txtQuotePaymentBasketAPR).Text.Trim();
                string interestRateQuoteBasket = _driver.FindElement(txtQuotePaymentBasketInterestRate).Text.Trim();
                _informationQuote = new GuiModelData.InformationQuote();
                _informationQuote.Deposit = depositQuoteBasket;
                _informationQuote.Then11InstalmentsOf = then11InstalmsQuoteBasket;
                _informationQuote.FinanceCharge = financeChargeQuoteBasket;
                _informationQuote.TotalAmountPayable = totalPayableQuoteBasket;
                _informationQuote.APRRepresentative = aPRQuoteBasket;
                _informationQuote.InterestRate = interestRateQuoteBasket;
            }

        }
        #endregion
        #region Verify error message
        public void VerifyQuotePageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(By.Id("Summary_Form"));
                Thread.Sleep(1000);
                var elements = _driver.FindElements(By.Id("Webreference"));
                bool isTrue = elements.Count > 0;
                Assert.True(isTrue);
            }
        }
        public void VerifyWebReferenceDisplayedExactly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string quoteReference = _driver.FindElement(webReference).Text;
                string reference = quoteReference.Split(":").Last().Trim();
                string url = _driver.Url;
                string referUrl = url.Split("=").Last().Trim();
                Assert.Equal(reference, referUrl);
            }
        }
        public void VerifyFirstNameDisplayedExactly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string name = _driver.FindElement(firstName).Text.Trim();
                Assert.Equal(name, input);
            }
        }
        public void VerifyPaymentIsSelected(string input)
        {
            if (input.Equals("Annual"))
            {
                Assert.True(IsElementDisplayed(By.Id("PaymentPanelAnnualPaymentUnselect")));
                Assert.True(IsElementBehind(By.Id("PaymentPanelAnnualPaymentSelect")));
            }
            else if (input.Equals("Monthly"))
            {
                Assert.True(IsElementDisplayed(By.Id("PaymentPanelMonthlyPaymentUnselect")));
                Assert.True(IsElementBehind(By.Id("PaymentPanelMonthlyPaymentSelect")));
            }
        }
        public void VerifyAllOptionalExtraSelected(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal("Selected", _driver.FindElement(By.Id("DLPOpExSelectButton")).Text);
            }
        }
        public void VerifyProtectNCBSelected(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementDisplayed(btnProtectNCBSelected));
            }
            else if (input.Equals("No thanks"))
            {
                bool isNoThanksSelected = btnProtectNCBNo.GetAttributeValue("class").Contains("isActive");
                Assert.True(isNoThanksSelected);

            }
        }
        public void VerifyOpExSelected(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                bool isExtraSelected = btnDLPOpExSelectButton.GetAttributeValue("class").Contains("isActive");
                bool isBrkDwnEUSelected = _driver.FindElement(By.Id("BrkDwnEUOpExSelectButton")).Text.Contains("Selected");
                Assert.True(isBrkDwnEUSelected);
                Assert.True(isExtraSelected);
            }
        }
        public void VerifyVoluntaryExcess4Selected(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                bool isVoluntaryExcess4Selected = btnVoluntaryExcess4.GetAttributeValue("class").Contains("isActive");
                Assert.True(isVoluntaryExcess4Selected);
            }
        }
        public void VerifyQuotePaymentBasketCoverType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(input, _driver.FindElement(txtQuotePaymentBasketCoverType).Text);
            }
        }
        public void VerifyAnnualPaymentPremium(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string basketPremium = _driver.FindElement(txtQuotePaymentBasketPremium).Text.Trim();
                string panelPremium = _driver.FindElement(txtPaymentPanelAnnualPaymentPremium).Text.Trim();
                Assert.Equal(basketPremium, panelPremium);
            }
        }
        public void VerifyQuotePaymentBasketNCBYear(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementDisplayed(txtQuotePaymentBasketNCBYear));
            }
            else if (input.Equals("No thanks"))
            {
                Assert.True(IsElementBehind(txtQuotePaymentBasketNCBYear));
            }
        }
        public void VerifyVoluntaryExcessValue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string value = _driver.FindElement(txtVoluntaryExcessValue).Text.Trim();
                bool isTrue = value.Contains(input);
                Assert.True(isTrue);
            }
        }
        public void VerifyTotalPaymentText(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtTotalPaymentText));
            }
        }
        public void VerifyTotalPayment(string input)
        {
            if (input.Equals("No thanks"))
            {
                string totalPremium = _driver.FindElement(txtQuotePaymentBasketTotalAnnualPayment).Text.Trim();
                string panelPremium = _driver.FindElement(txtPaymentPanelAnnualPaymentPremium).Text.Trim();
                Assert.Equal(totalPremium, panelPremium);
            }
        }
        public void VerifySinglePaymentCreditOrDebitCardDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtSinglePaymentCreditOrDebitCard));
            }
        }
        public void VerifyInsurancePricesDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtInsurancePrices));
            }
        }
        public void VerifyDepositDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtPaymentPanelDeposit).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketDeposit).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyMonthlyAmountDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtPaymentPanelMonthlyPaymentPremium).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketMonthlyAmount).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyFinanceChargeDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtPaymentPanelFinanceCharge).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketFinanceCharge).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyTotalPayableDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtPaymentPanelTotalPayable).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketTotalPayable).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyAPRDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtPaymentPanelAPR).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketAPR).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyInterestRateDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtPaymentPanelInterestRate).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketInterestRate).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyEUCoverDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtBreakdownWithEUCover).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketBreakdownWithEUCover).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyLegalCoverDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string valueInPaymentPanel = _driver.FindElement(txtLegalCover).Text.Trim();
                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketLegalCover).Text.Trim();
                Assert.Equal(valueInPaymentPanel, valueInQuotePaymentBasket);
            }
        }
        public void VerifyTotalPaymentAnnual(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string paymentQuoteBasket = _driver.FindElement(txtQuotePaymentBasketTotalAnnualPayment).Text.Trim();
                Assert.Equal(_informationQuote.TotalAnnualPayment, paymentQuoteBasket);
            }

        }
        #endregion
        public string GetWebReference(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string currentURl = _driver.Url;
                _webReference = currentURl.Substring(currentURl.LastIndexOf("=") + 1);
            }
            return _webReference;
        }
    }
}
