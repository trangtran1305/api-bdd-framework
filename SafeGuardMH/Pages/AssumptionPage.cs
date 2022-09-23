using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SafeGuardMH.Pages
{
    public class AssumptionPage : BasePage
    {
        LinkText linkFindOutMore = new LinkText(By.Id("GuidelineInfo"));
        LinkText linkPrivacyPolicyHyperlink = new LinkText(By.Id("PrivacyPolicyHyperlink"));
        Label lblDialogTitle = new Label(By.CssSelector(".modal-header > h4"));
        Label lblDialogBody = new Label(By.CssSelector(".modal-body > div"));
        Button btnHelpOverLayInfo = new Button(By.Id("HelpOverLayInfo"));
        Button btnMoreInfoClose = new Button(By.Id("MoreInfoClose"));
        Label lblQuestionDialog = new Label(By.Id("UnspentConvictionHelpTxt"));
        private string currentWindow;

        public void ClickOnFindOutMoreLink(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                linkFindOutMore.Click();
            }
        }

        public void VerifyAnFindOutMoreOverlayDisplayed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Equal("Important", lblDialogTitle.GetText());
                Assert.Contains("We, our insurers or credit provider may carry out checks with external databases such as credit reference agencies and publicly available sources of information for fraud prevention, to verify the information you provide and to assist us in providing a quote.", lblDialogBody.GetText());
            }
        }

        public void ClickOnQuestionIcon(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                btnHelpOverLayInfo.Click();
            }
        }

        public void VerifyAnQuestionOverlayDisplayed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.Contains("Insurers only need to know whether you have any unspent convictions.", lblQuestionDialog.GetText());
            }
        }

        public void ClickOnPrivacyLink(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                currentWindow = _driver.CurrentWindowHandle;
                linkPrivacyPolicyHyperlink.Click();
            }
        }

        public void VerifyPrivacyTabOpened(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                // Get all Open Tabs
                List<String> tabHandles = new List<String>(_driver.WindowHandles);
                bool myNewTabFound = false;

                foreach (string eachHandle in tabHandles)
                {
                    _driver.SwitchTo().Window(eachHandle);
                    // Check Your Page Title 
                    if (_driver.Title.Equals(input))
                    {
                        _driver.Close();

                        //Switch focus to Old tab
                        _driver.SwitchTo().Window(currentWindow);
                        myNewTabFound = true;
                    }
                }
                Assert.True(myNewTabFound);
            }
        }

        public void ClickXSign(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                btnMoreInfoClose.Click();
            }
        }

        public void VerifyTheOverlapClosed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Assert.True(IsElementBehind(By.Id("PrivacyPolicyHyperlink")));
            }
        }
    }
}
