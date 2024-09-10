using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.pages
{
    public class EleganceAppPage : BasePage
    {
        public EleganceAppPage() { }

        private By ApplicationsMenu => By.XPath("//*[@id='menuGroupStyle44']/a[contains(text(), 'Applications')]");
        private By AlineRevenueRmsLink => By.XPath("//a[contains(text(),'Aline Revenue (RMS)')]");

       public EleganceRmsHomePage GotoAlineRevenueRms ()
        {
            Click(ApplicationsMenu);
            Click(AlineRevenueRmsLink);
            ReadOnlyCollection<string> windows = _Driver.WindowHandles;
            _Driver.SwitchTo().Window(windows[1]);
            WaitUntilPageLoaded();
            logger.Info("Open Elegance Aline Revenue (RMS)");
            return new EleganceRmsHomePage();
        }

    }
}
