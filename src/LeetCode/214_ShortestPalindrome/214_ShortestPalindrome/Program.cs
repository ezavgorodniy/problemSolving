using System;

namespace _214_ShortestPalindrome
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
                int mirror = 2 * center - i;

                if (right > i)
                {
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

        public string ShortestPalindrome(string s)
        {
            var tmp = Preprocess(s);
            var lps = CalculateLps(tmp);

            int lengthStartPalindrom = 0; // length of longest palindromic substring
            for (int i = 1; i < lps.Length - 1; i++)
            {
                if (lps[i] > lengthStartPalindrom && (i - 1 - lps[i]) / 2 == 0)
                {
                    lengthStartPalindrom = lps[i];
                }
            }

            var result = new char[s.Length + s.Length - lengthStartPalindrom];

            var lengthAddedPart = s.Length - lengthStartPalindrom;
            for (int i = 0; i < lengthAddedPart; i++)
            {
                result[i] = s[s.Length - 1 - i];
            }
            for (int i = 0; i < lengthStartPalindrom; i++)
            {
                result[lengthAddedPart + i] = s[i];
            }
            for (int i = 0; i < lengthAddedPart; i++)
            {
                result[lengthAddedPart + lengthStartPalindrom + i] = s[lengthStartPalindrom + i];
            }
            return new string(result);


            /*var addedPart = s.Substring(lengthStartPalindrom, s.Length - lengthStartPalindrom);
            var startPalindrome = s.Substring(0, lengthStartPalindrom);
            return new string(addedPart.Reverse().ToArray()) + startPalindrome + addedPart;*/
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.ShortestPalindrome("abaxabaxabb"));
        }
    }
}



