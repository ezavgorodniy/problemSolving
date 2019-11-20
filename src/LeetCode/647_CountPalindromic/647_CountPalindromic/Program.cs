using System;

namespace _647_CountPalindromic
{
    public class Solution
    {
        private char[] Preprocess(string s)
        {
            var tmp = new char[s.Length * 2 + 3];
            tmp[0] = '$';
            tmp[s.Length * 2 + 2] = '@';
            for (int i = 0; i < s.Length; i++)
            {
                tmp[2 * i + 1] = '#';
                tmp[2 * i + 2] = s[i];
            }
            tmp[s.Length * 2 + 1] = '#';
            return tmp;
        }

        private int[] CalculateLps(char[] str)
        {
            var lps = new int[str.Length];

            int center = 0, right = 0;
            for (int i = 1; i < str.Length - 1; i++)
            {

                if (right > i)
                {
                    int mirror = 2 * center - i;
                    lps[i] = Math.Min(right - i, lps[mirror]);
                }

                // attempt to expand palindrome centered at i
                while (str[i + 1 + lps[i]] == str[i - (1 + lps[i])])
                {
                    lps[i]++;
                }

                // if palindrome centered at i expands past right,
                // adjust center based on expanded palindrome.
                if (i + lps[i] > right)
                {
                    center = i;
                    right = i + lps[i];
                }
            }

            return lps;
        }

        public int CountSubstrings(string s)
        {
            var tmp = Preprocess(s);
            var lps = CalculateLps(tmp);

            var result = 0;
            for (int i = 1; i < lps.Length - 1; i++)
            {
                result += (lps[i] + 1) / 2;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.CountSubstrings("abc"));
            //Console.WriteLine(solution.ShortestPalindrome("abccbaabba"));
        }
    }
}
