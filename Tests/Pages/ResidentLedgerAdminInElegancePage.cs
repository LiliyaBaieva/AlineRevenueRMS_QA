using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using TestProject.TestData.models;

namespace Core.pages
{
    public class ResidentLedgerAdminInElegancePage : BasePage
    {
        private By PaymentsSection = By.XPath("//th[contains(text(),'Payments')]");
        private By DeletePaymentBtn = By.XPath("//div[@class='dropdown open']//a[contains(text(), 'Delete')]");
        private By ConfirmDeleteBtn = By.Id("btnDelete");

        private By EditBtnInPayments(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]//button");

        public ResidentLedgerAdminInElegancePage() {}

        public void DeletePayment(Resident resident)
        {
            Wrap.WaitUntilPageLoaded();
            Wrap.ScrollToElement(PaymentsSection);
            DateTime paymentDate = resident.Payment.Date;
            string date = $"{paymentDate.Month.ToString()}/{paymentDate.Day.ToString()}/{paymentDate.Year.ToString()}";
            Wrap.Click(EditBtnInPayments(date, ""+resident.Payment.Amount));
            Wrap.Click(DeletePaymentBtn);
            Wrap.Click(ConfirmDeleteBtn);
            logger.Info("Payment by '{0}' with amount '{1}' was deleted successfully", 
                resident.Payment.Date.ToString(), resident.Payment.Amount.ToString());
        }
    }
}