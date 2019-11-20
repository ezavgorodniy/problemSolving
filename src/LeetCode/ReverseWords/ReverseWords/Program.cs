using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWords
{
    public class Solution
    {
        public string ReverseWords(string s)
        {
            var words = new List<Tuple<int, int>>();
            var sumSize = 0;
            int i = 0;
            while (i < s.Length)
            {
                while (i < s.Length && s[i] == ' ')
                {
                    i++;
                }
                int startWord = i;
                while (i < s.Length && s[i] != ' ')
                {
                    i++;
                }
                if (startWord < i)
                {
                    words.Add(new Tuple<int, int>(startWord, i - 1));
                    sumSize += i - startWord;
                }
            }

            var result = new char[sumSize + words.Count() - 1];
            var curIndex = 0;
            for (int wordsI = words.Count() - 1; wordsI >= 0; wordsI--, curIndex++)
            {
                for (int j = words[wordsI].Item1; j <= words[wordsI].Item2; j++, curIndex++)
                {
                    result[curIndex] = s[j];
                }
                if (curIndex < s.Length)
                {
                    result[curIndex] = ' ';
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
            Console.WriteLine(sln.ReverseWords("the sky is blue"));
        }
    }
}
