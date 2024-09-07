using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.pages
{
    public class EleganceRmsHomePage : BasePage
    {
        public EleganceRmsHomePage() {}

        private By ComunityTab = By.XPath("//a[contains(text(),'Community...')]");

        private By CommunityFilter = By.Id("communityFilter");
        private By ComunityInSelector(string community) => By.XPath($"//strong[contains(text(),'{community}')]");

        private By QuickActionLink = By.LinkText("Quick Actions");
        private By PaymentManagement = By.LinkText("Payment Management");


        public EleganceRmsHomePage SelectWentworthCentralAvenue()
        {
            SelectComunity("Wentworth Central Avenue");
            return this;
        }

        private void SelectComunity(string community)
        {
            Click(ComunityTab);
            WaitUntilElementExist(CommunityFilter);
            SendKeysText(CommunityFilter, community);
            Click(ComunityInSelector(community));
            logger.Debug("Select community: {0}", community);
        }

        public PaymentCenterPage NavigateToThePaymentcenter()
        {
            Click(QuickActionLink);
            Click(PaymentManagement);
            logger.Debug("Navigate to Payment Center.");
            return new PaymentCenterPage();
        }
    }
}