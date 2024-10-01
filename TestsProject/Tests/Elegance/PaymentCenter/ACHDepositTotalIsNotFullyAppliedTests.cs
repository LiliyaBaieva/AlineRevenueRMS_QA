using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using System.Linq;
using TestProject.TestData.Constants;
using TestProject.TestData.Models;
using TestProject.Tests;

namespace TestsProject.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("Deposit total is not fully applied tests in communities.")]
    [AllureSuite("Deposit total is not fully applied tests in communities.")]
    public class ACHDepositTotalIsNotFullyAppliedTests : TestBase
    {
        private Resident _Resident;

        [SetUp]
        public void Precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
        }

        [Test(Description = "Payment Entry Test for an amount less than the total due")]
        [AllureName("Payment Entry Test for an amount less than the total due")]
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
            _Resident = new Resident(community, new Payment(111.00, DateTime.Now.Date.AddDays(-8), "For hobbie"));
            double depositTotal = 211.00;
            double unAppliedAmount = depositTotal - _Resident.Payment.Amount;

            Pages.GetEleganceRmsHomePage.SelectComunity(_Resident.Community);
            _Resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterPaymentDitails(_Resident.Payment, depositTotal).SelectResident(1);

            Pages.GetPaymentMenegementPage.EnterPaymentFor1payor(_Resident.Payment.Amount);

            Assert.IsTrue(Pages.GetPaymentMenegementPage.ErrorMessageDisplaied("Please ensure deposit total is fully applied"));
            Assert.That(Pages.GetPaymentMenegementPage.GetUnAppliedAmount().Contains(unAppliedAmount.ToString()));
        }
    }
}
