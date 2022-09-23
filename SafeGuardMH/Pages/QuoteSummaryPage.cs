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
    public class QuoteSummaryPage : BasePage
    {
        private Button btnQuoteSummaryBack = new Button(By.Id("QuoteSummaryEditQuote"));
        By webReference = By.Id("Webreference");
        By firstName = By.XPath("//*[@class='thank-text']/span");
        private Button btnAnnualPaymentUnselect = new Button(By.Id("PaymentPanelAnnualPaymentUnselect"));
        private Button btnAnnualPaymentSelect = new Button(By.Id("PaymentPanelAnnualPaymentSelect"));
        private Button btnMonthlyPaymentSelect = new Button(By.Id("PaymentPanelMonthlyPaymentSelect"));
        private Button btnMonthlyPaymentUnSelect = new Button(By.Id("PaymentPanelMonthlyPaymentUnselect"));
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
        By txtQuotePaymentBasketNCBYear = By.XPath("//*[@class='payment-detail__item--inline']/span[text()='- Protected']");
        By txtVoluntaryExcessValue = By.Id("QuotePaymentBasketVoluntaryExcess");
        By txtTotalPaymentText = By.XPath("//*[@class='annual-section col-12 col-md-6']/h3[. ='Total payment']");
        By txtQuotePaymentBasketTotalAnnualPayment = By.Id("QuotePaymentBasketTotalAnnualPayment");
        By txtSinglePaymentCreditOrDebitCard = By.XPath("//h4[text() = ' A single payment today by Credit or Debit card ']");
        By txtInsurancePrices = By.XPath("//*[@class='payment-detail']/h4[@class='payment-detail__note text-bold']");
        By txtPaymentPanelDeposit = By.XPath("//p[@id='PaymentPanelNumberOfPayment']");
        By txtPaymentPanelFinanceCharge = By.XPath("//*[@id='PaymentPanelFinanceCharge']/span");
        By txtPaymentPanelTotalPayable = By.XPath("//*[@id='PaymentPanelTotalPayable']/span");
        By txtPaymentPanelAPR = By.XPath("//*[@id='PaymentPanelAPR']/span");
        By txtPaymentPanelInterestRate = By.XPath("//*[@id='PaymentPanelInterestRate']/span");
        By txtPaymentPanelMonthlyPaymentPremium = By.Id("PaymentPanelMonthlyPaymentPremium");
        By txtLegalCover = By.Id("DLPOpExAmount");
        By txtBreakdownWithEUCover = By.Id("BrkDwnEUOpExAmount");

        By txtQuotePaymentBasketDeposit = By.Id("QuotePaymentBasketDeposit");
        By txtQuotePaymentBasketMonthlyAmount = By.Id("QuotePaymentBasketMonthlyAmount");
        By txtTotalCredit = By.Id("QuotePaymentBasketTotalCredit");
        By txtQuotePaymentBasketFinanceCharge = By.Id("QuotePaymentBasketFinanceCharge");
        By txtQuotePaymentBasketTotalPayable = By.Id("QuotePaymentBasketTotalPayable");
        By txtQuotePaymentBasketAPR = By.Id("QuotePaymentBasketAPR");
        By txtQuotePaymentBasketInterestRate = By.Id("QuotePaymentBasketInterestRate");
        Label lblQuotePaymentBasketTotalAnnualPayment = new Label(By.Id("QuotePaymentBasketTotalAnnualPayment"));
        Label lblVoluntaryExcessValue = new Label(By.Id("QuotePaymentBasketVoluntaryExcess"));
        By lblNCBProtectedSelector = By.XPath("//span[@id='QuotePaymentBasketNCBYear']/following-sibling::span");
        By txtQuotePaymentBasketLegalCover = By.Id("QuotePaymentBasketLegalCover");
        By txtQuotePaymentBasketBreakdownWithEUCover = By.Id("QuotePaymentBasketBreakdownWithEUCover");
        Label lblPaymentTypeErrorMessage = new Label(By.CssSelector(".price-panel.ng-untouched.ng-pristine.ng-valid > p"));
        Label lblDriverLagalProtection = new Label(By.XPath("//h4[text() =' Driver’s Legal Protection ']"));
        Label lblUKHomeEUBreakdown = new Label(By.XPath("//h4[text() =' UK, Home & EU Breakdown ']"));
        By lblUKHomeEUBreakdownSelector = By.XPath("//h4[text() =' UK, Home & EU Breakdown ']");
        #region Action

        public void VerifyOptionalExtraWhenVehicleAgeIsLessThan20(string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                Assert.True(lblDriverLagalProtection.IsPresent());
                Assert.True(lblUKHomeEUBreakdown.IsPresent());
            }    
        }

        public void VerifyOptionalExtraWhenVehicleAgeIsMoreThan20(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.True(lblDriverLagalProtection.IsPresent());
                if(_driver.FindElements(lblUKHomeEUBreakdownSelector).Count > 0)
                {
                    throw new Exception("The test fail as the UK Home & EU Breakdown is appear in the page when vehicle age is more than 20");
                }    
            }
        }

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

        public void ClickQuoteSummaryContinue1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(1000);
                btnQuoteSummaryContinue.Click();
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
                //string financeChargeQuoteBasket = _driver.FindElement(txtQuotePaymentBasketFinanceCharge).Text.Trim();
                string totalPayableQuoteBasket = _driver.FindElement(txtQuotePaymentBasketTotalPayable).Text.Trim();
                string aPRQuoteBasket = _driver.FindElement(txtQuotePaymentBasketAPR).Text.Trim();
                string interestRateQuoteBasket = _driver.FindElement(txtQuotePaymentBasketInterestRate).Text.Trim();
                _informationQuote = new GuiModelData.InformationQuote();
                _informationQuote.Deposit = depositQuoteBasket;
                _informationQuote.Then11InstalmentsOf = then11InstalmsQuoteBasket;
                //_informationQuote.FinanceCharge = financeChargeQuoteBasket;
                _informationQuote.TotalCredit = _driver.FindElement(txtTotalCredit).Text.Trim();
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
                string basketPremium = _driver.FindElement(txtQuotePaymentBasketTotalAnnualPayment).Text.Trim();
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
                string[] paymentPanels = valueInPaymentPanel.Split(" ");

                string valueInQuotePaymentBasket = _driver.FindElement(txtQuotePaymentBasketDeposit).Text.Trim();
                Assert.Equal(paymentPanels[1], valueInQuotePaymentBasket);
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

        public void VerifyNoPaymentIsSelected(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("Select", btnAnnualPaymentSelect.GetText());
                Assert.Equal("Select", btnMonthlyPaymentSelect.GetText());
            }
        }

        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _informationQuote = new GuiModelData.InformationQuote();
                //_informationQuote.PaymentType =
                if (btnAnnualPaymentSelect.GetText().Equals("Selected"))
                {
                    _informationQuote.PaymentType = "Annual";

                }
                else
                {
                    _informationQuote.PaymentType = "Monthly";
                    _informationQuote.Deposit = _driver.FindElement(txtQuotePaymentBasketDeposit).Text.Trim();
                    _informationQuote.Then11InstalmentsOf = _driver.FindElement(txtQuotePaymentBasketMonthlyAmount).Text.Trim();
                    _informationQuote.TotalCredit = _driver.FindElement(txtTotalCredit).Text.Trim();
                    _informationQuote.APRRepresentative = _driver.FindElement(txtQuotePaymentBasketAPR).Text.Trim();
                    _informationQuote.InterestRate = _driver.FindElement(txtQuotePaymentBasketInterestRate).Text.Trim();
                }
                _informationQuote.TotalAnnualPayment = lblQuotePaymentBasketTotalAnnualPayment.GetText().Trim();
                _informationQuote.VoluntaryExcess = lblVoluntaryExcessValue.GetText().Trim();
                if (_driver.FindElements(lblNCBProtectedSelector).Count > 0)
                {
                    _informationQuote.NCBProtection = _driver.FindElement(lblNCBProtectedSelector).Text;
                }
            }
        }

        public void VerifyQuoteSummaryDataDisplayedCorrectly(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (_informationQuote.PaymentType.Equals("Annual"))
                {
                    Assert.Equal("Selected", btnAnnualPaymentUnselect.GetText());
                }
                else
                {
                    Assert.Equal("Selected", btnMonthlyPaymentUnSelect.GetText());
                    Assert.Equal(_informationQuote.Deposit, _driver.FindElement(txtQuotePaymentBasketDeposit).Text.Trim());
                    Assert.Equal(_informationQuote.Then11InstalmentsOf, _driver.FindElement(txtQuotePaymentBasketMonthlyAmount).Text.Trim());
                    Assert.Equal(_informationQuote.TotalCredit, _driver.FindElement(txtTotalCredit).Text.Trim());
                    Assert.Equal(_informationQuote.APRRepresentative, _driver.FindElement(txtQuotePaymentBasketAPR).Text.Trim());
                    Assert.Equal(_informationQuote.InterestRate, _driver.FindElement(txtQuotePaymentBasketInterestRate).Text.Trim());
                }
                Assert.Equal(_informationQuote.TotalAnnualPayment, lblQuotePaymentBasketTotalAnnualPayment.GetText().Trim());
                Assert.Equal(_informationQuote.VoluntaryExcess, lblVoluntaryExcessValue.GetText().Trim());
                if(!string.IsNullOrEmpty(_informationQuote.NCBProtection))
                {
                    Assert.Equal(_informationQuote.NCBProtection, _driver.FindElement(lblNCBProtectedSelector).Text);
                }
            }
        }

        public void VerifyPaymentTypeErrorMessageDisplayed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("Please select your preferred payment method from the options below:", lblPaymentTypeErrorMessage.GetText());
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
