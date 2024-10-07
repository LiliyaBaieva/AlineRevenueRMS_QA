using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Tests.Pages.Base;

namespace AlineRevenueRMS.Automation.Web.Tests.Pages
{
    public class LoginPage : BasePage
    {
        public static WrappedElement UserNameField => new (With.Id("Username"), "User Name field");
        public static WrappedElement PasswordField => new(With.Id("Password"), "Password field");
        public static WrappedElement SignInButton => new(With.Id("Submit"), "SignIn button");
        public static WrappedElement TenantCollectionValidateWarning => new(With.Id("TenantCollectionValidate"), "'You have access to multiple tenants. Please select one.' warning");

        public static void Open()
        {
            Openlink(AppConfiguration.BaseUrl);
        }
    }
}