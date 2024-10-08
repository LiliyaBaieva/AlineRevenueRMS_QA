﻿using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlineRevenueRMS_QA.Pages
{
    public class EleganceAppPage : BasePage
    {
        public EleganceAppPage() { }

        private By ApplicationsMenu => By.XPath("//*[@id='menuGroupStyle44']/a[contains(text(), 'Applications')]");
        private By AlineRevenueRmsLink => By.XPath("//a[contains(text(),'Aline Revenue (RMS)')]");

        [AllureStep("Go to Aline Revenue Rms")]
       public EleganceRmsHomePage GotoAlineRevenueRms ()
        {
            Wrap.Click(ApplicationsMenu);
            Wrap.Click(AlineRevenueRmsLink);

            Wrap.SwitchToWindow(1);

            Wrap.WaitUntilPageLoaded();
            logger.Info("Open Elegance Aline Revenue (RMS)");
            return new EleganceRmsHomePage();
        }


    }
}
