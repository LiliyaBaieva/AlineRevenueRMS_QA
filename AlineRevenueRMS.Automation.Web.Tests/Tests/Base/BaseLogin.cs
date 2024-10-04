using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Tests.Pages;
using NUnit.Framework;

namespace AlineRevenueRMS.Automation.Web.Tests.Tests.Base
{
    public class BaseLogin : BaseInitWebDriver
    {
        private readonly int _setId;

        public BaseLogin(int setId)
        {
            _setId = setId;
        }

        [SetUp]
        public void SetupLogIn()
        {
            var userToLogin = AppConfiguration.Users.Single(u => u.SetId == _setId);

            LoginPage.Open();
            LoginPage.UserNameField.Set(userToLogin.UserName);
            LoginPage.PasswordField.Set(userToLogin.Password);
            LoginPage.SignInButton.Click();
        }
    }
}
