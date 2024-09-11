using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlineRevenueRMS_QA.Pages;
using NLog;
using OpenQA.Selenium;
using AlineRevenueRMS_QA;
using TestProject.Core;

namespace TestProject.Tests
{
    public class TestBase
    {

        protected PageFactory Pages = new PageFactory();
        protected DriverManager Driver;

        private static string BaseUrl = ConfigurationManager.Configuration["BaseUrl"];

        [SetUp]
        public void Initialize()
        {
            LogManager.LoadConfiguration("nlog.config");
            Environment.SetEnvironmentVariable("ALLURE_RESULTS_DIR", @"AlineRevenueRMS_QA\allure-results");
            Driver = DriverManager.GetInstance();
            Driver.CurrentDriver.Navigate().GoToUrl(BaseUrl);
            Driver.CurrentDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
        }
    }
}
