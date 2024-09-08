
using AlineRevenueRMS_QA;
using AlineRevenueRMS_QA.Pages;
using Core.models;
using OpenQA.Selenium;

namespace Core.pages
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
        private By AppliedAmountSell(int residentNum) => 
            By.CssSelector($" div[row-id='{residentNum-1}'] div.ag-cell-value[col-id='itemAppliedAmount']");
        private By CheckBoxInPaymentCart(int residentNum) => 
            By.CssSelector($"div[row-id='{residentNum-1}'] div.ag-checkbox-input-wrapper");
        private By SubmitPaymentsBtn = By.CssSelector("input[value='Submit Payments']");
        private By PaymentSuccessfullySubmitted = By.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]");
        private By Description = By.Id("displayBatchPaymentDesc");
        private By Applied = By.Id("applied");



        public PaymentMenegementPage EnterSinglePaymentDetails(Payment payment)
        {
            EnterDateInField(DataField, payment.Date);
            SendKeysText(PaymentDescriprionField, payment.Description);
            Click(ContinueBtn);
            logger.Info("Enter Single Payment Details");
            return this;
        }

        public string SelectResident(int residentNum)
        {
            ScrollDown(2);
            Click(ResidentCheckbox(residentNum));
            Resident resident = new Resident();
            string name = GetText(ResidentToSelect(residentNum));
            logger.Info("Resident \"{0}\" is selected", resident.Name);
            return name;
        }

        public PaymentMenegementPage SubmitPaymentFor1payor(double amount)
        {
            Click(PaySelectedItem);
            ScrollDown(2);
            SendKeysText(AppliedAmountSell(1), ""+amount);
            ClickEnter(AppliedAmountSell(1));
            Click(CheckBoxInPaymentCart(1));
            logger.Info("Set ammount {0} for one payor", amount);
            Click(SubmitPaymentsBtn);
            SubmitAlert();
            logger.Info("Confirm payment.");
            return this;
        }

        public bool PaymentSuccessful(Payment payment)
        {
            ScrollUp(2);
            if (
            IsElementPresent(PaymentSuccessfullySubmitted) &&
            GetText(Description).Contains(payment.Description) &&
            GetText(Applied).Contains("" + payment.Amount)
                ) 
            {
                logger.Info("Payment was upplied successfully");
                return true;
            }
            else { return false; }
        }
    }
}