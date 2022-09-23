using CNBike.Model;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    class RiderHistoryPage : BasePage
    {
        private By pageTitle = By.CssSelector("#history .title");

        //Claims
        private By btnBtnHasClaim_Y = By.Id("btnHasClaim_Y");
        private By btnBtnHasClaim_N = By.Id("btnHasClaim_N");
        private By ddlDdlClaimRiderName = By.Id("ddlClaimRiderName");
        private By txtAutonetDateInputDay_ClaimDate = By.Id("autonetDateInputDay_ClaimDate");
        private By txtAutonetDateInputMonth_ClaimDate = By.Id("autonetDateInputMonth_ClaimDate");
        private By txtAutonetDateInputYear_ClaimDate = By.Id("autonetDateInputYear_ClaimDate");
        private By txtClaimType = By.CssSelector("#ClaimType input");
        private By btnClaimType = By.XPath("//*[@id='ClaimType']/ng-dropdown-panel//span");
        private By txtOwnDamageCost = By.Id("OwnDamageCost");
        private By btnFault_Y = By.Id("Fault_Y");
        private By btnFault_N = By.Id("Fault_N");
        private By btnBtnSaveClaim = By.Id("btnSaveClaim");
        private By btnBtnCancelSaveClaim = By.Id("btnCancelSaveClaim");
        private By btnDeleteClaim_1 = By.Id("deleteClaim_1");
        private By btnRiderHistory_Claim_Y = By.Id("RiderHistory_Claim_Y");
        private By btnRiderHistory_Claim_N = By.Id("RiderHistory_Claim_N");
        private By btnAddAnotherClaim = By.Id("addAnotherClaim");
        private By TextClaimType = By.XPath("//*[@id='ClaimType']//span[@class='ng-value-label']");
        private By TextOffenceType = By.XPath("//*[@id='OffenceType']//span[@class='ng-value-label']");
        //Convictions
        private By btnBtnHasConviction_Y = By.Id("btnHasConviction_Y");
        // By btnBtnHasConviction_Y = By.Id("CoreConvictionOneDriverYes");            
        private By btnBtnHasConviction_N = By.Id("btnHasConviction_N");
        //private By btnBtnHasConviction_N = By.Id("CoreConvictionOneDriverNo");
        private By ddlDdlConvictionRiderName = By.Id("ddlConvictionRiderName");
        private By txtAutonetDateInputDay_ConvictionDate = By.Id("autonetDateInputDay_ConvictionDate");
        private By txtAutonetDateInputMonth_ConvictionDate = By.Id("autonetDateInputMonth_ConvictionDate");
        private By txtAutonetDateInputYear_ConvictionDate = By.Id("autonetDateInputYear_ConvictionDate");
        private By txtOffenceType = By.CssSelector("#OffenceType input");
        private By btnOffenceType = By.XPath("//*[@id='OffenceType']/ng-dropdown-panel//span");
        private By txtPoints = By.Id("Points");
        private By btnIsFines_Y = By.Id("isFines_Y");
        private By btnIsFines_N = By.Id("isFines_N");
        private By txtFine = By.Id("Fine");
        private By btnIsBanned_Y = By.Id("isBanned_Y");
        private By btnIsBanned_N = By.Id("isBanned_N");
        private By txtBanLength = By.Id("BanLength");
        private By btnBtnSaveConviction = By.Id("btnSaveConviction");
        private By btnBtnCancelSaveConviction = By.Id("btnCancelSaveConviction");
        private By btnDeleteConviction_1 = By.Id("deleteConviction_1");
        private By btnRiderHistory_Conviction_Y = By.Id("RiderHistory_Conviction_Y");
        private By btnRiderHistory_Conviction_N = By.Id("RiderHistory_Conviction_N");
        private By btnAddAnotherConviction = By.Id("addAnotherConviction");

        //No Claims Bonus
        private By ddlDdlYearsOfNCB = By.Id("ddlYearsOfNCB");
        private By TextDdlYearsOfNCB = By.XPath("//*[@id='ddlYearsOfNCB']//span[@class='ng-value-label']");
        private By btnBtnHaveOwnedMotorcycle_Y = By.Id("btnHaveOwnedMotorcycle_Y");
        private By btnBtnHaveOwnedMotorcycle_N = By.Id("btnHaveOwnedMotorcycle_N");
        private By ddlDdlStyleOfMotorcycle = By.Id("ddlStyleOfMotorcycle");
        private By txtDdlStyleOfMotorcycle = By.XPath("//*[@id='ddlStyleOfMotorcycle']//span[@class='ng-value-label']");
        private By txtTxtEngineSizeOfMotorcycle = By.Id("txtEngineSizeOfMotorcycle");
        private By ddlDdlYearOfManufactureTheMotorcycle = By.Id("ddlYearOfManufactureTheMotorcycle");
        private By txtDdlYearOfManufactureTheMotorcycle = By.XPath("//*[@id='ddlYearOfManufactureTheMotorcycle']//span[@class='ng-value-label']");
        private By ddlDdlQuantityYearsOwnTheMotorcycle = By.Id("ddlQuantityYearsOwnTheMotorcycle");
        private By txtDdlQuantityYearsOwnTheMotorcycle = By.XPath("//*[@id='ddlQuantityYearsOwnTheMotorcycle']//span[@class='ng-value-label']");
        private By ddlDdlQuantityYearsNCBHaveOnMotorcycle = By.Id("ddlQuantityYearsNCBHaveOnMotorcycle");
        private By txtDdlQuantityYearsNCBHaveOnMotorcycle = By.XPath("//*[@id='ddlQuantityYearsNCBHaveOnMotorcycle']//span[@class='ng-value-label']");
        private By ddlDdlTimeLastRideTheMotorcycle = By.Id("ddlTimeLastRideTheMotorcycle");
        private By txtDdlTimeLastRideTheMotorcycle = By.XPath("//*[@id='ddlTimeLastRideTheMotorcycle']//span[@class='ng-value-label']");
        private By btnBtnRiderHistory_Continue = By.Id("btnRiderHistory_Continue");
        private By ddAboutYourVehicleUseOfVehicle = By.Id("AboutYourVehicle_UseOfVehicle");

        // Progress
        private By btnYourMotorcycle = By.Id("btnYourMotorcycle");
        // 
        private By btnYourCover = By.Id("btnYourCover");

        public Claim Claim = new Claim();
        public Conviction Conviction = new Conviction();
        public List<Claim> ClaimList = new List<Claim>();
        public List<Conviction> ConvictionList = new List<Conviction>();
        public NoClaimsBonus NoClaimsBonus = new NoClaimsBonus();

        public void ClickBtnYourCover(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnYourCover);
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }
        public void VerifyData(string input)
        {
            if (input.Equals("Required"))
            {
                var cacheModel = getCookie();
                VerifyDataClaims(cacheModel.Claims);
                VerifyDataConviction(cacheModel.Convictions);
                VerifyNoClaimsBonus(cacheModel.NoClaimsBonus);
            }
        }

        public void VerifyNoClaimsBonus(NoClaimsBonus NoClaimsBonus)
        {
            CheckAssertData(TextDdlYearsOfNCB, NoClaimsBonus.yearsOfNCB, TypeFormControl.DropDownList);
            if (CheckElementExists(btnBtnHaveOwnedMotorcycle_Y) == true)
            {
                if (NoClaimsBonus.haveOwnedAMotorcycle.Equals("Yes"))
                {
                    CheckAssertData(btnBtnHaveOwnedMotorcycle_Y, "", TypeFormControl.BtnYesNo);
                    CheckAssertData(txtDdlStyleOfMotorcycle, NoClaimsBonus.styleOfMotorcycle, TypeFormControl.DropDownList);
                    CheckAssertData(txtTxtEngineSizeOfMotorcycle, NoClaimsBonus.engineSizeOfMotorcycle, TypeFormControl.Input);
                    CheckAssertData(txtDdlYearOfManufactureTheMotorcycle, NoClaimsBonus.yearOfManufactureTheMotorcycle, TypeFormControl.DropDownList);
                    CheckAssertData(txtDdlQuantityYearsOwnTheMotorcycle, NoClaimsBonus.quantityYearsOwnTheMotorcycle, TypeFormControl.DropDownList);
                    CheckAssertData(txtDdlQuantityYearsNCBHaveOnMotorcycle, NoClaimsBonus.quantityYearsNCBHaveOnMotorcycle, TypeFormControl.DropDownList);
                    CheckAssertData(txtDdlTimeLastRideTheMotorcycle, NoClaimsBonus.timeLastRideTheMotorcycle, TypeFormControl.DropDownList);
                }
                else
                {
                    CheckAssertData(btnBtnHaveOwnedMotorcycle_N, "", TypeFormControl.BtnYesNo);
                }
            }

        }
        public void VerifyDataClaims(List<Claim> Claims)
        {
            if (Claims.Count > 0)
            {
                CheckAssertData(btnBtnHasClaim_Y, "", TypeFormControl.BtnYesNo);
                for (int i = 0; i < Claims.Count; i++)
                {
                    OpenEditClaim(i);
                    Thread.Sleep(1000);
                    CheckDetailClaim(Claims[i]);
                }
            }
        }

        public void VerifyDataConviction(List<Conviction> Convictions)
        {
            if (Convictions.Count > 0)
            {
                CheckAssertData(btnBtnHasConviction_Y, "", TypeFormControl.BtnYesNo);
                for (int i = 0; i < Convictions.Count; i++)
                {
                    OpenEditConviction(i);
                    Thread.Sleep(1000);
                    CheckDetailConviction(Convictions[i]);
                }
            }
        }

        public void OpenEditClaim(int index)
        {
            if (CheckElementExists(By.Id($"editClaim_{index + 1}")))
            {
                Click(By.Id($"editClaim_{index + 1}"));
            }
        }

        public void OpenEditConviction(int index)
        {
            if (CheckElementExists(By.Id($"editConviction_{index + 1}")))
            {
                Click(By.Id($"editConviction_{index + 1}"));
            }
        }
        public void CheckDetailConviction(Conviction Conviction)
        {
            Assert.True(IsElementDisplayed(txtAutonetDateInputDay_ConvictionDate));
            if (!String.IsNullOrEmpty(Conviction.convictionDate))
            {
                var dataFormDate = getTextFromInput(txtAutonetDateInputDay_ConvictionDate)
                    + "/" + getTextFromInput(txtAutonetDateInputMonth_ConvictionDate)
                    + "/" + getTextFromInput(txtAutonetDateInputYear_ConvictionDate);
                Assert.True(dataFormDate.Equals(Conviction.convictionDate, StringComparison.CurrentCultureIgnoreCase));

            }
            CheckAssertData(TextOffenceType, Conviction.convictionCause, TypeFormControl.DropDownList);
            CheckAssertData(txtPoints, Conviction.penaltyPoints, TypeFormControl.Input);
            if (Conviction.isFineControl.Equals("Yes"))
            {
                CheckAssertData(btnIsFines_Y, "", TypeFormControl.BtnYesNo);
                CheckAssertData(txtFine, Conviction.valueOfFine, TypeFormControl.Input);
            }
            else
            {
                CheckAssertData(btnIsFines_N, "", TypeFormControl.BtnYesNo);
            }
            if (Conviction.isBannedControl.Equals("Yes"))
            {
                CheckAssertData(btnIsBanned_Y, "", TypeFormControl.BtnYesNo);
                CheckAssertData(txtBanLength, Conviction.numberOfMonth, TypeFormControl.Input);
            }
            else
            {
                CheckAssertData(btnIsBanned_N, "", TypeFormControl.BtnYesNo);
            }
            Click(btnBtnCancelSaveConviction);
        }

        public void CheckDetailClaim(Claim Claim)
        {
            if (!String.IsNullOrEmpty(Claim.claimDate))
            {
                var dataFormDate = getTextFromInput(txtAutonetDateInputDay_ClaimDate)
                    + "/" + getTextFromInput(txtAutonetDateInputMonth_ClaimDate)
                    + "/" + getTextFromInput(txtAutonetDateInputYear_ClaimDate);
                Assert.True(dataFormDate.Equals(Claim.claimDate, StringComparison.CurrentCultureIgnoreCase));
            }
            CheckAssertData(TextClaimType, Claim.claimCause, TypeFormControl.DropDownList);
            CheckAssertData(txtOwnDamageCost, Claim.totalEstimatedCost, TypeFormControl.Input);
            if (Claim.claimBonusAffected.Equals("Yes"))
            {
                CheckAssertData(btnFault_Y, "", TypeFormControl.BtnYesNo);
            }
            else
            {
                CheckAssertData(btnFault_N, "", TypeFormControl.BtnYesNo);
            }
            Click(btnBtnCancelSaveClaim);
        }
        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(1000);
                Assert.True(IsElementDisplayed(pageTitle));
                var cacheData = getCookie();
                if (String.IsNullOrEmpty(cacheData.WebReference))
                {
                    cacheData.WebReference = GetWebReference();
                    addCookie(cacheData);
                }
            }
        }

        public void ClickBtnYourMotorcycle(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnYourMotorcycle);
            }
        }

        public void ClickAddAnotherConviction(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnAddAnotherConviction);
                Conviction = new Conviction();
            }
        }
        public void ClickAddAnotherClaim(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnAddAnotherClaim);
                Claim = new Claim();
            }
        }
        public void SaveClaimList()
        {
            ClaimList.Add(Claim);
        }
        public void SaveConvictionList()
        {
            ConvictionList.Add(Conviction);
        }
        public void VerifyDeleteConviction1NotDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(!IsElementDisplayed(btnDeleteConviction_1));
            }
        }

        public void VerifyDeleteClaim1NotDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(!IsElementDisplayed(btnDeleteClaim_1));
            }
        }

        public void ClickRiderHistoryConviction(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    Click(btnRiderHistory_Conviction_Y);
                }
                else
                {
                    Click(btnRiderHistory_Conviction_N);
                }
            }
        }

        public void ClickDeleteConviction1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnDeleteConviction_1);
            }
        }

        public void ClickRiderHistoryClaim(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    Click(btnRiderHistory_Claim_Y);
                }
                else
                {
                    Click(btnRiderHistory_Claim_N);
                }
            }
        }

        public void ClickDeleteClaim1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnDeleteClaim_1);
            }
        }

        public void SaveDataRiderHistory()
        {
            var cacheModel = getCookie();
            cacheModel.Claims = ClaimList;
            cacheModel.Convictions = ConvictionList;
            cacheModel.NoClaimsBonus = NoClaimsBonus;
            addCookie(cacheModel);
        }
        public void ClickBtnRiderHistoryContinue(string input)
        {
            if (input.Equals("Required"))
            {
                SaveDataRiderHistory();
                Thread.Sleep(1000);
                //_driver.FindElement(btnBtnRiderHistory_Continue).Click();
                ClickByJavascript(btnBtnRiderHistory_Continue);
                WaitForLoadingIconDisappear();
                //Thread.Sleep(2000);
                int count = _driver.FindElements(ddAboutYourVehicleUseOfVehicle).Count;
                if (count == 0)
                {
                    Click(btnBtnRiderHistory_Continue);
                    WaitForLoadingIconDisappear();
                }
                WaitUntilElementExists(ddAboutYourVehicleUseOfVehicle);
            }
        }
        public void SelectDdlTimeLastRideTheMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.timeLastRideTheMotorcycle = input;

                Click(ddlDdlTimeLastRideTheMotorcycle);
                Click(By.XPath("//*[@id='ddlTimeLastRideTheMotorcycle']//span[text() = '" + input + "']"));
            }
        }

        public void SelectDdlQuantityYearsNCBHaveOnMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.quantityYearsNCBHaveOnMotorcycle = input;

                Click(ddlDdlQuantityYearsNCBHaveOnMotorcycle);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }
        //
        public void SelectDdlQuantityYearsOwnTheMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.quantityYearsOwnTheMotorcycle = input;
                ScrollToElement(ddlDdlQuantityYearsOwnTheMotorcycle);
                Click(ddlDdlQuantityYearsOwnTheMotorcycle);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectDdlYearOfManufactureTheMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.yearOfManufactureTheMotorcycle = input;

                Click(ddlDdlYearOfManufactureTheMotorcycle);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void InputTxtEngineSizeOfMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.engineSizeOfMotorcycle = input;
                WaitUntilTextboxAvailable(txtTxtEngineSizeOfMotorcycle, 10);
                TypeInElement(txtTxtEngineSizeOfMotorcycle, input);
            }
        }

        public void SelectDdlStyleOfMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.styleOfMotorcycle = input;
                Click(ddlDdlStyleOfMotorcycle);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void ClickBtnHaveOwnedMotorcycle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.haveOwnedAMotorcycle = input;
                if (input.Equals("Yes"))
                {
                    Click(btnBtnHaveOwnedMotorcycle_Y);
                }
                else
                {
                    Click(btnBtnHaveOwnedMotorcycle_N);
                }
            }
        }

        public void SelectDdlYearsOfNCB(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NoClaimsBonus.yearsOfNCB = input;
                Click(ddlDdlYearsOfNCB);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }


        public void ClickBtnSaveConviction(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                SaveConvictionList();
                Click(btnBtnSaveConviction);
            }
        }

        public void InputBanLength(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(txtFine);
                Thread.Sleep(500);
                Conviction.numberOfMonth = input;
                TypeInElement(txtBanLength, input);
            }
        }

        public void ClickIsBanned(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Conviction.isBannedControl = input;

                if (input.Equals("Yes"))
                {
                    Click(btnIsBanned_Y);
                }
                else
                {
                    Click(btnIsBanned_N);
                }
            }
        }

        public void InputFine(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(txtFine);
                Thread.Sleep(500);
                Conviction.valueOfFine = input;
                TypeInElement(txtFine, input);
            }
        }

        public void ClickIsFine(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Conviction.isFineControl = input;
                if (input.Equals("Yes"))
                {
                    Click(btnIsFines_Y);
                }
                else
                {
                    Click(btnIsFines_N);
                }
            }
        }

        public void InputPoints(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Conviction.penaltyPoints = input;
                TypeInElement(txtPoints, input);
            }
        }
        public void InputOffenceType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Conviction.convictionCause = input;
                TypeInElement(txtOffenceType, input);
                WaitUntilElementExists(btnOffenceType);
                Click(btnOffenceType);
            }
        }

        public void InputConvictionDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Conviction.convictionDate = input;
                String[] strlist = input.Split('/', 3);
                TypeInElement(txtAutonetDateInputDay_ConvictionDate, strlist[0]);
                TypeInElement(txtAutonetDateInputMonth_ConvictionDate, strlist[1]);
                TypeInElement(txtAutonetDateInputYear_ConvictionDate, strlist[2]);
            }
        }

        public void SelectDdlConvictionRiderName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Conviction.convictionRiderName = input;
                Click(ddlDdlConvictionRiderName);
                var option = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(option);
                Click(option);
            }
        }

        public void ClickBtnHasConviction(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    Click(btnBtnHasConviction_Y);
                }
                else
                {
                    Click(btnBtnHasConviction_N);
                }
            }
        }

        public void ClickBtnSaveClaim(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                SaveClaimList();
                Click(btnBtnSaveClaim);
            }
        }

        public void ClickFault(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Claim.claimBonusAffected = input;
                if (input.Equals("Yes"))
                {
                    Click(btnFault_Y);
                }
                else
                {
                    Click(btnFault_N);
                }
            }
        }

        public void InputOwnDamageCost(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Claim.totalEstimatedCost = input;
                TypeInElement(txtOwnDamageCost, input);
            }
        }

        public void InputClaimType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Claim.claimCause = input;

                TypeInElement(txtClaimType, input);
                WaitUntilElementExists(btnClaimType);
                Click(btnClaimType);
            }
        }

        public void InputClaimDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {

                Claim.claimDate = input;

                String[] strlist = input.Split('/', 3);
                TypeInElement(txtAutonetDateInputDay_ClaimDate, strlist[0]);
                TypeInElement(txtAutonetDateInputMonth_ClaimDate, strlist[1]);
                TypeInElement(txtAutonetDateInputYear_ClaimDate, strlist[2]);
            }

        }

        public void SelectDdlClaimRiderName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Claim.riderName = input;
                Click(ddlDdlClaimRiderName);
                Click(By.XPath("//span[text() = '" + input + "']"));
            }
        }

        public void ClickBtnHasClaim(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnBtnHasClaim_Y);
            }
            else
            {
                Click(btnBtnHasClaim_N);
            }
        }
    }
}
