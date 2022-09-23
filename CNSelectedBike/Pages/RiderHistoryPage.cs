using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class RiderHistoryPage : BasePage
    {
        private By pageTitle = By.XPath("//h2[text()='Rider History']");
        public Button btnBack = new Button(By.Id("HistoryPageBack"));
        public Button btnCoreClaimMultiDriversYes = new Button(By.Id("CoreClaimMultiDriversYes"));
        public Button btnCoreClaimMultiDriversNo = new Button(By.Id("CoreClaimMultiDriversNo"));
        public Button btnCoreClaimOneDriverYes = new Button(By.Id("CoreClaimOneDriverYes"));
        public Button btnCoreClaimOneDriverNo = new Button(By.Id("CoreClaimOneDriverNo"));

        Combobox cbClaimCustomer1 = new Combobox(By.Id("ClaimCustomer1"));
        Textbox txtDateInputDay_ClaimDate1 = new Textbox(By.Id("ClaimDay1"));
        Textbox txtDateInputMonth_ClaimDate1 = new Textbox(By.Id("ClaimMonth1"));
        Textbox txtDateInputYear_ClaimDate1 = new Textbox(By.Id("ClaimYear1"));
        Combobox cbClaimType1 = new Combobox(By.Id("ClaimType1"));
        Textbox txtTotalClaimCost1 = new Textbox(By.Id("TotalClaimCost1"));
        public Button btnNCBAffectedYes1 = new Button(By.Id("NCBAffectedYes1"));
        public Button btnNCBAffectedNo1 = new Button(By.Id("NCBAffectedNo1"));
        public Button btnSaveClaim = new Button(By.Id("SaveClaim"));
        public Button btnEditClaim1 = new Button(By.Id("EditClaim1"));

        //Convictions
        public Button btnCoreConvictionMultiDriversYes = new Button(By.Id("CoreConvictionMultiDriversYes"));
        public Button btnCoreConvictionMultiDriversNo = new Button(By.Id("CoreConvictionMultiDriversNo"));
        public Button btnCoreConvictionOneDriverYes = new Button(By.Id("CoreConvictionOneDriverYes"));
        public Button btnCoreConvictionOneDriverNo = new Button(By.Id("CoreConvictionOneDriverNo"));

        Combobox cbConvictionCustomer1 = new Combobox(By.Id("ConvictionCustomer1"));
        Textbox txtConvictionDay1 = new Textbox(By.Id("ConvictionDay1"));
        Textbox txtConvictionMonth1 = new Textbox(By.Id("ConvictionMonth1"));
        Textbox txtConvictionYear1 = new Textbox(By.Id("ConvictionYear1"));
        Combobox cbConvictionCode1 = new Combobox(By.Id("ConvictionCode1"));
        Textbox txtPenaltyPoints1 = new Textbox(By.Id("PenaltyPoints1"));
        public Button btnWasFinedYes1 = new Button(By.Id("WasFinedYes1"));
        public Button btnWasFinedNo1 = new Button(By.Id("WasFinedNo1"));
        Textbox txtFineValue1 = new Textbox(By.Id("FineValue1"));
        Combobox cbDrinkReading1 = new Combobox(By.Id("DrinkReading1"));
        Textbox txtDrinkDriveReadingLevel1 = new Textbox(By.Id("DrinkDriveReadingLevel1"));
        public Button btnWasDriverBannedYes1 = new Button(By.Id("WasDriverBannedYes1"));
        public Button btnWasDriverBannedNo1 = new Button(By.Id("WasDriverBannedNo1"));
        Textbox txtBanMonths1 = new Textbox(By.Id("BanMonths1"));
        public Button btnSaveConviction = new Button(By.Id("SaveConviction"));
        Combobox cbNCBYears = new Combobox(By.XPath("//ng-select[@id='NCBYears']"));
        public Button btnHistoryPageContinue = new Button(By.Id("HistoryPageContinue"));
        public Button btnEditConviction1 = new Button(By.Id("EditConviction1"));
        public Button btnWereYouBannedYes1 = new Button(By.Id("WereYouBannedYes1"));
        public Button btnWereYouBannedNo1 = new Button(By.Id("WereYouBannedNo1"));


        #region Claim
        public void ClickCoreClaimMultiDrivers(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreClaimMultiDriversYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreClaimMultiDriversNo.Click();
            }
        }

        public void ClickCoreClaimOneDriver(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreClaimOneDriverYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreClaimOneDriverNo.Click();
            }
        }
        public void SelectClaimCustomer1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimCustomer1.SelectByText(input);
            }
        }
        public void InputDateOfClaim1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtDateInputDay_ClaimDate1.Input(splittedDate.Item1);
                txtDateInputMonth_ClaimDate1.Input(splittedDate.Item2);
                txtDateInputYear_ClaimDate1.Input(splittedDate.Item3);
            }
        }
        public void SelectClaimType1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimType1.Input(input);
            }
        }
        public void InputTotalClaimCost1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtTotalClaimCost1.Input(input);
            }
        }
        public void ClickNCBAffectedYes(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnNCBAffectedYes1.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnNCBAffectedNo1.Click();
            }
        }
        public void ClickSaveClaimButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnSaveClaim.Click();
            }
        }
        public void ClickEditClaim1Button(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEditClaim1.Click();
            }
        }
        #endregion
        #region Conviction
        public void ClickCoreConvictionMultiDrivers(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreConvictionMultiDriversYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreConvictionMultiDriversNo.Click();
            }
        }
        public void ClickCoreConvictionOneDriver(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreConvictionOneDriverYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnCoreConvictionOneDriverNo.Click();
            }
        }
        public void SelectConvictionCustomer1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCustomer1.SelectByText(input);
            }
        }
        public void InputDateOfConviction1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtConvictionDay1.Input(splittedDate.Item1);
                txtConvictionMonth1.Input(splittedDate.Item2);
                txtConvictionYear1.Input(splittedDate.Item3);
            }
        }
        public void SelectConvictionTypeAndCode1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCode1.Input(input);
            }
        }

        public void InputPenaltyPoints1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtPenaltyPoints1.Input(input);
            }
        }
        public void ClickWasFined1(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnWasFinedYes1.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnWasFinedNo1.Click();
            }
        }
        public void InputFineValue1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFineValue1.Input(input);
            }
        }
        public void SelectDrinkReading1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbDrinkReading1.SelectByText(input);
            }
        }
        public void InputDrinkDriveReadingLevel1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtDrinkDriveReadingLevel1.Input(input);
            }
        }
        public void ClickWasRiverBanned1(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnWasDriverBannedYes1.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnWasDriverBannedNo1.Click();
            }
        }
        public void ClickWereYouBanned1(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnWereYouBannedYes1.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnWereYouBannedNo1.Click();
            }
        }
        public void InputBanMonths1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBanMonths1.Input(input);
            }
        }
        public void ClickSaveConvictionButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnSaveConviction.Click();
            }
        }
        public void SelectNCBYears(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var ls = _driver.FindElements(By.XPath("//ng-select[@id='NCBYears']"));
                cbNCBYears.SelectByText(input);
            }
        }
        public void ClickEditConviction1Button(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEditConviction1.Click();
            }
        }


        #endregion

        public void VerifyRiderHistoryPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(pageTitle);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void ClickBackButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnBack.Click();
                Thread.Sleep(1000);
                ClickContinueOnTrialPage();
            }
        }

        public void ClickRiderHistoryContinueButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnHistoryPageContinue.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(2000);
                ClickContinueOnTrialPage();

            }
        }

        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _riderHistoryData = new GuiModelData.RiderHistoryData();
                ClickEditClaim1Button("Yes");
                ClickEditConviction1Button("Yes");
               // _riderHistoryData.ClaimCustomer1 = cbClaimCustomer1?.GetText();
                _riderHistoryData.ClaimType1 = cbClaimType1?.GetText();
                _riderHistoryData.DateInputDay_ClaimDate1 = txtDateInputDay_ClaimDate1?.GetPopulatedValue();
                _riderHistoryData.DateInputMonth_ClaimDate1 = txtDateInputMonth_ClaimDate1?.GetPopulatedValue();
                _riderHistoryData.DateInputYear_ClaimDate1 = txtDateInputYear_ClaimDate1?.GetPopulatedValue();
                //_riderHistoryData.ConvictionCustomer1 = cbConvictionCustomer1.GetText();
                _riderHistoryData.ConvictionDay1 = txtConvictionDay1?.GetPopulatedValue();
                _riderHistoryData.ConvictionMonth1 = txtConvictionMonth1?.GetPopulatedValue();
                _riderHistoryData.ConvictionYear1 = txtConvictionYear1?.GetPopulatedValue();
                _riderHistoryData.ConvictionCode1 = cbConvictionCode1?.GetText();
                ClickSaveClaimButton("Yes");
                ClickSaveConvictionButton("Yes");
            }

        }

        public void VerifyAllDataDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                ClickEditClaim1Button("Yes");
                ClickEditConviction1Button("Yes");
                Assert.Equal(_riderHistoryData.ClaimType1 , cbClaimType1?.GetText());
                Assert.Equal(_riderHistoryData.DateInputDay_ClaimDate1 , txtDateInputDay_ClaimDate1?.GetPopulatedValue());
                Assert.Equal(_riderHistoryData.DateInputMonth_ClaimDate1 , txtDateInputMonth_ClaimDate1?.GetPopulatedValue());
                Assert.Equal(_riderHistoryData.DateInputYear_ClaimDate1 , txtDateInputYear_ClaimDate1?.GetPopulatedValue());
                Assert.Equal(_riderHistoryData.ConvictionDay1 , txtConvictionDay1?.GetPopulatedValue());
                Assert.Equal(_riderHistoryData.ConvictionMonth1 , txtConvictionMonth1?.GetPopulatedValue());
                Assert.Equal(_riderHistoryData.ConvictionYear1 , txtConvictionYear1?.GetPopulatedValue());
                Assert.Equal(_riderHistoryData.ConvictionCode1 , cbConvictionCode1.GetText());
                ClickSaveClaimButton("Yes");
                ClickSaveConvictionButton("Yes");
            }
        }
    }
}
