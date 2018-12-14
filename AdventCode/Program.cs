using AdventCode.Day5;
using System;

namespace AdventCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            var puzzleSolver = new Day5PuzzleSolver("Day5\\input.txt");

            puzzleSolver.SolvePuzzle();
            
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
