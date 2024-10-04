using AlineRevenueRMS.Automation.Web.Core.Wrappers.Interfaces;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Wrappers
{
    public class ThreadLocalWrappedDriver : IWrappedDriver
    {
        private readonly ThreadLocal<IWebDriver> _driver;

        public ThreadLocalWrappedDriver()
        {
            _driver = new ThreadLocal<IWebDriver>();
        }

        public IWebDriver Driver
        {
            get
            {
                if (_driver.Value != null)
                    return _driver.Value;

                throw new WebDriverException("WebDriver is null");
            }

            set => _driver.Value = value;
        }

        public static ThreadLocalWrappedDriver Instance = new ThreadLocalWrappedDriver();

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                foreach (var local in _driver.Values)
                {
                    local.Quit();
                }
            }
            _disposedValue = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
