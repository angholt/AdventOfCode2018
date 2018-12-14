using System.Text.RegularExpressions;

namespace AdventCode
{
    public static class StringExtensions
    {
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
