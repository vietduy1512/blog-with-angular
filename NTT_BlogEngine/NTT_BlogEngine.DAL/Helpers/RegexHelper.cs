using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace NTT_BlogEngine.BlogEngineHelpers
{
    public static class RegexHelper
    {
        public static string CreateSlug(string title)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = title.Normalize(NormalizationForm.FormD);

            result = regex.Replace(result, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            result = Regex.Replace(Regex.Replace(Regex.Replace(result, @"\s+", "_"), @"\W", ""), "_+", "-");

            return result;
        }
    }
}