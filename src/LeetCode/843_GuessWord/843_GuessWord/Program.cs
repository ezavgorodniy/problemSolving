using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _843_GuessWord
{
    public abstract class Master
    {
        public abstract int Guess(string word);
    }

    public class MockMaster : Master
    {
        private const string Secret = "hbaczn";

        private int GetDistance(string a, string b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException();
            }

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    result++;
                }
            }
            return result;
        }

        public override int Guess(string word)
        {
            return GetDistance(word, Secret);
        }
    }

    class Solution
    {
        public void FindSecretWord(string[] wordlist, Master master)
        {
            var options = new HashSet<int>();
            for (int i = 0; i < wordlist.Length; i++)
            {
                options.Add(i);
            }

            while (options.Count > 0)
            {
                int min = int.MaxValue;
                int minIdx = -1;
                foreach (var i in options)
                {
                    int max = MaxLoss(i, wordlist, options);
                    if (max < min)
                    {
                        min = max;
                        minIdx = i;
                    }
                }

                int match = master.Guess(wordlist[minIdx]);
                if (match == 6)
                {
                    return;
                }

                var next = new HashSet<int>();
                foreach (var i in options)
                {
                    if (Similarity(wordlist[minIdx], wordlist[i]) == match)
                    {
                        next.Add(i);
                    }
                }

                options = next;
            }
        }

        private int MaxLoss(int wordIdx, string[] words, HashSet<int> options)
        {
            int[] bucket = new int[words[0].Length];
            int maxLoss = 0;
            foreach (var i in options)
            {
                if (!words[wordIdx].Equals(words[i]))
                {
                    int sim = Similarity(words[wordIdx], words[i]);
                    bucket[sim]++;
                    maxLoss = Math.Max(maxLoss, bucket[sim]);
                }
            }
            return maxLoss;
        }

        private int Similarity(string s1, string s2)
        {
            int match = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                match += s1[i] == s2[i] ? 1 : 0;
            }
            return match;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();


            /*"hbaczn"
["gaxckt","trlccr","jxwhkz","ycbfps","peayuf","yiejjw","ldzccp","nqsjoa","qrjasy","pcldos","acrtag","buyeia","ubmtpj","drtclz","zqderp","snywek","caoztp","ibpghw","evtkhl","bhpfla","ymqhxk","qkvipb","tvmued","rvbass","axeasm","qolsjg","roswcb","vdjgxx","bugbyv","zipjpc","tamszl","osdifo","dvxlxm","iwmyfb","wmnwhe","hslnop","nkrfwn","puvgve","rqsqpq","jwoswl","tittgf","evqsqe","aishiv","pmwovj","sorbte","hbaczn","coifed","hrctvp","vkytbw","dizcxz","arabol","uywurk","ppywdo","resfls","tmoliy","etriev","oanvlx","wcsnzy","loufkw","onnwcy","novblw","mtxgwe","rgrdbt","ckolob","kxnflb","phonmg","egcdab","cykndr","lkzobv","ifwmwp","jqmbib","mypnvf","lnrgnj","clijwa","kiioqr","syzebr","rqsmhg","sczjmz","hsdjfp","mjcgvm","ajotcx","olgnfv","mjyjxj","wzgbmg","lpcnbj","yjjlwn","blrogv","bdplzs","oxblph","twejel","rupapy","euwrrz","apiqzu","ydcroj","ldvzgq","zailgu","xgqpsr","wxdyho","alrplq","brklfk"]
10*/

            sln.FindSecretWord(
                new[]
                {
                    "gaxckt", "trlccr", "jxwhkz", "ycbfps", "peayuf", "yiejjw", "ldzccp", "nqsjoa", "qrjasy", "pcldos",
                    "acrtag", "buyeia", "ubmtpj", "drtclz", "zqderp", "snywek", "caoztp", "ibpghw", "evtkhl", "bhpfla",
                    "ymqhxk", "qkvipb", "tvmued", "rvbass", "axeasm", "qolsjg", "roswcb", "vdjgxx", "bugbyv", "zipjpc",
                    "tamszl", "osdifo", "dvxlxm", "iwmyfb", "wmnwhe", "hslnop", "nkrfwn", "puvgve", "rqsqpq", "jwoswl",
                    "tittgf", "evqsqe", "aishiv", "pmwovj", "sorbte", "hbaczn", "coifed", "hrctvp", "vkytbw", "dizcxz",
                    "arabol", "uywurk", "ppywdo", "resfls", "tmoliy", "etriev", "oanvlx", "wcsnzy", "loufkw", "onnwcy",
                    "novblw", "mtxgwe", "rgrdbt", "ckolob", "kxnflb", "phonmg", "egcdab", "cykndr", "lkzobv", "ifwmwp",
                    "jqmbib", "mypnvf", "lnrgnj", "clijwa", "kiioqr", "syzebr", "rqsmhg", "sczjmz", "hsdjfp", "mjcgvm",
                    "ajotcx", "olgnfv", "mjyjxj", "wzgbmg", "lpcnbj", "yjjlwn", "blrogv", "bdplzs", "oxblph", "twejel",
                    "rupapy", "euwrrz", "apiqzu", "ydcroj", "ldvzgq", "zailgu", "xgqpsr", "wxdyho", "alrplq", "brklfk"
                }, new MockMaster());
        }
    }
}
