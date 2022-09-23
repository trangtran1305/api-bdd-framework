using SafeGuardMH.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;

namespace SafeGuardMH.Pages
{
    public class AboutYouPage : BasePage
    {

        DateTime now = DateTime.Now;

        public static By aboutYouProgressBar = By.Id("ProgressBarAboutYou");
        By additionalDriverPersonalDetailsSubHeading = By.Id("AdditionalDriverPersonalDetailsSubHeading");

        By txtObtainedLicenceLessThan1YearDayLocator = By.Id("ProposerLicenceDateLessThan1YearDay");
        By txtObtainedLicenceLessThan1YearMonthLocator = By.Id("ProposerLicenceDateLessThan1YearMonth");
        By txtObtainedLicenceLessThan1YearYearLocator = By.Id("ProposerLicenceDateLessThan1YearYear");
        By cbObtainedLicenceLessThan5YearsMonthLocator = By.Id("ProposerLicenceDateLessThan5YearsMonth");
        By cbObtainedLicenceLessThan5YearsYearLocator = By.Id("ProposerLicenceDateLessThan5YearsYear");

        //Your Details
        private static By btnTitle_MrSelector = By.Id("ProposerTitle_Mr");
        private static By btnTitle_MrsSelector = By.Id("ProposerTitle_Mrs");
        private static By btnTitle_MissSelector = By.Id("ProposerTitle_Miss");
        private static By btnTitle_MsSelector = By.Id("ProposerTitle_Ms");
        private Button btnTitle_Mr = new Button(btnTitle_MrSelector);
        private Button btnTitle_Mrs = new Button(btnTitle_MrsSelector);
        private Button btnTitle_Miss = new Button(btnTitle_MissSelector);
        private Button btnTitle_Ms = new Button(btnTitle_MsSelector);
        private Textbox txtFirstName = new Textbox(By.Id("ProposerFirstName"));
        private Textbox txtSurname = new Textbox(By.Id("ProposerSurname"));
        private Textbox txtBirthDay = new Textbox(By.Id("ProposerBirthDay"));
        private Textbox txtBirthMonth = new Textbox(By.Id("ProposerBirthMonth"));
        private Textbox txtBirthYear = new Textbox(By.Id("ProposerBirthYear"));
        private Button btnUKResidentSinceBirthYes = new Button(By.Id("ProposerUKResidentSinceBirthYes"));
        private Button btnUKResidentSinceBirthNo = new Button(By.Id("ProposerUKResidentSinceBirthNo"));
        private Combobox cbUKResidentMonth = new Combobox(By.Id("ProposerUKResidentMonth"));
        private Combobox cbUKResidentYear = new Combobox(By.Id("ProposerUKResidentYear"));
        private Combobox cbMaritalStatus = new Combobox(By.Id("ProposerMaritalStatus"));
        private Button btnDVLANotifiedYes = new Button(By.Id("ProposerDVLANotifiedYes"));
        private Button btnDVLANotifiedNo = new Button(By.Id("ProposerDVLANotifiedNo"));
        private Button btnPersonalDetailNextStep = new Button(By.Id("PersonalDetailsContinueNextStep"));

        //Your Address
        private Textbox txtHouseNumber = new Textbox(By.Id("ProposerHouseNumber"));
        private Textbox txtPostCode = new Textbox(By.Id("ProposerPostcode"));
        private Button btnFindAddress = new Button(By.Id("ProposerFindAddress"));
        private Textbox txtEmail = new Textbox(By.Id("ProposerEmail"));
        private Textbox txtMainPhoneNumber = new Textbox(By.Id("ProposerMainPhoneNumber"));
        private Textbox txtContactTelNumber = new Textbox(By.Id("SecondPhoneNumber"));
        private Button btnAdressNextStep = new Button(By.Id("AddressContinueNextStep"));

        //Employment
        private Combobox cbEmploymentStatusFullTime = new Combobox(By.Id("ProposerEmploymentStatusFullTime"));
        private Combobox cbMainJob = new Combobox(By.Id("ProposerMainJob"));
        private Combobox cbBusinessOrIndustryFullTime = new Combobox(By.Id("ProposerBusinessOrIndustryFullTime"));
        private Button btnAnyPartTimeJobYes = new Button(By.Id("ProposerAnyPartTimeJobYes"));
        private Button btnAnyPartTimeJobNo = new Button(By.Id("ProposerAnyPartTimeJobNo"));
        private Combobox cbEmploymentStatusPartTime = new Combobox(By.Id("ProposerEmploymentStatusPartTime"));
        private Combobox cbPartTimeJob = new Combobox(By.Id("ProposerPartTimeJob"));
        private Combobox cbBusinessOrIndustryPartTime = new Combobox(By.Id("ProposerBusinessOrIndustryPartTime"));
        private Button btnEmploymentNextStep = new Button(By.Id("EmploymentContinueNextStep"));

        //Driving
        private Combobox cbLicenceType = new Combobox(By.Id("ProposerLicenceType"));
        private Combobox cbLicenceDate = new Combobox(By.Id("ProposerLicenceDate"));
        private Textbox txtObtainedLicenceLessThan1YearDay = new Textbox(By.Id("ProposerLicenceDateLessThan1YearDay"));
        private Textbox txtObtainedLicenceLessThan1YearMonth = new Textbox(By.Id("ProposerLicenceDateLessThan1YearMonth"));
        private Textbox txtObtainedLicenceLessThan1YearYear = new Textbox(By.Id("ProposerLicenceDateLessThan1YearYear"));
        private Combobox cbObtainedLicenceLessThan5YearsMonth = new Combobox(By.Id("ProposerLicenceDateLessThan5YearsMonth"));
        private Combobox cbObtainedLicenceLessThan5YearsYear = new Combobox(By.Id("ProposerLicenceDateLessThan5YearsYear"));

        private Combobox cbNCBYear = new Combobox(By.XPath("//*[@role='listbox' and @id='NCBYears']"));
        private Combobox cbNumOfVehicle = new Combobox(By.XPath("//*[@role='listbox' and @id='NumberofVehicleInHousehold']"));
        private Combobox cbPersonalVehicle = new Combobox(By.Id("ProposerOtherVehicleAccess"));
        private Button btnOtherVehicleYes = new Button(By.Id("InsureOtherVehicleYes"));
        private Button btnOtherVehicleNo = new Button(By.Id("InsureOtherVehicleNo"));
        private Button btnCaravanClubMemberYes = new Button(By.Id("CaravanClubMemberYes"));
        private Button btnCaravanClubMemberNo = new Button(By.Id("CaravanClubMemberNo"));
        private static By btnContinueToDriversSelector = By.Id("ProposerContinue");
        private Button btnContinueToDrivers = new Button(btnContinueToDriversSelector);
        private Button btnAboutYouBack = new Button(By.Id("ProposerBack"));
        //Mei: add addressLine1,2
        private Textbox txtProposerAddressLine1 = new Textbox(By.Id("ProposerAddressLine1"));
        private Textbox txtProposerAddressLine2 = new Textbox(By.Id("ProposerAddressLine2"));
        private By address = By.Id("ProposerAddressSummary");

        private static By btnConfirmBackContinueSelector = By.Id("Continue");
        private Button btnConfirmBackContinue = new Button(btnConfirmBackContinueSelector);
        private Label lblErrorMessage = new Label(By.CssSelector(".error__content"));

        public void ClickAboutYouBack(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnAboutYouBack.Click();
            }
        }

        #region Your details
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
                if (txtFirstName.GetPopulatedValue() != input)
                {
                    txtFirstName.Clear();
                    txtFirstName.Input(input);
                }
            }
        }
        public void InputSurname(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtSurname.Clear();
                txtSurname.Input(input);
                if (txtSurname.GetPopulatedValue() != input)
                {
                    txtSurname.Clear();
                    txtSurname.Input(input);
                }
            }
        }
        public void InputDateOfBirth(string input)
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
        public void ClickPermanentUKResidentSinceBirth(string input)
        {
            if (input.Equals("Yes"))
            {
                btnUKResidentSinceBirthYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnUKResidentSinceBirthNo.Click();
            }
        }
        public void SelectPermanentResidentMonth(string input)
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
        public void ClickMedicalConditionDVLANotified(string input)
        {
            if (input.Equals("Yes"))
            {
                btnDVLANotifiedYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnDVLANotifiedNo.Click();
            }
        }
        public void ClickPersonalDetailNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnPersonalDetailNextStep.Click();
            }
        }
        #endregion

        #region Your Adress
        public void InputHouseNameAndNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtHouseNumber.Input(input);
            }
        }
        public void InputPostCode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtPostCode.Clear();
                txtPostCode.Input(input);
            }
        }
        public void ClickFindAddress(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFindAddress.Click();
                WaitForLoadingIconDisappear();
                //btnFindAddress.Click();
                //WaitForLoadingIconDisappear();
                //Thread.Sleep(1500);
                //WaitUntilElementExists(By.Id("ProposerAddressSummary"));
            }
        }
   
        public void InputEmailAdress(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (String.IsNullOrEmpty(txtEmail.GetPopulatedValue()))
                {
                    txtEmail.Clear();
                    txtEmail.Input(input);
                }
            }
        }
        public void InputMobileNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtMainPhoneNumber.Clear();
                txtMainPhoneNumber.Input(input);
            }
        }
        public void InputContactTelNumber(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtContactTelNumber.Clear();
                txtContactTelNumber.Input(input);
            }
        }
        public void ClickAdressNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAdressNextStep.Click();
            }
        }
        #endregion

        #region Employment
        public void SelectEmploymentStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbEmploymentStatusFullTime.SelectByText(input);
            }
        }
        public void InputMainJob(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbMainJob.Input(input);
            }
        }
        public void InputMainJobBusiness(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbBusinessOrIndustryFullTime.Input(input);
            }
        }
        public void ClickPartTimeJobConfirm(string input)
        {
            if (input.Equals("No"))
            {
                btnAnyPartTimeJobNo.Click();
            }
            else if (input.Equals("Yes"))
            {
                btnAnyPartTimeJobYes.Click();
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
        public void ClickEmployeeNextStep(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEmploymentNextStep.Click();
            }
        }
        #endregion

        #region Driving
        public void SelectDrivingLicenceType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbLicenceType.SelectByText(input);
            }
        }
        public void SelectHowLongHeldLicence(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbLicenceDate.SelectByText(input);
            }
        }

        public void InputObtainedLicenceDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                //Thread.Sleep(1000);
                //var numOfMonths = int.Parse(input, NumberStyles.AllowLeadingSign);
                var numOfMonths = Convert.ToInt32(input);
                var inputtedDate = now.ToString("dd/MM/yyyy");
                var splittedDate = _pageHelper.SplitDate(inputtedDate);
                var elements = _driver.FindElements(txtObtainedLicenceLessThan1YearDayLocator);
                bool isTrue = elements.Count > 0;
                if (numOfMonths == 0)
                {
                    txtObtainedLicenceLessThan1YearDay.Clear();
                    txtObtainedLicenceLessThan1YearDay.Input(splittedDate.Item1);
                    txtObtainedLicenceLessThan1YearMonth.Clear();
                    txtObtainedLicenceLessThan1YearMonth.Input(splittedDate.Item2);
                    txtObtainedLicenceLessThan1YearYear.Clear();
                    txtObtainedLicenceLessThan1YearYear.Input(splittedDate.Item3);
                }
                else if (isTrue)
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    txtObtainedLicenceLessThan1YearDay.Clear();
                    txtObtainedLicenceLessThan1YearDay.Input(splittedDate.Item1);
                    txtObtainedLicenceLessThan1YearMonth.Clear();
                    txtObtainedLicenceLessThan1YearMonth.Input(splittedDate.Item2);
                    txtObtainedLicenceLessThan1YearYear.Clear();
                    txtObtainedLicenceLessThan1YearYear.Input(splittedDate.Item3);

                }
                else
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MMMM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    cbObtainedLicenceLessThan5YearsMonth.SelectByText(splittedDate.Item2);
                    cbObtainedLicenceLessThan5YearsYear.SelectByText(splittedDate.Item3);
                }
            }
        }


        public void SelectNCBYears(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbNCBYear.SelectByText(input);
            }
        }
        public void SelectNumOfVehicles(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbNumOfVehicle.SelectByText(input);
            }
        }
        public void SelectPersonalVehicle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbPersonalVehicle.SelectByText(input);
            }
        }
        public void ClickPersonalVehicleStatus(string input)
        {
            if (input.Equals("Yes"))
            {
                btnOtherVehicleYes.Click();
            }
            if (input.Equals("No"))
            {
                btnOtherVehicleNo.Click();
            }
        }
        public void ClickClubMemberStatus(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCaravanClubMemberYes.Click();
            }
            if (input.Equals("No"))
            {
                btnCaravanClubMemberNo.Click();
            }
        }

        public void ClickContinueToDrivers(string input)
        {
            if (input.Equals("Yes"))
            {
                BaseAction.FindAndClick(btnContinueToDriversSelector);
                WaitForLoadingIconDisappear();
                //Thread.Sleep(3000);
                while (_driver.FindElements(btnContinueToDriversSelector).Count > 0)
                {
                    btnContinueToDrivers.Click();
                    WaitForLoadingIconDisappear();
                    //Thread.Sleep(2000);
                }
            }
            WriteLogIfTechnicalError();
        }

        public void ClickContinueToDrivers1(string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                btnContinueToDrivers.Click();
            }
        }

        public void VerifyErrorMessageDisplayed(string input)
        {
            switch (input)
            {
                case "Title":
                case "PermanentUKResidentSinceBirth":
                case "MedicalConditionDVLANotified":
                case "PassTimeJobConfirm":
                case "ClubMemberStatus":
                case "MainDriver ":
                    Assert.Equal("Please select an option to continue.", lblErrorMessage.GetText());
                    break;
                case "Firstname":
                case "Surname":
                case "DOB":
                case "HouseNameAndNumber":
                case "PostCode":
                case "AddressLine1":
                case "AddressLine2":
                case "MainJob":
                case "MainJobBusiness":
                case "PartTimeJob":
                case "BusinessOrIndustryPartTime":
                case "HowLongHeldLicence":
                    Assert.Equal("Please complete this question to continue.", lblErrorMessage.GetText());
                    break;
                case "UKResidentDate":
                    Assert.Equal("Please complete question to continue.", lblErrorMessage.GetText());
                    break;
                case "MarritalStatus":
                case "EmploymentStatus":
                case "PartTimeStatus":
                case "DrivingLicenceType":
                case "NCBYears":
                case "VehicleNumber":
                case "PersonalVehicle":
                case "RelationshipToProposer":
                    Assert.Equal("Please select an answer from the list.", lblErrorMessage.GetText());
                    break;
                case "TelPhone":
                case "MobilePhone":
                    Assert.Equal("Please complete either the Mobile number or Main contact number question to continue.", lblErrorMessage.GetText());
                    break;
                case "AgeLessThan25":
                    Assert.Equal("You must be 25 or over for us to quote.", lblErrorMessage.GetText());
                    break;
                case "AgeMoreThan80":
                    Assert.Equal("Please check your date of birth.", lblErrorMessage.GetText());
                    break;
                default:
                    Console.WriteLine("Have not have scripts to verify this");
                    break;
            }
        }

        public void InputDOBLessThan25(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string date = DateTime.Now.AddYears(-24).ToString("dd/MM/yyyy");
                InputDateOfBirth(date);
            }
        }

        public void InputDOBMoreThan80(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string date = DateTime.Now.AddYears(-80).ToString("dd/MM/yyyy");
                InputDateOfBirth(date);
            }
        }
        #endregion

        #region Verify page displayed
        public void VerifyAboutYouPageTitle(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(btnTitle_MrSelector);
                //Thread.Sleep(5000);
                var result = _driver.FindElement(aboutYouProgressBar).GetAttribute("class");
                Assert.Equal("active", result);
            }
        }
        #endregion

        #region Verify obtained licence in Driving section
        public void VerifyLicenceDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(input, cbLicenceDate.GetInnerText());
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
                    Assert.Equal(splittedDate.Item1, txtObtainedLicenceLessThan1YearDay.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item2, txtObtainedLicenceLessThan1YearMonth.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item3, txtObtainedLicenceLessThan1YearYear.GetAttributeValue("value"));
                }
                else if (numOfMonths < 12)
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    Assert.Equal("01", txtObtainedLicenceLessThan1YearDay.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item2, txtObtainedLicenceLessThan1YearMonth.GetAttributeValue("value"));
                    Assert.Equal(splittedDate.Item3, txtObtainedLicenceLessThan1YearYear.GetAttributeValue("value"));
                }
                else if ((numOfMonths > 12) && (numOfMonths < 60))
                {
                    inputtedDate = now.AddMonths(numOfMonths * (-1)).ToString("dd/MMMM/yyyy");
                    splittedDate = _pageHelper.SplitDate(inputtedDate);
                    Assert.True(IsElementBehind(txtObtainedLicenceLessThan1YearDayLocator));
                    Assert.Equal(splittedDate.Item2, cbObtainedLicenceLessThan5YearsMonth.GetInnerText());
                    Assert.Equal(splittedDate.Item3, cbObtainedLicenceLessThan5YearsYear.GetInnerText());
                }
                else
                {
                    Assert.True(IsElementBehind(txtObtainedLicenceLessThan1YearDayLocator));
                    Assert.True(IsElementBehind(cbObtainedLicenceLessThan5YearsMonthLocator));
                    Assert.True(IsElementBehind(cbObtainedLicenceLessThan5YearsYearLocator));
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
                _aboutYouData = new GuiModelData.AboutYouData();
                _aboutYouData.Title = getDriverTitle();
                _aboutYouData.FirstName = txtFirstName?.GetPopulatedValue();
                _aboutYouData.Surname = txtSurname?.GetPopulatedValue();
                _aboutYouData.BirthDay = txtBirthDay?.GetPopulatedValue();
                _aboutYouData.BirthMonth = txtBirthMonth?.GetPopulatedValue();
                _aboutYouData.BirthYear = txtBirthYear?.GetPopulatedValue();
                _aboutYouData.UKResidentSinceBirthYes = btnUKResidentSinceBirthYes?.GetAttributeValue("class");
                _aboutYouData.UKResidentSinceBirthNo = btnUKResidentSinceBirthNo?.GetAttributeValue("class");
                if (_aboutYouData.UKResidentSinceBirthNo.Equals("isActive"))
                {
                    _aboutYouData.UKResidentMonth = cbUKResidentMonth?.GetText();
                    _aboutYouData.UKResidentYear = cbUKResidentYear?.GetText();
                }
                _aboutYouData.MaritalStatus = cbMaritalStatus?.GetText();
                _aboutYouData.DVLANo = btnDVLANotifiedNo?.GetAttributeValue("class");
                _aboutYouData.DVLAYes = btnDVLANotifiedYes?.GetAttributeValue("class");
                _aboutYouData.HouseNumber = txtHouseNumber?.GetPopulatedValue();
                _aboutYouData.PostCode = txtPostCode?.GetPopulatedValue();
                _aboutYouData.EmailAddress = txtEmail?.GetPopulatedValue();
                _aboutYouData.PhoneNumber = txtMainPhoneNumber?.GetPopulatedValue();
                _aboutYouData.ContactTelNumber = txtContactTelNumber?.GetPopulatedValue();
                _aboutYouData.EmploymentStatus = cbEmploymentStatusFullTime?.GetText();
                _aboutYouData.MainJob = cbMainJob?.GetText();
                _aboutYouData.MainJobBusiness = cbBusinessOrIndustryFullTime?.GetText();

                _aboutYouData.PartTimeYes = btnAnyPartTimeJobYes?.GetAttributeValue("class");
                _aboutYouData.PartTimeNo = btnAnyPartTimeJobNo?.GetAttributeValue("class");
                if (_aboutYouData.PartTimeYes.Equals("isActive"))
                {
                    _aboutYouData.PartTimeStatus = cbEmploymentStatusPartTime?.GetText();
                    _aboutYouData.PartTimeJob = cbPartTimeJob?.GetText();
                    _aboutYouData.PartTimeJobBusiness = cbBusinessOrIndustryPartTime?.GetText();
                }
                _aboutYouData.DrivingLicenceType = cbLicenceType?.GetText();
                _aboutYouData.DrivingLicenceDate = cbLicenceDate?.GetText();
                _aboutYouData.NCBYear = cbNCBYear?.GetText();
                _aboutYouData.NumOfVehicle = cbNumOfVehicle?.GetText();
                _aboutYouData.PersonalVehicleStatus = cbPersonalVehicle?.GetText();
                _aboutYouData.CaravanVehicleYes = btnCaravanClubMemberYes?.GetAttributeValue("class");
                _aboutYouData.CaravanVehicleNo = btnCaravanClubMemberNo?.GetAttributeValue("class");
            }
        }
        public void VerifyProposerDataDisplayedCorrectly(string input)
        {
            try
            {
                if (input.Equals("Yes"))
                {
                    Assert.Equal(_aboutYouData.Title, getDriverTitle());
                    Assert.Equal(_aboutYouData.FirstName, txtFirstName?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.Surname, txtSurname?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.BirthDay, txtBirthDay?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.BirthMonth, txtBirthMonth?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.BirthYear, txtBirthYear?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.UKResidentSinceBirthYes, btnUKResidentSinceBirthYes?.GetAttributeValue("class"));
                    Assert.Equal(_aboutYouData.UKResidentSinceBirthNo, btnUKResidentSinceBirthNo?.GetAttributeValue("class"));
                    if (_aboutYouData.UKResidentSinceBirthNo.Equals("isActive"))
                    {
                        Assert.Equal(_aboutYouData.UKResidentMonth, cbUKResidentMonth?.GetText());
                        Assert.Equal(_aboutYouData.UKResidentYear, cbUKResidentYear?.GetText());
                    }
                    Assert.Equal(_aboutYouData.MaritalStatus, cbMaritalStatus?.GetText());
                    Assert.Equal(_aboutYouData.DVLANo, btnDVLANotifiedNo?.GetAttributeValue("class"));
                    Assert.Equal(_aboutYouData.DVLAYes, btnDVLANotifiedYes?.GetAttributeValue("class"));
                    Assert.Equal(_aboutYouData.HouseNumber, txtHouseNumber?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.PostCode, txtPostCode?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.EmailAddress, txtEmail?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.PhoneNumber, txtMainPhoneNumber?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.ContactTelNumber, txtContactTelNumber?.GetPopulatedValue());
                    Assert.Equal(_aboutYouData.EmploymentStatus, cbEmploymentStatusFullTime?.GetText());
                    Assert.Equal(_aboutYouData.MainJob, cbMainJob?.GetText());
                    Assert.Equal(_aboutYouData.MainJobBusiness, cbBusinessOrIndustryFullTime?.GetText());

                    Assert.Equal(_aboutYouData.PartTimeYes, btnAnyPartTimeJobYes?.GetAttributeValue("class"));
                    Assert.Equal(_aboutYouData.PartTimeNo, btnAnyPartTimeJobNo?.GetAttributeValue("class"));
                    if (_aboutYouData.PartTimeYes.Equals("isActive"))
                    {
                        Assert.Equal(_aboutYouData.PartTimeStatus, cbEmploymentStatusPartTime?.GetText());
                        Assert.Equal(_aboutYouData.PartTimeJob, cbPartTimeJob?.GetText());
                        Assert.Equal(_aboutYouData.PartTimeJobBusiness, cbBusinessOrIndustryPartTime?.GetText());
                    }
                    Assert.Equal(_aboutYouData.DrivingLicenceType, cbLicenceType?.GetText());
                    Assert.Equal(_aboutYouData.DrivingLicenceDate, cbLicenceDate?.GetText());
                    Assert.Equal(_aboutYouData.NCBYear, cbNCBYear?.GetText());
                    Assert.Equal(_aboutYouData.NumOfVehicle, cbNumOfVehicle?.GetText());
                    Assert.Equal(_aboutYouData.PersonalVehicleStatus, cbPersonalVehicle?.GetText());
                    Assert.Equal(_aboutYouData.CaravanVehicleYes, btnCaravanClubMemberYes?.GetAttributeValue("class"));
                    Assert.Equal(_aboutYouData.CaravanVehicleNo, btnCaravanClubMemberNo?.GetAttributeValue("class"));
                }
            }
            catch (Exception) { }
        }        
        #endregion

        public void InputProposerAddressLine1(string input)
        {
            var ele = _driver.FindElements(address);
            if (!String.IsNullOrEmpty(input) && ele.Count==0)
            {
                txtProposerAddressLine1.Input(input);
            }
        }
        public void InputProposerAddressLine2(string input)
        {
            var ele = _driver.FindElements(address);
            if (!String.IsNullOrEmpty(input) && ele.Count == 0)
            {
                txtProposerAddressLine2.Input(input);
            }
        }

        public void ClickConfirmBackContinue (string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(btnConfirmBackContinueSelector);
                btnConfirmBackContinue.Click();
                WaitForLoadingIconDisappear();
                WaitUntilElementExists(VehiclePage.btnRegNumberConfirmSelector);
            }
        }
        


    }
}
