using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.WebDriverConditions
{
    public class WindowsTabUrl : Condition<IWebDriver>
    {
        private string _expected = null!;
        private string _actual = null!;

        public WindowsTabUrl(string expected)
        {
            _expected = expected;
        }

        public override bool Apply(IWebDriver entity)
        {
            _actual = entity.Url;
            return _actual.Contains(_expected);
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
