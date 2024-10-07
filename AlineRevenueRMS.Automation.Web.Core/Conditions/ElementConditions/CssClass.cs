using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class CssClass : Condition<WrappedElement>
    {
        private readonly string _expected;
        private string _actual;

        public CssClass(string expected)
        {
            _expected = expected;
            _actual = string.Empty;
        }

        public override bool Apply(WrappedElement entity)
        {
            _actual = entity.ActualWebElement.GetAttribute("class");
            return _actual != null && _actual.Split(' ').Any(a => a.Contains(_expected));
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
