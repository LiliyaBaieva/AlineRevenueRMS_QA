using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using Allure.NUnit.Attributes;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class ResidentPageInElegance : BasePage
    {
        private static WrappedElement TaskListInResidentActivityBtn = new(With.XPath(
            "//div[contains(text(), 'Resident Activity')]/../..//a[@class='dropdown-toggle']"), "TaskList In Resident Activity button");
        private static WrappedElement ResidentLedgerLink = new(With.XPath("//a[contains(@href, 'ResidentLedger.aspx')]"), "Open Rsident Ledger");
        private static WrappedElement ResidentLedgerAdminLink = new(With.XPath("//a[contains(@href, '/ResidentLedger/ResidentLedger2.aspx')]"),
            "Open Rsident Ledger Admin link");

        public static void OpenResidentLedger()
        {
            ScrollDown(1);
            TaskListInResidentActivityBtn.Click();
            ResidentLedgerLink.Click();
        }

        [AllureStep("Open Resident Ledger Admin")]
        public static void OpenResidentLedgerAdmin()
        {
            ScrollDown(1);
            TaskListInResidentActivityBtn.Click();
            ResidentLedgerAdminLink.Click();
        }
    }
}