using ScenicMH.Pages.GuiModelData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Configurations;
using ProjectCore.GUICore.WebElementProvider;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace CNSBike.Pages
{
    //Should put all common actions here
    public class BasePage
    {
        public IWebDriver _driver => TestConfigs._driver;
        public PageHelper _pageHelper = new PageHelper();
        public static VehicleData _yourMotorcycleData; 
        public static AboutYouData _driverHistoryData; 
        Button btnNext = new Button(By.Id("btnNext"));
        Button btnCover_Next = new Button(By.Id("Cover_Next"));
        public void ClickNextButton(string input)
        {
            //Thread.Sleep(5000);
            btnNext.Click();
            PageActions.ByPassTrialSifinity();                    
        }
        public void ClickCoverNext(string input)
        {           
            if (input.Equals("Yes"))
            {
                //Thread.Sleep(5000);
                var buttonTitle = btnCover_Next.GetText();
                btnCover_Next.Click();              
                PageActions.ByPassTrialSifinity();
                if (buttonTitle.Equals("Get Quote"))
                {
                    //Thread.Sleep(10000);
                }
            }
            
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                WaitUntilElementExists(locator);
                return Find(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for the element to exist in DOM before proceeding
        /// </summary>
        protected void WaitUntilElementExists(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(locator));
        }

        protected IWebElement Find(By locator)
        {
            return _driver.FindElement(locator);
        }

        public string GetValueFromCombobox(By element)
        {
            IWebElement comboBox = _driver.FindElement(element);
            SelectElement selectedValue = new SelectElement(comboBox);
            return selectedValue.SelectedOption.Text;
        }

    }
}
