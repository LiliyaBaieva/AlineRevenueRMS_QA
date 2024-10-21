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
        private static WrappedElement CommunityFilter => new(With.Id("communityFilter"), "Community Filter");
        private static WrappedElement QuickActionLink => new(With.LinkText("Quick Actions"), "Quick Actions");
        private static WrappedElement PaymentManagementLink => new(With.LinkText("Payment Management"), "Navigate to Payment Center");
        private static WrappedElement ResidentLink => new(With.XPath("//a[contains(@href, 'ResidentModal')]"), "Resident Link");
        private static WrappedElement SearchResidentInput => new(With.Id("mdlFilterResident"), "Search Resident Input");

        public static WrappedElement ComunityTab => new(With.XPath("//a[contains(text(),'Community...')]"), "Community Tab");

        private static WrappedElement HomeNavBtn => new(With.Id("homeNav"), "Home Icon");
        private static WrappedElement ComunityInSelector(string community) =>
            new(With.XPath($"//strong[contains(text(),'{community}')]"), $"Select community {community}");
        private static WrappedElement SearchedResident(string name) =>
            new(With.XPath($"//div[contains(text(), '{name}')]"), $"Open Lease Menegement for '{name}'");

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
            PaymentManagementLink.Click();
        }

        [AllureStep("Open Resident Page")]
        public static void OpenResidentPage(Resident resident)
        {
            HomeNavBtn.Click();
            ResidentLink.Click();
            SearchResidentInput.SendKeys(resident.Name);
            SearchedResident(resident.Name).Click();
        }
    }
}