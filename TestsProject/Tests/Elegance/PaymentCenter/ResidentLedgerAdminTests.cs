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
    [AllureSuite("Resident Ledger Admin Tests.")]
    [AllureFeature("Resident Ledger Admin Tests.")]
    public class ResidentLedgerAdminTests : TestBase
    {
        private Resident _Resident;

        [SetUp]
        public void precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();

        [Test(Description = "Delete payment test in Resident Ledger Admin in various communities")]
        [AllureName("Delete payment test in Resident Ledger Admin in various communities")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
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

            Assert.True(Pages.GetResidentLedgerAdminInElegancePage.PaymentDoesntExist(_Resident), 
                "Payment wasn`t deleted.");
        }
        
        [Test(Description = "Update payment test in Resident Ledger Admin in various communities")]
        [AllureName("Update payment test in Resident Ledger Admin in various communities")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void UpdatePaymentInvariousCommunitiesTest(string community)
        {
            _Resident = new Resident(community, new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For closes"));
            double newAmmount = 555.00;
            Pages.GetPaymentMenegementPage.DoACHPayment(_Resident);

            Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident);
            Pages.GetResidentPageInElegance.OpenResidentLedgerAdmin();
            Pages.GetResidentLedgerAdminInElegancePage.UpdatePayment(_Resident, newAmmount);

            Assert.True(Pages.GetResidentLedgerAdminInElegancePage.PaymenExist(_Resident, newAmmount) &&
                Pages.GetResidentLedgerAdminInElegancePage.RecentPaymentDoesntExist(_Resident),
                "Payment wasn`t updated.");

            _Resident.Payment.Amount = newAmmount;
            Pages.GetResidentLedgerInElegancePage.MoveToResidentPage(_Resident).OpenResidentLedgerAdmin().DeletePayment(_Resident);
        }

    }
}
