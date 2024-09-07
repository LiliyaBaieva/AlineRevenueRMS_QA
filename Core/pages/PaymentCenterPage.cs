using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;

namespace Core.pages
{
    public class PaymentCenterPage : BasePage
    {
        public PaymentCenterPage(){}

        public By ACHpaymentsLink = By.XPath("//h5[contains(text(),'ACH payments')]");


        public PaymentMenegementPage GoToACHpayment()
        {
            Click(ACHpaymentsLink);
            logger.Debug("Navigate to ACH payment");
            return new PaymentMenegementPage();

        }
    }
}