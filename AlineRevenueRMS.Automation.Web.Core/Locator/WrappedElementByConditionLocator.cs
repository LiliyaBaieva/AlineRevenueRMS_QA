using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Locator
{
    public class WrappedElementByConditionLocator : WrappedLocator<IWebElement>
    {
        private readonly Condition<WrappedElement> _condition;
        private readonly WrappedElementsCollection _collection;
        private readonly WrappedDriver _driver;

        public WrappedElementByConditionLocator(Condition<WrappedElement> condition, WrappedElementsCollection collection, WrappedDriver driver)
        {
            _condition = condition;
            _collection = collection;
            _driver = driver;
        }

        public override string Info => $"{_collection}.FindBy{_condition.Explain()}";
        public override IWebElement Find()
        {
            var webElements = _collection.ActualWebElements;

            var found = webElements.ToList()
                .Find(e => _condition.Apply(new WrappedElement(
                    new WrappedElementLocator(
                        $"{Info}", e),
                    _driver, $"{_collection.Description} filtering by {_condition.Explain()}")));

            if (found != null) return found;
            {
                var actualTexts = webElements.ToList().Select(element => element.Text).ToArray();
                throw new NotFoundException(
                    $"element was not found in collection by condition {_condition.Explain()}{Environment.NewLine}Actual visible texts : [{string.Join(",", actualTexts)}]");
            }
        }
    }
}
