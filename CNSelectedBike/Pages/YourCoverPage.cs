using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNSBike.Pages
{
    public class YourCoverPage : BasePage
    {
        private By pageTitle = By.XPath("//*[@id='coverPageTitle']");
        public Button btnBack = new Button(By.Id("CoverPageBack"));
        public Combobox cbVehicleUse = new Combobox(By.Id("VehicleUse"));
        public Combobox cbMultipleVehicleUse = new Combobox(By.Id("MultipleVehicleUse"));
        public Button btnCoverTypeComprehensive = new Button(By.Id("CoverTypeComprehensive"));
        public Button btnCoverTypeThirdPartyFireTheft = new Button(By.Id("CoverTypeThirdPartyFireTheft"));
        public Button btnCoverTypeThirdPartyOnly = new Button(By.Id("CoverTypeThirdPartyOnly"));
        public Combobox cbStartDate = new Combobox(By.Id("StartDate"));
        LinkText linkNotHadPreviousInsurance = new LinkText(By.Id("NotHadPreviousInsurance"));
        public Button btnCoverPageNext = new Button(By.Id("CoverPageNext"));
        public static By btnCoverPageAgreeSelector = By.Id("CoverPageAsssumptionAgree");
        public Button btnCoverPageAgree = new Button(btnCoverPageAgreeSelector);
        public Button btnCoverPageGetQuote = new Button(By.Id("CoverPageGetQuote"));
        public void SelectVehicleUse(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbVehicleUse.SelectByText(input);
            }
        }
        public void SelectMultipleVehicleUse(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                cbMultipleVehicleUse.SelectByText(input);
            }
        }
        public void ClickTypeOfCover(string input)
        {
            if (input.Equals("Comprehensive"))
            {
                btnCoverTypeComprehensive.Click();
            }
            else if (input.Equals("Third Party, Fire and Theft"))
            {
                btnCoverTypeThirdPartyFireTheft.Click();
            }
            else if (input.Equals("Third Party Only"))
            {
                btnCoverTypeThirdPartyOnly.Click();
            }
        }
        public void SelectStartDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Yes"))
                {
                    var startDate = DateTime.Now.AddDays(1).ToString("dd MMMMMMMMM yyyy");
                    cbStartDate.SelectByText(startDate);
                }
                else
                    cbStartDate.SelectByText(input);
            }

        }
        public void ClickLinkNotHadPreviousInsurance(string input)
        {
            if (input.Equals("Yes"))
            {
                linkNotHadPreviousInsurance.Click();
            }
        }

        public void VerifyYourCoverPageTitle(string input)
        {
            ClickContinueOnTrialPage();

            if (input.Equals("Yes"))
            {
                WaitUntilElementExists(pageTitle);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }
        public void ClickBackButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnBack.Click();
                Thread.Sleep(2000);
                ClickContinueOnTrialPage();
            }
        }
        public void ClickCoverPageNextButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCoverPageNext.Click();
                ClickContinueOnTrialPage();
            }
        }

        public void ClickCoverPageAgreeButton(string input)
        {
            if (input.Equals("Yes"))
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.Control).SendKeys(Keys.End).Perform();
                WaitUntilElementExists(btnCoverPageAgreeSelector);
                Thread.Sleep(1000);
                btnCoverPageAgree.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void ClickCoverPageGetQuoteButton(string input)
        {
            if (input.Equals("Yes"))
            {
                btnCoverPageGetQuote.Click();
                WaitForLoadingIconDisappear();
                ClickContinueOnTrialPage();
            }
        }
        public void SaveDataToModel(string input)
        {
            _yourCoverData = new GuiModelData.YourCoverData();
            _yourCoverData.CoverTypeComprehensive = btnCoverTypeComprehensive?.GetAttributeValue("class");
            _yourCoverData.CoverTypeThirdPartyFireTheft = btnCoverTypeThirdPartyFireTheft?.GetAttributeValue("class");
            _yourCoverData.DateInputYear_ClaimDate1 = btnCoverTypeThirdPartyOnly?.GetAttributeValue("class");
            _yourCoverData.StartDate = cbStartDate.GetText();
        }
        public void VerifyAllDataDisplayed(string input)
        {
            Assert.Equal(_yourCoverData.CoverTypeComprehensive , btnCoverTypeComprehensive?.GetAttributeValue("class"));
            Assert.Equal(_yourCoverData.CoverTypeThirdPartyFireTheft , btnCoverTypeThirdPartyFireTheft?.GetAttributeValue("class"));
            Assert.Equal(_yourCoverData.DateInputYear_ClaimDate1 , btnCoverTypeThirdPartyOnly?.GetAttributeValue("class"));
            Assert.Equal(_yourCoverData.StartDate , cbStartDate.GetText());
        }
    }
}
