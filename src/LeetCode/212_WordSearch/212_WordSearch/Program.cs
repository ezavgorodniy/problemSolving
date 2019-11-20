using System;
using System.Collections.Generic;

namespace _212_WordSearch
{
    public class Solution
    {
        public class TrieNode
        {
            private readonly TrieNode[] _next;
            public string Word { get; set; }

            public TrieNode()
            {
                _next = new TrieNode[26];
            }

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
        }

        private TrieNode BuildTrie(string[] words)
        {
            var root = new TrieNode();
            foreach (var word in words)
            {
                var currentNode = root;
                foreach (char t in word)
                {
                    currentNode = currentNode.AddSymbol(t);
                }

                currentNode.Word = word;
            }
            return root;
        }

        private void DFS(char[][] board, int i, int j, TrieNode trie, List<string> res)
        {
            var c = board[i][j];
            var next = c != '#' ? trie.GetSymbol(c) : null;
            if (next == null)
            {
                return;
            }

            if (next.Word != null)
            {
                res.Add(next.Word);
                next.Word = null;
            }

            board[i][j] = '#';
            if (i > 0)
            {
                DFS(board, i - 1, j, next, res);
            }
            if (j > 0)
            {
                DFS(board, i, j - 1, next, res);
            }
            if (i < board.Length - 1)
            {
                DFS(board, i + 1, j, next, res);
            }
            if (j < board[i].Length - 1)
            {
                DFS(board, i, j + 1, next, res);
            }

            board[i][j] = c;
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var trie = BuildTrie(words);
            var result = new List<string>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    DFS(board, i, j, trie, result);
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','k','r'],
  ['i','f','l','v']
]*/

            var board = new[]
            {
                new[] { 'o', 'a', 'a', 'n' },
                new [] { 'e', 't', 'a', 'e' },
                new [] { 'i', 'h', 'k', 'r' },
                new [] { 'i', 'f', 'l', 'v' }
            };

            var sln = new Solution();
            var words = sln.FindWords(board, new[] {"oath", "pea", "eat", "rain"});

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
