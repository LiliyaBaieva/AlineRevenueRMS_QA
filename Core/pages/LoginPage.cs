using Core;
using Core.pages;
using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage() { }

        private IWebElement loginField => Driver.FindElement(By.Id("Username"));
        private IWebElement passwordField => Driver.FindElement(By.Id("Password"));
        private IWebElement signInBtn => Driver.FindElement(By.Id("Submit"));
        private IWebElement SubmitMultiTenant => Driver.FindElement(By.Id("SubmitMultiTenant"));
        private IWebElement tenantCollection => Driver.FindElement(By.Id("TenantCollection"));
        private IWebElement eleganceOption => Driver.FindElement(By.XPath("//option[contains(text(),'Elegance')]"));

        public LoginPage LogInToApp()
        {
            SendKeysText(loginField, ConfigurationManager.Configuration["Logging:Name"]);
            SendKeysText(passwordField, ConfigurationManager.Configuration["Logging:Password"]);
            Click(signInBtn);
            logger.Debug("Login to application");
            return this;
        }

        public EleganceAppPage GoToElegance()
        {
            Click(eleganceOption);
            Click(SubmitMultiTenant);
            logger.Debug("Go to Elegance");
            return new EleganceAppPage();
        }

        public bool IsTenantPresent()
        {
            return IsElementPresent(tenantCollection);
        }

    }
}