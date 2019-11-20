using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _381_InsertDeleteGetRandom
{
    public class RandomizedCollection
    {
        private readonly List<int> _result;
        private readonly Dictionary<int, HashSet<int>> _map;
        private readonly Random _random;


        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            _result = new List<int>();
            _map = new Dictionary<int, HashSet<int>>();
            _random = new Random();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            var alreadyExists = _map.ContainsKey(val);
            if (!alreadyExists)
            {
                _map.Add(val, new HashSet<int>());
            }

            _map[val].Add(_result.Count);
            _result.Add(val);
            return !alreadyExists;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (_map.ContainsKey(val))
            {
                return false;
            }

            var valSet = _map[val];
            var indexToReplace = valSet.First();

            var numAtLastPlace = _result[_result.Count - 1];
            var replaceWith = _map[numAtLastPlace];

            _result[indexToReplace] = numAtLastPlace;

            valSet.Remove(indexToReplace);

            if (indexToReplace != _result.Count - 1)
            {
                replaceWith.Remove(_result.Count - 1);
                replaceWith.Add(indexToReplace);
            }
            _result.Remove(_result.Count - 1);

            if (valSet.Count == 0)
            {
                _map.Remove(val);
            }

            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            return _result[(int)(_random.NextDouble() * _result.Count)];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var obj = new RandomizedCollection();
            Console.WriteLine(obj.Insert(1));
            Console.WriteLine(obj.Remove(2));
            Console.WriteLine(obj.Insert(1));
            Console.WriteLine(obj.GetRandom());
            Console.WriteLine(obj.Remove(1));
            Console.WriteLine(obj.Insert(2));
            Console.WriteLine(obj.GetRandom());
        }
    }
}
