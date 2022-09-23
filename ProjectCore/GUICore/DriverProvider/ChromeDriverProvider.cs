using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

namespace ProjectCore.GUICore.DriverProvider
{
    public class ChromeDriverProvider: DriverProviderBase
    {
        protected DriverAddition driverAddition;
        public ChromeDriverProvider(DriverAddition driverAddition)
        {
            this.driverAddition = driverAddition;            
        }
        public override IWebDriver CreateDriver()
        {            
            var chromeOptions = new ChromeOptions();
            
            if (driverAddition != null)
            {
                if (driverAddition.UserProfilePreferences != null)
                {
                    foreach (var preference in driverAddition.UserProfilePreferences)
                    {
                        chromeOptions.AddUserProfilePreference(preference.Name, preference.Value);
                    }
                }
                if (driverAddition.Arguments != null)
                {
                    foreach (var argument in driverAddition.Arguments)
                    {
                        chromeOptions.AddArgument(argument.ArgumentName);
                    }
                }
                
               
            }
           //chromeOptions.AddArgument("--headless");
            var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);

            var driver = new ChromeDriver(service, chromeOptions);                   
            return driver;
        }
        public override void KillDriverService()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }
    }
}
