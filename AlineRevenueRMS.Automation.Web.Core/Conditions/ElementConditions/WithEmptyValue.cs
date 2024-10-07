using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.Helpers;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    internal class WithEmptyValue : Condition<WrappedElement>
    {
        public override bool Apply(WrappedElement element)
        {
            return element.GetAttribute("value").IsEmpty();
        }
    }
}
