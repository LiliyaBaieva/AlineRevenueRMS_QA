using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlineRevenueRMS_QA
{
    public static class Driver
    {
        private static IWebDriver _Driver => GetDriver();
        private static IWebDriver Instatce;
        //private const string BaseUrl = "https://elegance-qa.glennissolutions.com/";
        private static string BaseUrl = ConfigurationManager.Configuration["BaseUrl"];

        public static IWebDriver GetDriver()
        {
            if (Instatce == null)
                Instatce = new ChromeDriver();
            return Instatce;
        }

        public static string Title { get { return _Driver.Title; } }

        public static void Goto(string url)
        {
            _Driver.Navigate().GoToUrl(BaseUrl + url);
        }

        public static void Initialize()
        {
            Goto("");
            _Driver.Manage().Window.Maximize();
            //_Driver.Manage().Timeouts()
        }

        public static void Close()
        {
            _Driver.Quit();
        }
    }
}