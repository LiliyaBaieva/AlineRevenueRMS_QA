using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class PageFactory
    {
        public PageFactory() { }

        public LoginPage GetLoginPage => new LoginPage();
        public EleganceAppPage GetEleganceAppPage => new EleganceAppPage();
        public EleganceRmsHomePage GetEleganceRmsHomePage => new EleganceRmsHomePage();
        public PaymentCenterPage GetPaymentCenterPage => new PaymentCenterPage();
        public PaymentMenegementPage GetPaymentMenegementPage => new PaymentMenegementPage();
        public ResidentPageInElegance GetResidentPageInElegance => new ResidentPageInElegance();
        public ResidentLedgerAdminInElegancePage GetResidentLedgerAdminInElegancePage => new ResidentLedgerAdminInElegancePage();
        public ResidentLedgerInElegancePage GetResidentLedgerInElegancePage => new ResidentLedgerInElegancePage();
 

    }
}
