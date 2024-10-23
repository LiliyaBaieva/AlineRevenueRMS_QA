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
        private static WrappedElement PaymentManagement => new(With.LinkText("Payment Management"), "Payment Management"); // TODO: Where it uses
        private static WrappedElement PaymentDescriprionField => new(With.Id("BatchPaymentDescStep1"), "Payment Descriprion Field");
        private static WrappedElement ContinueBtn => new(With.Id("Submit"), "Continue Buttton");
        private static WrappedElement DataField => new(With.Id("CheckDateStep1"), "Data Field");
        private static WrappedElement PaySelectedItemBtn => new(With.Css(".btn-outline-secondary"), "Pay Selected Item button");
        private static WrappedElement SubmitPaymentsBtn => new(With.Css("input[value='Submit Payments']"), "Submit Payments Button ");
        private static WrappedElement DepositTotalField => new(With.Id("CheckAmountStep1"), "Deposit Total");

        public static WrappedElement UnAppliedAmountText => new(With.Id("unapplied"), "UnAppliedAmount");
        public static WrappedElement DescriptionText => new(With.Id("displayBatchPaymentDesc"), "Description");
        public static WrappedElement TotalAppliedText => new(With.Id("applied"), "Total Applied");
        public static WrappedElement UnAppliedErrorMessage => new(With.Id("error-message"), "Un-Applied Error Message");
        public static WrappedElement PaymentSuccessfullySubmittedMessage => new(With.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]"), "Payment Successfully Submitted");

        private static WrappedElement AppliedAmountSell(int residentIndex) =>
            new(With.Css($" div[row-id='{residentIndex}'] div.ag-cell-value[col-id='itemAppliedAmount']"), "Applied Amount Sell");
        private static WrappedElement CheckBoxInPaymentCart(int residentIndex) =>
            new(With.Css($"div[row-id='{residentIndex}'] div.ag-checkbox-input-wrapper"), "Check Box In Payment Cart");
        private static WrappedElement ResidentCheckbox(int residentNum) =>
            new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//*[@class='ag-selection-checkbox']/div"), "Select Resident checkbox");
        public static WrappedElement ResidentToSelect(int residentNum) =>
            new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//span[@class='ag-cell-value']"), "Receive resident name");

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
            ResidentCheckbox(residentNum).ScrollIntoView();
            ResidentCheckbox(residentNum).Click();
        }

        [AllureStep("Enter payment for 1 payor")]
        public static void EnterPaymentFor1payor(double amount)
        {
            PaySelectedItemBtn.Click();
            AppliedAmountSell(0).ScrollIntoView();
            AppliedAmountSell(0).SendKeys($"{amount}");
            AppliedAmountSell(0).PressEnter();
            CheckBoxInPaymentCart(0).Click();
            SubmitPaymentsBtn.Click();
        }
        
        [AllureStep("Eneter payment for several payors")]
        public static void EnterPaymentForSeveralPayors(List<Resident> residents)
        {
            PaySelectedItemBtn.Click();
            //ScrollDown(2); // TODO: delete
            AppliedAmountSell(0).ScrollIntoView();
            for (int i = 0; i < residents.Count; i++)
            {
                AppliedAmountSell(i).SendKeys($"{residents[i].Payment.Amount}");
                AppliedAmountSell(i).PressEnter();
                CheckBoxInPaymentCart(i).Click();
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
    }
}