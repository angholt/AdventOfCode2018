using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode
{
    public class Day3PuzzleSolver : PuzzleSolver
    {
        private readonly int[,] _fabric;
        public Day3PuzzleSolver(string inputFileName) : base(inputFileName)
        {
            _fabric = new int[1000, 1000];
        }

        public override void SolvePuzzle()
        {
            var claims = ParseInputFile();
            HandleClaims(claims);
            Console.WriteLine("There are " + CountOverlappingClaims() + " overlapping claims");
            Console.WriteLine("Claim with id: " + FindIntactClaimId(claims) + " is the only intact claim");
        }

        private IEnumerable<Claim> ParseInputFile()
        {
            var fileLines = File.ReadAllLines(_puzzleInput);

            var claims = new List<Claim>();

            foreach (var line in fileLines)
            {
                var c = new Claim(line);
                claims.Add(c);
            }

            return claims;

            //return fileLines.Select(fl => new Claim(fl));
        }

        private void HandleClaims(IEnumerable<Claim> claims)
        {
            foreach(var claim in claims)
            {
                for(int x = claim.XStartPos; x < claim.XStartPos + claim.XLength; x++)
                {
                    for(int y = claim.YStartPos; y < claim.YStartPos + claim.YLength; y++)
                    {
                        _fabric[x, y] = _fabric[x, y] + 1;
                    }
                }
            }
        }

        private int CountOverlappingClaims()
        {
            int counter = 0;
            for(int x = 0; x < _fabric.GetLength(0); x++)
            {
                for(int y = 0; y < _fabric.GetLength(1); y++)
                {
                    if(_fabric[x, y] > 1)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private int FindIntactClaimId(IEnumerable<Claim> claims)
        {
            var intactClaims = claims.Where(c => IsIntactClaim(c)).Select(c => c.Id);
            return intactClaims.First(); ;

        }

        private bool IsIntactClaim(Claim claim)
        {
            for (int x = claim.XStartPos; x < claim.XStartPos + claim.XLength; x++)
            {
                for (int y = claim.YStartPos; y < claim.YStartPos + claim.YLength; y++)
                {
                    if(_fabric[x, y] > 1)
                    {
                        return false;
                    }
                }
            }

            return true; ;
        }
    }

    public class Claim
    {
        public int Id { get; set; }
        public int XStartPos { get; set; }
        public int YStartPos { get; set; }
        public int XLength { get; set; }
        public int YLength { get; set; }

        public Claim(string inputLine)
        {
            Id = int.Parse(StringHelper.GetSubstring(inputLine, "#", "@"));
            XStartPos = int.Parse(StringHelper.GetSubstring(inputLine, "@", ","));
            YStartPos = int.Parse(StringHelper.GetSubstring(inputLine, ",", ":"));
            XLength = int.Parse(StringHelper.GetSubstring(inputLine, ":", "x"));
            YLength = int.Parse(inputLine.Substring(inputLine.IndexOf("x") + 1));
        }
    }
}
