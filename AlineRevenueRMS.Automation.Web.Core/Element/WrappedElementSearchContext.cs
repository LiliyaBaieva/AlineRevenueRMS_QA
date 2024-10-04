using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Locator.Interfaces;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Element
{
    public class WrappedElementSearchContext : WrappedLocator<IWebElement>
    {
        private readonly IWrappedSearchContext _context;
        private readonly By _locator;

        public WrappedElementSearchContext(By locator, IWrappedSearchContext context)
        {
            _context = context;
            _locator = locator;
        }

        public override string Info => $"By.WrappedLocator: ({_context}).Find({_locator})";
        public override IWebElement Find()
        {
            return _context.FindElement(_locator);
        }
    }
}
