using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Wrappers.Interfaces
{
    public interface IWrappedDriver : IDisposable
    {
        IWebDriver Driver { get; set; }
    }
}
