using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection.Interfaces;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;
using Serilog;
using System.Collections;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.ElementsCollection
{
    public class WrappedElementsCollection : IWrappedElementsCollection, IReadOnlyList<WrappedElement>, IList<WrappedElement>, IList<IWebElement>
    {
        private readonly WrappedDriver _driver;
        readonly WrappedLocator<ReadOnlyCollection<IWebElement>> _locator;
        public string Description { get; }

        public WrappedElementsCollection(WrappedLocator<ReadOnlyCollection<IWebElement>> locator, WrappedDriver driver, string description)
        {
            _locator = locator;
            _driver = driver;
            Description = description;
        }

        public WrappedElementsCollection(By locator, WrappedDriver driver, string description) : this(new WrappedElementsCollectionSearchContextLocator(locator, driver), driver, description)
        {
        }

        public WrappedElementsCollection(By locator, string description) : this(new WrappedElementsCollectionSearchContextLocator(locator, DriverManager.CommonDriver), DriverManager.CommonDriver, description)
        {
        }

        public WrappedElementsCollection(IList<IWebElement> elementsCollection, IWebDriver driver, string description) : this(new WrappedElementsCollectionLocator(elementsCollection), new WrappedDriver(driver), description)
        {
        }

        public ReadOnlyCollection<IWebElement> ActualWebElements => _locator.Find();

        public override string ToString()
        {
            return _locator.Info;
        }

        public WrappedElementsCollection Should(Condition<WrappedElementsCollection> condition, int waitSeconds = -1)
        {
            Log.Debug($"Check collection '{Description}' for '{condition.Explain()}' ");
            if (waitSeconds == -1)
            {
                return WrappedDriverManager.WaitFor(this, condition);
            }
            return WrappedDriverManager.WaitFor(this, condition, TimeSpan.FromSeconds(waitSeconds));
        }

        public WrappedElementsCollection ShouldNot(Condition<WrappedElementsCollection> condition, int waitSeconds = -1)
        {
            Log.Debug($"Check collection '{Description}' for not '{condition.Explain()}' ");
            if (waitSeconds == -1)
            {
                return WrappedDriverManager.WaitForNot(this, condition);
            }
            return WrappedDriverManager.WaitForNot(this, condition, TimeSpan.FromSeconds(waitSeconds));
        }

        public WrappedElement FindBy(Condition<WrappedElement> condition, string description)
        {
            return new WrappedElement(new WrappedElementByConditionLocator(condition, this, _driver), _driver, description);
        }

        public WrappedElementsCollection FilterBy(Condition<WrappedElement> condition)
        {
            return new WrappedElementsCollection(new WrappedFilteredElementsCollectionLocator(condition, this, _driver), _driver, Description);
        }

        public ReadOnlyCollection<IWebElement> ToReadOnlyWebElementsCollection()
        {
            return new ReadOnlyCollection<IWebElement>(this);
        }

        //
        // IReadOnlyList
        //

        public WrappedElement this[int index]
        {
            get
            {
                return new WrappedElement(new WrappedElementByIndexLocator(index, this), _driver, $"{Description} with index #{index}");
            }
        }

        //
        // IReadOnlyCollection
        //

        public int Count
        {
            get
            {
                Should(Be.InDomCollection);
                return ActualWebElements.Count;
            }
        }

        public List<string> GetTextList
        {
            get
            {
                Should(Be.InDomCollection);
                return ActualWebElements.Select(s => s.Text).Where(w => !string.IsNullOrWhiteSpace(w)).ToList();
            }
        }

        public List<string> GetTextListWithEmptyValue
        {
            get
            {
                Should(Be.InDomCollection);
                return ActualWebElements.Select(s => s.Text).ToList();
            }
        }

        public IEnumerator<WrappedElement> GetEnumerator()
        {
            return new ReadOnlyCollection<WrappedElement>(
                ActualWebElements.Select(webElement => new WrappedElement(webElement, _driver, Description)).ToList()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //
        // IList<IWebElement> methods
        //

        int ICollection<IWebElement>.Count
        {
            get
            {
                return Count;
            }
        }

        bool ICollection<IWebElement>.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        IWebElement IList<IWebElement>.this[int index]
        {
            get => this[index];

            set => throw new NotImplementedException();
        }

        int IList<IWebElement>.IndexOf(IWebElement item)
        {
            throw new NotImplementedException();
        }

        void IList<IWebElement>.Insert(int index, IWebElement item)
        {
            throw new NotImplementedException();
        }

        void IList<IWebElement>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void ICollection<IWebElement>.Add(IWebElement item)
        {
            throw new NotImplementedException();
        }

        void ICollection<IWebElement>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<IWebElement>.Contains(IWebElement item)
        {
            throw new NotImplementedException();
        }

        void ICollection<IWebElement>.CopyTo(IWebElement[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if (array.Rank > 1)
                throw new ArgumentException("array is multidimensional.");
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Not enough elements after index in the destination array.");

            for (var i = 0; i < Count; ++i)
                array.SetValue(this[i], i + arrayIndex);
        }

        bool ICollection<IWebElement>.Remove(IWebElement item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<IWebElement> IEnumerable<IWebElement>.GetEnumerator()
        {
            return GetEnumerator();
        }

        //
        // IList<SElement> methods
        //

        bool ICollection<WrappedElement>.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        WrappedElement IList<WrappedElement>.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        int IList<WrappedElement>.IndexOf(WrappedElement item)
        {
            throw new NotImplementedException();
        }

        void IList<WrappedElement>.Insert(int index, WrappedElement item)
        {
            throw new NotImplementedException();
        }

        void IList<WrappedElement>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void ICollection<WrappedElement>.Add(WrappedElement item)
        {
            throw new NotImplementedException();
        }

        void ICollection<WrappedElement>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<WrappedElement>.Contains(WrappedElement item)
        {
            throw new NotImplementedException();
        }

        void ICollection<WrappedElement>.CopyTo(WrappedElement[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<WrappedElement>.Remove(WrappedElement item)
        {
            throw new NotImplementedException();
        }

        public List<string> GetLinksListForCollection()
        {
            return ToReadOnlyWebElementsCollection().Select(a => a.GetAttribute("href")).ToList();
        }
    }
}
