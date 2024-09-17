using Allure.NUnit.Attributes;
using Allure.NUnit;
using TestProject.TestData.Models;
using TestProject.TestData.Constants;
using Allure.Net.Commons;

namespace TestProject.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("Single Payment Entry Tests in communities.")]
    [AllureSuite("Single Payment Entry Tests in communities.")]
    public class SinglePaymentEntryTests : TestBase
    {
        private Resident _Resident;

        [SetUp]
        public void Precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();

        [TearDown]
        public void Postcondition()
        {
            Pages.GetResidentLedgerInElegancePage.MoveToResidentPage(_Resident).OpenResidentLedgerAdmin().DeletePayment(_Resident);
        }

        [Test(Description = "Payment Entry Test in various communities")]
        [AllureName("Payment Entry Test in various communities")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void PaymentEntryTestInVariousCommunities(string community)
        {
            _Resident = new Resident(new Payment(111.00, DateTime.Now.Date.AddDays(-8), "For hobbie"))
            {
                Community = community
            };

            Pages.GetEleganceRmsHomePage.SelectComunity(_Resident.Community);
            _Resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(_Resident.Payment).SelectResident(1);

            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(_Resident.Payment.Amount);

            Assert.IsTrue((
                Pages.GetPaymentMenegementPage.PaymentSuccessful(_Resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident).OpenResidentLedger().IsPaymentExist(_Resident.Payment)),
                "Payment doesn`t exist."
            );
        }

        [Test(Description = "Payment Entry Test in various communities with specific date")]
        [AllureName("Payment Entry Test in various communities with specific date")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void PaymentEntryTestWith1DateOfMonth(string community)
        {
            string dateString = "2024-09-01";
            DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            _Resident = new Resident(new Payment(111.00, date, "For hobbie"))
            {
                Community = community
            };

            Pages.GetEleganceRmsHomePage.SelectComunity(_Resident.Community);
            _Resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(_Resident.Payment).SelectResident(1);

            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(_Resident.Payment.Amount);

            Assert.IsTrue(
                Pages.GetPaymentMenegementPage.PaymentSuccessful(_Resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident).OpenResidentLedger().IsPaymentExist(_Resident.Payment)
            );
        }
    }
}
