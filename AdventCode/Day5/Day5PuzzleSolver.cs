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
            int i = 0;
            while(i < Polymer.Length -1)
            {
                if(!CombinationIsReactive(Polymer[i], Polymer[i + 1]))
                {
                    i++;
                    continue;
                }
                else
                {
                    Polymer = Polymer.Remove(i, 2);
                    if (i > 0)
                    {
                        i--;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }
        }

        private bool CombinationIsReactive(char c1, char c2)
        {
            return c1 == c2.InvertCase();
        }
    }
}
