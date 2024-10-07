using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions
{
    public static class Be
    {
        public static Condition<WrappedElement> Clickable => new Clickable();
        public static Condition<WrappedElement> Enabled => new Enabled();
        public static Condition<WrappedElement> Disabled => new Disabled();
        public static Condition<WrappedElement> InDom => new InDom();
        public static Condition<WrappedElement> Selected => new Selected();
        public static Condition<WrappedElement> Visible => new Visible();
        public static Condition<WrappedElement> WithEmptyValue => new WithEmptyValue();
        public static Condition<WrappedElement> WithStabilityPosition => new WithStabilityPosition();
        public static Condition<WrappedElementsCollection> ClickableCollection => new ClickableCollection();
        public static Condition<WrappedElementsCollection> Empty => new Count(0);
        public static Condition<WrappedElementsCollection> InDomCollection => new InDomCollection();
        public static Condition<WrappedElementsCollection> VisibleCollection => new VisibleCollection();
        public static Condition<WrappedElementsCollection> WithStabilityPositionCollection => new WithStabilityPositionCollection();
    }
}
