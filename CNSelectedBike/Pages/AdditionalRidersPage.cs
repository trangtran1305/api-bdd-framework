using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class AdditionalRidersPage : BasePage
    {
        Button btnAdditionalRiderTitle_Mr = new Button(By.Id("ProposerTitle_Mr"));
        Button btnProposerTitle_Mrs = new Button(By.Id("ProposerTitle_Mrs"));
        Button btnAdditionalRiderTitle_Miss = new Button(By.Id("ProposerTitle_Miss"));

        Textbox txtAdditionalRiderFirstName = new Textbox(By.Id("AdditionalDriverFirstName"));
        Textbox txtAdditionalRiderSurname = new Textbox(By.Id("AdditionalDriverSurname"));
        Textbox txtAdditionalRiderBirthDay = new Textbox(By.Id("AdditionalDriverBirthDay"));
        Textbox txtAdditionalRiderBirthMonth = new Textbox(By.Id("AdditionalDriverBirthMonth"));
        Textbox txtAdditionalRiderBirthYear = new Textbox(By.Id("AdditionalDriverBirthYear"));
        Button btnAdditionalRiderUKResidentSinceBirthYes = new Button(By.Id("AdditionalDriverUKResidentSinceBirthYes"));
        Button btnAdditionalRiderUKResidentSinceBirthNo = new Button(By.Id("AdditionalDriverUKResidentSinceBirthNo"));
        Combobox cbAdditionalRiderMaritalStatus = new Combobox(By.Id("AdditionalDriverMaritalStatus"));
        Combobox cbRelationshipToProposer = new Combobox(By.Id("AdditionalDriverRelationshipToProposer"));
        Combobox cbAdditionalDriverLicenceType = new Combobox(By.Id("AdditionalDriverLicenceType"));
        Combobox cbAdditionalLicenceDate = new Combobox(By.Id("AdditionalLicenceDate"));
        Button btnAdditionalDriverContinue = new Button(By.Id("AdditionalDriverContinue"));
        Combobox cbAdditionalDriverEmploymentStatusFullTime = new Combobox(By.Id("AdditionalDriverEmploymentStatusFullTime"));

        public void ClickMrButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAdditionalRiderTitle_Mr.Click();
            }
        }
        public void ClickMissButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAdditionalRiderTitle_Miss.Click();
            }
        }
        public void InputAdditionalRiderFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtAdditionalRiderFirstName.Input(input);
            }
        }
        public void EditAdditionalRiderFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtAdditionalRiderFirstName.EditInput(input);
            }
        }
        public void InputAdditionalRiderSurname(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                txtAdditionalRiderSurname.Input(input);
            }
        }
        public void InputAdditionalRiderBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var splittedDate = _pageHelper.SplitDate(input);
                txtAdditionalRiderBirthDay.Input(splittedDate.Item1);
                txtAdditionalRiderBirthMonth.Input(splittedDate.Item2);
                txtAdditionalRiderBirthYear.Input(splittedDate.Item3);
            }
        }
        public void ClickAdditionalRiderUKResidentSinceBirth(string input)
        {
            if (String.Equals("Yes", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdditionalRiderUKResidentSinceBirthYes.Click();
            }
            else if (String.Equals("No", input, StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdditionalRiderUKResidentSinceBirthNo.Click();
            }
        }
        public void SelectAdditionalRiderMaritalStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbAdditionalRiderMaritalStatus.SelectByText(input);
            }
        }
        public void SelectRelationshipToProposer(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbRelationshipToProposer.SelectByText(input);
            }
        }

        public void SelectAdditionalDriverLicenceType(string additionalDriverLicenceType)
        {
            if (!String.IsNullOrEmpty(additionalDriverLicenceType))
            {
                cbAdditionalDriverLicenceType.SelectByText(additionalDriverLicenceType);
            }
        }
        public void SelectAdditionalLicenceDate(string additionalLicenceDate)
        {
            if (!String.IsNullOrEmpty(additionalLicenceDate))
            {
                cbAdditionalLicenceDate.SelectByText(additionalLicenceDate);
            }
        }

        public void ClickAdditionalDriverContinue(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAdditionalDriverContinue.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(10000);
                ClickContinueOnTrialPage();

            }

        }

        public void SelectAdditionalDriverEmploymentStatusFullTime(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbAdditionalDriverEmploymentStatusFullTime.SelectByText(input);
            }
        }

        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _additionalRiderData = new GuiModelData.AdditionalRiderData();
                _additionalRiderData.FirstName = txtAdditionalRiderFirstName?.GetPopulatedValue();
                _additionalRiderData.Surname = txtAdditionalRiderSurname?.GetPopulatedValue();
                _additionalRiderData.BirthDay = txtAdditionalRiderBirthDay?.GetPopulatedValue();
                _additionalRiderData.BirthMonth = txtAdditionalRiderBirthMonth?.GetPopulatedValue();
                _additionalRiderData.BirthYear = txtAdditionalRiderBirthYear?.GetPopulatedValue();
                _additionalRiderData.UKResidentSinceBirthNo = btnAdditionalRiderUKResidentSinceBirthNo?.GetAttributeValue("class");
                _additionalRiderData.UKResidentSinceBirthYes = btnAdditionalRiderUKResidentSinceBirthYes?.GetAttributeValue("class");
                _additionalRiderData.MaritalStatus = cbAdditionalRiderMaritalStatus?.GetText();
                _additionalRiderData.EmploymentStatus = cbAdditionalDriverEmploymentStatusFullTime?.GetText();
                _additionalRiderData.DrivingLicenceType = cbAdditionalDriverLicenceType?.GetText();
                _additionalRiderData.DrivingLicenceDate = cbAdditionalLicenceDate?.GetText();
                _additionalRiderData.RelationshipToProposer = cbRelationshipToProposer?.GetText();
            }
        }

        public void VerifyAllDataDisplayed(string input)
        {

            if (input.Equals("Yes"))
            {
                Assert.Equal(_additionalRiderData.FirstName , txtAdditionalRiderFirstName?.GetPopulatedValue());
                Assert.Equal(_additionalRiderData.Surname , txtAdditionalRiderSurname?.GetPopulatedValue());
                Assert.Equal(_additionalRiderData.BirthDay , txtAdditionalRiderBirthDay?.GetPopulatedValue());
                Assert.Equal(_additionalRiderData.BirthMonth , txtAdditionalRiderBirthMonth?.GetPopulatedValue());
                Assert.Equal(_additionalRiderData.BirthYear , txtAdditionalRiderBirthYear?.GetPopulatedValue());
                Assert.Equal(_additionalRiderData.UKResidentSinceBirthNo , btnAdditionalRiderUKResidentSinceBirthNo?.GetAttributeValue("class"));
                Assert.Equal(_additionalRiderData.UKResidentSinceBirthYes , btnAdditionalRiderUKResidentSinceBirthYes?.GetAttributeValue("class"));
                Assert.Equal(_additionalRiderData.MaritalStatus , cbAdditionalRiderMaritalStatus?.GetText());
                Assert.Equal(_additionalRiderData.EmploymentStatus , cbAdditionalDriverEmploymentStatusFullTime?.GetText());
                Assert.Equal(_additionalRiderData.DrivingLicenceType , cbAdditionalDriverLicenceType?.GetText());
                Assert.Equal(_additionalRiderData.DrivingLicenceDate , cbAdditionalLicenceDate?.GetText());
                Assert.Equal(_additionalRiderData.RelationshipToProposer , cbRelationshipToProposer?.GetText());
            }
        }
    }
}
