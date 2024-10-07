using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class Visible : Condition<WrappedElement>
    {
        public override bool Apply(WrappedElement element)
        {
            var result = element.ActualWebElement.Displayed;
            return result;
        }
    }
}
