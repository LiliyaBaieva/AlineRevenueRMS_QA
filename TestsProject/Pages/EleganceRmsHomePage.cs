using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TestProject.TestData.Models;

namespace AlineRevenueRMS_QA.Pages
{
    public class EleganceRmsHomePage : BasePage
    {
        public EleganceRmsHomePage() {}

        private By ComunityTab = By.XPath("//a[contains(text(),'Community...')]");
        private By CommunityFilter = By.Id("communityFilter");
        private By ComunityInSelector(string community) => By.XPath($"//strong[contains(text(),'{community}')]");
        private By QuickActionLink = By.LinkText("Quick Actions");
        private By PaymentManagement = By.LinkText("Payment Management");
        private By ResidentLink = By.XPath("//a[contains(@href, 'ResidentModal')]");
        private By SearchResidentInput = By.Id("mdlFilterResident");
        private By SearchedResident(string name) => By.XPath($"//div[contains(text(), '{name}')]");
        private By HomeNav = By.Id("homeNav");


        [AllureStep("Select comunity")]
        public EleganceRmsHomePage SelectComunity(string community)
        {
            Wrap.Click(ComunityTab);
            Wrap.WaitUntilElementExist(CommunityFilter);
            Wrap.SendKeysText(CommunityFilter, community);
            Wrap.Click(ComunityInSelector(community));
            logger.Info($"Select community: {community}");
            return this;
        }

        [AllureStep("Navigate to the Payment Center")]
        public PaymentCenterPage NavigateToThePaymentCenter()
        {
            Wrap.Click(QuickActionLink);
            Wrap.Click(PaymentManagement);
            logger.Info("Navigate to Payment Center.");
            return new PaymentCenterPage();
        }

        [AllureStep("Open Resident Page")]
        public ResidentPageInElegance OpenResidentPage(Resident resident)
        {
            Wrap.Click(HomeNav);
            Wrap.Click(ResidentLink);
            Wrap.SendKeysText(SearchResidentInput, resident.Name);
            Wrap.Click(SearchedResident(resident.Name));
            logger.Info($"Open Lease Menegement for '{resident.Name}'");
            return new ResidentPageInElegance();
        }

    }
}