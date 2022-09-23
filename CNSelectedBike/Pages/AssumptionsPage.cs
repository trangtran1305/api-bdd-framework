using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;

namespace CNSBike.Pages
{
    public class AssumptionsPage : BasePage
    {
        Button btnContinue = new Button(By.Id("AssumptionPageContinue"));
        private Button btnSingleBike = new Button(By.Id("btnSingle_Bike"));
        private Button btnMultiBike = new Button(By.Id("btnMulti_Bike"));
        public void ClickAssumptionContinue(String data)
        {
            int runCount = 0;
            while ((btnContinue.IsPresent() == false) && runCount < 5)
            {
                _driver.Navigate().Refresh();
                runCount++;
            }
            btnContinue.Click();
            WaitForLoadingIconDisappear();
            PageActions.ByPassTrialSifinity();
            ClickContinueOnTrialPage();
        }
        public void ClickSingleBike(String input)
        {
            ClickContinueOnTrialPage();
                PageActions.ByPassTrialSifinity();
            if (input.Equals("Yes"))
            {
                int runCount = 0;
                while ((btnSingleBike.IsPresent() == false) && runCount < 5)
                {
                    _driver.Navigate().Refresh();
                    runCount++;
                }
                btnSingleBike.Click();
                PageActions.ByPassTrialSifinity();
                ClickContinueOnTrialPage();

            }
        }
        public void ClickMultiBike(String input)
        {
                PageActions.ByPassTrialSifinity();
            ClickContinueOnTrialPage();
            if (input.Equals("Yes"))
            {
                int runCount = 0;
                while ((btnMultiBike.IsPresent() == false) && runCount < 5)
                {
                    _driver.Navigate().Refresh();
                    runCount++;
                }
                btnMultiBike.Click();
                PageActions.ByPassTrialSifinity();
                ClickContinueOnTrialPage();
            }
        }

    }
}
