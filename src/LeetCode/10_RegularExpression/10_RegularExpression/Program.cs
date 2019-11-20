using System;

namespace _10_RegularExpression
{

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            var dp = new bool[s.Length + 1][];
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i] = new bool[p.Length + 1];
            }

            dp[s.Length][p.Length] = true;

            for (int i = s.Length; i >= 0; i--)
            {
                for (int j = p.Length - 1; j >= 0; j--)
                {
                    var firstMatch = (i < s.Length &&
                                      (p[j] == s[i] || p[j] == '.'));
                    if (j + 1 < p.Length && p[j + 1] == '*')
                    {
                        dp[i][j] = dp[i][j + 2] || firstMatch && dp[i + 1][j];
                    }
                    else
                    {
                        dp[i][j] = firstMatch && dp[i + 1][j + 1];
                    }
                }
            }

            return dp[0][0];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.IsMatch("mississippi", "mis*is*p*."));
        }
    }
}
