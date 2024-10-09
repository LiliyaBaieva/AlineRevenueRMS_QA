using Allure.NUnit.Attributes;
using Allure.NUnit;
using Allure.Net.Commons;
using AngleSharp.Dom;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Constants;
using NUnit.Framework;
using AlineRevenueRMS.Automation.Web.Tests.Tests.Base;
using AlineRevenueRMS.Automation.Web.Tests.TestData.Models;
using AlineRevenueRMS.Automation.Web.Tests.Pages;

namespace AlineRevenueRMS.Automation.Web.Tests.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("ACH Single Payment Entry Tests in communities.")]
    [AllureSuite("ACH Single Payment Entry Tests in communities.")]
    public class ACHSinglePaymentEntryTests : BaseLogin
    {
        public ACHSinglePaymentEntryTests() : base(1){}

        private Resident _Resident;

        [SetUp]
        public void Precondition()
        {
            LoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
        }

        [TearDown]
        public void Postcondition()
        {
            Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident).OpenResidentLedgerAdmin().DeletePayment(_Resident);
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
        public void ACHSinglePaymentEntry_TestInVariousCommunities_Applied(string community)
        {
            _Resident = new Resident(community, new Payment(111.00, DateTime.Now.Date.AddDays(-8), "For hobbie"));
            double depositTotal = _Resident.Payment.Amount;

            Pages.GetEleganceRmsHomePage.SelectComunity(_Resident.Community);
            _Resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterPaymentDitails(_Resident.Payment, depositTotal).SelectResident(1);

            Pages.GetPaymentMenegementPage.EnterPaymentFor1payor(_Resident.Payment.Amount).SubmitPayment();

            Assert.IsTrue(
                Pages.GetPaymentMenegementPage.PaymentSuccessful(_Resident.Payment.Description, _Resident.Payment.Amount) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident).OpenResidentLedger().IsPaymentExist(_Resident.Payment),
                "Payment doesn`t exist."
            );
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

            Pages.GetEleganceRmsHomePage.SelectComunity(_Resident.Community);
            _Resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterPaymentDitails(_Resident.Payment, depositTotal).SelectResident(1);

            Pages.GetPaymentMenegementPage.EnterPaymentFor1payor(_Resident.Payment.Amount).SubmitPayment();

            Assert.IsTrue(
                Pages.GetPaymentMenegementPage.PaymentSuccessful(_Resident.Payment.Description, _Resident.Payment.Amount) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(_Resident).OpenResidentLedger().IsPaymentExist(_Resident.Payment)
            );
        }

    }
}
