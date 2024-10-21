using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlineRevenueRMS.Automation.Web.Core.Wrappers
{
    public static class DriverManager
    {
        public static WrappedDriver CommonDriver => new();

        public static IWebDriver GetWebDriver(bool headlessMode)
        {
            var optionsChrome = new ChromeOptions();
            optionsChrome.AddArguments(chromiumBrowserOptions);

            if (headlessMode)
            {
                optionsChrome.AddArguments("--headless");
            }
    
            optionsChrome.AddExcludedArgument("enable-automation");
            optionsChrome.AddUserProfilePreference("credentials_enable_service", false);
            optionsChrome.AddUserProfilePreference("profile.password_manager_enabled", false);
            optionsChrome.AddUserProfilePreference("disable-popup-blocking", true); // TODO: Liliia. try to delete

            return new ChromeDriver(optionsChrome);
        }

        private static readonly string[] chromiumBrowserOptions =
{
            "--test-type",
            "--start-maximized",
            "--no-sandbox", // TODO: Liliia. try to delete
            "--incognito",
            "--window-size=1920,1080",
        };
    }
}
