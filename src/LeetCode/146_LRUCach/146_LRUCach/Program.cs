using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _146_LRUCach
{
    public class LRUCache
    {

        private class ListNode<T>
        {
            public ListNode<T> Prev { get; set; }

            public ListNode<T> Next { get; set; }

            public T Value { get; set; }

            public int Key { get; set; }
        }

        private readonly int _capacity;
        private readonly Dictionary<int, ListNode<int>> _map;
        private ListNode<int> _head;
        private ListNode<int> _tail;
        private int _size = 0;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _map = new Dictionary<int, ListNode<int>>();
        }

        public int Get(int key)
        {
            if (!_map.ContainsKey(key))
            {
                return -1;
            }

            var resultNode = _map[key];
            UpdateKeyUsage(resultNode);
            return resultNode.Value;
        }

        public void Put(int key, int value)
        {
            if (_map.ContainsKey(key))
            {
                var curListNode = _map[key];
                curListNode.Value = value;
                UpdateKeyUsage(curListNode);
            }
            else
            {
                var newNode = new ListNode<int>();
                newNode.Value = value;
                newNode.Key = key;
                _map.Add(key, newNode);
                if (_head == null) // first element
                {
                    _head = newNode;
                    _tail = newNode;
                }
                else
                {
                    _tail.Next = newNode;
                    newNode.Prev = _tail;
                    _tail = newNode;
                }

                _size++;
                if (_size > _capacity)
                {
                    _size--;
                    _map.Remove(_head.Key);
                    if (_capacity == 1)
                    {
                        _head = newNode;
                        _tail = newNode;
                    }
                    else
                    {
                        var newHead = _head.Next;
                        newHead.Prev = null;
                        _head.Next = null;
                        _head = newHead;
                    }
                }
            }
        }

        private void UpdateKeyUsage(ListNode<int> curListNode)
        {
            if (_capacity == 1)
            {
                _head = curListNode;
                _tail = curListNode;
                return;
            }

            if (_head == curListNode && _head != _tail)
            {
                _head = curListNode.Next;
                _head.Prev = null;
                curListNode.Prev = _tail;
                curListNode.Next = null;
                _tail.Next = curListNode;
                _tail = curListNode;
            }
            else if (curListNode != _tail)
            {
                var prev = curListNode.Prev;
                var next = curListNode.Next;
                prev.Next = next;
                next.Prev = prev;
                _tail.Next = curListNode;
                curListNode.Prev = _tail;
                curListNode.Next = null;
                _tail = curListNode;
            }
            // else // curListNode == tail, do nothing

        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    class Program
    {
        static void Main(string[] args)
        {
            /*LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4
            */

            var cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(2, 2);
            cache.Get(2);
            cache.Put(1, 1);
            cache.Put(4, 1);
            cache.Get(2);
        }
    }
}
