using System.Text.RegularExpressions;

namespace AlineRevenueRMS.Automation.Web.Tests.Helpers
{
    internal static class StringHelper
    {
        internal static string DeleteUnnecessarySymbols(this string str)
        {
            return Regex.Replace(str, "[\"'@()]", string.Empty);
        }
    }
}
