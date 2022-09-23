using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using System.Linq;

namespace ANCarClassic.Pages
{
    public class YourCoverPage : BasePage
    {

        // Your cover
        private Button btnCoverTypeComprehensive = new Button(By.Id("CoverTypeComprehensive"));
        private Button btnCoverTypeThirdPartyFireTheft = new Button(By.Id("CoverTypeThirdPartyFireTheft"));
        private Button btnCoverTypeThirdPartyOnly = new Button(By.Id("CoverTypeThirdPartyOnly"));
        private Combobox cbStartDate = new Combobox(By.Id("StartDate"));
        private Button btnPaymentMethodMonthly = new Button(By.Id("PaymentMethodMonthly"));
        private Button btnPaymentMethodAnnually = new Button(By.Id("PaymentMethodAnnually"));
        private Button btnCoverNextStep = new Button(By.Id("CoverNextStep"));
        private Button btnPreferenceEmail = new Button(By.Id("MarketingPreferenceEmail"));
        private Button btnPreferenceSMS = new Button(By.Id("MarketingPreferenceSMS"));
        private Button btnPreferencePost = new Button(By.Id("MarketingPreferencePost"));
        private Button btnPreferencePhone = new Button(By.Id("MarketingPreferenceTel"));
        private Button btnGroupPartnersYes = new Button(By.Id("GroupPartnersYes"));
        private Button btnGroupPartnersNo = new Button(By.Id("GroupPartnersNo"));

        private static By btnGetQuoteSelector = By.Id("CoverPageGetQuote");
        private Button btnGetQuote = new Button(btnGetQuoteSelector);
        private Button btnCoverPageBack = new Button(By.Id("CoverPageBack"));
        private Button btnProgressBarCover = new Button(By.Id("ProgressBarCover"));

        #region YourCover
        public void SelectTypeOfCover(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                switch (input)
                {
                    case "Comprehensive":
                        btnCoverTypeComprehensive.Click();
                        break;
                    case "Third Party, Fire and Theft":
                        btnCoverTypeThirdPartyFireTheft.Click();
                        break;
                    case "Third Party Only":
                        btnCoverTypeThirdPartyOnly.Click();
                        break;
                }
            }
        }
        public void SelectStartDateFollowingByDay(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                int numOfDays = Convert.ToInt32(input);
                DateTime today = DateTime.UtcNow;
                DateTime startDate = today.AddDays(numOfDays);
                string startDateNew = startDate.ToString("dd MMMMMMMM yyyy");
                cbStartDate.SelectByText(startDateNew);
            }
        }
        public void SelectWayYouPay(string input)
        {
            switch (input)
            {
                case "Monthly":
                    btnPaymentMethodMonthly.Click();
                    break;
                case "Annual":
                    btnPaymentMethodAnnually.Click();
                    break;
            }
        }
        public void ClickCoverNextStep(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnCoverNextStep.Click();
            }
        }
        public void SelectWayPreference(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                List<string> items = input.Split(',').ToList<string>();
                if ((items.Contains("Email") && !btnPreferenceEmail.GetAttributeValue("class").Contains("isActive"))
                    || (!items.Contains("Email") && btnPreferenceEmail.GetAttributeValue("class").Contains("isActive")))
                {
                    btnPreferenceEmail.Click();
                }
                if ((items.Contains("SMS") && !btnPreferenceSMS.GetAttributeValue("class").Contains("isActive"))
                    || (!items.Contains("SMS") && btnPreferenceSMS.GetAttributeValue("class").Contains("isActive")))
                {
                    btnPreferenceSMS.Click();
                }
                if ((items.Contains("Phone") && !btnPreferencePhone.GetAttributeValue("class").Contains("isActive"))
                    || (!items.Contains("Phone") && btnPreferencePhone.GetAttributeValue("class").Contains("isActive")))
                {
                    btnPreferencePhone.Click();
                }
                if ((items.Contains("Post") && !btnPreferencePost.GetAttributeValue("class").Contains("isActive"))
                    || (!items.Contains("Post") && btnPreferencePost.GetAttributeValue("class").Contains("isActive")))
                {
                    btnPreferencePost.Click();
                }
            }
        }
        public void ClickGroupPartners(string input)
        {
            if (input.Equals("Yes"))
            {
                btnGroupPartnersYes.Click();
            }
            else if (input.Equals("No"))
            {
                btnGroupPartnersNo.Click();
            }
        }
        public void ClickGetQuote(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnGetQuote.Click(); ;
                WaitForLoadingIconDisappear();
                Thread.Sleep(2000);
                ClickContinueOnTrialPage();
                WriteLogIfTechnicalError();
            }
        }
        public void ClickBack(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnCoverPageBack.Click();
                WaitUntilElementVisible(HistoryPage.btnHistoryPageContinueSelector);
            }
        }
        public void ClickProgressBarYourCover(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                btnProgressBarCover.Click();
                WaitForLoadingIconDisappear();
            }
        }

        #endregion

        #region Verify page displayed
        public void VerifyYourCoverPageDisplayed(string input)
        {
            if (input.Equals("Yes"))
            {
                var pageTitle = By.Id("coverPageTitle");
                WaitUntilElementVisible(pageTitle);
                bool isTrue = _driver.FindElements(pageTitle).Count > 0;
                Assert.True(isTrue);
            }
        }
        #endregion


        #region Verify data save correctly
        public void SaveToDataModel(string input)
        {
            if (input.Equals("Yes"))
            {
                _yourCoverData = new GuiModelData.YourCoverData();

                _yourCoverData.IsCoverTypeComprehensive = btnCoverTypeComprehensive?.GetAttributeValue("class");
                _yourCoverData.IsCoverTypeThirdPartyAndFireAndTheft = btnCoverTypeThirdPartyFireTheft?.GetAttributeValue("class");
                _yourCoverData.IsCoverTypeThirdPartyOnly = btnCoverTypeThirdPartyOnly?.GetAttributeValue("class");
                _yourCoverData.StartInsuranceDate = cbStartDate?.GetText();
                _yourCoverData.IsInsurancePayByMonthly = btnPaymentMethodMonthly?.GetAttributeValue("class");
                _yourCoverData.IsInsurancePayByAnnualy = btnPaymentMethodAnnually?.GetAttributeValue("class");
                _yourCoverData.IsContactByPhone = btnPreferencePhone?.GetAttributeValue("class");
                _yourCoverData.IsContactByPost = btnPreferencePost?.GetAttributeValue("class");
                _yourCoverData.IsContactByEmail = btnPreferenceEmail?.GetAttributeValue("class");
                _yourCoverData.IsContactBySMS = btnPreferenceSMS?.GetAttributeValue("class");
                if (_yourCoverData.IsContactByPhone == "isActive" || _yourCoverData.IsContactByPost == "isActive"
                    || _yourCoverData.IsContactByEmail == "isActive" || _yourCoverData.IsContactBySMS == "isActive")
                {
                    _yourCoverData.IsGroupPartnersYes = btnGroupPartnersYes?.GetAttributeValue("class");
                    _yourCoverData.IsGroupPartnersNo = btnGroupPartnersNo?.GetAttributeValue("class");
                }
            }
        }

        public void VerifyYourCoverDataDisplayedCorrectly(string input)
        {
            if (input.Equals("Yes"))
            {
                Assert.Equal(_yourCoverData.IsCoverTypeComprehensive, btnCoverTypeComprehensive?.GetAttributeValue("class"));
                Assert.Equal(_yourCoverData.IsCoverTypeThirdPartyAndFireAndTheft, btnCoverTypeThirdPartyFireTheft?.GetAttributeValue("class"));
                Assert.Equal(_yourCoverData.IsCoverTypeThirdPartyOnly, btnCoverTypeThirdPartyOnly?.GetAttributeValue("class"));
                Assert.Equal(_yourCoverData.StartInsuranceDate, cbStartDate?.GetText());
                Assert.Equal(_yourCoverData.IsInsurancePayByMonthly, btnPaymentMethodMonthly?.GetAttributeValue("class"));
                Assert.Equal(_yourCoverData.IsInsurancePayByAnnualy, btnPaymentMethodAnnually?.GetAttributeValue("class"));
                Assert.Equal(_yourCoverData.IsContactByEmail, btnPreferenceEmail?.GetAttributeValue("class"));
                Assert.Equal(_yourCoverData.IsContactBySMS, btnPreferenceSMS?.GetAttributeValue("class"));
                if (_yourCoverData.IsContactByPhone == "isActive" || _yourCoverData.IsContactByPost == "isActive"
                    || _yourCoverData.IsContactByEmail == "isActive" || _yourCoverData.IsContactBySMS == "isActive")
                {
                    Assert.Equal(_yourCoverData.IsGroupPartnersYes, btnGroupPartnersYes?.GetAttributeValue("class"));
                    Assert.Equal(_yourCoverData.IsGroupPartnersNo, btnGroupPartnersNo?.GetAttributeValue("class"));
                }
            }
        }

        #endregion

        public string GetWebReference(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string currentURl = _driver.Url;
                _webReference = currentURl.Substring(currentURl.LastIndexOf("=") + 1);
            }
            return _webReference;

        }
    }
}