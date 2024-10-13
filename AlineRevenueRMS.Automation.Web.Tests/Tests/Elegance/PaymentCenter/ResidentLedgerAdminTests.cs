using AlineRevenueRMS.Automation.Web.Tests.Pages;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Elegance;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Constants;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using AlineRevenueRMS.Automation.Web.Tests.Tests.Base;
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace AlineRevenueRMS.Automation.Web.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Resident Ledger Admin Tests.")]
    [AllureFeature("Resident Ledger Admin Tests.")]
    public class ResidentLedgerAdminTests : BaseLogin
    {
        public ResidentLedgerAdminTests() : base(1) { }

        private Resident _Resident;

        [SetUp]
        public void Precondition()
        {
            LoginPage.GoToElegance();
            EleganceAppPage.GotoAlineRevenueRms();
        }

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
        public void ResidentLedgerAdminPage_DeletePaymentInvariousCommunitiesTest_Deleted(string community)
        {
            _Resident = new Resident(community, new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For closes"));

            PaymentMenegementPage.DoACHPayment(_Resident);
            EleganceRmsHomePage.OpenResidentPage(_Resident);
            ResidentPageInElegance.OpenResidentLedgerAdmin();
            ResidentLedgerAdminInElegancePage.DeletePayment(_Resident);

            ResidentLedgerAdminInElegancePage.MakeASurePaymentDoesntExist(_Resident);
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
        public void ResidentLedgerAdminPage_UpdatePaymentInvariousCommunitiesTest_Updated(string community)
        {
            _Resident = new Resident(community, new Payment(222.00, DateTime.Now.Date.AddDays(-7), "For closes"));
            double newAmmount = 555.00;
            PaymentMenegementPage.DoACHPayment(_Resident);

            EleganceRmsHomePage.OpenResidentPage(_Resident);
            ResidentPageInElegance.OpenResidentLedgerAdmin();
            ResidentLedgerAdminInElegancePage.UpdatePayment(_Resident, newAmmount);

            ResidentLedgerAdminInElegancePage.PaymentIsUpdatedSuccessfully(_Resident, newAmmount);

            _Resident.Payment.Amount = newAmmount;
            ResidentLedgerInElegancePage.BackToResidentDashboard(_Resident);
            ResidentPageInElegance.OpenResidentLedgerAdmin();
            ResidentLedgerAdminInElegancePage.DeletePayment(_Resident);
        }

    }
}
