namespace AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions
{
    public abstract class BaseCondition<TWebElement>
    {
        public abstract bool Apply(TWebElement entity);

        public abstract string Explain();
    }
}
