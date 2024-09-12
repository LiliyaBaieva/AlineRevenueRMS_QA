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
        private Resident residentWenrworth = new Resident(Comunities.WENTWORT_CENTRAL_AVENUE, 
            new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For closes"));
        
        private Resident residentAnchorBay = new Resident(Comunities.ANCHOR_BAY_POCASSET, 
            new Payment(222.00, DateTime.Now.Date.AddDays(-15), "For closes"));


        [SetUp]
        public void precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();



        [Test(Description = "Delete payment test in Resident Ledger Admin in Wentworth Central Avenue (12006) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void DeletePaymentInWentworthCentralAvenueTest()
        {
            Pages.GetPaymentMenegementPage.DoACHPayment(residentWenrworth);

            Pages.GetEleganceRmsHomePage.OpenResidentPage(residentWenrworth);
            Pages.GetResidentPageInElegance.OpenResidentLedgerAdmin();
            Pages.GetResidentLedgerAdminInElegancePage.DeletePayment(residentWenrworth);

            Assert.True(Pages.GetResidentLedgerAdminInElegancePage.PaymentDoesntExist(residentWenrworth));
        }
        
        [Test(Description = "Delete payment test in Resident Ledger Admin in Anchor Bay Pocasset (18003) ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void DeletePaymentInAnchorBayPocassetTest()
        {
            Pages.GetPaymentMenegementPage.DoACHPayment(residentAnchorBay);

            Pages.GetEleganceRmsHomePage.OpenResidentPage(residentAnchorBay);
            Pages.GetResidentPageInElegance.OpenResidentLedgerAdmin();
            Pages.GetResidentLedgerAdminInElegancePage.DeletePayment(residentAnchorBay);

            Assert.True(Pages.GetResidentLedgerAdminInElegancePage.PaymentDoesntExist(residentAnchorBay));
        }

    }
}
