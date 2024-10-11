using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        public static void ScrollToElement(WrappedElement locator)
        {
            locator.Should(Be.Visible);
            var js = (IJavaScriptExecutor)WrappedDriverManager.GetWebDriver();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", locator);
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

        public static void ScrollDown(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var jsExecutor = (IJavaScriptExecutor)WrappedDriverManager.GetWebDriver();
                jsExecutor.ExecuteScript("window.scrollBy(0, window.innerHeight / 2);");
            }
        }
        public static void ScrollUp(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var jsExecutor = (IJavaScriptExecutor)WrappedDriverManager.GetWebDriver();
                jsExecutor.ExecuteScript("window.scrollBy(0, -window.innerHeight / 2);");
            }
        }

        public static void SubmitAlert()
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
            WrappedDriverManager.GetWebDriver().SwitchTo().Alert().Accept(); // TODO: it is doesn`t work
            //WebDriverWait wait = new WebDriverWait(WrappedDriverManager.GetWebDriver(), TimeSpan.FromSeconds(10));
            //wait.(ExpectedConditions.AlertIsPresent()).Accept();

        }

    }
}
