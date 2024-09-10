using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlineRevenueRMS_QA
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class DriverManager
    {
        private static readonly Lazy<DriverManager> lazy = new Lazy<DriverManager>(() => new DriverManager());

        private IWebDriver Webdriver;
        public IWebDriver CurrentDriver => getDriver();


        private DriverManager(){}

        private IWebDriver getDriver()
        {
            if (Webdriver == null)
            {
                Webdriver = new ChromeDriver();
                Webdriver.Manage().Window.Maximize();
            }
            return Webdriver;
        }

        public static DriverManager GetInstance()
        {
            return lazy.Value;
        }

        public void QuitDriver()
        {
            if (Webdriver == null)
            {
                return;
            }
            else
            {
                Webdriver.Quit();
                Webdriver = null;
            }
        }
    }

}
