using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.WebDriverConditions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions
{
    public static class JavaScript
    {
        public static Condition<IWebDriver> JsReturnedTrue(string script, params object[] arguments) => new JsReturnedTrue(script, arguments);

        public static Condition<IWebDriver> JavaScriptLoadingComplete() => new JavaScriptLoadingComplete();
    }
}
