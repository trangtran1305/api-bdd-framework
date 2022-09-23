using SafeGuardMH.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using System.Linq;
using ProjectCore.Configurations;

namespace SafeGuardMH.Pages
{
    public class QuoteRetrievePage : BasePage
    {
        public TestConfigs _configs = new TestConfigs();
        private Textbox txtQuoteRetrieveWebRef = new Textbox(By.Id("QuoteRetrieveWebRef"));
        private Textbox txtQuoteRetrievePostCode = new Textbox(By.Id("QuoteRetrievePostCode"));
        private Textbox txtQuoteRetrieveDoB_Day = new Textbox(By.Id("QuoteRetrieveDoB_Day"));
        private Textbox txtQuoteRetrieveDoB_Month = new Textbox(By.Id("QuoteRetrieveDoB_Month"));
        private Textbox txtQuoteRetrieveDoB_Year = new Textbox(By.Id("QuoteRetrieveDoB_Year"));
        private Button btnQuoteRetrieveButton = new Button(By.Id("QuoteRetrieveButton"));
        
        
        private Label lbQuoteReviewPaymentInterestRate = new Label(By.Id("QuoteRetrieveButton"));


        public void NavigateToQuoteRetrieve(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var globalSettings = _configs.GlobalConfig;
                _driver.Navigate().GoToUrl(globalSettings.BaseUrl + "/mh/newbus/retrieve-quote");
                WaitForLoadingIconDisappear();

            }
        }

        public void InputQuoteRetrieveWebRef(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(By.Id("QuoteRetrieveWebRef"));
                txtQuoteRetrieveWebRef.Input(_webReference);
                Thread.Sleep(500);
                while (txtQuoteRetrieveWebRef.GetPopulatedValue() != _webReference)
                {
                    txtQuoteRetrieveWebRef.Input(_webReference);
                }
            }
        }

        public void InputQuoteRetrievePostCode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtQuoteRetrievePostCode.Input(input);
            }
        }

        public void InputDateOfBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                //txtQuoteRetrieveDoB_Day.Clear();
                txtQuoteRetrieveDoB_Day.Input(splittedDate.Item1);
                txtQuoteRetrieveDoB_Month.Input(splittedDate.Item2);
                txtQuoteRetrieveDoB_Year.Input(splittedDate.Item3);
            }
        }

        public void ClickQuoteRetrieveButton(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnQuoteRetrieveButton.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(3000);
                WriteLogIfTechnicalError();
            }
        }


        public void VerifyQuoteRetrievePageDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var quoteRetrieveButton = By.Id("QuoteRetrieveButton");
                WaitUntilElementExists(quoteRetrieveButton);
                //Thread.Sleep(3000);
                Assert.True(IsElementDisplayed(quoteRetrieveButton));
            }
        }
        
        
    }
}
