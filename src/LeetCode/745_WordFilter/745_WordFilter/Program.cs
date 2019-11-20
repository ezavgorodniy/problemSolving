using System;
using System.Collections.Generic;

namespace _745_WordFilter
{
    public class WordFilter
    {
        private class TrieNode
        {
            private readonly Dictionary<char, TrieNode> _next = new Dictionary<char, TrieNode>();
            public bool IsWord { get; private set; }
            public int Index { get; private set; }

            public TrieNode AddSymbol(char c)
            {
                TrieNode result;
                if (!_next.ContainsKey(c))
                {
                    result = new TrieNode();
                    _next.Add(c, result);
                }
                else
                {
                    result = _next[c];
                }
                return result;
            }

            public TrieNode GetSymbol(char c)
            {
                return _next.ContainsKey(c) ? _next[c] : null;
            }

            public TrieNode AddWord(int index)
            {
                Index = index;
                IsWord = true;
                return this;
            }

            public Dictionary<char, TrieNode>.KeyCollection PossibleSymbols()
            {
                return _next.Keys;
            }
        }

        private readonly string[] _words;
        private readonly TrieNode _trie;


        public WordFilter(string[] words)
        {
            if (words == null)
            {
                throw new ArgumentNullException();
            }

            _words = words;
            _trie = new TrieNode();

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var suffix = "";
                AddWordToTrie(suffix + "#" + word, i);
                for (int j = word.Length - 1; j >= 0; j--)
                {
                    suffix = word[j] + suffix;
                    AddWordToTrie(suffix + "#" + word, i);
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            var searchPattern = suffix + "#" + prefix;
            var currentTrieNode = _trie;
            for (int i = 0; i < searchPattern.Length && currentTrieNode != null; i++)
            {
                var c = searchPattern[i];
                currentTrieNode = currentTrieNode.GetSymbol(c);
            }

            int result = -1;
            FindBiggestWeight(currentTrieNode, ref result);
            return result;
        }

        private void FindBiggestWeight(TrieNode trieNode, ref int result)
        {
            if (trieNode == null)
            {
                return;
            }
            if (trieNode.IsWord && trieNode.Index > result)
            {
                result = trieNode.Index;
            }

            var possibleSymbols = trieNode.PossibleSymbols();
            foreach (var key in possibleSymbols)
            {
                FindBiggestWeight(trieNode.GetSymbol(key), ref result);
            }
        }

        private void AddWordToTrie(string word, int index)
        {
            var currentTrieNode = _trie;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                currentTrieNode = currentTrieNode.AddSymbol(c);
            }

            currentTrieNode.AddWord(index);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var wordFilter = new WordFilter(new [] { "apple", "apppppppppple"});
            Console.WriteLine(wordFilter.F("a", "e"));
            Console.WriteLine(wordFilter.F("b", ""));
        }
    }
}
