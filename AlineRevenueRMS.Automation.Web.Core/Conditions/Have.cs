using AlineRevenueRMS.Automation.Web.Core.Conditions.Abstractions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.ElementConditions;
using AlineRevenueRMS.Automation.Web.Core.Conditions.ElementsCollectionConditions;
using AlineRevenueRMS.Automation.Web.Core.Element;
using AlineRevenueRMS.Automation.Web.Core.ElementsCollection;

namespace AlineRevenueRMS.Automation.Web.Core.Conditions
{
    public static class Have
    {
        public static Condition<WrappedElement> Attribute(string attributeName, string value) => new ElementConditions.Attribute(attributeName, value);
        public static Condition<WrappedElement> CssClass(string value) => new CssClass(value);
        public static Condition<WrappedElement> ExactText(string value) => new ExactText(value);
        public static Condition<WrappedElement> Text(string value) => new Text(value);
        public static Condition<WrappedElement> Value(string value) => new Value(value);
        public static Condition<WrappedElementsCollection> AttributeCollection(string attributeName, string value) => new AttributeCollection(attributeName, value);
        public static Condition<WrappedElementsCollection> Count(int count) => new Count(count);
        public static Condition<WrappedElementsCollection> CountAtLeast(int count) => new CountAtLeast(count);
        public static Condition<WrappedElementsCollection> TextCollection(string value) => new TextCollection(value);
    }
}
