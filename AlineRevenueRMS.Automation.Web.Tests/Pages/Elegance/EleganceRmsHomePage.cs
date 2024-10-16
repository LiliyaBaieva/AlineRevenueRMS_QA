using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using Allure.NUnit.Attributes;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages.Elegance
{
    public class EleganceRmsHomePage : BasePage
    {
        public static readonly WrappedElement _comunityTab = new(With.XPath("//a[contains(text(),'Community...')]"), "Community Tab");
        private static readonly WrappedElement _communityFilter = new(With.Id("communityFilter"), "Community Filter");
        private static WrappedElement _comunityInSelector(string community) => new(With.XPath($"//strong[contains(text(),'{community}')]"), $"Select community {community}");
        private static readonly WrappedElement _quickActionLink = new(With.LinkText("Quick Actions"), "Quick Actions");
        private static readonly WrappedElement _paymentManagement = new(With.LinkText("Payment Management"), "Navigate to Payment Center");
        private static readonly WrappedElement _residentLink = new(With.XPath("//a[contains(@href, 'ResidentModal')]"), "Resident Link");
        private static readonly WrappedElement _searchResidentInput = new(With.Id("mdlFilterResident"), "Search Resident Input");
        private static WrappedElement _searchedResident(string name) => new(With.XPath($"//div[contains(text(), '{name}')]"), $"Open Lease Menegement for '{name}'");
        private static readonly WrappedElement _homeNav = new(With.Id("homeNav"), "Home Icon");

        [AllureStep("Select comunity")]
        public static void SelectComunity(string community)
        {
            _comunityTab.Click();
            _communityFilter.Should(Be.Visible);
            _communityFilter.SendKeys(community);
            _comunityInSelector(community).Click();
        }

        [AllureStep("Navigate to the Payment Center")]
        public static void NavigateToThePaymentCenter()
        {
            _quickActionLink.Click();
            _paymentManagement.Click();
        }

        [AllureStep("Open Resident Page")]
        public static void OpenResidentPage(Resident resident)
        {
            _homeNav.Click();
            _residentLink.Click();
            _searchResidentInput.SendKeys(resident.Name);
            _searchedResident(resident.Name).Click();
        }
    }
}