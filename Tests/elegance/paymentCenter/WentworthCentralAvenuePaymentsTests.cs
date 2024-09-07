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
            Pages.GetEleganceRmsHomePage.NavigateToThePaymentcenter()
                .GoToACHpayment()
                .EnterSinglePaymentDetails(7, "For hobbie");

            Resident resident = Pages.GetPaymentMenegementPage.SelectResident(1);

                //.SubmitPaymentFor1payor();

            // LOGGING

            // DELETE
            Thread.Sleep(2000);
        }
    }
}
