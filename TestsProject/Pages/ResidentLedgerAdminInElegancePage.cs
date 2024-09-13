using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using TestProject.TestData.Models;

namespace AlineRevenueRMS_QA.Pages
{
    public class ResidentLedgerAdminInElegancePage : BasePage
    {
        private By PaymentsSection = By.XPath("//th[contains(text(),'Payments')]");
        private By DeletePaymentBtn = By.XPath("//div[@class='dropdown open']//a[contains(text(), 'Delete')]");
        private By ConfirmDeleteBtn = By.Id("btnDelete");

        private By EditBtnInPayments(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]//button");
        private By PaymentRow(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]");

        public ResidentLedgerAdminInElegancePage() {}

        public void DeletePayment(Resident resident)
        {
            Wrap.WaitUntilPageLoaded();
            Wrap.ScrollToElement(PaymentsSection);
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Wrap.Click(EditBtnInPayments(date, ""+resident.Payment.Amount));
            logger.Debug("Click edit button");
            Wrap.Click(DeletePaymentBtn);
            Wrap.Click(ConfirmDeleteBtn);
            logger.Info("Payment by '{0}' with amount '{1}' was deleted successfully", 
                date, resident.Payment.Amount.ToString());
        }

        internal bool PaymentDoesntExist(Resident resident)
        {
            DateTime paymentDate = resident.Payment.Date;
            string date = $"{paymentDate.Month.ToString()}/{paymentDate.Day.ToString()}/{paymentDate.Year.ToString()}";
            return !Wrap.IsElementPresent(PaymentRow(date, ""+resident.Payment.Amount));
        }
    }
}