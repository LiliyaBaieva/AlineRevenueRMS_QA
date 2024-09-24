using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace TestProject.Core
{
    public class WebElementWrapper
    {
        protected IWebDriver _Driver;
        protected WebDriverWait Wait;
        public WebElementWrapper() 
        {
            this._Driver = DriverManager.GetInstance().CurrentDriver;
            this.Wait = new WebDriverWait(_Driver, TimeSpan.FromSeconds(10));
        }

        public void Click(By locator)
        {
            int retryCount = 3;
            for (int attempt = 1; attempt <= retryCount; attempt++)
            {
                try
                {
                    Wait.Until(ExpectedConditions.ElementIsVisible(locator));

                    Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();

                    return;
                }
                catch (StaleElementReferenceException)
                {
                    if (attempt == retryCount)
                    {
                        Assert.Fail($"Failed to click on the element after {retryCount} attempts due to stale element reference: {locator}");
                    }
                }
                catch (WebDriverTimeoutException ex)
                {
                    Assert.Fail($"Failed to click on the element (timed out): {locator}. Exception: {ex.Message}");
                }
                catch (NoSuchElementException ex)
                {
                    Assert.Fail($"No such element found: {locator}. Exception: {ex.Message}");
                }
                catch (ElementClickInterceptedException ex)
                {
                    Assert.Fail($"Element click was intercepted by another element: {locator}. Exception: {ex.Message}");
                }
                catch (WebDriverException ex)
                {
                    Assert.Fail($"WebDriver error occurred when trying to click on the element: {locator}. Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Assert.Fail($"An unexpected error occurred while clicking on the element: {locator}. Exception: {ex.Message}");
                }
            }
        }


        public void SendKeysText(By locator, string text)
        {
            IWebElement webElement = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            webElement.SendKeys(text);
        }
        
        public WebElementWrapper ClearField(By locator)
        {
            IWebElement webElement = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            webElement.Clear();
            return this;
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

        public void SwitchToWindow(int winNum)
        {
            ReadOnlyCollection<string> windows = _Driver.WindowHandles;
            _Driver.SwitchTo().Window(windows[winNum]);
        }

        public void ScrollDown(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var jsExecutor = (IJavaScriptExecutor)_Driver;
                jsExecutor.ExecuteScript("window.scrollBy(0, window.innerHeight / 2);");
            }
        }
        public void ScrollUp(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var jsExecutor = (IJavaScriptExecutor)_Driver;
                jsExecutor.ExecuteScript("window.scrollBy(0, -window.innerHeight / 2);");
            }
        }
        public void MoveToTopOfPage()
        {
            var jsExecutor = (IJavaScriptExecutor)_Driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, 0);");
        }


        public void ScrollToElement(By locator)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            var jsExecutor = (IJavaScriptExecutor)_Driver;
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
