using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class ResidentLedgerInElegancePage : BasePage
    {

        public static WrappedElement PaymentsSection => new(With.XPath("//th[contains(text(),'Payments')]"), "Payments Section");
        public static WrappedElement ResidentNameLink(string name) => new(With.LinkText(name), $"Resident Name Link for {name}");
        public static WrappedElement PaymentRow(string date, string amount) => new(With.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]"),
            $"Row with date {date} and amount ${amount}");


        public static void IsPaymentExist(Payment payment)
        {
            ScrollToElement(PaymentsSection);
            DateTime paymentDate = payment.Date;
            string date = payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            PaymentRow(date, "" + payment.Amount).Should(Be.Visible);
            ScrollToHeader();
        }

        [AllureStep("Move to resident page")]
        public ResidentPageInElegance BackToResidentDashboard(Resident resident)
        {
            ResidentNameLink(resident.Name).Click();
            return new ResidentPageInElegance();
        }
    }
}