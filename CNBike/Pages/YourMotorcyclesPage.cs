using CNBike.Model;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    public class YourMotorcyclesPage : BasePage
    {
        //Registration
        private By txtRegistrationNumber = By.Id("AboutYourVehicle_RegistrationNumber");
        private By txtRegistrationNumberTitle = By.XPath("//*[@formcontrolname='registrationNumber']//span[@class='text-label']");
        private By txtPurchaseDateTitle = By.XPath("//*[@formcontrolname='boughtDate']//span[@class='text-label']");
        private By txtEstimatedMotorcycleTitle = By.XPath("//*[@formcontrolname='estimatedMotorcycle']//span[@class='text-label']");

        private By pageTitle = By.CssSelector("#your-motocycles .title");
        private By btnLookupRegistration = By.Id("btnlookup_Registration");
        private By lblDoNotKnow = By.Id("AboutYourVehicle_DoNotKnow");
        private By errRegistrationNumber = By.XPath("//*[@formcontrolname='registrationNumber']//small");
        private By ddlYearManufacture = By.Id("AboutYourVehicle_YearManufacture");
        private By lblYearManufacture = By.XPath("//*[@formcontrolname='manufactureDate']//span[@class='text-label']");
        private By lblYearManufactureValue = By.XPath("//*[@formcontrolname='manufactureDate']//span[@class='ng-value-label']");
        private By errYearManufacture = By.XPath("//*[@formcontrolname='manufactureDate']//small/p");
        private By txtMake = By.Id("AboutYourVehicle_Make");
        private By lblMake = By.XPath("//*[@formcontrolname='make']//span[@class='text-label']");
        private By txtEngineSize = By.Id("AboutYourVehicle_EngineSize");
        private By lblEngineSize = By.XPath("//*[@formcontrolname='engine']//span[@class='text-label']");
        private By txtModel = By.Id("AboutYourVehicle_Model");
        private By lblModel = By.XPath("//*[@formcontrolname='model']//span[@class='text-label']");
        private By ddlSpecificMotorcycle = By.Id("AboutYourVehicle_SpecificMotorcycle");
        private By lblSpecificMotorcycle = By.XPath("//*[@formcontrolname='specificMotorcycle']//span[@class='text-label']");
        private By lblWeFoundTheFollowingMotorcycle = By.CssSelector(".search-results h5");
        private By lblNoVehicle = By.Id("AboutYourVehicle_NoVehicle");
        private By lblNotMyMotorcycle = By.Id("AboutYourVehicle_NotMyMotorcycle");
        private By txtPurchaseDateDay = By.Id("autonetDateInputDay_AboutYourVehicle_PurchaseDate");
        private By txtPurchaseDateMonth = By.Id("autonetDateInputMonth_AboutYourVehicle_PurchaseDate");
        private By txtPurchaseDateYear = By.Id("autonetDateInputYear_AboutYourVehicle_PurchaseDate");
        private By txtEstimatedMotorcycle = By.Id("AboutYourVehicle_EstimatedMotorcycle");
        //Modifications
        private By NumberDynamicQuestionItemsY = By.Id("AboutYourVehicle_DynamicModifications_SelectedNumberDynamicQuestionItems_Y");
        private By NumberDynamicQuestionItemsN = By.Id("AboutYourVehicle_DynamicModifications_SelectedNumberDynamicQuestionItems_N");
        private By AboutYourVehicleDynamicModificationsQuestion0 = By.Id("AboutYourVehicle_DynamicModifications_Questions_0__SelectedAnswer");
        private By txtAboutYourVehicleDynamicModificationsQuestion0 = By.XPath("//*[@id='AboutYourVehicle_DynamicModifications_Questions_0__SelectedAnswer']//span[@class='ng-value-label']");
        private By AboutYourVehicleDynamicModificationsQuestion1 = By.Id("AboutYourVehicle_DynamicModifications_Questions_1__SelectedAnswer");
        private By txtAboutYourVehicleDynamicModificationsQuestion1 = By.XPath("//*[@id='AboutYourVehicle_DynamicModifications_Questions_1__SelectedAnswer']//span[@class='ng-value-label']");
        private By AboutYourVehicleDynamicModificationsQuestion2 = By.Id("AboutYourVehicle_DynamicModifications_Questions_2__SelectedAnswer");
        private By txtAboutYourVehicleDynamicModificationsQuestion2 = By.XPath("//*[@id='AboutYourVehicle_DynamicModifications_Questions_2__SelectedAnswer']//span[@class='ng-value-label']");
        private By AboutYourVehicleDynamicModificationsQuestionsAddAnswer = By.Id("AboutYourVehicle_DynamicModifications_Questions_AddAnswer");
        private By AboutYourVehicleEstimatedAnnualMileage = By.Id("AboutYourVehicle_Estimated_Annual_Mileage");
        private By AboutYourVehicleCarryPillionPassengersY = By.Id("AboutYourVehicle_Carry_Pillion_Passengers_Y");
        private By AboutYourVehicleCarryPillionPassengersN = By.Id("AboutYourVehicle_Carry_Pillion_Passengers_N");
        private By AboutYourVehicleWhereKept = By.Id("AboutYourVehicle_WhereKept");
        private By txtAboutYourVehicleWhereKept = By.XPath("//*[@id='AboutYourVehicle_WhereKept']//span[@class='ng-value-label']");
        private By AboutYourVehicle_Overnight_N = By.Id("AboutYourVehicle_Overnight_N");
        private By AboutYourVehicle_Overnight_Y = By.Id("AboutYourVehicle_Overnight_Y");
        private By AboutYourVehicleKeptPostcode = By.Id("AboutYourVehicle_KeptPostcode");

        //Security
        private By ddlImmobiliserOrAlarm = By.Id("AboutYourVehicle_ImmobiliserOrAlarm");
        private By txtImmobiliserOrAlarm = By.XPath("//*[@id='AboutYourVehicle_ImmobiliserOrAlarm']//span[@class='ng-value-label']");
        private By ddlAboutYourVehicleImmobiliser = By.Id("AboutYourVehicle_Immobiliser");
        private By btnAboutYourVehicle_TrackerOption_Y = By.Id("AboutYourVehicle_TrackerOption_Y");
        private By btnAboutYourVehicle_TrackerOption_N = By.Id("AboutYourVehicle_TrackerOption_N");
        private By ddlAboutYourVehicle_Tracker = By.Id("AboutYourVehicle_Tracker");
        private By txtlAboutYourVehicle_Tracker = By.XPath("//*[@id='AboutYourVehicle_Tracker']//span[@class='ng-value-label']");
        private By ddlAboutYourVehicle_Datatag_Or_Alphadot = By.Id("AboutYourVehicle_Datatag_Or_Alphadot");
        private By txtAboutYourVehicle_Datatag_Or_Alphadot = By.XPath("//*[@id='AboutYourVehicle_Datatag_Or_Alphadot']//span[@class='ng-value-label']");

        private By btnAboutYourVehicle_OtherPhysicalSecurity_Y = By.Id("AboutYourVehicle_OtherPhysicalSecurity_Y");
        private By btnAboutYourVehicle_OtherPhysicalSecurity_N = By.Id("AboutYourVehicle_OtherPhysicalSecurity_N");

        private By btnbtnNext = By.Id("btnNext");
        private By btnYourMotorcycle = By.Id("btnYourMotorcycle");
        private By btnAboutYou = By.Id("btnAboutYou");
        private By btnContinue = By.Id("btnContinue");
        private By popupCompareDataChange = By.CssSelector(".modal-backdrop");

        //CacheData
        public Motorcycle Motorcycle = new Motorcycle();
        public List<ModificationItem> modificationList = new List<ModificationItem>();


        public void InputautonetDateInputAboutYourVehiclePurchaseDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                String[] strlist = input.Split('/', 3);
                TypeInElement(txtPurchaseDateDay, strlist[0]);
                TypeInElement(txtPurchaseDateMonth, strlist[1]);
                TypeInElement(txtPurchaseDateYear, strlist[2]);
                var date = new DateType();
                date.day = strlist[0];
                date.month = strlist[1];
                date.years = strlist[2];
                Motorcycle.vehicleDetail.boughtDate = date;
            }
        }

        public void ClickAboutYourVehicleNotMyMotorcycle(string input)
        {
            if (input.Equals("Required"))
            {
                Click(lblNotMyMotorcycle);
            }
        }

        public void SelectAboutYourVehicleSpecificMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleDetail.vehicleSpecific = input;
                Click(ddlSpecificMotorcycle);
                //WaitUntilElementClickable(ddlSpecificMotorcycle, 5000);
                //Thread.Sleep(500);
                var option = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(option);
                Click(option);

                if (!input.Contains("Other"))
                { //select other form be hidden and not select data from DOM
                    Motorcycle.vehicleDetail.manufactureDate = getTextFromDropdown(lblYearManufactureValue);
                    Motorcycle.vehicleDetail.make = getTextFromInput(txtMake);
                    Motorcycle.vehicleDetail.engine = getTextFromInput(txtEngineSize);
                    Motorcycle.vehicleDetail.model = getTextFromInput(txtModel);
                }
            }
        }

        public void InputAboutYourVehicleModel(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtModel, input);
                Thread.Sleep(2000);
            }
        }

        public void InputAboutYourVehicleEngineSize(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtEngineSize, input);
            }
        }

        public void InputAboutYourVehicleMake(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtMake, input);
            }
        }

        public void SelectAboutYourVehicleYearManufacture(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(ddlYearManufacture);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                Thread.Sleep(500);
                Click(expectedValue);
            }
        }

        public void InputAboutYourVehicleEstimatedMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleDetail.estimatedMotorcycle = input;
                TypeInElement(txtEstimatedMotorcycle, input);
            }
        }

        public void ClickAboutYourVehicleNoVehicle(string input)
        {
            if (input.Equals("Required"))
            {
                Click(lblNoVehicle);
            }
        }

        public void VerifyWeFoundTheFollowingMotorcycleLabel(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.Equal("We found the following motorcycle:", GetElementText(lblWeFoundTheFollowingMotorcycle));
            }
        }

        public void VerifyAboutYourVehicleYearManufactureErrorMessage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(GetElementText(errYearManufacture), input);
            }
        }

        public void VerifyAboutYourVehicleSpecificMotorcycleTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(lblSpecificMotorcycle));
            }
        }

        public void VerifyAboutYourVehicleModelTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(lblModel));
            }
        }

        public void VerifyAboutYourVehicleEngineSizeTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(lblEngineSize));
            }
        }

        public void VerifyAboutYourVehicleMakeTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(lblMake));
            }
        }

        public void VerifyAboutYourVehicleYearManufactureTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(lblYearManufacture));
            }
        }

        public void ClickBtnlookupRegistration(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnLookupRegistration);
            }
        }

        public void VerifyAboutYourVehicleRegistrationNumberErrorMessage(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.Equal(GetElementText(errRegistrationNumber), input);
            }
        }

        public void ClickAboutYourVehicleDoNotKnow(string input)
        {
            if (input.Equals("Required"))
            {
                Click(lblDoNotKnow);
                Find(lblDoNotKnow).GetAttribute("class").Contains("hidden-all");

            }
        }

        public void VerifyAboutYourVehicleDoNotKnowNotDisplayed(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementHidden(lblDoNotKnow));
            }
        }

        public void VerifyAboutYourVehicleEstimatedMotorcycleTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(txtEstimatedMotorcycleTitle));
            }
        }

        public void VerifyAboutYourVehiclePurchaseDateTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(txtPurchaseDateTitle));
            }
        }

        public void VerifyAboutYourVehicleRegistrationNumberTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(1000);
                Assert.True(IsElementDisplayed(txtRegistrationNumberTitle));
            }
        }

        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void InputAboutYourVehicleRegistrationNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtRegistrationNumber, input);
                Motorcycle.vehicleDetail.registrationNumber = input;
            }
            
        }

        //Verify all fields displayed after click on "I don’t know the registration"
        public void VerifyAboutYourVehicleFieldsDisplayed(string input)
        {
            if (string.Equals(input, "Required", StringComparison.CurrentCultureIgnoreCase))
            {
                Assert.True(!Find(ddlYearManufacture).Displayed);
                Assert.True(!Find(txtMake).Displayed);
                Assert.True(!Find(txtEngineSize).Displayed);
                Assert.True(!Find(txtModel).Displayed);
                Assert.True(!Find(ddlSpecificMotorcycle).Displayed);
            }
        }

        //Modifications
        public void ClickAboutYourVehicleDynamicModificationsSelectedNumberDynamicQuestionItems(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleModifications.yesNoModification = input;
                if (input.Equals("Yes"))
                {
                    Click(NumberDynamicQuestionItemsY);
                }
                else
                {
                    Click(NumberDynamicQuestionItemsN);
                }
            }
        }

        public void SelectAboutYourVehicleDynamicModificationsQuestions0SelectedAnswer(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var modificationItem = new ModificationItem();
                modificationItem.modificationName = input;
                modificationItem.modificationIndex = 0;
                modificationList.Add(modificationItem);

                Motorcycle.vehicleModifications.modificationItem = modificationList;
                Click(AboutYourVehicleDynamicModificationsQuestion0);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }

        }

        public void ClickAboutYourVehicleDynamicModificationsQuestionsAddAnswer(string input)
        {
            if (input.Equals("Required"))
            {
                Click(AboutYourVehicleDynamicModificationsQuestionsAddAnswer);
            }
        }

        public void SelectAboutYourVehicleDynamicModificationsQuestions1SelectedAnswer(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var modificationItem = new ModificationItem();
                modificationItem.modificationName = input;
                modificationItem.modificationIndex = 1;
                modificationList.Add(modificationItem);
                Motorcycle.vehicleModifications.modificationItem = modificationList;

                Click(AboutYourVehicleDynamicModificationsQuestion1);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAboutYourVehicleDynamicModificationsQuestions2SelectedAnswer(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {

                var modificationItem = new ModificationItem();
                modificationItem.modificationName = input;
                modificationItem.modificationIndex = 2;
                modificationList.Add(modificationItem);
                Motorcycle.vehicleModifications.modificationItem = modificationList;

                Click(AboutYourVehicleDynamicModificationsQuestion2);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void InputAboutYourVehicleEstimatedAnnualMileage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.motorcycleUse.estimatedMiles = input;
                TypeInElement(AboutYourVehicleEstimatedAnnualMileage, input);
            }
        }

        public void ClickAboutYourVehicleCarryPillionPassengers(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.motorcycleUse.yesNoPillionPassengers = input;
                if (input.Equals("Yes"))
                {
                    Click(AboutYourVehicleCarryPillionPassengersY);
                }
                else
                {
                    Click(AboutYourVehicleCarryPillionPassengersN);
                }
            }
        }

        public void SelectAboutYourVehicleWhereKept(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.motorcycleUse.vehicleStorageLocation = input;
                Click(AboutYourVehicleWhereKept);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void ClickAboutYourVehicleOvernight(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.motorcycleUse.motorcycleParked = input;
                if (input.Equals("Yes"))
                {
                    Click(AboutYourVehicle_Overnight_Y);
                }
                else
                {
                    Click(AboutYourVehicle_Overnight_N);
                }
            }
        }

        public void InputAboutYourVehicleKeptPostcode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.motorcycleUse.postCode = input;
                TypeInElement(AboutYourVehicleKeptPostcode, input);
            }
        }
        // Script for Security block
        public void SelectAboutYourVehicleImmobiliserOrAlarm(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleSecurity.electronicOption = input;
                Click(ddlImmobiliserOrAlarm);
                Click(By.XPath("//span[text() = '" + input + "']"));
            }
        }

        public void SelectAboutYourVehicleImmobiliser(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleSecurity.immobiliserOption = input;
                Click(ddlAboutYourVehicleImmobiliser);
                Click(By.XPath("//span[text() = '" + input + "']"));
            }
        }
        public void ClickAboutYourVehicleTrackerOption(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleSecurity.yesNoTrackingDevice = input;
                if (input.Equals("Yes"))
                {
                    Click(btnAboutYourVehicle_TrackerOption_Y);
                }
                else
                {
                    Click(btnAboutYourVehicle_TrackerOption_N);
                }
            }
        }

        public void SelectAboutYourVehicleTracker(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Thread.Sleep(2000);
                Motorcycle.vehicleSecurity.trackingOption = input;
                Click(ddlAboutYourVehicle_Tracker);
                WaitUntilElementExists(ddlAboutYourVehicle_Tracker);
                Click(By.XPath("//span[text() = '" + input + "']"));
            }
        }

        public void SelectAboutYourVehicleDatatagOrAlphadot(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleSecurity.securityOption = input;

                Click(ddlAboutYourVehicle_Datatag_Or_Alphadot);
                Click(By.XPath("//span[text() = '" + input + "']"));
            }
        }
        public void ClickAboutYourVehicleOtherPhysicalSecurity(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Motorcycle.vehicleSecurity.yesNoSecurityDevices = input;
                if (input.Equals("Yes"))
                {
                    Click(btnAboutYourVehicle_OtherPhysicalSecurity_Y);
                }
                else
                {
                    Click(btnAboutYourVehicle_OtherPhysicalSecurity_N);
                }
            }

        }
        public void saveDataToCookie()
        {
             var cacheModel = getCookie();
                Motorcycle.index = cacheModel.Motorcycles.Count;
                cacheModel.Motorcycles.Add(Motorcycle);
                addCookie(cacheModel);
                //VerifyData(Motorcycle.index.ToString());
            
        }

        public void VerifyDataBehicleDetail(VehicleDetail vehicleDetail)
        {
            
                CheckAssertData(txtRegistrationNumber, vehicleDetail.registrationNumber, TypeFormControl.Input);
                CheckAssertData(txtMake, vehicleDetail.make, TypeFormControl.Input);
                CheckAssertData(txtEngineSize, vehicleDetail.engine, TypeFormControl.Input);
                CheckAssertData(txtModel, vehicleDetail.model, TypeFormControl.Input);
                CheckAssertData(txtEstimatedMotorcycle, vehicleDetail.estimatedMotorcycle, TypeFormControl.Input);

            
        }
        public void VerifyDataModification(VehicleModifications vehicleModifications)
        {
            if (vehicleModifications.yesNoModification.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
            {
                CheckAssertData(txtAboutYourVehicleDynamicModificationsQuestion0, vehicleModifications?.modificationItem?[0]?.modificationName, TypeFormControl.DropDownList);
                if (vehicleModifications?.modificationItem.Count > 1)
                {
                    CheckAssertData(txtAboutYourVehicleDynamicModificationsQuestion1, vehicleModifications?.modificationItem?[1]?.modificationName, TypeFormControl.DropDownList);
                    if (vehicleModifications?.modificationItem.Count > 2)
                    {

                        CheckAssertData(txtAboutYourVehicleDynamicModificationsQuestion2, vehicleModifications?.modificationItem?[2]?.modificationName, TypeFormControl.DropDownList);
                    }
                }
            }
        }

        public void VerifyDataSecurity(VehicleSecurity vehicleSecurity)
        {
            CheckAssertData(txtImmobiliserOrAlarm, vehicleSecurity.electronicOption, TypeFormControl.DropDownList);
            if (!String.IsNullOrEmpty(vehicleSecurity.yesNoTrackingDevice) && vehicleSecurity.yesNoTrackingDevice.Equals("Yes"))
            {
                CheckAssertData(btnAboutYourVehicle_TrackerOption_Y, "", TypeFormControl.BtnYesNo);
                CheckAssertData(txtlAboutYourVehicle_Tracker, vehicleSecurity.trackingOption, TypeFormControl.DropDownList);
            }
            else
            {
                CheckAssertData(btnAboutYourVehicle_TrackerOption_N, "", TypeFormControl.BtnYesNo);
            }
            CheckAssertData(txtAboutYourVehicle_Datatag_Or_Alphadot, vehicleSecurity.securityOption, TypeFormControl.DropDownList);
            if (!String.IsNullOrEmpty(vehicleSecurity.yesNoSecurityDevices) && vehicleSecurity.yesNoSecurityDevices.Equals("Yes"))
            {
                CheckAssertData(btnAboutYourVehicle_OtherPhysicalSecurity_Y, "", TypeFormControl.BtnYesNo);
            }
            else
            {
                CheckAssertData(btnAboutYourVehicle_OtherPhysicalSecurity_N, "", TypeFormControl.BtnYesNo);
            }
        }

        public void VerifyDataMotorcycleUse(MotorcycleUse motorcycleUse)
        {
            CheckAssertData(AboutYourVehicleEstimatedAnnualMileage, motorcycleUse.estimatedMiles, TypeFormControl.Input);
            if (!String.IsNullOrEmpty(motorcycleUse.yesNoPillionPassengers) && motorcycleUse.yesNoPillionPassengers.Equals("Yes"))
            {
                CheckAssertData(AboutYourVehicleCarryPillionPassengersY, "", TypeFormControl.BtnYesNo);
            }
            else
            {
                CheckAssertData(AboutYourVehicleCarryPillionPassengersN, "", TypeFormControl.BtnYesNo);
            }
            CheckAssertData(txtAboutYourVehicleWhereKept, motorcycleUse.vehicleStorageLocation, TypeFormControl.DropDownList);
            
        }

        public void VerifyData(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var cacheModel = getCookie();
                var MotorcyclesIndex = cacheModel.Motorcycles[Int16.Parse(input)];
                Thread.Sleep(1000);
                //modification
                VerifyDataModification(MotorcyclesIndex.vehicleModifications);
                // security
                VerifyDataSecurity(MotorcyclesIndex.vehicleSecurity);
                //Motorcycle use
                VerifyDataMotorcycleUse(MotorcyclesIndex.motorcycleUse);
            }
        }

    
        public void ClickNextPage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                saveDataToCookie();
                if (input.Equals("Required"))
                {
                    Click(btnbtnNext);
                    WaitForLoadingIconDisappear();
                    if (_driver.FindElements(pageTitle).Count > 0)
                    {
                        Click(btnbtnNext);
                        WaitForLoadingIconDisappear();
                    }
                }
            }
        }

        public void ClickBtnNext(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(btnbtnNext);
                Click(btnbtnNext);
                WaitForLoadingIconDisappear();
                if (_driver.FindElements(pageTitle).Count > 0)
                {
                    Click(btnbtnNext);
                    WaitForLoadingIconDisappear();
                }
            }
        }
        public void ClickBtnYourMotorcycle(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnYourMotorcycle);
                Thread.Sleep(5000);
            }
        }
        public void ClickBtnAboutYou(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnAboutYou);
                Thread.Sleep(5000);
            }
        }
        public void ClickBtnContinuePopupEdit(string input)
        {
            if (input.Equals("Required"))
            {
                WaitUntilElementVisible(popupCompareDataChange);
               // var wl = _driver.WindowHandles.ToString();
                //var w = _driver.SwitchTo().Window();
                _driver.FindElement(popupCompareDataChange).SendKeys(Keys.Enter);
                Thread.Sleep(5000);

            }
        }
        public void VerifyBehaviourWhenSelectDoNotKnowRegNumber(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(1000);
                Assert.True(_driver.FindElements(ddlYearManufacture).Count > 0);
                Assert.True(_driver.FindElements(txtMake).Count > 0);
                Assert.True(_driver.FindElements(txtEngineSize).Count > 0);
                Assert.True(_driver.FindElements(txtModel).Count > 0);
                Assert.True(_driver.FindElements(ddlSpecificMotorcycle).Count > 0);
            }
        }
    }
}
