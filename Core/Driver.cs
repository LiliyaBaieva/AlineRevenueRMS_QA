using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlineRevenueRMS_QA
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class Driver
    {
        private IWebDriver _Driver;
        private static Driver Instance;
        private static string BaseUrl = ConfigurationManager.Configuration["BaseUrl"];

        public string Title => _Driver.Title;

        private Driver() { }

        public static Driver GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Driver();
            }
            return Instance;
        }

        public Driver SetWebDriver()
        {
            _Driver = new ChromeDriver();
            Goto("");
            _Driver.Manage().Window.Maximize();
            return this;
        }

        public IWebDriver GetWebDriver()
        {
            return _Driver;
        }

        public void CloseWebDriver()
        {
            if (_Driver != null)
            {
                _Driver.Quit();
                _Driver = null;
            }
        }

        public void Goto(string url)
        {
            GetWebDriver().Navigate().GoToUrl(BaseUrl + url);
        }
    }

}
