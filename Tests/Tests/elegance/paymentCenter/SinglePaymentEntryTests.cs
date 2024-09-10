using Allure.NUnit.Attributes;
using Allure.NUnit;
using TestProject.TestData.models;
using TestProject.TestData.constants;
using Allure.Net.Commons;

namespace TestProject.Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Single Payment Entry Tests for different comunities.")]
    public class SinglePaymentEntryTests : TestBase
    {

        private Resident resident = new Resident(new Payment(111.00, DateTime.Now.Date.AddDays(-10), "For hobbie"));

        [SetUp]
        public void precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();

        [TearDown]
        public void Postcondition()
        {
            Pages.GetResidentLedgerInElegancePage.MoveToResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident);
        }

        [Test(Description = "Payment Entry In Wentworth Central Avenue")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInWentworthCentralAvenue()
        {
            resident.Comunity = Comunities.WENTWORT_CENTRAL_AVENUE;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }

        [Test(Description = "Payment Entry In Anchor Bay Pocasset (18003)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInAnchorBayPocasset()
        {
            resident.Comunity = Comunities.ANCHOR_BAY_POCASSET;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }

        [Test(Description = "Payment Entry In Elegance at Lake Worth (12007) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInEleganceAtLakeWorth()
        {
            resident.Comunity = Comunities.ELEGANCE_AT_LAKE_WORTH;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }

        [Test(Description = "Payment Entry In Symphony Manor Roland Park (14001) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInSymphonyManorRolandPark()
        {
            resident.Comunity = Comunities.SYMPHONY_MANOR_ROLAND_PARK;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }

        [Test(Description = "Payment Entry In Symphony Olmsted Falls (16003) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInSymphonyOlmstedFalls()
        {
            resident.Comunity = Comunities.SYMPHONY_OLMSTED_FALLS;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }

        [Test(Description = "Payment Entry In Tranquillity Fredericktowne (14002) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInTranquillityFredericktowne()
        {
            resident.Comunity = Comunities.TRANQUILLITY_FREDERICKTOWNE;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }

        [Ignore("It never works")]
        [Test(Description = "Payment Entry In Demo Community (99999) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryTestInDemoCommunity()
        {
            resident.Comunity = Comunities.DEMO_COMUNITY;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }


    }
}
