using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class RiderSummaryPage : BasePage
    {
        private By pageTitle = By.Id("RiderSummaryHeading");
        public Button btnContinue = new Button(By.Id("DriverSummaryContinue"));
        public Button btnEdit = new Button(By.Id("EditDriver1"));
        public Button btnEdit2 = new Button(By.Id("EditDriver2"));
        public Button btnAddDriver = new Button(By.Id("AddDriver"));
        public Button btnRemoveDriver2 = new Button(By.Id("RemoveDriver2"));
        public Button btnDeleteDriverConfirmationYes = new Button(By.Id("DeleteDriverConfirmationYes"));
        public Button btnDeleteDriverConfirmationNo = new Button(By.Id("DeleteDriverConfirmationNo"));

        public void VerifyRiderSummaryPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(pageTitle);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void ClickContinueButton(string input)

        {
            if (input.Equals("Yes"))
            {
                btnContinue.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void ClickEditButton(string input)

        {
            if (input.Equals("Yes"))
            {
                btnEdit.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void ClickEdit2Button(string input)

        {
            if (input.Equals("Yes"))
            {
                btnEdit2.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void ClickAddDriverButton(string input)

        {
            if (input.Equals("Yes"))
            {
                btnAddDriver.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }

        public void ClickRemoveDriver2Button(string input)

        {
            if (input.Equals("Yes"))
            {
                btnRemoveDriver2.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }

        public void ClickDeleteDriverConfirmation(string input)

        {
            if (input.Equals("Yes"))
            {
                btnDeleteDriverConfirmationYes.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }

            else if (input.Equals("No"))
            {
                btnDeleteDriverConfirmationNo.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }

        public void VerifyRiderSummaryJustHaveProposer(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(_driver.FindElements(By.Id("EditDriver2")).Count == 0 && btnEdit.IsPresent());
            }
        }
        public void VerifyDataDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.True(btnEdit2.IsPresent() && btnEdit.IsPresent());
            }
        }
    }
}
