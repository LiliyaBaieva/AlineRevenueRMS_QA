using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    public class ClickableCollection : Condition<WrappedElementsCollection>
    {
        public override bool Apply(WrappedElementsCollection entity)
        {
            var elements = entity.ActualWebElements;
            foreach (var element in elements)
            {
                var displayed = element.Displayed;
                var enabled = element.Enabled;
                if (!displayed | !enabled) return false;
            }

            return true;
        }
    }
}
