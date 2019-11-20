using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97_InterleavingString
{

    public class Solution
    {
        /* bool isInterleave(string s1, string s2, string s3) {

        if(s3.length() != s1.length() + s2.length())
            return false;

        bool table[s1.length()+1][s2.length()+1];

        for(int i=0; i<s1.length()+1; i++)
            for(int j=0; j< s2.length()+1; j++){
                if(i==0 && j==0)
                    table[i][j] = true;
                else if(i == 0)
                    table[i][j] = ( table[i][j-1] && s2[j-1] == s3[i+j-1]);
                else if(j == 0)
                    table[i][j] = ( table[i-1][j] && s1[i-1] == s3[i+j-1]);
                else
                    table[i][j] = (table[i-1][j] && s1[i-1] == s3[i+j-1] ) || (table[i][j-1] && s2[j-1] == s3[i+j-1] );
            }

        return table[s1.length()][s2.length()];
    }*/

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }

            var dp = new bool[s1.Length + 1][];
            for (int i = 0; i <= s1.Length; i++)
            {
                dp[i] = new bool[s2.Length];
            }

            dp[0][0] = true;
            for (int j = 1; j <= s2.Length; j++)
            {
                dp[0][j] = dp[0][j - 1] && s2[j - 1] == s3[j - 1];
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                dp[i][0] = dp[i - 1][0] && s1[i - 1] == s3[i - 1];
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    dp[i][j] = (dp[i - 1][j] && s1[i - 1] == s3[i + j - 1]) ||
                               (dp[i][j - 1] && s2[j - 1] == s3[i + j - 1]);
                }
            }

            return dp[s1.Length][s2.Length];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.IsInterleave("aabcc", "dbbca", "aadbbcbcac"));
        }
    }
}
