using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    internal class Value : Condition<WrappedElement>
    {
        protected string _expected;
        protected string _actual;

        public Value(string value)
        {
            _expected = value;
            _actual = string.Empty;
        }

        public override bool Apply(WrappedElement entity)
        {
            _actual = entity.ActualWebElement.GetAttribute("value");
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
