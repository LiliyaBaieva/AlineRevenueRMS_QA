using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    public class AttributeCollection : Condition<WrappedElementsCollection>
    {
        protected string _attributeName;
        protected string _expected;

        public AttributeCollection(string attributeName, string expected)
        {
            _attributeName = attributeName;
            _expected = expected;
        }

        public override bool Apply(WrappedElementsCollection entity)
        {
            var elements = entity.ActualWebElements.Select(e => e.GetAttribute(_attributeName)).ToList();
            return elements.Any(el => el.Contains(_expected, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
