using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _392_IsSubsequence
{
    public class Solution
    {
        private bool IsSubsequence(string t, int curIndex, int lastOccurence, List<int>[] occurences)
        {
            if (curIndex >= t.Length)
            {
                return true;
            }

            var curSymbolOccurences = occurences[t[curIndex] - 'a'];
            if (curSymbolOccurences == null)
            {
                return false;
            }

            foreach (var occurence in curSymbolOccurences)
            {
                if (occurence > lastOccurence && IsSubsequence(t, curIndex + 1, occurence, occurences))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsSubsequence(string s, string t)
        {
            var occurrences = new List<int>[26];
            for (int i = 0; i < s.Length; i++)
            {
                if (occurrences[s[i] - 'a'] == null)
                {
                    occurrences[s[i] - 'a'] = new List<int>();
                }
                
                occurrences[s[i] - 'a'].Add(i);
            }

            return IsSubsequence(t, 0, -1, occurrences);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.IsSubsequence("ahbgdc", "acb"));
        }
    }
}
