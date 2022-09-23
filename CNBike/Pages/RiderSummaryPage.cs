using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CNBike.Pages
{
    public class RiderSummaryPage : BasePage
    {
        private By pageTitle = By.CssSelector("app-rider-summary");
        private By btnAdd = By.Id("btnAdd_Rider");
        private By btnNext = By.CssSelector("#RiderSummaryForm #btnNext");
        private By btnBtnRemove_Rider_5 = By.Id("btnRemove_Rider_5");
        private By btnRider_Summary_Y = By.Id("Rider_Summary_Y");
        private By btnRider_Summary_N = By.Id("Rider_Summary_N");
        private By btnBtnEdit_Rider_1 = By.Id("btnEdit_Rider_1");
        private By btnBtnEdit_Rider_2 = By.Id("btnEdit_Rider_2");
        private By btnBtnEdit_Rider_3 = By.Id("btnEdit_Rider_3");
        private By btnBtnEdit_Rider_4 = By.Id("btnEdit_Rider_4");
        private By btnBtnEdit_Rider_5 = By.Id("btnEdit_Rider_5");
        //

        /// <summary>
        /// Check how many rider displayed in Rider Summary Page
        /// X = 1,2,3,4,5
        /// </summary>
        /// 
        public void VerifyXRiderDisplayed(string input)
        {
            switch (input)
            {
                case "1":
                    Assert.True(IsElementDisplayed(btnBtnEdit_Rider_1));
                    break;
                case "2":
                    Assert.True(IsElementDisplayed(btnBtnEdit_Rider_2));
                    break;
                case "3":
                    Assert.True(IsElementDisplayed(btnBtnEdit_Rider_3));
                    break;
                case "4":
                    Assert.True(IsElementDisplayed(btnBtnEdit_Rider_4));
                    break;
                case "5":
                    Assert.True(IsElementDisplayed(btnBtnEdit_Rider_5));
                    break;
            }
        }

        public void ClickBtnAdd(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnAdd);
            }
        }

        public void ClickBtnNext(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                ClickByJavascript(btnNext);
                WaitForLoadingIconDisappear();
            }

        }

        public void ClickBtnAddRider(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnAdd);
                WaitForLoadingIconDisappear();
            }
        }

        public void VerifyPageTitle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }
        
        public void CheckDataInRecallQuoteResponseInTrackingTable(string input)
        {

        }

        public void ClickBtnRemoveRider5(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Click(btnBtnRemove_Rider_5);
                WaitUntilElementExists(btnRider_Summary_Y);
            }
        }

        public void ClickRiderSummary(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    Click(btnRider_Summary_Y);
                }
                else
                {
                    Click(btnRider_Summary_N);
                }
            }
        }
    }
}
