using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{

    public class AssumptionsPage : BasePage
    {
        private By lblWelcome = By.XPath("//app-assumption//h2");
        private By btnSingleBike = By.Id("btnSingle_Bike");
        private By btnContinue = By.Id("btnNext");
        private By lblAssumptionViewList = By.Id("Assumption_ViewList");
        private By popupViewFullList = By.CssSelector("#view-full-list div.modal-body");
        private By btnAgree = By.Id("btnAgree");
        private By btnMultiBike = By.Id("btnMulti_Bike");
        private By lblWarningMessage = By.XPath("//*[ text() = 'Please select single bike or multi-bike before you start.' ]");

        public void VerifyWelcomeLabel(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.Equal(GetElementText(lblWelcome), input);
            }
        }

        public void VerifyBtnSingleBike(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(btnSingleBike));
            }
        }

        public void VerifyBtnNext(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(btnContinue));
            }
        }

        public void ClickBtnSingleBike(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnSingleBike);
            }
        }

        public void ClickBtnNext(string input)
        {
            if (input.Equals("Required"))
            {
                WaitUntilElementExists(btnContinue);
                Thread.Sleep(500);
                ClickByJavascript(btnContinue);
                WaitForLoadingIconDisappear();
                if(_driver.FindElements(btnSingleBike).Count > 0)
                {
                    Click(btnContinue);
                    WaitForLoadingIconDisappear();
                }
            }
        }

        public void ClickAssumptionViewList(string input)
        {
            if (input.Equals("Required"))
            {
                Click(lblAssumptionViewList);
            }
        }

        public void ClickBtnAgree(string input)
        {
            if (input.Equals("Required"))
            {
                //WaitUntilElementVisible(popupViewFullList);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scroll(" + 0 + ", " + 1000 + ");", Find(popupViewFullList));
                WaitUntilElementExists(btnAgree);
                Thread.Sleep(1000);
                ClickByJavascript(btnAgree);
            }
        }
        public void ClickBtnMultiBike(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnMultiBike);
            }
        }

        public void VerifyWarningMessage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                ClickBtnNext("Required");
                Assert.Equal(GetElementText(lblWarningMessage), input);
            }
        }
    }
}
