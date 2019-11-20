using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthOfLongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
        }
        private static int GetCharNumber(char c)
        {
            return c - 'a';
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var curStart = 0;
            var lettersAmount = GetCharNumber('z') - GetCharNumber('a') + 1;
            var lastAppearance = new int[lettersAmount];
            for (int i = 0; i < lettersAmount; i++)
            {
                lastAppearance[i] = -1;
            }

            var curResult = 1;
            lastAppearance[GetCharNumber(s[0])] = 0;

            for (int i = 1; i < s.Length; i++)
            {
                var letterIndex = GetCharNumber(s[i]);

                if (lastAppearance[letterIndex] != -1 && lastAppearance[letterIndex] >= curStart)
                {
                    var newResult = i - curStart;
                    if (newResult > curResult)
                    {
                        curResult = newResult;
                    }

                    curStart = lastAppearance[letterIndex] + 1;
                }
                lastAppearance[letterIndex] = i;
            }
            return curStart;

        }
    }
}
