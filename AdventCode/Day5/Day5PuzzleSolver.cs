using System;
using System.IO;

namespace AdventCode.Day5
{
    public class Day5PuzzleSolver : PuzzleSolver
    {
        private string Polymer; 
        public Day5PuzzleSolver(string inputFileName) : base(inputFileName)
        {
            Polymer = File.ReadAllText(_puzzleInput).Trim();
        }

        public override void SolvePuzzle()
        {
            ReactPolymer();
            Console.WriteLine($"After reaction there are {Polymer.Length} units left");
        }

        private void ReactPolymer()
        {
            bool reactionHasOccured = false;
            do
            {
                reactionHasOccured = false;
                for (int i = 0; i < Polymer.Length -1; i++)
                {
                    if (CombinationIsReactive(Polymer[i], Polymer[i + 1]))
                    {
                        Polymer = Polymer.Remove(i, 2);
                        reactionHasOccured = true;
                        break;
                    }
                }
            } while (reactionHasOccured);

        }

        private bool CombinationIsReactive(char c1, char c2)
        {
            return c1 == c2.InvertCase();
        }
    }
}
