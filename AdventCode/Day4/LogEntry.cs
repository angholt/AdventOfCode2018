using AdventCode.Extensions;
using System;

namespace AdventCode.Day4
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string Entry { get; set; }

        public LogEntry(string inputLine)
        {
            var dateString = inputLine.GetSubstringBetweenStrings("[", "]");
            Date = DateTime.Parse(dateString);
            Entry = inputLine.Substring(inputLine.IndexOf("]") + 1);
        }
    }
}
