using Allure.NUnit.Attributes;
using Allure.NUnit;
using Allure.Net.Commons;
using TestProject.TestData.models;

namespace TestProject.Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Resident Ledger Admin Tests in Wentworth Central Avenue.")]
    public class ResidentLedgerAdminTestsInWentworthCentralAvenue : TestBase
    {
        private Resident resident = new Resident(new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For hobbie"));

        [SetUp]
        public void precondition()
        {
            //Payment payment = new Payment(111.00, DateTime.Now.Date.AddDays(-7), "For hobbie");
            //Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter()
            //    .GoToACHpayment()
            //    .EnterSinglePaymentDetails(payment);
            //resident = Pages.GetPaymentMenegementPage.SelectResident(1);
            //resident.Payment = payment;
            //Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(payment.Amount);
        }


        [Test(Description = "Delete payment test in Resident Ledger Admin")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void DeletePaymentTest()
        {
            //Pages.GetEleganceRmsHomePage.OpenResidentPage(resident);
            //Pages.GetResidentPageInElegance.OpenResidentLedgerAdmin();
            //Pages.GetResidentLedgerAdminInElegancePage.DeletePayment(resident);

            //TODO Assertion
        }

        [TearDown]
        public void Postcondition()
        {

        }

    }
}
