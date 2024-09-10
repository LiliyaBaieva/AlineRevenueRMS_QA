
using AlineRevenueRMS_QA;
using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using TestProject.TestData.models;

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
            Wrap.EnterDateInField(DataField, payment.Date);
            Wrap.SendKeysText(PaymentDescriprionField, payment.Description);
            Wrap.Click(ContinueBtn);
            logger.Info("Enter Single Payment Details with date '{0}' and amount {1}", payment.Date.ToString(), ""+payment.Amount);
            return this;
        }

        public string SelectResident(int residentNum)
        {
            Wrap.ScrollDown(2);
            Wrap.Click(ResidentCheckbox(residentNum));
            string name = Wrap.GetText(ResidentToSelect(residentNum));
            logger.Info("Resident '{0}' is selected", name);
            return name;
        }

        public PaymentMenegementPage SubmitPaymentFor1payor(double amount)
        {
            Wrap.Click(PaySelectedItem);
            Wrap.ScrollDown(2);
            Wrap.SendKeysText(AppliedAmountSell(1), ""+amount);
            Wrap.ClickEnter(AppliedAmountSell(1));
            Wrap.Click(CheckBoxInPaymentCart(1));
            logger.Info("Set ammount {0} for one payor", amount);
            Wrap.Click(SubmitPaymentsBtn);
            Wrap.SubmitAlert();
            logger.Info("Confirm payment.");
            return this;
        }

        public bool PaymentSuccessful(Payment payment)
        {
            Wrap.ScrollUp(2);
            if (
            Wrap.IsElementPresent(PaymentSuccessfullySubmitted) &&
            Wrap.GetText(Description).Contains(payment.Description) &&
            Wrap.GetText(Applied).Contains("" + payment.Amount)
                ) 
            {
                logger.Info("Payment was upplied successfully");
                return true;
            }
            else { return false; }
        }
    }
}