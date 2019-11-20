using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _76_MinimumWindowSubstring
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            int[] tOccurences = new int[256];
            for (int i = 0; i < t.Length; i++)
            {
                tOccurences[t[i]]++;
            }

            int[] curSOccurences = new int[256];
            int r = 0;
            int matchSymbols = 0;
            while (r < s.Length)
            {
                curSOccurences[s[r]]++;
                if (tOccurences[s[r]] != 0 && curSOccurences[s[r]] <= tOccurences[s[r]])
                {
                    matchSymbols++;
                    if (matchSymbols == t.Length)
                    {
                        break;
                    }
                }
                r++;
            }
            if (matchSymbols != t.Length)
            {
                return "";
            }

            int l = 0;
            while (tOccurences[s[l]] == 0 || curSOccurences[s[l]] > tOccurences[s[l]])
            {
                curSOccurences[s[l]]--;
                l++;
            }


            int resultL = l;
            int resultR = r;

            while (l < s.Length && r < s.Length)
            {
                while (l <= r)
                {
                    var removedChar = s[l];
                    curSOccurences[removedChar]--;
                    l++;

                    if (tOccurences[removedChar] != 0 && curSOccurences[removedChar] <= tOccurences[removedChar])
                    {
                        break;
                    }
                }

                r++;
                while (r < s.Length)
                {
                    var addedChar = s[r];
                    curSOccurences[addedChar]++;
                    if (tOccurences[addedChar] != 0 && curSOccurences[addedChar] == tOccurences[addedChar])
                    {
                        break;
                    }
                    r++;
                }

                if (r >= s.Length)
                {
                    break;
                }

                while (tOccurences[s[l]] == 0 || curSOccurences[s[l]] > tOccurences[s[l]])
                {
                    curSOccurences[s[l]]--;
                    l++;
                }

                if (r - l + 1 < resultR - resultL + 1)
                {
                    resultR = r;
                    resultL = l;
                }
            }

            return s.Substring(resultL, resultR - resultL + 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.MinWindow("ADOBECODEBANC", "ABC"));
        }
    }
}
