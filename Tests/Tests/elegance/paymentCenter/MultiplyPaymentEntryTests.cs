using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TestProject.TestData.models;

namespace TestProject.Tests.elegance.paymentCenter
{
    internal class MultiplyPaymentEntryTests : TestBase
    {

        private List<Resident> ResidentList = new List<Resident>();

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
        }

        [Test(Description = "Payment Entry In Wentworth Central Avenue")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryInWentworthCentralAvenue()
        {
            //Resident resident = new Resident(Comunities.WENTWORT_CENTRAL_AVENUE,
            //    new Payment(111.00, DateTime.Now.Date.AddDays(-7), "For hobbie"));

            //Resident resident = new Resident();
            //resident.Payment = new Payment(111.00, DateTime.Now.Date.AddDays(-7), "For hobbie");
            //resident.Comunity = Comunities.WENTWORT_CENTRAL_AVENUE;

            //Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            //Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
            //    .EnterSinglePaymentDetails(resident.Payment);
            //resident.Name = Pages.GetPaymentMenegementPage.SelectResident(1);
            //ResidentList.Add(resident);
            //Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            //Assert.IsTrue(Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment));
        }

        [TearDown]
        public void Postcondition()
        {
            ResidentList.ForEach(resident =>
            Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident));
        }

    }
}
