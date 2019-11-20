using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _767_ReorganizeString
{
    public class Solution
    {
        private char FindMaximalOccuredChar(int[] occurences)
        {
            char maxChar = 'a';
            for (char c = 'b'; c <= 'z'; c++)
            {
                if (occurences[c - 'a'] > occurences[maxChar - 'a'])
                {
                    maxChar = c;
                }
            }

            return maxChar;
        }

        private int[] GetOccurences(string s)
        {
            var occurences = new int[26];
            foreach (var c in s)
            {
                occurences[c - 'a']++;
            }

            return occurences;
        }

        private int FindAvailablePlace(char[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public string ReorganizeString(string S)
        {
            var occurences = GetOccurences(S);
            var result = new char[S.Length];
            var processedLettersCount = 0;
            while (processedLettersCount < result.Length)
            {
                var maxChar = FindMaximalOccuredChar(occurences);
                for (int i = FindAvailablePlace(result); i < result.Length && occurences[maxChar - 'a'] >= 0; i += 2)
                {
                    result[i] = maxChar;
                    occurences[maxChar - 'a']--;
                    processedLettersCount++;
                }

                if (occurences[maxChar - 'a'] != 0)
                {
                    return "";
                }
            }

            return new string(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.ReorganizeString("vvvlo"));
        }
    }
}
