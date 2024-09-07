
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



        public PaymentMenegementPage EnterSinglePaymentDetails(int daysBefore, string paymentDescriprion)
        {
            DateTime date = DateTime.Now.Date.AddDays(-daysBefore);
            EnterDateInField(DataField, date);
            SendKeysText(PaymentDescriprionField, paymentDescriprion);
            Click(ContinueBtn);
            logger.Debug("Enter Single Payment Details");
            return this;
        }

        public Resident SelectResident(int residentNum)
        {
            ScrollDown(2);
            Click(ResidentCheckbox(residentNum));
            logger.Debug("Resident {0} is selected", residentNum);
            Resident resident = new Resident();
            resident.Name = GetText(ResidentToSelect(residentNum));
            logger.Debug("Resident \"{0}\" is selected", resident.Name);
            return resident;
        }

        public void SubmitPaymentFor1payors()
        {

            // click on button 'Pay Selected Item
            // Click(PaySelectedItem);

            // in column 'Applied Amount' enter amount,
            // in column 'Applied Amount' enter amount,


            // click on button 'Submit Payments',
            // confirm allert)
        }
    }
}