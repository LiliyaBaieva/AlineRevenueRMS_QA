using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NLog;
using NLog.Fluent;
using SeleniumExtras.WaitHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;

namespace AlineRevenueRMS_QA.Pages
{
    public abstract class BasePage
    {

        protected static IWebDriver Driver = AlineRevenueRMS_QA.Driver.GetDriver();
        protected WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public void Click(By locator)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        public void SendKeysText(By locator, string text)
        {
            IWebElement webElement = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            //webElement.Clear();
            webElement.SendKeys(text);
        }

        public string GetText(By locator)
        {
         return Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
        }


        public void WaitUntilElementExist(By locator)
        {
            Wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public bool IsElementPresent(By locator)
        {

            try
            {
                Wait.Until(ExpectedConditions.ElementExists(locator));
                Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void WaitUntilPageLoaded()
        {
            Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void EnterDateInField(By dataField, DateTime date)
        {
            SendKeysText(dataField, date.Day.ToString());
            SendKeysText(dataField, date.Month.ToString());
            SendKeysText(dataField, date.Year.ToString());
        }

        public void ScrollDown(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var jsExecutor = (IJavaScriptExecutor)Driver;
                jsExecutor.ExecuteScript("window.scrollBy(0, window.innerHeight / 2);");
            }
        }
        public void ScrollUp(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var jsExecutor = (IJavaScriptExecutor)Driver;
                jsExecutor.ExecuteScript("window.scrollBy(0, -window.innerHeight / 2);");
            }
        }
        public void MoveToTopOfPage()
        {
            var jsExecutor = (IJavaScriptExecutor)Driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, 0);");
        }


        public void ScrollToElement(By locator)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            var jsExecutor = (IJavaScriptExecutor)Driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }


        public void ClickEnter(By locator)
        {
            IWebElement webElement = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            webElement.SendKeys(Keys.Enter);
        }

        public void SubmitAlert() => Wait.Until(ExpectedConditions.AlertIsPresent()).Accept();

    }
}
