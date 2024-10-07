using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Locator.Interfaces;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.ElementsCollection
{
    class WrappedElementsCollectionSearchContext : WrappedLocator<ReadOnlyCollection<IWebElement>>
    {
        private readonly IWrappedSearchContext _context;
        private readonly By _locator;

        public WrappedElementsCollectionSearchContext(By locator, IWrappedSearchContext context)
        {
            _locator = locator;
            _context = context;
        }

        public override string Info => $"By.Selene: ({_context}).FindAll({_locator})";
        public override ReadOnlyCollection<IWebElement> Find()
        {
            return _context.FindElements(_locator);
        }
    }
}
