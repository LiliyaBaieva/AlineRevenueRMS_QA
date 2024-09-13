using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TestProject.Core;

namespace AlineRevenueRMS_QA.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage() { }

        private By LoginField = By.Id("Username");
        private By PasswordField => By.Id("Password");
        private By SignInBtn => By.Id("Submit");
        private By SubmitMultiTenant => By.Id("SubmitMultiTenant");
        private By TenantCollection => By.Id("TenantCollection");
        private By EleganceOption => By.XPath("//option[contains(text(),'Elegance')]");
        private By ApplicationsMenu => By.XPath("//*[@id='menuGroupStyle44']/a[contains(text(), 'Applications')]");


        [AllureStep("Log In To App")]
        public LoginPage LogInToApp()
        {
            Wrap.SendKeysText(LoginField, ConfigurationManager.Configuration["Logging:Name"]);
            Wrap.SendKeysText(PasswordField, ConfigurationManager.Configuration["Logging:Password"]);
            Wrap.Click(SignInBtn);
            //Assert.IsTrue(Wrap.IsElementPresent(TenantCollection));
            //Assert.IsTrue(false);
            logger.Info("Login to application");
            return this;
        }

        [AllureStep("Go to Elegance")]
        public EleganceAppPage GoToElegance()
        {
            Wrap.Click(EleganceOption);
            Wrap.Click(SubmitMultiTenant);
            Assert.IsTrue(Wrap.IsElementPresent(ApplicationsMenu));
            logger.Info("Go to Elegance");
            return new EleganceAppPage();
        }

    }
}