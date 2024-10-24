using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using AlineRevenueRMS.Automation.Web.Tests.Helpers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Serilog;

namespace AlineRevenueRMS.Automation.Web.Tests.Tests.Base
{
    public class BaseInitWebDriver
    {
        [SetUp]
        public void DriverSetup()
        {
            WrappedDriverManager.InitWebDriver();
        }

        [TearDown]
        public void DriverTearDown()
        {
            var testContext = TestContext.CurrentContext;
            if (testContext.Result.Outcome.Status == TestStatus.Failed)
            {
                MakeScreenshot();
            }
            WrappedDriverManager.GetWebDriver().Quit();
        }

        private static void MakeScreenshot()
        {
            var testContext = TestContext.CurrentContext;
            try
            {
                var ss = WrappedDriverManager.GetWebDriver().TakeScreenshot();
                var filePath = $"{testContext.WorkDirectory}\\{testContext.Test.Name}_{Guid.NewGuid().ToString("N").Substring(0, 6)}_Exception.png";
                filePath = filePath.DeleteUnnecessarySymbols().Replace(" ", "_");
                ss.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath, "screenshot of failed test");
            }
            catch (WebDriverException e)
            {
                Log.Warning($"TearDown: {e.Message}");
            }
        }
    }
}
