using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TestProject.TestData.Models;

namespace AlineRevenueRMS_QA.Pages
{
    public class ResidentLedgerAdminInElegancePage : BasePage
    {
        private By PaymentsSection = By.XPath("//th[contains(text(),'Payments')]");
        private By DeletePaymentBtn = By.XPath("//div[@class='dropdown open']//a[contains(text(), 'Delete...')]");
        private By UpdatePaymentBtn = By.XPath("//div[@class='dropdown open']//a[contains(text(), 'Update...')]");
        private By ConfirmDeleteBtn = By.Id("btnDelete");
        private By PaymnetInput = By.Id("AmountSelect");
        private By ConfirmUpdateBtn = By.Id("btnLedgerAdminSubmit");
        private By UpdateModalWindow = By.Id("UpdateModal");

        private By EditBtnInPayments(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]//button");
        private By PaymentRow(string date, string amount) => By.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]");

        public ResidentLedgerAdminInElegancePage() {}
        
        [AllureStep("Delete Payment")]
        public void DeletePayment(Resident resident)
        {
            Wrap.WaitUntilPageLoaded();
            Wrap.ScrollToElement(PaymentsSection);
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Wrap.Click(EditBtnInPayments(date, ""+resident.Payment.Amount));
            logger.Info("Click edit button");
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

        [AllureStep("Edit Payment with new amount")]
        internal void UpdatePayment(Resident resident, double newAmmount)
        {
            Wrap.WaitUntilPageLoaded();
            Wrap.ScrollToElement(PaymentsSection);
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Wrap.Click(EditBtnInPayments(date, "" + resident.Payment.Amount));
            logger.Info("Click edit button");
            Wrap.Click(UpdatePaymentBtn);
            Assert.IsTrue(Wrap.IsElementPresent(UpdateModalWindow));
            Wrap.ClearField(PaymnetInput).SendKeysText(PaymnetInput, newAmmount.ToString());
            Wrap.Click(ConfirmUpdateBtn);

            logger.Info("Payment by '{0}' with previous amount '{1}' was updated to {2}, successfully",
                date, resident.Payment.Amount.ToString(), newAmmount);
        }

        internal bool PaymenExist(Resident resident, double newAmmount)
        {
            Wrap.ScrollToElement(PaymentsSection);
            DateTime paymentDate = resident.Payment.Date;
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return Wrap.IsElementPresent(PaymentRow(date, "" + newAmmount.ToString()));
        }

        internal bool RecentPaymentDoesntExist(Resident resident)
        {
            return PaymentDoesntExist(resident);
        }
    }
}