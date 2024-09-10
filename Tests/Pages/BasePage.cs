using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NLog;
using NLog.Fluent;
using SeleniumExtras.WaitHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
using TestProject.Core;

namespace AlineRevenueRMS_QA.Pages
{
    public abstract class BasePage
    {


        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected WebElementWrapper Wrap = new WebElementWrapper();

        public BasePage() {}

        

    }
}
