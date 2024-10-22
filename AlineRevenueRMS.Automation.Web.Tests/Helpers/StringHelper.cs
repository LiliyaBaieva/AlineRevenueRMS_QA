using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlineRevenueRMS.Automation.Web.Tests.Helpers
{
    internal static class StringHelper
    {
        internal static string ReplaceSpacesAndDeleteSymbols(this string str, string replacement)
        {
            string sanitizedString = Regex.Replace(str, "[\"'@()]", string.Empty);
            return sanitizedString.Replace(" ", replacement);
        }
    }
}
