using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode.Day1
{
    public class Day1PuzzleSolver : PuzzleSolver
    {
        public Day1PuzzleSolver(string inputFileName) : base(inputFileName)
        {

        }

        public override void SolvePuzzle()
        {
            var frequencyChanges = GetFequencyChangesFromFile();
            var result = FindFirstReoccuringFrequency(frequencyChanges);

            Console.WriteLine("The result is: " + result);
        }

        private IEnumerable<int> GetFequencyChangesFromFile()
        {
            var fileLines = File.ReadAllLines(_puzzleInput);
            return fileLines.Select(line => int.Parse(line));
        }

        private static int FindFirstReoccuringFrequency(IEnumerable<int> frequencyChanges)
        {
            int currentFrequency = 0;
            var seenFreqValues = new HashSet<int>();
            while (true)
            {
                foreach (var freqChange in frequencyChanges)
                {
                    currentFrequency += freqChange;
                    if (seenFreqValues.Contains(currentFrequency))
                    {
                        return currentFrequency;
                    }
                    else
                    {
                        seenFreqValues.Add(currentFrequency);
                    }
                }
            }
        }
    }
}
