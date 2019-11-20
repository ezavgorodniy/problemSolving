using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _347_TopKFrequentElements
{

    public class Solution
    {
        public abstract class BaseIntHeap
        {
            protected int Size;
            protected readonly KeyValuePair<int, int>[] Items;

            public BaseIntHeap(int capacity)
            {
                Size = 0;
                Items = new KeyValuePair<int, int>[capacity + 1];
            }

            protected int GetLeftChildIndex(int parentIndex)
            {
                return 2 * parentIndex + 1;
            }
            protected int GetRightChildIndex(int parentIndex)
            {
                return 2 * parentIndex + 2;
            }

            protected int GetParentIndex(int childIndex)
            {
                return (childIndex - 1) / 2;
            }

            protected bool HasLeftChild(int index)
            {
                return GetLeftChildIndex(index) < Size;
            }

            protected bool HasRightChild(int index)
            {
                return GetRightChildIndex(index) < Size;
            }

            protected bool HasParent(int index)
            {
                return GetParentIndex(index) >= 0;
            }

            protected KeyValuePair<int, int> LeftChild(int index)
            {
                return Items[GetLeftChildIndex(index)];
            }

            protected KeyValuePair<int, int> RightChild(int index)
            {
                return Items[GetRightChildIndex(index)];
            }

            protected KeyValuePair<int, int> Parent(int index)
            {
                return Items[GetParentIndex(index)];
            }

            protected abstract void HeapifyDown();

            protected abstract void HeapifyUp();

            protected void Swap(int indexOne, int indexTwo)
            {
                var tmp = Items[indexOne];
                Items[indexOne] = Items[indexTwo];
                Items[indexTwo] = tmp;
            }

            public KeyValuePair<int, int> Peek()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                return Items[0];
            }

            public KeyValuePair<int, int> Pop()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                KeyValuePair<int, int> item = Items[0];
                Items[0] = Items[Size - 1];
                Size--;

                HeapifyDown();

                return item;
            }

            public void Push(KeyValuePair<int, int> item)
            {
                Items[Size] = item;
                Size++;
                HeapifyUp();

                if (Size == Items.Length - 1)
                {
                    Pop();
                }
            }
        }

        public class MinIntHeap : BaseIntHeap
        {
            public MinIntHeap(int capacity) : base(capacity)
            {
            }

            protected override void HeapifyDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    int smallerChildIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && RightChild(index).Value < LeftChild(index).Value)
                    {
                        smallerChildIndex = GetRightChildIndex(index);
                    }

                    if (Items[index].Value < Items[smallerChildIndex].Value)
                    {
                        break;
                    }

                    Swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
            }

            protected override void HeapifyUp()
            {
                int index = Size - 1;
                while (HasParent(index) && Parent(index).Value > Items[index].Value)
                {
                    Swap(GetParentIndex(index), index);
                    index = GetParentIndex(index);
                }
            }
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var occurences = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (occurences.ContainsKey(num))
                {
                    occurences[num]++;
                }
                else
                {
                    occurences.Add(num, 1);
                }
            }

            var heap = new MinIntHeap(k);
            foreach (var kvp in occurences)
            {
                heap.Push(kvp);
            }

            var result = new List<int>();
            while (k != 0)
            {
                result.Add(heap.Pop().Key);
                k--;
            }
            return result;


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            foreach (var result in sln.TopKFrequent(new[] { 1, 1, 1, 2, 2, 3 }, 2))
            {
                Console.WriteLine(result);
            }
            
        }
    }
}
