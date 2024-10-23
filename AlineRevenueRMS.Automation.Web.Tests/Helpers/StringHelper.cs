using System.Text.RegularExpressions;

namespace AlineRevenueRMS.Automation.Web.Tests.Helpers
{
    internal static class StringHelper
    {
        internal static string ReplaceSpacesAndDeleteSymbols(this string str, string replacement) // TODO: decompose methods
        {
            string sanitizedString = Regex.Replace(str, "[\"'@()]", string.Empty);
            return sanitizedString.Replace(" ", replacement); // TODO: add " " as argument as well to the method
        }
    }
}
