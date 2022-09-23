using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using Xunit;

namespace SafeGuardMH.Pages
{
    public class VehiclePage : BasePage
    {
        private static string _listModificationPath = Directory.GetCurrentDirectory() + "\\TestData\\ListModifications.txt";
        private static By btnLowProfileCampervanSelector = By.Id("d86c86bc-3f43-4884-bb2e-0f8a4c8bd219");
        private static By btnFixedHighRisingRoofCampervanSelector = By.Id("2d643acd-be81-4a91-a137-115710ace4ad");
        private static By btnLowProfileMotorhomeSelector = By.Id("5c1c7aa0-a576-48f7-b38d-789b492260ae");
        private static By btnCoachbuiltMotorhomeSelector = By.Id("78f3d915-19b2-42b5-a363-9632f1311f8a");
        private static By btnEuropeanAClassMotorhomeSelector = By.Id("5e8a9f94-2f2e-437a-828a-52c5a793ef8b");
        private static By btnAmericanCClassMotorhomeSelector = By.Id("60185c80-6b36-4511-8401-a42a326684b5");
        private static By btnAmericanAClassMotorhomeSelector = By.Id("ee852397-5538-4af8-a7f8-18e3288dfaa1");
        private static By btnDayVanLeisureVanSelector = By.Id("63c98f72-0fa0-4444-adb9-49929ef86922");
        private static By btnDIYConversionSelector = By.Id("b2a86510-9237-4fbf-aec1-1bb2400f72b2");
        private Button btnLowProfileCampervan = new Button(btnLowProfileCampervanSelector);
        private Button btnFixedHighRisingRoofCampervan = new Button(btnFixedHighRisingRoofCampervanSelector);
        private Button btnLowProfileMotorhome = new Button(btnLowProfileMotorhomeSelector);
        private Button btnCoachbuiltMotorhome = new Button(btnCoachbuiltMotorhomeSelector);
        private Button btnEuropeanAClassMotorhome = new Button(btnEuropeanAClassMotorhomeSelector);
        private Button btnAmericanCClassMotorhome = new Button(btnAmericanCClassMotorhomeSelector);
        private Button btnAmericanAClassMotorhome = new Button(btnAmericanAClassMotorhomeSelector);
        private Button btnDayVanLeisureVan = new Button(btnDayVanLeisureVanSelector);
        private Button btnDIYConversion = new Button(btnDIYConversionSelector);
        private Button alDIYConversionOverLay = new Button(By.Id("DiyWarningContent"));
        private Button alDayVanOverLay = new Button(By.Id("DayvanWarningContent"));

        public Textbox txtRegNumber = new Textbox(By.Id("RegNumber"));
        public Label lblVRNErrorMessage = new Label(By.CssSelector(".ng-invalid .error__content"));
        public static By btnRegNumberConfirmSelector = By.Id("ConfirmSearchVRN");
        private Button btnRegNumberConfirm = new Button(btnRegNumberConfirmSelector);
        private Combobox cbVehicleMake = new Combobox(By.Id("BaseVehicleMake"));
        private Combobox cbManufacturerOrConverter = new Combobox(By.Id("ManufacturerOrConverter"));
        private Combobox cbVehicleModel = new Combobox(By.Id("Model"));
        private Combobox cbYearOfManufacture = new Combobox(By.Id("YearOfManufacture"));
        private Textbox txtEngineCC = new Textbox(By.Id("EngineCC"));
        private Label lblEngineCCErrorMessage = new Label(By.CssSelector(".error__wrapper:nth-child(1)"));
        private Combobox cbFuelType = new Combobox(By.Id("Fuel"));
        private Combobox cbTransmissionType = new Combobox(By.Id("Transmission"));
        private Combobox cbNumberOfDoors = new Combobox(By.Id("Doors"));
        private Combobox cbSeats = new Combobox(By.Id("Seats"));
        private Button btnConfirmVehicle = new Button(By.Id("ConfirmVehicle"));
        private Button btnYourVehicleNext = new Button(By.Id("YourVehicleNext"));
        public Label lblErrorMessage = new Label(By.CssSelector(".ng-invalid .error__content"));

        //VehicleDetail
        private Combobox cbFittedWithAlarmOrImmobiliser = new Combobox(By.Id("IsImmobilisedFitted"));
        private Button btnTrackerFittedYes = new Button(By.Id("TrackerFittedYes"));
        private Button btnTrackerFittedNo = new Button(By.Id("TrackerFittedNo"));
        private Combobox cbTrackerType = new Combobox(By.Id("TrackerType"));
        private Button btnLeftHandDrive = new Button(By.Id("LeftHandDrive"));
        private Button btnRightHandDrive = new Button(By.Id("RightHandDrive"));
        public Textbox txtEstimateValue = new Textbox(By.XPath("//input[@id='EstimateValue']"));
        private Textbox txtPurchaseDay = new Textbox(By.Id("PurchaseDay"));
        private Textbox txtPurchaseMonth = new Textbox(By.Id("PurchaseMonth"));
        private Textbox txtPurchaseYear = new Textbox(By.Id("PurchaseYear"));
        private Label lblPurchaseDateErrorMessage = new Label(By.CssSelector(".mb-0 > app-safeguard-field-error-display > div > p"));
        private Checkbox chkNotBoughtVehicleYet = new Checkbox(By.Id("NotBoughtVehicleYet"));
        private Button btnMotorhomeDetailsNextStep = new Button(By.Id("motorhomeDetailsNextStep"));
        private Combobox cbImmobiliserType = new Combobox(By.Id("ImmobiliserType"));

        //ManufaturingDetail
        private Button btnVehicleManufacturedUK = new Button(By.XPath("//button[@id='item.id']//span[text()=' UK ']"));
        private Button btnVehicleManufacturedUS = new Button(By.XPath("//button[@id='item.id']//span[text()=' USA ']"));
        private Button btnVehicleManufacturedOther = new Button(By.XPath("//button[@id='item.id']//span[text()=' Other ']"));
        private Button btnProfessionalConvertedYes = new Button(By.Id("ProfessionalConvertedYes"));
        private Button btnProfessionalConvertedNo = new Button(By.Id("ProfessionalConvertedNo"));
        private Button btnIsModifiedYes = new Button(By.Id("IsModifiedYes"));
        private Button btnIsModifiedNo = new Button(By.Id("IsModifiedNo"));
        private Button btnModificationNextStep = new Button(By.Id("ModificationNextStep"));
        private Button linkNondisclosableModificationOpen = new Button(By.Id("NondisclosableModificationOpen"));
        private Button lblModificationPopup = new Button(By.CssSelector(".text-label.mb-4"));
        private Combobox cbModification1 = new Combobox(By.Id("Modification1"));
        private Combobox cbModification2 = new Combobox(By.Id("Modification2"));
        private Combobox cbModification3 = new Combobox(By.Id("Modification3"));
        private Button btnAddModification = new Button(By.Id("AddModification"));
        private Button btnRemoveModification1 = new Button(By.Id("Remove1"));
        private Textbox txtModification1 = new Textbox(By.XPath("//ng-select[@id='Modification1']//input"));
        private Textbox txtModification2 = new Textbox(By.XPath("//ng-select[@id='Modification2']//input"));
        private Textbox txtModification3 = new Textbox(By.XPath("//ng-select[@id='Modification3']//input"));
        private Label lblModificationNotMatchError = new Label(By.CssSelector(".ng-option-disabled"));
        private Label lblModification = new Label(By.XPath("//label[text()=' Modification 1/3 ']"));
        private By addModificationSelector = By.Id("AddModification");

        //UseOfTheVehicle
        private Combobox cbOwner = new Combobox(By.Id("Owner"));
        private Button btnRegisteredKeeperYes = new Button(By.Id("RegisteredKeeperYes"));
        private Button btnRegisteredKeeperNo = new Button(By.Id("RegisteredKeeperNo"));
        private Button btnOnADriveway = new Button(By.XPath("//*[@id='ParkOvernight']/div/div/button[1]"));
        private Button btnInALockedGarage = new Button(By.XPath("//*[@id='ParkOvernight']/div/div/button[2]"));
        private Button btnOnTheRoad = new Button(By.XPath("//*[@id='ParkOvernight']/div/div/button[3]"));
        private Button btnParkOvernightAtHomeYes = new Button(By.Id("ParkOvernightAtHomeYes"));
        private Button btnParkOvernightAtHomeNo = new Button(By.Id("ParkOvernightAtHomeNo"));
        private Button btnSDPexC = new Button(By.Id("SDPexC"));
        private Button btnSDP = new Button(By.Id("SDP"));
        private Button btnBusinessUse = new Button(By.Id("BusinessUse"));
        private Textbox txtAnnualMileage = new Textbox(By.Id("AnnualMileage"));
        private Button btnPlanInTheEUYes = new Button(By.Id("Yes"));
        private Button btnPlanInTheEUNo = new Button(By.Id("No"));
        private static By btnVehiclePageContinueSelector = By.Id("VehiclePageContinue");
        private Button btnVehiclePageContinue = new Button(btnVehiclePageContinueSelector);
        private Button btnLetBegin = new Button(By.Id("AssumptionPageContinue"));
        private Textbox txtKeptPostcode = new Textbox(By.Id("KeptPostcode"));
        private Textbox txtEUMileage = new Textbox(By.Id("EUMileage"));
        private Button btnForeignUseB = new Button(By.Id("ForeignUseB"));
        private Button btnForeignUseA = new Button(By.Id("ForeignUseA"));
        private Button btnForeignUseC = new Button(By.Id("ForeignUseC"));
        private Button btnForeignUseD = new Button(By.Id("ForeignUseD"));
        private static By btnVehicleEditSelector = By.Id("VehicleSummEdit");
        private Button btnVehicleSummEdit = new Button(btnVehicleEditSelector);

        #region YourVehicle
        public void ClickVehicleSummEdit(String input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(btnVehicleEditSelector);

                btnVehicleSummEdit.Click();
                Thread.Sleep(1000);
            }
        }
        public void ClickLetBegin(String input)
        {
            if (input.Equals("Yes"))
            {
                btnLetBegin.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(2000);
            }

            WriteLogIfTechnicalError();
        }
        public void SelectYourVehicle(string input)
        {
            WriteLogIfTechnicalError();
            WaitUntilElementExists(btnLowProfileCampervanSelector);
            if (input.Equals("Low profile campervan"))
            {
                BaseAction.FindAndClick(btnLowProfileCampervanSelector);
                // focus on other item to get Class attribute of btnLowProfileCampervanSelector
                txtRegNumber.Input("");
                while (!btnLowProfileCampervan.GetAttributeValue("class").Contains("isActive"))
                {
                    btnLowProfileCampervan.Click();
                    txtRegNumber.Input("");
                }
            }
            else if (input.Equals("Fixed/High/Rising roof campervan"))
            {
                BaseAction.FindAndClick(btnFixedHighRisingRoofCampervanSelector);
            }
            else if (input.Equals("Low profile motorhome"))
            {
                BaseAction.FindAndClick(btnLowProfileMotorhomeSelector);
            }
            else if (input.Equals("Coachbuilt motorhome"))
            {
                BaseAction.FindAndClick(btnCoachbuiltMotorhomeSelector);

            }
            else if (input.Equals("European A-Class motorhome"))
            {
                BaseAction.FindAndClick(btnEuropeanAClassMotorhomeSelector);
            }
            else if (input.Equals("American C-Class motorhome"))
            {
                BaseAction.FindAndClick(btnAmericanCClassMotorhomeSelector);
            }
            else if (input.Equals("American A-Class motorhome"))
            {
                BaseAction.FindAndClick(btnAmericanAClassMotorhomeSelector);
            }
            else if (input.Equals("Day Van/Leisure Van"))
            {
                BaseAction.FindAndClick(btnDayVanLeisureVanSelector);
            }
            else if (input.Equals("DIY Conversion"))
            {
                BaseAction.FindAndClick(btnDIYConversionSelector);
            }
            WriteLogIfTechnicalError();
        }

        public void VerifyADIYConversionOverlayIsDisplayed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Contains(input, alDIYConversionOverLay.GetText());
            }
        }

        public void VerifyADayVanLeisureVanOverlayIsDisplayed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Contains(input, alDayVanOverLay.GetText());
            }
        }

        public void InputRegNumber(string regNumber)
        {
            if (!String.IsNullOrEmpty(regNumber))
            {
                txtRegNumber.Input(regNumber);
                Thread.Sleep(1000);
                if (txtRegNumber.GetPopulatedValue() != regNumber)
                {
                    txtRegNumber.Clear();
                    txtRegNumber.Input(regNumber);
                }
            }
            WriteLogIfTechnicalError();
        }

        public void InputInvalidRegNumberThenVerify(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] invalidVRNs = input.Split(",");
                foreach (string invalidVRN in invalidVRNs)
                {
                    txtRegNumber.Clear();
                    txtRegNumber.Input(invalidVRN);
                    btnRegNumberConfirm.Click();
                    Assert.Equal("This is not a valid registration plate format.", lblVRNErrorMessage.GetText());
                }
            }
        }

        public void VerifyVRNErrorMessage(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal(input, lblVRNErrorMessage.GetText());
            }
        }

        public void ClickConfirmSearchVRN(string input)
        {
            if (input.Equals("Yes"))
            {
                btnRegNumberConfirm.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(2000);
            }
            WriteLogIfTechnicalError();
        }
        public void SelectMake(string make)
        {
            if (!String.IsNullOrEmpty(make))
            {
                cbVehicleMake.SelectByText(make);
                //Thread.Sleep(2000);
            }
        }
        public void SelectManufacturerOrConverter(string manufacturerOrConverter)
        {
            if (!String.IsNullOrEmpty(manufacturerOrConverter))
            {
                cbManufacturerOrConverter.SelectByText(manufacturerOrConverter);
                //Thread.Sleep(3000);
            }
        }
        public void SelectModel(string model)
        {
            if (!String.IsNullOrEmpty(model))
            {
                cbVehicleModel.SelectByText(model);
                //Thread.Sleep(2000);
            }
        }

        public void SelectYearOfManufacture(string yearOfManufacture)
        {
            if (!String.IsNullOrEmpty(yearOfManufacture))
            {
                cbYearOfManufacture.SelectByText(yearOfManufacture);
            }
        }
        public void InputEngineCC(string engineCC)
        {
            if (!String.IsNullOrEmpty(engineCC))
            {
                txtEngineCC.Input(engineCC);
                if (int.Parse(engineCC) < 500)
                {
                    btnYourVehicleNext.Click();
                }
            }
        }

        public void VerifyEngineCCErrorMessage(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal(input, lblEngineCCErrorMessage.GetText());
            }

        }
        public void SelectFuel(string fuel)
        {
            if (!String.IsNullOrEmpty(fuel))
            {
                cbFuelType.SelectByText(fuel);
            }
        }

        public void SelectTransmission(string transmission)
        {
            if (!String.IsNullOrEmpty(transmission))
            {
                cbTransmissionType.SelectByText(transmission);
            }
        }

        public void SelectNumberOfDoors(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbNumberOfDoors.SelectByText(input);
            }
        }
        public void SelectSeats(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbSeats.SelectByText(input);
            }
        }
        public void ClickYourVehicleNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnYourVehicleNext.Click();
            }
        }

        public void ClickConfirmVehicle(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConfirmVehicle.Click();
            }
        }
        #endregion
        #region Vehicle Detail

        public void SelectFittedWithAlarmOrImmobiliser(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //cbFittedWithAlarmOrImmobiliser.SelectByText(input);
                string xpathElement = String.Format("//button[text()='{0}']", input);
                Button btnFitted = new Button(By.XPath(" " + xpathElement + " "));
                btnFitted.Click();
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
        public void InputEstimateValue(string estimatedValue)
        {
            if (!String.IsNullOrEmpty(estimatedValue))
            {
                txtEstimateValue.Input(estimatedValue);
            }
        }

        public void InputPurchaseDate(string purchaseDate)
        {
            if (!String.IsNullOrEmpty(purchaseDate))
            {
                var splittedDate = _pageHelper.SplitDate(purchaseDate);
                txtPurchaseDay.Input(splittedDate.Item1);
                txtPurchaseMonth.Input(splittedDate.Item2);
                txtPurchaseYear.Input(splittedDate.Item3);
            }
        }

        public void VerifyPurchaseDateErrorMessage(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal(input, lblPurchaseDateErrorMessage.GetText());
            }
        }

        public void ClickMotorhomeDetailNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnMotorhomeDetailsNextStep.Click();
            }
        }
        public void ClickNotBoughtVehicleYet(string input)
        {
            if (input.Equals("Yes"))
            {
                if (chkNotBoughtVehicleYet.GetSelectedStatus() == false)
                {
                    chkNotBoughtVehicleYet.Click();
                }
            }
        }
        public void SelectImmobiliserType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbImmobiliserType.SelectByText(input);
            }
        }
        #endregion

        #region Manufaturing Detail
        public void SelectVehicleManufacturedPlace(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string xpathElement = String.Format("//button[@id='item.id']//span[text()='{0}']", input);
                Button btnVehicleManufacturedPlace = new Button(By.XPath(" " + xpathElement + " "));
                btnVehicleManufacturedPlace.Click();
            }
        }
        public void ClickProfessionalConverted(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProfessionalConvertedYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnProfessionalConvertedNo.Click();
            }
        }
        public void ClickIsModified(string input)
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
        public void ClickModificationNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnModificationNextStep.Click();
            }
        }

        public void ClickOnListModificationsLink(string input)
        {
            if (input.Equals("Yes"))
            {
                linkNondisclosableModificationOpen.Click();
            }
        }

        public void VerifyListModificationsPopupDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Contains(input, lblModificationPopup.GetText());
            }
        }

        public void VerifyDetailsOfListModificationsPopupDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                string[] expectedModifications = File.ReadAllLines(_listModificationPath);
                IWebElement[] arModifications = new IWebElement[35];
                ReadOnlyCollection<IWebElement> modificationItems = _driver.FindElements(By.CssSelector(".content-infor > div > ul > li"));
                modificationItems.CopyTo(arModifications, 0);
                for (int i = 0; i < expectedModifications.Length; i++)
                {
                    Assert.Equal(expectedModifications[i], arModifications[i].Text);
                }
            }
        }


        public void SelectModification1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbModification1.SelectByText(input);
            }
        }

        public void SelectModification2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbModification2.SelectByText(input);
            }
        }

        public void SelectModification3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbModification3.SelectByText(input);
            }
        }

        public void InputModification1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtModification1.Input(input);
            }
        }

        public void InputModification2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtModification2.Input(input);
            }
        }

        public void InputModification3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtModification3.Input(input);
            }
        }

        public void AddAnotherModification(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnAddModification.Click();
            }
        }

        public void VerifyUserJustCanAddMaximun3Modifications(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Equal(false, IsAddModificationButtonDisplay());
            }
        }

        public bool IsAddModificationButtonDisplay()
        {
            try
            {
                _driver.FindElement(addModificationSelector);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public void ClickOnALabelToAbleToClickOnAddAnotherModification(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                lblModification.Click();
            }
        }

        public void VerifyModificationNotMatchError(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("No matches found, please try another description.", lblModificationNotMatchError.GetText());
            }
        }

        public void RemoveModification1(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                btnRemoveModification1.Click();
            }
        }

        public void VerifyAfterRemoveModification(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("isActive", btnIsModifiedNo?.GetAttributeValue("class"));
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
            if (vehicleUseOption.Equals("Social, Domestic and Pleasure Only"))
            {
                btnSDPexC.Click();
            }
            else if (vehicleUseOption.Equals("Social, Domestic and Pleasure including Commuting"))
            {
                btnSDP.Click();
            }
            else if (vehicleUseOption.Equals(" Business Use "))
            {
                btnBusinessUse.Click();
            }
        }
        public void InputAnnualMileage(string annualMileage)
        {
            if (!String.IsNullOrEmpty(annualMileage))
            {
                txtAnnualMileage.Input(annualMileage);
            }
        }
        public void ClickDrivingInTheEU(string input)
        {
            if (input.Equals("Yes"))
            {
                btnPlanInTheEUYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnPlanInTheEUNo.Click();
            }
        }
        public void ClickContinueToAboutYou(string input)
        {
            if (input.Equals("Yes"))
            {
                BaseAction.FindAndClick(btnVehiclePageContinueSelector);
                WaitForLoadingIconDisappear();
                //WaitUntilElementExists(AboutYouPage.aboutYouProgressBar);
                //Thread.Sleep(4000);
                while (_driver.FindElements(btnVehiclePageContinueSelector).Count > 0)
                {
                    btnVehiclePageContinue.Click();
                    WaitForLoadingIconDisappear();
                    //Thread.Sleep(4000);
                }
            }
        }

        public void ClickContinueToAboutYou1(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                btnVehiclePageContinue.Click();
                Thread.Sleep(3000);
            }
        }

        public void VerifyAnualMileageErrorMessage(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal(input, lblErrorMessage.GetText());
            }
        }

        public void InputKeptPostcode(string estimatedValue)
        {
            if (!String.IsNullOrEmpty(estimatedValue))
            {
                txtKeptPostcode.Input(estimatedValue);
            }
        }
        public void InputEUMileage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtEUMileage.Input(input);
            }
        }
        public void SelectTimePlanOnEU(string input)
        {
            switch (input)
            {
                case " Less than 30 days ":
                    btnForeignUseA.Click();
                    break;
                case " 30 - 59 days ":
                    btnForeignUseB.Click();
                    break;
                case " 60 - 89 days ":
                    btnForeignUseC.Click();
                    break;
                case " More than 90 days ":
                    btnForeignUseD.Click();
                    break;
            }
        }
        #endregion
        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _yourVehicleData = new GuiModelData.VehicleData();
                _yourVehicleData.RegNumber = txtRegNumber?.GetPopulatedValue();
                //hien add 0306
                _yourVehicleData.IsLowProfileCampervan = btnLowProfileCampervan?.GetAttributeValue("class");
                _yourVehicleData.IsLowProfileMotorhome = btnLowProfileMotorhome?.GetAttributeValue("class");
                _yourVehicleData.IsEuropeanAClassMotorhome = btnEuropeanAClassMotorhome?.GetAttributeValue("class");
                _yourVehicleData.IsAmericanAClassMotorhome = btnAmericanAClassMotorhome?.GetAttributeValue("class");
                _yourVehicleData.IsDIYConversion = btnDIYConversion?.GetAttributeValue("class");
                _yourVehicleData.IsFixedHighRisingRoofCampervan = btnFixedHighRisingRoofCampervan?.GetAttributeValue("class");
                _yourVehicleData.IsCoachbuiltMotorhome = btnCoachbuiltMotorhome?.GetAttributeValue("class");
                _yourVehicleData.IsAmericanCClassMotorhome = btnAmericanCClassMotorhome?.GetAttributeValue("class");
                _yourVehicleData.IsDayVanLeisureVan = btnDayVanLeisureVan?.GetAttributeValue("class");

                _yourVehicleData.VehicleMake = cbVehicleMake?.GetText();
                _yourVehicleData.ManufacturerOrConverter = cbManufacturerOrConverter?.GetText();
                _yourVehicleData.VehicleModel = cbVehicleModel?.GetText();
                _yourVehicleData.YearOfManufacture = cbYearOfManufacture?.GetText();
                _yourVehicleData.EngineCC = txtEngineCC?.GetPopulatedValue();
                _yourVehicleData.FuelType = cbFuelType?.GetText();
                _yourVehicleData.TransmissionType = cbTransmissionType?.GetText();
                _yourVehicleData.NumberOfDoors = cbNumberOfDoors?.GetText();
                _yourVehicleData.NumOfSeats = cbSeats?.GetText();

                _yourVehicleData.IsTrackingDeviceYes = btnTrackerFittedYes?.GetAttributeValue("class");
                _yourVehicleData.IsTrackingDeviceNo = btnTrackerFittedNo?.GetAttributeValue("class");
                _yourVehicleData.IsLeftHand = btnLeftHandDrive?.GetAttributeValue("class");
                _yourVehicleData.IsRightHand = btnRightHandDrive?.GetAttributeValue("class");
                _yourVehicleData.EstimateValue = txtEstimateValue?.GetPopulatedValue();
                _yourVehicleData.IsConvertedPurposeBuiltYes = btnProfessionalConvertedYes?.GetAttributeValue("class");
                _yourVehicleData.IsConvertedPurposeBuiltNo = btnProfessionalConvertedNo?.GetAttributeValue("class");
                _yourVehicleData.HasManufacturerOrConverterYes = btnIsModifiedYes?.GetAttributeValue("class");
                _yourVehicleData.HasManufacturerOrConverterNo = btnIsModifiedNo?.GetAttributeValue("class");
                _yourVehicleData.OwnsVehicle = cbOwner?.GetText();
                _yourVehicleData.IsRegisteredKeeperYes = btnRegisteredKeeperYes?.GetAttributeValue("class");
                _yourVehicleData.IsRegisteredKeeperNo = btnRegisteredKeeperNo?.GetAttributeValue("class");
                _yourVehicleData.ParkOvernightAtHomeYes = btnParkOvernightAtHomeYes?.GetAttributeValue("class");
                _yourVehicleData.ParkOvernightAtHomeNo = btnParkOvernightAtHomeNo?.GetAttributeValue("class");
                _yourVehicleData.Miles = txtAnnualMileage?.GetPopulatedValue();
                _yourVehicleData.DrivingInEUYes = btnPlanInTheEUYes?.GetAttributeValue("class");
                _yourVehicleData.DrivingInEUNo = btnPlanInTheEUNo?.GetAttributeValue("class");
                _yourVehicleData.ParkOverNightInLockedGarage = btnInALockedGarage?.GetAttributeValue("class");
                _yourVehicleData.ParkOverNightOnDriveWay = btnOnADriveway?.GetAttributeValue("class");
                _yourVehicleData.ParkOverNightOnTheRoad = btnOnTheRoad?.GetAttributeValue("class");
                var isModifiedYes = btnIsModifiedYes?.GetAttributeValue("class");
                if (isModifiedYes.Equals("isActive"))
                {
                    _yourVehicleData.Modification1 = cbModification1.GetText();
                }

                var trackerFittedYes = btnTrackerFittedYes.GetAttributeValue("class");
                if (trackerFittedYes.Equals("isActive"))
                {
                    _yourVehicleData.TrakingType = cbTrackerType.GetText();
                }
                var parkOvernightAtHomeNo = btnParkOvernightAtHomeNo?.GetAttributeValue("class");
                if (parkOvernightAtHomeNo.Equals("isActive"))
                {
                    _yourVehicleData.KeptPostCode = txtKeptPostcode.GetPopulatedValue();
                }
            }
        }
        public void VerifyVehicleDataDisplayedCorrectly(string input)
        {
            try
            {
                if (input.Equals("Yes"))
                {
                    Assert.Equal(_yourVehicleData.RegNumber, txtRegNumber?.GetPopulatedValue());
                    Assert.Equal(_yourVehicleData.IsLowProfileCampervan, btnLowProfileCampervan?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsLowProfileMotorhome, btnLowProfileMotorhome?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsEuropeanAClassMotorhome, btnEuropeanAClassMotorhome?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsAmericanAClassMotorhome, btnAmericanAClassMotorhome?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsDIYConversion, btnDIYConversion?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsFixedHighRisingRoofCampervan, btnFixedHighRisingRoofCampervan?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsCoachbuiltMotorhome, btnCoachbuiltMotorhome?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsAmericanCClassMotorhome, btnAmericanCClassMotorhome?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsDayVanLeisureVan, btnDayVanLeisureVan?.GetAttributeValue("class"));

                    Assert.Equal(_yourVehicleData.VehicleMake, cbVehicleMake?.GetText());
                    Assert.Equal(_yourVehicleData.ManufacturerOrConverter, cbManufacturerOrConverter?.GetText());
                    Assert.Equal(_yourVehicleData.VehicleModel, cbVehicleModel?.GetText());
                    Assert.Equal(_yourVehicleData.YearOfManufacture, cbYearOfManufacture?.GetText());
                    Assert.Equal(_yourVehicleData.EngineCC, txtEngineCC?.GetPopulatedValue());
                    Assert.Equal(_yourVehicleData.FuelType, cbFuelType?.GetText());
                    Assert.Equal(_yourVehicleData.TransmissionType, cbTransmissionType?.GetText());
                    Assert.Equal(_yourVehicleData.NumberOfDoors, cbNumberOfDoors?.GetText());
                    Assert.Equal(_yourVehicleData.NumOfSeats, cbSeats?.GetText());

                    Assert.Equal(_yourVehicleData.IsTrackingDeviceYes, btnTrackerFittedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsTrackingDeviceNo, btnTrackerFittedNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsLeftHand, btnLeftHandDrive?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsRightHand, btnRightHandDrive?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.EstimateValue, txtEstimateValue?.GetPopulatedValue());
                    Assert.Equal(_yourVehicleData.IsConvertedPurposeBuiltYes, btnProfessionalConvertedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsConvertedPurposeBuiltNo, btnProfessionalConvertedNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.HasManufacturerOrConverterYes, btnIsModifiedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.HasManufacturerOrConverterNo, btnIsModifiedNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.OwnsVehicle, cbOwner?.GetText());
                    Assert.Equal(_yourVehicleData.IsRegisteredKeeperYes, btnRegisteredKeeperYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.IsRegisteredKeeperNo, btnRegisteredKeeperNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.ParkOvernightAtHomeYes, btnParkOvernightAtHomeYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.ParkOvernightAtHomeNo, btnParkOvernightAtHomeNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.Miles, txtAnnualMileage?.GetPopulatedValue());
                    Assert.Equal(_yourVehicleData.DrivingInEUYes, btnPlanInTheEUYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.DrivingInEUNo, btnPlanInTheEUNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.ParkOverNightInLockedGarage, btnInALockedGarage?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.ParkOverNightOnDriveWay, btnOnADriveway?.GetAttributeValue("class"));
                    Assert.Equal(_yourVehicleData.ParkOverNightOnTheRoad, btnOnTheRoad?.GetAttributeValue("class"));
                    var isModifiedYes = btnIsModifiedYes?.GetAttributeValue("class");
                    if (isModifiedYes.Equals("isActive"))
                    {
                        Assert.Equal(_yourVehicleData.Modification1, cbModification1.GetText());
                    }

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
                }
            }
            catch (Exception)
            {

            }
        }

        public void VerifyVehiclePageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var indicator = By.Id("VehiclePageContinue");
                WaitUntilElementExists(indicator);
                //Thread.Sleep(3000);
                var elements = _driver.FindElements(indicator);
                bool isTrue = elements.Count > 0;
                Assert.True(isTrue);
            }
        }

        public void VerifyFieldMissing1(string input)
        {
            switch (input)
            {
                case "VehicleType":
                case "EngineCC":
                case "ModelAlarmOrImmobiliser":
                case "TrackingModel":
                case "VehicleEstimationValue":
                case "VehiclePurchaseDate":
                case "VehicleDrivenMiles":
                case "PlanToDriveInEU":
                case "VehicleparkedOvernightNotAtHomePostcode":
                    Assert.Equal("Please complete this question to continue.", lblErrorMessage.GetText());
                    break;
                case "BaseVehicleMake":
                case "Manufacturer":
                case "Model":
                case "AlarmOrImmobiliser":
                case "VehicleTracking":
                case "VehicleHandDriveSide":
                case "VehicleConverted":
                case "VehicleModifiedFromConverter":
                case "VehicleOwner":
                case "VehicleRegisteredKeeper":
                case "VehicleparkedOvernight":
                case "VehicleparkedOvernightAtHome":
                case "VehiclePurpose":
                case "Modification":
                case "VehicleManufactured":
                    Assert.Contains(lblErrorMessage.GetText(),"Please select an option to continue.");
                    break;
                case "YearOfManufacture":
                case "Fuel":
                case "Transmision":
                case "NumberOfDoor":
                case "NumberOfSeatsBelt":
                    Assert.Equal("Please select an answer from the list.", lblErrorMessage.GetText());
                    break;
                case "PlanToDriveInEUMiles":
                    Assert.Equal("Please enter a value between 0 and 99999", lblErrorMessage.GetText());
                    break;
                default:
                    Console.WriteLine("This options was not covered");
                    break;
            }

        }
    }
}
