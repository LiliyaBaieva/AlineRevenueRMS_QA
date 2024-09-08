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

        private Resident resident = new Resident(new Payment(111.00, DateTime.Now.Date.AddDays(-7), "For hobbie"));

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
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

            Assert.IsTrue(Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment));
        }

        [TearDown]
        public void Postcondition()
        {
            Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident);
        }
    }
}
