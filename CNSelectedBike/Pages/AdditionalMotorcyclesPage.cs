using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CNSBike.Pages
{
    public class AdditionalMotorcyclesPage : YourMotorcyclePage
    {
        public Button btnAddMotorcycleNext = new Button(By.XPath("//div[2]/button[@id='VehiclePageContinue']"));

        public void ClickAddMotorcycleNext(string input)
        {
            if (input.Equals("Yes"))
            {
                btnAddMotorcycleNext.Click();
                //Thread.Sleep(2000);
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
    }
}
