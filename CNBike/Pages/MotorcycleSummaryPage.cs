using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    public class MotorcycleSummaryPage : BasePage
    {
        private By btnAdd = By.Id("btnAdd");
        private By btnNext = By.Id("btnNext");
        //private By pageTitle = By.Id("MotorcycleSummaryForm");
        By pageTitle = By.XPath("//h4[text()='Your motorcycle summary']");
        private By btnEditVehicle0 = By.Id("btnEdit_Vehicle_0");
        private By btnEditVehicle1 = By.Id("btnEdit_Vehicle_1");
        private By btnEditVehicle2 = By.Id("btnEdit_Vehicle_2"); 
        private By btnEditVehicle3 = By.Id("btnEdit_Vehicle_3");
        private By btnEditVehicle4 = By.Id("btnEdit_Vehicle_4");
        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(1000);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }
        public void ClickBtnAdd(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnAdd);
                WaitForLoadingIconDisappear();
            }
        }

        public void ClickBtnNext(string input)
        {
            var a = _driver.Manage().Cookies.GetCookieNamed("key");
            if (input.Equals("Required"))
            {
                WaitUntilElementClickable(btnNext, 1000);
                Click(btnNext);
                WaitForLoadingIconDisappear();
                if(_driver.FindElements(pageTitle).Count > 0)
                {
                    Click(btnNext);
                    WaitForLoadingIconDisappear();
                }
            }
        }

        public void ClickEditMotorcycle (string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                switch (input)
                {
                    case "0":
                        Click(btnEditVehicle0);
                        Thread.Sleep(2000);
                        break;
                    case "1":
                        Click(btnEditVehicle1);
                        Thread.Sleep(2000);
                        break;
                    case "2":
                        Click(btnEditVehicle2);
                        Thread.Sleep(2000);
                        if (_driver.FindElements(btnEditVehicle2).Count > 0)
                        {
                            Click(btnEditVehicle2);
                        }
                        break;
                    case "3":
                        Click(btnEditVehicle3);
                        break;
                    case "4":
                        Click(btnEditVehicle4);
                        break;
                }
            }
        }
    }
}
