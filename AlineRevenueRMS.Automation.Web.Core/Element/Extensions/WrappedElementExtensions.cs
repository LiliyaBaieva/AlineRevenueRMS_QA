using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Core.Configuration;
using AlineRevenueRMS.Automation.Web.Core.Wrappers;
using Serilog;

namespace AlineRevenueRMS.Automation.Web.Core.Element.Extensions
{
    public static class WrappedElementExtensions
    {
        public static bool IsDisplayed(this WrappedElement wrappedElement, int temeoutInMilliseconds = 10000)
        {
            try
            {
                WrappedDriverManager.WaitFor(wrappedElement, Be.Visible, TimeSpan.FromMilliseconds(temeoutInMilliseconds));
                Log.Information($"{wrappedElement.Description} is displayed");
                return true;
            }
            catch
            {
                Log.Information($"{wrappedElement.Description} is not displayed");
                return false;
            }
        }

        public static bool IsClickable(this WrappedElement wrappedElement)
        {
            try
            {
                WrappedDriverManager.WaitFor(wrappedElement, Be.Clickable, AppConfiguration.GetTimeout());
                Log.Information($"{wrappedElement.Description} is сlickable");
                return true;
            }
            catch
            {
                Log.Information($"{wrappedElement.Description} is not сlickable");
                return false;
            }
        }

        public static bool DoesHaveText(this WrappedElement wrappedElement, string text)
        {
            try
            {
                WrappedDriverManager.WaitFor(wrappedElement, Have.Text(text), AppConfiguration.GetTimeout());
                Log.Information($"{wrappedElement.Description} does have '{text}' text");
                return true;
            }
            catch
            {
                Log.Information($"{wrappedElement.Description} does not have '{text}' text");
                return false;
            }
        }
    }
}
