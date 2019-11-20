using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _49_GroupAnagrams
{
    public class Solution
    {
        public class NewPresentation
        {
            private readonly char[] _charOccurences = new char[26];
            private readonly int _hash;

            public NewPresentation(string s, int indexOriginalArray)
            {
                OriginalString = s;
                foreach (char c in s)
                {
                    _charOccurences[c - 'a']++;
                }

                _hash = CalculateHash();
                IndexOriginalArray = indexOriginalArray;
            }

            public int IndexOriginalArray { get; }

            public string OriginalString { get; }

            public override int GetHashCode()
            {
                return _hash;
            }

            public bool IsAnagram(NewPresentation np)
            {
                for (int i = 0; i < _charOccurences.Length; i++)
                {
                    if (_charOccurences[i] != np._charOccurences[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            private int CalculateHash()
            {
                var hashBase = 10000000;
                var hash = 0;
                for (int i = 0, multiplier = 10; i < _charOccurences.Length; i++, multiplier = (multiplier * 10) % (hashBase / 10))
                {
                    hash += _charOccurences[i] * multiplier;
                    hash %= hashBase;
                }

                return hashBase * OriginalString.Length + hash;
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            if (strs.Length <= 0)
            {
                return result;
            }

            var newPresentations = new NewPresentation[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                newPresentations[i] = new NewPresentation(strs[i], i);
            }

            var processed = new bool[strs.Length];
            var groupedPresentations = newPresentations.GroupBy(np => np.GetHashCode());
            foreach (var group in groupedPresentations)
            {
                var groupContent = group.ToArray();
                if (groupContent.Length == 0)
                {
                    continue;
                }

                int countProcessed = 0; 
                for (int i = 0; i < groupContent.Length && countProcessed < groupContent.Length; i++)
                {
                    if (processed[groupContent[i].IndexOriginalArray])
                    {
                        continue;
                    }

                    var newGroup = new List<string> {groupContent[i].OriginalString};
                    countProcessed++;
                    for (int j = i + 1; j < groupContent.Length; j++)
                    {
                        if (processed[groupContent[i].IndexOriginalArray])
                        {
                            continue;
                        }

                        if (groupContent[i].IsAnagram(groupContent[j]))
                        {
                            processed[groupContent[j].IndexOriginalArray] = true;
                            newGroup.Add(groupContent[j].OriginalString);
                            countProcessed++;
                        }
                    }
                    processed[groupContent[i].IndexOriginalArray] = true;
                    result.Add(newGroup);
                }
            }


            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var result = sln.GroupAnagrams(new[] {"eat", "tea", "tan", "ate", "nat", "bat"});
            foreach (var group in result)
            {
                Console.Write("[");
                foreach (var word in group)
                {
                    Console.Write(word + ",");
                    
                }
                Console.WriteLine("]");
            }
        }
    }
}
