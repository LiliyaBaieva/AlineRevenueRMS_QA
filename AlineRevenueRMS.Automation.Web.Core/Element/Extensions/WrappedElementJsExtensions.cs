using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;
using Serilog;

namespace AlineRevenueRMS.Automation.Web.Core.Element.Extensions
{
    public static class WrappedElementJsExtensions
    {
        public static void ScrollIntoView(this WrappedElement wrappedElement)
        {
            Log.Information($"Scroll with JS into view of '{wrappedElement.Description}'");
            var js = (IJavaScriptExecutor)WrappedDriverManager.GetWebDriver();
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            wrappedElement.Should(Be.InDom);

            while (true)
            {
                js.ExecuteScript("arguments[0].scrollIntoView(true);", wrappedElement.ActualWebElement);
                Thread.Sleep(AppConfiguration.GetPollingInterval());
                if (wrappedElement.IsClickable())
                    break;
            }
        }
    }
}
