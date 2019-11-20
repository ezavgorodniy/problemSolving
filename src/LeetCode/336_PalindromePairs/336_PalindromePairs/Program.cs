using System;
using System.Collections.Generic;

namespace _336_PalindromePairs
{
    public class Solution
    {
        class TrieNode
        {
            public TrieNode[] Children { get; } 
            public List<int> Ids { get; }
            public int Index { get; set; }

            public TrieNode()
            {
                Children = new TrieNode[26];
                Ids = new List<int>();
                Index = -1;
            }
        }

        private TrieNode root;

        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var list = new List<IList<int>>();
            if (words.Length < 2)
            {
                return list;
            }

            var empty = new List<int>(); // to record index of empty word
            root = new TrieNode();

            for (int i = 0; i < words.Length; i++)
            {
                // O(n*len*len)
                if (words[i].Length == 0)
                {
                    empty.Add(i);
                    continue;
                }
                Insert(words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                // (n*len)
                Search(words[i], list, i, empty);
            }
            return list;
        }

        private void Search(string word, List<IList<int>> list, int idx, List<int> empty)
        {
            char[] wd = word.ToCharArray();
            TrieNode cur = root;

            for (int i = wd.Length - 1; i >= 0; i--)
            {
                // O(len)
                int pt = wd[i] - 'a';
                if (cur.Index != -1 && IsPalindrom(wd, 0, i))
                {
                    // prefix is palin, "cur.index != -1" means the end of a word
                    var li = new List<int> {cur.Index, idx};
                    list.Add(li);
                }
                if (cur.Children[pt] == null) return; // nothing to compare for the next step
                cur = cur.Children[pt];
            }

            if (cur.Ids.Count != 0)
            {
                // suffix is palin 
                foreach (var id in cur.Ids)
                {
                    if (id != idx) {
                        var li = new List<int> {id, idx};
                        list.Add(li);
                    } else {
                        foreach (var em in empty) {
                            var li = new List<int> {em, idx};
                            list.Add(li);
                            li = new List<int> {idx, em};
                            list.Add(li);
                        }
                    }
                }
            }
        }

        private void Insert(string word, int idx)
        {
            // O(len*len)
            var wd = word.ToCharArray();
            var cur = root;

            for (int i = 0; i < wd.Length; i++)
            {
                var pt = wd[i] - 'a';
                if (cur.Children[pt] == null)
                {
                    cur.Children[pt] = new TrieNode();
                }
                cur = cur.Children[pt];
                if (i == wd.Length - 1)
                {
                    cur.Index = idx;
                }
                if (IsPalindrom(wd, i + 1, wd.Length - 1))
                {
                    cur.Ids.Add(idx);
                }
            }
        }

        private bool IsPalindrom(char[] str, int i, int j)
        {
            while (j - i > 0)
            {
                if (str[i++] != str[j--])
                {
                    return false;
                }
            }
            return true;
        }
    }


    /*public class Solution
    {
        private class TrieNode
        {
            private readonly TrieNode[] _next = new TrieNode[26];

            public bool IsWord { get; private set; }

            public int WordIndex { get; private set; }

            public TrieNode AddSymbol(char c)
            {
                if (_next[c - 'a'] == null)
                {
                    _next[c - 'a'] = new TrieNode();
                }

                return _next[c - 'a'];
            }

            public TrieNode GetSymbol(char c)
            {
                return _next[c - 'a'];
            }

            public TrieNode AddWord(int wordIndex)
            {
                WordIndex = wordIndex;
                IsWord = true;
                return this;
            }

        }

        private TrieNode BuildTrie(string[] words)
        {
            var root = new TrieNode();

            for (int i = 0; i < words.Length; i++)
            {
                var curNode = root;
                foreach (var c in words[i])
                {
                    curNode = curNode.AddSymbol(c);
                }
                curNode.AddWord(i);
            }
            return root;
        }

        private bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private void FindPalindromesInternal(TrieNode root, string[] words, int index, List<int> result)
        {
            if (root.IsWord && index != root.WordIndex && IsPalindrome(words[index] + words[root.WordIndex]))
            {
                result.Add(root.WordIndex);
            }

            for (int i = 0; i < 26; i++)
            {
                char c = (char) ('a' + i);
                var nextTrie = root.GetSymbol(c);
                if (nextTrie != null)
                {
                    FindPalindromesInternal(nextTrie, words, index, result);
                }
            }
        }

        private TrieNode IterateReverseTrie(TrieNode trie, string s)
        {
            TrieNode current = trie;
            for (int i = s.Length - 1; i >= 0 && current.GetSymbol(s[i]) != null; i--)
            {
                current = current.GetSymbol(s[i]);
            }
            return current;
        }

        private List<int> FindPalindromes(TrieNode root, string[] words, int index)
        {
            var result = new List<int>();
            FindPalindromesInternal(root, words, index, result);
            return result;
        }


        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var result = new List<IList<int>>();
            var trie = BuildTrie(words);
            for (int i = 0; i < words.Length; i++)
            {
                var currentRoot = IterateReverseTrie(trie, words[i]);
                if (currentRoot == null)
                {
                    continue; // there is no such a word
                }
                var palindromes = FindPalindromes(currentRoot, words, i);
                foreach (var index in palindromes)
                {
                    if (index != i)
                    {
                        result.Add(new List<int>(new[] {i, index}));
                    }
                }
            }
            return result;
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var palindromPairs = solution.PalindromePairs(new[] {"abcd","dcba","lls","s","sssll"});
            for (int i = 0; i < palindromPairs.Count; i++)
            {
                for (int j = 0; j < palindromPairs[i].Count; j++)
                {
                    Console.Write(palindromPairs[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
