using System.Text.RegularExpressions;

namespace AlineRevenueRMS.Automation.Web.Core.Helpers
{
    internal static class StringHelper
    {
        internal static bool IsEmpty(this string @this)
        {
            return @this == "";
        }

        internal static string ReplaceCamelCaseWithSpaces(string s)
        {
            return Regex.Replace(s, "(\\B[A-Z])", " $1");
        }

        internal static string ReplaceFirstLetterToLowerCase(string s)
        {
            return char.ToLower(s[0]) + s[1..];
        }
    }
}
