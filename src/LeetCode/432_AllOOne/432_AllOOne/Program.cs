using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _432_AllOOne
{
    public class AllOne
    {

        private readonly Dictionary<int, HashSet<string>> _dictByOccurences = new Dictionary<int, HashSet<string>>();

        private readonly Dictionary<string, LinkedListNode<int>> _dictByKey =
            new Dictionary<string, LinkedListNode<int>>();

        private readonly LinkedList<int> _occurencesAmount = new LinkedList<int>();

        /** Initialize your data structure here. */
        public AllOne()
        {

        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if (!_dictByKey.ContainsKey(key))
            {
                if (_occurencesAmount.Count != 0 && _occurencesAmount.First.Value == 1)
                {
                    _dictByKey.Add(key, _occurencesAmount.First);
                }
                else
                {
                    _occurencesAmount.AddFirst(1);
                    _dictByKey.Add(key, _occurencesAmount.First);
                }

                if (_dictByOccurences.ContainsKey(1))
                {
                    _dictByOccurences[1].Add(key);
                }
                else
                {
                    _dictByOccurences.Add(1, new HashSet<string>{key});
                }
            }
            else
            {
                var curValue = _dictByKey[key];
                var nextValue = curValue.Next;
                if (nextValue == null || nextValue.Value != curValue.Value + 1)
                {
                    nextValue = new LinkedListNode<int>(curValue.Value + 1);
                    _occurencesAmount.AddAfter(curValue, nextValue);
                }

                _dictByKey[key] = nextValue;
                _dictByOccurences[curValue.Value].Remove(key);
                if (_dictByOccurences[curValue.Value].Count == 0)
                {
                    _occurencesAmount.Remove(curValue);
                }

                if (_dictByOccurences.ContainsKey(nextValue.Value))
                {
                    _dictByOccurences[nextValue.Value].Add(key);
                }
                else
                {
                    _dictByOccurences.Add(nextValue.Value, new HashSet<string>{key});
                }
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!_dictByKey.ContainsKey(key))
            {
                throw new Exception("Not existed key decrement");
            }

            var curValue = _dictByKey[key];
            var prevValue = curValue.Previous;
            if (curValue.Value != 1)
            {
                if (prevValue == null || prevValue.Value != curValue.Value - 1)
                {
                    prevValue = new LinkedListNode<int>(curValue.Value - 1);
                    _occurencesAmount.AddBefore(curValue, prevValue);
                }

                _dictByKey[key] = prevValue;
            }
            else
            {
                _dictByKey.Remove(key);
            }

            _dictByOccurences[curValue.Value].Remove(key);
            if (_dictByOccurences[curValue.Value].Count == 0)
            {
                _occurencesAmount.Remove(curValue);
            }

            if (curValue.Value != 1 && prevValue != null)
            {
                if (_dictByOccurences.ContainsKey(prevValue.Value))
                {
                    _dictByOccurences[prevValue.Value].Add(key);
                }
                else
                {
                    _dictByOccurences.Add(prevValue.Value, new HashSet<string> {key});
                }
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            return _occurencesAmount.Count == 0 ? string.Empty : _dictByOccurences[_occurencesAmount.Last()].First();
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            return _occurencesAmount.Count == 0 ? string.Empty : _dictByOccurences[_occurencesAmount.First()].First();
        }
    }

    /**
     * Your AllOne object will be instantiated and called as such:
     * AllOne obj = new AllOne();
     * obj.Inc(key);
     * obj.Dec(key);
     * string param_3 = obj.GetMaxKey();
     * string param_4 = obj.GetMinKey();
     */


    class Program
    {
        static void Main(string[] args)
        {
            var allOne = new AllOne();
            Console.WriteLine($"Min={allOne.GetMinKey()}; Max={allOne.GetMaxKey()}");
            allOne.Inc("A");
            allOne.Inc("A");
            allOne.Inc("A");
            Console.WriteLine($"Min={allOne.GetMinKey()}; Max={allOne.GetMaxKey()}");
            allOne.Inc("B");
            Console.WriteLine($"Min={allOne.GetMinKey()}; Max={allOne.GetMaxKey()}");
            allOne.Dec("B");
            Console.WriteLine($"Min={allOne.GetMinKey()}; Max={allOne.GetMaxKey()}");
            allOne.Inc("B");
            allOne.Inc("B");
            allOne.Inc("B");
            allOne.Inc("B");
            Console.WriteLine($"Min={allOne.GetMinKey()}; Max={allOne.GetMaxKey()}");
        }
    }
}
