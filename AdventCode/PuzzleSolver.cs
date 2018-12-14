using System.IO;

namespace AdventCode
{
    public abstract class PuzzleSolver
    {
        protected readonly string _puzzleInput;
        protected readonly string[] _fileLines;

        public PuzzleSolver(string inputFileName)
        {
            _puzzleInput = inputFileName;
            _fileLines = File.ReadAllLines(_puzzleInput);
        }

        public abstract void SolvePuzzle();
    }
}
