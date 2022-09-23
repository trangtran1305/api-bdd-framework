using CNSBike.Pages;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CNSBike.Pages
{
    class QuoteReviewPage: BasePage
    {
        By txtPageTitle = By.XPath("//h4[contains(text(), 'Review your policy')]");
        By lblAnnualPayment = By.CssSelector("#QuoteReviewPaymentAnnualAmount");
        By lblMonthlyPayment = By.CssSelector("#QuoteReviewPaymentMonthlyTotalAmount");
        By lblFirstName = By.XPath("//h4//following-sibling::p[contains(@class, 'title-first-name')]");
        By tbxEmail = By.CssSelector("#QuoteReviewEmailAddress");
        By tbxPhone = By.CssSelector("#QuoteReviewPhoneNumber");
        By btnConfirmButton = By.CssSelector("#ConfirmationConfirmbutton");
        By btnContinueToPay = By.CssSelector("#Quote_Review_Next");

        public void ClickConfirmButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnConfirmButton);
            }
        }
        public void ClickContinueToPayButton(string input)
        {
            if (input == "Yes")
            {
                BaseAction.FindAndClick(btnContinueToPay);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();

            }
        }

        public void VerifyFirstName(string input)
        {
            if(input != "")
            {
                string actual = BaseAction.FindElement(lblFirstName).Text;
                Assert.Contains(input + ",", actual);
            }
        }

        public void VerifyEmail(string input)
        {
            if (input != "")
            {
                string actual = BaseAction.FindElement(tbxEmail).GetAttribute("value");
                Assert.Equal(input, actual);
            }
        }

        public void VerifyPhone(string input)
        {
            if (input != "")
            {
                string actual = BaseAction.FindElement(tbxPhone).GetAttribute("value");
                Assert.Equal(input, actual);
            }
        }

        public void VerifyQuoteReviewPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input == "Yes")
            {
                bool isDisplayed = IsElementDisplayed(txtPageTitle);
                Assert.True(isDisplayed);
            }            
        }

        public void VerifyTotalAnnualPayment(string input)
        {
            if (input == "Yes")
            {
                bool isDisplayed = IsElementDisplayed(lblAnnualPayment);
                Assert.True(isDisplayed);
            }
        }
        public void VerifyTotalMonthlyPayment(string input)
        {
            if (input == "Yes")
            {
                bool isDisplayed = IsElementDisplayed(lblMonthlyPayment);
                Assert.True(isDisplayed);
            }
        }
    }
}
