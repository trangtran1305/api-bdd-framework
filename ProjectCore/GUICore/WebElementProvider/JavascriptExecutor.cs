using OpenQA.Selenium;
using ProjectCore.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class JavascriptExecutor
    {
        private static IWebDriver driver = TestConfigs._driver;
        private static IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        public static object Execute(string script)
        {
            object result = js.ExecuteScript(script);
            return result;
        }

        public static object Execute(string script, IWebElement element)
        {
            object result = js.ExecuteScript(script, element);
            return result;
        }
    }
}
