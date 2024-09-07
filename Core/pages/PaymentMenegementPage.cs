
using AlineRevenueRMS_QA;
using AlineRevenueRMS_QA.Pages;
using Core.models;
using OpenQA.Selenium;

namespace Core.pages
{
    public class PaymentMenegementPage : BasePage
    {
        public PaymentMenegementPage(){}

        public By PaymentManagement = By.LinkText("Payment Management");
        public By PaymentDescriprionField = By.Id("BatchPaymentDescStep1");
        public By ContinueBtn = By.Id("Submit");
        public By DataField = By.Id("CheckDateStep1");
        public By ResidentCheckbox(int residentNum) => 
            By.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//*[@class='ag-selection-checkbox']/div");
        public By ResidentToSelect(int residentNum) =>
            By.XPath($"//*[@class='ag-center-cols-container']/div[{residentNum}]//span[@class='ag-cell-value']");
        public By PaySelectedItem = By.CssSelector(".btn-outline-secondary");
        public By AppliedAmountSell(int residentNum) => 
            By.CssSelector($" div[row-id='{residentNum-1}'] div.ag-cell-value[col-id='itemAppliedAmount']");
        public By CheckBoxInPaymentCart(int residentNum) => 
            By.CssSelector($"div[row-id='{residentNum-1}'] div.ag-checkbox-input-wrapper");
        public By SubmitPaymentsBtn = By.CssSelector("input[value='Submit Payments']");
        public By PaymentSuccessfullySubmitted = By.XPath("//h2[contains(text(), 'Payment Successfully Submitted')]");
        public By Description = By.Id("displayBatchPaymentDesc");
        public By Applied = By.Id("applied");



        public PaymentMenegementPage EnterSinglePaymentDetails(Payment payment)
        {
            EnterDateInField(DataField, payment.Date);
            SendKeysText(PaymentDescriprionField, payment.Description);
            Click(ContinueBtn);
            logger.Debug("Enter Single Payment Details");
            return this;
        }

        public Resident SelectResident(int residentNum)
        {
            ScrollDown(2);
            Click(ResidentCheckbox(residentNum));
            Resident resident = new Resident();
            resident.Name = GetText(ResidentToSelect(residentNum));
            logger.Debug("Resident \"{0}\" is selected", resident.Name);
            return resident;
        }

        public void SubmitPaymentFor1payor(double amount)
        {

            // click on button 'Pay Selected Item
            Click(PaySelectedItem);
            ScrollDown(2);

            // in column 'Applied Amount' enter amount,
            SendKeysText(AppliedAmountSell(1), ""+amount);
            ClickEnter(AppliedAmountSell(1));
            Click(CheckBoxInPaymentCart(1));

            // click on button 'Submit Payments',
            Click(SubmitPaymentsBtn);
            SubmitAlert();
            logger.Debug("Set ammount {0} for one payor", amount);
        }

        public bool? PaymentSuccessful(Payment payment)
        {
            ScrollUp(2);
            if (
            IsElementPresent(PaymentSuccessfullySubmitted) &&
            GetText(Description).Contains(payment.Description) &&
            GetText(Applied).Contains("" + payment.Amount)
                ) { return true; }
            else { return false; }
        }
    }
}