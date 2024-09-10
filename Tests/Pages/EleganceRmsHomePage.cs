﻿using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;
using TestProject.TestData.models;

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
        private By ResidentLink = By.CssSelector("button[data-bs-target=\"#residentModal\"]");
        private By SearchResidentInput = By.Id("searchInput");
        private By SearchedResident(string name) => By.XPath($"//div[contains(text(), '{name}')]");

        public EleganceRmsHomePage SelectComunity(string community)
        {
            Wrap.Click(ComunityTab);
            Wrap.WaitUntilElementExist(CommunityFilter);
            Wrap.SendKeysText(CommunityFilter, community);
            Wrap.Click(ComunityInSelector(community));
            logger.Info("Select community: {0}", community);
            return this;
        }

        public PaymentCenterPage NavigateToThePaymentCenter()
        {
            Wrap.Click(QuickActionLink);
            Wrap.Click(PaymentManagement);
            logger.Info("Navigate to Payment Center.");
            return new PaymentCenterPage();
        }

        public ResidentPageInElegance OpenResidentPage(Resident resident)
        {
            Wrap.Click(ResidentLink);
            Wrap.SendKeysText(SearchResidentInput, resident.Name);
            Wrap.Click(SearchedResident(resident.Name));
            logger.Info("Open Lease Menegement for '{0}'", resident.Name);
            return new ResidentPageInElegance();
        }
    }
}