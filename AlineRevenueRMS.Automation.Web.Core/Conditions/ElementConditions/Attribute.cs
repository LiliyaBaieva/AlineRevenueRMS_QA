using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    class Attribute : Condition<WrappedElement>
    {
        protected string _expected;
        protected string _actual;
        protected string _attributeName;

        public Attribute(string attributeName, string expected)
        {
            _attributeName = attributeName;
            _expected = expected;
            _actual = string.Empty;
        }

        public override bool Apply(WrappedElement entity)
        {
            _actual = entity.ActualWebElement.GetAttribute(_attributeName);
            return _actual.Contains(_expected, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ActualResult()
        {
            return $"'{_actual}'";
        }

        public override string ExpectedResult()
        {
            return $"'{_expected}'";
        }
    }
}
