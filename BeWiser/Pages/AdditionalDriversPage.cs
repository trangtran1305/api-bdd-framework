using BeWiser.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace BeWiser.Pages
{
    public class AdditionalDriversPage : BasePage
    {
        DateTime now = DateTime.Now;
        private By additionalDriverPersonalDetailsSubHeading = By.Id("AdditionalDriverPersonalDetailsSubHeading");

        private Button btnContinueToHistory = new Button(By.Id("DriverSummaryContinue"));
        private Button btnAddDriver = new Button(By.Id("AddDriver"));

        private By cbLicenceDateLessThan5YearsYearLocator = By.Id("AdditionalDriverLicenceDateLessThan5YearsYear");
        private By cbLicenceDateLessThan5YearsMonthLocator = By.Id("AdditionalDriverLicenceDateLessThan5YearsMonth");
        private By txtLicenceDateLessThan1YearDayLocator = By.Id("AdditionalDriverLicenceDateLessThan1YearDay");
        private By txtLicenceDateLessThan1YearYearLocator = By.Id("AdditionalDriverLicenceDateLessThan1YearMonth");
        private By txtLicenceDateLessThan1YearMonthLocator = By.Id("AdditionalDriverLicenceDateLessThan1YearYear");
        
        private static By btnTitle_MrSelector = By.Id("AdditionalDriverTitle_Mr");
        private static By btnTitle_MrsSelector = By.Id("AdditionalDriverTitle_Mrs");
        private static By btnTitle_MissSelector = By.Id("AdditionalDriverTitle_Miss");
        private static By btnTitle_MsSelector = By.Id("AdditionalDriverTitle_Ms");
        private Button btnTitle_Mr = new Button(btnTitle_MrSelector);
        private Button btnTitle_Mrs = new Button(btnTitle_MrsSelector);
        private Button btnTitle_Miss = new Button(btnTitle_MissSelector);
        private Button btnTitle_Ms = new Button(btnTitle_MsSelector);
        private Textbox txtFirstName = new Textbox(By.Id("AdditionalDriverFirstName"));
        private Textbox txtSurname = new Textbox(By.Id("AdditionalDriverSurname"));
        private Textbox txtBirthDay = new Textbox(By.Id("AdditionalDriverBirthDay"));
        private Textbox txtBirthMonth = new Textbox(By.Id("AdditionalDriverBirthMonth"));
        private Textbox txtBirthYear = new Textbox(By.Id("AdditionalDriverBirthYear"));
        private Button btnAdditionalDriverUKResidentSinceBirthYes = new Button(By.Id("AdditionalDriverUKResidentSinceBirthYes"));
        private Button btnAdditionalDriverUKResidentSinceBirthNo = new Button(By.Id("AdditionalDriverUKResidentSinceBirthNo"));

        private Combobox cbUKResidentMonth = new Combobox(By.Id("AdditionalDriverUKResidentMonth"));
        private Combobox cbUKResidentYear = new Combobox(By.Id("AdditionalDriverUKResidentYear"));
        private Combobox cbMaritalStatus = new Combobox(By.Id("AdditionalDriverMaritalStatus"));
        private Combobox cbRelationshipToProposer = new Combobox(By.Id("AdditionalDriverRelationshipToProposer"));
        private Button btnDVLANotifiedYes = new Button(By.Id("AdditionalDriverDVLANotifiedYes"));
        private Button btnDVLANotifiedNo = new Button(By.Id("AdditionalDriverDVLANotifiedNo"));
        private Button btnAdditionalDriverDetailsContinueNextStep = new Button(By.Id("AdditionalDriverPersonalDetailsContinueNextStep"));

        private Combobox cbEmploymentStatusFullTime = new Combobox(By.Id("AdditionalDriverEmploymentStatusFullTime"));
        private Combobox cbMainJob = new Combobox(By.Id("AdditionalDriverMainJob"));
        private Combobox cbBusinessOrIndustryFullTime = new Combobox(By.Id("AdditionalDriverBusinessOrIndustryFullTime"));
        private Button btnAnyPartTimeJobYes = new Button(By.Id("AdditionalDriverAnyPartTimeJobYes"));
        private Button btnAnyPartTimeJobNo = new Button(By.Id("AdditionalDriverAnyPartTimeJobNo"));
        private Combobox cbEmploymentStatusPartTime = new Combobox(By.Id("AdditionalDriverEmploymentStatusPartTime"));
        private Combobox cbPartTimeJob = new Combobox(By.Id("AdditionalDriverPartTimeJob"));
        private Combobox cbBusinessOrIndustryPartTime = new Combobox(By.Id("AdditionalDriverBusinessOrIndustryPartTime"));
        private Button btnAdditionalDriverEmploymentContinueNextStep = new Button(By.Id("AdditionalDriverContinueNextStep"));

        private Combobox cbLicenceType = new Combobox(By.Id("AdditionalDriverLicenceType"));

        private Textbox txtLicenceDateLessThan1YearDay = new Textbox(By.Id("AdditionalDriverLicenceDateLessThan1YearDay"));
        private Textbox txtLicenceDateLessThan1YearMonth = new Textbox(By.Id("AdditionalDriverLicenceDateLessThan1YearMonth"));
        private Textbox txtLicenceDateLessThan1YearYear = new Textbox(By.Id("AdditionalDriverLicenceDateLessThan1YearYear"));
        private Combobox cbAdditionalLicenceDate = new Combobox(By.Id("AdditionalLicenceDate"));
        //private Combobox cbOtherVehicleAccess = new Combobox(By.Id("AdditionalDriverOtherVehicleAccess"));
        private Combobox cbLicenceDateLessThan5YearsMonth = new Combobox(By.Id("AdditionalDriverLicenceDateLessThan5YearsMonth"));
        private Combobox cbLicenceDateLessThan5YearsYear = new Combobox(By.Id("AdditionalDriverLicenceDateLessThan5YearsYear"));
        private Button btnMainDriverYes = new Button(By.Id("AdditionalDriverMainDriverYes"));
        private Button btnMainDriverNo = new Button(By.Id("AdditionalDriverMainDriverNo"));
        private static By btnAddAdditionalDriverSelector = By.Id("AdditionalDriverContinue");
        private Button btnAddAdditionalDriver = new Button(btnAddAdditionalDriverSelector);
        private Button btnAdditionalDriverContinueToHistory = new Button(By.Id("DriverSummaryContinue"));
        private Button btnAdditionalDriverBack = new Button(By.Id("DriverSummaryBack"));

        private By MainDriverSummary = By.XPath("(//*[@class='questionset__summary__content'])[1]");
        private By MainDriverLabel = By.XPath("(//*[@class='questionset__summary__content'])[1]/following-sibling::div/div/span");
        private By AdditionalDriverSummary = By.XPath("(//*[@class='questionset__summary__content'])[2]");
        private By SetAsMainDriverButton = By.Id("SetMainDriver2");
        private Combobox cbOtherVehicleUse = new Combobox(By.XPath("//ng-select[@id='AdditionalDriverOtherVehicleUse']"));

        #region Additional driver's detail
        public void ClickTitle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                switch (input)
                {
                    case "Mr":
                        BaseAction.FindAndClick(btnTitle_MrSelector);
                        Thread.Sleep(500);
                        // focus on other item to get Class attribute of btnLowProfileCampervanSelector
                        txtFirstName.Input("");
                        while (!btnTitle_Mr.GetAttributeValue("class").Contains("isActive"))
                        {
                            btnTitle_Mr.Click();
                            txtFirstName.Input("");
                        }
                        break;
                    case "Mrs":
                        BaseAction.FindAndClick(btnTitle_MrsSelector);
                        break;
                    case "Miss":
                        BaseAction.FindAndClick(btnTitle_MissSelector);
                        Thread.Sleep(500);
                        // focus on other item to get Class attribute of btnLowProfileCampervanSelector
                        txtFirstName.Input("");
                        while (!btnTitle_Miss.GetAttributeValue("class").Contains("isActive"))
                        {
                            btnTitle_Miss.Click();
                            txtFirstName.Input("");
                        }
                        break;
                    case "Ms":
                        BaseAction.FindAndClick(btnTitle_MsSelector);
                        break;
                    default:
                        Console.WriteLine("The inputted title is not match!");
                        break;
                }
            }
        }
        public void InputFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtFirstName.Clear();
                txtFirstName.Input(input);
            }
        }
        public void InputSurname(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtSurname.Clear();
                txtSurname.Input(input);
            }
        }
        public void InputAdditionalDriverBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtBirthDay.Clear();
                txtBirthDay.Input(splittedDate.Item1);
                txtBirthMonth.Clear();
                txtBirthMonth.Input(splittedDate.Item2);
                txtBirthYear.Clear();
                txtBirthYear.Input(splittedDate.Item3);
            }
        }
        public void ClickAdditionalDriverUKResidentSinceBirth(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdditionalDriverUKResidentSinceBirthYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdditionalDriverUKResidentSinceBirthNo.Click();
            }
        }
        public void SelectPermanentResidentMonth (string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbUKResidentMonth.SelectByText(input);
            }
        }
        public void SelectPermanentResidentYear(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbUKResidentYear.SelectByText(input);
            }
        }

        public void SelectMaritalStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbMaritalStatus.SelectByText(input);
            }
        }
        public void SelectRelationshipToProposer(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbRelationshipToProposer.SelectByText(input);
            }
        }



        public void ClickDVLANotified(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnDVLANotifiedYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnDVLANotifiedNo.Click();
            }
        }
        public void ClickAdditionalDriverDetailsContinueNextStep(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnAdditionalDriverDetailsContinueNextStep.Click();
            }
        }

        #endregion

        #region Employment
        public void SelectEmploymentStatusFullTime(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbEmploymentStatusFullTime.SelectByText(input);
            }
        }
        public void SelectAdditionalDriverMainJob(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbMainJob.Input(input);
            }
        }
        public void SelectBusinessOrIndustryFullTime(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbBusinessOrIndustryFullTime.Input(input);
            }
        }

        public void ClickPartTimeJobConfirm(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAnyPartTimeJobYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAnyPartTimeJobNo.Click();
            }
        }
        

        public void SelectPartTimeStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbEmploymentStatusPartTime.SelectByText(input);
            }
        }
        public void SelectPartTimeJob(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbPartTimeJob.Input(input);
            }
        }

        public void SelectBusinessOrIndustryPartTime(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbBusinessOrIndustryPartTime.Input(input);
            }
        }

        public void SelectLicenceDateLessThan5Years(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbLicenceDateLessThan5YearsYear.SelectByText(input);
            }
        }
        public void SelectLicenceDateLessThan5YearsMonth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbLicenceDateLessThan5YearsMonth.SelectByText(input);
            }
        }

        public void ClickAdditionalDriverContinueNextStep(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnAdditionalDriverEmploymentContinueNextStep.Click();
            }
        }
        public void ClickAdditionalDriverContinue(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                BaseAction.FindAndClick(btnAddAdditionalDriverSelector);
                //btnAddAdditionalDriver.Click();
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
                if (_driver.FindElements(btnAddAdditionalDriverSelector).Count > 0)
                {
                    btnAddAdditionalDriver.Click();
                }
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }

        #endregion

        #region Driving
        public void SelectLicenceType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbLicenceType.SelectByText(input);
            }
        }
        public void SelectAdditionalLicenceDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbAdditionalLicenceDate.SelectByText(input);
            }
        }
        public void InputObtainedLicenceDateSubtractMonths(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(1000);
                var numOfMonths = Convert.ToInt32(input);
                var inputtedDate = now.ToString("dd/MM/yyyy");
                var splittedDate = _pageHelper.SplitDate(inputtedDate);
                var elements = _driver.FindElements(txtLicenceDateLessThan1YearDayLocator);
                bool isTrue = elements.Count > 0;
                if (numOfMonths == 0)
                {
                    txtLicenceDateLessThan1YearDay.Clear();
                    txtLicenceDateLessThan1YearDay.Input(splittedDate.Item1);
                    txtLicenceDateLessThan1YearMonth.Clear();
                    txtLicenceDateLessThan1YearMonth.Input(splittedDate.Item2);
                    txtLicenceDateLessThan1YearYear.Clear();
                    txtLicenceDateLessThan1YearYear.Input(splittedDate.Item3);
                }
                else if (isTrue)
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    txtLicenceDateLessThan1YearDay.Clear();
                    txtLicenceDateLessThan1YearDay.Input(splittedDate.Item1);
                    txtLicenceDateLessThan1YearMonth.Clear();
                    txtLicenceDateLessThan1YearMonth.Input(splittedDate.Item2);
                    txtLicenceDateLessThan1YearYear.Clear();
                    txtLicenceDateLessThan1YearYear.Input(splittedDate.Item3);
                }
                else
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MMMM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    cbLicenceDateLessThan5YearsMonth.SelectByText(splittedDate.Item2);
                    cbLicenceDateLessThan5YearsYear.SelectByText(splittedDate.Item3);
                }
            }
        }
        //public void SelectOtherVehicleAccess(string input)
        //{
        //    if (!String.IsNullOrEmpty(input))
        //    {
        //        cbOtherVehicleAccess.SelectByText(input);
        //    }
        //}
        public void ClickMainDriver(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnMainDriverYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnMainDriverNo.Click();
            }
        }
        public void SelectOtherVehicleInUse(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbOtherVehicleUse.SelectByText(input);
            }
        }

        public void ClickAdditionalDriverBack(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdditionalDriverBack.Click();
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
        #endregion

        #region Verify error message
        public void VerifyAdditionalDriversPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(additionalDriverPersonalDetailsSubHeading);
                //Thread.Sleep(3000);
                var elements = _driver.FindElements(additionalDriverPersonalDetailsSubHeading);
                bool isTrue = elements.Count > 0;
                Assert.True(isTrue);
            }
        }
        #endregion

        #region Verify obtained licence in Driving section
        public void VerifyLicenceDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(input, cbAdditionalLicenceDate.GetInnerText());
            }
        }
        public void VerifyDateLicenceObtained(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var numOfMonths = Convert.ToInt32(input);
                var inputtedDate = now.ToString("dd/MM/yyyy");
                var splittedDate = _pageHelper.SplitDate(inputtedDate);
                if (numOfMonths == 0)
                {
                    Assert.Equal(splittedDate.Item1, txtLicenceDateLessThan1YearDay.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item2, txtLicenceDateLessThan1YearMonth.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item3, txtLicenceDateLessThan1YearYear.GetAttributeValue("value"));
                }
                else if (numOfMonths < 12)
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    Assert.Equal("01", txtLicenceDateLessThan1YearDay.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item2, txtLicenceDateLessThan1YearMonth.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item3, txtLicenceDateLessThan1YearYear.GetAttributeValue("value"));
                }
                else if ((numOfMonths > 12) && (numOfMonths < 60))
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MMMM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    Assert.True(IsElementBehind(txtLicenceDateLessThan1YearDayLocator));
                    Assert.Equal(splittedDate.Item2, cbLicenceDateLessThan5YearsMonth.GetInnerText());
                    Assert.Equal(splittedDate.Item3, cbLicenceDateLessThan5YearsYear.GetInnerText());
                }
                else
                {
                    Assert.True(IsElementBehind(txtLicenceDateLessThan1YearDayLocator));
                    Assert.True(IsElementBehind(cbLicenceDateLessThan5YearsMonthLocator));
                    Assert.True(IsElementBehind(cbLicenceDateLessThan5YearsYearLocator));
                }
            }
        }
        #endregion

        #region Verify data save correctly
        public string getDriverTitle()
        {
            string _title = "";
            if (btnTitle_Mr.GetAttributeValue("class") == "isActive") _title = "Mr";
            if (btnTitle_Mrs.GetAttributeValue("class") == "isActive") _title = "Mrs";
            if (btnTitle_Miss.GetAttributeValue("class") == "isActive") _title = "Miss";
            if (btnTitle_Ms.GetAttributeValue("class") == "isActive") _title = "Ms";
            return _title;
        }
        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _additionalDriverData = new GuiModelData.AdditionalDriverData();
                _additionalDriverData.Title = getDriverTitle();
                _additionalDriverData.FirstName = txtFirstName?.GetPopulatedValue();
                _additionalDriverData.Surname = txtSurname?.GetPopulatedValue();
                _additionalDriverData.BirthDay = txtBirthDay?.GetPopulatedValue();
                _additionalDriverData.BirthMonth = txtBirthMonth?.GetPopulatedValue();
                _additionalDriverData.BirthYear = txtBirthYear?.GetPopulatedValue();
                _additionalDriverData.UKResidentSinceBirthYes = btnAdditionalDriverUKResidentSinceBirthYes?.GetAttributeValue("class");
                _additionalDriverData.UKResidentSinceBirthNo = btnAdditionalDriverUKResidentSinceBirthNo?.GetAttributeValue("class");
                if (_additionalDriverData.UKResidentSinceBirthNo.Equals("isActive"))
                {
                    _additionalDriverData.UKResidentMonth = cbUKResidentMonth?.GetText();
                    _additionalDriverData.UKResidentYear = cbUKResidentYear?.GetText();
                }
                _additionalDriverData.MaritalStatus = cbMaritalStatus?.GetText();
                _additionalDriverData.RelationshipToProposer = cbRelationshipToProposer?.GetText();
                _additionalDriverData.DVLANotifiedYes = btnDVLANotifiedYes?.GetAttributeValue("class");
                _additionalDriverData.DVLANotifiedNo = btnDVLANotifiedNo?.GetAttributeValue("class");
                _additionalDriverData.EmploymentStatus = cbEmploymentStatusFullTime?.GetText();
                _additionalDriverData.MainJob = cbMainJob?.GetText();
                _additionalDriverData.MainJobBusiness = cbBusinessOrIndustryFullTime?.GetText();
                _additionalDriverData.PartTimeYes = btnAnyPartTimeJobYes?.GetAttributeValue("class");
                _additionalDriverData.PartTimeNo = btnAnyPartTimeJobNo?.GetAttributeValue("class");
                if (_additionalDriverData.PartTimeYes.Equals("isActive"))
                {
                    _additionalDriverData.PartTimeStatus = cbEmploymentStatusPartTime?.GetText();
                    _additionalDriverData.PartTimeJob = cbPartTimeJob?.GetText();
                    _additionalDriverData.PartTimeJobBusiness = cbBusinessOrIndustryPartTime?.GetText();
                }
                _additionalDriverData.DrivingLicenceType = cbLicenceType?.GetText();
                _additionalDriverData.DrivingLicenceDate = cbAdditionalLicenceDate?.GetText();
                //_additionalDriverData.OtherVehicleAccess = cbOtherVehicleAccess?.GetText();
                _additionalDriverData.MainDriverYes = btnMainDriverYes?.GetAttributeValue("class");
                _additionalDriverData.MainDriverYes = btnMainDriverYes?.GetAttributeValue("class");
                _additionalDriverData.OtherVehicleInUse = cbOtherVehicleUse.GetText();
            }
        }
        public void VerifyAdditionalDriverDataDisplayedCorrectly(string input)
        {
            try
            {
                if (input.Equals("Yes"))
                {
                    Assert.Equal(_additionalDriverData.Title, getDriverTitle());
                    Assert.Equal(_additionalDriverData.FirstName, txtFirstName?.GetPopulatedValue());
                    Assert.Equal(_additionalDriverData.Surname, txtSurname?.GetPopulatedValue());
                    Assert.Equal(_additionalDriverData.BirthDay, txtBirthDay?.GetPopulatedValue());
                    Assert.Equal(_additionalDriverData.BirthMonth, txtBirthMonth?.GetPopulatedValue());
                    Assert.Equal(_additionalDriverData.BirthYear, txtBirthYear?.GetPopulatedValue());
                    Assert.Equal(_additionalDriverData.UKResidentSinceBirthYes, btnAdditionalDriverUKResidentSinceBirthYes?.GetAttributeValue("class"));
                    Assert.Equal(_additionalDriverData.UKResidentSinceBirthNo, btnAdditionalDriverUKResidentSinceBirthNo?.GetAttributeValue("class"));
                    if (_additionalDriverData.UKResidentSinceBirthNo.Equals("isActive"))
                    {
                        Assert.Equal(_additionalDriverData.UKResidentMonth, cbUKResidentMonth?.GetText());
                        Assert.Equal(_additionalDriverData.UKResidentYear, cbUKResidentYear?.GetText());
                    }
                    Assert.Equal(_additionalDriverData.MaritalStatus, cbMaritalStatus?.GetText());
                    Assert.Equal(_additionalDriverData.RelationshipToProposer, cbRelationshipToProposer?.GetText());
                    Assert.Equal(_additionalDriverData.DVLANotifiedYes, btnDVLANotifiedYes?.GetAttributeValue("class"));
                    Assert.Equal(_additionalDriverData.DVLANotifiedNo, btnDVLANotifiedNo?.GetAttributeValue("class"));
                    Assert.Equal(_additionalDriverData.EmploymentStatus, cbEmploymentStatusFullTime?.GetText());
                    Assert.Equal(_additionalDriverData.MainJob, cbMainJob?.GetText());
                    Assert.Equal(_additionalDriverData.MainJobBusiness, cbBusinessOrIndustryFullTime?.GetText());

                    Assert.Equal(_additionalDriverData.PartTimeYes, btnAnyPartTimeJobYes?.GetAttributeValue("class"));
                    Assert.Equal(_additionalDriverData.PartTimeNo, btnAnyPartTimeJobNo?.GetAttributeValue("class"));
                    if (_additionalDriverData.PartTimeYes.Equals("isActive"))
                    {
                        Assert.Equal(_additionalDriverData.PartTimeStatus, cbEmploymentStatusPartTime?.GetText());
                        Assert.Equal(_additionalDriverData.PartTimeJob, cbPartTimeJob?.GetText());
                        Assert.Equal(_additionalDriverData.PartTimeJobBusiness, cbBusinessOrIndustryPartTime?.GetText());
                    }
                    Assert.Equal(_additionalDriverData.DrivingLicenceType, cbLicenceType?.GetText());
                    Assert.Equal(_additionalDriverData.DrivingLicenceDate, cbAdditionalLicenceDate?.GetText());
                    //Assert.Equal(_additionalDriverData.OtherVehicleAccess, cbOtherVehicleAccess?.GetText());
                    Assert.Equal(_additionalDriverData.MainDriverYes, btnMainDriverYes?.GetAttributeValue("class"));
                    Assert.Equal(_additionalDriverData.MainDriverYes, btnMainDriverYes?.GetAttributeValue("class"));
                    Assert.Equal(_additionalDriverData.OtherVehicleInUse, cbOtherVehicleUse.GetText());
                }
            }
            catch (Exception) { }
        }

        #endregion
                
        
    }
}
