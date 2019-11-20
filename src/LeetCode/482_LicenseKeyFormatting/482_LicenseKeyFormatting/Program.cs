using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _482_LicenseKeyFormatting
{
    public class Solution
    {
        private bool IsUpperCase(char c)
        {
            return 'A' <= c && c <= 'Z';
        }

        private bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        private char ToUpperCase(char c)
        {
            if (IsUpperCase(c) || IsDigit(c))
            {
                return c;
            }
            return (char)(c + 'A' - 'a');
        }

        private int GetCharactersCount(string s)
        {
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '-')
                {
                    cnt++;
                }
            }
            return cnt;
        }



        public string LicenseKeyFormatting(string S, int K)
        {
            var charCount = GetCharactersCount(S);
            if (charCount == 0)
            {
                return "";
            }

            var groupsAmount = charCount / K + (charCount % K == 0 ? 0 : 1);

            var result = new char[groupsAmount - 1 + charCount];
            int curSIndex = 0;
            int curResultIndex = 0;
            if (charCount % K != 0)
            {
                var firstGroupSize = charCount % K;
                while (curResultIndex < firstGroupSize)
                {
                    if (S[curSIndex] == '-')
                    {
                        curSIndex++;
                    }
                    else
                    {
                        result[curResultIndex] = S[curSIndex];
                        curSIndex++;
                        curResultIndex++;
                    }
                }
            }

            while (curResultIndex < result.Length)
            {
                int curGroupIndex = 0;
                while (curGroupIndex < K)
                {
                    if (S[curSIndex] != '-')
                    {
                        result[curResultIndex] = ToUpperCase(S[curSIndex]);
                        curResultIndex++;
                        curGroupIndex++;
                    }
                    curSIndex++;
                }
                if (curResultIndex < result.Length)
                {
                    result[curResultIndex] = '-';
                    curResultIndex++;
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
            Console.WriteLine(sln.LicenseKeyFormatting("2-5g-3-J",2));
        }
    }
}
