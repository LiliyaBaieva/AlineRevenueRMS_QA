
using AlineRevenueRMS_QA.Pages;
using OpenQA.Selenium;

namespace Core.pages
{
    public class ResidentPageInElegance : BasePage
    {
        private By TaskListInResidentActivity = By.XPath("//div[contains(text(), 'Resident Activity')]/../..//a[@class='dropdown-toggle']");
        private By ResidentLedgerAdmin = By.LinkText("• Resident Ledger Admin");
        private By ResidentLedger = By.LinkText("• Resident Ledger");

        public ResidentPageInElegance() { }

        public ResidentLedgerInElegancePage OpenResidentLedger()
        {
            ScrollDown(1);
            Click(TaskListInResidentActivity);
            Click(ResidentLedger);
            logger.Info("Open Rsident Ledger");
            return new ResidentLedgerInElegancePage();
        }

        public ResidentLedgerAdminInElegancePage OpenResidentLedgerAdmin()
        {
            ScrollDown(1);
            Click(TaskListInResidentActivity);
            Click(ResidentLedgerAdmin);
            logger.Info("Open Rsident Ledger Admin");
            return new ResidentLedgerAdminInElegancePage();
        }
    }
}