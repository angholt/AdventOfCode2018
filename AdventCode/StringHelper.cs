namespace AdventCode
{
    public  static class StringHelper
    {
        public static string GetSubstring(string input, string startString, string endString)
        {
            var startPos = input.IndexOf(startString) + startString.Length;
            var endPos = input.IndexOf(endString);
            return input.Substring(startPos, endPos - startPos).Trim();
        }
    }
}
