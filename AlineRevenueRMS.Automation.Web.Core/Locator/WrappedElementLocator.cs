using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Locator
{
    public class WrappedElementLocator : WrappedLocator<IWebElement>
    {
        private readonly string _info;
        private readonly IWebElement _webElement;

        public WrappedElementLocator(string info, IWebElement webElement)
        {
            _info = info;
            _webElement = webElement;
        }

        public WrappedElementLocator(IWebElement webElement) : this("wrapped webElement", webElement)
        {
        }

        public override string Info => $"{_info}:{_webElement}";

        public override IWebElement Find()
        {
            return _webElement;
        }
    }
}
