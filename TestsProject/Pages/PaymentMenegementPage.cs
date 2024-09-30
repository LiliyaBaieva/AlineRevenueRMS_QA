
using AlineRevenueRMS_QA;
using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TestProject.TestData.Models;

namespace AlineRevenueRMS_QA.Pages
{
    public class PaymentMenegementPage : BasePage
    {
        public PaymentMenegementPage(){}

        private By PaymentManagement = By.LinkText("Payment Management");
        private By PaymentDescriprionField = By.Id("BatchPaymentDescStep1");
        private By ContinueBtn = By.Id("Submit");
        private By DataField = By.Id("CheckDateStep1");
        private By ResidentCheckbox(int residentNum) => 
            By.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//*[@class='ag-selection-checkbox']/div");
        private By ResidentToSelect(int residentNum) =>
            By.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//span[@class='ag-cell-value']");
        private By PaySelectedItem = By.CssSelector(".btn-outline-secondary");
        private By AppliedAmountSell(int residentIndex) => 
            By.CssSelector($" div[row-id='{residentIndex}'] div.ag-cell-value[col-id='itemAppliedAmount']");
        private By CheckBoxInPaymentCart(int residentIndex) => 
            By.CssSelector($"div[row-id='{residentIndex}'] div.ag-checkbox-input-wrapper");
        private By SubmitPaymentsBtn = By.CssSelector("input[value='Submit Payments']");
        private By PaymentSuccessfullySubmitted = By.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]");
        private By Description = By.Id("displayBatchPaymentDesc");
        private By TotalApplied = By.Id("applied");
        private By DepositTotal = By.Id("CheckAmountStep1");
        private By UnAppliedErrorMessage = By.Id("error-message");
        private By UnAppliedAmount = By.Id("unapplied");

        [AllureStep("Enter Payment date and description")]
        public PaymentMenegementPage EnterPaymentDitails(Payment payment, double depositTotal)
        {
            Wrap.SendKeysText(DataField, payment.Date.ToString("dd-MM-yyyy"));
            Wrap.SendKeysText(DepositTotal, depositTotal.ToString());
            Wrap.SendKeysText(PaymentDescriprionField, payment.Description);
            Wrap.Click(ContinueBtn);
            logger.Info($"Enter Payment Details with date '{payment.Date.ToString()}', Deposit Total {depositTotal} and description {payment.Description}");
            return this;
        }

        [AllureStep("Select Resident")]
        public string SelectResident(int residentNum)
        {
            Wrap.ScrollDown(2);
            Wrap.Click(ResidentCheckbox(residentNum));
            string name = Wrap.GetText(ResidentToSelect(residentNum));
            logger.Info("Resident '{0}' is selected", name);
            return name;
        }

        [AllureStep("Enter payment for 1 payor")]
        public PaymentMenegementPage EnterPaymentFor1payor(double amount)
        {
            Wrap.Click(PaySelectedItem);
            Wrap.ScrollDown(2);
            Wrap.SendKeysText(AppliedAmountSell(0), ""+amount);
            Wrap.ClickEnter(AppliedAmountSell(0));
            Wrap.Click(CheckBoxInPaymentCart(0));
            logger.Info($"Set ammount {amount} for one payor");
            Wrap.Click(SubmitPaymentsBtn);
            return this;
        }
        
        [AllureStep("Eneter payment for several payors")]
        public PaymentMenegementPage EnterPaymentForSeveralPayors(List<Resident> residents)
        {
            Wrap.Click(PaySelectedItem);
            Wrap.ScrollDown(2);
            for (int i = 0; i < residents.Count; i++)
            {
                Wrap.SendKeysText(AppliedAmountSell(i), $"{residents[i].Payment.Amount}");
                Wrap.ClickEnter(AppliedAmountSell(i));
                Wrap.Click(CheckBoxInPaymentCart(i));
                logger.Info($"Set ammount {residents[i].Payment.Amount} for {residents[i].Name}");
            }
            Wrap.Click(SubmitPaymentsBtn);
            return this;
        }

        [AllureStep("Submit Payment")]
        public PaymentMenegementPage SubmitPayment()
        {
            Wrap.SubmitAlert();
            logger.Info("Confirm payment.");
            return this;
        }

        public bool PaymentSuccessful(string description, double totalAmount)
        {
            Wrap.ScrollUp(3);
            if (
            Wrap.IsElementPresent(PaymentSuccessfullySubmitted) &&
            Wrap.GetText(Description).Contains(description) &&
            Wrap.GetText(TotalApplied).Contains($"{totalAmount}")
                ) 
            {
                logger.Info($"Payment was upplied successfully with amount {totalAmount}");
                return true;
            }
            else { return false; }
        }

        [AllureStep("Do ACH payment")]
        public void DoACHPayment(Resident resident)
        {
            double depositTotal = resident.Payment.Amount;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Community);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterPaymentDitails(resident.Payment, depositTotal).SelectResident(1);
            Pages.GetPaymentMenegementPage.EnterPaymentFor1payor(resident.Payment.Amount).SubmitPayment();
        }

        internal bool ErrorMessageDisplaied(string message)
        {
            return Wrap.GetText(UnAppliedErrorMessage).Contains(message);
        }

        internal string GetUnAppliedAmount()
        {
            return Wrap.GetText(UnAppliedAmount);
        }
    }
}