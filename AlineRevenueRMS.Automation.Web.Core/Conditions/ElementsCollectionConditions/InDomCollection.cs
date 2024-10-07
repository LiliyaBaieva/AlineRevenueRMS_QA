using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    public class InDomCollection : Condition<WrappedElementsCollection>
    {
        public override bool Apply(WrappedElementsCollection entity)
        {
            _ = entity.ActualWebElements;
            return true;
        }
    }
}
