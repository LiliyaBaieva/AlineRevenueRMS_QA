using Allure.NUnit.Attributes;
using Allure.NUnit;
using Allure.Net.Commons;
using TestProject.TestData.models;
using TestProject.TestData.constants;
using OpenQA.Selenium;

namespace TestProject.Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Resident Ledger Admin Tests.")]
    public class ResidentLedgerAdminTests : TestBase
    {
        private Resident _Resident;
        
        private Resident residentAnchorBay = new Resident(Comunities.ANCHOR_BAY_POCASSET, 
            new Payment(222.00, DateTime.Now.Date.AddDays(-15), "For closes"));


        [SetUp]
        public void precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();



        [Test(Description = "Delete payment test in Resident Ledger Admin in Wentworth Central Avenue (12006) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void DeletePaymentInVariousCommunities(string comunity)
        {
            _Resident = new Resident(comunity, new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For closes"));
            Pages.GetPaymentMenegementPage.DoACHPayment(_Resident);

            Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident);
            Pages.GetResidentPageInElegance.OpenResidentLedgerAdmin();
            Pages.GetResidentLedgerAdminInElegancePage.DeletePayment(_Resident);

            Assert.True(Pages.GetResidentLedgerAdminInElegancePage.PaymentDoesntExist(_Resident));
        }

    }
}
