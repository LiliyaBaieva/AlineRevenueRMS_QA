using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using Allure.NUnit.Attributes;
using Serilog;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class ResidentLedgerAdminInElegancePage : BasePage
    {
        private static WrappedElement PaymentsSection = new(With.XPath("//th[contains(text(),'Payments')]"), "Payments Section");
        private static WrappedElement DeletePaymentBtn = 
            new(With.XPath("//div[@class='dropdown open']//a[contains(text(), 'Delete...')]"), "Delete Payment Button");
        private static WrappedElement UpdatePaymentBtn =
            new(With.XPath("//div[@class='dropdown open']//a[contains(text(), 'Update...')]"), "Update Payment Button");
        private static WrappedElement ConfirmDeleteBtn = new(With.Id("btnDelete"), "Confirm Delete Button");
        private static WrappedElement PaymnetInput = new(With.Id("AmountSelect"), "Paymnet Input");
        private static WrappedElement ConfirmUpdateBtn = new(With.Id("btnLedgerAdminSubmit"), "Confirm Update Button");
        private static WrappedElement UpdateModalWindow = new(With.Id("UpdateModal"), "Update Modal Window");
        private static WrappedElement EditBtnInPayments(string date, string amount) => 
            new(With.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]//button"), 
                $"Edit Button In Payments with date {date}, amount {amount}");
        private static WrappedElement PaymentRow(string date, string amount) => 
            new(With.XPath($"//tr[contains(., '{date}') and contains(., '{amount}')][1]"), "Payment Row");

        [AllureStep("Delete Payment")]
        public static void DeletePayment(Resident resident)
        {
            ScrollToElement(PaymentsSection);
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            EditBtnInPayments(date, $"{resident.Payment.Amount}").Click();
            DeletePaymentBtn.Click();
            ConfirmDeleteBtn.Click();
            Log.Information($"Payment with amoint {resident.Payment.Amount} and date {date} was deleted successfully.");
        }

        public static void MakeASurePaymentDoesntExist(Resident resident)
        {
            DateTime paymentDate = resident.Payment.Date;
            string date = $"{paymentDate.Month.ToString()}/{paymentDate.Day.ToString()}/{paymentDate.Year.ToString()}";
            PaymentRow(date, "" + resident.Payment.Amount).ShouldNot(Be.Visible);
        }

        [AllureStep("Edit Payment with new amount")]
        public static void UpdatePayment(Resident resident, double newAmmount)
        {
            //Wrap.WaitUntilPageLoaded(); // TODO: find solution if need this
            ScrollToElement(PaymentsSection);
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            EditBtnInPayments(date, "" + resident.Payment.Amount).Click();
            UpdatePaymentBtn.Click();
            PaymnetInput.Clear();
            PaymnetInput.SendKeys(newAmmount.ToString());
            ConfirmUpdateBtn.Click();
            Log.Information($"Payment by '{date}' with previous amount '{resident.Payment.Amount.ToString()}' " +
                $"was updated to {newAmmount}, successfully");
        }

        public static void PaymenExist(Resident resident, double newAmmount)
        {
            ScrollToElement(PaymentsSection);
            DateTime paymentDate = resident.Payment.Date;
            string date = resident.Payment.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            PaymentRow(date, "" + newAmmount.ToString()).Should(Be.Visible);
        }

        public static void RecentPaymentDoesntExist(Resident resident)
        {
            MakeASurePaymentDoesntExist(resident);
        }

        internal static void PaymentIsUpdatedSuccessfully(Resident resident, double newAmmount)
        {
            PaymenExist(resident, newAmmount);
            RecentPaymentDoesntExist(resident);
        }
    }
}