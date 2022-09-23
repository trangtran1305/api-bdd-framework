using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class MotorcycleSummaryPage : YourMotorcyclePage
    {
        private By pageTitle = By.Id("vehicleSummaryHeading");
        public Button btnEdit = new Button(By.Id("editVehicle0"));
        public Button btnAddMotorcycle = new Button(By.Id("addVehicle"));
        public Button btnRemove = new Button(By.Id("removeVehicle1"));
        public Button btnContinue = new Button(By.Id("vehicleSummaryContinue"));
        public Button btnDeleteVehicleConfirmationYes = new Button(By.Id("DeleteVehicleConfirmationNo"));
        public Button btnYesContinue = new Button(By.Id("changeJourneyContinue"));
        By motocycleInfor = By.XPath("//*[@id='MotorcycleSummaryForm']/div[1]/div[1]/div[2]/p");
        public Button btnEdit1 = new Button(By.Id("editVehicle1"));

        //public void VerifyMotocycleInfomation(string input)
        //{
        //    if (!String.IsNullOrEmpty(input))
        //    {
        //        var element = _driver.FindElements(motocycleInfor);
        //        foreach (var ele in element)
        //        {
        //            Assert.True(ele.Displayed);

        //        }
        //    }
        //}
        public void ClickEdit1(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEdit1.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                //Thread.Sleep(2000);
            }
        }
        public void ClickRemoveButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnRemove.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                //Thread.Sleep(1000);
            }
        }

        public void ClickDeleteVehicleConfirmationYesButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnDeleteVehicleConfirmationYes.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                //Thread.Sleep(1000);
            }
        }

        public void VerifyAdditionalMotorcycleIsRemoved(string input)
        {
            if (input.Equals("Yes"))
            {
                bool isRemoved = false;
                try
                {
                    bool isDisplayed = btnRemove.IsPresent();
                }
                catch (Exception)
                {
                    isRemoved = true;
                }
                Assert.True(isRemoved);
            }
        }

        public void VerifyMotorcycleSummaryPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(pageTitle);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void ClickEditButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnEdit.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
                //Thread.Sleep(1000);
            }
        }

        public void ClickAddAnotherMotocycle(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAddMotorcycle.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }

        public void ClickContinueButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnContinue.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(1000);
                ClickContinueOnTrialPage();

            }
        }

        public void ClickYesContinueButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnYesContinue.Click();
                WaitForLoadingIconDisappear();
                //Thread.Sleep(5000);
                ClickContinueOnTrialPage();

            }
        }

    }
}
