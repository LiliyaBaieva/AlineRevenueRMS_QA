using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    public class VisibleCollection : Condition<WrappedElementsCollection>
    {
        public override bool Apply(WrappedElementsCollection entity)
        {
            var elements = entity.ActualWebElements;
            foreach (var element in elements)
            {
                var displayed = element.Displayed;
                if (!displayed) return false;
            }

            return true;
        }
    }
}
