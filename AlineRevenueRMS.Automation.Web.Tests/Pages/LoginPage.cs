using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Elegance;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

        public static void Open()
        {
            Openlink(AppConfiguration.BaseUrl);
        }

        [AllureStep("Go to Elegance")]
        public static void GoToElegance()
        {
            EleganceOption.Click();
            SubmitMultiTenant.Click();
            EleganceAppPage.ApplicationsMenu.Should(Be.Visible);
        }
    }
}