﻿
using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class ResidentPageInElegance : BasePage
    {
        private By TaskListInResidentActivity = By.XPath("//div[contains(text(), 'Resident Activity')]/../..//a[@class='dropdown-toggle']");
        private By ResidentLedgerAdmin = By.XPath("//a[contains(@href, 'ResidentLedger.aspx')]");
        private By ResidentLedger = By.XPath("//a[contains(@href, '/ResidentLedger/ResidentLedger2.aspx')]");

        public ResidentPageInElegance() { }

        public ResidentLedgerInElegancePage OpenResidentLedger()
        {
            Wrap.ScrollDown(1);
            Wrap.Click(TaskListInResidentActivity);
            Wrap.Click(ResidentLedger);
            logger.Info("Open Rsident Ledger");
            return new ResidentLedgerInElegancePage();
        }

        [AllureStep("Open Resident Ledger Admin")]
        public ResidentLedgerAdminInElegancePage OpenResidentLedgerAdmin()
        {
            Wrap.ScrollDown(1);
            Wrap.Click(TaskListInResidentActivity);
            Wrap.Click(ResidentLedgerAdmin);
            logger.Info("Open Rsident Ledger Admin");
            return new ResidentLedgerAdminInElegancePage();
        }
    }
}