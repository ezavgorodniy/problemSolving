using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateParenthesis
{
    public class Solution
    {

        private List<string> GetResult(int parenthesisLeft, int parenthesisCounter, Dictionary<int, Dictionary<int, List<string>>> savedResults)
        {
            if (!savedResults.ContainsKey(parenthesisLeft))
            {
                return null;
            }

            var subResult = savedResults[parenthesisLeft];
            if (!subResult.ContainsKey(parenthesisCounter))
            {
                return null;
            }

            return subResult[parenthesisCounter];
        }

        private void AddResult(int parenthesisLeft, int parenthesisCounter, Dictionary<int, Dictionary<int, List<string>>> savedResults, List<string> newResult)
        {
            Dictionary<int, List<string>> subResult;
            if (!savedResults.ContainsKey(parenthesisLeft))
            {
                subResult = new Dictionary<int, List<string>>();
                savedResults.Add(parenthesisLeft, subResult);
            }
            else
            {
                subResult = savedResults[parenthesisLeft];
            }

            if (!subResult.ContainsKey(parenthesisCounter))
            {
                subResult.Add(parenthesisCounter, newResult);
            }
            else
            {
                subResult[parenthesisCounter] = newResult;
            }
        }

        public IList<string> GenerateParenthesis(int parenthesisLeft, int currentParenthesisCounter, string currentString, Dictionary<int, Dictionary<int, List<string>>> savedResults)
        {
            List<string> result;
            var existedResults = GetResult(parenthesisLeft, currentParenthesisCounter, savedResults);
            if (existedResults != null)
            {
                result = existedResults.Select(existedResult => currentString + existedResult).ToList();
            }
            else
            {
                if (currentParenthesisCounter < 0)
                {
                    result = new List<string>(new string[0]);
                }
                else if (parenthesisLeft == 0)
                {
                    result = currentParenthesisCounter == 0 ? new List<string>(new[] {""}) : new List<string>(new string[0]);
                }
                else
                {
                    result = new List<string>();
                    if (currentParenthesisCounter > 0)
                    {
                        var openSuffixes = GenerateParenthesis(parenthesisLeft - 1, currentParenthesisCounter - 1,
                            currentString + ")", savedResults);
                        result.AddRange(openSuffixes.Select(suffix => currentString + ")" + suffix));
                    }

                    var closeSuffixes = GenerateParenthesis(parenthesisLeft - 1, currentParenthesisCounter + 1,
                        currentString + "(", savedResults);
                    result.AddRange(closeSuffixes.Select(suffix => currentString + "(" + suffix));
                }
            }

            AddResult(parenthesisLeft, currentParenthesisCounter, savedResults, result);
            return result;
        }

        public IList<string> GenerateParenthesis(int n)
        {
            return GenerateParenthesis(n * 2, 0, string.Empty, new Dictionary<int, Dictionary<int, List<string>>>());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var result = solution.GenerateParenthesis(2);
            Console.WriteLine("[");
            foreach (var subResult in result)
            {
                Console.Write("\t[");
                foreach (var item in subResult)
                {
                    Console.Write(item);

                }
                Console.WriteLine("]");
            }
            Console.WriteLine("]");
        }
    }
}
