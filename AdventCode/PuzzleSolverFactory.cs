using System;

namespace AdventCode
{
    public static class PuzzleSolverFactory
    {
        public static PuzzleSolver Create(int day)
        {
            var filePath = $"Day{day}\\input.txt";
            var puzzleSolverTypeName = $"AdventCode.Day{day}.Day{day}PuzzleSolver";
            var puzzleSolverType = Type.GetType(puzzleSolverTypeName);

            return Activator.CreateInstance(puzzleSolverType, filePath) as PuzzleSolver;
        }
    }
}