using System;

namespace AdventCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merry Xmas!");
            while (true)
            {
                Console.WriteLine("Enter the day of the puzzle you want to solve: ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out var result) || result < 1 || result > 24)
                {
                    Console.WriteLine("Not a valid day!");
                    continue;
                }
                else
                {
                    var puzzleSolver = PuzzleSolverFactory.Create(result);
                    if(puzzleSolver == null)
                    {
                        Console.WriteLine("No puzzle solver available for this day yet");
                        continue;
                    }

                    puzzleSolver.SolvePuzzle();

                    Console.WriteLine("Press any key to exit");
                    Console.ReadLine();
                    break;
                }

            }
        }
    }
}
