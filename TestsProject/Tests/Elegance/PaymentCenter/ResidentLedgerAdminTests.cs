using Allure.NUnit.Attributes;
using Allure.NUnit;
using Allure.Net.Commons;
using TestProject.TestData.Models;
using TestProject.TestData.Constants;
using OpenQA.Selenium;

namespace TestProject.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Payment Center.")]
    public class ResidentLedgerAdminTests : TestBase
    {
        private Resident _Resident;

        [SetUp]
        public void precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();

        [Test(Description = "Delete payment test in Resident Ledger Admin in various communities")]
        [AllureName("Delete payment test in Resident Ledger Admin in various communities")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void DeletePaymentInvariousCommunitiesTest(string community)
        {
            _Resident = new Resident(community, new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For closes"));
            Pages.GetPaymentMenegementPage.DoACHPayment(_Resident);

            Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident);
            Pages.GetResidentPageInElegance.OpenResidentLedgerAdmin();
            Pages.GetResidentLedgerAdminInElegancePage.DeletePayment(_Resident);

            Assert.True(Pages.GetResidentLedgerAdminInElegancePage.PaymentDoesntExist(_Resident));
        }

    }
}
