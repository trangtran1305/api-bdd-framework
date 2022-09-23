using OpenQA.Selenium;
using ProjectCore.GUICore.DriverProvider;
using System;
using System.Collections.Generic;
using static ProjectCore.GUICore.DriverProvider.DriverProviderFactory;

namespace ProjectCore.Configurations
{
    public class TestConfigs:ConfigsBuilder
    {
        public static IWebDriver _driver;
        public static DriverProviderBase _driverBase;       
        public GlobalSettings GlobalConfig => GetGlobalSettings();
       
        public static IWebDriver InitDriver(string driverName, List<UserProfilePreference> userProfilePreferences, List<Argument> arguments)
        {
            var driverType = (DriverType)Enum.Parse(typeof(DriverType), driverName, true);

            var driverAddition = new DriverAddition();
            if (userProfilePreferences != null)
            {
                driverAddition.UserProfilePreferences = new List<UserProfilePreference>(userProfilePreferences);
            }
            if (arguments != null)
            {
                driverAddition.Arguments = new List<Argument>(arguments);
            }
            var driverFactory = new DriverProviderFactory(driverAddition);
            _driverBase = driverFactory.GetDriverProvider(driverType);
            _driver = _driverBase.GetDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
            return _driver;

        }      
    }
}
