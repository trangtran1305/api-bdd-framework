using ANCarClassic.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace ANCarClassic.Pages
{
    public class HistoryPage : BasePage
    {
        //Claim
        public static By claimSubHeading = By.Id("ClaimSubHeading");
        private static string cbClaimCustomer1Id = "ClaimCustomer1";
        private static string txtClaimDay1Id = "DateInputDay_ClaimDate1";
        private static string txtClaimMonth1Id = "DateInputMonth_ClaimDate1";
        private static string txtClaimYear1Id = "DateInputYear_ClaimDate1";
        private static string cbClaimType1Id = "ClaimType1";
        private static string txtClaimCost1Id = "TotalClaimCost1";

        private static By cbClaimCustomer1Selector = By.Id(cbClaimCustomer1Id);
        private static By txtClaimDay1Selector = By.Id(txtClaimDay1Id);
        private static By txtClaimMonth1Selector = By.Id(txtClaimMonth1Id);
        private static By txtClaimYear1Selector = By.Id(txtClaimYear1Id);
        private static By cbClaimType1Selector = By.Id(cbClaimType1Id);
        private static By txtTotalClaimCost1Selector = By.Id("TotalClaimCost1");
        private static By btnNCBAffectedYes1Selector = By.Id("NCBAffectedYes1");
        private static By btnNCBAffectedNo1Selector = By.Id("NCBAffectedNo1");

        private static By btnCoreClaimOneDriverYesSelector = By.Id("CoreClaimOneDriverYes");
        private Button btnCoreClaimOneDriverYes = new Button(btnCoreClaimOneDriverYesSelector);
        private Button btnCoreClaimOneDriverNo = new Button(By.Id("CoreClaimOneDriverNo"));
        private static By btnCoreClaimMultiDriverYesSelector = By.Id("CoreClaimMultiDriversYes");
        private Button btnCoreClaimMultiDriverYes = new Button(btnCoreClaimMultiDriverYesSelector);
        private Button btnCoreClaimMultiDriverNo = new Button(By.Id("CoreClaimMultiDriversNo"));
        private Combobox cbClaimCustomer1 = new Combobox(cbClaimCustomer1Selector);
        private Textbox txtClaimDay1 = new Textbox(txtClaimDay1Selector);
        private Textbox txtClaimMonth1 = new Textbox(txtClaimMonth1Selector);
        private Textbox txtClaimYear1 = new Textbox(txtClaimYear1Selector);
        private Combobox cbClaimType1 = new Combobox(cbClaimType1Selector);
        private Textbox txtTotalClaimCost1 = new Textbox(txtTotalClaimCost1Selector);
        private Button btnNCBAffectedYes1 = new Button(btnNCBAffectedYes1Selector);
        private Button btnNCBAffectedNo1 = new Button(btnNCBAffectedNo1Selector);

        private Combobox cbClaimCustomer2 = new Combobox(By.Id("ClaimCustomer2"));
        private Textbox txtClaimDay2 = new Textbox(By.Id("DateInputDay_ClaimDate2"));
        private Textbox txtClaimMonth2 = new Textbox(By.Id("DateInputMonth_ClaimDate2"));
        private Textbox txtClaimYear2 = new Textbox(By.Id("DateInputYear_ClaimDate2"));
        private Combobox cbClaimType2 = new Combobox(By.Id("ClaimType2"));
        private Textbox txtTotalClaimCost2 = new Textbox(By.Id("TotalClaimCost2"));
        private Button btnNCBAffectedYes2 = new Button(By.Id("NCBAffectedYes2"));
        private Button btnNCBAffectedNo2 = new Button(By.Id("NCBAffectedNo2"));
        private Combobox cbClaimCustomer3 = new Combobox(By.Id("ClaimCustomer3"));
        private Textbox txtClaimDay3 = new Textbox(By.Id("DateInputDay_ClaimDate3"));
        private Textbox txtClaimMonth3 = new Textbox(By.Id("DateInputMonth_ClaimDate3"));
        private Textbox txtClaimYear3 = new Textbox(By.Id("DateInputYear_ClaimDate3"));
        private Combobox cbClaimType3 = new Combobox(By.Id("ClaimType3"));
        private Textbox txtTotalClaimCost3 = new Textbox(By.Id("TotalClaimCost3"));
        private Button btnNCBAffectedYes3 = new Button(By.Id("NCBAffectedYes3"));
        private Button btnNCBAffectedNo3 = new Button(By.Id("NCBAffectedNo3"));
        private Combobox cbClaimCustomer4 = new Combobox(By.Id("ClaimCustomer4"));
        private Textbox txtClaimDay4 = new Textbox(By.Id("DateInputDay_ClaimDate4"));
        private Textbox txtClaimMonth4 = new Textbox(By.Id("DateInputMonth_ClaimDate4"));
        private Textbox txtClaimYear4 = new Textbox(By.Id("DateInputYear_ClaimDate4"));
        private Combobox cbClaimType4 = new Combobox(By.Id("ClaimType4"));
        private Textbox txtTotalClaimCost4 = new Textbox(By.Id("TotalClaimCost4"));
        private Button btnNCBAffectedYes4 = new Button(By.Id("NCBAffectedYes4"));
        private Button btnNCBAffectedNo4 = new Button(By.Id("NCBAffectedNo4"));
        private Combobox cbClaimCustomer5 = new Combobox(By.Id("ClaimCustomer5"));
        private Textbox txtClaimDay5 = new Textbox(By.Id("DateInputDay_ClaimDate5"));
        private Textbox txtClaimMonth5 = new Textbox(By.Id("DateInputMonth_ClaimDate5"));
        private Textbox txtClaimYear5 = new Textbox(By.Id("DateInputYear_ClaimDate5"));
        private Combobox cbClaimType5 = new Combobox(By.Id("ClaimType5"));
        private Textbox txtTotalClaimCost5 = new Textbox(By.Id("TotalClaimCost5"));
        private Button btnNCBAffectedYes5 = new Button(By.Id("NCBAffectedYes5"));
        private Button btnNCBAffectedNo5 = new Button(By.Id("NCBAffectedNo5"));

        private static string firstClaimSummaryXpath = "//*[@itemname='Claim']/div[1]";
        private static By firstClaimSummary = By.XPath(firstClaimSummaryXpath);
        private Label firstClaimSummaryTitle = new Label(By.XPath(firstClaimSummaryXpath + "//p[1]"));
        private Label firstClaimSummaryDriver = new Label(By.XPath(firstClaimSummaryXpath + "//p[2]"));
        private Label firstClaimSummaryDate = new Label(By.XPath(firstClaimSummaryXpath + "//p[3]"));
        private Label firstClaimSummaryCause = new Label(By.XPath(firstClaimSummaryXpath + "//p[4]"));
        private Button btnFirstClaimSummaryEdit = new Button(By.Id("EditClaim1"));
        private Button btnFirstClaimSummaryRemove = new Button(By.Id("RemoveClaim1"));
        private static By btnSecondClaimSummaryEditSelector = By.Id("EditClaim2");
        private Button btnSecondClaimSummaryEdit = new Button(btnSecondClaimSummaryEditSelector);
        private Button btnSecondClaimSummaryRemove = new Button(By.Id("RemoveClaim2"));

        private static By btnAddAnotherClaimSelector = By.Id("AddClaim");
        private Button btnAddAnotherClaim = new Button(btnAddAnotherClaimSelector);

        private static By btnSaveClaimSelector = By.Id("SaveClaim");
        private Button btnSaveClaim = new Button(btnSaveClaimSelector);
        private Button btnCancelClaim = new Button(By.Id("CancelClaim"));

        private Button btnClaimContinueNextStep = new Button(By.Id("ClaimContinueNextStep"));

        // Conviction
        private Button btnCoreConvictionOneDriverYes = new Button(By.Id("CoreConvictionOneDriverYes"));
        private Button btnCoreConvictionOneDriverNo = new Button(By.Id("CoreConvictionOneDriverNo"));
        private Button btnCoreConvictionMultiDriverYes = new Button(By.Id("CoreConvictionMultiDriversYes"));
        private Button btnCoreConvictionMultiDriverNo = new Button(By.Id("CoreConvictionMultiDriversNo"));
        private Button btnConvictionContinueNextStep = new Button(By.Id("ConvictionContinueNextStep"));

        private static string cbConvictionCustomer1Id = "ConvictionCustomer1";
        private static string txtConvictionDay1Id = "DateInputDay_ConvictionDate1";
        private static string txtConvictionMonth1Id = "DateInputMonth_ConvictionDate1";
        private static string txtConvictionYear1Id = "DateInputYear_ConvictionDate1";
        private static string cbConvictionType1Id = "ConvictionCode1";
        private static string txtConvictionPenaltyPoint1Id = "PenaltyPoints1";
        private static string btnConvictionFineYes1Id = "WasFinedYes1";
        private static string txtConvictionFineAmount1Id = "FineValue1";
        private static string btnConvictionFineNo1Id = "WasFinedNo1";
        private static string btnConvictionBannedDriverYes1Id = "WasDriverBannedYes1";
        private static string txtConvictionBanMonth1Id = "BanMonths1";
        private static string btnConvictionBannedDriverNo1Id = "WasDriverBannedNo1";
        
        private static By cbConvictionCustomer1Selector = By.Id(cbConvictionCustomer1Id);
        private static By txtConvictionDay1Selector = By.Id(txtConvictionDay1Id);
        private static By txtConvictionMonth1Selector = By.Id(txtConvictionMonth1Id);
        private static By txtConvictionYear1Selector = By.Id(txtConvictionYear1Id);
        private static By cbConvictionType1Selector = By.Id(cbConvictionType1Id);
        private static By txtConvictionPenaltyPoint1Selector = By.Id(txtConvictionPenaltyPoint1Id);
        private static By btnConvictionFineYes1Selector = By.Id(btnConvictionFineYes1Id);
        private static By btnConvictionFineNo1Selector = By.Id(btnConvictionFineNo1Id);
        private static By btnConvictionBannedDriverYes1Selector = By.Id(btnConvictionBannedDriverYes1Id);
        private static By btnConvictionBannedDriverNo1Selector = By.Id(btnConvictionBannedDriverNo1Id);
        private Combobox cbConvictionCustomer1 = new Combobox(cbConvictionCustomer1Selector);
        private Textbox txtConvictionDay1 = new Textbox(txtConvictionDay1Selector);
        private Textbox txtConvictionMonth1 = new Textbox(txtConvictionMonth1Selector);
        private Textbox txtConvictionYear1 = new Textbox(txtConvictionYear1Selector);
        private Combobox cbConvictionType1 = new Combobox(cbConvictionType1Selector);
        private Textbox txtConvictionPenaltyPoint1 = new Textbox(txtConvictionPenaltyPoint1Selector);
        private Button btnConvictionFineYes1 = new Button(btnConvictionFineYes1Selector);
        private Button btnConvictionFineNo1 = new Button(btnConvictionFineNo1Selector);
        private Textbox txtFineValue1 = new Textbox(By.Id("FineValue1"));
        private Button btnConvictionBannedDriverYes1 = new Button(btnConvictionBannedDriverYes1Selector);
        private Textbox txtBanMonths1 = new Textbox(By.Id("BanMonths1"));
        private Button btnConvictionBannedDriverNo1 = new Button(btnConvictionBannedDriverNo1Selector);

        private Textbox txtBanMonths2 = new Textbox(By.Id("BanMonths2"));
        private Textbox txtFineValue2 = new Textbox(By.Id("FineValue2"));

        private Textbox txtBanMonths3 = new Textbox(By.Id("BanMonths3"));
        private Textbox txtFineValue3 = new Textbox(By.Id("FineValue3"));

        private Textbox txtBanMonths4 = new Textbox(By.Id("BanMonths4"));
        private Textbox txtFineValue4 = new Textbox(By.Id("FineValue4"));

        private Textbox txtBanMonths5 = new Textbox(By.Id("BanMonths5"));
        private Textbox txtFineValue5 = new Textbox(By.Id("FineValue5"));
        private static By btnSaveConvictionSelector = By.Id("SaveConviction");
        private Button btnSaveConviction = new Button(btnSaveConvictionSelector);
        private Button btnCancelConviction = new Button(By.Id("CancelConviction"));

        private Combobox cbConvictionCustomer2 = new Combobox(By.Id("ConvictionCustomer2"));
        private Textbox txtConvictionDay2 = new Textbox(By.Id("DateInputDay_ConvictionDate2"));
        private Textbox txtConvictionMonth2 = new Textbox(By.Id("DateInputMonth_ConvictionDate2"));
        private Textbox txtConvictionYear2 = new Textbox(By.Id("DateInputYear_ConvictionDate2"));
        private Combobox cbConvictionType2 = new Combobox(By.Id("ConvictionCode2"));
        private Textbox txtConvictionPenaltyPoint2 = new Textbox(By.Id("PenaltyPoints2"));
        private Button btnConvictionFineYes2 = new Button(By.Id("WasFinedYes2"));
        private Button btnConvictionFineNo2 = new Button(By.Id("WasFinedNo2"));
        private Button btnConvictionBannedDriverYes2 = new Button(By.Id("WasDriverBannedYes2"));
        private Button btnConvictionBannedDriverNo2 = new Button(By.Id("WasDriverBannedNo2"));
        private Combobox cbConvictionCustomer3 = new Combobox(By.Id("ConvictionCustomer3"));
        private Textbox txtConvictionDay3 = new Textbox(By.Id("DateInputDay_ConvictionDate3"));
        private Textbox txtConvictionMonth3 = new Textbox(By.Id("DateInputMonth_ConvictionDate3"));
        private Textbox txtConvictionYear3 = new Textbox(By.Id("DateInputYear_ConvictionDate3"));
        private Combobox cbConvictionType3 = new Combobox(By.Id("ConvictionCode3"));
        private Textbox txtConvictionPenaltyPoint3 = new Textbox(By.Id("PenaltyPoints3"));
        private Button btnConvictionFineYes3 = new Button(By.Id("WasFinedYes3"));
        private Button btnConvictionFineNo3 = new Button(By.Id("WasFinedNo3"));
        private Button btnConvictionBannedDriverYes3 = new Button(By.Id("WasDriverBannedYes3"));
        private Button btnConvictionBannedDriverNo3 = new Button(By.Id("WasDriverBannedNo3"));
        private Combobox cbConvictionCustomer4 = new Combobox(By.Id("ConvictionCustomer4"));
        private Textbox txtConvictionDay4 = new Textbox(By.Id("DateInputDay_ConvictionDate4"));
        private Textbox txtConvictionMonth4 = new Textbox(By.Id("DateInputMonth_ConvictionDate4"));
        private Textbox txtConvictionYear4 = new Textbox(By.Id("DateInputYear_ConvictionDate4"));
        private Combobox cbConvictionType4 = new Combobox(By.Id("ConvictionCode4"));
        private Textbox txtConvictionPenaltyPoint4 = new Textbox(By.Id("PenaltyPoints4"));
        private Button btnConvictionFineYes4 = new Button(By.Id("WasFinedYes4"));
        private Button btnConvictionFineNo4 = new Button(By.Id("WasFinedNo4"));
        private Button btnConvictionBannedDriverYes4 = new Button(By.Id("WasDriverBannedYes4"));
        private Button btnConvictionBannedDriverNo4 = new Button(By.Id("WasDriverBannedNo4"));
        private Combobox cbConvictionCustomer5 = new Combobox(By.Id("ConvictionCustomer5"));
        private Textbox txtConvictionDay5 = new Textbox(By.Id("DateInputDay_ConvictionDate5"));
        private Textbox txtConvictionMonth5 = new Textbox(By.Id("DateInputMonth_ConvictionDate5"));
        private Textbox txtConvictionYear5 = new Textbox(By.Id("DateInputYear_ConvictionDate5"));
        private Combobox cbConvictionType5 = new Combobox(By.Id("ConvictionCode5"));
        private Textbox txtConvictionPenaltyPoint5 = new Textbox(By.Id("PenaltyPoints5"));
        private Button btnConvictionFineYes5 = new Button(By.Id("WasFinedYes5"));
        private Button btnConvictionFineNo5 = new Button(By.Id("WasFinedNo5"));
        private Button btnConvictionBannedDriverYes5 = new Button(By.Id("WasDriverBannedYes5"));
        private Button btnConvictionBannedDriverNo5 = new Button(By.Id("WasDriverBannedNo5"));

        private static string firstConvictionSummaryXpath = "//*[@itemname='Conviction']/div[1]";
        private static By firstConvictionSummarySelector = By.XPath(firstConvictionSummaryXpath);
        private Label firstConvictionSummaryTitle = new Label(By.XPath(firstConvictionSummaryXpath + "//p[1]"));
        private Label firstConvictionSummaryDriver = new Label(By.XPath(firstConvictionSummaryXpath + "//p[2]"));
        private Label firstConvictionSummaryDate = new Label(By.XPath(firstConvictionSummaryXpath + "//p[3]"));
        private Label firstConvictionSummaryCause = new Label(By.XPath(firstConvictionSummaryXpath + "//p[4]"));
        private Button btnFirstConvictionSummaryEdit = new Button(By.Id("EditConviction1"));
        private Button btnFirstConvictionSummaryRemove = new Button(By.Id("RemoveConviction1"));

        private static By btnSecondConvictionSummaryEditSelector = By.Id("EditConviction2");
        private Button btnSecondConvictionSummaryEdit = new Button(btnSecondConvictionSummaryEditSelector);
        private Button btnSecondConvictionSummaryRemove = new Button(By.Id("RemoveConviction2"));
        private Button btnThirdConvictionSummaryRemove = new Button(By.Id("RemoveConviction3"));
        private Button btnFourthConvictionSummaryRemove = new Button(By.Id("RemoveConviction4"));
        private Button btnFifthConvictionSummaryRemove = new Button(By.Id("RemoveConviction5"));
        private Button btnRemoveConvictionConfirmYes = new Button(By.Id("ConvictionConfirmationMsgYes"));

        private static By btnAddAnotherConvictionSelector = By.Id("AddConviction");
        private Button btnAddAnotherConviction = new Button(btnAddAnotherConvictionSelector);

        private Combobox cbNCBYears = new Combobox(By.XPath("//ng-select[@id='NCBYears']"));
        private Button btnInsuranceRefusedNo = new Button(By.Id("InsuranceRefusedNo"));
        private Button btnInsuranceRefusedYes = new Button(By.Id("InsuranceRefusedYes"));
        private Combobox cbNumberOfVehicleInHousehold = new Combobox(By.XPath("//ng-select[@id='NumberOfVehicleInHousehold']"));
        private Button btnOtherVehicleNamedDriverYes = new Button(By.Id("OtherVehicleNamedDriverYes"));
        private Button btnOtherVehicleNamedDriverNo = new Button(By.Id("OtherVehicleNamedDriverNo"));
        private Button btnOtherVehicleType1 = new Button(By.Id("VehicleType1"));
        private Button btnOtherVehicleType2 = new Button(By.Id("VehicleType2"));
        private Button btnOtherVehicleUseYes = new Button(By.Id("OtherVehicleUseYes"));
        private Button btnOtherVehicleUseNo = new Button(By.Id("OtherVehicleUseNo"));
        private Combobox cbLargestNcbInOtherVehicle = new Combobox(By.XPath("//ng-select[@id='LargestNcbInOtherVehicle']"));
        private Combobox cbClaimsFreeYearPrivateVehicle = new Combobox(By.XPath("//ng-select[@id='ClaimsFreeYearPrivateVehicle']"));
        private Combobox cbClaimsFreeYearCompanyVehicle = new Combobox(By.XPath("//ng-select[@id='ClaimsFreeYearCompanyVehicle']"));

        public static By btnHistoryPageContinueSelector = By.Id("HistoryPageContinue");
        private Button btnHistoryPageContinue = new Button(btnHistoryPageContinueSelector);
        private static By btnHistoryPageBackSelector = By.Id("HistoryPageBack");
        private Button btnHistoryPageBack = new Button(btnHistoryPageBackSelector);
        private Button btnProgressBarDriverHistory = new Button(By.Id("ProgressBarDriverHistory"));

        private static string[,] claimsInfo = new string[5, 5];
        private static string[,] convictionsInfo = new string[5, 4];
        private static List<Claim> lstClaim = new List<Claim>();
        private static List<Conviction> lstConviction = new List<Conviction>();


        #region Claims
        public void ClickProgressBarDriverHistory(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProgressBarDriverHistory.Click();
            }
        }
        public void IsClaimsOrLossesOne(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(btnCoreClaimOneDriverYesSelector);
                btnCoreClaimOneDriverYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCoreClaimOneDriverNo.Click();
            }
        }
        public void IsClaimsOrLossesMulti(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(btnCoreClaimMultiDriverYesSelector);
                //Thread.Sleep(1000);
                btnCoreClaimMultiDriverYes.Click();
                WaitUntilElementVisible(cbClaimCustomer1Selector);
            }
            else if (input.Equals("No"))
            {
                btnCoreClaimMultiDriverNo.Click();
            }
        }
        public void ClickClaimContinueNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnClaimContinueNextStep.Click();
            }
        }
        public void SelectClaimCustomer1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimCustomer1.SelectByText(input);
            }
        }

        // hien 31/5 need to update name in excel file
        public void InputClaimDate1(string purchaseDate)
        {
            if (!String.IsNullOrEmpty(purchaseDate))
            {
                var splittedDate = _pageHelper.SplitDate(purchaseDate);
                txtClaimDay1.Clear();
                txtClaimDay1.Input(splittedDate.Item1);
                txtClaimMonth1.Clear();
                txtClaimMonth1.Input(splittedDate.Item2);
                txtClaimYear1.Clear();
                txtClaimYear1.Input(splittedDate.Item3);
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
                txtTotalClaimCost1.Clear();
                txtTotalClaimCost1.Input(input);
            }
        }
        public void ClickNCBAffected1(string input)
        {
            if (input.Equals("Yes"))
            {
                btnNCBAffectedYes1.Click();
            }
            else if (input.Equals("No"))
            {
                btnNCBAffectedNo1.Click();
            }
        }
        public void ClickSaveClaim(string input)
        {
            if (input.Equals("Yes"))
            {
                btnSaveClaim.Click();
                Thread.Sleep(1000);
            }
        }

        // hien
        public void SelectClaimCustomer2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimCustomer2.SelectByText(input);
            }
        }

        // hien 31/5 need to update name in excel file
        public void InputClaimDate2(string purchaseDate)
        {
            if (!String.IsNullOrEmpty(purchaseDate))
            {
                var splittedDate = _pageHelper.SplitDate(purchaseDate);
                txtClaimDay2.Input(splittedDate.Item1);
                txtClaimMonth2.Input(splittedDate.Item2);
                txtClaimYear2.Input(splittedDate.Item3);
            }
        }
        public void SelectClaimType2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimType2.Input(input);
            }
        }
        public void InputTotalClaimCost2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtTotalClaimCost2.Input(input);
            }
        }
        public void ClickNCBAffected2(string input)
        {
            if (input.Equals("Yes"))
            {
                btnNCBAffectedYes2.Click();
            }
            else if (input.Equals("No"))
            {
                btnNCBAffectedNo2.Click();
            }
        }
        public void SelectClaimCustomer3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimCustomer3.SelectByText(input);
            }
        }

        // hien 31/5 need to update name in excel file
        public void InputClaimDate3(string purchaseDate)
        {
            if (!String.IsNullOrEmpty(purchaseDate))
            {
                var splittedDate = _pageHelper.SplitDate(purchaseDate);
                txtClaimDay3.Input(splittedDate.Item1);
                txtClaimMonth3.Input(splittedDate.Item2);
                txtClaimYear3.Input(splittedDate.Item3);
            }
        }
        public void SelectClaimType3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimType3.Input(input);
            }
        }
        public void InputTotalClaimCost3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtTotalClaimCost3.Input(input);
            }
        }
        public void ClickNCBAffected3(string input)
        {
            if (input.Equals("Yes"))
            {
                btnNCBAffectedYes3.Click();
            }
            else if (input.Equals("No"))
            {
                btnNCBAffectedNo3.Click();
            }
        }
        public void SelectClaimCustomer4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimCustomer4.SelectByText(input);
            }
        }

        // hien 31/5 need to update name in excel file
        public void InputClaimDate4(string purchaseDate)
        {
            if (!String.IsNullOrEmpty(purchaseDate))
            {
                var splittedDate = _pageHelper.SplitDate(purchaseDate);
                txtClaimDay4.Input(splittedDate.Item1);
                txtClaimMonth4.Input(splittedDate.Item2);
                txtClaimYear4.Input(splittedDate.Item3);
            }
        }
        public void SelectClaimType4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimType4.Input(input);
            }
        }
        public void InputTotalClaimCost4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtTotalClaimCost4.Input(input);
            }
        }
        public void ClickNCBAffected4(string input)
        {
            if (input.Equals("Yes"))
            {
                btnNCBAffectedYes4.Click();
            }
            else if (input.Equals("No"))
            {
                btnNCBAffectedNo4.Click();
            }
        }
        public void SelectClaimCustomer5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimCustomer5.SelectByText(input);
            }
        }

        // hien 31/5 need to update name in excel file
        public void InputClaimDate5(string purchaseDate)
        {
            if (!String.IsNullOrEmpty(purchaseDate))
            {
                var splittedDate = _pageHelper.SplitDate(purchaseDate);
                txtClaimDay5.Input(splittedDate.Item1);
                txtClaimMonth5.Input(splittedDate.Item2);
                txtClaimYear5.Input(splittedDate.Item3);
            }
        }
        public void SelectClaimType5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbClaimType5.Input(input);
            }
        }
        public void InputTotalClaimCost5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtTotalClaimCost5.Input(input);
            }
        }
        public void ClickNCBAffected5(string input)
        {
            if (input.Equals("Yes"))
            {
                btnNCBAffectedYes5.Click();
            }
            else if (input.Equals("No"))
            {
                btnNCBAffectedNo5.Click();
            }
        }
        public void ClickEditFirstClaim(string input)
        {
            if (input.Equals("Yes"))
            {
                Thread.Sleep(1000);
                btnFirstClaimSummaryEdit.Click();
            }
        }
        
        public void ClickCancelClaim(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCancelClaim.Click();
            }

        }

        public void ClickAddAnotherClaim(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAddAnotherClaim.Click();
            }
        }

       
        #endregion

        #region Convictions
        public void DoYouHaveAnyUnspentMotorConvictionsOne(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCoreConvictionOneDriverYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCoreConvictionOneDriverNo.Click();
            }
        }
        public void DoYouHaveAnyUnspentMotorConvictionsMulti(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCoreConvictionMultiDriverYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnCoreConvictionMultiDriverNo.Click();
            }
        }
        public void SelectConvictionCustomer1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCustomer1.SelectByText(input);
            }
        }
        
        public void InputConvictionDate1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtConvictionDay1.Clear();
                txtConvictionDay1.Input(splittedDate.Item1);
                txtConvictionMonth1.Clear();
                txtConvictionMonth1.Input(splittedDate.Item2);
                txtConvictionYear1.Clear();
                txtConvictionYear1.Input(splittedDate.Item3);
            }
        }
        public void SelectConvictionCodeAndType1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionType1.Input(input);
            }
        }
        public void InputConvictionPenaltyPoint1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtConvictionPenaltyPoint1.Clear();
                txtConvictionPenaltyPoint1.Input(input);
            }
        }
        public void ClickConvictionFinedStatus1(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionFineYes1.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionFineNo1.Click();
            }
        }
        

        public void ClickConvictionBannedDriverStatus1(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionBannedDriverYes1.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionBannedDriverNo1.Click();
            }
        }
        public void InputConvictionFineValue1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFineValue1.Clear();
                txtFineValue1.Input(input);
            }
        }
        public void InputConvictionBannedMonth1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBanMonths1.Clear();
                txtBanMonths1.Input(input);
            }
        }
        public void ClickSaveConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnSaveConviction.Click();
            }
        }


        public void ClickEditFirstConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFirstConvictionSummaryEdit.Click();
            }
        }

        public void ClickRemoveFirstConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFirstConvictionSummaryRemove.Click();
                Thread.Sleep(500);
                btnRemoveConvictionConfirmYes.Click();
                Thread.Sleep(500);
            }
        }
        public void ClickRemoveSecondConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnSecondConvictionSummaryRemove.Click();
                Thread.Sleep(500);
                btnRemoveConvictionConfirmYes.Click();
                Thread.Sleep(500);
            }
        }
        public void ClickRemoveThirdConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnThirdConvictionSummaryRemove.Click();
                Thread.Sleep(500);
                btnRemoveConvictionConfirmYes.Click();
                Thread.Sleep(500);
            }
        }
        public void ClickRemoveFourthConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFourthConvictionSummaryRemove.Click();
                Thread.Sleep(500);
                btnRemoveConvictionConfirmYes.Click();
                Thread.Sleep(500);
            }
        }
        public void ClickRemoveFifthConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFifthConvictionSummaryRemove.Click();
                Thread.Sleep(500);
                btnRemoveConvictionConfirmYes.Click();
                Thread.Sleep(500);
            }
        }

        public void VerifyAllConvictionRemovedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementBehind(firstConvictionSummarySelector));
            }
        }

        public void ClickCancelConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCancelConviction.Click();
            }

        }

        public void ClickAddAnotherConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAddAnotherConviction.Click();
                //Thread.Sleep(500);
            }
        }
        public void SelectConvictionCustomer2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCustomer2.SelectByText(input);
            }
        }

        public void InputConvictionDate2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtConvictionDay2.Input(splittedDate.Item1);
                txtConvictionMonth2.Input(splittedDate.Item2);
                txtConvictionYear2.Input(splittedDate.Item3);
            }
        }
        public void SelectConvictionCodeAndType2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionType2.Input(input);
            }
        }
        public void InputConvictionPenaltyPoint2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtConvictionPenaltyPoint2.Input(input);
            }
        }
        public void ClickConvictionFinedStatus2(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionFineYes2.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionFineNo2.Click();
            }
        }


        public void ClickConvictionBannedDriverStatus2(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionBannedDriverYes2.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionBannedDriverNo2.Click();
            }
        }
        public void InputConvictionFineValue2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFineValue2.Clear();
                txtFineValue2.Input(input);
            }
        }
        public void InputConvictionBannedMonth2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBanMonths2.Clear();
                txtBanMonths2.Input(input);
            }
        }
        public void SelectConvictionCustomer3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCustomer3.SelectByText(input);
            }
        }

        public void InputConvictionDate3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtConvictionDay3.Input(splittedDate.Item1);
                txtConvictionMonth3.Input(splittedDate.Item2);
                txtConvictionYear3.Input(splittedDate.Item3);
            }
        }
        public void SelectConvictionCodeAndType3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionType3.Input(input);
            }
        }
        public void InputConvictionPenaltyPoint3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtConvictionPenaltyPoint3.Input(input);
            }
        }
        public void ClickConvictionFinedStatus3(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionFineYes3.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionFineNo3.Click();
            }
        }

        public void ClickConvictionBannedDriverStatus3(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionBannedDriverYes3.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionBannedDriverNo3.Click();
            }
        }
        public void InputConvictionFineValue3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFineValue3.Clear();
                txtFineValue3.Input(input);
            }
        }
        public void InputConvictionBannedMonth3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBanMonths3.Clear();
                txtBanMonths3.Input(input);
            }
        }

        public void SelectConvictionCustomer4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCustomer4.SelectByText(input);
            }
        }
        public void InputConvictionDate4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtConvictionDay4.Input(splittedDate.Item1);
                txtConvictionMonth4.Input(splittedDate.Item2);
                txtConvictionYear4.Input(splittedDate.Item3);
            }
        }
        public void SelectConvictionCodeAndType4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionType4.Input(input);
            }
        }
        public void InputConvictionPenaltyPoint4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtConvictionPenaltyPoint4.Input(input);
            }
        }
        public void ClickConvictionFinedStatus4(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionFineYes4.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionFineNo4.Click();
            }
        }

        public void ClickConvictionBannedDriverStatus4(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionBannedDriverYes4.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionBannedDriverNo4.Click();
            }
        }
        public void InputConvictionFineValue4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFineValue4.Clear();
                txtFineValue4.Input(input);
            }
        }
        public void InputConvictionBannedMonth4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBanMonths4.Clear();
                txtBanMonths4.Input(input);
            }
        }

        public void SelectConvictionCustomer5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionCustomer5.SelectByText(input);
            }
        }
        public void InputConvictionDate5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtConvictionDay5.Input(splittedDate.Item1);
                txtConvictionMonth5.Input(splittedDate.Item2);
                txtConvictionYear5.Input(splittedDate.Item3);
            }
        }
        public void SelectConvictionCodeAndType5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbConvictionType5.Input(input);
            }
        }
        public void InputConvictionPenaltyPoint5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtConvictionPenaltyPoint5.Input(input);
            }
        }
        public void ClickConvictionFinedStatus5(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionFineYes5.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionFineNo5.Click();
            }
        }

        public void ClickConvictionBannedDriverStatus5(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionBannedDriverYes5.Click();
            }
            else if (input.Equals("No"))
            {
                btnConvictionBannedDriverNo5.Click();
            }
        }
        public void InputConvictionFineValue5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFineValue5.Clear();
                txtFineValue5.Input(input);
            }
        }
        public void InputConvictionBannedMonth5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtBanMonths5.Clear();
                txtBanMonths5.Input(input);
            }
        }

        public void ClickConvictionContinueNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnConvictionContinueNextStep.Click();
            }
        }
        #endregion

        public void SelectNCBYears(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbNCBYears.SelectByText(input);
            }
        }
        public void SelectNumberOfVehicleInHousehold(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbNumberOfVehicleInHousehold.SelectByText(input);
            }
        }
        public void ClickInsuranceRefused(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    btnInsuranceRefusedYes.Click();
                }
                else if (input.Equals("No"))
                {
                    btnInsuranceRefusedNo.Click();
                }
            }

        }

        public void ClickOtherVehicleNamedDriver(string input)
        {
            if(!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    btnOtherVehicleNamedDriverYes.Click();
                }
                else if (input.Equals("No"))
                {
                    btnOtherVehicleNamedDriverNo.Click();
                }
            }
            
        }
        public void ClickOtherVehicleType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Private Car or van"))
                {
                    btnOtherVehicleType1.Click();
                }
                else if (input.Equals("Company car or van"))
                {
                    btnOtherVehicleType2.Click();
                }
            }
        }
        public void SelectClaimsFreeYear(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (btnOtherVehicleType1.GetAttributeValue("class").Equals("isActive"))
                {
                    cbClaimsFreeYearPrivateVehicle.SelectByText(input);
                }
                else if (btnOtherVehicleType2.GetAttributeValue("class").Equals("isActive"))
                {
                    cbClaimsFreeYearCompanyVehicle.SelectByText(input);
                }
            }
        }
        public void ClickOtherVehicleUse(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    btnOtherVehicleUseYes.Click();
                }
                else if (input.Equals("No"))
                {
                    btnOtherVehicleUseNo.Click();
                }
            }
        }
        public void SelectNcbInOtherVehicle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbLargestNcbInOtherVehicle.SelectByText(input);
            }
        }

        public void ClickHistoryPageContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnHistoryPageContinue.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
        public void ClickHistoryPageBack(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementVisible(btnHistoryPageBackSelector);
                btnHistoryPageBack.Click();
                WaitUntilElementVisible(DriversPage.btnContinueToHistorySelector);
            }
        }

        #region Verify page displayed
        public void VerifyHistoryPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(claimSubHeading);
                var elements = _driver.FindElements(claimSubHeading);
                bool isTrue = elements.Count > 0;
                Assert.True(isTrue);
            }
        }
        #endregion

        #region Verify Claim
        public void VerifyFirstClaimSummaryCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                string claimTitle = firstClaimSummaryTitle.GetAttributeValue("innerText");
                string claimDriver = firstClaimSummaryDriver.GetAttributeValue("innerText");
                string claimDate = firstClaimSummaryDate.GetAttributeValue("innerText");
                string claimCause = firstClaimSummaryCause.GetAttributeValue("innerText");
                Assert.Equal("Claim 1", claimTitle);
                var date = _driverHistoryData.FirstClaimDay + "/" 
                    + _driverHistoryData.FirstClaimMonth + "/" + _driverHistoryData.FirstClaimYear;
                Assert.Equal(_driverHistoryData.FirstClaimDriver, claimDriver);
                Assert.Equal(date, claimDate);
                Assert.Equal(_driverHistoryData.FirstClaimCause, claimCause);
            }

        }

        public void VerifyFirstClaimSectionCollapsed(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementBehind(cbClaimCustomer1Selector));
                Assert.True(IsElementBehind(txtClaimDay1Selector));
                Assert.True(IsElementBehind(txtClaimMonth1Selector));
                Assert.True(IsElementBehind(txtClaimYear1Selector));
                Assert.True(IsElementBehind(cbClaimType1Selector));
                Assert.True(IsElementBehind(txtTotalClaimCost1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedYes1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedNo1Selector));
                Assert.True(IsElementBehind(btnSaveClaimSelector));
            }
        }
        public void VerifyCancelClaimCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                Boolean isClaimActive = btnCoreClaimMultiDriverYes.GetAttributeValue("class").Equals("isActive") || btnCoreClaimMultiDriverNo.GetAttributeValue("class").Equals("isActive");
                Assert.False(isClaimActive);
                Assert.True(IsElementBehind(cbClaimCustomer1Selector));
                Assert.True(IsElementBehind(txtClaimDay1Selector));
                Assert.True(IsElementBehind(txtClaimMonth1Selector));
                Assert.True(IsElementBehind(txtClaimYear1Selector));
                Assert.True(IsElementBehind(cbClaimType1Selector));
                Assert.True(IsElementBehind(txtTotalClaimCost1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedYes1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedNo1Selector));
                Assert.True(IsElementBehind(btnSaveClaimSelector));
            }
        }
        public void SaveDataOfClaimByClaimNumber (string claimNumber)
        {
            if(!String.IsNullOrEmpty(claimNumber))
            {
                var editButton = _driver.FindElement(By.Id("EditClaim" + claimNumber));
                editButton.Click();
                var i = Convert.ToInt32(claimNumber);
                string claimCustomer = _driver.FindElement(By.Id(cbClaimCustomer1Id.Replace("1", (i).ToString()))).Text;
                string claimDay = _driver.FindElement(By.Id(txtClaimDay1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string claimMonth = _driver.FindElement(By.Id(txtClaimMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string claimYear = _driver.FindElement(By.Id(txtClaimYear1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string claimType = _driver.FindElement(By.Id(cbClaimType1Id.Replace("1", (i).ToString()))).Text.Replace("\r", "").Replace("\n", "").Replace("×", ""); 
                claimsInfo[i-1, 0] = "Claim " + (i).ToString();
                claimsInfo[i-1, 1] = claimCustomer;
                claimsInfo[i-1, 2] = claimDay + "/" + claimMonth + "/" + claimYear;
                claimsInfo[i-1, 3] = claimType;
                btnSaveClaim.Click();
            }
        }
        public void SaveDataOfClaimByClaimNumber2(string claimInfo)
        {
            if (!String.IsNullOrEmpty(claimInfo))
            {
                
                var claim = new Claim();
                var info = _pageHelper.SplitBy(claimInfo, ",");
                var claimNumber = info[0];
                var editButton = _driver.FindElement(By.Id("EditClaim" + claimNumber));
                editButton.Click();
                var i = Convert.ToInt32(claimNumber);
                string claimCustomer = _driver.FindElement(By.Id(cbClaimCustomer1Id.Replace("1", (i).ToString()))).Text;
                string claimDay = _driver.FindElement(By.Id(txtClaimDay1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string claimMonth = _driver.FindElement(By.Id(txtClaimMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string claimYear = _driver.FindElement(By.Id(txtClaimYear1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string claimType = _driver.FindElement(By.Id(cbClaimType1Id.Replace("1", (i).ToString()))).Text.Replace("\r", "").Replace("\n", "").Replace("×", "");
                string claimCost = _driver.FindElement(By.Id(txtClaimCost1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                claim.Driver = claimCustomer;
                claim.Day = claimDay;
                claim.Month = claimMonth;
                claim.Year = claimYear;
                claim.Cause = claimType;
                claim.Cost = claimCost;
                claim.isProposer = (info[1].Trim() == "Proposer") ? 1 : 0;
                btnSaveClaim.Click();
                lstClaim.Add(claim);
            }
        }
        public void SortClaims(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                lstClaim = lstClaim.OrderByDescending(o => o.isProposer).ToList();

            }
        }

        public void SortConvictions(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                lstConviction = lstConviction.OrderByDescending(o => o.isProposer).ToList();
            }
        }

        public void VerifyClaimsInfo(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                for (int i = 0; i < claimsInfo.GetLength(0); i ++)
                {
                    string claimSummaryXpath = $"//*[@itemname='Claim']/div[{i + 1}]";

                    string claimTitle = _driver.FindElement(By.XPath(claimSummaryXpath))
                        .FindElement(By.XPath(".//p[1]"))
                        .GetAttribute("innerText");
                    string claimCustomer = _driver.FindElement(By.XPath(claimSummaryXpath))
                        .FindElement(By.XPath(".//p[2]"))
                        .GetAttribute("innerText");
                    string claimDate = _driver.FindElement(By.XPath(claimSummaryXpath))
                        .FindElement(By.XPath(".//p[3]"))
                        .GetAttribute("innerText");
                    string claimType = _driver.FindElement(By.XPath(claimSummaryXpath))
                        .FindElement(By.XPath(".//p[4]"))
                        .GetAttribute("innerText");
                    Assert.Equal(claimsInfo[i, 0], claimTitle);
                    Assert.Equal(claimsInfo[i, 1], claimCustomer);
                    Assert.Equal(claimsInfo[i, 2], claimDate);
                    Assert.Equal(claimsInfo[i, 3], claimType);
                }                
            }
        }
        public void VerifyClaimsInfo2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                for (int i = 1; i < lstClaim.Count + 1; i++)
                {
                    var editButton = _driver.FindElement(By.Id("EditClaim" + (i).ToString()));
                    editButton.Click();
                    string claimCustomer = _driver.FindElement(By.Id(cbClaimCustomer1Id.Replace("1", (i).ToString()))).Text;
                    string claimDay = _driver.FindElement(By.Id(txtClaimDay1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    string claimMonth = _driver.FindElement(By.Id(txtClaimMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    string claimYear = _driver.FindElement(By.Id(txtClaimYear1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    string claimType = _driver.FindElement(By.Id(cbClaimType1Id.Replace("1", (i).ToString()))).Text.Replace("\r", "").Replace("\n", "").Replace("×", "");
                    string claimCost = _driver.FindElement(By.Id(txtClaimCost1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    Assert.Equal(lstClaim[i - 1].Driver, claimCustomer);
                    Assert.Equal(lstClaim[i - 1].Day, claimDay);
                    Assert.Equal(lstClaim[i - 1].Month, claimMonth);
                    Assert.Equal(lstClaim[i - 1].Year, claimYear);
                    Assert.Equal(lstClaim[i - 1].Cause, claimType);
                    Assert.Equal(lstClaim[i - 1].Cost, claimCost);                    
                    btnSaveClaim.Click();
                }
                lstClaim.Clear();
            }
        }

        public void VerifyCanNotAddOverMaxClaim(string input)
        {
            if(input.Equals("Yes"))
            {
                Assert.True(IsElementBehind(btnAddAnotherClaimSelector));
            }
        }
        #endregion

        #region Verify Conviction

        public void VerifyConvictionCustomerContainsAdditionalDriver(string addDriverName)
        {
            if (!String.IsNullOrEmpty(addDriverName))
            {
                cbConvictionCustomer1.SelectByText(addDriverName);
                string selectedItem = cbConvictionCustomer1.GetText();
                Assert.Equal(addDriverName, selectedItem);
            }
        }
        public void VerifyFirstConvictionSummaryCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                string ConvictionTitle = firstConvictionSummaryTitle.GetAttributeValue("innerText");
                string ConvictionDriver = firstConvictionSummaryDriver.GetAttributeValue("innerText");
                string ConvictionDate = firstConvictionSummaryDate.GetAttributeValue("innerText");
                string ConvictionCause = firstConvictionSummaryCause.GetAttributeValue("innerText");
                Assert.Equal("Conviction 1", ConvictionTitle);
                var date = _driverHistoryData.FirstConvictionDay + "/"
                    + _driverHistoryData.FirstConvictionMonth + "/" + _driverHistoryData.FirstConvictionYear;
                Assert.Equal(_driverHistoryData.FirstConvictionDriver, ConvictionDriver);
                Assert.Equal(date, ConvictionDate);
                Assert.Equal(_driverHistoryData.FirstConvictionCode, ConvictionCause);
            }

        }

        public void VerifyFirstConvictionSectionCollapsed(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementBehind(cbConvictionCustomer1Selector));
                Assert.True(IsElementBehind(txtConvictionDay1Selector));
                Assert.True(IsElementBehind(txtConvictionMonth1Selector));
                Assert.True(IsElementBehind(txtConvictionYear1Selector));
                Assert.True(IsElementBehind(cbConvictionType1Selector));
                Assert.True(IsElementBehind(txtConvictionPenaltyPoint1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedYes1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedNo1Selector));
                Assert.True(IsElementBehind(btnSaveConvictionSelector));
            }
        }
        public void VerifyCancelConvictionCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                Boolean isConvictionActive = btnCoreConvictionMultiDriverYes.GetAttributeValue("class").Equals("isActive") || btnCoreConvictionMultiDriverNo.GetAttributeValue("class").Equals("isActive");
                Assert.False(isConvictionActive);
                Assert.True(IsElementBehind(cbConvictionCustomer1Selector));
                Assert.True(IsElementBehind(txtConvictionDay1Selector));
                Assert.True(IsElementBehind(txtConvictionMonth1Selector));
                Assert.True(IsElementBehind(txtConvictionYear1Selector));
                Assert.True(IsElementBehind(cbConvictionType1Selector));
                Assert.True(IsElementBehind(txtConvictionPenaltyPoint1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedYes1Selector));
                Assert.True(IsElementBehind(btnNCBAffectedNo1Selector));
                Assert.True(IsElementBehind(btnSaveConvictionSelector));
            }
        }
        public void SaveDataOfConvictionByConvictionNumber(string ConvictionNumber)
        {
            if (!String.IsNullOrEmpty(ConvictionNumber))
            {
                var editButton = _driver.FindElement(By.Id("EditConviction" + ConvictionNumber));
                editButton.Click();
                //btnFirstConvictionSummaryEdit.Click();
                var i = Convert.ToInt32(ConvictionNumber);
                string ConvictionCustomer = _driver.FindElement(By.Id(cbConvictionCustomer1Id.Replace("1", (i).ToString()))).Text;
                string ConvictionDay = _driver.FindElement(By.Id(txtConvictionDay1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string ConvictionMonth = _driver.FindElement(By.Id(txtConvictionMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string ConvictionYear = _driver.FindElement(By.Id(txtConvictionYear1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string ConvictionType = _driver.FindElement(By.Id(cbConvictionType1Id.Replace("1", (i).ToString()))).Text.Replace("\r", "").Replace("\n", "").Replace("×", "");
                convictionsInfo[i - 1, 0] = "Conviction " + (i).ToString();
                convictionsInfo[i - 1, 1] = ConvictionCustomer;
                convictionsInfo[i - 1, 2] = ConvictionDay + "/" + ConvictionMonth + "/" + ConvictionYear;
                convictionsInfo[i - 1, 3] = ConvictionType;
                btnSaveConviction.Click();
            }
        }
        public void SaveDataOfConvictionByConvictionNumber2(string info)
        {
            if (!String.IsNullOrEmpty(info))
            {
                Conviction con = new Conviction();
                var convicionInfo = _pageHelper.SplitBy(info, ",");
                var i =  convicionInfo[0];
                var editButton = _driver.FindElement(By.Id("EditConviction" + i));
                editButton.Click();
                string convictionCustomer = _driver.FindElement(By.Id(cbConvictionCustomer1Id.Replace("1", (i).ToString()))).Text;
                string convictionDay = _driver.FindElement(By.Id(txtConvictionDay1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string convictionMonth = _driver.FindElement(By.Id(txtConvictionMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string convictionYear = _driver.FindElement(By.Id(txtConvictionYear1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                string convictionType = _driver.FindElement(By.Id(cbConvictionType1Id.Replace("1", (i).ToString()))).Text.Replace("\r", "").Replace("\n", "").Replace("×", "");
                string convictionFineYes = _driver.FindElement(By.Id(btnConvictionFineYes1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                string convictionFineNo = _driver.FindElement(By.Id(btnConvictionFineNo1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                if (convictionFineYes == "isActive")
                {
                    string convictionFineAmount = _driver.FindElement(By.Id(txtConvictionFineAmount1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    con.FineAmount = convictionFineAmount;
                }
                string convictionBanYes = _driver.FindElement(By.Id(btnConvictionBannedDriverYes1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                string convictionBanNo = _driver.FindElement(By.Id(btnConvictionBannedDriverNo1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                if (convictionBanYes == "isActive")
                {
                    string convictionBanMonth = _driver.FindElement(By.Id(txtConvictionBanMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    con.BannedMonth = convictionBanMonth;
                }
                
                con.Driver = convictionCustomer;
                con.Day = convictionDay;
                con.Month = convictionMonth;
                con.Year = convictionYear;
                con.Code = convictionType;
                con.PenaltyPoints = convictionType;
                con.FineYes = convictionFineYes;
                con.FineNo = convictionFineNo;
                con.BannedDriverYes = convictionBanYes;
                con.BannedDriverNo = convictionBanNo;
                con.isProposer = (convicionInfo[1] == "Proposer") ? 1 : 0;
                btnSaveConviction.Click();
                lstConviction.Add(con);
            }
        }

        public void VerifyConvictionsInfo(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                for (int i = 0; i < convictionsInfo.GetLength(0); i++)
                {
                    string ConvictionSummaryXpath = $"//*[@itemname='Conviction']/div[{i + 1}]";

                    string ConvictionTitle = _driver.FindElement(By.XPath(ConvictionSummaryXpath))
                        .FindElement(By.XPath(".//p[1]"))
                        .GetAttribute("innerText");
                    string ConvictionCustomer = _driver.FindElement(By.XPath(ConvictionSummaryXpath))
                        .FindElement(By.XPath(".//p[2]"))
                        .GetAttribute("innerText");
                    string ConvictionDate = _driver.FindElement(By.XPath(ConvictionSummaryXpath))
                        .FindElement(By.XPath(".//p[3]"))
                        .GetAttribute("innerText");
                    string ConvictionType = _driver.FindElement(By.XPath(ConvictionSummaryXpath))
                        .FindElement(By.XPath(".//p[4]"))
                        .GetAttribute("innerText");
                    Assert.Equal(convictionsInfo[i, 0], ConvictionTitle);
                    Assert.Equal(convictionsInfo[i, 1], ConvictionCustomer);
                    Assert.Equal(convictionsInfo[i, 2], ConvictionDate);
                    Assert.Equal(convictionsInfo[i, 3], ConvictionType);
                }
            }
        }
        public void VerifyConvictionsInfo2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                for (int i = 1; i < lstConviction.Count + 1; i++)
                {
                    var editButton = _driver.FindElement(By.Id("EditConviction" + i.ToString()));
                    editButton.Click();
                    string convictionCustomer = _driver.FindElement(By.Id(cbConvictionCustomer1Id.Replace("1", (i).ToString()))).Text;
                    string convictionDay = _driver.FindElement(By.Id(txtConvictionDay1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    string convictionMonth = _driver.FindElement(By.Id(txtConvictionMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    string convictionYear = _driver.FindElement(By.Id(txtConvictionYear1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                    string convictionType = _driver.FindElement(By.Id(cbConvictionType1Id.Replace("1", (i).ToString()))).Text.Replace("\r", "").Replace("\n", "").Replace("×", "");
                    string convictionFineYes = _driver.FindElement(By.Id(btnConvictionFineYes1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                    string convictionFineNo = _driver.FindElement(By.Id(btnConvictionFineNo1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                    if (convictionFineYes == "isActive")
                    {
                        string convictionFineAmount = _driver.FindElement(By.Id(txtConvictionFineAmount1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                        Assert.Equal(lstConviction[i - 1].FineAmount, convictionFineAmount);
                    }
                    string convictionBanYes = _driver.FindElement(By.Id(btnConvictionBannedDriverYes1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                    string convictionBanNo = _driver.FindElement(By.Id(btnConvictionBannedDriverNo1Id.Replace("1", (i).ToString()))).GetAttribute("class");
                    if (convictionBanYes == "isActive")
                    {
                        string convictionBanMonth = _driver.FindElement(By.Id(txtConvictionBanMonth1Id.Replace("1", (i).ToString()))).GetAttribute("value");
                        Assert.Equal(lstConviction[i - 1].BannedMonth, convictionBanMonth);
                    }
                    Assert.Equal(lstConviction[i - 1].Driver, convictionCustomer);
                    Assert.Equal(lstConviction[i - 1].Day, convictionDay);
                    Assert.Equal(lstConviction[i - 1].Month, convictionMonth);
                    Assert.Equal(lstConviction[i - 1].Year, convictionYear);
                    Assert.Equal(lstConviction[i - 1].Code, convictionType);
                    Assert.Equal(lstConviction[i - 1].PenaltyPoints, convictionType);
                    Assert.Equal(lstConviction[i - 1].FineYes, convictionFineYes);
                    Assert.Equal(lstConviction[i - 1].FineNo, convictionFineNo);
                    Assert.Equal(lstConviction[i - 1].BannedDriverYes, convictionBanYes);
                    Assert.Equal(lstConviction[i - 1].BannedDriverNo, convictionBanNo);
                    btnSaveConviction.Click();
                }
                lstConviction.Clear();
            }
        }

        public void VerifyCanNotAddOverMaxConviction(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(IsElementBehind(btnAddAnotherConvictionSelector));
            }
        }
        #endregion

        #region Verify data save correctly
        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _driverHistoryData = new GuiModelData.DriverHistoryData();
                _driverHistoryData.FirstClaimNo = btnCoreClaimMultiDriverNo?.GetAttributeValue("class");
                _driverHistoryData.FirstClaimYes = btnCoreClaimMultiDriverYes?.GetAttributeValue("class");
                if (_driverHistoryData.FirstClaimYes.Equals("isActive"))
                {
                    btnFirstClaimSummaryEdit.Click();
                    _driverHistoryData.FirstClaimDriver = cbClaimCustomer1?.GetText();
                    _driverHistoryData.FirstClaimDay = txtClaimDay1?.GetPopulatedValue();
                    _driverHistoryData.FirstClaimMonth = txtClaimMonth1?.GetPopulatedValue();
                    _driverHistoryData.FirstClaimYear = txtClaimYear1?.GetPopulatedValue();
                    _driverHistoryData.FirstClaimCause = cbClaimType1?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", "");
                    _driverHistoryData.FirstClaimCost = txtTotalClaimCost1?.GetPopulatedValue();
                    _driverHistoryData.FirstClaimAffectedYes = btnNCBAffectedYes1?.GetAttributeValue("class");
                    _driverHistoryData.FirstClaimAffectedNo = btnNCBAffectedNo1?.GetAttributeValue("class");
                    btnSaveClaim.Click();
                }

                if (_driver.FindElements(btnSecondClaimSummaryEditSelector).Count > 0)
                {
                    btnSecondClaimSummaryEdit.Click();
                    _driverHistoryData.SecondClaimDriver = cbClaimCustomer2?.GetText();
                    _driverHistoryData.SecondClaimDay = txtClaimDay2?.GetPopulatedValue();
                    _driverHistoryData.SecondClaimMonth = txtClaimMonth2?.GetPopulatedValue();
                    _driverHistoryData.SecondClaimYear = txtClaimYear2?.GetPopulatedValue();
                    _driverHistoryData.SecondClaimCause = cbClaimType2?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", "");
                    _driverHistoryData.SecondClaimCost = txtTotalClaimCost2?.GetPopulatedValue();
                    _driverHistoryData.SecondClaimAffectedYes = btnNCBAffectedYes2?.GetAttributeValue("class");
                    _driverHistoryData.SecondClaimAffectedNo = btnNCBAffectedNo2?.GetAttributeValue("class");
                    btnSaveClaim.Click();
                }
                _driverHistoryData.FirstConvictionNo = btnCoreConvictionMultiDriverNo?.GetAttributeValue("class");
                _driverHistoryData.FirstConvictionYes = btnCoreConvictionMultiDriverYes?.GetAttributeValue("class");
                if (_driverHistoryData.FirstConvictionYes.Equals("isActive"))
                {
                    btnFirstConvictionSummaryEdit.Click();
                    _driverHistoryData.FirstConvictionDriver = cbConvictionCustomer1?.GetText();
                    _driverHistoryData.FirstConvictionDay = txtConvictionDay1?.GetPopulatedValue();
                    _driverHistoryData.FirstConvictionMonth = txtConvictionMonth1?.GetPopulatedValue();
                    _driverHistoryData.FirstConvictionYear = txtConvictionYear1?.GetPopulatedValue();
                    _driverHistoryData.FirstConvictionCode = cbConvictionType1?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", "");
                    _driverHistoryData.FirstConvictionPenaltyPoints = txtConvictionPenaltyPoint1?.GetPopulatedValue();
                    _driverHistoryData.FirstConvictionFineYes = btnConvictionFineYes1?.GetAttributeValue("class");
                    _driverHistoryData.FirstConvictionFineNo = btnConvictionFineNo1?.GetAttributeValue("class");
                    _driverHistoryData.FirstConvictionBannedDriverYes = btnConvictionBannedDriverYes1?.GetAttributeValue("class");
                    _driverHistoryData.FirstConvictionBannedDriverNo = btnConvictionBannedDriverNo1?.GetAttributeValue("class");
                    if (_driverHistoryData.FirstConvictionBannedDriverYes.Equals("isActive"))
                    {
                        _driverHistoryData.BannedMonth1 = txtBanMonths1.GetPopulatedValue();
                    }
                    if (_driverHistoryData.FirstConvictionFineYes.Equals("isActive"))
                    {
                        _driverHistoryData.FinnedAmount1 = txtFineValue1.GetPopulatedValue();
                    }
                    btnSaveConviction.Click();
                }
                if (_driver.FindElements(btnSecondConvictionSummaryEditSelector).Count > 0)
                {
                    btnSecondConvictionSummaryEdit.Click();
                    _driverHistoryData.SecondConvictionDriver = cbConvictionCustomer2?.GetText();
                    _driverHistoryData.SecondConvictionDay = txtConvictionDay2?.GetPopulatedValue();
                    _driverHistoryData.SecondConvictionMonth = txtConvictionMonth2?.GetPopulatedValue();
                    _driverHistoryData.SecondConvictionYear = txtConvictionYear2?.GetPopulatedValue();
                    _driverHistoryData.SecondConvictionCode = cbConvictionType2?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", "");
                    _driverHistoryData.SecondConvictionPenaltyPoints = txtConvictionPenaltyPoint2?.GetPopulatedValue();
                    _driverHistoryData.SecondConvictionFineYes = btnConvictionFineYes2?.GetAttributeValue("class");
                    _driverHistoryData.SecondConvictionFineNo = btnConvictionFineNo2?.GetAttributeValue("class");
                    _driverHistoryData.SecondConvictionBannedDriverYes = btnConvictionBannedDriverYes2?.GetAttributeValue("class");
                    _driverHistoryData.SecondConvictionBannedDriverNo = btnConvictionBannedDriverNo2?.GetAttributeValue("class");
                    if (_driverHistoryData.FirstConvictionBannedDriverYes.Equals("isActive"))
                    {
                        _driverHistoryData.BannedMonth2 = txtBanMonths2.GetPopulatedValue();
                    }
                    if (_driverHistoryData.FirstConvictionFineYes.Equals("isActive"))
                    {
                        _driverHistoryData.FinnedAmount2 = txtFineValue2.GetPopulatedValue();

                    }
                    btnSaveConviction.Click();
                }
                _driverHistoryData.NCBYears =  cbNCBYears?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", "");
                _driverHistoryData.NumberOfVehicleInHousehold = cbNumberOfVehicleInHousehold.GetText();
                
                if (_driverHistoryData.NumberOfVehicleInHousehold != "1" && _driverHistoryData.NumberOfVehicleInHousehold != "Please Select")
                {
                    _driverHistoryData.IsOtherVehicleUseYes = btnOtherVehicleUseYes.GetAttributeValue("class");
                    _driverHistoryData.IsOtherVehicleUseNo = btnOtherVehicleUseNo.GetAttributeValue("class");
                    if (_driverHistoryData.IsOtherVehicleUseYes == "isActive")
                    {
                        _driverHistoryData.LargestNcbInOtherVehicle = cbLargestNcbInOtherVehicle.GetText();
                    }
                }
                
                
            }
        }

        public void VerifyDriverHistoryDataDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {

                Assert.Equal(_driverHistoryData.FirstClaimNo, btnCoreClaimMultiDriverNo?.GetAttributeValue("class"));
                Assert.Equal(_driverHistoryData.FirstClaimYes, btnCoreClaimMultiDriverYes?.GetAttributeValue("class"));
                if (_driverHistoryData.FirstClaimYes.Equals("isActive"))
                {
                    btnFirstClaimSummaryEdit.Click();
                    Assert.Equal(_driverHistoryData.FirstClaimDriver, cbClaimCustomer1?.GetText());
                    Assert.Equal(_driverHistoryData.FirstClaimDay, txtClaimDay1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstClaimMonth, txtClaimMonth1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstClaimYear, txtClaimYear1?.GetPopulatedValue());
                    var claimType = cbClaimType1?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", "");
                    Assert.Equal(_driverHistoryData.FirstClaimCause, claimType);
                    Assert.Equal(_driverHistoryData.FirstClaimCost, txtTotalClaimCost1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstClaimAffectedYes, btnNCBAffectedYes1?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.FirstClaimAffectedNo, btnNCBAffectedNo1?.GetAttributeValue("class"));
                    btnSaveClaim.Click();
                }
                if (_driver.FindElements(btnSecondClaimSummaryEditSelector).Count > 0)
                {
                    btnSecondClaimSummaryEdit.Click();
                    Assert.Equal(_driverHistoryData.SecondClaimDriver, cbClaimCustomer2?.GetText());
                    Assert.Equal(_driverHistoryData.SecondClaimDay, txtClaimDay2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondClaimMonth, txtClaimMonth2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondClaimYear, txtClaimYear2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondClaimCause, cbClaimType2?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", ""));
                    Assert.Equal(_driverHistoryData.SecondClaimCost, txtTotalClaimCost2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondClaimAffectedYes, btnNCBAffectedYes2?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.SecondClaimAffectedNo, btnNCBAffectedNo2?.GetAttributeValue("class"));
                    btnSaveClaim.Click();
                }
                Assert.Equal(_driverHistoryData.FirstConvictionNo, btnCoreConvictionMultiDriverNo?.GetAttributeValue("class"));
                Assert.Equal(_driverHistoryData.FirstConvictionYes, btnCoreConvictionMultiDriverYes?.GetAttributeValue("class"));
                if (_driverHistoryData.FirstConvictionYes.Equals("isActive"))
                {
                    btnFirstConvictionSummaryEdit.Click();
                    Assert.Equal(_driverHistoryData.FirstConvictionDriver, cbConvictionCustomer1?.GetText());
                    Assert.Equal(_driverHistoryData.FirstConvictionDay, txtConvictionDay1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstConvictionMonth, txtConvictionMonth1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstConvictionYear, txtConvictionYear1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstConvictionCode, cbConvictionType1?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", ""));
                    Assert.Equal(_driverHistoryData.FirstConvictionPenaltyPoints, txtConvictionPenaltyPoint1?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.FirstConvictionFineYes, btnConvictionFineYes1?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.FirstConvictionFineNo, btnConvictionFineNo1?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.FirstConvictionBannedDriverYes, btnConvictionBannedDriverYes1?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.SecondConvictionBannedDriverNo, btnConvictionBannedDriverNo1?.GetAttributeValue("class"));
                    btnSaveConviction.Click();
                }
                if (_driver.FindElements(btnSecondConvictionSummaryEditSelector).Count > 0)
                {
                    btnSecondConvictionSummaryEdit.Click();
                    Assert.Equal(_driverHistoryData.SecondConvictionDriver, cbConvictionCustomer2?.GetText());
                    Assert.Equal(_driverHistoryData.SecondConvictionDay, txtConvictionDay2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondConvictionMonth, txtConvictionMonth2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondConvictionYear, txtConvictionYear2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondConvictionCode, cbConvictionType2?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", ""));
                    Assert.Equal(_driverHistoryData.SecondConvictionPenaltyPoints, txtConvictionPenaltyPoint2?.GetPopulatedValue());
                    Assert.Equal(_driverHistoryData.SecondConvictionFineYes, btnConvictionFineYes2?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.SecondConvictionFineNo, btnConvictionFineNo2?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.SecondConvictionBannedDriverYes, btnConvictionBannedDriverYes2?.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.SecondConvictionBannedDriverNo, btnConvictionBannedDriverNo2?.GetAttributeValue("class"));
                    btnSaveConviction.Click();
                }
                Assert.Equal(_driverHistoryData.NCBYears, cbNCBYears?.GetText().Replace("\r", "").Replace("\n", "").Replace("×", ""));
                Assert.Equal(_driverHistoryData.NumberOfVehicleInHousehold, cbNumberOfVehicleInHousehold.GetText());

                if (_driverHistoryData.NumberOfVehicleInHousehold != "1" && _driverHistoryData.NumberOfVehicleInHousehold != "Please Select")
                {
                    Assert.Equal(_driverHistoryData.IsOtherVehicleUseYes, btnOtherVehicleUseYes.GetAttributeValue("class"));
                    Assert.Equal(_driverHistoryData.IsOtherVehicleUseNo, btnOtherVehicleUseNo.GetAttributeValue("class"));
                    if (_driverHistoryData.IsOtherVehicleUseYes == "isActive")
                    {
                        Assert.Equal(_driverHistoryData.LargestNcbInOtherVehicle, cbLargestNcbInOtherVehicle.GetText());
                    }
                }
            }
        }

        #endregion

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