using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.WebDriverConditions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions
{
    public static class WindowsTabs
    {
        public static Condition<IWebDriver> WindowsTabCountShouldBe(int value)
        {
            return new WindowsTabCount(value);
        }

        public static Condition<IWebDriver> WindowsTabsCountShouldBeAtLeast(int value)
        {
            return new WindowsTabCountAtLeast(value);
        }

        public static Condition<IWebDriver> WindowsTabShouldContainUrl(string url)
        {
            return new WindowsTabUrl(url);
        }
    }
}
