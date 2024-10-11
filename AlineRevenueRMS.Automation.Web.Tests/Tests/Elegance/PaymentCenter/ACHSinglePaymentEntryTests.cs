using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Tests.Pages;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Elegance;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Constants;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using AlineRevenueRMS.Automation.Web.Tests.Tests.Base;
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace AlineRevenueRMS.Automation.Web.Tests.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("ACH Single Payment Entry Tests in communities.")]
    [AllureSuite("ACH Single Payment Entry Tests in communities.")]
    public class ACHSinglePaymentEntryTests : BaseLogin
    {
        public ACHSinglePaymentEntryTests() : base(1){}

        Resident _Resident;

        [SetUp]
        public void GoToAlineRMSinElegance()
        {
            LoginPage.GoToElegance();
            EleganceAppPage.GotoAlineRevenueRms();
        }

        [TearDown]
        public void DeletePaymentFromResident()
        {
            EleganceRmsHomePage.OpenResidentPage(_Resident);
            ResidentPageInElegance.OpenResidentLedgerAdmin();
            ResidentLedgerAdminInElegancePage.DeletePayment(_Resident);
        }

        [Test(Description = "ACH Payment Entry Test in various communities")]
        [AllureName("ACH Payment Entry Test in various communities")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void ACHSinglePaymentEntry_TestInVariousCommunities_PaymentShouldBeSuccessful(string community)
        {
            Resident _Resident = new Resident(community, new Payment(111.00, DateTime.Now.Date.AddDays(-8), "For hobbie"));
            double depositTotal = _Resident.Payment.Amount;

            EleganceRmsHomePage.SelectComunity(_Resident.Community);
            EleganceRmsHomePage.NavigateToThePaymentCenter();
            PaymentCenterPage.GoToACHpayment();
            PaymentMenegementPage.EnterPaymentDitails(_Resident.Payment, depositTotal);
            _Resident.Name = PaymentMenegementPage.SelectResident(1);
            PaymentMenegementPage.EnterPaymentFor1payor(_Resident.Payment.Amount);
            PaymentMenegementPage.SubmitPayment();

            PaymentMenegementPage.PaymentSuccessfullySubmitted.Should(Be.Visible);
            PaymentMenegementPage.Description.GetText().Contains(_Resident.Payment.Description);
            PaymentMenegementPage.TotalApplied.GetText().Contains($"{_Resident.Payment.Amount}");
            EleganceRmsHomePage.OpenResidentPage(_Resident);
            ResidentPageInElegance.OpenResidentLedger();
            ResidentLedgerInElegancePage.IsPaymentExist(_Resident.Payment);
        }

        [Test(Description = "ACH Payment Entry Test in various communities with specific date")]
        [AllureName("ACH Payment Entry Test in various communities with specific date")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void ACHSinglePaymentEntry_TestWith1DateOfMonth_Applied(string community)
        {
            string dateString = "2024-09-01";
            DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            _Resident = new Resident(community, new Payment(111.00, date, "For hobbie"));
            double depositTotal = _Resident.Payment.Amount;

            EleganceRmsHomePage.SelectComunity(_Resident.Community);
            EleganceRmsHomePage.NavigateToThePaymentCenter();
            PaymentCenterPage.GoToACHpayment();
            PaymentMenegementPage.EnterPaymentDitails(_Resident.Payment, depositTotal);
            _Resident.Name = PaymentMenegementPage.SelectResident(1);
            PaymentMenegementPage.EnterPaymentFor1payor(_Resident.Payment.Amount);
            PaymentMenegementPage.SubmitPayment();

            PaymentMenegementPage.PaymentSuccessfullySubmitted.Should(Be.Visible);
            PaymentMenegementPage.Description.GetText().Contains(_Resident.Payment.Description);
            PaymentMenegementPage.TotalApplied.GetText().Contains($"{_Resident.Payment.Amount}");
            EleganceRmsHomePage.OpenResidentPage(_Resident);
            ResidentPageInElegance.OpenResidentLedger();
            ResidentLedgerInElegancePage.IsPaymentExist(_Resident.Payment);
        }

    }
}
