using CNBike.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
namespace CNBike.Pages
{
    public class AdditionalRiderPage : BasePage
    {
        private By btnAdditionalDriverSalutationMr = By.Id("AdditionalDriver_Salutation_Mr");
        private By btnAdditionalDriverSalutationMrs = By.Id("AdditionalDriver_Salutation_Mrs");
        private By btnAdditionalDriverSalutationMiss = By.Id("AdditionalDriver_Salutation_Miss");
        private By btnAdditionalDriverSalutationMs = By.Id("AdditionalDriver_Salutation_Ms");
        private By txtAdditionalDriverFirstName = By.Id("AdditionalDriver_FirstName");
        private By txtAdditionalDriverSurname = By.Id("AdditionalDriver_Surname");
        private By txtAdditionalDriverDateOfBirthDay = By.Id("autonetDateInputDay_AdditionalDriver_DateOfBirth");
        private By txtAdditionalDriverDateOfBirthMonth = By.Id("autonetDateInputMonth_AdditionalDriver_DateOfBirth");
        private By txtAdditionalDriverDateOfBirthYear = By.Id("autonetDateInputYear_AdditionalDriver_DateOfBirth");
        private By btnAdditionalDriverResidentFromBirthY = By.Id("AdditionalDriver_ResidentFromBirth_Y");
        private By btnAdditionalDriverResidentFromBirthN = By.Id("AdditionalDriver_ResidentFromBirth_N");
        private By ddAdditionalDriverResidentSinceMonth = By.Id("autonetDateInputMonth_AdditionalDriver_ResidentSince");
        private By ddAdditionalDriverResidentSinceYear = By.Id("autonetDateInputYear_AdditionalDriver_ResidentSince");

        private By ddAdditionalDriverMaritalStatus = By.Id("AdditionalDriver_MaritalStatus");
        private By txtAdditionalDriverMaritalStatus = By.XPath("//*[@id='AdditionalDriver_MaritalStatus']//span[@class='ng-value-label']");
        private By ddAdditionalDriverRelationshipToProposer = By.Id("AdditionalDriver_RelationshipToProposer");
        private By txtAdditionalDriverRelationshipToProposer = By.XPath("//*[@id='AdditionalDriver_RelationshipToProposer']//span[@class='ng-value-label']");

        //Employment
        private By ddAdditionalDriverFullTimeEmploymentEmploymentStatus = By.Id("AdditionalDriver_FullTimeEmployment_EmploymentStatus");
        private By textAdditionalDriverFullTimeEmploymentEmploymentStatus = By.XPath("//*[@id='AdditionalDriver_FullTimeEmployment_EmploymentStatus']//span[@class='ng-value-label']");

        private By txtAdditionalDriverFullTimeEmploymentOccupationType = By.CssSelector("#AdditionalDriver_FullTimeEmployment_OccupationType input");
        private By btnAdditionalDriverFullTimeEmploymentOccupationType = By.XPath("//*[@id='AdditionalDriver_FullTimeEmployment_OccupationType']/ng-dropdown-panel//span");
        private By textAdditionalDriverFullTimeEmploymentOccupationType = By.XPath("//*[@id='AdditionalDriver_FullTimeEmployment_OccupationType']//span[@class='ng-value-label']");

        private By txtAdditionalDriverFullTimeEmploymentBusinessType = By.CssSelector("#AdditionalDriver_FullTimeEmployment_BusinessType input");
        private By btnAdditionalDriverFullTimeEmploymentBusinessType = By.XPath("//*[@id='AdditionalDriver_FullTimeEmployment_BusinessType']/ng-dropdown-panel//span");
        private By textAdditionalDriverFullTimeEmploymentBusinessType = By.XPath("//*[@id='AdditionalDriver_FullTimeEmployment_BusinessType']//span[@class='ng-value-label']");

        private By btnAdditionalDriverHasPartTimeOccupationNo = By.Id("AdditionalDriver_HasPartTimeOccupation_N");
        private By btnAdditionalDriverHasPartTimeOccupationYes = By.Id("AdditionalDriver_HasPartTimeOccupation_Y");
        private By ddAdditionalDriverPartTimeEmploymentEmploymentStatus = By.Id("AdditionalDriver_PartTimeEmployment_EmploymentStatus");

        private By txtAdditionalDriverPartTimeEmploymentOccupationType = By.CssSelector("#AdditionalDriver_PartTimeEmployment_OccupationType input");
        private By btnAdditionalDriverPartTimeEmploymentOccupationType = By.XPath("//*[@id='AdditionalDriver_PartTimeEmployment_OccupationType']/ng-dropdown-panel//span");

        private By txtAdditionalDriverPartTimeEmploymentBusinessType = By.CssSelector("#AdditionalDriver_PartTimeEmployment_BusinessType input");
        private By btnAdditionalDriverPartTimeEmploymentBusinessType = By.XPath("//*[@id='AdditionalDriver_PartTimeEmployment_BusinessType']/ng-dropdown-panel//span");
        // riding
        private By ddMotorcycleLicenceType = By.Id("MotorcycleLicenceType");
        private By txtMotorcycleLicenceType = By.XPath("//*[@id='MotorcycleLicenceType']//span[@class='ng-value-label']");
        private By ddAdditionalDriverYearOfLicence = By.Id("AdditionalDriver_YearOfLicence");
        private By txtAdditionalDriverYearOfLicence = By.XPath("//*[@id='AdditionalDriver_YearOfLicence']//span[@class='ng-value-label']");
        private By ddAdditionalDriveNumberOfMonthLicence = By.Id("AdditionalDrive_NumberOfMonthLicence");
        private By txtAdditionalDriveNumberOfMonthLicence = By.XPath("//*[@id='AdditionalDrive_NumberOfMonthLicence']//span[@class='ng-value-label']");
        private By txtAutonetDateInputDayMotorcycleLicenceObtained = By.Id("autonetDateInputDay_MotorcycleLicenceObtained");
        private By txtAutonetDateInputMonthMotorcycleLicenceObtained = By.Id("autonetDateInputMonth_MotorcycleLicenceObtained");
        private By txtAutonetDateInputYearMotorcycleLicenceObtained = By.Id("autonetDateInputYear_MotorcycleLicenceObtained");
        private By btnNext = By.Id("btnNext");

        // 
        public Rider Rider = new Rider();

        public void ClickAdditionalDriverSalutation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.title = input;
                switch (input)
                {
                    case "Mr":
                        Click(btnAdditionalDriverSalutationMr);
                        break;
                    case "Mrs":
                        Click(btnAdditionalDriverSalutationMrs);
                        break;
                    case "Miss":
                        Click(btnAdditionalDriverSalutationMiss);
                        break;
                    case "Ms":
                        Click(btnAdditionalDriverSalutationMs);
                        break;
                }
            }
        }

        public void InputAdditionalDriverFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.firstName = input;

                TypeInElement(txtAdditionalDriverFirstName, input);
            }
        }
        public void InputAdditionalDriverSurname(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.surName = input;
                TypeInElement(txtAdditionalDriverSurname, input);
            }
        }

        public void InputAdditionalDriverDateOfBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                String[] strlist = input.Split('/', 3);
                TypeInElement(txtAdditionalDriverDateOfBirthDay, strlist[0]);
                TypeInElement(txtAdditionalDriverDateOfBirthMonth, strlist[1]);
                TypeInElement(txtAdditionalDriverDateOfBirthYear, strlist[2]);

                var date = new DateType();
                date.day = strlist[0];
                date.month = strlist[1];
                date.years = strlist[2];
                Rider.personalDetails.dateOfBirth = date;
            }
        }

        public void ClickAdditionalDriverResidentFromBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.yesNoPermanentResident = input;

                if (input.Equals("Yes"))
                {
                    Click(btnAdditionalDriverResidentFromBirthY);
                }
                else
                {
                    Click(btnAdditionalDriverResidentFromBirthN);
                }
            }
        }

        public void SelectAutonetDateInputMonthAdditionalDriverResidentSince(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.permanentResidentMonth = input;

                Click(ddAdditionalDriverResidentSinceMonth);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAutonetDateInputYearAdditionalDriverResidentSince(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.permanentResidentYear = input;

                Click(ddAdditionalDriverResidentSinceYear);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAdditionalDriverResidentSince(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                String[] strlist = input.Split('/', 2);
                SelectAutonetDateInputMonthAdditionalDriverResidentSince(strlist[0]);
                SelectAutonetDateInputYearAdditionalDriverResidentSince(strlist[1]);
            }
        }

        public void SelectAdditionalDriverMaritalStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.yourMaritalStatus = input;

                Click(ddAdditionalDriverMaritalStatus);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAdditionalDriverRelationshipToProposer(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.relationshipStatus = input;

                Click(ddAdditionalDriverRelationshipToProposer);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAdditionalDriverFullTimeEmploymentEmploymentStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmentStatusOption = input;
                Click(ddAdditionalDriverFullTimeEmploymentEmploymentStatus);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAdditionalDriverFullTimeEmploymentOccupationType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmentMainJobOption = input;
                TypeInElement(txtAdditionalDriverFullTimeEmploymentOccupationType, input);
                Click(btnAdditionalDriverFullTimeEmploymentOccupationType);
            }
        }
        public void SelectAdditionalDriverFullTimeEmploymentBusinessType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmentIndustryJobOption = input;
                TypeInElement(txtAdditionalDriverFullTimeEmploymentBusinessType, input);
                Click(btnAdditionalDriverFullTimeEmploymentBusinessType);
            }
        }

        public void InputAdditionalDriverFullTimeEmploymentOccupationType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtAdditionalDriverFullTimeEmploymentOccupationType, input);
                WaitUntilElementExists(btnAdditionalDriverFullTimeEmploymentOccupationType);
                Click(btnAdditionalDriverFullTimeEmploymentOccupationType);
            }
        }
        public void InputAdditionalDriverFullTimeEmploymentBusinessType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtAdditionalDriverFullTimeEmploymentBusinessType, input);
                WaitUntilElementExists(btnAdditionalDriverFullTimeEmploymentBusinessType);
                Click(btnAdditionalDriverFullTimeEmploymentBusinessType);
            }
        }

        public void ClickAdditionalDriverHasPartTimeOccupation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.yesNoAdditionalPartTimeJob = input;
                if (input.Equals("Yes"))
                {
                    Click(btnAdditionalDriverHasPartTimeOccupationYes);
                }
                else
                {
                    Click(btnAdditionalDriverHasPartTimeOccupationNo);
                }
            }
        }

        public void SelectAdditionalDriverPartTimeEmploymentEmploymentStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmenPartTimeJobStatusJobOption = input;

                Click(ddAdditionalDriverPartTimeEmploymentEmploymentStatus);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAdditionalDriverPartTimeEmploymentOccupationType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmenIndustryPartTimeJobInJobOption = input;

                TypeInElement(txtAdditionalDriverPartTimeEmploymentOccupationType, input);
                WaitUntilElementExists(btnAdditionalDriverPartTimeEmploymentOccupationType);
                Click(btnAdditionalDriverPartTimeEmploymentOccupationType);
            }
        }
        public void SelectAdditionalDriverPartTimeEmploymentBusinessType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmenPartTimeJobInJobOption = input;

                TypeInElement(txtAdditionalDriverPartTimeEmploymentBusinessType, input);
                WaitUntilElementExists(btnAdditionalDriverPartTimeEmploymentBusinessType);
                Click(btnAdditionalDriverPartTimeEmploymentBusinessType);
            }
        }

        public void InputAdditionalDriverPartTimeEmploymentOccupationType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtAdditionalDriverPartTimeEmploymentOccupationType, input);
                Click(btnAdditionalDriverPartTimeEmploymentOccupationType);
            }
        }
        public void InputAdditionalDriverPartTimeEmploymentBusinessType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtAdditionalDriverPartTimeEmploymentBusinessType, input);
                WaitUntilElementExists(btnAdditionalDriverPartTimeEmploymentBusinessType);
                Click(btnAdditionalDriverPartTimeEmploymentBusinessType);
            }
        }

        public void SelectMotorcycleLicenceType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.motorcycleLicenceType = input;
                Click(ddMotorcycleLicenceType);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }
        public void SelectAdditionalDriverYearOfLicence(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.yearsOfLicence = input;

                Click(ddAdditionalDriverYearOfLicence);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAdditionalDriveNumberOfMonthLicence(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(ddAdditionalDriveNumberOfMonthLicence);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void InputAutonetDateInputYearMotorcycleLicenceObtained(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.dateCBT = input;

                String[] strList = input.Split('/', 3);
                TypeInElement(txtAutonetDateInputDayMotorcycleLicenceObtained, strList[0]);
                TypeInElement(txtAutonetDateInputMonthMotorcycleLicenceObtained, strList[1]);
                TypeInElement(txtAutonetDateInputYearMotorcycleLicenceObtained, strList[2]);
            }
        }

        public void saveDataToCookie()
        {
            var cacheModel = getCookie();
            Rider.index = cacheModel.Riders.Count;
            cacheModel.Riders.Add(Rider);
            addCookie(cacheModel);
          //  verifyData(Rider.index.ToString());
        }

        public void ClickBtnNext(string input)
        {
            saveDataToCookie();
            if (input.Equals("Required"))
            {
                Click(btnNext);
                WaitForLoadingIconDisappear();
            }
        }

        public void verifyData(string riderIndex)
        {
            var cacheModel = getCookie();
            var RiderIndex = cacheModel.Riders[Int16.Parse(riderIndex)];
            var personalDetails = RiderIndex.personalDetails;
            var address = RiderIndex.address;
            var riderEmployment = RiderIndex.riderEmployment;
            var yourRiding = RiderIndex.yourRiding;
            if (!String.IsNullOrEmpty(personalDetails.title))
            {
                switch (personalDetails.title)
                {
                    case "Mr":
                        CheckAssertClickBtn(btnAdditionalDriverSalutationMr);
                        break;

                    case "Mrs":
                        CheckAssertClickBtn(btnAdditionalDriverSalutationMrs);
                        break;

                    case "Miss":
                        CheckAssertClickBtn(btnAdditionalDriverSalutationMiss);
                        break;

                    case "Ms":
                        CheckAssertClickBtn(btnAdditionalDriverSalutationMs);
                        break;
                }
            }
            CheckAssertData(txtAdditionalDriverFirstName, personalDetails.firstName, TypeFormControl.Input);
            CheckAssertData(txtAdditionalDriverSurname, personalDetails.surName, TypeFormControl.Input);

            if (!String.IsNullOrEmpty(personalDetails.dateOfBirth.day))
            {
                Assert.True(getTextFromInput(txtAdditionalDriverDateOfBirthDay).Equals(personalDetails.dateOfBirth.day, StringComparison.CurrentCultureIgnoreCase));
                Assert.True(getTextFromInput(txtAdditionalDriverDateOfBirthMonth).Equals(personalDetails.dateOfBirth.month, StringComparison.CurrentCultureIgnoreCase));
                Assert.True(getTextFromInput(txtAdditionalDriverDateOfBirthYear).Equals(personalDetails.dateOfBirth.years, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!String.IsNullOrEmpty(personalDetails.yesNoPermanentResident) && personalDetails.yesNoPermanentResident.Equals("Yes"))
            {
                CheckAssertData(btnAdditionalDriverResidentFromBirthY, "", TypeFormControl.BtnYesNo);
            }
            else
            {
                CheckAssertData(btnAdditionalDriverResidentFromBirthN, "", TypeFormControl.BtnYesNo);
            }

            CheckAssertData(txtAdditionalDriverMaritalStatus, personalDetails.yourMaritalStatus, TypeFormControl.DropDownList);
            CheckAssertData(txtAdditionalDriverRelationshipToProposer, personalDetails.relationshipStatus, TypeFormControl.DropDownList);
            // Employment
            CheckAssertData(textAdditionalDriverFullTimeEmploymentEmploymentStatus, riderEmployment.employmentStatusOption, TypeFormControl.DropDownList);
            CheckAssertData(textAdditionalDriverFullTimeEmploymentOccupationType, riderEmployment.employmentMainJobOption, TypeFormControl.DropDownList);
            CheckAssertData(textAdditionalDriverFullTimeEmploymentBusinessType, riderEmployment.employmentIndustryJobOption, TypeFormControl.DropDownList);
            if (!String.IsNullOrEmpty(riderEmployment.yesNoAdditionalPartTimeJob) && riderEmployment.yesNoAdditionalPartTimeJob.Equals("Yes"))
            {
                CheckAssertData(btnAdditionalDriverHasPartTimeOccupationYes, "", TypeFormControl.BtnYesNo);
            }
            else
            {
                CheckAssertData(btnAdditionalDriverHasPartTimeOccupationNo, "", TypeFormControl.BtnYesNo);
            }
            // your Riding
            CheckAssertData(txtMotorcycleLicenceType, yourRiding.motorcycleLicenceType, TypeFormControl.DropDownList);
            CheckAssertData(txtAdditionalDriverYearOfLicence, yourRiding.yearsOfLicence, TypeFormControl.DropDownList);
            CheckAssertData(txtAdditionalDriveNumberOfMonthLicence, yourRiding.monthsOfLicence, TypeFormControl.DropDownList);

        }
    }
}
