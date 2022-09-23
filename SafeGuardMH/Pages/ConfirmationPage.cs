using SafeGuardMH.Pages.GuiModelData;
using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using System.Linq;

namespace SafeGuardMH.Pages
{
    public class ConfirmationPage : BasePage
    {
        private Button btnConfirmationPageNext = new Button(By.XPath("//*[@id='mainNavigation']/button[@class='next btn btn-primary']"));
        private Button btnBack = new Button(By.CssSelector(".back.btn"));

        public void VerifyConfirmationPageDisplayed(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(By.XPath("//*[@id='mainNavigation']/button[@class='next btn btn-primary']")));
            }
        }

        public void ClickOnBackButton(string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                btnBack.Click();
            }
        }
    }
}
