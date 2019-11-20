using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _295_MedianFromDataStream
{
    public class MedianFinder
    {
        public abstract class BaseIntHeap
        {
            private const int InitialCapacity = 10;

            protected int Capacity = InitialCapacity;
            protected int Size = 0;
            protected int[] Items = new int[InitialCapacity];

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

            protected void EnsureExtraCapacity()
            {
                if (Size != Capacity)
                {
                    return;
                }

                Array.Resize(ref Items, Capacity * 2);
                Capacity *= 2;
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
                EnsureExtraCapacity();
                Items[Size] = item;
                Size++;
                HeapifyUp();
            }

            public int GetSize()
            {
                return Size;
            }
        }

        public class MaxIntHeap : BaseIntHeap
        {
            protected override void HeapifyDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    int largerChildIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && RightChild(index) > LeftChild(index))
                    {
                        largerChildIndex = GetRightChildIndex(index);
                    }

                    if (Items[index] > Items[largerChildIndex])
                    {
                        break;
                    }

                    Swap(index, largerChildIndex);
                    index = largerChildIndex;
                }
            }

            protected override void HeapifyUp()
            {
                int index = Size - 1;
                while (HasParent(index) && Parent(index) < Items[index])
                {
                    Swap(GetParentIndex(index), index);
                    index = GetParentIndex(index);
                }
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
        }

        private readonly MaxIntHeap _maxIntHeap = new MaxIntHeap();
        private readonly MinIntHeap _minIntHeap = new MinIntHeap();
        private double _median = 0.0;

        /** initialize your data structure here. */
        public MedianFinder()
        {
        }

        public void AddNum(int num)
        {
            _minIntHeap.Push(num);
            _maxIntHeap.Push(_minIntHeap.Pop());

            if (_minIntHeap.GetSize() < _maxIntHeap.GetSize())
            {
                _minIntHeap.Push(_maxIntHeap.Pop());
            }
        }

        public double FindMedian()
        {
            if (_minIntHeap.GetSize() == 0 && _maxIntHeap.GetSize() == 0) return 0;

            if (_minIntHeap.GetSize() == _maxIntHeap.GetSize())
            {
                return ((double)_minIntHeap.Peek() + _maxIntHeap.Peek()) / 2;
            }
            else if (_minIntHeap.GetSize() > _maxIntHeap.GetSize())
            {
                return _minIntHeap.Peek();
            }
            else
            {
                return _minIntHeap.Peek();
            }
        }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */


    class Program
    {
        static void Main(string[] args)
        {
            var medianFinder = new MedianFinder();
            medianFinder.AddNum(6);
            Console.WriteLine(medianFinder.FindMedian()); // 6.0
            medianFinder.AddNum(10);
            Console.WriteLine(medianFinder.FindMedian()); // 8.0
            medianFinder.AddNum(2);
            Console.WriteLine(medianFinder.FindMedian()); // 6.0
            medianFinder.AddNum(6);
            Console.WriteLine(medianFinder.FindMedian()); // 6.0
            /*medianFinder.AddNum(1);
            Console.WriteLine(medianFinder.FindMedian());
            medianFinder.AddNum(2);
            Console.WriteLine(medianFinder.FindMedian());
            medianFinder.AddNum(3);
            Console.WriteLine(medianFinder.FindMedian());*/



            /*
             ["addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian"]
             [[],[6],[],[10],[],[2],[],[6],[],[5],[],[0],[],[6],[],[3],[],[1],[],[0],[],[0],[]]
             
             */
        }
    }
}
