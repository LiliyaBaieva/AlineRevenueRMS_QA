using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions
{
    public class CountAtLeast : Count
    {
        private int _count;

        public CountAtLeast(int count) : base(count)
        {
            _count = count;
        }

        public override bool Apply(WrappedElementsCollection entity)
        {
            _actualCount = entity.ActualWebElements.Count;
            return _actualCount >= _expectedCount;
        }

        public override string ExpectedResult()
        {
            return $"More or equal '{_count}'";
        }
    }
}
