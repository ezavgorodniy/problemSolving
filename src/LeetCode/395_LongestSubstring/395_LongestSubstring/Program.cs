using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _395_LongestSubstring
{
    public class Solution
    {
        public int LongestSubstring(string s, int k)
        {
            return LongestSubstring(s, 0, s.Length, k);
        }

        private int LongestSubstring(string s, int start, int end, int k)
        {
            if (end - start < k)
            {
                //substring length shorter than k.
                return 0;
            }

            var count = new int[26];
            var firstOccurence = new int[26];

            for (int i = end - 1; i >= start; i--)
            {
                count[s[i] - 'a']++;
                firstOccurence[s[i] - 'a'] = i;
            }

            for (int i = 0; i < 26; i++)
            {
                if (count[i] < k && count[i] > 0)
                {
                    //count[i]=0 => i+'a' does not exist in the string, skip it.
                    for (int j = start; j < end; j++)
                    {
                        if (s[j] == i + 'a')
                        {
                            int left = LongestSubstring(s, start, j, k);
                            int right = LongestSubstring(s, j + 1, end, k);
                            return Math.Max(left, right);
                        }
                    }
                }
            }
            return end - start;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.LongestSubstring("aaabb", 3));
        }
    }
}
