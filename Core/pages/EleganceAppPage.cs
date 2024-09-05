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

        private IWebElement ApplicationsMenu => Driver.FindElement(By.XPath("//*[@id='menuGroupStyle44']/a[contains(text(), 'Applications')]"));
        private IWebElement AlineRevenueRmsLink => Driver.FindElement(By.XPath("//a[contains(text(),'Aline Revenue (RMS)')]"));

        public EleganceRmsHomePage GotoAlineRevenueRms ()
        {
            Click(ApplicationsMenu);
            Click(AlineRevenueRmsLink);
            ReadOnlyCollection<string> windows = Driver.WindowHandles;
            Driver.SwitchTo().Window(windows[1]);
            logger.Debug("Open Elegance Aline Revenue (RMS)");
            return new EleganceRmsHomePage();
        }

    }
}
