using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator.Interfaces;
using AlineRevenueRMS.Automation.Web.Core.Wrappers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.Wrappers
{
    public class WrappedDriver : IWebDriver, INavigation, IWrappedSearchContext
    {
        private readonly IWrappedDriver _source;
        private bool _disposedValue;

        public WrappedDriver(IWrappedDriver driver)
        {
            _source = driver;
        }

        public WrappedDriver(IWebDriver driver) : this(new ExplicitWrappedDriver(driver))
        {
        }

        public WrappedDriver() : this(ThreadLocalWrappedDriver.Instance)
        {
        }

        public IWebDriver Value
        {
            get => _source.Driver;

            set => _source.Driver = value;
        }

        public Actions Actions()
        {
            return new Actions(Value);
        }

        public WrappedElement Find(By @by, string description)
        {
            return new WrappedElement(by, this, description);
        }

        public WrappedElement Find(IWebElement element, string description)
        {
            return new WrappedElement(element, this, description);
        }

        public WrappedElementsCollection FindAll(By @by, string description)
        {
            return new WrappedElementsCollection(by, this, description);
        }

        public WrappedElementsCollection FindAll(IList<IWebElement> elements, string description)
        {
            return new WrappedElementsCollection(elements, this, description);
        }

        #region IWebDriver methods
        public string Title => Value.Title;
        public string PageSource => Value.PageSource;
        public string CurrentWindowHandle => Value.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => Value.WindowHandles;

        public string Url
        {
            get => Value.Url;
            set => Value.Url = value;
        }

        IOptions IWebDriver.Manage()
        {
            return Value.Manage();
        }

        INavigation IWebDriver.Navigate()
        {
            return Value.Navigate();
        }

        ITargetLocator IWebDriver.SwitchTo()
        {
            return Value.SwitchTo();
        }

        protected virtual void Dispose(bool disposing)
        {
            _source.Dispose();
            if (_disposedValue) return;
            if (disposing)
            {
                _source.Dispose();
            }

            _disposedValue = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        void IWebDriver.Close()
        {
            Value.Close();
        }

        void IWebDriver.Quit()
        {
            Value.Quit();
        }

        public void Close()
        {
            Value.Close();
        }

        public void Quit()
        {
            Value.Quit();
        }
        #endregion

        #region INavigation methods
        public void Back()
        {
            Value.Navigate().Back();
        }

        public void Forward()
        {
            Value.Navigate().Forward();
        }

        public void GoToUrl(string url)
        {
            Value.Navigate().GoToUrl(url);
        }

        public void GoToUrl(Uri url)
        {
            Value.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            Value.Navigate().Refresh();
        }
        #endregion

        #region IWrappedSearchContext methods
        IWebElement ISearchContext.FindElement(By by)
        {
            return new WrappedElement(by, this, "no description");
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            return new WrappedElementsCollection(by, this, "no description").ToReadOnlyWebElementsCollection();
        }

        IWebElement IWrappedSearchContext.FindElement(By by)
        {
            return Value.FindElement(by);
        }

        ReadOnlyCollection<IWebElement> IWrappedSearchContext.FindElements(By by)
        {
            return Value.FindElements(by);
        }
        #endregion
    }
}
