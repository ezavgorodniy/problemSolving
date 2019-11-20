using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _460_LFUCached
{
    public class LFUCache
    {

        private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _keyToLinkedListNode = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        private readonly LinkedList<KeyValuePair<int, int>> _values = new LinkedList<KeyValuePair<int, int>>();
        private readonly int _capacity;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_keyToLinkedListNode.ContainsKey(key))
            {
                return -1;
            }

            var node = _keyToLinkedListNode[key];
            _values.Remove(node);
            _values.AddLast(node);
            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            LinkedListNode<KeyValuePair<int, int>> node;
            if (_keyToLinkedListNode.ContainsKey(key))
            {
                node = _keyToLinkedListNode[key];
                _values.Remove(node);
            }
            else
            {
                node = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
                _keyToLinkedListNode.Add(key, node);
            }

            node.Value = new KeyValuePair<int, int>(key, value);
            _values.AddLast(node);

            while (_values.Count > _capacity)
            {
                _keyToLinkedListNode.Remove(_values.First.Value.Key);
                _values.RemoveFirst();
            }
        }
    }

    /**
     * Your LFUCache object will be instantiated and called as such:
     * LFUCache obj = new LFUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    class Program
    {
        static void Main(string[] args)

        {
            //    LFUCache cache = new LFUCache(2);

            //    cache.Put(1, 1);
            //    cache.Put(2, 2);
            //    cache.Get(1);       // returns 1
            //    cache.Put(3, 3);    // evicts key 2
            //    cache.Get(2);       // returns -1 (not found)
            //    cache.Get(3);       // returns 3.
            //    cache.Put(4, 4);    // evicts key 1.
            //    cache.Get(1);       // returns -1 (not found)
            //    cache.Get(3);       // returns 3
            //    cache.Get(4);       // returns 4

            //LFUCache cache = new LFUCache(1);

            //cache.Put(2, 1);
            //cache.Get(2);
            //cache.Put(3, 2); 
            //cache.Get(2); // returns -1 (not found)
            //cache.Get(3); // returns 3.

            /*["LFUCache","put","put","get","get","get","put","put","get","get","get","get"]
[[3],[2,2],[1,1],[2],[1],[2],[3,3],[4,4],[3],[2],[1],[4]]*/

            LFUCache cache = new LFUCache(3);
            cache.Put(2, 2);
            cache.Put(1, 1);
            cache.Get(2);
            cache.Get(1);
            cache.Get(2);
            cache.Put(3, 3);
            cache.Put(4, 4);
            cache.Get(3);
            cache.Get(2);
            cache.Get(1);
            cache.Get(4);
        }
    }
}
