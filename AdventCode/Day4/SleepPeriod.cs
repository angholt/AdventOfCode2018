namespace AdventCode.Day4
{
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
