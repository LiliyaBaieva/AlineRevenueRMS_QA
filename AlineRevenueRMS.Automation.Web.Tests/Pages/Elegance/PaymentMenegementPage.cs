
using AlineRevenueRMS.Automation.Web.Core.Conditions;
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

        public static WrappedElement PaymentManagement => new(With.LinkText("Payment Management"), "Payment Management");
        public static WrappedElement PaymentDescriprionField => new(With.Id("BatchPaymentDescStep1"), "Payment Descriprion Field");
        public static WrappedElement ContinueBtn => new(With.Id("Submit"), "Continue Buttton");
        public static WrappedElement DataField => new(With.Id("CheckDateStep1"), "Data Field");
        public static WrappedElement ResidentCheckbox(int residentNum) =>
            new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//*[@class='ag-selection-checkbox']/div"), 
                "Select Resident checkbox");
        public static WrappedElement ResidentToSelect(int residentNum) =>
             new(With.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//span[@class='ag-cell-value']"), "Receive resident name");
        public static WrappedElement PaySelectedItem => new(With.Css(".btn-outline-secondary"), "Pay Selected Item button");
        public static WrappedElement AppliedAmountSell(int residentIndex) =>
             new(With.Css($" div[row-id='{residentIndex}'] div.ag-cell-value[col-id='itemAppliedAmount']"), "Applied Amount Sell");
        public static WrappedElement CheckBoxInPaymentCart(int residentIndex) =>
             new(With.Css($"div[row-id='{residentIndex}'] div.ag-checkbox-input-wrapper"), "Check Box In Payment Cart");
        public static WrappedElement SubmitPaymentsBtn => new(With.Css("input[value='Submit Payments']"), "Submit Payments Button ");
        public static WrappedElement PaymentSuccessfullySubmitted => new(With.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]"),
            "Payment Successfully Submitted");
        public static WrappedElement Description => new(With.Id("displayBatchPaymentDesc"), "Description");
        public static WrappedElement TotalApplied => new(With.Id("applied"), "Total Applied");
        public static WrappedElement DepositTotal => new(With.Id("CheckAmountStep1"), "Deposit Total");
        public static WrappedElement UnAppliedErrorMessage => new(With.Id("error-message"), "Un-Applied Error Message");
        public static WrappedElement UnAppliedAmount => new(With.Id("unapplied"), "UnAppliedAmount");

        [AllureStep("Enter Payment date and description")]
        public static void EnterPaymentDitails(Payment payment, double depositTotal)
        {
            DataField.SendKeys(payment.Date.ToString("dd-MM-yyyy"));
            DepositTotal.SendKeys(depositTotal.ToString());
            PaymentDescriprionField.SendKeys(payment.Description);
            ContinueBtn.Click();
            Log.Information($"Enter Payment Details with date '{payment.Date.ToString()}', Deposit Total {depositTotal} and description {payment.Description}");
        }

        [AllureStep("Select Resident")]
        public static string SelectResident(int residentNum)
        {
            ScrollDown(2);
            ResidentCheckbox(residentNum).Click();
            string name = ResidentToSelect(residentNum).GetText();
            Log.Information($"Resident '{name}' is selected");
            return name;
        }

        [AllureStep("Enter payment for 1 payor")]
        public static void EnterPaymentFor1payor(double amount)
        {
            PaySelectedItem.Click();
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
            PaySelectedItem.Click();
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
            resident.Name = SelectResident(1);
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