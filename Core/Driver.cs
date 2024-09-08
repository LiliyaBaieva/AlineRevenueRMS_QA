using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlineRevenueRMS_QA
{
    public class Driver
    {
        private static IWebDriver _driver;
        private static string BaseUrl = ConfigurationManager.Configuration["BaseUrl"];

        public static IWebDriver Instance
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                }
                return _driver;
            }
        }

        public static string Title => Instance.Title;

        public static void Goto(string url)
        {
            Instance.Navigate().GoToUrl(BaseUrl + url);
        }

        public static void Initialize()
        {
            Goto("");
            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
