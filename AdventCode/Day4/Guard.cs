using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode.Day4
{
    public class Guard
    {
        public List<SleepPeriod> SleepPeriods { get; set; }
        public int TotalSleep => SleepPeriods.Sum(sp => sp.Duration);
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
}
