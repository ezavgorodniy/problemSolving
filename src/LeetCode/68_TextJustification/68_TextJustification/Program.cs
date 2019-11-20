using System;
using System.Collections.Generic;

namespace _68_TextJustification
{
    public class Solution
    {

        private string GetLine(string[] words, int totalWordsSize, int startIndex, int endIndex, int maxWidth)
        {
            var result = new char[maxWidth];

            var curIndex = 0;
            var spacesPlacesAmount = GetMinimalSpacesAmount(startIndex, endIndex);
            var totalSpacesAmount = maxWidth - totalWordsSize;

            var minSpacePlaceSize = totalSpacesAmount / spacesPlacesAmount;
            var bigSpacesLeft = totalSpacesAmount % spacesPlacesAmount;

            for (int i = startIndex; i <= endIndex; i++)
            {
                for (int j = 0; j < words[i].Length; j++, curIndex++)
                {
                    result[curIndex] = words[i][j];
                }

                for (int j = 0; j < minSpacePlaceSize; j++, curIndex++)
                {
                    result[curIndex] = ' ';
                }

                if (bigSpacesLeft > 0)
                {
                    result[curIndex] = ' ';
                    curIndex++;
                    bigSpacesLeft--;
                }
                }
            return new string(result);
        }

        private string GetLastLine(string[] words, int startIndex, int endIndex, int maxWidth)
        {
            var result = new char[maxWidth];

            int curIndex = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                for (int j = 0; j < words[i].Length; j++, curIndex++)
                {
                    result[curIndex] = words[i][j];
                }
            }

            while (curIndex < maxWidth)
            {
                result[curIndex] = ' ';
                curIndex++;
            }

            return new string(result);
        }

        private int GetMinimalSpacesAmount(int startIndex, int endIndex)
        {
            return endIndex - startIndex;
        }

        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var result = new List<string>();
            var currentStartIndex = 0;
            while (currentStartIndex < words.Length)
            {
                var totalWordsSize = words[currentStartIndex].Length;
                var currentEndIndex = currentStartIndex + 1;
                while (currentEndIndex < words.Length)
                {
                    var potentialAmountOfSpaces = GetMinimalSpacesAmount(currentStartIndex, currentEndIndex);
                    var potentialLineSize = potentialAmountOfSpaces + totalWordsSize + words[currentEndIndex].Length;

                    if (potentialLineSize <= maxWidth)
                    {
                        totalWordsSize += words[currentEndIndex].Length;
                        currentEndIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentEndIndex < words.Length)
                {
                    result.Add(GetLine(words, totalWordsSize, currentStartIndex, currentEndIndex - 1, maxWidth));
                }
                else
                {
                    result.Add(GetLastLine(words, currentStartIndex, currentEndIndex - 1, maxWidth));
                }

                currentStartIndex = currentEndIndex;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.FullJustify(new[] {"This", "is", "an", "example", "of", "text", "justification."}, 16);
        }
    }
}
