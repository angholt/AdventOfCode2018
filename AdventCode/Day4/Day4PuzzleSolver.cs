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
}
