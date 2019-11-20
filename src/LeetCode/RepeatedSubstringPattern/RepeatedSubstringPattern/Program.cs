using System;

public class Solution
{

    public bool RepeatedSubstringPattern(string s)
    {
        int n = s.Length;
        for (int wordsAmount = 2; n/ wordsAmount >= 1; wordsAmount++)
        {
            if (n % wordsAmount != 0)
            {
                continue;
            }

            var wordSize = n / wordsAmount;

            bool isPattern = true;
            for (int i = 0; i < wordSize && isPattern; i++)
            {
                var c = s[i];
                int j = i + wordSize;
                while (j < n && isPattern)
                {
                    isPattern = s[j] == c;
                    j += wordSize;
                }
            }

            if (isPattern)
            {
                return true;
            }
        }

        return false;
    }
}

namespace RepeatedSubstringPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.RepeatedSubstringPattern("babbbbaabb"));

        }
    }
}
