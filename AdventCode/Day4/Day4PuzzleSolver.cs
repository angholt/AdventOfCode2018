using AdventCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode.Day4
{
    public class Day4PuzzleSolver : PuzzleSolver
    {
        public Day4PuzzleSolver(string inputFileName) : base(inputFileName)
        {

        }

        public override void SolvePuzzle()
        {
            var logEntries = GetLogEntries();

            var guards = GetGuardSleeps(logEntries);

            var sleepiestGuard = guards.OrderByDescending(gs => gs.Value.TotalSleep).First();

            Console.WriteLine("Part 1 result is: " + sleepiestGuard.Key * sleepiestGuard.Value.GetSleepiestMinute());

            var guardSleepyAtSameTime = GetGuardMostFrequentlyAsleepOnSameMinute(guards);

            Console.WriteLine("Part 2 result is: " + guardSleepyAtSameTime.Key * guardSleepyAtSameTime.Value.GetSleepiestMinute());
        }

        private KeyValuePair<int, Guard> GetGuardMostFrequentlyAsleepOnSameMinute(Dictionary<int, Guard> guards)
        {
            return guards.OrderByDescending(g => g.Value.GetNumberOfTimesAsleepOnSleepiestMinute()).First();
        }

        public Dictionary<int, Guard> GetGuardSleeps(IEnumerable<LogEntry> logEntries)
        {
            int currentGuardId = 0;
            int sleepMinute = 0;
            var guardDict = new Dictionary<int, Guard>();
            foreach(var logEntry in logEntries)
            {
                var entry = logEntry.Entry;
                if (entry.Contains("Guard #"))
                {
                    currentGuardId = int.Parse(entry.GetSubstringBetweenStrings("Guard #", "begins shift"));
                    if (!guardDict.ContainsKey(currentGuardId))
                    {
                        guardDict.Add(currentGuardId, new Guard());
                    }
                }
                else if (entry.Contains("falls asleep"))
                {
                    sleepMinute = logEntry.Date.Minute;
                }
                else if (entry.Contains("wakes up"))
                {
                    guardDict[currentGuardId].SleepPeriods.Add(new SleepPeriod(sleepMinute, logEntry.Date.Minute));
                }
            }

            return guardDict;
        }

        private IEnumerable<LogEntry> GetLogEntries()
        {
            var logEntries = _fileLines.Select(fl => new LogEntry(fl));
            return logEntries.OrderBy(le => le.Date);
        }
    }

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

    public class Guard
    {
        public List<SleepPeriod> SleepPeriods { get; set; }
        public int TotalSleep => SleepPeriods.Sum(sp => sp.Duration);
        public int[] SleepyMinutes { get; set; }
        public Guard()
        {
            SleepPeriods = new List<SleepPeriod>();
        }

        public int[] GetSleepyMinutes()
        {
            int[] sleepyMinutes = new int[60];

            foreach (var sleepPeriod in SleepPeriods)
            {
                for (int i = sleepPeriod.SleepMinute; i < sleepPeriod.WakeMinute; i++)
                {
                    sleepyMinutes[i]++;
                }
            }

            return sleepyMinutes;
        }

        public int GetSleepiestMinute()
        {
            var sleepyMinutes = GetSleepyMinutes();
            return Array.FindIndex(sleepyMinutes, sl => sl == sleepyMinutes.Max());
        }

        public int GetNumberOfTimesAsleepOnSleepiestMinute()
        {
            var sleepyMinutes = GetSleepyMinutes();
            return sleepyMinutes.Max();
        }
    }
    
    public class SleepPeriod
    {
        public int SleepMinute { get; set; }
        public int WakeMinute { get; set; }
        public int Duration => WakeMinute - SleepMinute;
        public SleepPeriod(int sleepMinute, int wakeMinute)
        {
            SleepMinute = sleepMinute;
            WakeMinute = wakeMinute;
        }
    }
}
