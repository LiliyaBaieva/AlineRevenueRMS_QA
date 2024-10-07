using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.Locator
{
    public class WrappedFilteredElementsCollectionLocator : WrappedLocator<ReadOnlyCollection<IWebElement>>
    {
        private readonly Condition<WrappedElement> _condition;
        private readonly WrappedElementsCollection _collection;
        private readonly WrappedDriver _driver;

        public WrappedFilteredElementsCollectionLocator(Condition<WrappedElement> condition, WrappedElementsCollection collection, WrappedDriver driver)
        {
            _condition = condition;
            _collection = collection;
            _driver = driver;
        }

        public override string Info => $"{_collection}.FindBy{_condition.Explain()}";
        public override ReadOnlyCollection<IWebElement> Find()
        {
            return new(
                _collection.ActualWebElements.Where(e => _condition.Apply(new WrappedElement(
                    new WrappedElementLocator($"{Info}", e), _driver, ""))).ToList());
        }
    }
}
