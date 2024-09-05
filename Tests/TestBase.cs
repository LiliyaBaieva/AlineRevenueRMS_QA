using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlineRevenueRMS_QA.Pages;
using AngleSharp;
using Microsoft.Extensions.Configuration;
using Core;
using NLog;

namespace AlineRevenueRMS_QA
{
    public class TestBase
    {

        protected PageFactory Pages = new PageFactory();

        [SetUp]
        public static void Initialize()
        {
            LogManager.LoadConfiguration("nlog.config");
            //LogManager.LoadConfiguration("NLog");
            Driver.Initialize();
        }

        [TearDown]
        public static void TearDown()
        {
            Driver.Close();
        }
    }
}
