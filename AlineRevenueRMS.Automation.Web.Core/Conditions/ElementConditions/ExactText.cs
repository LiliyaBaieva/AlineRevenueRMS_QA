using AlineRevenueRMS.Automation.Web.Core.Element;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions
{
    public class ExactText : Text
    {
        public ExactText(string expected) : base(expected)
        {
        }

        public override bool Apply(WrappedElement entity)
        {
            _actual = entity.ActualWebElement.Text;
            return _actual.Equals(_expected);
        }
    }
}
