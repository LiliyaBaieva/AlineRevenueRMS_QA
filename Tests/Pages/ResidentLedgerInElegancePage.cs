using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using TestProject.TestData.models;

namespace Core.pages
{
    public class ResidentLedgerInElegancePage : BasePage
    {
        public ResidentLedgerInElegancePage(){}

        private By PaymentsSection = By.XPath("//th[contains(text(),'Payments')]");
        private By ResidentNameLink(string name) => By.LinkText(name);

        private By PatmentString(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]");


        public bool IsPaymentExist(Payment payment)
        {
            WaitUntilPageLoaded();
            ScrollToElement(PaymentsSection);
            DateTime paymentDate = payment.Date;
            string date = $"{paymentDate.Month.ToString()}/{paymentDate.Day.ToString()}/{paymentDate.Year.ToString()}";
            bool exist = IsElementPresent(PatmentString(date, "" + payment.Amount));
            MoveToTopOfPage();
            //MoveToResidentPage();
            logger.Info("Payment by '{0}' with amount '{1}' exist", payment.Date.ToString(), payment.Amount.ToString());
            return exist;
        }

        public ResidentPageInElegance MoveToResidentPage(Resident resident)
        {
            Click(ResidentNameLink(resident.Name));
            return new ResidentPageInElegance();
        }
    }
}