using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventCode.Day2
{
    public class Day2PuzzleSolver : PuzzleSolver
    {
        public Day2PuzzleSolver(string inputFileName) : base(inputFileName)
        {
        }

        public override void SolvePuzzle()
        {
            IEnumerable<string> boxIds = GetBoxIds();
            //var (box1, box2) = FindSimilarBoxes(boxIds);
            //var commonLetters = GetCommonLetters(box1, box2);
            var (twoLetterBoxCount, threeLetterBoxCount) = CountSimilarBoxIds(boxIds);
            //var checkSum = GetCheckSum(twoLetterBoxCount, threeLetterBoxCount);
            //Console.WriteLine("The result is: " + commonLetters);
        }

        private IEnumerable<string> GetBoxIds()
        {
            return File.ReadAllLines(_puzzleInput);
        }

        private (string box1, string box2) FindSimilarBoxes(IEnumerable<string> boxIds)
        {
            var boxIdArray = boxIds.ToArray();
            var numberOfIds = boxIdArray.Count();
            for (int i = 0; i < numberOfIds; i++)
            {
                var boxId = boxIdArray[i];
                for(int j = i+1; j < numberOfIds; j++)
                {
                    if(CheckIfBoxIdsMatch(boxId, boxIdArray[j]))
                    {
                        return (boxId, boxIdArray[j]);
                    }
                }
            }

            return (string.Empty, string.Empty);
        }

        private string GetCommonLetters(string id1, string id2)
        {
            var stringBuilder = new StringBuilder();
            for(int i = 0; i < id1.Length; i++)
            {
                if(id1[i] == id2[i])
                {
                    stringBuilder.Append(id1[i]);
                }
            }
            return stringBuilder.ToString();
        }

        private bool CheckIfBoxIdsMatch(string boxId1, string boxId2)
        {
            int numberOfNonMatchingCharacters = 0;
            //Assumes strings are always of same length
            for(var i = 0; i < boxId1.Length; i++)
            {
                if(boxId1[i] != boxId2[i])
                {
                    numberOfNonMatchingCharacters++;
                    if(numberOfNonMatchingCharacters > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private (int twoLetterBoxCount, int threeLetterBoxCount) CountSimilarBoxIds(IEnumerable<string> boxIds)
        {
            int twoLetterBoxCount = 0;
            int threeLetterBoxCount = 0;
            foreach(var id in boxIds)
            {
                var groupedId = id.GroupBy(c => c);
                if(groupedId.Any(c => c.Count() == 2))
                {
                    twoLetterBoxCount++;
                }
                if(groupedId.Any(c => c.Count() == 3))
                {
                    threeLetterBoxCount++;
                }
            }

            return (twoLetterBoxCount, threeLetterBoxCount);
        }

        private int GetCheckSum(int twoLetterBoxCount, int threeLetterBoxCount)
        {
            return twoLetterBoxCount * threeLetterBoxCount;
        }
    }
}
