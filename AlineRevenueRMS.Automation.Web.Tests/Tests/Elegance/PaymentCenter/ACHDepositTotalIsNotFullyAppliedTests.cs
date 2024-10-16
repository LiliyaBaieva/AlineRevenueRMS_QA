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
    [AllureFeature("Deposit total is not fully applied tests in communities.")]
    [AllureSuite("Deposit total is not fully applied tests in communities.")]
    public class ACHDepositTotalIsNotFullyAppliedTests : BaseLogin
    {
        public ACHDepositTotalIsNotFullyAppliedTests() : base(1) { }

        [SetUp]
        public void GoToAlineRMSinElegance()
        {
            LoginPage.GoToElegance();
            EleganceAppPage.GotoAlineRevenueRms();
        }

        [Test(Description = "ACH Payment Entry Test for an amount less than the total due")]
        [AllureName("ACH Payment Entry Test for an amount less than the total due")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void ACHPaymentEntryTestForAmountLessThanTotal_NotApplied(string community)
        {
            Resident resident = new Resident(community, new Payment(111.00, DateTime.Now.Date.AddDays(-8), "For hobbie"));
            double depositTotal = 211.00;
            double unAppliedAmount = depositTotal - resident.Payment.Amount;

            EleganceRmsHomePage.SelectComunity(resident.Community);
            EleganceRmsHomePage.NavigateToThePaymentCenter();
            PaymentCenterPage.GoToACHpayment();
            PaymentMenegementPage.EnterPaymentDitails(resident.Payment, depositTotal);
            resident.Name = PaymentMenegementPage.SelectResident(1);
            PaymentMenegementPage.EnterPaymentFor1payor(resident.Payment.Amount);

            PaymentMenegementPage.ErrorMessageDisplaied("Please ensure deposit total is fully applied");
            PaymentMenegementPage.GetUnAppliedAmount().Contains(unAppliedAmount.ToString());
        }
    }
}
