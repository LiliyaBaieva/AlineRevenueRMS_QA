using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Locator.Interfaces;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.Locator
{
    public class WrappedElementsCollectionSearchContextLocator : WrappedLocator<ReadOnlyCollection<IWebElement>>
    {
        private readonly IWrappedSearchContext _context;
        private readonly By _locator;


        public WrappedElementsCollectionSearchContextLocator(By locator, IWrappedSearchContext context)
        {
            _context = context;
            _locator = locator;
        }

        public override string Info => $"{_context}.FindAll({_locator})";
        public override ReadOnlyCollection<IWebElement> Find()
        {
            return _context.FindElements(_locator);
        }
    }
}
