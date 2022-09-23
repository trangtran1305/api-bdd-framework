using CNBike.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    class QuoteSummaryPage : BasePage
    {
        private By pageIndicate = By.Id("QuoteSummaryForm");

        private By btnPayYearSelectionLabelSplit = By.Id("PayYearSelectionLabelSplit");
        private By btnPayMonthSelectionLabelSplit = By.Id("PayMonthSelectionLabelSplit");
        private By btnPricePresent_ChangeCover = By.Id("PricePresent_ChangeCover");
        private By btnYourMotorcycle = By.Id("btnYourMotorcycle");
        //Tailor your cover
        private By ddlPricePresent_voluntaryExcess = By.Id("PricePresent_voluntaryExcess");
        private By PayMonthSelectionLabelSplit = By.Id("PayMonthSelectionLabelSplit");
        private By PayYearSelectionLabelSplit = By.Id("PayYearSelectionLabelSplit");

        //Extra Protection
        public void ClickBtnYourMotorcycle(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(1500);
                Click(btnYourMotorcycle);
            }
        }
        public void ClickPaymentMethod(string input)
        {
            if (input.Contains("Annual"))
            {
                Click(PayYearSelectionLabelSplit);
            }
            else if (input.Contains("Month"))
            {
                Click(PayMonthSelectionLabelSplit);
            }
        }
        public void ClickPricePresentChangeCover(string input)
        {
            Click(btnPricePresent_ChangeCover);
        }

        private By btnBtnNext = By.Id("btnNext");


        public void VerifyPageTitle(string input)
        {
            Thread.Sleep(1000);
            var count = _driver.FindElements(pageIndicate).Count;
            Assert.True(count > 0);
        }

        public void ClickPayYearSelectionLabelSplit(string input)
        {
            Click(btnPayYearSelectionLabelSplit);
        }

        public void ClickPayMonthSelectionLabelSplit(string input)
        {
            Thread.Sleep(2000);
            Click(btnPayMonthSelectionLabelSplit);
        }

        public void ClickNextPage(string input)
        {
            if (input.Equals("Required"))
            {
                //GetInfoQuoteSummaryPage();
                //WaitUntilElementVisible(btnBtnNext);
                Thread.Sleep(1000);
                ClickByJavascript(btnBtnNext);
                WaitForLoadingIconDisappear();
                if(_driver.FindElements(pageIndicate).Count > 0)
                {
                    Click(btnBtnNext);
                    WaitForLoadingIconDisappear();
                }
            }
        }

        public void GetInfoQuoteSummaryPage(string input)
        {
            if (input.Equals("Required"))
            {
                var cacheModel = getCookie();
                Thread.Sleep(1000);
                var isMonthPayment = Find(PayMonthSelectionLabelSplit).GetAttribute("class").Contains("btn-green");
                var quote = new QuoteSummary();
                quote.Type = isMonthPayment == true ? "month" : "year";
                quote.TotalPayment = GetDataFromPayment("h4", "Total payment");
                quote.TotalMonthPayment = GetDataFromPayment("h5", " Total monthly payment ");
                quote.Deposit = GetDataFromPayment("p", "Deposit (payable today) ");
                quote.InstalmentsOf = GetDataFromPayment("p", "Then 12 instalments of: ");
                quote.FinanceCharge = GetDataFromPayment("p", "Finance charge ");
                quote.TotalAmount = GetDataFromPayment("p", "Total amount payable ");
                quote.APRRepresentative = GetDataFromPayment("p", "APR representative ");
                //quote.InterestRate = GetDataFromPayment("p", "Interest rate ");
                var interestRate = _driver.FindElement(By.XPath("//div[contains(text(), 'Interest rate')]")).Text.Trim();
                quote.InterestRate = interestRate.Substring(interestRate.IndexOf("rate") + 5, interestRate.Length - 14);
                cacheModel.QuoteSummary = quote;
                addCookie(cacheModel);
            }
        }

        public string GetDataFromPayment(string parentTag, string parentText)
        {
            try
            {
                var XPathString = By.XPath($"//span[@id='btnHideQuoteSummary']/../../../div//{parentTag}[text()='{parentText}']/following-sibling::span[1]");
                return _driver.FindElement(XPathString).Text;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
