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

namespace Tests.elegance.paymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Wentworth Central Avenue payments tests")]
    public class WentworthCentralAvenuePaymentsTests : TestBase
    {

        private Resident resident;

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
            Payment payment = new Payment(100.00, DateTime.Now.Date.AddDays(-7), "For hobbie");
            Pages.GetEleganceRmsHomePage.NavigateToThePaymentcenter()
                .GoToACHpayment()
                .EnterSinglePaymentDetails(payment);
            Resident resident = Pages.GetPaymentMenegementPage.SelectResident(1);
            Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(payment.Amount);

            Assert.IsTrue(Pages.GetPaymentMenegementPage.PaymentSuccessful(payment));

            // DELETE
            Thread.Sleep(2000);
        }
    }
}
