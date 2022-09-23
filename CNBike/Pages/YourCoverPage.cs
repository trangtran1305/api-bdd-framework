using CNBike.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
namespace CNBike.Pages
{
    public class YourCoverPage : BasePage
    {
        private By pageTitle = By.CssSelector("app-your-cover>div>div>div>div>div>h5");
        private By ddAboutYourVehicleUseOfVehicle = By.Id("AboutYourVehicle_UseOfVehicle");
        private By txtAboutYourVehicleUseOfVehicle = By.XPath("//*[@id='AboutYourVehicle_UseOfVehicle']//span[@class='ng-value-label']");
        private By btnAboutYourVehicleCoverType1 = By.Id("AboutYourVehicle_CoverType_1");
        private By btnAboutYourVehicleCoverType2 = By.Id("AboutYourVehicle_CoverType_2");
        private By btnAboutYourVehicleCoverType3 = By.Id("AboutYourVehicle_CoverType_3");
        private By ddAboutYourVehicleInceptionDate = By.Id("autonetDateInputContainer_AboutYourVehicle_InceptionDate");
        private By txtAboutYourVehicleInceptionDate = By.XPath("//*[@id='autonetDateInputContainer_AboutYourVehicle_InceptionDate']//span[@class='ng-value-label']");
        private By ddAboutYourVehicleInceptionDateFirstOption = By.XPath("//*[@id='autonetDateInputContainer_AboutYourVehicle_InceptionDate']//./div[@class='ng-option'][2]");
        private By btnPaymentType1 = By.Id("btnPaymentType_1");
        private By btnPaymentType2 = By.Id("btnPaymentType_2");
        private By btnContactType1 = By.Id("btnContactType_1");
        private By btnContactType2 = By.Id("btnContactType_2");
        private By btnContactType3 = By.Id("btnContactType_3");
        private By btnContactType4 = By.Id("btnContactType_4");
        private By btnGroupPartnerY = By.Id("btnGroupPartner_Y");
        private By btnGroupPartnerN = By.Id("btnGroupPartner_N");
        private By btnYourCoverNext = By.Id("Your_Cover_Next");
        private By btnYourCoverAgree = By.Id("Your_Cover_Agree");
        private By popupViewFullList = By.CssSelector("ngb-modal-window .modal-body");

        public YourCover YourCover = new YourCover();
        public ContactYou ContactYou = new ContactYou();
        private By btnYourMotorcycle = By.Id("btnYourMotorcycle");
        private By btnBtnAboutYou = By.Id("btnAboutYou"); 
        private By btnYour_Cover_GetQuote = By.Id("Your_Cover_GetQuote");

        public void ClickBtnYourMotorcycle(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(2000);
                Click(btnYourMotorcycle);
                Thread.Sleep(2000);
            }
        }
        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void SelectAboutYourVehicleUseOfVehicle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                YourCover.motorcycleUsed = input;
                Click(ddAboutYourVehicleUseOfVehicle);
                var expectedValue = By.XPath("//span[text() = '" + input + "']");
                WaitUntilElementExists(expectedValue);
                ClickByJavascript(expectedValue);
            }
        }

        public void ClickAboutYourVehicleCoverType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                YourCover.typeOfCover = input;
                if (string.Equals(input.Trim(), CoverType.Comprehensive, StringComparison.CurrentCultureIgnoreCase))
                {
                    Click(btnAboutYourVehicleCoverType1);
                }
                else if (string.Equals(input.Trim(), CoverType.ThirdPartyOnly, StringComparison.CurrentCultureIgnoreCase))
                {
                    Click(btnAboutYourVehicleCoverType3);
                }
                else
                {
                    Click(btnAboutYourVehicleCoverType2);
                }
            }
        }

        public void SelectautonetDateInputContainerAboutYourVehicleInceptionDate(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                YourCover.insuranceStart = input;
                Click(ddAboutYourVehicleInceptionDate);
                WaitUntilElementExists(ddAboutYourVehicleInceptionDateFirstOption);
                ClickByJavascript(ddAboutYourVehicleInceptionDateFirstOption);
            }
        }

        public void ClickPaymentType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                YourCover.lastInsurance = input;

                if (string.Equals(input.Trim(), "Annually", StringComparison.CurrentCultureIgnoreCase))
                {
                    Click(btnPaymentType1);
                }
                else
                {
                    Click(btnPaymentType2);
                }
            }
        }

        public void ClickContactType(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                ContactYou.contactType = input;
                if (input.Contains(ContactType.Post, StringComparison.OrdinalIgnoreCase))
                {
                    Click(btnContactType1);
                }
                if (input.Contains(ContactType.Email, StringComparison.OrdinalIgnoreCase))
                {
                    Click(btnContactType2);
                }
                if (input.Contains(ContactType.Phone, StringComparison.OrdinalIgnoreCase))
                {
                    Click(btnContactType3);
                }
                if (input.Contains(ContactType.SMS, StringComparison.OrdinalIgnoreCase))
                {
                    Click(btnContactType4);
                }
            }
        }

        public void ClickGroupPartner(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                ContactYou.yesNoGroupPartners = input;

                if (input.Equals("Yes"))
                {
                    Click(btnGroupPartnerY);
                }
                else if (input.Equals("No"))
                {
                    Click(btnGroupPartnerN);
                }
            }
        }
        public void saveDataToCookie()
        {
            var cover = new Cover();
            cover.contactYou = ContactYou;
            cover.yourCover = YourCover;
            var cacheModel = getCookie();
            cacheModel.Cover = cover;
            addCookie(cacheModel);
            //verifyData();
        }

        public void ClickBtnYourCoverNext(string input)
        {
            saveDataToCookie();
            if (input.Equals("Required"))
            {
                Thread.Sleep(500);
                Click(btnYourCoverNext);
            }
        }

        public void ClickBtnYourCoverAgree(string input)
        {
            if (input.Equals("Required"))
            {
                WaitUntilElementVisible(popupViewFullList);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scroll(" + 0 + ", " + 1000 + ");", Find(popupViewFullList));
                Thread.Sleep(500);
                WaitUntilElementVisible(btnYourCoverAgree);
                ClickByJavascript(btnYourCoverAgree);
                WaitForLoadingIconDisappear();

                //if (_driver.FindElements(btnYourCoverAgree).Count > 0)
                //{
                //    Click(btnYourCoverAgree);
                //    WaitForLoadingIconDisappear();
                //}
            }
        }

        public void ReturnToRiderSummaryPage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                WaitUntilElementExists(pageTitle);
                Click(btnBtnAboutYou);
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }

        public void ClickYourCoverGetQuote(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {                
                Click(btnYour_Cover_GetQuote);
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }

        public void VerifyData(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var cacheModel = getCookie();
                var yourCover = cacheModel.Cover.yourCover;
                var contactYou = cacheModel.Cover.contactYou;
                //CheckAssertData(txtAboutYourVehicleUseOfVehicle, yourCover.motorcycleUsed, TypeFormControl.DropDownList);
                if (string.Equals(yourCover.typeOfCover, CoverType.Comprehensive, StringComparison.CurrentCultureIgnoreCase))
                {
                    CheckAssertClickBtn(btnAboutYourVehicleCoverType1);
                }
                else if (string.Equals(yourCover.typeOfCover, CoverType.ThirdPartyOnly, StringComparison.CurrentCultureIgnoreCase))
                {
                    CheckAssertClickBtn(btnAboutYourVehicleCoverType3);
                }
                else
                {
                    CheckAssertClickBtn(btnAboutYourVehicleCoverType2);
                }
                //CheckAssertData(txtAboutYourVehicleInceptionDate, yourCover.insuranceStart, TypeFormControl.DropDownList);

                if (!String.IsNullOrEmpty(contactYou.contactType))
                {
                    verifyContactType(contactYou);
                }
            }
        }

        public void verifyContactType(ContactYou contactYou)
        {
            if (contactYou.contactType.Contains(ContactType.Post, StringComparison.OrdinalIgnoreCase))
            {
                CheckAssertClickBtn(btnContactType1);

            }
            if (contactYou.contactType.Contains(ContactType.Email, StringComparison.OrdinalIgnoreCase))
            {
                CheckAssertClickBtn(btnContactType2);

            }
            if (contactYou.contactType.Contains(ContactType.Phone, StringComparison.OrdinalIgnoreCase))
            {
                CheckAssertClickBtn(btnContactType3);

            }
            if (contactYou.contactType.Contains(ContactType.SMS, StringComparison.OrdinalIgnoreCase))
            {
                CheckAssertClickBtn(btnContactType4);
            }

            if (!String.IsNullOrEmpty(contactYou.yesNoGroupPartners) && contactYou.yesNoGroupPartners.Equals("Yes"))
            {
                CheckAssertData(btnGroupPartnerY, "", TypeFormControl.BtnYesNo);
            }
            else
            {
                CheckAssertData(btnGroupPartnerN, "", TypeFormControl.BtnYesNo);
            }
        }


    }
}
