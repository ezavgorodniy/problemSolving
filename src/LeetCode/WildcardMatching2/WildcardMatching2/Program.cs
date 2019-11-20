using System;

namespace WildcardMatching2
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (p == "*")
            {
                return true;
            }

            //int n = s.Length;
            //int m = p.Length;
            //var lookup = new bool[n + 1][];
            //for (int i = 0; i <= n; i++)
            //{
            //    lookup[i] = new bool[m + 1];
            //}

            //lookup[0][0] = true;
            //for (int j = 1; j <= m; j++)
            //{
            //    if (p[j - 1] == '*')
            //    {
            //        lookup[0][j] = lookup[0][j - 1];
            //    }
            //}

            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= m; j++)
            //    {
            //        if (p[j - 1] == '*')
            //            lookup[i][j] = lookup[i][j - 1] ||
            //                           lookup[i - 1][j];

            //        // Current characters are considered as 
            //        // matching in two cases 
            //        // (a) current character of pattern is '?' 
            //        // (b) characters actually match 
            //        else if (p[j - 1] == '?' ||
            //                 s[i - 1] == p[j - 1])
            //            lookup[i][j] = lookup[i - 1][j - 1];

            //        // If characters don't match 
            //        else lookup[i][j] = false;
            //    }
            //}
            //return lookup[n][m];


            var lookup = new bool[2][];
            lookup[0] = new bool[p.Length + 1];
            lookup[1] = new bool[p.Length + 1];

            lookup[0][0] = true;
            for (int j = 1; j <= p.Length; j++)
            {
                if (p[j - 1] == '*')
                {
                    lookup[0][j] = lookup[0][j - 1];
                }
            }

            var prevLine = 0;
            var curLine = 1;
            for (int i = 1; i <= s.Length; i++)
            {
                lookup[curLine][0] = false;
                for (int j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        lookup[curLine][j] = lookup[curLine][j - 1] || lookup[prevLine][j];
                    }
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        lookup[curLine][j] = lookup[prevLine][j - 1];
                    }
                    else
                    {
                        lookup[curLine][j] = false;
                    }
                }


                prevLine = 1 - prevLine;
                curLine = 1 - curLine;
            }

            return lookup[prevLine][p.Length];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.IsMatch("bbbaab", "a**?***"));
        }
    }
}
