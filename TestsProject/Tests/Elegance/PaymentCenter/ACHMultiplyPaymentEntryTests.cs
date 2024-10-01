using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestProject.TestData.Constants;
using TestProject.TestData.Models;

namespace TestProject.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("Multiply Payment Entry Tests.")]
    [AllureSuite("Multiply Payment Entry Tests.")]
    public class ACHMultiplyPaymentEntryTests : TestBase
    {

        private List<Resident> _ResidenstList = new List<Resident>();

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
        }

        [TearDown]
        public void Postcondition()
        {
            _ResidenstList.ForEach(resident =>
            Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident));
            _ResidenstList.Clear();
        }

        [Test(Description = "Multiply payment Entry Test in various communities.")]
        [AllureName("Multiply payment Entry Test in various communities.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void ACHMultiplyPaymentEntryTests_InVariousComunities_Applied(string comunity)
        {
            Payment payment = new Payment(333.00, DateTime.Now.Date.AddDays(-7), "Celebration");
            double depositTotal = Enumerable.Range(0, 3).Select(i =>
            {
                var resident = new Resident(comunity, payment);
                _ResidenstList.Add(resident);
                return resident.Payment.Amount;
            }).Sum();

            Pages.GetEleganceRmsHomePage.SelectComunity(comunity);
            Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterPaymentDitails(payment, depositTotal);

            _ResidenstList.Select((resident, index) => resident.Name = Pages.GetPaymentMenegementPage.SelectResident(index + 1)).ToList();
            Pages.GetPaymentMenegementPage.EnterPaymentForSeveralPayors(_ResidenstList).SubmitPayment();

            Assert.IsTrue(Pages.GetPaymentMenegementPage.PaymentSuccessful(payment.Description, depositTotal), "Payment was not successful");

            Assert.IsTrue(!_ResidenstList.Any(resident =>
                !Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)),
            "Payment doesn`t exist.");

        }

    }
}
