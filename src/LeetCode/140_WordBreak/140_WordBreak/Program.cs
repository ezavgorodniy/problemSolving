using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _140_WordBreak
{
    public class Solution
    {
        private class TrieNode
        {
            private readonly Dictionary<char, TrieNode> Characters = new Dictionary<char, TrieNode>();
            public string Word { get; private set; }

            public TrieNode GetNext(char c)
            {
                return Characters.ContainsKey(c) ? Characters[c] : null;
            }

            public TrieNode AddWord(string word)
            {
                var curTrieNode = this;
                foreach (char c in word)
                {
                    if (!curTrieNode.Characters.ContainsKey(c))
                    {
                        curTrieNode.Characters.Add(c, new TrieNode());
                    }

                    curTrieNode = curTrieNode.Characters[c];
                }

                curTrieNode.Word = word;
                return curTrieNode;
            }
        }
        
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var trie = new TrieNode();
            foreach (var word in wordDict)
            {
                trie.AddWord(word);
            }

            var results = new List<List<string>>[s.Length + 1];
            results[s.Length] = new List<List<string>>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                var curTrie = trie;
                int j;
                for (j = i; j < s.Length && curTrie != null; j++)
                {
                    if (curTrie.Word != null && results[j] != null)
                    {
                        if (results[i] == null)
                        {
                            results[i] = new List<List<string>>();
                        }

                        foreach (var subList in results[j])
                        {
                            var newSubResult = new List<string>
                            {
                                curTrie.Word
                            };
                            newSubResult.AddRange(subList);
                            results[i].Add(newSubResult);
                        }
                    }

                    curTrie = curTrie.GetNext(s[j]);
                }

                if (j != s.Length || curTrie?.Word == null)
                {
                    continue;
                }

                if (results[i] == null)
                {
                    results[i] = new List<List<string>>();
                }
                results[i].Add(new List<string> {curTrie.Word});
            }


            return results[0]
                .Select(subResult =>
                {
                    var sb = new StringBuilder();
                    sb.Append(subResult[0]);
                    for (int i = 1; i < subResult.Count; i++)
                    {
                        sb.Append(" " + subResult[i]);
                    }
                    return sb.ToString();
                })
                .ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            /*var wordBreak = sln.WordBreak("pineapplepenapple",
                new List<string>(new[] {"apple", "pen", "applepen", "pine", "pineapple"}));*/
            var wordBreak = sln.WordBreak("catsandog",
                new List<string>(new[] { "cats", "dog", "sand", "and", "cat" }));

            foreach (var opton in wordBreak)
            {
                foreach (var word in opton)
                {
                    Console.Write("{0}", word);
                }
                Console.WriteLine();
            }
        }
    }
}
