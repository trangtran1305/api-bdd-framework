using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;
using System.Linq;

namespace ANCarClassic.Pages
{
    public class QuoteReviewPage : BasePage
    {
        public static By btnQuoteReviewContinueSelector = By.Id("Quote_Review_Next");
        public static By Quote_Review_Form = By.Id("Quote_Review_Form");
        private Button btnQuoteReviewContinue = new Button(btnQuoteReviewContinueSelector);
        private Textbox txtQuoteReviewEmailAddress = new Textbox(By.Id("QuoteReviewEmailAddress"));
        private Textbox txtQuoteReviewPhoneNumber = new Textbox(By.Id("QuoteReviewPhoneNumber"));
        private Button btnConfirmationAgree = new Button(By.Id("ConfirmationAgreeAssumptionbutton"));
        private Button btnTermConfirmation = new Button(By.Id("ConfirmationConfirmbutton"));
        
        private Label lbQuoteReviewPaymentAnnualAmount = new Label(By.Id("QuoteReviewPaymentAnnualAmount"));

        private Label lbQuoteReviewPaymentMonthlyTotalAmount = new Label(By.Id("QuoteReviewPaymentMonthlyTotalAmount"));
        private Label lbQuoteReviewPaymentMonthlyAmount = new Label(By.Id("QuoteReviewPaymentMonthlyAmount"));
        By webReference = By.Id("QuoteReviewWebreference");
        By checkBoxConfirmation = By.XPath("//*[@id='ConfirmationConfirmbutton']");
        public string webRef;
        private Label lbQuoteReviewPaymentDeposit = new Label(By.Id("QuoteReviewPaymentDeposit"));
        private Label lbQuoteReviewPaymentFinanceCharge = new Label(By.Id("QuoteReviewPaymentFinanceCharge"));
        private Label lbQuoteReviewPaymentTotalPayable = new Label(By.Id("QuoteReviewPaymentTotalPayable"));
        private Label lbQuoteReviewPaymentAPR = new Label(By.Id("QuoteReviewPaymentAPR"));
        private Label lbQuoteReviewPaymentInterestRate = new Label(By.Id("QuoteReviewPaymentInterestRate"));
        private Button btnQuoteReviewVehicleView = new Button(By.Id("QuoteReviewVehicleView"));
        private Button btnQteRvwProposerSeeMore = new Button(By.Id("QteRvwProposerSeeMore"));
        private Button btnQteRvwAddlDriverSeeMore = new Button(By.Id("QteRvwAddlDriverSeeMore"));
        private Button btnQteRvwHistorySeeMore = new Button(By.Id("QteRvwHistorySeeMore"));


        public string getValueByItemName(string itemName)
        {
            var ele = _driver.FindElement(By.XPath($"//div/*[text() = ' {itemName} ']/following-sibling::p[1]"));
            return ele.GetAttribute("innerText").Trim();
        }
        public void BackFromQuoteReviewToQuoteSummary(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _driver.Navigate().Back();
                WaitForLoadingIconDisappear();
            }
        }
        public void ClickQuoteReviewContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                BaseAction.FindAndClick(btnQuoteReviewContinueSelector);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
        public void ClickAgreeButton(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnConfirmationAgree.Click();
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
                WaitUntilElementVisible(btnQuoteReviewContinueSelector);
                Assert.True(IsElementDisplayed(btnQuoteReviewContinueSelector));
            }
        }
        

        #region Verify information from previous page
        public void VerifyVehicleDataDisplayedCorrectly(string input)
        {
            
            if (input.Equals("Yes"))
            {
                btnQuoteReviewVehicleView.Click();
                //Assert.Equal(_yourVehicleData.RegNumber, getValueByItemName("Registration number"));   
                //Assert.Equal(_yourVehicleData.VehicleSummary, getValueByItemName("Your Car").Replace(" ", "").Replace("-", ""));

                Assert.Equal(_yourVehicleData.VehicleMake, getValueByItemName("Make"));
                Assert.Equal(_yourVehicleData.VehicleModel, getValueByItemName("Model"));
                Assert.Equal(_yourVehicleData.YearOfManufacture, getValueByItemName("Year of manufacture"));
                //Assert.Equal(_yourVehicleData.EngineCC, getValueByItemName("Engine cc"));
                Assert.Equal(_yourVehicleData.FuelType, getValueByItemName("Fuel type"));
                Assert.Equal(_yourVehicleData.TransmissionType, getValueByItemName("Transmission type"));

                Assert.Equal(_yourVehicleData.AlarmFitted, getValueByItemName("Alarm fitted"));
                Assert.Equal(_yourVehicleData.ImmobiliserFitted, getValueByItemName("Immobiliser fitted"));
                if (_yourVehicleData.IsTrackingDeviceYes == "isActive")
                {
                    Assert.Equal("Yes", getValueByItemName("Tracking device fitted"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Tracking device fitted"));
                }
                if (_yourVehicleData.IsLeftHand == "isActive")
                {
                    Assert.Equal("Left Hand Drive", getValueByItemName("Left or right hand drive"));
                }
                else
                {
                    Assert.Equal("Right Hand Drive", getValueByItemName("Left or right hand drive"));
                }
                //Assert.Equal(_yourVehicleData.TransmissionType, getValueByItemName("Left or right hand drive"));

                if (_yourVehicleData.PurchaseDay == "")
                {
                    Assert.Equal("Not purchased yet", getValueByItemName("Date purchased"));
                }
                else
                {
                    string purchaseDate = _yourVehicleData.PurchaseDay + "/" + _yourVehicleData.PurchaseMonth + "/" + _yourVehicleData.PurchaseYear;
                    Assert.Equal(purchaseDate, getValueByItemName("Date purchased"));
                }
                string value = getValueByItemName("Estimated value").Replace(",", "");
                value = value.Substring(1,value.Length - 4);
                Assert.Equal(_yourVehicleData.EstimateValue, value); 
                Assert.Equal(_yourVehicleData.NumOfSeats, getValueByItemName("Number of seats"));

                Assert.Equal(_yourVehicleData.OwnsVehicle, getValueByItemName("Vehicle owner"));

                var nightParkLocation = getValueByItemName("Overnight parking location");
                if (_yourVehicleData.ParkOverNightInLockedGarage == "isActive")
                {
                    Assert.Equal("In a locked garage", nightParkLocation);
                }
                else if (_yourVehicleData.ParkOverNightOnDriveWay == "isActive")
                {
                    Assert.Equal("On a driver way", nightParkLocation);
                }
                else if (_yourVehicleData.ParkOverNightOnTheRoad == "isActive")
                {
                    Assert.Equal("On the road", nightParkLocation);
                }

                if (_yourVehicleData.IsRegisteredKeeperYes == "isActive")
                {
                    Assert.Equal("Yes", getValueByItemName("Registered keeper"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Registered keeper"));
                }

                if (_yourVehicleData.ParkOvernightAtHomeYes == "isActive")
                {
                    Assert.Equal("Yes", getValueByItemName("Parked at home address"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Parked at home address"));
                }

                var useOfCar = getValueByItemName("Use of the car");
                if (_yourVehicleData.IsPleasureOnly == "isActive")
                {
                    Assert.Contains("Pleasure Only",useOfCar);
                }
                else if (_yourVehicleData.IsCommutting == "isActive")
                {
                    Assert.Contains("Commuting", useOfCar);
                }
                else if (_yourVehicleData.IsBusinessUse == "isActive")
                {
                    Assert.Equal("Business Use", useOfCar);
                }
                else
                {
                    Assert.Contains("Commercial Travel", useOfCar);
                }
                
            }
        }

        public void VerifyProposerDataDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                btnQteRvwProposerSeeMore.Click();
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
                if (_aboutYouData.HomeOwnerYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("Homeowner"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Homeowner"));
                }
                Assert.Equal(_aboutYouData.EmploymentStatus, getValueByItemName("Employment status"));
                Assert.Equal(_aboutYouData.MainJob.Replace("\r\n×",""), getValueByItemName("Main job"));
                Assert.Equal(_aboutYouData.MainJobBusiness.Replace("\r\n×", ""), getValueByItemName("Business type or industry"));
                if (_aboutYouData.PartTimeNo.Equals("isActive"))
                {
                    Assert.Equal("No", getValueByItemName("Additional part-time job"));
                }
                else
                {
                    Assert.Equal("Yes", getValueByItemName("Additional part-time job"));
                    Assert.Equal(_aboutYouData.PartTimeStatus, getValueByItemName("Part-time employment status"));
                    Assert.Equal(_aboutYouData.PartTimeJob.Replace("\r\n×", ""), getValueByItemName("Part-time job"));
                    var i = getValueByItemName("Business type or industry");
                    var x = _aboutYouData.PartTimeJobBusiness.Replace("\r\n×", "");
                    //Assert.Equal(_aboutYouData.PartTimeJobBusiness.Replace("\r\n×", ""), getValueByItemName("Business type or industry"));
                }
                Assert.Equal(_aboutYouData.DrivingLicenceType, getValueByItemName("Licence type"));
                //int year = Int32.Parse(_aboutYouData.DrivingLicenceDate.Substring(0, 1));
                //var now = DateTime.Now.AddYears(-1 * year);
                var date = _aboutYouData.DrivingLicenceDay + "/" + _aboutYouData.DrivingLicenceMonth + "/" + _aboutYouData.DrivingLicenceYear;
                Assert.Equal(date, getValueByItemName("Date licence obtained"));
                Assert.Equal("Yes", getValueByItemName("Main driver"));

            }
        }

        public void VerifyClaimAndConvictionDataDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                btnQteRvwHistorySeeMore.Click();
                if (_driverHistoryData.FirstClaimAffectedYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("Motor claims in the last 5 years"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Motor claims in the last 5 years"));
                }
                Assert.Equal(_driverHistoryData.FirstClaimDriver, getValueByItemName("Driver"));
                var date = _driverHistoryData.FirstClaimDay + "/" + _driverHistoryData.FirstClaimMonth + "/" + _driverHistoryData.FirstClaimYear;
                Assert.Equal(date, getValueByItemName("Date"));
                Assert.Equal(_driverHistoryData.FirstClaimCause, getValueByItemName("Claim Type"));
                Assert.Equal(_driverHistoryData.FirstClaimCost, getValueByItemName("Total estimated cost"));
                if (_driverHistoryData.FirstClaimAffectedYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("No Claims Bonus affected"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("No Claims Bonus affected"));
                }
                if (_driverHistoryData.FirstConvictionYes.Equals("isActive"))
                {
                    Assert.Equal("Yes", getValueByItemName("Unspent criminal convictions"));
                }
                else
                {
                    Assert.Equal("No", getValueByItemName("Unspent criminal convictions"));
                }
                Assert.Equal(_driverHistoryData.FirstConvictionDriver, getValueByItemName("Driver"));
                var convictionDate = _driverHistoryData.FirstConvictionDay + "/" + _driverHistoryData.FirstConvictionMonth + "/" + _driverHistoryData.FirstConvictionYear;

                Assert.Equal(convictionDate, getValueByItemName("Date"));
                Assert.Equal(_driverHistoryData.FirstConvictionCode, getValueByItemName("Conviction type"));
                Assert.Equal(_driverHistoryData.FirstConvictionPenaltyPoints, getValueByItemName("Points"));
                if (_driverHistoryData.FirstConvictionBannedDriverNo.Equals("isActive"))
                {
                    Assert.Equal("No", getValueByItemName("Banned"));
                }
                else
                {
                    string bannedValue = "";
                    if (_driverHistoryData.BannedMonth1 == "1")
                    {
                        bannedValue = _driverHistoryData.BannedMonth1 + " month";
                    }
                    else
                    {
                        bannedValue = _driverHistoryData.BannedMonth1 + " months";
                    }
                    Assert.Equal(bannedValue, getValueByItemName("Banned"));
                }
                if (_driverHistoryData.FirstConvictionFineNo.Equals("isActive"))
                {
                    Assert.Equal("0", getValueByItemName("Fine amount £"));
                }
                else
                {
                    Assert.Equal(_driverHistoryData.FinnedAmount1, getValueByItemName("Fine amount £"));
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
                WaitUntilElementVisible(webReference);
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
