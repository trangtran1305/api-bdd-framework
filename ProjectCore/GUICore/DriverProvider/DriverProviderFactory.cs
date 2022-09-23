using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.DriverProvider
{
    public  class DriverProviderFactory
    {
        public  DriverAddition driverAddition;        
        public DriverProviderFactory(DriverAddition driverAddition)
        {
            this.driverAddition = driverAddition;
            
        }
        public DriverProviderBase GetDriverProvider(DriverType type)
        {
            DriverProviderBase driverBase = null;
            switch (type)
            {
                case DriverType.Chrome:
                    driverBase = new ChromeDriverProvider(driverAddition);
                    break;
                case DriverType.Firefox:
                    driverBase = new FirefoxDriverProvider(driverAddition);
                    break;
                case DriverType.IE:
                    driverBase = new InternetExplorerDriverProvider(driverAddition);
                    break;
            }
            return driverBase;
        }

        public enum DriverType
        {
            Chrome,
            Firefox,
            IE
        }
    }
}
