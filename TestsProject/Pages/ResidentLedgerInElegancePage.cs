using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TestProject.TestData.Models;

namespace AlineRevenueRMS_QA.Pages
{
    public class ResidentLedgerInElegancePage : BasePage
    {
        public ResidentLedgerInElegancePage(){}

        private By PaymentsSection = By.XPath("//th[contains(text(),'Payments')]");
        private By ResidentNameLink(string name) => By.LinkText(name);
        private By PatmentString(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]");


        public bool IsPaymentExist(Payment payment)
        {
            Wrap.WaitUntilPageLoaded();
            Wrap.ScrollToElement(PaymentsSection);
            DateTime paymentDate = payment.Date;
            string date = payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            bool exist = Wrap.IsElementPresent(PatmentString(date, "" + payment.Amount));
            Wrap.MoveToTopOfPage();
            logger.Info("Payment by '{0}' with amount '{1}' exist", payment.Date.ToString(), payment.Amount.ToString());
            return exist;
        }

        [AllureStep("Move to resident page")]
        public ResidentPageInElegance BackToResidentDashboard(Resident resident)
        {
            Wrap.Click(ResidentNameLink(resident.Name));
            return new ResidentPageInElegance();
        }
    }
}