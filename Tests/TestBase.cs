using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlineRevenueRMS_QA.Pages;
using NLog;

namespace AlineRevenueRMS_QA
{
    public class TestBase
    {

        protected PageFactory Pages = new PageFactory();

        [SetUp]
        public void Initialize()
        {
            LogManager.LoadConfiguration("nlog.config");
            Environment.SetEnvironmentVariable("ALLURE_RESULTS_DIR", @"AlineRevenueRMS_QA\allure-results");
            Driver.GetInstance().SetWebDriver();
        }

        //[OneTimeTearDown]
        [TearDown]
        public static void TearDown()
        {
            Driver.GetInstance().CloseWebDriver();
        }
    }
}
