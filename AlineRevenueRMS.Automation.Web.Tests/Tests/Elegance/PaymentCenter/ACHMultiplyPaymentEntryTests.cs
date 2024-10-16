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

namespace AlineRevenueRMS.Automation.Web.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("ACH Multiply Payment Entry Tests.")]
    [AllureSuite("ACH Multiply Payment Entry Tests.")]
    public class ACHMultiplyPaymentEntryTests : BaseLogin
    {
        public ACHMultiplyPaymentEntryTests() : base(1) { }

        private List<Resident> _residenstList = new List<Resident>();

        [SetUp]
        public void precondition()
        {
            LoginPage.GoToElegance();
            EleganceAppPage.GotoAlineRevenueRms();
        }

        [TearDown]
        public void Postcondition()
        {
            foreach (Resident resident in _residenstList)
            {
                EleganceRmsHomePage.OpenResidentPage(resident);
                ResidentPageInElegance.OpenResidentLedgerAdmin();
                ResidentLedgerAdminInElegancePage.DeletePayment(resident);
            }
            _residenstList.Clear();
        }

        [Test(Description = "ACH Multiply payment Entry Test in various communities.")]
        [AllureName("ACH Multiply payment Entry Test in various communities.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void ACHMultiplyPaymentEntryTests_InVariousComunities_Applied(string community)
        {
            Payment payment = new Payment(333.00, DateTime.Now.Date.AddDays(-7), "Celebration");
            double depositTotal = Enumerable.Range(0, 3).Select(i =>
            {
                var resident = new Resident(community, payment);
                _residenstList.Add(resident);
                return resident.Payment.Amount;
            }).Sum();

            EleganceRmsHomePage.SelectComunity(community);
            EleganceRmsHomePage.NavigateToThePaymentCenter();
            PaymentCenterPage.GoToACHpayment();
            PaymentMenegementPage.EnterPaymentDitails(payment, depositTotal);

            _residenstList.Select((resident, index) => resident.Name = PaymentMenegementPage.SelectResident(index + 1)).ToList();
            PaymentMenegementPage.EnterPaymentForSeveralPayors(_residenstList);
            PaymentMenegementPage.SubmitPayment();

            PaymentMenegementPage._paymentSuccessfullySubmitted.Should(Be.Visible);
            PaymentMenegementPage._description.GetText().Contains(payment.Description);
            PaymentMenegementPage._totalApplied.GetText().Contains($"{depositTotal}");

            foreach (Resident resident in _residenstList)
            {
                EleganceRmsHomePage.OpenResidentPage(resident);
                ResidentPageInElegance.OpenResidentLedger();
                ResidentLedgerInElegancePage.IsPaymentExist(resident.Payment);
            }
        }
    }
}
