using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CNBike.Pages
{
    public class DirectDebitPage: BasePage
    {
        private By txtDirectDebit_NameOfHolder = By.Id("DirectDebit_NameOfHolder");
        private By txtDirectDebit_SortCode1 = By.Id("DirectDebit_SortCode1");
        private By txtDirectDebit_SortCode2 = By.Id("DirectDebit_SortCode2");
        private By txtDirectDebit_SortCode3 = By.Id("DirectDebit_SortCode3");
        private By txtDirectDebit_AccountNumber = By.Id("DirectDebit_AccountNumber");
        private By btnDirectDebit_BtnConfirm = By.Id("DirectDebit_BtnConfirm");
        private By btnDirectDebit_BtnContinue = By.Id("DirectDebit_BtnContinue");
        public void VerifyPageTitle(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(true);
            }
        }
        public void ClickBtnConfirm(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnDirectDebit_BtnConfirm);
            }
        }
        public void ClickBtnContinue(string input)
        {
            if (input.Equals("Yes"))
            {
                Click(btnDirectDebit_BtnContinue);
                WaitForLoadingIconDisappear();
            }
        }
        public void InputNameOfHolder(string input)
        {
            TypeInElement(txtDirectDebit_NameOfHolder, input);
        }
        public void InputSortCode(string input)
        {
            if (input != "")
            {
                string[] codePart = input.Split("-");
                string part1 = codePart[0];
                string part2 = codePart[1];
                string part3 = codePart[2];
                TypeInElement(txtDirectDebit_SortCode1, part1);
                TypeInElement(txtDirectDebit_SortCode2, part2);
                TypeInElement(txtDirectDebit_SortCode3, part3);
            }
        }
        
        public void InputAccountNumber(string input)
        {
            TypeInElement(txtDirectDebit_AccountNumber, input);
        }
    }
}

//form[@id='DirectDebit_Form']//span[text()='Total monthly payment']