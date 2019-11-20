using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _833_FindAndReplaceInString
{
    public class Solution
    {
        private class ReplacementResult
        {
            public char OriginalSymbol { get; set; }

            public bool IsReplacedByString { get; set; }

            public string Replacement { get; set; }
        }

        private ReplacementResult[] StringToReplacementResults(string s)
        {
            return s.Select(c => new ReplacementResult
            {
                OriginalSymbol = c,
                IsReplacedByString = false,
                Replacement = null
            }).ToArray();
        }

        private string ReplacementResultToString(ReplacementResult[] result)
        {
            var sb = new StringBuilder();
            foreach (var replacement in result)
            {
                if (replacement.IsReplacedByString)
                {
                    if (!string.IsNullOrEmpty(replacement.Replacement))
                    {
                        sb.Append(replacement.Replacement);
                    }
                }
                else
                {
                    sb.Append(replacement.OriginalSymbol);
                }
            }
            return sb.ToString();
        }

        private void Replace(ReplacementResult[] result, int index, string source, string target)
        {
            if (index + source.Length >= result.Length)
            {
                return;
            }

            bool findResult = true;
            for (int i = 0; i < source.Length; i++)
            {
                if (result[index + i].OriginalSymbol != source[i])
                {
                    findResult = false;
                }
            }

            if (!findResult)
            {
                return;
            }

            result[index].Replacement = target;
            for (int i = 0; i < source.Length; i++)
            {
                result[index + i].IsReplacedByString = true;
            }
        }



        public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
        {
            var result = StringToReplacementResults(S);
            for (int i = 0; i < indexes.Length; i++)
            {
                Replace(result, indexes[i], sources[i], targets[i]);
            }
            return ReplacementResultToString(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(
                sln.FindReplaceString("abcd", new[] {0, 2}, new[] {"a", "cd"}, new[] {"eee", "ffff"}));
        }
    }
}
