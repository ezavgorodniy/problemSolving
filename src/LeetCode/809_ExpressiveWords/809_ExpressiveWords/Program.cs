using System;
using System.Collections.Generic;

namespace _809_ExpressiveWords
{
    public class Solution
    {

        private class GroupDescription
        {
            public char Symbol { get; set; }

            public int Count { get; set; }
        }

        private List<GroupDescription> GetGroupDescription(string s)
        {
            var result = new List<GroupDescription>();

            char currentC = s[0];
            int count = 1;
            int index = 1;
            while (index < s.Length)
            {
                if (s[index] != currentC)
                {
                    result.Add(new GroupDescription
                    {
                        Symbol = currentC,
                        Count = count
                    });

                    currentC = s[index];
                    count = 1;
                }
                else
                {
                    count++;
                }
                index++;
            }

            result.Add(new GroupDescription
            {
                Symbol = currentC,
                Count = count
            });
            return result;
        }

        private bool FirstExpressedFromSecond(List<GroupDescription> s1, List<GroupDescription> s2)
        {
            if (s1.Count != s2.Count)
            {
                return false;
            }
            for (int i = 0; i < s1.Count; i++)
            {
                if (s1[i].Symbol != s2[i].Symbol)
                {
                    return false;
                }
                if (s1[i].Count == s2[i].Count)
                {
                    continue;
                }
                if (s1[i].Count < 3 || s2[i].Count > s1[i].Count)
                {
                    return false;
                }
            }

            return true;

        }

        public int ExpressiveWords(string S, string[] words)
        {
            var sGroupDescription = GetGroupDescription(S);
            var result = 0;
            foreach (var word in words)
            {
                var wordDescription = GetGroupDescription(word);
                if (FirstExpressedFromSecond(sGroupDescription, wordDescription))
                {
                    result++;
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*"dddiiiinnssssssoooo"
["dinnssoo","ddinso","ddiinnso","ddiinnssoo","ddiinso","dinsoo","ddiinsso","dinssoo","dinso"]*/
            var sln = new Solution();
            Console.WriteLine(sln.ExpressiveWords("aaa",
                new[] { "aaaa" }));
            /*var sln = new Solution();
            Console.WriteLine(sln.ExpressiveWords("heeellooo",
                new []{ "hello", "hi", "helo" }));*/
        }
    }
}
