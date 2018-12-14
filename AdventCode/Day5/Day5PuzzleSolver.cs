using AdventCode.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode.Day5
{
    public class Day5PuzzleSolver : PuzzleSolver
    {
        private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public Day5PuzzleSolver(string inputFileName) : base(inputFileName)
        {
            
        }

        public override void SolvePuzzle()
        {
            var originalPolymer = GetPolymer();
            var reactedPolymer = ReactPolymer(originalPolymer);
            Console.WriteLine($"After reaction there are {reactedPolymer.Length} units left");
            var shortestPolymer = ProduceShortestPolymer(originalPolymer);
            Console.WriteLine($"The shortest possible polymer is of length: {shortestPolymer}");
        }

        private string GetPolymer()
        {
            return File.ReadAllText(_puzzleInput).Trim();
        }

        private string ReactPolymer(string originalPolymer)
        {
            var reactedPolymer = originalPolymer;
            int i = 0;
            while(i < reactedPolymer.Length -1)
            {
                if(!CombinationIsReactive(reactedPolymer[i], reactedPolymer[i + 1]))
                {
                    i++;
                    continue;
                }
                else
                {
                    reactedPolymer = reactedPolymer.Remove(i, 2);
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
            return reactedPolymer;
        }

        private int ProduceShortestPolymer(string originalPolymer)
        {
            var experimentResults = new Dictionary<char, int>();

            foreach(var c in alphabet)
            {
                var trimmedPolymer = originalPolymer.ReplaceIgnoreCase(c.ToString(), "");

                var polymerLength = ReactPolymer(trimmedPolymer).Length;
                experimentResults.Add(c, polymerLength);
            }

            return experimentResults.Min(er => er.Value);
        }

        private bool CombinationIsReactive(char c1, char c2)
        {
            return c1 == c2.InvertCase();
        }
    }
}
