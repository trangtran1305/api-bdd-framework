using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class JavaScriptActions
    {
        public static string JsValue(IWebElement element)
        {
            string value = JavascriptExecutor.Execute("return arguments[0].innerText;", element).ToString();
            return value;
        }
    }
}
