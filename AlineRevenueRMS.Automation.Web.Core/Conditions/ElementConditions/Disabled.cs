using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class Disabled : Condition<WrappedElement>
    {
        public override bool Apply(WrappedElement element)
        {
            return element.ActualWebElement.Displayed && !element.ActualWebElement.Enabled;
        }
    }
}
