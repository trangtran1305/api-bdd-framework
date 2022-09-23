using CNSBike.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class AboutYouPage : BasePage
    {
        Label lblAboutYou = new Label(By.CssSelector("div#about-you>h2"));
        private By pageTitle = By.XPath("//h2[text()='About You']");
        Button btnBack = new Button(By.Id("ProposerBack"));
        Button btnProposerTitle_Mr = new Button(By.Id("ProposerTitle_Mr"));
        Button btnProposerTitle_Mrs = new Button(By.Id("ProposerTitle_Mrs"));
        Button btnProposerTitle_Miss = new Button(By.Id("ProposerTitle_Miss"));

        Textbox txtProposerFirstName = new Textbox(By.Id("ProposerFirstName"));
        Textbox txtProposerSurname = new Textbox(By.Id("ProposerSurname"));
        Textbox txtProposerBirthDay = new Textbox(By.Id("ProposerBirthDay"));
        Textbox txtProposerBirthMonth = new Textbox(By.Id("ProposerBirthMonth"));
        Textbox txtProposerBirthYear = new Textbox(By.Id("ProposerBirthYear"));
        Button btnProposerUKResidentSinceBirthYes = new Button(By.Id("ProposerUKResidentSinceBirthYes"));
        Button btnProposerUKResidentSinceBirthNo = new Button(By.Id("ProposerUKResidentSinceBirthNo"));
        Combobox cbProposerMaritalStatus = new Combobox(By.Id("ProposerMaritalStatus"));
        Textbox txtPostCode = new Textbox(By.Id("ProposerPostcodeAddressLookup"));
        Button btnFindAddress = new Button(By.Id("ProposerFindAddress"));
        Combobox cbProposerSelectAddress = new Combobox(By.Id("ProposerSelectAddress"));
        Button btnHomeownerYes = new Button(By.Id("HomeownerYes"));
        Button btnHomeownerNo = new Button(By.Id("HomeownerNo"));
        Textbox txtEmailAddress = new Textbox(By.Id("ProposerEmail"));
        Textbox txtPhoneNumber = new Textbox(By.Id("ProposerMainPhoneNumber"));
        Combobox cbProposerEmploymentStatusFullTime = new Combobox(By.Id("ProposerEmploymentStatusFullTime"));
        Combobox cbTypeOfStudent = new Combobox(By.Id("ProposerStudentType"));
        Button btnProposerAnyPartTimeJobYes = new Button(By.Id("ProposerAnyPartTimeJobYes"));
        Button btnProposerAnyPartTimeJobNo = new Button(By.Id("ProposerAnyPartTimeJobNo"));
        Combobox cbEmploymentStatusPartTime = new Combobox(By.Id("ProposerEmploymentStatusPartTime"));
        Combobox cbPartTimeJob = new Combobox(By.Id("ProposerPartTimeJob"));
        Combobox cbBusinessOrIndustryPartTime = new Combobox(By.Id("ProposerBusinessOrIndustryPartTime"));

        Combobox cbProposerDrivingLicenceType = new Combobox(By.Id("ProposerLicenceType"));
        Combobox cbProposerDrivingLicenceDate = new Combobox(By.Id("ProposerLicenceDate"));
        Combobox cbProposerDrivingLicenceMonth = new Combobox(By.Id("ProposerLicenceMonth"));
        Combobox cbClubMember = new Combobox(By.Id("ClubMember"));
        Combobox cbAdvancedRiderQualification = new Combobox(By.Id("AdvancedRiderQualification"));
        Button btnProposerContinue = new Button(By.Id("ProposerContinue"));
        Textbox txtPassCBTDay = new Textbox(By.Id("PassCBTDay"));
        Textbox txtPassCBTMonth = new Textbox(By.Id("PassCBTMonth"));
        Textbox txtPassCBTYear = new Textbox(By.Id("PassCBTYear"));

        Combobox cbProposerUKResidentMonth = new Combobox(By.Id("ProposerUKResidentMonth"));
        Combobox cbProposerUKResidentYear = new Combobox(By.Id("ProposerUKResidentYear"));
        Button btnEditDriver = new Button(By.Id("EditDriver1"));
        By ProposerAddressSummary = By.Id("ProposerAddressSummary");
        Textbox txtProposerAddressLine1 = new Textbox(By.Id("ProposerAddressLine1"));
        Textbox txtProposerAddressLine2 = new Textbox(By.Id("ProposerAddressLine2"));
        Textbox txtProposerAddressLine3 = new Textbox(By.Id("ProposerAddressLine3"));
        Textbox txtProposerAddressLine4 = new Textbox(By.Id("ProposerAddressLine4"));

        #region Action

        public void ClickEditDriverButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEditDriver.Click();
                Thread.Sleep(2000);
            }
        }
        public void ClickBackButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnBack.Click();
                Thread.Sleep(5000);
                ClickContinueOnTrialPage();
            }
        }

        public void ClickMrButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProposerTitle_Mr.Click();
            }
        }
        public void ClickMissButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProposerTitle_Miss.Click();
            }
        }
        public void InputProposerFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtProposerFirstName.Input(input);
            }
        }
        public void InputProposerSurname(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtProposerSurname.Input(input);
            }
        }
        public void InputProposerBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtProposerBirthDay.Input(splittedDate.Item1);
                txtProposerBirthMonth.Input(splittedDate.Item2);
                txtProposerBirthYear.Input(splittedDate.Item3);
            }
        }
        public void ClickProposerUKResidentSinceBirth(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnProposerUKResidentSinceBirthYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnProposerUKResidentSinceBirthNo.Click();
            }
        }
        public void SelectProposerUKResidentMonth(string month)
        {
            if (month != "")
            {
                cbProposerUKResidentMonth.SelectByText(month);
            }
        }
        public void SelectProposerUKResidentYear(string year)
        {
            if (year != "")
            {
                cbProposerUKResidentYear.SelectByText(year);
            }
        }
        public void SelectProposerMaritalStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbProposerMaritalStatus.SelectByText(input);
            }
        }
        public void InputProposerPostcode(string postcode)
        {
            if (postcode != "")
            {
                txtPostCode.Input(postcode);
            }
        }

        public void SelectPartTimeJob(string proposerPartTimeJob)
        {
            if (!proposerPartTimeJob.Equals(""))
            {
                cbPartTimeJob.Input(proposerPartTimeJob);
            }
        }

        public void SelectBusinessOrIndustryPartTime(string proposerBusinessOrIndustryPartTime)
        {
            if (!proposerBusinessOrIndustryPartTime.Equals(""))
            {
                cbBusinessOrIndustryPartTime.Input(proposerBusinessOrIndustryPartTime);
            }
        }
        #region Address

        public void ClickProposerFindAddress(string input)
        {
            if (input.Equals("Yes"))
            {
                btnFindAddress.Click();
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
                //WaitUntilElementExists(By.Id("ProposerAddressSummary"));

            }
        }
        public void SelectProposerAddress(string address)
        {
            if (!String.IsNullOrEmpty(address))
            {
                var ele = _driver.FindElements(By.Id("ProposerSelectAddress"));
                if (ele.Count > 0)
                {
                    cbProposerSelectAddress.SelectByText(address);

                }
            }
        }
        public void ClickHomeowner(string input)
        {
            if (input.Equals("Yes"))
            {
                btnHomeownerYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnHomeownerNo.Click();
            }
        }

        public void InputProposerEmail(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                txtEmailAddress.Input(email);
            }
        }
        public void InputProposerMainPhoneNumber(string phoneNumber)
        {
            if (!phoneNumber.Equals(""))
            {
                txtPhoneNumber.Input(phoneNumber);
            }
        }
        #endregion
        #region Employment - Driving
        public void InputPassCBT(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtPassCBTDay.Input(splittedDate.Item1);
                txtPassCBTMonth.Input(splittedDate.Item2);
                txtPassCBTYear.Input(splittedDate.Item3);
            }
        }
        public void SelectEmploymentStatusFullTime(string employmentStatus)
        {
            if (!String.IsNullOrEmpty(employmentStatus))
            {
                cbProposerEmploymentStatusFullTime.SelectByText(employmentStatus);
            }
        }
        public void SelectTypeOfStudent(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbTypeOfStudent.SelectByText(input);
            }
        }
        public void ClickAdditionalParttimeJob(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProposerAnyPartTimeJobYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnProposerAnyPartTimeJobNo.Click();
            }
        }
        public void SelectEmploymentStatusPartTime(string proposerEmploymentStatusPartTime)
        {
            if (!proposerEmploymentStatusPartTime.Equals(""))
            {
                cbEmploymentStatusPartTime.SelectByText(proposerEmploymentStatusPartTime);
            }
        }
        public void SelectProposerLicenceType(string proposerLicenceType)
        {
            if (!String.IsNullOrEmpty(proposerLicenceType))
            {
                cbProposerDrivingLicenceType.SelectByText(proposerLicenceType);
            }
        }
        public void SelectProposerLicenceDate(string proposerLicenceDate)
        {
            if (!String.IsNullOrEmpty(proposerLicenceDate))
            {
                cbProposerDrivingLicenceDate.SelectByText(proposerLicenceDate);
            }
        }
        public void SelectProposerLicenceMonth(string proposerLicenceMonth)
        {
            if (!String.IsNullOrEmpty(proposerLicenceMonth))
            {
                cbProposerDrivingLicenceMonth.SelectByText(proposerLicenceMonth);
            }
        }
        public void SelectAOrganizationOrClub(string clubMember)
        {
            if (!String.IsNullOrEmpty(clubMember))
            {
                cbClubMember.SelectByText(clubMember);
            }
        }
        public void SelectAdvancedRiderQualification(string advancedRiderQualification)
        {
            if (!String.IsNullOrEmpty(advancedRiderQualification))
            {
                cbAdvancedRiderQualification.SelectByText(advancedRiderQualification);
            }
        }
        public void EditFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtProposerFirstName.EditInput(input);
            }
        }
        #endregion
        public void ClickContinueButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnProposerContinue.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(10000);
                ClickContinueOnTrialPage();
            }

        }
        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _aboutYouData = new AboutYouData();
                _aboutYouData.FirstName = txtProposerFirstName?.GetPopulatedValue();
                _aboutYouData.Surname = txtProposerSurname?.GetPopulatedValue();
                _aboutYouData.BirthDay = txtProposerBirthDay?.GetPopulatedValue();
                _aboutYouData.BirthMonth = txtProposerBirthMonth?.GetPopulatedValue();
                _aboutYouData.BirthYear = txtProposerBirthYear?.GetPopulatedValue();
                _aboutYouData.UKResidentSinceBirthNo = btnProposerUKResidentSinceBirthNo?.GetAttributeValue("class");
                _aboutYouData.UKResidentSinceBirthYes = btnProposerUKResidentSinceBirthYes?.GetAttributeValue("class");
                _aboutYouData.MaritalStatus = cbProposerMaritalStatus?.GetText();
                _aboutYouData.PostCode = txtPostCode?.GetPopulatedValue();
                _aboutYouData.HomeownerNo = btnHomeownerNo?.GetAttributeValue("class");
                _aboutYouData.HomeownerYes = btnHomeownerYes?.GetAttributeValue("class");
                _aboutYouData.EmailAddress = txtEmailAddress?.GetPopulatedValue();
                _aboutYouData.PhoneNumber = txtPhoneNumber?.GetPopulatedValue();
                _aboutYouData.EmploymentStatus = cbProposerEmploymentStatusFullTime?.GetText();
                _aboutYouData.DrivingLicenceType = cbProposerDrivingLicenceType?.GetText();
                _aboutYouData.DrivingLicenceDate = cbProposerDrivingLicenceDate?.GetText();
                if (cbProposerDrivingLicenceDate.GetText().ToLower().Contains("less than 1 year"))
                {
                    _aboutYouData.DrivingLicenceMonth = cbProposerDrivingLicenceMonth?.GetText();
                }
                _aboutYouData.MemberOfOrganisationOrClub = cbClubMember?.GetText();
                _aboutYouData.AdvancedRiderQualifications = cbAdvancedRiderQualification?.GetText();
            }

        }
        public void VerifyAllDataDisplayed(string input)
        {

            if (input.Equals("Yes"))
            {
                Thread.Sleep(2000);
                Assert.Equal(_aboutYouData.FirstName, txtProposerFirstName?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.Surname, txtProposerSurname?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.BirthDay, txtProposerBirthDay?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.BirthMonth, txtProposerBirthMonth?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.BirthYear, txtProposerBirthYear?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.UKResidentSinceBirthNo, btnProposerUKResidentSinceBirthNo?.GetAttributeValue("class"));
                Assert.Equal(_aboutYouData.UKResidentSinceBirthYes, btnProposerUKResidentSinceBirthYes?.GetAttributeValue("class"));
                Assert.Equal(_aboutYouData.MaritalStatus, cbProposerMaritalStatus?.GetText());
                Assert.Equal(_aboutYouData.PostCode, txtPostCode?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.HomeownerNo, btnHomeownerNo?.GetAttributeValue("class"));
                Assert.Equal(_aboutYouData.HomeownerYes, btnHomeownerYes?.GetAttributeValue("class"));
                Assert.Equal(_aboutYouData.EmailAddress, txtEmailAddress?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.PhoneNumber, txtPhoneNumber?.GetPopulatedValue());
                Assert.Equal(_aboutYouData.EmploymentStatus, cbProposerEmploymentStatusFullTime?.GetText());
                Assert.Equal(_aboutYouData.DrivingLicenceType, cbProposerDrivingLicenceType?.GetText());
                Assert.Equal(_aboutYouData.DrivingLicenceDate, cbProposerDrivingLicenceDate?.GetText());
                if (cbProposerDrivingLicenceDate.GetText().ToLower().Contains("less than 1 year"))
                {
                    Assert.Equal(_aboutYouData.DrivingLicenceMonth, cbProposerDrivingLicenceMonth?.GetText());
                }
                Assert.Equal(_aboutYouData.MemberOfOrganisationOrClub, cbClubMember?.GetText());
                Assert.Equal(_aboutYouData.AdvancedRiderQualifications, cbAdvancedRiderQualification?.GetText());
            }

        }
        #endregion
        #region Verify error message
        public void VerifyAboutYouPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(pageTitle);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }
        #endregion
        public void InputAddressLine1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var element = _driver.FindElements(By.Id("ProposerAddressLine1"));
                if (element.Count > 0)
                {
                    txtProposerAddressLine1.Input(input);
                }
            }
        }
        public void InputAddressLine2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var element = _driver.FindElements(By.Id("ProposerAddressLine2"));
                if (element.Count > 0)
                {
                    txtProposerAddressLine2.Input(input);
                }
            }
        }
        public void InputAddressLine3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var element = _driver.FindElements(By.Id("ProposerAddressLine3"));
                if (element.Count > 0)
                {
                    txtProposerAddressLine3.Input(input);
                }
            }
        }
        public void InputAddressLine4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var element = _driver.FindElements(By.Id("ProposerAddressLine4"));
                if (element.Count > 0)
                {
                    txtProposerAddressLine4.Input(input);
                }
            }
        }
    }
}
