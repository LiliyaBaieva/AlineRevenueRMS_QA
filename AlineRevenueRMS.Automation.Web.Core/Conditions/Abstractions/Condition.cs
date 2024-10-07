using AlineRevenueRMS.Automation.Web.Core.Helpers;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions
{
    public abstract class Condition<TEntity> : BaseCondition<TEntity>
    {

        public virtual string ActualResult()
        {
            return false.ToString(); // TODO: consider providing more "universal" approach... because this makes sense only in case of failed condition:(
        }

        public virtual string ExpectedResult()
        {
            return true.ToString();
        }

        public override string ToString()
        {
            var message =
                $"{GetConditionName()}{Environment.NewLine}  Expected : {ExpectedResult()}{Environment.NewLine}  Actual   : {ActualResult()}";

            return message;
        }

        public override string Explain()
        {
            return $"{GetConditionName()} - {ExpectedResult()}";
        }

        private string GetConditionName()
        {
            return StringHelper.ReplaceCamelCaseWithSpaces(GetType().Name);
        }
    }
}
