using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Element.Extensions;
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

        private static WrappedElement PaymentManagement = new(With.LinkText("Payment Management"), "Payment Management");
        private static WrappedElement PaymentDescriprionField = new(With.Id("BatchPaymentDescStep1"), "Payment Descriprion Field");
        private static WrappedElement ContinueBtn = new(With.Id("Submit"), "Continue Buttton");
        private static WrappedElement DataField = new(With.Id("CheckDateStep1"), "Data Field"); // TODO проверить везде ли дописано что это кнопка или поле
        private static WrappedElement ResidentCheckbox(int residentNum) => 
            new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//*[@class='ag-selection-checkbox']/div"), 
                "Select Resident checkbox");
        private static readonly WrappedElement PaySelectedItemBtn = new(With.Css(".btn-outline-secondary"), "Pay Selected Item button");
        private static WrappedElement AppliedAmountSell(int residentIndex) =>
             new(With.Css($" div[row-id='{residentIndex}'] div.ag-cell-value[col-id='itemAppliedAmount']"), "Applied Amount Sell");
        private static WrappedElement CheckBoxInPaymentCart(int residentIndex) =>
             new(With.Css($"div[row-id='{residentIndex}'] div.ag-checkbox-input-wrapper"), "Check Box In Payment Cart");
        private static readonly WrappedElement SubmitPaymentsBtn = new(With.Css("input[value='Submit Payments']"), "Submit Payments Button ");
        private static readonly WrappedElement DepositTotalField = new(With.Id("CheckAmountStep1"), "Deposit Total");
        private static readonly WrappedElement UnAppliedAmount = new(With.Id("unapplied"), "UnAppliedAmount");

        public static WrappedElement ResidentToSelect(int residentNum) =>
             new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//span[@class='ag-cell-value']"), "Receive resident name");
        
        public static readonly WrappedElement PaymentSuccessfullySubmitted = new(With.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]"),
            "Payment Successfully Submitted");
        public static readonly WrappedElement Description = new(With.Id("displayBatchPaymentDesc"), "Description"); // TODO: all without readonly + Description, all start from capital letter
        public static readonly WrappedElement TotalApplied = new(With.Id("applied"), "Total Applied");
        public static WrappedElement UnAppliedErrorMessage => new(With.Id("error-message"), "Un-Applied Error Message");

        [AllureStep("Enter Payment date and description")]
        public static void EnterPaymentDitails(Payment payment, double depositTotal)
        {
            DataField.SendKeys(payment.Date.ToString("dd-MM-yyyy"));
            DepositTotalField.SendKeys(depositTotal.ToString());
            PaymentDescriprionField.SendKeys(payment.Description);
            ContinueBtn.Click();
            Log.Information($"Enter Payment Details with date '{payment.Date.ToString()}', Deposit Total {depositTotal} and description {payment.Description}");
        }

        [AllureStep("Select Resident")]
        public static void SelectResident(int residentNum)
        {
            //ScrollDown(2); // TODO: delete
            ResidentCheckbox(residentNum).ScrollIntoView();
            ResidentCheckbox(residentNum).Click();
        }

        [AllureStep("Enter payment for 1 payor")]
        public static void EnterPaymentFor1payor(double amount)
        {
            PaySelectedItemBtn.Click();
            ScrollDown(2);
            AppliedAmountSell(0).SendKeys($"{amount}");
            AppliedAmountSell(0).PressEnter();
            CheckBoxInPaymentCart(0).Click();
            Log.Information($"Set ammount {amount} for one payor");
            SubmitPaymentsBtn.Click();
        }
        
        [AllureStep("Eneter payment for several payors")]
        public static void EnterPaymentForSeveralPayors(List<Resident> residents)
        {
            PaySelectedItemBtn.Click();
            ScrollDown(2);
            for (int i = 0; i < residents.Count; i++)
            {
                AppliedAmountSell(i).SendKeys($"{residents[i].Payment.Amount}");
                AppliedAmountSell(i).PressEnter();
                CheckBoxInPaymentCart(i).Click();
                Log.Information($"Set ammount {residents[i].Payment.Amount} for {residents[i].Name}");
            }
            SubmitPaymentsBtn.Click();
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
            SelectResident(1);
            resident.Name = ResidentToSelect(1).GetText();
            EnterPaymentFor1payor(resident.Payment.Amount);
            SubmitPayment();
        }

        public static bool ErrorMessageDisplaied(string message)
        {
            return UnAppliedErrorMessage.GetText().Contains(message);
        }

        public static string GetUnAppliedAmount()
        {
            return UnAppliedAmount.GetText();
        }
    }
}