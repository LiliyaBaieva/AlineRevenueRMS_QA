using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class PaymentCenterPage : BasePage
    {

        private By ACHpaymentsLink = By.XPath("//h5[contains(text(),'ACH payments')]");

        [AllureStep("Go to ACH payment")]
        public static PaymentMenegementPage GoToACHpayment()
        {
            Wrap.Click(ACHpaymentsLink);
            logger.Info("Navigate to ACH payment");
            return new PaymentMenegementPage();

        }
    }
}