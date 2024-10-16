using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Elegance;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using Allure.NUnit.Attributes;
using Serilog;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class PaymentMenegementPage : BasePage
    {

        private static readonly WrappedElement _paymentManagement = new(With.LinkText("Payment Management"), "Payment Management");
        private static readonly WrappedElement _paymentDescriprionField = new(With.Id("BatchPaymentDescStep1"), "Payment Descriprion Field");
        private static readonly WrappedElement _continueBtn = new(With.Id("Submit"), "Continue Buttton");
        private static readonly WrappedElement _dataField = new(With.Id("CheckDateStep1"), "Data Field");
        private static WrappedElement _residentCheckbox(int residentNum) =>
            new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//*[@class='ag-selection-checkbox']/div"), 
                "Select Resident checkbox");
        private static WrappedElement _residentToSelect(int residentNum) =>
             new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//span[@class='ag-cell-value']"), "Receive resident name");
        private static readonly WrappedElement PaySelectedItem = new(With.Css(".btn-outline-secondary"), "Pay Selected Item button");
        private static WrappedElement _appliedAmountSell(int residentIndex) =>
             new(With.Css($" div[row-id='{residentIndex}'] div.ag-cell-value[col-id='itemAppliedAmount']"), "Applied Amount Sell");
        private static WrappedElement _checkBoxInPaymentCart(int residentIndex) =>
             new(With.Css($"div[row-id='{residentIndex}'] div.ag-checkbox-input-wrapper"), "Check Box In Payment Cart");
        private static readonly WrappedElement _submitPaymentsBtn = new(With.Css("input[value='Submit Payments']"), "Submit Payments Button ");
        public static readonly WrappedElement _paymentSuccessfullySubmitted = new(With.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]"),
            "Payment Successfully Submitted");
        public static readonly WrappedElement _description = new(With.Id("displayBatchPaymentDesc"), "Description");
        public static readonly WrappedElement _totalApplied = new(With.Id("applied"), "Total Applied");
        private static readonly WrappedElement _depositTotal = new(With.Id("CheckAmountStep1"), "Deposit Total");
        private static readonly WrappedElement _unAppliedErrorMessage = new(With.Id("error-message"), "Un-Applied Error Message");
        private static readonly WrappedElement _unAppliedAmount = new(With.Id("unapplied"), "UnAppliedAmount");

        [AllureStep("Enter Payment date and description")]
        public static void EnterPaymentDitails(Payment payment, double depositTotal)
        {
            _dataField.SendKeys(payment.Date.ToString("dd-MM-yyyy"));
            _depositTotal.SendKeys(depositTotal.ToString());
            _paymentDescriprionField.SendKeys(payment.Description);
            _continueBtn.Click();
            Log.Information($"Enter Payment Details with date '{payment.Date.ToString()}', Deposit Total {depositTotal} and description {payment.Description}");
        }

        [AllureStep("Select Resident")]
        public static string SelectResident(int residentNum)
        {
            ScrollDown(2);
            _residentCheckbox(residentNum).Click();
            string name = _residentToSelect(residentNum).GetText();
            Log.Information($"Resident '{name}' is selected");
            return name;
        }

        [AllureStep("Enter payment for 1 payor")]
        public static void EnterPaymentFor1payor(double amount)
        {
            PaySelectedItem.Click();
            ScrollDown(2);
            _appliedAmountSell(0).SendKeys($"{amount}");
            _appliedAmountSell(0).PressEnter();
            _checkBoxInPaymentCart(0).Click();
            Log.Information($"Set ammount {amount} for one payor");
            _submitPaymentsBtn.Click();
        }
        
        [AllureStep("Eneter payment for several payors")]
        public static void EnterPaymentForSeveralPayors(List<Resident> residents)
        {
            PaySelectedItem.Click();
            ScrollDown(2);
            for (int i = 0; i < residents.Count; i++)
            {
                _appliedAmountSell(i).SendKeys($"{residents[i].Payment.Amount}");
                _appliedAmountSell(i).PressEnter();
                _checkBoxInPaymentCart(i).Click();
                Log.Information($"Set ammount {residents[i].Payment.Amount} for {residents[i].Name}");
            }
            _submitPaymentsBtn.Click();
        }

        [AllureStep("Submit Payment")]
        public static void SubmitPayment()
        {
            SubmitAlert();
            Log.Information("Confirm payment.");
        }

        [AllureStep("Do ACH payment")]
        public static void DoACHPayment(Resident resident)
        {
            double depositTotal = resident.Payment.Amount;
            EleganceRmsHomePage.SelectComunity(resident.Community);
            EleganceRmsHomePage.NavigateToThePaymentCenter();
            PaymentCenterPage.GoToACHpayment();
            EnterPaymentDitails(resident.Payment, depositTotal);
            resident.Name = SelectResident(1);
            EnterPaymentFor1payor(resident.Payment.Amount);
            SubmitPayment();
        }

        public static bool ErrorMessageDisplaied(string message)
        {
            return _unAppliedErrorMessage.GetText().Contains(message);
        }

        public static string GetUnAppliedAmount()
        {
            return _unAppliedAmount.GetText();
        }
    }
}