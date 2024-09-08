using AlineRevenueRMS_QA;
using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.Net.Commons;
using System;
using Core.models;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using static System.Collections.Specialized.BitVector32;
using Core.constants;

namespace Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Single Payment Entry Tests for different comunities.")]
    public class SinglePaymentEntryTests : TestBase
    {

        private Resident resident = new Resident(new Payment(111.00, DateTime.Now.Date.AddDays(-8), "For hobbie"));

        [SetUp]
        public void precondition() => Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();

        [TearDown]
        public void Postcondition()
        {
            Pages.GetResidentLedgerInElegancePage.MoveToResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident);
        }

        [Test(Description = "Payment Entry In Wentworth Central Avenue")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryInWentworthCentralAvenue()
        {
            resident.Comunity = Comunities.WENTWORT_CENTRAL_AVENUE;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }
        
        [Test(Description = "Payment Entry In Anchor Bay Pocasset (18003)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void PaymentEntryInAnchorBayPocasset()
        {
            resident.Comunity = Comunities.ANCHOR_BAY_POCASSET;
            Pages.GetEleganceRmsHomePage.SelectComunity(resident.Comunity);
            resident.Name = Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterSinglePaymentDetails(resident.Payment).SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue
                (
                Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment) &&
                Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedger().IsPaymentExist(resident.Payment)
                );
        }


    }
}
