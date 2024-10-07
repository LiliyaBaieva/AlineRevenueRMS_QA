using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;
using Serilog;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages.Base
{
    public class BasePage
    {
        public static string Title => WrappedDriverManager.Title;
        public static string Url => WrappedDriverManager.GetUrl;

        public static void RefreshPage() => WrappedDriverManager.Refresh();
        public static void ClosePage() => WrappedDriverManager.Close();
        public static void OpenNewTab() => WrappedDriverManager.OpenNewTab();
        public static void SwitchToTheFirstTab() => WrappedDriverManager.SwitchToTheFirstTab();
        public static void Openlink(Uri link) => WrappedDriverManager.Open(link);

        public static void SwitchToTheLastTab()
        {
            WrappedDriverManager.SwitchToTheLastTab();
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
        }

        public static void ScrollToBottom()
        {
            Log.Information($"Scroll with JS to bottom of the page");
            var js = (IJavaScriptExecutor)WrappedDriverManager.GetWebDriver();
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void ScrollToHeader()
        {
            Log.Information($"Scroll with JS to header of the page");
            var js = (IJavaScriptExecutor)WrappedDriverManager.GetWebDriver();
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        public static void SwitchIFrame(int index = 0)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
            var frames = new WrappedElementsCollection(With.TagName("iframe"), "IFrame").Should(Have.CountAtLeast(1));
            WrappedDriverManager.GetWebDriver().SwitchTo().Frame(frames[index].ActualWebElement);
        }

        public static void SwitchToDefaultContent()
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
            WrappedDriverManager.GetWebDriver().SwitchTo().DefaultContent();
        }
    }
}
