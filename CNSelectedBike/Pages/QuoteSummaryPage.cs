using CNSBike.Pages.SqlDatabase;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using ProjectCore.SQL;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CNSBike.Pages
{
    public class QuoteSummaryPage : BasePage
    {
        private By pageTitle = By.XPath("//h2[text()='Your Quote']");
        private By webReference = By.XPath("//*[@id='Webreference']/b");
        private By userName = By.CssSelector("#ProposerName");
        private By btnContinue = By.XPath("(//button[@id='QuoteSummaryContinue'])[last()]");
        private By btnMonthlyPaymentSelect = By.CssSelector("#PaymentPanelMonthlyPaymentSelect");
        private By btnAnnualPaymentSelect = By.CssSelector("#PaymentPanelAnnualPaymentUnselect");

        private By lblPanelAnnualPrice = By.CssSelector("#PaymentPanelAnnualPaymentPremium");
        private By lblPanelMonthlyPrice = By.CssSelector("#PaymentPanelMonthlyPaymentPremium");
        private By lblPanelDeposit = By.CssSelector("#PaymentPanelDeposit");
        private By lblPanelFinanceCharge = By.CssSelector("#PaymentPanelFinanceCharge");
        private By lblPanelTotalPayable = By.CssSelector("#PaymentPanelTotalPayable");
        private By lblPanelAPR = By.CssSelector("#PaymentPanelAPR");
        private By lblPanelInterestRate = By.CssSelector("#PaymentPanelInterestRate");

        private By lblTotalAnnualPayment = By.CssSelector("#QuotePaymentBasketTotalAnnualPayment");
        private By lblDeposit = By.CssSelector("#QuotePaymentBasketDeposit");
        private By lblInstalment = By.CssSelector("#QuotePaymentBasketMonthlyAmount");
        private By lblFinanceCharge = By.CssSelector("#QuotePaymentBasketFinanceCharge");
        private By lblTotalPayable = By.CssSelector("#QuotePaymentBasketTotalPayable");
        private By lblBasketAPR = By.CssSelector("#QuotePaymentBasketAPR");
        private By lblInterestRate = By.CssSelector("#QuotePaymentBasketInterestRate");

        private By lblStickyBarAnnualPayment = By.CssSelector("#StickyBarAnnualPayment");
        private By lblStickyBarMonthlyPayment = By.CssSelector("#StickyBarMonthlyPayment");
        private Button btnPaymentPanelAnnualPaymentSelect = new Button(By.Id("PaymentPanelAnnualPaymentSelect"));
        private Button btnPaymentPanelMonthlyPaymentSelect = new Button(By.Id("PaymentPanelMonthlyPaymentSelect"));

        private FluentSqlClient<QuoteDb> _quoteDataSqlClient;
        private string quoteDataConnectionString;

        
        public QuoteSummaryPage()
        {
                ClickContinueOnTrialPage();
            //save web reference
            _webRerence = _driver.FindElement(webReference).Text;
            //save price
            _monthlyPrice = _driver.FindElement(lblPanelMonthlyPrice).Text;


            var sqlHelper = new SqlHelper();
            quoteDataConnectionString = sqlHelper.GetConnectionString("TrackingDb");
            _quoteDataSqlClient = new FluentSqlClient<QuoteDb>(new DatabaseConnectionFactory(quoteDataConnectionString));
        }

        public void ClickPaymentMethod(string input)
        {
            if (input.Contains("Annual"))
            {
                btnPaymentPanelAnnualPaymentSelect.Click();
            } else if (input.Contains("Month"))
            {
                btnPaymentPanelMonthlyPaymentSelect.Click();
            }
        }
        public void VerifyQuoteSummaryPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input.Equals("Yes"))
            {
                bool isDisplayed = IsElementDisplayed(pageTitle);
                Assert.True(isDisplayed);
            }
        }
        public void VerifyWebReference(string input)
        {
            if (input.Equals("Yes"))
            {
                string pageRef = _driver.FindElement(webReference).Text;
                string url = GetCurrnetURL();
                int endIndex = url.Length - 1;
                int startIndex = url.IndexOf("=") + 1;
                string urlRef = url.Substring(startIndex, endIndex - startIndex + 1);
                Assert.Equal(pageRef, urlRef);
            }
        }

        public void VerifyUserName(string input)
        {
            if(input != "")
            {
                WaitUntilElementExists(userName);
                string actualName = Find(userName).Text;
                Assert.Equal(actualName, input);
            }
        }

        public async Task<JObject> GetQuoteResponseFromQuoteDb(string webReference)
        {
            var query = new Query("Quote")
                .Where("WebReference", webReference)
                .Take(1)
                .OrderByDesc("DateCreated")
                .Select(nameof(QuoteDb.QuoteRequest), nameof(QuoteDb.QuoteResponse));

            var records = await _quoteDataSqlClient.Get(query);
            if (records.Count == 0)
            {
                Console.WriteLine("No record found in database.");
                return null;
            }
            var record = records.FirstOrDefault();
            var storeInformation = record.WebReference;
            var jsonObjectStoreInformation = JObject.Parse(storeInformation);
            return jsonObjectStoreInformation;
        }

        public void ClickContinueButton(string input)
        {
            if(input == "Yes")
            {
                BaseAction.FindAndClick(btnContinue);
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
                ClickContinueOnTrialPage();
            }

        }

        public void SelectMonthlyPayment(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnMonthlyPaymentSelect);
            }
        }

        public void VerifyPanelPriceAnnual(string input)
        {
            if (input == "Yes")
            {
                Assert.True(IsElementDisplayed(lblPanelAnnualPrice));
            }
        }

        public void VerifyPanelPriceMonthly(string input)
        {
            if (input == "Yes")
            {
                Assert.True(IsElementDisplayed(lblPanelMonthlyPrice));
                Assert.True(IsElementDisplayed(lblPanelDeposit));
                Assert.True(IsElementDisplayed(lblPanelFinanceCharge));
                Assert.True(IsElementDisplayed(lblPanelTotalPayable));
                Assert.True(IsElementDisplayed(lblPanelAPR));
                Assert.True(IsElementDisplayed(lblPanelInterestRate));

            }
        }

        public void VerifyPriceQuoteSummaryAnnual(string input)
        {
            if (input == "Yes")
            {
                Assert.True(IsElementDisplayed(lblTotalAnnualPayment));
            }
        }

        public void VerifyPriceQuoteSummaryMonthly(string input)
        {
            if (input == "Yes")
            {
                Assert.True(IsElementDisplayed(lblInstalment));
                Assert.True(IsElementDisplayed(lblDeposit));
                Assert.True(IsElementDisplayed(lblFinanceCharge));
                Assert.True(IsElementDisplayed(lblTotalPayable));
                Assert.True(IsElementDisplayed(lblBasketAPR));
                Assert.True(IsElementDisplayed(lblInterestRate));

            }
        }

        public void VerifyStickyBarAnnualPayment(string input)
        {
            if (input == "Yes")
            {
                Assert.True(IsElementDisplayed(lblStickyBarAnnualPayment));
            }
        }

        public void VerifyStickyBarMonthlyPayment(string input)
        {
            if (input == "Yes")
            {
                Assert.True(IsElementDisplayed(lblStickyBarMonthlyPayment));
            }
        }
        

    }

}

