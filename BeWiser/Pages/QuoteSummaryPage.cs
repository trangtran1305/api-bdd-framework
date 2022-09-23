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
    public class QuoteSummaryPage : BasePage
    {
        private Button btnQuoteSummaryBack = new Button(By.Id("QuoteSummaryEditQuote"));
        By webReference = By.Id("Webreference");
        By firstName = By.Id("ProposerName");
        private Button btnAnnualPaymentUnselect = new Button(By.Id("PaymentPanelAnnualPaymentUnselect"));
        private Button btnAnnualPaymentSelect = new Button(By.Id("PaymentPanelAnnualPaymentSelect"));
        private Button btnMonthlyPaymentSelect = new Button(By.Id("PaymentPanelMonthlyPaymentSelect"));
        private Button btnQuoteSummaryContinue = new Button(By.Id("QuoteSummaryContinue"));
        // may be removed
        private Button btnDLPOpExSelectButton = new Button(By.Id("DLPOpExSelectButton"));
        private Button btnBrkDwnEUOpExSelectButton = new Button(By.Id("BrkDwnEUOpExSelectButton"));
        private Button btnBrkDwnOpExSelectButton = new Button(By.Id("BrkDwnOpExSelectButton"));
        // end removed
        private static By btnProtectNCBSelectSelector = By.XPath("//button[@id='ProtectNCBSelect']");
        private Button btnProtectNCBSelect = new Button(btnProtectNCBSelectSelector);
        private Button btnProtectNCBNo = new Button(By.Id("ProtectNCBNo"));
        By btnProtectNCBSelected = By.Id("ProtectNCBSelected");
        By txtQuotePaymentBasketCoverType = By.Id("QuoteSummaryCoverType");
        By txtQuotePaymentBasketPremium = By.Id("QuotePaymentBasketTotalAnnualPayment");
        By txtPaymentPanelAnnualPaymentPremium = By.Id("PaymentPanelAnnualPaymentPremium");
        //By txtQuotePaymentBasketNCBYear = By.XPath("//*[@class='payment-detail__item--inline']/span[.=' - Protected']");
        By txtVoluntaryExcessValue = By.Id("QuotePaymentBasketVoluntaryExcess");
        By txtTotalPaymentText = By.Id("QuotePaymentBasketTotalAnnualPayment");
        By txtQuotePaymentBasketTotalAnnualPayment = By.Id("QuotePaymentBasketTotalAnnualPayment");
        By txtSinglePaymentCreditOrDebitCard = By.XPath("//*[@class='payment-detail']/h4[. ='A single payment today by Credit or Debit card']");
        By txtInsurancePrices = By.XPath("//span[contains(text(), 'Protector Insurance')]");
        By txtPaymentPanelDeposit = By.XPath("//*[@id='PaymentPanelDeposit']/b");
        By txtPaymentPanelFinanceCharge = By.XPath("//*[@id='PaymentPanelFinanceCharge']/b");
        By txtPaymentPanelTotalPayable = By.XPath("//*[@id='PaymentPanelTotalPayable']/b");
        By txtPaymentPanelAPR = By.XPath("//*[@id='PaymentPanelAPR']/b");
        By txtPaymentPanelInterestRate = By.XPath("//*[@id='PaymentPanelInterestRate']/b");
        By txtPaymentPanelMonthlyPaymentPremium = By.Id("PaymentPanelMonthlyPaymentPremium");
        By txtLegalCover = By.Id("DLPOpExAmount");
        By txtBreakdownWithEUCover = By.Id("BrkDwnEUOpExAmount");

        By txtQuotePaymentBasketDeposit = By.XPath("//*[@id='PaymentPanelDeposit']/b");
        By txtQuotePaymentBasketMonthlyAmount = By.XPath("//*[@id='PaymentPanelMonthlyPaymentPremium']");
        By txtQuotePaymentBasketFinanceCharge = By.XPath("//*[@id='PaymentPanelFinanceCharge']/b");
        By txtQuotePaymentBasketTotalPayable = By.XPath("//*[@id='PaymentPanelTotalPayable']/b");
        By txtQuotePaymentBasketAPR = By.XPath("//*[@id='PaymentPanelAPR']/b");
        By txtQuotePaymentBasketInterestRate = By.XPath("//*[@id='PaymentPanelInterestRate']/b");
        By txtQuotePaymentBasketLegalCover = By.Id("QuotePaymentBasketLegalCover");
        By txtQuotePaymentBasketBreakdownWithEUCover = By.Id("QuotePaymentBasketBreakdownWithEUCover");
        private Combobox cbVoluntaryExcess = new Combobox(By.XPath("//ng-select[@id='VoluntaryExcess']"));
        private Button btnBrkDwnRoadsideSelect = new Button(By.Id("BrkDwnRoadsideSelectButton"));
        private Button btnBrkDwnRoadsideUKSelect = new Button(By.Id("BrkDwnRoadsideUKSelectButton"));
        private Button btnBrkDwnUKHomestartSelect = new Button(By.Id("BrkDwnUKHomestartSelectButton"));
        private Button btnBrkDwnEUSelect = new Button(By.Id("BrkDwnEUSelectButton"));
        private Button btnBrkDwnOpExNoThanksButton = new Button(By.Id("BrkDwnOpExNoThanksButton"));
        private Button btnLegalSelectBtn = new Button(By.Id("LegalSelectBtn"));
        private Button btnBrkDwnEUSelectButton = new Button(By.Id("BrkDwnEUSelectButton"));
        private Button btnChangeInsurerOverlayContinue = new Button(By.Id("ChangeInsurerOverlayContinue"));
        private Button btnExcessInsurance = new Button(By.Id("ExcessSelectBtn"));
        By lbInsurancePrice = By.XPath("//button[@id='ExcessSelectBtn']/preceding-sibling::div/h1");
        By lbInsurancePriceBasket = By.XPath("//*[contains(text(), 'Excess Protector Insurance')]/following-sibling::b");
        By lbQuotePaymentBasketNCBYear = By.Id("QuotePaymentBasketNCBYear");
        #region Action
        public void BackFromQuote(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnQuoteSummaryBack.Click();
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
        public void ClickQuoteSummaryContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnQuoteSummaryContinue.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
                WaitUntilElementVisible(QuoteReviewPage.Quote_Review_Form);
            }
        }
        public void ClickPaymentMethod(string input)
        {
            if (input.Equals("Annual", StringComparison.CurrentCultureIgnoreCase))
            {
                btnAnnualPaymentSelect.Click();
            }
            else if (input.Equals("Monthly", StringComparison.CurrentCultureIgnoreCase))
            {
                btnMonthlyPaymentSelect.Click();
            }
        }
        public void ClickLegalOpex(string input)
        {
            if (input.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                btnLegalSelectBtn.Click();
            }
        }
        public void ClickBreakdownCover4(string input)
        {
            if (input.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                btnBrkDwnEUSelectButton.Click();
            }
        }
        public void VerifyLegalOpexSelected(string input)
        {
            if (input.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                Assert.Equal("Selected", btnLegalSelectBtn.GetText().Trim());
            }
        }
        public void VerifyBreakdownCover4Selected(string input)
        {
            if (input.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                Assert.Equal("Selected", btnBrkDwnEUSelectButton.GetText().Trim());
            }
        }

        public void ClickProtectNCBSelect(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProtectNCBSelect.Click();
                WaitForLoadingIconDisappear();
            }
            else if (input.Equals("No thanks"))
            {
                btnProtectNCBNo.Click();
                WaitForLoadingIconDisappear();
            }
        }
        public void SelectVoluntaryExcess(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbVoluntaryExcess.SelectByText(input);
                WaitForLoadingIconDisappear();
            }
        }

        public void VerifyVoluntaryExcess(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(input, cbVoluntaryExcess.GetText());
                Assert.Contains(input, _driver.FindElement(txtVoluntaryExcessValue).GetAttribute("innerText").Trim());
            }
        }
        public void ClickExcessInsurance(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnExcessInsurance.Click();
            }
        }

        public void GetTotalPaymentAnnual(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementVisible(txtQuotePaymentBasketTotalAnnualPayment);
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

        #region Verify page displayed
        public void VerifyQuotePageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(By.Id("Summary_Form"));
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
                Assert.True(IsElementDisplayed(By.Id("PaymentPanelMonthlyPaymentSelect")));
            }
            else if (input.Equals("Monthly"))
            {
                Assert.True(IsElementDisplayed(By.Id("PaymentPanelMonthlyPaymentUnselect")));
                Assert.True(IsElementDisplayed(By.Id("PaymentPanelAnnualPaymentSelect")));
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
                Assert.True(IsElementDisplayed(lbQuotePaymentBasketNCBYear));
            }
            else if (input.Equals("No thanks"))
            {
                Assert.True(IsElementBehind(btnProtectNCBSelected));
                Assert.True(IsElementBehind(lbQuotePaymentBasketNCBYear));
            }
        }
        public void VerifyVoluntaryExcessSelected(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string voluntaryExcess = cbVoluntaryExcess.GetText().Trim().Replace("×", "");
                Assert.Equal(input, voluntaryExcess);
            }
        }
        public void VerifyQuotePaymentBasketCoverType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var coverType = _driver.FindElement(txtQuotePaymentBasketCoverType).Text;
                Assert.Equal(input, coverType);
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
                Assert.True(IsElementDisplayed(lbQuotePaymentBasketNCBYear));
            }
            else if (input.Equals("No thanks"))
            {
                Assert.True(IsElementBehind(lbQuotePaymentBasketNCBYear));
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
        public void VerifyInsurancePricesCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(_driver.FindElement(lbInsurancePrice).GetAttribute("innerText").Trim(),
                    _driver.FindElement(lbInsurancePrice).GetAttribute("innerText").Trim());
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
