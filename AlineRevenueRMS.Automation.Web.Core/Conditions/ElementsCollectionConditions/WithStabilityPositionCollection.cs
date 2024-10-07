using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    public class WithStabilityPositionCollection : Condition<WrappedElementsCollection>
    {
        public override bool Apply(WrappedElementsCollection entity)
        {
            var elements = entity.ActualWebElements;
            foreach (var el in elements)
            {
                var pos1 = el.Location;
                var pos2 = el.Location;
                if (!pos2.Equals(pos1))
                    return false;
            }

            return true;
        }
    }
}
