using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _126_WordLadder
{
    public class Solution
    {
        private bool IsOneLetterTransformation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            int cntDifferences = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    cntDifferences++;
                }
            }

            return cntDifferences == 1;
        }

        private IList<string> GetTransformationWords(string word, IList<string> words)
        {
            var result = new List<string>();
            foreach (var anotherWord in words)
            {
                if (IsOneLetterTransformation(word, anotherWord))
                {
                    result.Add(anotherWord);
                }
            }

            return result;
        }

        private Dictionary<string, IList<string>> GetEdges(string beginWord, IList<string> wordList)
        {
            var edges = new Dictionary<string, IList<string>>();
            foreach (var word in wordList)
            {
                edges.Add(word, GetTransformationWords(word, wordList));
            }
            if (!edges.ContainsKey(beginWord))
            {
                edges.Add(beginWord, GetTransformationWords(beginWord, wordList));
            }
            return edges;
        }

        private IList<IList<string>> BFS(string startWord,
                         Dictionary<string, IList<string>> edges,
                         string endWord)
        {
            var results = new List<IList<string>>();
            var depthVisited = new Dictionary<string, int>();
            depthVisited.Add(startWord, 0);

            var queue = new Queue<IList<string>>();
            queue.Enqueue(new List<string>(new[] { startWord }));
            while (queue.Count != 0)
            {
                var curPath = queue.Dequeue();
                if (results.Count != 0 && curPath.Count + 1 > results.First().Count)
                {
                    continue;
                }

                var lastWord = curPath[curPath.Count - 1];
                var curDepth = depthVisited[lastWord];
                foreach (var nextWord in edges[lastWord])
                {
                    if (nextWord == endWord)
                    {
                        var subResult = new List<string>(curPath);
                        subResult.Add(endWord);
                        results.Add(subResult);
                        continue;
                    }
                    if (depthVisited.ContainsKey(nextWord))
                    {
                        if (depthVisited[nextWord] > curDepth + 1)
                        {
                            continue;
                        }
                        depthVisited[nextWord] = curDepth + 1;
                    }
                    else
                    {
                        depthVisited.Add(nextWord, curDepth + 1);
                    }

                    var newPath = new List<string>(curPath);
                    newPath.Add(nextWord);
                    queue.Enqueue(newPath);
                }
            }

            return results;
        }

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            return BFS(beginWord, GetEdges(beginWord, wordList), endWord);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            /*var result = sln.FindLadders("hit", "cog",
                new List<string>(new[] {"hot", "dot", "dog", "lot", "log", "cog"}));*/
            /*var result = sln.FindLadders("a", "c",
                new List<string>(new[]
                {
                    "a", "b", "c"
                }));*/
            /*var result = sln.FindLadders("red", "tax",
                new List<string>(new[]
                {
                    "ted","tex","red","tax","tad","den","rex","pee"
                }));*/
            var result = sln.FindLadders("hit", "cog",
                new List<string>(new[]
                {
                    "hot","dot","dog","lot","log"
                }));

            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add()

            foreach (var subResult in result)
            {
                foreach (var word in subResult)
                {
                    Console.Write("{0} ", word);
                }
                Console.WriteLine();
            }
        }
    }
}
