using CNRenewalPortal.Pages.GuiModelData;
using CNRenewalPortal.Tests;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Xunit;

namespace CNRenewalPortal.Pages
{
    public class VerificationPage : BasePage
    {
        DateTime now = DateTime.Now;
        private Textbox txtFirstName = new Textbox(By.Id("FirstName"));
        private Textbox txtLastName = new Textbox(By.Id("LastName"));
        private Textbox txtEmailAddress = new Textbox(By.Id("EmailAddress"));
        private Textbox txtPolicyReferenceNumber = new Textbox(By.Id("PolicyReferenceNumber"));
        private Textbox txtBirthDay = new Textbox(By.Id("BirthDay"));
        private Textbox txtBirthMonth = new Textbox(By.Id("BirthMonth"));
        private Textbox txtBirthYear = new Textbox(By.Id("BirthYear"));
        private Button btnContinue = new Button(By.Id("VerificationContinueButton"));
        private Button btnBack = new Button(By.Id("VerificationBackButton"));
        private By errorFirstName = By.XPath("//div[@id='firstName']//div[@class='input-error-msg']/span");
        private By errorLastName = By.XPath("//div[@id='lastName']//div[@class='input-error-msg']/span");
        private By errorMsgUnderPolicyRefNumber = By.XPath("//div[@id='policyReferenceNumber']//div[@class='input-error-msg']/span");
        private By errorMsgDateOfBirth = By.XPath("//div[@id='dateOfBirth']//div[@class='input-error-msg']/span");
        private By errorMsgEmail = By.XPath("//div[@id='emailAddress']//div[@class='input-error-msg']/span");
        private static Verification verification;
        private readonly string paymentDataFile = "RenewPortal_Data Test for automation.xlsx";
        private readonly string sheetName = "PaymentInfo";
        private By lbErrorValidation = By.Id("errorValidation");
        BasePage basePage = new BasePage();

        public new void NavigateTo(string input)
        {
            if (input.Equals("Yes"))
            {
                basePage.NavigateTo("Verification");
                WaitForLoadingIconDisappear();
            }
        }
        public void InputFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFirstName.Clear();
                txtFirstName.Input(input);
            }
        }
        public void InputLastName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtLastName.Clear();
                txtLastName.Input(input);
            }
        }
        public void InputEmailAddress(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtEmailAddress.Clear();
                txtEmailAddress.Input(input);
            }
        }
        public void InputPolicyReferenceNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtPolicyReferenceNumber.Clear();
                txtPolicyReferenceNumber.Input(input);
            }
        }
        public void InputDateOfBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtBirthDay.Clear();
                txtBirthDay.Input(splittedDate.Item1);
                txtBirthMonth.Clear();
                txtBirthMonth.Input(splittedDate.Item2);
                txtBirthYear.Clear();
                txtBirthYear.Input(splittedDate.Item3);
                Thread.Sleep(1000);
            }
        }

        public void ClickContinue(string input)
        {
            if (input.Equals("Yes"))
            {
                btnContinue.Click();
                WaitForLoadingIconDisappear();
                if (_driver.FindElements(By.Id("VerificationContinueButton")).Count > 0)
                {
                    btnContinue.Click();
                    WaitForLoadingIconDisappear();
                }
            }
        }
        public void ClickBack(string input)
        {
            if (input.Equals("Yes"))
            {
                btnBack.Click();
            }
        }

        public void VerifyVerificationPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                Thread.Sleep(2000);
                var result = _driver.Url.Contains("Verification");
                Assert.True(result);
            }
        }

        public void VerifyInvalidDataErrorMessageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var result = _driver.FindElements(lbErrorValidation).Count;
                Assert.True(result > 0);
            }
        }

        public void RefreshPage(string input)
        {
            if (input.Equals("Yes"))
            {
                Refresh();
                WaitForLoadingIconDisappear();
            }
        }

        public void VerifyDataDisplayOnPage(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Equal(verification.FirstName, txtFirstName.GetPopulatedValue());
                Assert.Equal(verification.LastName, txtLastName.GetPopulatedValue());
                Assert.Equal(verification.Email, txtEmailAddress.GetPopulatedValue());
                Assert.Equal(verification.ReferenceNumber, txtPolicyReferenceNumber.GetPopulatedValue());
                Assert.Equal(verification.Day, txtBirthDay.GetPopulatedValue().TrimStart('0'));
                Assert.Equal(verification.Month, txtBirthMonth.GetPopulatedValue().TrimStart('0'));
                Assert.Equal(verification.Year, txtBirthYear.GetPopulatedValue());
            }
        }

        public void GetInfoDisplayOnVerificationPage(string input)
        {
            if (input.Equals("Yes"))
            {
                verification = new Verification();
                verification.FirstName = txtFirstName.GetPopulatedValue();
                verification.LastName = txtLastName.GetPopulatedValue();
                verification.Email = txtEmailAddress.GetPopulatedValue();
                verification.ReferenceNumber = txtPolicyReferenceNumber.GetPopulatedValue();
                verification.Day = txtBirthDay.GetPopulatedValue().TrimStart('0');
                verification.Month = txtBirthMonth.GetPopulatedValue().TrimStart('0');
                verification.Year = txtBirthYear.GetPopulatedValue();
            }
        }
        public void GetInputDataTest(string input)
        {
            if (input.Equals("Yes"))
            {
                 verification =  HandleExcelFile.GetDataFromExcelFile(paymentDataFile, sheetName);
            }
        }
        public void PushDataTest(string input)
        {
            if (input.Equals("Yes"))
            {
                txtFirstName.Input(verification.FirstName);
                txtLastName.Input(verification.LastName);
                txtPolicyReferenceNumber.Input(verification.ReferenceNumber);
                txtEmailAddress.Input(verification.Email);
                txtBirthDay.Input(verification.Day);
                txtBirthMonth.Input(verification.Month);
                txtBirthYear.Input(verification.Year);

            }
        }
    }


    public class Verification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ReferenceNumber { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string IsLock { get; set; }

    }
}
