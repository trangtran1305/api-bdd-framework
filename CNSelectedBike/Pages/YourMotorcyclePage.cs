using CNSBike.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class YourMotorcyclePage : BasePage
    {
        private By pageTitle = By.CssSelector("div#your-motocycles>h2");

        public Textbox txtRegNumber = new Textbox(By.Id("RegNumber"));
        public Textbox txtPurchaseDay = new Textbox(By.Id("PurchaseDay"));
        public Textbox txtPurchaseMonth = new Textbox(By.Id("PurchaseMonth"));
        public Textbox txtPurchaseYear = new Textbox(By.Id("PurchaseYear"));
        public Textbox txtEstimateValue = new Textbox(By.XPath("//input[@id='EstimateValue']"));
        public Button btnIsModifiedYes = new Button(By.Id("IsModifiedYes"));
        public Button btnIsModifiedNo = new Button(By.Id("IsModifiedNo"));
        public Combobox cbIsImmobilisedFitted = new Combobox(By.Id("IsImmobilisedFitted"));
        public Combobox cbImmobiliserType = new Combobox(By.Id("ImmobiliserType"));
        public Combobox cbSecurityTagFitted = new Combobox(By.Id("SecurityTagFitted"));
        public Button btnTrackerFittedYes = new Button(By.Id("TrackerFittedYes"));
        public Button btnTrackerFittedNo = new Button(By.Id("TrackerFittedNo"));
        public Combobox cbTrackerType = new Combobox(By.Id("TrackerType"));
        //private Combobox cbSecurityTagFitted = new Combobox(By.XPath("//*[@id='SecurityTagFitted']/div/div/div[2]/input"));
        public Button btnOtherSecurityDevicesFittedYes = new Button(By.Id("OtherSecurityDevicesFittedYes"));
        public Button btnOtherSecurityDevicesFittedNo = new Button(By.Id("OtherSecurityDevicesFittedNo"));
        public Textbox txtAnnualMileage = new Textbox(By.Id("AnnualMileage"));
        public Button btnCarryPillionPassengersYes = new Button(By.Id("CarryPillionPassengersYes"));
        public Button btnCarryPillionPassengersNo = new Button(By.Id("CarryPillionPassengersNo"));
        public Combobox cbParkOvernight = new Combobox(By.Id("ParkOvernight"));
        public Button btnParkOvernightAtHomeYes = new Button(By.Id("ParkOvernightAtHomeYes"));
        public Button btnParkOvernightAtHomeNo = new Button(By.Id("ParkOvernightAtHomeNo"));
        public static By btnYourMotorcycleNextSelector = By.Id("VehiclePageContinue");
        public Button btnYourMotorcycleNext = new Button(btnYourMotorcycleNextSelector);
        public Textbox txtKeptPostcode = new Textbox(By.Id("KeptPostcode"));
        public Button btnFindVehicle = new Button(By.Id("FindVehicle"));

        public Combobox cbModification1 = new Combobox(By.Id("Modification1"));

        By motocycleInfor = By.XPath("//*[@id='MotorcycleSummaryForm']/div[1]/div[1]/div[2]/p");
        public Button btnAddMotorcycleNext = new Button(By.XPath("//div[2]/button[@id='VehiclePageContinue']"));
        public Combobox cbYearOfManufacture = new Combobox(By.Id("YearOfManufacture"));
        public Combobox cbMake = new Combobox(By.Id("Make"));
        public Combobox cbEngineSize = new Combobox(By.Id("EngineSize"));
        public Combobox cbModel = new Combobox(By.Id("Model"));
        public Combobox cbSelectVehicle = new Combobox(By.Id("SelectVehicle"));
        public void ClickAddMotorcycleNext(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAddMotorcycleNext.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void VerifyMotocycleInfomation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var element = _driver.FindElements(motocycleInfor);
                foreach (var ele in element)
                {
                    Assert.True(ele.Displayed);

                }
            }
        }
        #region Action

        public void InputRegNumber(string regNumber)
        {
            if (!String.IsNullOrEmpty(regNumber))
            {
                txtRegNumber.Input(regNumber);
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
                //_driver.FindElement(By.XPath("//html")).Click();
                Thread.Sleep(1000);
            }
        }

        public void InputEstimateValue(string estimatedValue)
        {
            if (!String.IsNullOrEmpty(estimatedValue))
            {
                txtEstimateValue.Input(estimatedValue);
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

        public void SelectImmobilisedFitted(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbIsImmobilisedFitted.SelectByText(input);
            }
        }
        public void SelectImmobiliserType(string immobiliserType)
        {
            if (!String.IsNullOrEmpty(immobiliserType))
            {
                cbImmobiliserType.SelectByText(immobiliserType);
            }
        }
        public void SelectTrackerType(string trackerType)
        {
            if (!String.IsNullOrEmpty(trackerType))
            {
                cbTrackerType.SelectByText(trackerType);
            }
        }

        public void SelectModification1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbModification1.SelectByText(input);
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

        public void SelectWithAnySecurityTags(string securityTag)
        {
            if (!String.IsNullOrEmpty(securityTag))
            {
                cbSecurityTagFitted.SelectByText(securityTag);
            }
        }
        public void HaveAnyPhysicalSecurityDevices(string input)
        {
            if (input.Equals("Yes"))
            {
                btnOtherSecurityDevicesFittedYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnOtherSecurityDevicesFittedNo.Click();
            }
        }

        public void InputAnnualMileage(string annualMileage)
        {
            if (!String.IsNullOrEmpty(annualMileage))
            {
                txtAnnualMileage.Input(annualMileage);
            }
        }
        public void IsUsedToCarryPillionPassengers(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCarryPillionPassengersYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCarryPillionPassengersNo.Click();
            }
        }

        public void SelectParkOvernight(string parkOvernightOption)
        {
            if (!String.IsNullOrEmpty(parkOvernightOption))
            {
                cbParkOvernight.SelectByText(parkOvernightOption);
            }
        }
        public void IsParkedOvernightAtHomeAddress(string input)
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

        public void InputKeptPostcode(string keptPostcode)
        {
            if (!String.IsNullOrEmpty(keptPostcode))
            {
                txtKeptPostcode.Input(keptPostcode);
            }
        }
        public void ClickYourMotorcycleNext(string input)
        {
            if (input.Equals("Yes"))
            {
                BaseAction.FindAndClick( btnYourMotorcycleNextSelector);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void ClickFindVehicle(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFindVehicle.Click();
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);

            }
        }
        #endregion
        #region Verify
        public void VerifyYourMotorcycleTitle(string input)
        {
            ClickContinueOnTrialPage();
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _yourMotorcycleData = new YourMotorcycleData();
                _yourMotorcycleData.RegNumber = txtRegNumber?.GetPopulatedValue();
                _yourMotorcycleData.PurchaseDay = txtPurchaseDay?.GetPopulatedValue();
                _yourMotorcycleData.PurchaseMonth = txtPurchaseMonth?.GetPopulatedValue();
                _yourMotorcycleData.PurchaseYear = txtPurchaseYear?.GetPopulatedValue();

                _yourMotorcycleData.EstimateValue = txtEstimateValue?.GetPopulatedValue();
                _yourMotorcycleData.IsModifiedYes = btnIsModifiedYes?.GetAttributeValue("class");
                _yourMotorcycleData.IsModifiedNo = btnIsModifiedNo?.GetAttributeValue("class");

                _yourMotorcycleData.IsImmobilisedFitted = cbIsImmobilisedFitted?.GetText();
                _yourMotorcycleData.TrackerFittedYes = btnTrackerFittedYes?.GetAttributeValue("class");
                _yourMotorcycleData.TrackerFittedNo = btnTrackerFittedNo?.GetAttributeValue("class");
                _yourMotorcycleData.SecurityTagFitted = cbSecurityTagFitted?.GetText();
                _yourMotorcycleData.OtherSecurityDevicesFittedYes = btnOtherSecurityDevicesFittedYes?.GetAttributeValue("class");
                _yourMotorcycleData.OtherSecurityDevicesFittedNo = btnOtherSecurityDevicesFittedNo?.GetAttributeValue("class");
                _yourMotorcycleData.AnnualMileage = txtAnnualMileage?.GetPopulatedValue();
                _yourMotorcycleData.ParkOvernight = cbParkOvernight?.GetText();

                _yourMotorcycleData.ParkOvernightAtHomeYes = btnParkOvernightAtHomeYes?.GetAttributeValue("class");
                _yourMotorcycleData.ParkOvernightAtHomeNo = btnParkOvernightAtHomeNo?.GetAttributeValue("class");
                //_yourMotorcycleData.KeptPostcode = txtKeptPostcode?.GetPopulatedValue();
                //_yourMotorcycleData.Modification1 = cbModification1?.GetText();

            }

        }
        public void VerifyAllDataDisplayed(string input)
        {
            try
            {
                if (input.Equals("Yes"))
                {
                    Assert.Equal(_yourMotorcycleData.RegNumber, txtRegNumber?.GetPopulatedValue());
                    Assert.Equal(_yourMotorcycleData.TrackerFittedYes, btnTrackerFittedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.RegNumber, txtRegNumber?.GetPopulatedValue());
                    Assert.Equal(_yourMotorcycleData.PurchaseDay, txtPurchaseDay?.GetPopulatedValue());
                    Assert.Equal(_yourMotorcycleData.PurchaseMonth, txtPurchaseMonth?.GetPopulatedValue());
                    Assert.Equal(_yourMotorcycleData.PurchaseYear, txtPurchaseYear?.GetPopulatedValue());

                    Assert.Equal(_yourMotorcycleData.EstimateValue, txtEstimateValue?.GetPopulatedValue());
                    Assert.Equal(_yourMotorcycleData.IsModifiedYes, btnIsModifiedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.IsModifiedNo, btnIsModifiedNo?.GetAttributeValue("class"));

                    Assert.Equal(_yourMotorcycleData.IsImmobilisedFitted, cbIsImmobilisedFitted?.GetText());
                    Assert.Equal(_yourMotorcycleData.TrackerFittedYes, btnTrackerFittedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.TrackerFittedNo, btnTrackerFittedNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.SecurityTagFitted, cbSecurityTagFitted?.GetText());
                    Assert.Equal(_yourMotorcycleData.OtherSecurityDevicesFittedYes, btnOtherSecurityDevicesFittedYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.OtherSecurityDevicesFittedNo, btnOtherSecurityDevicesFittedNo?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.AnnualMileage, txtAnnualMileage?.GetPopulatedValue());
                    Assert.Equal(_yourMotorcycleData.ParkOvernight, cbParkOvernight?.GetText());

                    Assert.Equal(_yourMotorcycleData.ParkOvernightAtHomeYes, btnParkOvernightAtHomeYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourMotorcycleData.ParkOvernightAtHomeNo, btnParkOvernightAtHomeNo?.GetAttributeValue("class"));
                    //Assert.Equal(_yourMotorcycleData.KeptPostcode, txtKeptPostcode?.GetPopulatedValue());
                    //Assert.Equal(_yourMotorcycleData.Modification1, cbModification1?.GetText());

                }
            }
            catch (Exception)
            { }
        }

        public void EditRegNumber(string regNumber)
        {
            if (!String.IsNullOrEmpty(regNumber))
            {
                // txtRegNumber.
                txtRegNumber.EditInput(regNumber);
            }
        }
        #endregion
        public void SelectYearOfManufacture(string input)
        {
            var eles = _driver.FindElements(By.Id("YearOfManufacture"));
            if (eles.Count > 0)
            {
                cbYearOfManufacture.SelectByText(input);
                Thread.Sleep(3000);
            }
        }
        public void SelectMake(string input)
        {
            var eles = _driver.FindElements(By.Id("Make"));
            if (eles.Count > 0)
            {
                cbMake.SelectByText(input);
                Thread.Sleep(3000);
            }

        }
        public void SelectEngineSize(string input)
        {
            var eles = _driver.FindElements(By.Id("EngineSize"));
            if (eles.Count > 0)
            {
                cbEngineSize.SelectByText(input);
                Thread.Sleep(3000);
            }
        }
        public void SelectModel(string input)
        {
            var eles = _driver.FindElements(By.Id("Model"));
            if (eles.Count > 0)
            {
                cbModel.SelectByText(input);
                Thread.Sleep(3000);
            }
        }
        public void SelectSelectVehicle(string input)
        {
            var eles = _driver.FindElements(By.Id("SelectVehicle"));
            if (eles.Count > 0)
            {
                cbSelectVehicle.SelectByText(input);
            }
        }

    }
}