using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Element.Interfaces
{
    public interface IWrappedElement
    {
        IWebElement ActualWebElement { get; }
        string Description { get; }
    }
}
