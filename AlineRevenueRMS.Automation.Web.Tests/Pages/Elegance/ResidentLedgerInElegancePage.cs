using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Element.Extensions;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using Allure.NUnit.Attributes;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class ResidentLedgerInElegancePage : BasePage
    {
        private static WrappedElement ResidentNameLink(string name) => new(With.LinkText(name), $"Resident Name Link for {name}");
        public static WrappedElement PaymentRow(string date, string amount) => 
            new(With.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]"),$"Row with date {date} and amount ${amount}");
        public static WrappedElement PaymentsSection => new(With.XPath("//th[contains(text(),'Payments')]"), "Payments Section");

        [AllureStep("Move to resident page")]
        public static void BackToResidentDashboard(Resident resident)
        {
            ResidentNameLink(resident.Name).Click();
        }
    }
}