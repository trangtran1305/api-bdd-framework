using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Threading;
using Xunit;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;

namespace ANCarClassic.Pages
{
    public class DriversPage : BasePage
    {
        public static By driverSummarySubHeading = By.Id("DriverSummarySubHeading");
        public static By btnContinueToHistorySelector = By.Id("DriverSummaryContinue");
        private Button btnContinueToHistory = new Button(btnContinueToHistorySelector);
        private static By btnAddDriverSelector = By.Id("AddDriver");
        private Button btnAddDriver = new Button(btnAddDriverSelector);
        private By txtTitleName = By.XPath("(//div[@class='questionset__summary__content'])[1]/p[1]");
        private By txtDateOfBirth = By.XPath("(//div[@class='questionset__summary__content'])[1]/p[2]");
        private By mainDriver1 = By.Id("MainDriver1");
        private By mainDriver2 = By.Id("MainDriver2");

        private Button btnRemoveDriver2 = new Button(By.Id("RemoveDriver2"));
        private Button btnDeleteDriverConfirmationYes = new Button(By.Id("DeleteDriverConfirmationYes"));
        private Button btnDeleteDriverConfirmationNo = new Button(By.Id("DeleteDriverConfirmationNo"));
        private By txtTitleName2 = By.XPath("(//div[@class='questionset__summary__content'])[2]/p[1]");
        private Button btnSetMainDriver2 = new Button(By.Id("SetMainDriver2"));
        private By btnDeleteDriverConfirmationClaimConvictionConflictYes = By.Id("DeleteDriverConfirmationClaimConvictionConflictYes");
        private By btnDeleteDriverConfirmationClaimConvictionConflictNo = By.Id("DeleteDriverConfirmationClaimConvictionConflictNo");

        private Button btnDriverSummaryBack = new Button(By.Id("DriverSummaryBack"));
        private Button btnEditAdditionalDriver = new Button(By.Id("EditDriver2"));

        private By MainDriverSummary = By.XPath("(//*[@class='questionset__summary__content'])[1]");
        private By MainDriverLabel = By.XPath("(//*[@class='questionset__summary__content'])[1]/following-sibling::div/div/span");
        private By AdditionalDriverSummary = By.XPath("(//*[@class='questionset__summary__content'])[2]");
        private By SetAsMainDriverButton = By.Id("SetMainDriver2");

        public void ClickEditAdditionalDriver(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEditAdditionalDriver.Click();
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }

        public void ClickContinueToHistory(string input)
        {
            if (input.Equals("Yes"))
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.Control).SendKeys(Keys.End).Perform();
                WaitUntilElementVisible(btnContinueToHistorySelector);
                BaseAction.FindAndClick(btnContinueToHistorySelector);
                WaitForLoadingIconDisappear();
                while (_driver.FindElements(btnContinueToHistorySelector).Count > 0)
                {
                    WaitUntilElementVisible(btnContinueToHistorySelector);
                    btnContinueToHistory.Click();
                    WaitForLoadingIconDisappear();
                }
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
        public void ClickDriverPageBack(string input)
        {
            if (input.Equals("Yes"))
            {
                btnDriverSummaryBack.Click();

                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }

        public void ClickAddDriver(string input)
        {
            if (input.Equals("Yes"))
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.Control).SendKeys(Keys.End).Perform();
                BaseAction.FindAndClick(btnAddDriverSelector);
                WaitForLoadingIconDisappear();
                while (_driver.FindElements(btnAddDriverSelector).Count > 0)
                {
                    btnAddDriver.Click();
                    WaitForLoadingIconDisappear();
                }

                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
       
        public void ClickRemoveDriver2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Thread.Sleep(1500);
                btnRemoveDriver2.Click();
            }
        }

        public void ClickDeleteDriverConfirmationYes(string input)
        {
            if (input.Equals("Yes"))
            {
                btnDeleteDriverConfirmationYes.Click();
            }
        }

        public void ClickDeleteDriverConfirmationNo(string input)
        {
            if (input.Equals("Yes"))
            {
                btnDeleteDriverConfirmationNo.Click();
            }
        }
        public void ClickSetMainDriver2(string input)
         {
            if (input.Equals("Yes"))
            {
                btnSetMainDriver2.Click();
            }
        }

        #region Verify page displayed
        public void VerifyDriversPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(MainDriverSummary);
                var elements = _driver.FindElements(btnContinueToHistorySelector);
                bool isTrue = elements.Count > 0;
                Assert.True(isTrue);
            }
        }
        public void VerifyTitleNameDisplayedCorrectly(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtTitleName));
                string titleName = _driver.FindElement(txtTitleName).Text;
                Assert.Equal(input, titleName);
            }
        }
        public void VerifyAddDriverContinueButtonDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(btnAddDriver.IsPresent());
                Assert.True(btnContinueToHistory.IsPresent());
            }
        }
        public void VerifyDriver2Displayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(txtTitleName2));
            }
        }
        public void VerifyDriver2Removed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Thread.Sleep(1500);
                Assert.True(IsElementBehind(txtTitleName2));
            }
        }
        public void VerifyProposerIsMainDriver(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(mainDriver1));
            }
        }
        
        public void VerifyNoDriverIsSetMainDriver(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementBehind(mainDriver1));
            }
        }
        public void VerifyDeleteDriverConfirmationClaimConvictionDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(btnDeleteDriverConfirmationClaimConvictionConflictNo));
                Assert.True(IsElementDisplayed(btnDeleteDriverConfirmationClaimConvictionConflictYes));
            }
        }
        public void VerifyDeleteDriverConfirmationDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(By.Id("DeleteDriverConfirmationNo")));
                Assert.True(IsElementDisplayed(By.Id("DeleteDriverConfirmationYes")));
            }
        }
        public void VerifyButtonAddDriverDisappeared(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementBehind(By.Id("AddDriver")));
            }
        }
        public void VerifyDateOfBirthFormat(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

                //Verify whether date entered in dd/MM/yyyy format.
                bool isValid = regex.IsMatch(input.Trim());
                Assert.True(isValid);
            }
        }
        public void VerifySetAsMainDriverDisplayed(string input)
        {
            switch (input)
            {

                case "2":
                    Assert.True(IsElementDisplayed(By.Id("SetMainDriver2")));
                    break;
                case "3":
                    Assert.True(IsElementDisplayed(By.Id("SetMainDriver3")));
                    break;
                case "4":
                    Assert.True(IsElementDisplayed(By.Id("SetMainDriver4")));
                    break;
                case "5":
                    Assert.True(IsElementDisplayed(By.Id("SetMainDriver5")));
                    break;

            }
        }
        #endregion

        #region Verify Driver Summary
        public void VerifyMainDriverSummaryCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(MainDriverSummary);
                var driverSummaryTable = _driver.FindElement(MainDriverSummary);
                string actualDriverName = driverSummaryTable.FindElement(By.XPath("./p[1]")).GetAttribute("innerText");
                string expectedDriverName = _aboutYouData.Title + " " + _aboutYouData.FirstName + " " + _aboutYouData.Surname;
                Assert.Equal(expectedDriverName, actualDriverName);
                string actualBirthDay = driverSummaryTable.FindElement(By.XPath("./p[2]")).GetAttribute("innerText");
                string expectedBirthDay = _aboutYouData.BirthDay + "/" + _aboutYouData.BirthMonth + "/" + _aboutYouData.BirthYear;
                Assert.Equal(expectedBirthDay, actualBirthDay);
                Assert.False(IsElementBehind(MainDriverLabel));
            }
        }

        public void VerifyAdditionalDriverSummaryCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                WaitUntilElementVisible(AdditionalDriverSummary);
                var driverSummaryTable = _driver.FindElement(AdditionalDriverSummary);
                string actualDriverName = driverSummaryTable.FindElement(By.XPath("./p[1]")).GetAttribute("innerText");
                string expectedDriverName = _additionalDriverData.Title + " "
                    + _additionalDriverData.FirstName + " " + _additionalDriverData.Surname;
                Assert.Equal(expectedDriverName, actualDriverName);
                string actualBirthDay = driverSummaryTable.FindElement(By.XPath("./p[2]")).GetAttribute("innerText");
                string expectedBirthDay = _additionalDriverData.BirthDay + "/"
                    + _additionalDriverData.BirthMonth + "/" + _additionalDriverData.BirthYear;
                Assert.Equal(expectedBirthDay, actualBirthDay);
                Assert.False(IsElementBehind(SetAsMainDriverButton));
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
