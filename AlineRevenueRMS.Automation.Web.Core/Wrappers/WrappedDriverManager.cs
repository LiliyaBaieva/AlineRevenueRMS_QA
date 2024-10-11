using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Core.Configuration.Models;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using static AlineRevenueRMS.Automation.Web.Core.Logger.Logger;

namespace AlineRevenueRMS.Automation.Web.Core.Wrappers
{
    public static class WrappedDriverManager
    {
        private static readonly AppConfig Config;

        static WrappedDriverManager()
        {
            Initialize();
            Config = ConfigurationManager.GetConfiguration<AppConfig>();
        }

        public static void InitWebDriver()
        {
            DriverManager.CommonDriver.Value = DriverManager.GetWebDriver(Config.HeadlessMode);
            DriverManager.CommonDriver.Value.Manage().Window.Maximize();
        }

        public static IWebDriver GetWebDriver()
        {
            return DriverManager.CommonDriver.Value;
        }

        public static WrappedElement Find(By locator, string description)
        {
            return new WrappedElement(locator, description);
        }

        public static WrappedElement Find(IWebElement element, IWebDriver driver, string description)
        {
            return new WrappedElement(element, driver, description);
        }

        public static WrappedElement Find(By locator, IWebDriver driver, string description)
        {
            return new WrappedElement(locator, new WrappedDriver(driver), description);
        }

        public static WrappedElementsCollection FindAll(By locator, string description)
        {
            return new WrappedElementsCollection(locator, description);
        }

        public static WrappedElementsCollection FindAll(IList<IWebElement> elements, IWebDriver driver,
            string description)
        {
            return new WrappedElementsCollection(elements, driver, description);
        }

        public static WrappedElementsCollection FindAll(By locator, IWebDriver driver, string description)
        {
            return new WrappedElementsCollection(locator, new WrappedDriver(driver), description);
        }

        public static void Open(string url)
        {
            Log.Information($"Open url: {url}");
            GetWebDriver().Navigate().GoToUrl(url);
        }

        public static void Open(Uri url)
        {
            Log.Information($"Open url: {url}");
            GetWebDriver().Navigate().GoToUrl(url);
        }

        public static void Refresh() => GetWebDriver().Navigate().Refresh();

        public static void Close() => GetWebDriver().Close();

        public static void OpenNewTab()
        {
            Log.Information($"Open a new tab");
            ((IJavaScriptExecutor)GetWebDriver()).ExecuteScript("window.open();");
        }

        public static void SwitchToTheFirstTab()
        {
            Log.Information($"Switch to the first tab");
            var handle = GetWebDriver().WindowHandles.First();
            GetWebDriver().SwitchTo().Window(handle);
        }

        public static void SwitchToTheLastTab()
        {
            Log.Information($"Switch to the last tab");
            WaitTo(WindowsTabs.WindowsTabsCountShouldBeAtLeast(2));
            Log.Debug($"Windows handles={GetWebDriver().WindowHandles.Count}");
            var handle = GetWebDriver().WindowHandles.Last();
            GetWebDriver().SwitchTo().Window(handle);
        }

        public static string Title => GetWebDriver().Title;
        public static string GetUrl => GetWebDriver().Url;

        public static IWebDriver WaitTo(Condition<IWebDriver> condition)
        {
            return WaitFor(GetWebDriver(), condition);
        }

        public static IWebDriver WaitTo(Condition<IWebDriver> condition, int seconds)
        {
            return WaitFor(GetWebDriver(), condition, TimeSpan.FromSeconds(seconds));
        }

        public static TResult WaitFor<TResult>(TResult sEntity, Condition<TResult> condition)
        {
            return WaitFor(sEntity, condition, AppConfiguration.GetTimeout());
        }

        public static TResult WaitForNot<TResult>(TResult sEntity, Condition<TResult> condition)
        {
            return WaitForNot(sEntity, condition, AppConfiguration.GetTimeout());
        }

        public static TResult WaitFor<TResult>(TResult sEntity, Condition<TResult> condition, TimeSpan timeout)
        {
            Exception? lastException = null;
            var clock = new SystemClock();
            var otherDateTime = clock.LaterBy(timeout);
            var ignoredExceptionTypes = new[] {
                typeof(WebDriverException),
                typeof(IndexOutOfRangeException),
                typeof(ArgumentOutOfRangeException)
            };

            while (true)
            {
                try
                {
                    if (condition.Apply(sEntity))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (!ignoredExceptionTypes.Any(type => type.IsInstanceOfType(ex)))
                    {
                        throw;
                    }
                    lastException = ex;
                }
                if (!clock.IsNowBefore(otherDateTime))
                {
                    var text =
                        $"Timed out after {timeout.TotalSeconds} seconds {Environment.NewLine}Element: {sEntity} {Environment.NewLine}Condition: ";
                    text += condition;
                    throw new AssertionException(text, lastException);
                }
                Thread.Sleep(AppConfiguration.GetPollingInterval());
            }

            return sEntity;
        }

        public static TResult WaitForNot<TResult>(TResult sEntity, Condition<TResult> condition, TimeSpan timeout)
        {
            Exception? lastException = null;
            var clock = new SystemClock();
            var otherDateTime = clock.LaterBy(timeout);
            while (true)
            {
                try
                {
                    if (!condition.Apply(sEntity))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    break;
                }
                if (!clock.IsNowBefore(otherDateTime))
                {
                    var text =
                        $"Timed out after {timeout.TotalSeconds} seconds {Environment.NewLine}Element: {sEntity}{Environment.NewLine}Condition: Not ";
                    text += condition;
                    throw new AssertionException(text, lastException);
                }
                Thread.Sleep(AppConfiguration.GetPollingInterval());
            }
            return sEntity;
        }
    }
}
