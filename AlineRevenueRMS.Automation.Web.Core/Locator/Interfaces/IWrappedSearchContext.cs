using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.Locator.Interfaces
{
    public interface IWrappedSearchContext
    {
        IWebElement FindElement(By by);
        ReadOnlyCollection<IWebElement> FindElements(By by);
    }
}
