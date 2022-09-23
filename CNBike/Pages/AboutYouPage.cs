using CNBike.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    public class AboutYouPage : BasePage
    {
        private By pageTitle = By.CssSelector("#about-you>h5");
        //Your Details
        private By btnAboutTheDriver_Proposer_Salutation_Mr = By.Id("AboutTheDriver_Proposer_Salutation_Mr");
        private By btnAboutTheDriver_Proposer_Salutation_Mrs = By.Id("AboutTheDriver_Proposer_Salutation_Mrs");
        private By btnAboutTheDriver_Proposer_Salutation_Miss = By.Id("AboutTheDriver_Proposer_Salutation_Miss");
        private By btnAboutTheDriver_Proposer_Salutation_Ms = By.Id("AboutTheDriver_Proposer_Salutation_Ms");

        private By txtAboutTheDriver_Proposer_FirstName = By.Id("AboutTheDriver_Proposer_FirstName");
        private By txtAboutTheDriver_Proposer_Surname = By.Id("AboutTheDriver_Proposer_Surname");
        private By txtautonetDateInputDay_AboutTheDriver_Proposer_DateOfBirth = By.Id("autonetDateInputDay_AboutTheDriver_Proposer_DateOfBirth");
        private By txtautonetDateInputMonth_AboutTheDriver_Proposer_DateOfBirth = By.Id("autonetDateInputMonth_AboutTheDriver_Proposer_DateOfBirth");
        private By txtautonetDateInputYear_AboutTheDriver_Proposer_DateOfBirth = By.Id("autonetDateInputYear_AboutTheDriver_Proposer_DateOfBirth");

        private By btnAboutTheDriver_Proposer_ResidentFromBirth_Y = By.Id("AboutTheDriver_Proposer_ResidentFromBirth_Y");
        private By btnAboutTheDriver_Proposer_ResidentFromBirth_N = By.Id("AboutTheDriver_Proposer_ResidentFromBirth_N");
        private By ddlAboutTheDriver_Proposer_MaritalStatus = By.Id("AboutTheDriver_Proposer_MaritalStatus");
        private By txtAboutTheDriver_Proposer_MaritalStatus = By.XPath("//*[@id='AboutTheDriver_Proposer_MaritalStatus']//span[@class='ng-value-label']");

        //Your Address
        private By txtAboutTheDriver_Proposer_Address_Postcode = By.Id("AboutTheDriver_Proposer_Address_Postcode");
        private By btnbtnlookup_AboutTheDriver_Proposer_Address = By.Id("btnlookup_AboutTheDriver_Proposer_Address");
        private By ddlDdlAddresses = By.Id("ddlAddresses");
        private By btnAboutTheDriver_Proposer_HomeOwner_Y = By.Id("AboutTheDriver_Proposer_HomeOwner_Y");
        private By btnAboutTheDriver_Proposer_HomeOwner_N = By.Id("AboutTheDriver_Proposer_HomeOwner_N");
        private By txtAboutTheDriver_Proposer_EmailAddress = By.Id("AboutTheDriver_Proposer_EmailAddress");
        private By txttxtPropserTelephoneNum = By.Id("txtPropserTelephoneNum");

        //Employment
        private By ddlAboutTheDriver_Proposer_FullTimeEmployment_EmploymentStatus = By.Id("AboutTheDriver_Proposer_FullTimeEmployment_EmploymentStatus");
        private By txtAboutTheDriver_Proposer_FullTimeEmployment_EmploymentStatus = By.XPath("//*[@id='AboutTheDriver_Proposer_FullTimeEmployment_EmploymentStatus']//span[@class='ng-value-label']");
        private By txtAboutTheDriver_Proposer_FullTimeEmployment_OccupationType = By.CssSelector("#AboutTheDriver_Proposer_FullTimeEmployment_OccupationType input");
        private By btnAboutTheDriver_Proposer_FullTimeEmployment_OccupationType = By.XPath("//*[@id='AboutTheDriver_Proposer_FullTimeEmployment_OccupationType']/ng-dropdown-panel//span");
        private By valueAboutTheDriver_Proposer_FullTimeEmployment_OccupationType = By.XPath("//*[@id='AboutTheDriver_Proposer_FullTimeEmployment_OccupationType']//span[@class='ng-value-label']");
        private By txtAboutTheDriver_Proposer_FullTimeEmployment_BusinessType = By.CssSelector("#AboutTheDriver_Proposer_FullTimeEmployment_BusinessType input");
        private By btnAboutTheDriver_Proposer_FullTimeEmployment_BusinessType = By.XPath("//*[@id='AboutTheDriver_Proposer_FullTimeEmployment_BusinessType']/ng-dropdown-panel//span");
        private By valueAboutTheDriver_Proposer_FullTimeEmployment_BusinessType = By.XPath("//*[@id='AboutTheDriver_Proposer_FullTimeEmployment_BusinessType']//span[@class='ng-value-label']");
        private By btnAboutTheDriver_Proposer_HasPartTimeOccupation_Y = By.Id("AboutTheDriver_Proposer_HasPartTimeOccupation_Y");
        private By btnAboutTheDriver_Proposer_HasPartTimeOccupation_N = By.Id("AboutTheDriver_Proposer_HasPartTimeOccupation_N");

        //About your riding
        private By ddlAboutTheDriver_MotorcycleLicenceType = By.Id("AboutTheDriver_MotorcycleLicenceType");
        private By txtAboutTheDriver_MotorcycleLicenceType = By.XPath("//*[@id='AboutTheDriver_MotorcycleLicenceType']//span[@class='ng-value-label']");
        private By ddlAboutTheDriver_YearOfLicence = By.Id("AboutTheDriver_YearOfLicence");
        private By txtAboutTheDriver_YearOfLicence = By.XPath("//*[@id='AboutTheDriver_YearOfLicence']//span[@class='ng-value-label']");
        private By ddlAboutTheDriver_NumberOfMonthLicence = By.Id("AboutTheDriver_NumberOfMonthLicence");
        private By txtAboutTheDriver_NumberOfMonthLicence = By.XPath("//*[@id='AboutTheDriver_NumberOfMonthLicence']//span[@class='ng-value-label']");
        private By ddlAboutTheDriver_MotoringOrganisation = By.Id("AboutTheDriver_MotoringOrganisation");
        private By txtAboutTheDriver_MotoringOrganisation = By.XPath("//*[@id='AboutTheDriver_MotoringOrganisation']//span[@class='ng-value-label']");
        private By ddlAboutTheDriver_AdvancedRider = By.Id("AboutTheDriver_AdvancedRider");
        private By txtAboutTheDriver_AdvancedRider = By.XPath("//*[@id='AboutTheDriver_AdvancedRider']//span[@class='ng-value-label']");

        private By btnBtnNext = By.Id("btnNext");

        private By btnRiderHistory = By.Id("btnRiderHistory");

        // 
        public Rider Rider = new Rider();

        public void ClickBtnRiderHistory(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnRiderHistory);
            }
        }

        
        public void saveDataToCookie()
        {
            var cacheModel = getCookie();
            Rider.index = 0;
            cacheModel.Riders.Add(Rider);
            addCookie(cacheModel);
            //VerifyData("");
        }

        public void ClickBtnNext(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                saveDataToCookie();
            Click(btnBtnNext);
            WaitForLoadingIconDisappear();
                //WaitUntilElementExists(By.Id("btnHasClaim_Y"));
            }
        }

        public void SelectAboutTheDriverAdvancedRider(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.advancedRiderQualifications = input;

                Click(ddlAboutTheDriver_AdvancedRider);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAboutTheDriverMotoringOrganisation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.motoringOrganisation = input;

                Click(ddlAboutTheDriver_MotoringOrganisation);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAboutTheDriverNumberOfMonthLicence(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.monthsOfLicence = input;
                Click(ddlAboutTheDriver_NumberOfMonthLicence);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }

        }

        public void SelectAboutTheDriverYearOfLicence(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.yearsOfLicence = input;

                Click(ddlAboutTheDriver_YearOfLicence);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void SelectAboutTheDriverMotorcycleLicenceType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.yourRiding.motorcycleLicenceType = input;
                Click(ddlAboutTheDriver_MotorcycleLicenceType);
                var option = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(option);
                Click(option);
            }
        }

        public void ClickAboutTheDriverProposerHasPartTimeOccupation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.yesNoAdditionalPartTimeJob = input;

                if (input.Equals("Yes"))
                {
                    Click(btnAboutTheDriver_Proposer_HasPartTimeOccupation_Y);
                }
                else
                {
                    Click(btnAboutTheDriver_Proposer_HasPartTimeOccupation_N);
                }
            }
        }

        public void InputAboutTheDriverProposerFullTimeEmploymentBusinessType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmentIndustryJobOption = input;

                TypeInElement(txtAboutTheDriver_Proposer_FullTimeEmployment_BusinessType, input);
                WaitUntilElementExists(btnAboutTheDriver_Proposer_FullTimeEmployment_BusinessType);
                Click(btnAboutTheDriver_Proposer_FullTimeEmployment_BusinessType);
            }
        }

        public void InputAboutTheDriverProposerFullTimeEmploymentOccupationType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmentMainJobOption = input;

                TypeInElement(txtAboutTheDriver_Proposer_FullTimeEmployment_OccupationType, input);
                WaitUntilElementExists(btnAboutTheDriver_Proposer_FullTimeEmployment_OccupationType);
                Click(btnAboutTheDriver_Proposer_FullTimeEmployment_OccupationType);
            }
        }

        public void SelectAboutTheDriverProposerFullTimeEmploymentEmploymentStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.riderEmployment.employmentStatusOption = input;

                Click(ddlAboutTheDriver_Proposer_FullTimeEmployment_EmploymentStatus);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void InputTxtPropserTelephoneNum(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.address.phoneContact = input;

                TypeInElement(txttxtPropserTelephoneNum, input);
            }
        }

        public void InputAboutTheDriverProposerEmailAddress(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.address.email = input;

                TypeInElement(txtAboutTheDriver_Proposer_EmailAddress, input);
            }
        }

        public void ClickAboutTheDriverProposerHomeOwner(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.address.homeOwner = input;

                if (input.Equals("Yes"))
                {
                    Click(btnAboutTheDriver_Proposer_HomeOwner_Y);
                }
                else
                {
                    Click(btnAboutTheDriver_Proposer_HomeOwner_N);
                }
            }
        }

        public void SelectDdlAddresses(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.address.address = input;

                Click(ddlDdlAddresses);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void ClickBtnlookupAboutTheDriverProposerAddress(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnbtnlookup_AboutTheDriver_Proposer_Address);
                WaitForLoadingIconDisappear();
            }
        }
        public void InputAboutTheDriverProposerAddressPostcode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.address.postCode = input;

                TypeInElement(txtAboutTheDriver_Proposer_Address_Postcode, input);
            }
        }

        public void SelectAboutTheDriverProposerMaritalStatus(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.yourMaritalStatus = input;

                Click(ddlAboutTheDriver_Proposer_MaritalStatus);
                Click(By.XPath("//span[text() = '" + input + "']"));
            }
        }

        public void ClickAboutTheDriverProposerResidentFromBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.yesNoPermanentResident = input;
                if (input.Equals("Yes"))
                {
                    Click(btnAboutTheDriver_Proposer_ResidentFromBirth_Y);
                }
                else
                {
                    Click(btnAboutTheDriver_Proposer_ResidentFromBirth_N);
                }
            }
        }

        public void InputAboutTheDriverProposerDateOfBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                String[] strlist = input.Split('/', 3);
                TypeInElement(txtautonetDateInputDay_AboutTheDriver_Proposer_DateOfBirth, strlist[0]);
                TypeInElement(txtautonetDateInputMonth_AboutTheDriver_Proposer_DateOfBirth, strlist[1]);
                TypeInElement(txtautonetDateInputYear_AboutTheDriver_Proposer_DateOfBirth, strlist[2]);
                var date = new DateType();
                date.day = strlist[0];
                date.month = strlist[1];
                date.years = strlist[2];
                Rider.personalDetails.dateOfBirth = date;
            }
        }

        public void InputAboutTheDriverProposerSurname(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.surName = input;
                TypeInElement(txtAboutTheDriver_Proposer_Surname, "Trinh");
            }
        }

        public void InputAboutTheDriverProposerFirstName(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.firstName = input;
                TypeInElement(txtAboutTheDriver_Proposer_FirstName, "Hoan");
            }
        }

        public void ClickAboutTheDriverProposerSalutation(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Rider.personalDetails.title = input;
                WaitUntilElementExists(btnAboutTheDriver_Proposer_Salutation_Mr);
                switch (input)
                {
                    case "Mr":
                        Click(btnAboutTheDriver_Proposer_Salutation_Mr);
                        break;

                    case "Mrs":
                        Click(btnAboutTheDriver_Proposer_Salutation_Mrs);
                        break;

                    case "Miss":
                        Click(btnAboutTheDriver_Proposer_Salutation_Miss);
                        break;

                    case "Ms":
                        Click(btnAboutTheDriver_Proposer_Salutation_Ms);
                        break;
                }
            }
        }

        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void DemoScript(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                String currentURL = _driver.Url;
                String url = currentURL.Substring(0, currentURL.IndexOf("mc")) + "mc/quote-retrieve";
                NavigateTo("http://192.168.161.36:26000/mc/quote-retrieve");
                TypeInElement(By.Id("WebreferenceTextBox"), "045-942-583");
                //TypeInElement(By.Id("txtQuote_Retrieve_PostCode"), "ST3 5ED");
                Find(By.Id("txtQuote_Retrieve_PostCode")).SendKeys("ST3 5ED");
                ClearText(By.Id("txtQuote_Retrieve_PostCode"));
                TypeInElement(By.Id("autonetDateInputDay_DateOfBirth"), "11");
                TypeInElement(By.Id("autonetDateInputMonth_DateOfBirth"), "04");
                TypeInElement(By.Id("autonetDateInputYear_DateOfBirth"), "1975");
                Click(By.Id("btnRetrieve_Quote"));
                Click(By.Id("btnEdit_Rider_1"));
            }
        }
        public void VerifyData(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var cacheModel = getCookie();
                var RiderIndex = cacheModel.Riders[0];
                var personalDetails = RiderIndex.personalDetails;
                var address = RiderIndex.address;
                var riderEmployment = RiderIndex.riderEmployment;
                var yourRiding = RiderIndex.yourRiding;
                // your detail
                if (!String.IsNullOrEmpty(personalDetails.title))
                {
                    switch (personalDetails.title)
                    {
                        case "Mr":
                            CheckAssertClickBtn(btnAboutTheDriver_Proposer_Salutation_Mr);
                            break;

                        case "Mrs":
                            CheckAssertClickBtn(btnAboutTheDriver_Proposer_Salutation_Mrs);
                            break;

                        case "Miss":
                            CheckAssertClickBtn(btnAboutTheDriver_Proposer_Salutation_Miss);
                            break;

                        case "Ms":
                            CheckAssertClickBtn(btnAboutTheDriver_Proposer_Salutation_Ms);
                            break;
                    }
                }

                CheckAssertData(txtAboutTheDriver_Proposer_FirstName, personalDetails.firstName, TypeFormControl.Input);
                CheckAssertData(txtAboutTheDriver_Proposer_Surname, personalDetails.surName, TypeFormControl.Input);

                if (!String.IsNullOrEmpty(personalDetails.dateOfBirth.day))
                {
                    Assert.True(getTextFromInput(txtautonetDateInputDay_AboutTheDriver_Proposer_DateOfBirth).Equals(personalDetails.dateOfBirth.day, StringComparison.CurrentCultureIgnoreCase));
                    Assert.True(getTextFromInput(txtautonetDateInputMonth_AboutTheDriver_Proposer_DateOfBirth).Equals(personalDetails.dateOfBirth.month, StringComparison.CurrentCultureIgnoreCase));
                    Assert.True(getTextFromInput(txtautonetDateInputYear_AboutTheDriver_Proposer_DateOfBirth).Equals(personalDetails.dateOfBirth.years, StringComparison.CurrentCultureIgnoreCase));
                }

                if (!String.IsNullOrEmpty(personalDetails.yesNoPermanentResident) && personalDetails.yesNoPermanentResident.Equals("Yes"))
                {
                    CheckAssertData(btnAboutTheDriver_Proposer_ResidentFromBirth_Y, "", TypeFormControl.BtnYesNo);
                }
                else
                {
                    CheckAssertData(btnAboutTheDriver_Proposer_ResidentFromBirth_N, "", TypeFormControl.BtnYesNo);
                }

                CheckAssertData(txtAboutTheDriver_Proposer_MaritalStatus, personalDetails.yourMaritalStatus, TypeFormControl.DropDownList);

                // Your address

                // CheckAssertData(txtAboutTheDriver_Proposer_Address_Postcode, address.postCode, TypeFormControl.Input);
                if (!String.IsNullOrEmpty(address.homeOwner) && address.homeOwner.Equals("Yes"))
                {
                    CheckAssertData(btnAboutTheDriver_Proposer_HomeOwner_Y, "", TypeFormControl.BtnYesNo);
                }
                else
                {
                    CheckAssertData(btnAboutTheDriver_Proposer_HomeOwner_N, "", TypeFormControl.BtnYesNo);
                }
                CheckAssertData(txtAboutTheDriver_Proposer_EmailAddress, address.email, TypeFormControl.Input);
                CheckAssertData(txttxtPropserTelephoneNum, address.phoneContact, TypeFormControl.Input);
                //employment
                CheckAssertData(txtAboutTheDriver_Proposer_FullTimeEmployment_EmploymentStatus, riderEmployment.employmentStatusOption, TypeFormControl.DropDownList);
                CheckAssertData(valueAboutTheDriver_Proposer_FullTimeEmployment_OccupationType, riderEmployment.employmentMainJobOption, TypeFormControl.DropDownList);
                CheckAssertData(valueAboutTheDriver_Proposer_FullTimeEmployment_BusinessType, riderEmployment.employmentIndustryJobOption, TypeFormControl.DropDownList);
                if (!String.IsNullOrEmpty(riderEmployment.yesNoAdditionalPartTimeJob) && riderEmployment.yesNoAdditionalPartTimeJob.Equals("Yes"))
                {
                    CheckAssertData(btnAboutTheDriver_Proposer_HasPartTimeOccupation_Y, "", TypeFormControl.BtnYesNo);
                }
                else
                {
                    CheckAssertData(btnAboutTheDriver_Proposer_HasPartTimeOccupation_N, "", TypeFormControl.BtnYesNo);
                }
                //your riding
                CheckAssertData(txtAboutTheDriver_MotorcycleLicenceType, yourRiding.motorcycleLicenceType, TypeFormControl.DropDownList);
                CheckAssertData(txtAboutTheDriver_YearOfLicence, yourRiding.yearsOfLicence, TypeFormControl.DropDownList);
                CheckAssertData(txtAboutTheDriver_NumberOfMonthLicence, yourRiding.monthsOfLicence, TypeFormControl.DropDownList);
                CheckAssertData(txtAboutTheDriver_MotoringOrganisation, yourRiding.motoringOrganisation, TypeFormControl.DropDownList);
                CheckAssertData(txtAboutTheDriver_AdvancedRider, yourRiding.advancedRiderQualifications, TypeFormControl.DropDownList);

            }
        }
    }
}
