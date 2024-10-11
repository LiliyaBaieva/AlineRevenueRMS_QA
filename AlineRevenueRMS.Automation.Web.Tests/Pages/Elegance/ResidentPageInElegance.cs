using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class ResidentPageInElegance : BasePage
    {
        public static WrappedElement TaskListInResidentActivity => new(With.XPath(
            "//div[contains(text(), 'Resident Activity')]/../..//a[@class='dropdown-toggle']"), "TaskList In Resident Activity");
        public static WrappedElement ResidentLedgerLink => new(With.XPath("//a[contains(@href, 'ResidentLedger.aspx')]"), "Open Rsident Ledger");
        public static WrappedElement ResidentLedgerAdmin => new(With.XPath("//a[contains(@href, '/ResidentLedger/ResidentLedger2.aspx')]"),
            "Open Rsident Ledger Admin");

        public static void OpenResidentLedger()
        {
            ScrollDown(1);
            TaskListInResidentActivity.Click();
            ResidentLedgerLink.Click();
        }

        [AllureStep("Open Resident Ledger Admin")]
        public static void OpenResidentLedgerAdmin()
        {
            ScrollDown(1);
            TaskListInResidentActivity.Click();
            ResidentLedgerAdmin.Click();
        }
    }
}