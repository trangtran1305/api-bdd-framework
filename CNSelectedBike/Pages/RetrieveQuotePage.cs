using CNSBike.Pages;
using log4net;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Xunit;


namespace CNSBike.Pages
{
    public class RetrieveQuotePage : BasePage
    {
        public string webRef = "";

        By txtYourWebRef = By.CssSelector("#WebReference");
        By txtPostCode = By.CssSelector("#Postcode");
        By txtBirthDay = By.CssSelector("#BirthDay");
        By txtBirthMonth = By.CssSelector("#BirthMonth");
        By txtBirthYear = By.CssSelector("#BirthYear");
        By btnRetrieveQuote = By.CssSelector("#RetrieveQuote");

        public void GetWebReference(string input)
        {
            if(input == "Yes")
            {
                string url = GetCurrnetURL();
                int endIndex = url.Length - 1;
                int startIndex = url.IndexOf("=") + 1;
                webRef = url.Substring(startIndex, endIndex - startIndex + 1);
            }
        }
        public void NavigateToRetrieveQuotePage(string input)
        {
            ClickContinueOnTrialPage();

            if (input == "Yes")
            {
                NavigateTo("/mc/quote-retrieve");
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
                ClickContinueOnTrialPage();

            }
        }

        public void InputWebReference(string input)
        {
                ClickContinueOnTrialPage();
            if (input == "Yes")
            {
                Thread.Sleep(3000);
                BaseAction.SetText(txtYourWebRef, webRef);
            }
        }
        public void InputPostCode(string input)
        {
            if (input != "")
            {
                BaseAction.SetText(txtPostCode, input);
            }
        }

        public void InputDateOfBirth(string input)
        {
            if (input != "")
            {
                string[] datePart = input.Split("/");
                string day = datePart[0];
                string month = datePart[1];
                string year = datePart[2];
                BaseAction.SetText(txtBirthDay, day);
                BaseAction.SetText(txtBirthMonth, month);
                BaseAction.SetText(txtBirthYear, year);
            }
        }

        public void ClickRetrieveQuoteButton(string input)
        {
            if(input != "")
            {
                BaseAction.FindAndClick(btnRetrieveQuote);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }

    }
}
