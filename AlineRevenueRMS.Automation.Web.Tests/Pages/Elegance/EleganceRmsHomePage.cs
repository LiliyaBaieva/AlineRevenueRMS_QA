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
        public static readonly WrappedElement ComunityTab = new(With.XPath("//a[contains(text(),'Community...')]"), "Community Tab");
        private static readonly WrappedElement CommunityFilter = new(With.Id("communityFilter"), "Community Filter");
        private static WrappedElement ComunityInSelector(string community) => new(With.XPath($"//strong[contains(text(),'{community}')]"), $"Select community {community}");
        private static readonly WrappedElement QuickActionLink = new(With.LinkText("Quick Actions"), "Quick Actions");
        private static readonly WrappedElement PaymentManagement = new(With.LinkText("Payment Management"), "Navigate to Payment Center");
        private static readonly WrappedElement ResidentLink = new(With.XPath("//a[contains(@href, 'ResidentModal')]"), "Resident Link");
        private static readonly WrappedElement SearchResidentInput = new(With.Id("mdlFilterResident"), "Search Resident Input");
        private static WrappedElement SearchedResident(string name) => new(With.XPath($"//div[contains(text(), '{name}')]"), $"Open Lease Menegement for '{name}'");
        private static readonly WrappedElement HomeNav = new(With.Id("homeNav"), "Home Icon");

        [AllureStep("Select comunity")]
        public static void SelectComunity(string community)
        {
            ComunityTab.Click();
            CommunityFilter.Should(Be.Visible);
            CommunityFilter.SendKeys(community);
            ComunityInSelector(community).Click();
        }

        [AllureStep("Navigate to the Payment Center")]
        public static void NavigateToThePaymentCenter()
        {
            QuickActionLink.Click();
            PaymentManagement.Click();
        }

        [AllureStep("Open Resident Page")]
        public static void OpenResidentPage(Resident resident)
        {
            HomeNav.Click();
            ResidentLink.Click();
            SearchResidentInput.SendKeys(resident.Name);
            SearchedResident(resident.Name).Click();
        }
    }
}