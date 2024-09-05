using AlineRevenueRMS_QA;
using AlineRevenueRMS_QA.Pages;
using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class WentworthCentralAvenuePaymentsTests : TestBase
    {

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
            Pages.GetEleganceRmsHomePage.SelectWentworthCentralAvenue();
            Thread.Sleep(5000);
        }

        [Test]
        public void SinglePaymentEntry()
        {

        }
    }
}
