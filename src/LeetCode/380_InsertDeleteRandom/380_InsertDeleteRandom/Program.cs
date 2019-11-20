using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _380_InsertDeleteRandom
{
    public class RandomizedSet
    {

        private readonly Dictionary<int, HashSet<int>> _valueToIndexMap;
        private readonly List<int> _lstValues;
        private int _size = 0;
        private Random _random;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            _valueToIndexMap = new Dictionary<int, HashSet<int>>();
            _lstValues = new List<int>();
            _random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            bool result;
            HashSet<int> indexes;
            if (_valueToIndexMap.ContainsKey(val))
            {
                indexes = _valueToIndexMap[val];
                result = indexes.Count == 0;
            }
            else
            {
                indexes = new HashSet<int>();
                _valueToIndexMap.Add(val, indexes);
                result = true;
            }

            indexes.Add(_size);
            if (_size >= _lstValues.Count)
            {
                _lstValues.Add(val);
            }
            else
            {
                _lstValues[_size] = val;
            }
            _size++;

            return result;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!_valueToIndexMap.ContainsKey(val))
            {
                return false;
            }

            var indexes = _valueToIndexMap[val];
            if (indexes.Count == 0)
            {
                return false;
            }

            var indexToRemove = indexes.Last();
            indexes.Remove(indexToRemove);
            _size--;

            UpdateIndex(indexToRemove, _size);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return _lstValues[_random.Next(_size)];
        }

        private void UpdateIndex(int newIndex, int oldIndex)
        {
            var hashSet = _valueToIndexMap[_lstValues[oldIndex]];
            hashSet.Remove(oldIndex);
            hashSet.Add(newIndex);

            _lstValues[newIndex] = _lstValues[oldIndex];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RandomizedSet randomSet = new RandomizedSet();
            Console.WriteLine(randomSet.Remove(0));
            Console.WriteLine(randomSet.Remove(0));
            Console.WriteLine(randomSet.Insert(0));
            Console.WriteLine(randomSet.GetRandom());
            Console.WriteLine(randomSet.Remove(0));
            Console.WriteLine(randomSet.Insert(0));
        }
    }
}
