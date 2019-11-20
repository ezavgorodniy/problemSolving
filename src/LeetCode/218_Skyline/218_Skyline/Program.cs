using System;
using System.Collections.Generic;

namespace _218_Skyline
{
    public class Solution
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

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var result = new List<IList<int>>();
            int[] x2Buildings = new int[buildings.GetLength(0)], heights = new int[buildings.GetLength(0)];
            for (int i = 0; i < x2Buildings.Length; i++)
            { x2Buildings[i] = buildings[i][1]; heights[i] = buildings[i][2]; }
            Array.Sort(x2Buildings, heights); //Sort x2 and height seqences
            int[,] xAll = new int[buildings.GetLength(0) * 2, 3]; //0: x, 1: height, 2: left/right
            for (int i = 0, j = 0; i < buildings.GetLength(0) || j < x2Buildings.Length;)
            { // Merging Sort all edges
                int x1 = i < buildings.Length ? buildings[i][0] : int.MaxValue;
                int x2 = j < x2Buildings.Length ? x2Buildings[j] : int.MaxValue;
                if (j == x2Buildings.Length || i < buildings.GetLength(0) && x1 <= x2)
                {
                    xAll[i + j, 0] = buildings[i][0];
                    xAll[i + j, 1] = buildings[i][2];
                    xAll[i + j, 2] = 0;
                    i++;
                }
                else
                {
                    xAll[i + j, 0] = x2Buildings[j];
                    xAll[i + j, 1] = heights[j];
                    xAll[i + j, 2] = 1;
                    j++;
                }
            }

            var curHeights = new Dictionary<int, int>();
            var sH = new MaxIntHeap();
            for (int i = 0; i < xAll.GetLength(0); i++)
            {
                if (xAll[i, 2] == 0)
                {
                    curHeights[xAll[i, 1]] = curHeights.ContainsKey(xAll[i, 1]) ? curHeights[xAll[i, 1]] + 1 : 1;
                    sH.Push(xAll[i, 1]);
                }
                else
                {
                    if (curHeights[xAll[i, 1]] > 1) curHeights[xAll[i, 1]]--;
                    else
                    {
                        curHeights.Remove(xAll[i, 1]);
                        sH.Push(xAll[i, 1]);
                    }
                }
                int curMaxHeight = curHeights.Count == 0 ? 0 : sH.Peek();
                if (result.Count > 0 && result[result.Count - 1][1] == curMaxHeight) continue;
                else if (result.Count > 0 && result[result.Count - 1][0] == xAll[i, 0])
                    result[result.Count - 1][1] = curMaxHeight;
                else result.Add(new int[] { xAll[i, 0], curMaxHeight });
            }
            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
