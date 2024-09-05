using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NLog;
using NLog.Fluent;
using SeleniumExtras.WaitHelpers;

namespace AlineRevenueRMS_QA.Pages
{
    public abstract class BasePage
    {

        protected static IWebDriver Driver = AlineRevenueRMS_QA.Driver.GetDriver();
        protected WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public void Click(IWebElement element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public void SendKeysText(IWebElement element, string text)
        {
            Wait.Until(driver => element.Displayed && element.Enabled);
            element.Clear();
            element.SendKeys(text);
        }

        public bool IsElementPresent(IWebElement element)
        {

            try
            {
                Wait.Until(driver => element.Displayed && element.Enabled);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }


    }
}
