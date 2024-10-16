using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using Allure.NUnit.Attributes;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages.Elegance
{
    public class EleganceAppPage : BasePage
    {
        private static readonly WrappedElement AlineRevenueRmsLink = new(With.XPath("//a[contains(text(),'Aline Revenue (RMS)')]"), "Aline Revenue Rms Link");
        private static readonly WrappedElement ApplicationsMenu = new(With.XPath("//*[@id='menuGroupStyle44']/a[contains(text(), 'Applications')]"), "Aplication link");

        [AllureStep("Go to Aline Revenue Rms")]
        public static void GotoAlineRevenueRms()
        {
            ApplicationsMenu.Click();
            AlineRevenueRmsLink.Click();
            SwitchToTheLastTab();
            EleganceRmsHomePage.ComunityTab.Should(Be.Visible);
        }
    }
}
