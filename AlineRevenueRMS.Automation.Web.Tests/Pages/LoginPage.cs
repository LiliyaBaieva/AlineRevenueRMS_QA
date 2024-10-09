using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class LoginPage : BasePage
    {
        public static WrappedElement UserNameField => new (With.Id("Username"), "User Name field");
        public static WrappedElement PasswordField => new(With.Id("Password"), "Password field");
        public static WrappedElement SignInButton => new(With.Id("Submit"), "SignIn button");
        public static WrappedElement TenantCollectionValidateWarning => new(With.Id("TenantCollectionValidate"), "'You have access to multiple tenants. Please select one.' warning");
        public static WrappedElement SubmitMultiTenant => new(With.Id("SubmitMultiTenant"), "Submit multi Tenant");
        private static WrappedElement TenantCollection => new(With.Id("TenantCollection"), "Tenant Collection");
        private static WrappedElement EleganceOption => new(With.XPath("//option[contains(text(),'Elegance')]"), "Elegance option in select");
        private static WrappedElement ApplicationsMenu => new(With.XPath("//*[@id='menuGroupStyle44']/a[contains(text(), 'Applications')]"), "Aplication link");

        public static void Open()
        {
            Openlink(AppConfiguration.BaseUrl);
        }

        [AllureStep("Log In To App")]
        public LoginPage LogInToApp()
        {
            //Wrap.SendKeysText(UserNameField, ConfigurationManager.Configuration["Logging:Name"]);
            UserNameField.Set(ConfigurationManager.Configuration["Logging:Name"]);

            //Wrap.SendKeysText(PasswordField, ConfigurationManager.Configuration["Logging:Password"]);
            PasswordField.Set(ConfigurationManager.Configuration["Logging:Password"]);

            SignInButton.Click();

            
            logger.Info("Login to application"); // Where I have initialize Logger
            return this;
        }

        [AllureStep("Go to Elegance")]
        public EleganceAppPage GoToElegance()
        {
            EleganceOption.Click();
            SubmitMultiTenant.Click();

            //Assert.IsTrue(Wrap.IsElementPresent(ApplicationsMenu));
            ApplicationsMenu.Should(Be.Visible);

            logger.Info("Go to Elegance");
            return new EleganceAppPage(); // ????? I can`t user builder a step?
        }
    }
}