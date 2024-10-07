namespace AlineRevenueRMS.Automation.Web.Core.Conditions.WebDriverConditions
{
    public class JavaScriptLoadingComplete : JsReturnedTrue
    {
        private const string Script = @"try
                        {
                            if (document.readyState != 'complete')
                            {
                                return false;
                            }
                            if (!!window.jQuery && window.jQuery.active != 0)
                            {
                                return false;
                            }                           
                            return true;
                        }
                        catch (ex)
                        {
                            return false;
                        }";

        public JavaScriptLoadingComplete() : base(Script)
        {
        }
    }
}
