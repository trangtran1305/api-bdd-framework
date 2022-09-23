using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace CMBI.Pages
{
    public class QuoteListPage : BasePage
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
        private Button btnProgressBarBike = new Button(By.Id("ProgressBarBike"));
        private Button btnProgressBarYourDetails = new Button(By.Id("ProgressBarYourDetails"));
        private Button btnProgressBarHistory = new Button(By.Id("ProgressBarHistory"));
        private Button btnProgressBarPolicy = new Button(By.Id("ProgressBarPolicy"));
        private Button btnViewSummary = new Button(By.Id("ViewSummary"));
        private Button btnAdjustButton = new Button(By.Id("AdjustButton"));
        private Button btnCloseDetailsButton = new Button(By.Id("CloseDetailsButton"));
        private Button btnPaymentMonthly = new Button(By.Id("PaymentMonthly"));
        private Button btnPaymentAnnual = new Button(By.Id("PaymentAnnual"));
        private Button btnComprehensiveType = new Button(By.Id("ComprehensiveType"));
        private Button btnThirdPartyType = new Button(By.Id("ThirdPartyType"));
        private Button btnThirdPartyOnlyType = new Button(By.Id("ThirdPartyOnlyType"));
        private Button btnProtectedYes = new Button(By.Id("ProtectedYes"));
        private Button btnProtectedNo = new Button(By.Id("ProtectedNo"));
        private Combobox cbVoluntaryExcessQuestion = new Combobox(By.Id("VoluntaryExcessQuestion"));
        private Button btnOpExType1 = new Button(By.Id("OpExType1"));
        private Button btnOpExType2 = new Button(By.Id("OpExType2"));
        private Button btnOpExType3 = new Button(By.Id("OpExType3"));
        private Button btnOpExType4 = new Button(By.Id("OpExType4"));
        private Button btnOpExType5 = new Button(By.Id("OpExType5"));
        private Button btnQuoteUpdateButton = new Button(By.Id("QuoteUpdateButton"));
        private Button btnToggleMonthly = new Button(By.Id("toggle-monthly"));
        private Button btnToggleAnnual = new Button(By.Id("toggle-annual"));
        private By btnViewDetailsButtonSelector = By.XPath("//*[contains(@id, 'ViewDetailsButton_1')]");
        private Button btnTransferToProvider = new Button(By.Id("TransferButton"));
        private Button btnAdjustAdditionalButton = new Button(By.Id("AdjustAdditionalButton"));
        private Label lbPaymentValueAnnual = new Label(By.Id("PaymentValueAnnual"));
        private Label lbQuotereference = new Label(By.Id("Quotereference"));
        private Label lbTotalMonthlyValue = new Label(By.Id("TotalMonthlyValue"));
        private Label lb = new Label(By.Id("ThirdPartyOnlyType"));
        //private Label lb = new Label(By.Id("ThirdPartyOnlyType"));
        //private Label lb = new Label(By.Id("ThirdPartyOnlyType"));
        //private Label lb = new Label(By.Id("ThirdPartyOnlyType"));
        //private Label lb = new Label(By.Id("ThirdPartyOnlyType"));
        //private Label lb = new Label(By.Id("ThirdPartyOnlyType"));


        #region Assumption
        public void ClickLetBegin(String input)
        {

            ClickContinueOnTrialPage();
            //WaitUntilElementVisible(btnLetBeginSelector);
            if (input.Equals("Yes"))
            {
                //btnLetBegin.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(1000);
            }
            ClickContinueOnTrialPage();
            WriteLogIfTechnicalError();
        }
        #endregion

        
        public void ClickVehicleSummEdit(String input)
        {
            if (input.Equals("Yes"))
            {
                //Thread.Sleep(2000);
                //btnVehicleSummEdit.Click();
            }
        }

        public void InputRegNumber(string regNumber)
        {
            if (!String.IsNullOrEmpty(regNumber))
            {
                txtRegNumber.Input(regNumber);
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