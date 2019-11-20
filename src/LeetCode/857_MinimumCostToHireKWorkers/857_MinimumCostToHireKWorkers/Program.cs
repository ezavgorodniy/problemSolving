using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _857_MinimumCostToHireKWorkers
{
    public class Solution
    {
        public abstract class BaseDoubleHeap
        {
            private const int InitialCapacity = 10;

            protected int Capacity = InitialCapacity;
            protected int Size = 0;
            protected double[] Items = new double[InitialCapacity];

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

            protected double LeftChild(int index)
            {
                return Items[GetLeftChildIndex(index)];
            }

            protected double RightChild(int index)
            {
                return Items[GetRightChildIndex(index)];
            }

            protected double Parent(int index)
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

            public double Peek()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                return Items[0];
            }

            public double Pop()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                var item = Items[0];
                Items[0] = Items[Size - 1];
                Size--;

                HeapifyDown();

                return item;
            }

            public void Push(double item)
            {
                EnsureExtraCapacity();
                Items[Size] = item;
                Size++;
                HeapifyUp();
            }

            public int Length => Size;
        }

        public class MaxDoubleHeap : BaseDoubleHeap
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

        public class Payment
        {
            public double Ratio { get; set; }
            public double Quality { get; set; }

            public Payment(int quality, int wage)
            {
                Ratio = (double)wage / quality;
                Quality = quality;
            }
        }

        public class PaymentComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var xPayment = (Payment)x;
                var yPayment = (Payment)y;
                return xPayment.Ratio - yPayment.Ratio == 0 ? 0 : xPayment.Ratio < yPayment.Ratio ? -1 : 1;
            }
        }

        public double MincostToHireWorkers(int[] quality, int[] wage, int K)
        {
            var payments = new Payment[quality.Length];
            for (int i = 0; i < quality.Length; i++)
            {
                payments[i] = new Payment(quality[i], wage[i]);
            }

            Array.Sort(payments, new PaymentComparer());

            var heap = new MaxDoubleHeap();
            var res = double.MaxValue;
            var qSum = 0.0;
            foreach (var payment in payments)
            {
                qSum += payment.Quality;
                heap.Push(payment.Quality);
                if (heap.Length > K)
                {
                    qSum -= heap.Pop();
                }
                if (heap.Length == K)
                {
                    res = Math.Min(res, qSum * payment.Ratio);
                }
            }

            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.MincostToHireWorkers(new []{ 3, 1, 10, 10, 1 }, new []{ 4, 8, 2, 2, 7 }, 3));
        }
    }
}
