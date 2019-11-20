using System;
using System.Collections.Generic;

namespace LongestPalindrom
{
    public class Program
    {
        private static List<int>[] FillOccurences(string s)
        {
            var occurences = new List<int>[255];
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                var charIndex = (int)c;
                if (occurences[charIndex] == null)
                {
                    occurences[charIndex] = new List<int>();
                }

                occurences[charIndex].Add(i);
            }

            return occurences;
        }

        private static bool CheckPalindrome(string s, int startIndex, int endIndex)
        {
            while (startIndex > endIndex)
            {
                if (s[startIndex] != s[endIndex])
                {
                    return false;
                }

                startIndex++;
                endIndex--;
            }

            return true;

        }

        private static string LongestPalindrome(string s, int startIndex, List<int>[] occurences)
        {
            var startChar = s[startIndex];
            var occurencyChar = occurences[(int)startChar];
            for (int i = occurencyChar.Count - 1; i >= 0; i--)
            {
                var endIndex = occurencyChar[i];
                if (endIndex <= startIndex)
                {
                    break;
                }
                if (CheckPalindrome(s, startIndex, endIndex))
                {
                    return s.Substring(startIndex, endIndex - startIndex + 1);
                }

            }

            return s.Substring(startIndex, 1);
        }

        private static string LongestPalindrome(string s, List<int>[] occurences)
        {
            var result = s.Substring(0, 1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Length - i + 1 < result.Length)
                {
                    break;
                }

                var longestPalindrome = LongestPalindrome(s, i, occurences);
                if (longestPalindrome.Length > result.Length)
                {
                    result = longestPalindrome;
                }
            }
            return result;

        }

        public static string LongestPalindrome(string s)
        {
            if (s.Length <= 2)
            {
                return s;
            }
            var occurences = FillOccurences(s);
            return LongestPalindrome(s, occurences);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("abcda"));
        }
    }
}
