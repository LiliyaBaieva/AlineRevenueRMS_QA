using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestProject.TestData.Constants;
using TestProject.TestData.Models;

namespace TestProject.Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("Multiply Payment Entry Tests.")]
    [AllureSuite("Multiply Payment Entry Tests.")]
    public class MultiplyPaymentEntryTests : TestBase
    {

        private List<Resident> ResidentList = new List<Resident>();

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
        }

        [Test(Description = "Multiply payment Entry Test in various communities with specific date")]
        [AllureName("Multiply payment Entry Test in various communities with specific date")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void MultiplyPaymentEntryInVariousComunities(string comunity)
        {
            Resident resident1 = new Resident(comunity, new Payment(111.00, DateTime.Now.Date.AddDays(-7), "For hobbie"));

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
