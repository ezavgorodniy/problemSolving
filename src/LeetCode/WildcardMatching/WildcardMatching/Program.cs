using System;

namespace WildcardMatching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (p == "*")
            {
                return true;
            }

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
            }

            return lookup[prevLine][p.Length];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
