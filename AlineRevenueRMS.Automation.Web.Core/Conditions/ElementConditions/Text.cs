using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class Text : Condition<WrappedElement>
    {
        protected string _expected;
        protected string _actual;

        public Text(string expected)
        {
            _expected = expected;
            _actual = string.Empty;
        }

        public override bool Apply(WrappedElement entity)
        {
            _actual = entity.ActualWebElement.Text;
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

        public override string ToString()
        {
            var message =
                $"{GetType().Name}{Environment.NewLine} Expected : {ExpectedResult()}{Environment.NewLine} Actual : {ActualResult()}";

            return message;
        }
    }
}
