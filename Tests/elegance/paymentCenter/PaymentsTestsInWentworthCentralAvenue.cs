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

namespace Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Wentworth Central Avenue payments tests")]
    public class PaymentsTestsInWentworthCentralAvenue : TestBase
    {

        private List<Resident> ResidentList = new List<Resident>();

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp()
                .GoToElegance()
                .GotoAlineRevenueRms()
                .SelectWentworthCentralAvenue();
        }

        [Test(Description = "Payment for one resident")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [AllureFeature("Payment Center")]
        public void SinglePaymentEntry()
        {
            Payment payment = new Payment(111.00, DateTime.Now.Date.AddDays(-7), "For hobbie");
            Pages.GetEleganceRmsHomePage.NavigateToThePaymentcenter()
                .GoToACHpayment()
                .EnterSinglePaymentDetails(payment);
            Resident resident = Pages.GetPaymentMenegementPage.SelectResident(1);
            resident.Payment = payment;
            ResidentList.Add(resident);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

            Assert.IsTrue(Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment));
        }

        [TearDown]
        public void Postcondition()
        {
            ResidentList.ForEach(resident => 
            Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident));
        }
    }
}
