using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestProject.TestData.Constants;
using TestProject.TestData.Models;

namespace TestProject.Tests.Elegance.PaymentCenter
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("Multiply Payment Entry Tests.")]
    [AllureSuite("Multiply Payment Entry Tests.")]
    public class MultiplyPaymentEntryTests : TestBase
    {

        private List<Resident> _ResidenstList = new List<Resident>();

        [SetUp]
        public void precondition()
        {
            Pages.GetLoginPage.LogInToApp().GoToElegance().GotoAlineRevenueRms();
        }

        [TearDown]
        public void Postcondition()
        {
            _ResidenstList.ForEach(resident =>
            Pages.GetEleganceRmsHomePage.OpenResidentPage(resident).OpenResidentLedgerAdmin().DeletePayment(resident));
        }

        [Test(Description = "Multiply payment Entry Test in various communities.")]
        [AllureName("Multiply payment Entry Test in various communities.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Regression")]
        [TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        [TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        [TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        [TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        [TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        [TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        public void MultiplyPaymentEntryInVariousComunities(string comunity)
        {
            Payment payment = new Payment(300.00, DateTime.Now.Date.AddDays(-7), "Celebration");

            Pages.GetEleganceRmsHomePage.SelectComunity(comunity);
            Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
                .EnterPaymentDateDescription(payment);

            for (int i = 1; i <= 3; i++)
            {
                Resident resident = new Resident(comunity, payment);
                resident.Name = Pages.GetPaymentMenegementPage.SelectResident(i);
                _ResidenstList.Add(resident);
            }

            Pages.GetPaymentMenegementPage.SubmitPaymentForSeveralPayors(_ResidenstList);

        }
        
        //[Test(Description = "Multiply payment Entry Test in various communities with specific date")]
        //[AllureName("Multiply payment Entry Test in various communities with specific date")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[AllureTag("Regression")]
        //[TestCase(Comunities.WENTWORT_CENTRAL_AVENUE)]
        //[TestCase(Comunities.ANCHOR_BAY_POCASSET)]
        //[TestCase(Comunities.ELEGANCE_AT_LAKE_WORTH)]
        //[TestCase(Comunities.SYMPHONY_MANOR_ROLAND_PARK)]
        //[TestCase(Comunities.SYMPHONY_OLMSTED_FALLS)]
        //[TestCase(Comunities.TRANQUILLITY_FREDERICKTOWNE)]
        //public void MultiplyPaymentEntryInVariousComunities(string comunity)
        //{
        //    Payment payment = new Payment(300.00, DateTime.Now.Date.AddDays(-7), "Celebration");

        //    Resident resident1 = new Resident(comunity, payment);
        //    Resident resident2 = new Resident(comunity, payment);
        //    Resident resident3 = new Resident(comunity, payment);

        //    Pages.GetEleganceRmsHomePage.SelectComunity(comunity);
        //    Pages.GetEleganceRmsHomePage.NavigateToThePaymentCenter().GoToACHpayment()
        //        .EnterPaymentDateDescription(payment);

        //    resident1.Name = Pages.GetPaymentMenegementPage.SelectResident(1);
        //    resident2.Name = Pages.GetPaymentMenegementPage.SelectResident(2);
        //    resident3.Name = Pages.GetPaymentMenegementPage.SelectResident(3);

        //    _ResidenstList.Add(resident1);
        //    _ResidenstList.Add(resident2);
        //    _ResidenstList.Add(resident3);


        //    Pages.GetPaymentMenegementPage.SubmitPaymentFor1payor(resident.Payment.Amount);

        //    //Assert.IsTrue(Pages.GetPaymentMenegementPage.PaymentSuccessful(resident.Payment));
        //}

    }
}
