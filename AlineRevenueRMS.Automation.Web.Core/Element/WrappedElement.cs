using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element.Interfaces;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;
using AlineRevenueRMS.Automation.Web.Core.Locator;
using AlineRevenueRMS.Automation.Web.Core.Locator.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Locator.Interfaces;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System.Collections.ObjectModel;
using System.Drawing;

namespace AlineRevenueRMS.Automation.Web.Core.Element
{
    public class WrappedElement : IWrappedElement, IWebElement, IWrappedSearchContext
    {
        private readonly WrappedDriver _driver;
        private readonly WrappedLocator<IWebElement> _locator;
        public string Description { get; }

        public WrappedElement(WrappedLocator<IWebElement> locator, WrappedDriver driver, string description)
        {
            _locator = locator;
            _driver = driver;
            Description = description;
        }

        public WrappedElement(By locator, WrappedDriver driver, string description)
            : this(new WrappedElementSearchContextLocator(locator, driver), driver, description)
        {
        }

        internal WrappedElement(IWebElement elementToWrap, IWebDriver driver, string description)
            : this(new WrappedElementLocator(elementToWrap), new WrappedDriver(driver), description)
        {
        }

        public WrappedElement(By locator, string description)
            : this(new WrappedElementSearchContextLocator(locator, DriverManager.CommonDriver), DriverManager.CommonDriver, description)
        {
        }

        public Actions Actions => _driver.Actions();

        public IWebElement ActualWebElement => _locator.Find();

        #region IWebElement methods
        public string TagName
        {
            get
            {
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
                Should(Be.Visible);
                return ActualWebElement.TagName;
            }
        }

        public string Text
        {
            get
            {
                Log.Information($"Get the text of the '{Description}'");
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
                Should(Be.Visible);
                return ActualWebElement.Text;
            }
        }

        public bool Enabled
        {
            get
            {
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
                Should(Be.Visible);
                return ActualWebElement.Enabled;
            }
        }

        public bool Selected
        {
            get
            {
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
                Should(Be.Visible);
                return ActualWebElement.Selected;
            }
        }

        public Point Location
        {
            get
            {
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
                Should(Be.Visible);
                return ActualWebElement.Location;
            }
        }

        public Size Size
        {
            get
            {
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
                Should(Be.Visible);
                return ActualWebElement.Size;
            }
        }

        public bool Displayed
        {
            get
            {
                WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
                Should(Be.InDom);
                return ActualWebElement.Displayed;
            }
        }

        public WrappedElement Clear()
        {
            Log.Information($"Clear '{Description}'");
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            ActualWebElement.Clear();
            return this;
        }

        void IWebElement.Clear()
        {
            Log.Information($"Clear '{Description}'");
            Clear();
        }

        public WrappedElement SendKeys(string text)
        {
            Log.Information($"Send keys to the element '{Description}': '{text}' ");
            Should(Be.InDom);
            ActualWebElement.Clear();
            ActualWebElement.SendKeys(text);
            return this;
        }

        void IWebElement.SendKeys(string text)
        {
            Log.Information($"Send keys to the element '{Description}': '{text}' ");
            SendKeys(text);
        }

        public WrappedElement Submit()
        {
            Log.Information($"Submit '{Description}'");
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            ActualWebElement.Submit();
            return this;
        }

        void IWebElement.Submit()
        {
            Log.Information($"Submit '{Description}'");
            Submit();
        }

        public WrappedElement Click()
        {
            Log.Information($"Click '{Description}'");
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
            Should(Be.WithStabilityPosition);
            Should(Be.Clickable);
            ActualWebElement.Click();
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete(), 30);
            return this;
        }

        void IWebElement.Click()
        {
            Log.Information($"Click '{Description}'");
            Click();
        }

        public string GetText()
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            return ActualWebElement.Text;
        }

        public string GetAttribute(string attributeName)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.InDom);
            return ActualWebElement.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.InDom);
            return ActualWebElement.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.InDom);
            return ActualWebElement.GetDomProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.InDom);
            return ActualWebElement.GetCssValue(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            return ActualWebElement.GetShadowRoot();
        }
        #endregion

        #region ISearchContext methods
        IWebElement ISearchContext.FindElement(By @by)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            return new WrappedElement(new WrappedElementSearchContextLocator(by, this), _driver, Description);
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            return new WrappedElementsCollection(new WrappedElementsCollectionSearchContextLocator(by, _driver),
                _driver, Description).ToReadOnlyWebElementsCollection();
        }
        #endregion

        #region IWrappedSearchContext methods
        IWebElement IWrappedSearchContext.FindElement(By by)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            return ActualWebElement.FindElement(by);
        }

        ReadOnlyCollection<IWebElement> IWrappedSearchContext.FindElements(By by)
        {
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            return ActualWebElement.FindElements(by);
        }
        #endregion

        public override string ToString()
        {
            return Description + Environment.NewLine + _locator.Info;
        }

        public WrappedElement PressEnter()
        {
            SendKeys(Keys.Enter);
            return this;
        }

        public WrappedElement Set(string text)
        {
            Log.Information($"Set text '{text}' to the '{Description}'");
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            ActualWebElement.Clear();
            Should(Be.WithEmptyValue);
            ActualWebElement.SendKeys(text);
            Should(Have.Value(text));
            return this;
        }

        public WrappedElement SelectByValue(string value)
        {
            Log.Information($"Select value '{value}' to the '{Description}'");
            WrappedDriverManager.WaitTo(JavaScript.JavaScriptLoadingComplete());
            Should(Be.Visible);
            var selectElement = new SelectElement(ActualWebElement);
            selectElement.SelectByValue(value);
            return this;
        }

        public WrappedElement Find(By locator, string description)
        {
            return new WrappedElement(new WrappedElementSearchContextLocator(locator, this), _driver, description);
        }

        public WrappedElementsCollection FindAll(By locator)
        {
            return new WrappedElementsCollection(new WrappedElementsCollectionSearchContextLocator(locator, this), _driver, Description);
        }

        public WrappedElement Should(Condition<WrappedElement> condition, int waitSeconds = -1)
        {
            Log.Debug($"Check that '{Description}' is '{condition.Explain()}'");
            if (waitSeconds == -1)
            {
                return WrappedDriverManager.WaitFor(this, condition);
            }
            return WrappedDriverManager.WaitFor(this, condition, TimeSpan.FromSeconds(waitSeconds));
        }

        public WrappedElement ShouldNot(Condition<WrappedElement> condition, int waitSeconds = -1)
        {
            Log.Debug($"Check that '{Description}' is not '{condition.Explain()}'");
            if (waitSeconds == -1)
            {
                return WrappedDriverManager.WaitForNot(this, condition);
            }
            return WrappedDriverManager.WaitForNot(this, condition, TimeSpan.FromSeconds(waitSeconds));
        }
    }
}
