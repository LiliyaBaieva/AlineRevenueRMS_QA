using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;

namespace Core.pages
{
    public class EleganceRmsHomePage : BasePage
    {
        public EleganceRmsHomePage() {}

        private IWebElement ComunityTab => Driver.FindElement(By.XPath("//a[contains(text(),'Community...')]"));
        private IWebElement CommunityFilter => Driver.FindElement(By.Id("communityFilter"));
        private IWebElement WentworthCentralAvenueComunity => Driver.FindElement(By.XPath("//strong[contains(text(),'Wentworth Central Avenue (12006)')]"));

        public void SelectWentworthCentralAvenue()
        {
            Click(ComunityTab);
            logger.Debug("Open modal window to select community");
            //Driver.SwitchTo().Frame(0);
            Driver.SwitchTo().Frame(Driver.FindElement(By.Id("#communityModal")));

            SendKeysText(CommunityFilter, "Wentworth Central Avenue");
            //Click(WentworthCentralAvenueComunity);
        }

    }
}