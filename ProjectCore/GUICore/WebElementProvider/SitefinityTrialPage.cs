using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class SitefinityTrialPage
    {
        private Label title = new Label(By.CssSelector("body > div > h1"));
        
        private Button btnContinue = new Button(By.CssSelector("body > div > p > a"));
        public bool IsEnable()
        {
            if (title.ValueWithOutWait().Contains("You are running a trial version of Sitefinity"))
            {
                return true;
            }
            return false;
        }
        public void ClickOnContinue()
        {
            btnContinue.Click();
        }
    }
}
