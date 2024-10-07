using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.WebDriverConditions
{
    class WindowsTabCount : Condition<IWebDriver>
    {
        private int _expected;
        private int _actual;

        public WindowsTabCount(int expected)
        {
            _expected = expected;
        }

        public override bool Apply(IWebDriver entity)
        {
            _actual = entity.WindowHandles.Count;
            return _actual == _expected;
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
