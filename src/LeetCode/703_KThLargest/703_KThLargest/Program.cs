using System;

namespace _703_KThLargest
{
    public class KthLargest
    {
        public abstract class BaseIntHeap
        {
            protected int Size = 0;
            protected readonly int[] Items;

            protected BaseIntHeap(int capacity)
            {
                Items = new int[capacity + 1];

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

            protected int LeftChild(int index)
            {
                return Items[GetLeftChildIndex(index)];
            }

            protected int RightChild(int index)
            {
                return Items[GetRightChildIndex(index)];
            }

            protected int Parent(int index)
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

            public int Peek()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                return Items[0];
            }

            public int Pop()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                int item = Items[0];
                Items[0] = Items[Size - 1];
                Size--;

                HeapifyDown();

                return item;
            }

            public void Push(int item)
            {
                Items[Size] = item;
                Size++;
                HeapifyUp();
            }

            public bool IsFull()
            {
                return Size == Items.Length;
            }
        }

        public class MinIntHeap : BaseIntHeap
        {
            protected override void HeapifyDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    int smallerChildIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                    {
                        smallerChildIndex = GetRightChildIndex(index);
                    }

                    if (Items[index] < Items[smallerChildIndex])
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
                while (HasParent(index) && Parent(index) > Items[index])
                {
                    Swap(GetParentIndex(index), index);
                    index = GetParentIndex(index);
                }
            }

            public MinIntHeap(int capacity) : base(capacity)
            {
            }
        }

        private readonly MinIntHeap _heap;


        public KthLargest(int k, int[] nums)
        {
            _heap = new MinIntHeap(k);

            for (int i = 0; i < k && i < nums.Length; i++)
            {
                _heap.Push(nums[i]);
            }


            for (int i = k; i < nums.Length; i++)
            {
                AddImpl(nums[i]);
            }
        }

        public int Add(int val)
        {
            AddImpl(val);
            return _heap.Peek();
        }

        private void AddImpl(int val)
        {
            if (val < _heap.Peek())
            {
                return;
            }

            _heap.Push(val);
            if (!_heap.IsFull())
            {
                return;
            }

            _heap.Pop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KthLargest kthLargest = new KthLargest(1, new int[0]);
            Console.WriteLine(kthLargest.Add(-3));
            Console.WriteLine(kthLargest.Add(-2));
            Console.WriteLine(kthLargest.Add(-4));
            Console.WriteLine(kthLargest.Add(0));
            Console.WriteLine(kthLargest.Add(4));
            //KthLargest kthLargest = new KthLargest(3, new []{4,5,8,2});
            //Console.WriteLine(kthLargest.Add(3));   // returns 4
            //Console.WriteLine(kthLargest.Add(5));   // returns 5
            //Console.WriteLine(kthLargest.Add(10));  // returns 5
            //Console.WriteLine(kthLargest.Add(9));   // returns 8
            //Console.WriteLine(kthLargest.Add(4));   // returns 8
        }
    }
}
