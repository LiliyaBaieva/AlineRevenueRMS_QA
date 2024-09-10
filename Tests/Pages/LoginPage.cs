using Core;
using Core.pages;
using OpenQA.Selenium;
using TestProject.Core;

namespace AlineRevenueRMS_QA.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage() { }

        private By loginField = By.Id("Username");
        private By passwordField => By.Id("Password");
        private By signInBtn => By.Id("Submit");
        private By SubmitMultiTenant => By.Id("SubmitMultiTenant");
        private By tenantCollection => By.Id("TenantCollection");
        private By eleganceOption => By.XPath("//option[contains(text(),'Elegance')]");

        public LoginPage LogInToApp()
        {
            SendKeysText(loginField, ConfigurationManager.Configuration["Logging:Name"]);
            SendKeysText(passwordField, ConfigurationManager.Configuration["Logging:Password"]);
            Click(signInBtn);
            logger.Info("Login to application");
            return this;
        }

        public EleganceAppPage GoToElegance()
        {
            Click(eleganceOption);
            Click(SubmitMultiTenant);
            logger.Info("Go to Elegance");
            return new EleganceAppPage();
        }

        public bool IsTenantPresent()
        {
            return IsElementPresent(tenantCollection);
        }

    }
}