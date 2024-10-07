using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class Enabled : Condition<WrappedElement>
    {
        public override bool Apply(WrappedElement entity)
        {
            return entity.ActualWebElement.Enabled;
        }
    }
}
