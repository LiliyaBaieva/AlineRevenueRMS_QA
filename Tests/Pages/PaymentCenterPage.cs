using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;

namespace Core.pages
{
    public class PaymentCenterPage : BasePage
    {
        public PaymentCenterPage(){}

        private By ACHpaymentsLink = By.XPath("//h5[contains(text(),'ACH payments')]");


        public PaymentMenegementPage GoToACHpayment()
        {
            Wrap.Click(ACHpaymentsLink);
            logger.Info("Navigate to ACH payment");
            return new PaymentMenegementPage();

        }
    }
}