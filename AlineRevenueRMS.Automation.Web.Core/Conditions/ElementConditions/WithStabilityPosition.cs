using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    class WithStabilityPosition : Condition<WrappedElement>
    {
        public override bool Apply(WrappedElement element)
        {
            var pos1 = element.Location;
            var pos2 = element.Location;
            return pos2.Equals(pos1);
        }
    }
}
