using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using OpenQA.Selenium;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.WebDriverConditions
{
    public class JsReturnedTrue : Condition<IWebDriver>
    {
        private readonly string _script;
        private readonly object[] _arguments;
        private bool _result;

        public JsReturnedTrue(string script, params object[] arguments)
        {
            _script = script;
            _arguments = arguments;
        }

        public override bool Apply(IWebDriver entity)
        {
            try
            {
                _result = (bool)((IJavaScriptExecutor)entity).ExecuteScript(_script, _arguments);
            }
            catch (Exception)
            {
                _result = false;
            }

            return _result;
        }
    }
}
