using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Locator
{
    public class WrappedElementByIndexLocator : WrappedLocator<IWebElement>
    {
        private readonly int _index;
        private readonly WrappedElementsCollection _collection;

        public WrappedElementByIndexLocator(int index, WrappedElementsCollection collection)
        {
            _index = index;
            _collection = collection;
        }

        public override string Info => $"{_collection}[{_index}]";
        public override IWebElement Find()
        {
            return _collection.ActualWebElements[_index];
        }
    }
}
