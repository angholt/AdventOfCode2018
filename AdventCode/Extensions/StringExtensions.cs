using System.Text.RegularExpressions;

namespace AdventCode.Extensions
{
    public static class StringExtensions
    {
        public static string GetSubstringBetweenStrings(this string s, string startString, string endString)
        {
            var startPos = s.IndexOf(startString) + startString.Length;
            var endPos = s.IndexOf(endString);
            return s.Substring(startPos, endPos - startPos).Trim();
        }

        public static string ReplaceIgnoreCase(this string s, string find, string replace)
        {
            return Regex.Replace(
                s,
                Regex.Escape(find),
                replace.Replace("$", "$$"),
                RegexOptions.IgnoreCase
            );
        } 
    }
}
