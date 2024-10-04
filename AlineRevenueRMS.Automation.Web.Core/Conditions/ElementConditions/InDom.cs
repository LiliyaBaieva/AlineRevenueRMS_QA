using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class InDom : Condition<WrappedElement>
    {
        public override bool Apply(WrappedElement element)
        {
            var attribute = element.ActualWebElement;
            return true;
        }
    }
}
