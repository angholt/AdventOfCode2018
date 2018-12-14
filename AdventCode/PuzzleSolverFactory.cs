using AdventCode.Day1;
using AdventCode.Day2;
using AdventCode.Day3;
using AdventCode.Day4;
using AdventCode.Day5;

namespace AdventCode
{
    public static class PuzzleSolverFactory
    {
        public static PuzzleSolver Create(int day)
        {
            var filePath = $"Day{day}\\input.txt";
            switch (day)
            {
                case 1:
                    return new Day1PuzzleSolver(filePath);
                case 2:
                    return new Day2PuzzleSolver(filePath);
                case 3:
                    return new Day3PuzzleSolver(filePath);
                case 4:
                    return new Day4PuzzleSolver(filePath);
                case 5:
                    return new Day5PuzzleSolver(filePath);
                default:
                    return null;
            }
        }
    }
}