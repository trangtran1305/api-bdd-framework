using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace CNBike.Pages
{
    class QuoteRetrievePage : BasePage
    {
        public string _webRef = "";

        private By txtWebreferenceTextBox = By.Id("WebreferenceTextBox");
        private By txtTxtQuote_Retrieve_PostCode = By.Id("txtQuote_Retrieve_PostCode");
        private By txtAutonetDateInputDay_DateOfBirth = By.Id("autonetDateInputDay_DateOfBirth");
        private By txtAutonetDateInputMonth_DateOfBirth = By.Id("autonetDateInputMonth_DateOfBirth");
        private By txtAutonetDateInputYear_DateOfBirth = By.Id("autonetDateInputYear_DateOfBirth");
        private By btnBtnRetrieve_Quote = By.Id("btnRetrieve_Quote");
        private By pageTitle = By.Id("recallForm");

        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Thread.Sleep(1000);
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void InputDataFromCache(string input)
        {
            if (input.Equals("Required"))
            {
                var cacheModel = getCookie();
                var dateOfBirth = cacheModel.Riders[0].personalDetails.dateOfBirth;
                TypeInElement(txtWebreferenceTextBox, cacheModel.WebReference);
                TypeInElement(txtTxtQuote_Retrieve_PostCode, cacheModel.Riders[0].address.postCode);
                TypeInElement(txtAutonetDateInputDay_DateOfBirth, dateOfBirth.day);
                TypeInElement(txtAutonetDateInputMonth_DateOfBirth, dateOfBirth.month);
                TypeInElement(txtAutonetDateInputYear_DateOfBirth, dateOfBirth.years);

            }
        }

        public void ClickBtnRetrieveQuote(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnBtnRetrieve_Quote);
                WaitForLoadingIconDisappear();
                Thread.Sleep(1000);
            }
        }

        public void InputDateOfBirth(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                String[] strlist = input.Split('/', 3);
                TypeInElement(txtAutonetDateInputDay_DateOfBirth, strlist[0]);
                TypeInElement(txtAutonetDateInputMonth_DateOfBirth, strlist[1]);
                TypeInElement(txtAutonetDateInputYear_DateOfBirth, strlist[2]);
            }
        }

        public void InputTxtQuoteRetrievePostCode(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtTxtQuote_Retrieve_PostCode, input);
            }
        }

        public void InputWebreferenceTextBox(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Equals("Required"))
                {
                    TypeInElement(txtWebreferenceTextBox, _webRef);
                }
                else
                {
                    TypeInElement(txtWebreferenceTextBox, input);
                }
            }
        }

        public void NavigateToQuoteRetrievePage(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                NavigateTo(_configs.GlobalConfig.BaseUrl + "/mc/quote-retrieve");
            }
        }

        public void GetWebRef(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _webRef = GetWebReference();
            }
        }
    }
}
