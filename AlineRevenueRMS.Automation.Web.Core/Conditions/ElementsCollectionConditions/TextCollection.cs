using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    class TextCollection : Condition<WrappedElementsCollection>
    {
        protected string _expected;
        public TextCollection(string value)
        {
            _expected = value;
        }

        public override bool Apply(WrappedElementsCollection entity)
        {
            var elements = entity.ActualWebElements.Select(e => e.Text).ToList();
            return elements.Any(el => el.Contains(_expected, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
