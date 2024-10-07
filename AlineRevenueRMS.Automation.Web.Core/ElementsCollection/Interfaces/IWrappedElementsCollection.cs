using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AlineRevenueRMS.Automation.Web.Core.ElementsCollection.Interfaces
{
    public interface IWrappedElementsCollection
    {
        ReadOnlyCollection<IWebElement> ActualWebElements { get; }
        string Description { get; }
    }
}
