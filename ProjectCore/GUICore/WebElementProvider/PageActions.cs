using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.WebElementProvider
{
   public static class PageActions
    {
        public static void ByPassTrialSifinity()
        {
            try
            {
                SitefinityTrialPage sitefinityTrialPage = new SitefinityTrialPage();
                bool isEnable = sitefinityTrialPage.IsEnable();

                if (isEnable)
                {
                    sitefinityTrialPage.ClickOnContinue();
                }
            }
            catch (Exception) { }
        }
        
    }
}
