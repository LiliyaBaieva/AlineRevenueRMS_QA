using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using Allure.NUnit.Attributes;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class PaymentCenterPage : BasePage
    {
        private static WrappedElement AchPaymentsLink => new(With.XPath("//h5[contains(text(),'ACH payments')]"), "Navigate to ACH payment");

        [AllureStep("Go to ACH payment")]
        public static void GoToACHpayment()
        {
            AchPaymentsLink.Click();
        }
    }
}