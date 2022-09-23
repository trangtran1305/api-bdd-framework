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
    public class QuoteReviewPage : BasePage
    {
        public static By btnQuoteReviewContinueSelector = By.Id("QuoteReviewContinue");
        public static By Quote_Review_Form = By.Id("Quote_Review_Form");
        private Button btnQuoteReviewContinue = new Button(btnQuoteReviewContinueSelector);
        private Textbox txtQuoteReviewEmailAddress = new Textbox(By.Id("QuoteReviewEmailAddress"));
        private Textbox txtQuoteReviewPhoneNumber = new Textbox(By.Id("QuoteReviewPhoneNumber"));
        private Button btnTermConfirmation = new Button(By.XPath("//p[@id='ConfirmationConfirm']/preceding-sibling::div"));
        
        private Label lbQuoteReviewPaymentAnnualAmount = new Label(By.Id("QuoteReviewPaymentAnnualAmount"));

        private Label lbQuoteReviewPaymentMonthlyTotalAmount = new Label(By.Id("QuoteReviewPaymentMonthlyTotalAmount"));
        private Label lbQuoteReviewPaymentMonthlyAmount = new Label(By.Id("QuoteReviewPaymentMonthlyAmount"));
        By webReference = By.XPath("//*[@class='quote-reference']/h5[@class='text-bold']");
        By checkBoxConfirmation = By.XPath("//*[@id='ConfirmationConfirm']/preceding-sibling::div");
        public string webRef;
        private Label lbQuoteReviewPaymentDeposit = new Label(By.Id("QuoteReviewPaymentDeposit"));
        private Label lbQuoteReviewPaymentFinanceCharge = new Label(By.Id("QuoteReviewPaymentFinanceCharge"));
        private Label lbQuoteReviewPaymentTotalPayable = new Label(By.Id("QuoteReviewPaymentTotalPayable"));
        private Label lbQuoteReviewPaymentAPR = new Label(By.Id("QuoteReviewPaymentAPR"));
        private Label lbQuoteReviewPaymentInterestRate = new Label(By.Id("QuoteReviewPaymentInterestRate"));


        public string getValueByItemName(string itemName)
        {
            var ele = _driver.FindElement(By.XPath($"//div/p[contains(text(), '{itemName}')]/parent::div/following-sibling::div/p"));
            return ele.GetAttribute("innerText").Trim();
        }
        public void BackFromQuoteReviewToQuoteSummary(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _driver.Navigate().Back();
                Thread.Sleep(2000);
            }
        }
        public void ClickQuoteReviewContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                BaseAction.FindAndClick(btnQuoteReviewContinueSelector);
                WaitForLoadingIconDisappear();
                Thread.Sleep(3000);
                WriteLogIfTechnicalError();
            }
        }

        public void ClickTermConfirmation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnTermConfirmation.Click();
            }
        }
        public void VerifyQuoteReviewPageDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(webReference);
                //Thread.Sleep(3000);
                Assert.True(IsElementDisplayed(btnQuoteReviewContinueSelector));
            }
        }
        

        #region Verify information from previous page
        public void VerifyVehicleDataDisplayedCorrectly(string input)
        {
            try
            {
                if (input.Equals("Yes"))
                {
                    Assert.Equal(_yourVehicleData.RegNumber, getValueByItemName("Registration number"));                    
                    Assert.Equal(_yourVehicleData.VehicleMake, getValueByItemName("Base vehicle make"));
                    Assert.Equal(_yourVehicleData.ManufacturerOrConverter, getValueByItemName("Manufacturer/Converter"));
                    Assert.Equal(_yourVehicleData.VehicleModel, getValueByItemName("Vehicle model"));
                    Assert.Equal(_yourVehicleData.YearOfManufacture, getValueByItemName("Year of manufacture"));
                    Assert.Equal(_yourVehicleData.EngineCC, getValueByItemName("Engine cc"));
                    Assert.Equal(_yourVehicleData.FuelType, getValueByItemName("Fuel type"));
                    Assert.Equal(_yourVehicleData.TransmissionType, getValueByItemName("Transmission type"));
                    Assert.Equal(_yourVehicleData.NumberOfDoors, getValueByItemName("Number of doors"));
                    Assert.Equal(_yourVehicleData.NumOfSeats, getValueByItemName("Number of belted seats"));
                }
            }
            catch (Exception) { }
        }

        public void VerifyProposerDataDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                var _title = _aboutYouData.Title + " " + _aboutYouData.FirstName + " " + _aboutYouData.Surname;
                var _birthDay = _aboutYouData.BirthDay + "/" + _aboutYouData.BirthMonth + "/" + _aboutYouData.BirthYear;
                Assert.Equal(_title, getValueByItemName("Your name"));
                Assert.Equal(_birthDay, getValueByItemName("Date of birth"));
                if (_aboutYouData.UKResidentSinceBirthYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("UK resident since birth"));
                }
                else 
                {
                    Assert.Equal("No", getValueByItemName("UK resident since birth"));
                }
                Assert.Equal(_aboutYouData.MaritalStatus, getValueByItemName("Marital status"));
                if (_aboutYouData.DVLAYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("Medical conditions DVLA unaware"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Medical conditions DVLA unaware"));
                }
            }
        }

        public void VerifyClaimAndConvictionDataDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                if (_driverHistoryData.FirstClaimAffectedYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("Motor claims in the last 5 years"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Motor claims in the last 5 years"));
                }
                if (_driverHistoryData.FirstConvictionYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("Motor convictions in the last 5 years"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Motor convictions in the last 5 years"));
                }
            }
        }

        public void VerifyContactDetailDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Equal(_aboutYouData.EmailAddress, txtQuoteReviewEmailAddress.GetPopulatedValue());
                Assert.Equal(_aboutYouData.PhoneNumber, txtQuoteReviewPhoneNumber.GetPopulatedValue());
            }
        }
        public void VerifyQuotePaymentAnuallyDataCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(_informationQuote.TotalAnnualPayment, lbQuoteReviewPaymentAnnualAmount.GetAttributeValue("innerText").Trim());
            }
        }
        public void VerifyQuotePaymentMonthlyDataCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Assert.Equal(_informationQuote.TotalAnnualPayment, lbQuoteReviewPaymentMonthlyTotalAmount.GetAttributeValue("innerText").Trim());
                Assert.Equal(_informationQuote.Then11InstalmentsOf, lbQuoteReviewPaymentMonthlyAmount.GetAttributeValue("innerText").Trim());
                Assert.Equal(_informationQuote.TotalAmountPayable, lbQuoteReviewPaymentTotalPayable.GetAttributeValue("innerText").Trim());
                Assert.Equal(_informationQuote.InterestRate, lbQuoteReviewPaymentInterestRate.GetAttributeValue("innerText").Trim());
                Assert.Equal(_informationQuote.FinanceCharge, lbQuoteReviewPaymentFinanceCharge.GetAttributeValue("innerText").Trim());
                Assert.Equal(_informationQuote.Deposit, lbQuoteReviewPaymentDeposit.GetAttributeValue("innerText").Trim());
                Assert.Equal(_informationQuote.APRRepresentative, lbQuoteReviewPaymentAPR.GetAttributeValue("innerText").Trim());
            }
        }
        #endregion

        public string GetWebReferenceQuoteReview(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(webReference);
                webRef = _driver.FindElement(webReference).Text.Split(";").Last().Trim() ;
                _informationQuote = new GuiModelData.InformationQuote();
                _informationQuote.WebReference = webRef;
            }
            return webRef;
        }
        public void ClickCheckBoxConfirmation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _driver.FindElement(checkBoxConfirmation).Click();
            }
        }
        public string GetTotalAnnualPaymentQuoteReview(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string totalAnnualPayment = _driver.FindElement(By.Id("QuoteReviewPaymentAnnualAmount")).Text.Trim();
                _informationQuote = new GuiModelData.InformationQuote();
                _informationQuote.TotalAnnualPayment = totalAnnualPayment;
            }
            return webRef;
        }
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
