using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace BeWiser.Pages
{
    public class VehiclePage : BasePage
    {
        public Textbox txtRegNumber = new Textbox(By.Id("RegNumber"));
        public static By btnFindCarSelector = By.Id("FindVehicle");
        private Button btnFindCar = new Button(btnFindCarSelector);
        private Button btnDoNotKnowRegNumber = new Button(By.Id("DoNotKnowRegNumber"));
        private Combobox cbVehicleMake = new Combobox(By.Id("Make"));
        private Combobox cbVehicleModel = new Combobox(By.Id("Model"));
        private Combobox cbYearOfManufacture = new Combobox(By.Id("YearOfManufacture"));
        private Combobox cbFuelType = new Combobox(By.Id("Fuel"));
        private Combobox cbTransmissionType = new Combobox(By.Id("Transmission"));
        private Combobox cbSelectVehicle = new Combobox(By.Id("SelectVehicle")); //n
        private Label lbVehicleSummary = new Label(By.Id("VehicleSummarySubheading"));
        private Button btnYourVehicleNext = new Button(By.Id("YourVehicleNextStep"));

        //Security
        //private Combobox cbFittedWithAlarmOrImmobiliser = new Combobox(By.Id("IsImmobilisedFitted"));
        //private Combobox cbImmobiliserType = new Combobox(By.Id("ImmobiliserType"));

        private Button btnTrackerFittedYes = new Button(By.Id("TrackerFittedYes"));
        private Button btnTrackerFittedNo = new Button(By.Id("TrackerFittedNo"));
        private Combobox cbTrackerType = new Combobox(By.Id("TrackerType"));
        private Button btnSecurityNextStep = new Button(By.Id("SecurityNextStep")); //n

        //CarDetail
        private Button btnLeftHandDrive = new Button(By.Id("LeftHandDrive"));
        private Button btnRightHandDrive = new Button(By.Id("RightHandDrive"));
        private Combobox cbSeats = new Combobox(By.Id("Seat"));
        public Textbox txtEstimateValue = new Textbox(By.XPath("//input[@id='EstimateValue']"));
        private static By txtPurchaseDaySelector = By.Id("PurchaseDay");
        private Textbox txtPurchaseDay = new Textbox(txtPurchaseDaySelector);
        private Textbox txtPurchaseMonth = new Textbox(By.Id("PurchaseMonth"));
        private Textbox txtPurchaseYear = new Textbox(By.Id("PurchaseYear"));
        private Checkbox chkNotBoughtVehicleYet = new Checkbox(By.XPath("//input[@id='NotBoughtVehicleYet']/following-sibling::label"));
        private Button btnCarDetailsNextStep = new Button(By.Id("CarDetailsNextStep"));

        private Button btnIsModifiedYes = new Button(By.Id("IsModifiedYes"));
        private Button btnIsModifiedNo = new Button(By.Id("IsModifiedNo"));
        private Combobox cbModification1 = new Combobox(By.Id("Modification1"));
        private Button btnAddModification = new Button(By.Id("AddModification"));
        private Combobox cbModification2 = new Combobox(By.Id("Modification2"));
        private Combobox cbModification3 = new Combobox(By.Id("Modification3"));
        private Button btnModificationNextStep = new Button(By.Id("ModificationNextStep"));

        //Usage
        private Combobox cbOwner = new Combobox(By.Id("Owner"));
        private Button btnRegisteredKeeperYes = new Button(By.Id("RegisteredKeeperYes"));
        private Button btnRegisteredKeeperNo = new Button(By.Id("RegisteredKeeperNo"));
        private Button btnOnADriveway = new Button(By.XPath("//button[contains(text(), 'On a driveway')]"));
        private Button btnInALockedGarage = new Button(By.XPath("//button[contains(text(), ' In a locked garage ')]"));
        private Button btnOnTheRoad = new Button(By.XPath("//button[contains(text(), 'On the road')]"));
        private Button btnParkOvernightAtHomeYes = new Button(By.Id("ParkOvernightAtHomeYes"));
        private Button btnParkOvernightAtHomeNo = new Button(By.Id("ParkOvernightAtHomeNo"));
        private Button btnSDPO = new Button(By.XPath("//button[contains(text(), 'Pleasure Only')]"));//n
        private Button btnSDPC = new Button(By.XPath("//button[contains(text(), 'Commuting')]"));//n
        private Button btnBusinessUse = new Button(By.XPath("//button[contains(text(),'Business Use')]"));
        private Button btnBusinessUseAndCommercial = new Button(By.XPath("//button[contains(text(), 'Commercial Travel')]"));
        private Combobox cbBusinessUser = new Combobox(By.Id("BusinessUser"));
        private Textbox txtBusinessMileage = new Textbox(By.Id("BusinessMileage"));
        private Button btnBUCT = new Button(By.XPath("//button[contains(text(), 'Commercial Travelling')]"));
        private Textbox txtAnnualMileage = new Textbox(By.Id("AnnualMileage"));
        private Combobox cbCarsOfHouse = new Combobox(By.XPath("//ng-select[@id='NCBYears']"));//n
        private static By btnVehiclePageContinueSelector = By.Id("VehiclePageContinue");
        private Button btnVehiclePageContinue = new Button(btnVehiclePageContinueSelector);
        private static By btnLetBeginSelector = By.Id("AssumptionPageContinue");
        private Button btnLetBegin = new Button(btnLetBeginSelector);
        private Textbox txtKeptPostcode = new Textbox(By.Id("KeptPostcode"));
        private Button btnVehicleSummEdit = new Button(By.Id("NotMyCar"));
        // update 17/08
        private string btnSecurityAlarmFitted = "//*[@formcontrolname='securityDevice']/div[1]//button[contains(text(),'AlarmFitted')]";
        private Button btnSecurityAlarmFittedActive = new Button(By.XPath("//*[@formcontrolname='securityDevice']/div[1]//button[contains(@class,'isActive')]"));
        private string btnSecurityImmobiliserFitted = "//*[@formcontrolname='securityDevice']/div[2]//button[contains(text(),'ImmobiliserFitted')]";
        private Button btnSecurityImmobiliserFittedActive = new Button(By.XPath("//*[@formcontrolname='securityDevice']/div[2]//button[contains(@class,'isActive')]"));


        #region Assumption
        public void ClickLetBegin(String input)
        {

            ClickContinueOnTrialPage();
            WaitUntilElementVisible(btnLetBeginSelector);
            if (input.Equals("Yes"))
            {
                btnLetBegin.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(1000);
            }
            ClickContinueOnTrialPage();
            WriteLogIfTechnicalError();
        }
        #endregion

        #region YourVehicle
        public void ClickVehicleSummEdit(String input)
        {
            if (input.Equals("Yes"))
            {
                //Thread.Sleep(2000);
                btnVehicleSummEdit.Click();
            }
        }

        public void InputRegNumber(string regNumber)
        {
            if (!String.IsNullOrEmpty(regNumber))
            {
                txtRegNumber.Input(regNumber);
            }
        }

        public void ClickConfirmSearchVRN(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFindCar.Click();
                WaitForLoadingIconDisappear();
            }
            ClickContinueOnTrialPage();
        }

        public void ClickDoNotKnowRegNumber(string input)
        {
            if (input.Equals("Yes"))
            {
                btnDoNotKnowRegNumber.Click();
            }
        }
        public void SelectMake(string make)
        {
            if (!String.IsNullOrEmpty(make))
            {
                Thread.Sleep(2000);
                cbVehicleMake.SelectByText(make);
            }
        }

        public void SelectModel(string model)
        {
            if (!String.IsNullOrEmpty(model))
            {
                Thread.Sleep(4000);
                cbVehicleModel.SelectByText(model);
            }
        }

        public void SelectYearOfManufacture(string yearOfManufacture)
        {
            if (!String.IsNullOrEmpty(yearOfManufacture))
            {
                Thread.Sleep(1000);
                cbYearOfManufacture.SelectByText(yearOfManufacture);
            }
        }

        public void SelectFuel(string fuel)
        {
            if (!String.IsNullOrEmpty(fuel))
            {
                Thread.Sleep(500);
                cbFuelType.SelectByText(fuel);
            }
        }

        public void SelectTransmission(string transmission)
        {
            if (!String.IsNullOrEmpty(transmission))
            {
                Thread.Sleep(500);
                cbTransmissionType.SelectByText(transmission);
            }
        }
        public void SelectVehicle(string transmission)
        {
            if (!String.IsNullOrEmpty(transmission))
            {
                cbSelectVehicle.SelectByText(transmission);
            }
        }
        public void ClickYourVehicleNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnYourVehicleNext.Click();
            }
        }
        #endregion
        #region Vehicle Detail
        public void ClickAlarmFitted(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var btnAlarmFitted = _driver.FindElement(By.XPath(btnSecurityAlarmFitted.Replace("AlarmFitted", input)));
                btnAlarmFitted.Click();
            }
        }
        public void ClickImmobiliserFitted(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var btnImmobiliserFitted = _driver.FindElement(By.XPath(btnSecurityImmobiliserFitted.Replace("ImmobiliserFitted", input)));
                btnImmobiliserFitted.Click();
            }
        }

        public void ClickTrackerFitted(string input)
        {
            if (input.Equals("Yes"))
            {
                btnTrackerFittedYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnTrackerFittedNo.Click();
            }
        }
        public void SelectTrakingType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbTrackerType.SelectByText(input);
            }
        }

        public void ClickSecurityNextStep(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnSecurityNextStep.Click();
            }
        }
        public void ClickRightOrLeftHandDrive(string handTypeInput)
        {
            if (handTypeInput.Trim().Equals("Left Hand Drive"))
            {
                btnLeftHandDrive.Click();
            }
            else if (handTypeInput.Trim().Equals("Right Hand Drive"))
            {
                btnRightHandDrive.Click();
            }
        }
        public void SelectSeats(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbSeats.SelectByText(input);
            }
        }
        public void InputEstimateValue(string estimatedValue)
        {
            if (!String.IsNullOrEmpty(estimatedValue))
            {
                txtEstimateValue.Input(estimatedValue);
            }
        }

        public void InputPurchaseDate(string input)
        {

            if (!String.IsNullOrEmpty(input))
            {
                Tuple<string, string, string> splittedDate = new Tuple<string, string, string>("", "", "");
                if (input.Equals("today"))
                {
                    DateTime now = DateTime.Now;
                    var inputtedDate = now.ToString("dd/MM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                }
                else
                {
                    splittedDate = _pageHelper.SplitDate(input);
                }
                txtPurchaseDay.Input(splittedDate.Item1);
                txtPurchaseMonth.Input(splittedDate.Item2);
                txtPurchaseYear.Input(splittedDate.Item3);
            }
        }

        public void ClickMotorhomeDetailNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCarDetailsNextStep.Click();
            }
        }
        public void ClickNotBoughtVehicleYet(string input)
        {
            if (input.Equals("Yes"))
            {
                //Thread.Sleep(1000);
                if (chkNotBoughtVehicleYet.GetSelectedStatus() == false)
                {
                    chkNotBoughtVehicleYet.Click();
                }
            }
        }
        public void ClickIsModified(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    btnIsModifiedYes.Click();
                }
                else if (input.Equals("No"))
                {
                    btnIsModifiedNo.Click();
                }
            }
        }
        public void ClickModificationNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnModificationNextStep.Click();
            }
        }
        public void SelectModification1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbModification1.Input(input);
            }
        }
        public void ClickAddModification(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAddModification.Click();
            }
        }
        public void SelectModification2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnAddModification.Click();
                cbModification2.Input(input);
            }
        }
        public void SelectModification3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnAddModification.Click();
                cbModification3.Input(input);
            }
        }
        #endregion
        #region Use Of The Vehicle
        public void SelectOwner(string ownerOption)
        {
            if (!String.IsNullOrEmpty(ownerOption))
            {
                cbOwner.SelectByText(ownerOption);
            }
        }

        public void ClickRegisteredKeeper(string input)
        {
            if (input.Equals("Yes"))
            {
                btnRegisteredKeeperYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnRegisteredKeeperNo.Click();
            };
        }
        public void SelectParkOvernight(string parkOvernightOption)
        {
            if (parkOvernightOption.Equals("On a driveway"))
            {
                btnOnADriveway.Click();
            }
            else if (parkOvernightOption.Equals("On the road"))
            {
                btnOnTheRoad.Click();
            }
            else if (parkOvernightOption.Equals("In a locked garage"))
            {
                btnInALockedGarage.Click();
            }
        }
        public void ClickParkOvernightAtHome(string input)
        {
            if (input.Equals("Yes"))
            {
                btnParkOvernightAtHomeYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnParkOvernightAtHomeNo.Click();
            }
        }
        public void SelectVehicleUseFor(string vehicleUseOption)
        {
            if (vehicleUseOption.Contains("Pleasure Only"))
            {
                btnSDPO.Click();
            }
            else if (vehicleUseOption.Contains("Commuting"))
            {
                btnSDPC.Click();
            }
            else if (vehicleUseOption.Equals("Business Use"))
            {
                btnBusinessUse.Click();
            }
            else if (vehicleUseOption.Contains("Commercial Travel"))
            {
                btnBUCT.Click();
            }
        }
        public void InputAnnualMileage(string annualMileage)
        {
            if (!String.IsNullOrEmpty(annualMileage))
            {
                txtAnnualMileage.Input(annualMileage);
            }
        }
        public void SelectBusinessUser(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbBusinessUser.SelectByText(input);
            }
        }
        public void InputBusinessMileage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBusinessMileage.Input(input);
            }
        }

        public void SelectCarsInHouse(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbCarsOfHouse.SelectByText(input);
            }
        }
        public void ClickContinueToAboutYou(string input)
        {
            if (input.Equals("Yes"))
            {
                BaseAction.FindAndClick(btnVehiclePageContinueSelector);
                WaitForLoadingIconDisappear();
                while (_driver.FindElements(btnVehiclePageContinueSelector).Count > 0)
                {
                    btnVehiclePageContinue.Click();
                    WaitForLoadingIconDisappear();
                }
            }
            ClickContinueOnTrialPage();
        }
        public void InputKeptPostcode(string estimatedValue)
        {
            if (!String.IsNullOrEmpty(estimatedValue))
            {
                txtKeptPostcode.Input(estimatedValue);
            }
        }
        #endregion
        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _yourVehicleData = new GuiModelData.VehicleData();
                _yourVehicleData.RegNumber = txtRegNumber?.GetPopulatedValue();
                if (_driver.FindElements(By.Id("Make")).Count > 0)
                {
                    _yourVehicleData.VehicleMake = cbVehicleMake?.GetText();
                    _yourVehicleData.VehicleModel = cbVehicleModel?.GetText();
                    _yourVehicleData.YearOfManufacture = cbYearOfManufacture?.GetText();
                    _yourVehicleData.FuelType = cbFuelType?.GetText();
                    _yourVehicleData.TransmissionType = cbTransmissionType?.GetText();
                }
                else
                {
                    _yourVehicleData.VehicleSummary = lbVehicleSummary.GetTextByLocator().Replace(" ", "");
                }

                _yourVehicleData.AlarmFitted = btnSecurityAlarmFittedActive.GetText().Trim();
                _yourVehicleData.ImmobiliserFitted = btnSecurityImmobiliserFittedActive.GetText().Trim();
                _yourVehicleData.IsTrackingDeviceYes = btnTrackerFittedYes?.GetAttributeValue("class");
                _yourVehicleData.IsTrackingDeviceNo = btnTrackerFittedNo?.GetAttributeValue("class");
                if (_yourVehicleData.IsTrackingDeviceYes.Equals("isActive"))
                {
                    _yourVehicleData.TrakingType = cbTrackerType.GetText();
                }
                _yourVehicleData.IsLeftHand = btnLeftHandDrive?.GetAttributeValue("class");
                _yourVehicleData.IsRightHand = btnRightHandDrive?.GetAttributeValue("class");
                _yourVehicleData.NumOfSeats = cbSeats.GetText();
                _yourVehicleData.EstimateValue = txtEstimateValue?.GetPopulatedValue();
                if (_driver.FindElements(txtPurchaseDaySelector).Count > 0)
                {
                    _yourVehicleData.PurchaseDay = txtPurchaseDay.GetPopulatedValue();
                    _yourVehicleData.PurchaseMonth = txtPurchaseMonth.GetPopulatedValue();
                    _yourVehicleData.PurchaseYear = txtPurchaseYear.GetPopulatedValue();
                }
                _yourVehicleData.OwnsVehicle = cbOwner?.GetText();
                _yourVehicleData.IsRegisteredKeeperYes = btnRegisteredKeeperYes?.GetAttributeValue("class");
                _yourVehicleData.IsRegisteredKeeperNo = btnRegisteredKeeperNo?.GetAttributeValue("class");
                _yourVehicleData.ParkOvernightAtHomeYes = btnParkOvernightAtHomeYes?.GetAttributeValue("class");
                _yourVehicleData.ParkOvernightAtHomeNo = btnParkOvernightAtHomeNo?.GetAttributeValue("class");
                _yourVehicleData.ParkOverNightInLockedGarage = btnInALockedGarage?.GetAttributeValue("class");
                _yourVehicleData.ParkOverNightOnDriveWay = btnOnADriveway?.GetAttributeValue("class");
                _yourVehicleData.ParkOverNightOnTheRoad = btnOnTheRoad?.GetAttributeValue("class");

                var parkOvernightAtHomeNo = btnParkOvernightAtHomeNo?.GetAttributeValue("class");
                if (parkOvernightAtHomeNo.Equals("isactive"))
                {
                    _yourVehicleData.KeptPostCode = txtKeptPostcode.GetPopulatedValue();
                }
                _yourVehicleData.IsPleasureOnly = btnSDPO.GetAttributeValue("class");
                _yourVehicleData.IsCommutting = btnSDPC.GetAttributeValue("class");
                _yourVehicleData.IsBusinessUse = btnBusinessUse.GetAttributeValue("class");
                _yourVehicleData.IsBusinessUseAndCommercial = btnBusinessUseAndCommercial.GetAttributeValue("class");
                _yourVehicleData.AnnualMilleages = txtAnnualMileage.GetPopulatedValue();
            }
        }
        public void VerifyVehicleDataDisplayedCorrectly(string input)
        {

            if (input.Equals("Yes"))
            {
                Assert.Equal(_yourVehicleData.RegNumber, txtRegNumber?.GetPopulatedValue());
                Assert.Equal(_yourVehicleData.AlarmFitted, btnSecurityAlarmFittedActive.GetText().Trim());
                Assert.Equal(_yourVehicleData.ImmobiliserFitted, btnSecurityImmobiliserFittedActive.GetText().Trim());
                Assert.Equal(_yourVehicleData.IsTrackingDeviceYes, btnTrackerFittedYes?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsTrackingDeviceNo, btnTrackerFittedNo?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsLeftHand, btnLeftHandDrive?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsRightHand, btnRightHandDrive?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.EstimateValue, txtEstimateValue?.GetPopulatedValue());
                // In Vehicle page if user clicked on I havent bought a car yet chb, when retrieve quote it return today as Purchased date
                if (_yourVehicleData.PurchaseDay != "")
                {
                    //    var now = DateTime.Now.ToString("dd/MM/yyyy");
                    //    var comparedDate = _pageHelper.SplitDate(now);
                    //    Assert.Equal(comparedDate.Item1, txtPurchaseDay.GetPopulatedValue());
                    //    Assert.Equal(comparedDate.Item2, txtPurchaseMonth.GetPopulatedValue());
                    //    Assert.Equal(comparedDate.Item3, txtPurchaseYear.GetPopulatedValue());
                    //}
                    //else
                    //{
                    Assert.Equal(_yourVehicleData.PurchaseDay, txtPurchaseDay.GetPopulatedValue());
                    Assert.Equal(_yourVehicleData.PurchaseMonth, txtPurchaseMonth.GetPopulatedValue());
                    Assert.Equal(_yourVehicleData.PurchaseYear, txtPurchaseYear.GetPopulatedValue());
                }
                Assert.Equal(_yourVehicleData.OwnsVehicle, cbOwner?.GetText());
                Assert.Equal(_yourVehicleData.IsRegisteredKeeperYes, btnRegisteredKeeperYes?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsRegisteredKeeperNo, btnRegisteredKeeperNo?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.ParkOvernightAtHomeYes, btnParkOvernightAtHomeYes?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.ParkOvernightAtHomeNo, btnParkOvernightAtHomeNo?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.ParkOverNightInLockedGarage, btnInALockedGarage?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.ParkOverNightOnDriveWay, btnOnADriveway?.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.ParkOverNightOnTheRoad, btnOnTheRoad?.GetAttributeValue("class"));

                var trackerFittedYes = btnTrackerFittedYes.GetAttributeValue("class");
                if (trackerFittedYes.Equals("isActive"))
                {
                    Assert.Equal(_yourVehicleData.TrakingType, cbTrackerType.GetText());
                }
                var parkOvernightAtHomeNo = btnParkOvernightAtHomeNo?.GetAttributeValue("class");
                if (parkOvernightAtHomeNo.Equals("isActive"))
                {
                    Assert.Equal(_yourVehicleData.KeptPostCode, txtKeptPostcode.GetPopulatedValue());
                }

                Assert.Equal(_yourVehicleData.IsPleasureOnly, btnSDPO.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsCommutting, btnSDPC.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsBusinessUse, btnBusinessUse.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.IsBusinessUseAndCommercial, btnBusinessUseAndCommercial.GetAttributeValue("class"));
                Assert.Equal(_yourVehicleData.AnnualMilleages, txtAnnualMileage.GetPopulatedValue());
            }
        }

        public void VerifyVehiclePageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(btnFindCarSelector);
                var elements = _driver.FindElements(btnFindCarSelector);
                bool isTrue = elements.Count > 0;
                Assert.True(isTrue);
            }
        }
    }
}
