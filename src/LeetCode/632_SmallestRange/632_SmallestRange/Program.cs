using System;
using System.Collections.Generic;

namespace _632_SmallestRange
{
    public class Solution
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var numsList = new IList<int>[nums.Count];
            int n = 0;
            foreach (var num in nums)
            {
                numsList[n++] = num;
            }
            int[][] mergedArr = MergeKList(numsList, 0, numsList.Length - 1);
            int arrLen = mergedArr.Length;
            int minDist = int.MaxValue;
            int[] count = new int[n];
            int curValidCount = 0;
            int frontIdx = 0, backIdx = 0;

            int left = 0, right = 0;
            while (frontIdx < arrLen)
            {
                while (frontIdx < arrLen && curValidCount < n)
                {
                    if (++count[mergedArr[frontIdx++][1]] == 1)
                    {
                        curValidCount++;
                    }
                }

                while (backIdx < frontIdx && curValidCount == n)
                {
                    if (--count[mergedArr[backIdx++][1]] == 0)
                    {
                        curValidCount--;
                        if (minDist > mergedArr[frontIdx - 1][0] - mergedArr[backIdx - 1][0])
                        {
                            minDist = mergedArr[frontIdx - 1][0] - mergedArr[backIdx - 1][0];
                            left = mergedArr[backIdx - 1][0];
                            right = mergedArr[frontIdx - 1][0];
                        }
                    }
                }
            }
            return new[] { left, right };


        }

        private int[][] MergeKList(IList<int>[] numsList, int s, int e)
        {
            if (s == e)
            {
                int n = 0;
                var res = new int[numsList[s].Count][];
                foreach (var integer in numsList[s])
                {
                    res[n++] = new [] { integer, s };
                }
                return res;
            }

            var mid = s + (e - s) / 2;
            var leftList = MergeKList(numsList, s, mid);
            var rightList = MergeKList(numsList, mid + 1, e);
            return MergeTwoList(leftList, rightList);
        }


        private int[][] MergeTwoList(int[][] leftList, int[][] rightList)
        {
            int m = leftList.Length;
            int n = rightList.Length;
            var res = new int[m + n][];
            int lIdx = 0, rIdx = 0;
            int idx = 0;
            while (lIdx < m && rIdx < n)
            {
                if (leftList[lIdx][0] > rightList[rIdx][0])
                {
                    res[idx++] = rightList[rIdx++];
                }
                else
                {
                    res[idx++] = leftList[lIdx++];
                }
            }

            while (lIdx < m)
            {
                res[idx++] = leftList[lIdx++];
            }

            while (rIdx < n)
            {
                res[idx++] = rightList[rIdx++];
            }
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var smallestRange = sln.SmallestRange(new List<IList<int>>
            {
                new List<int> {4, 10, 15, 24, 26},
                new List<int> {0, 9, 12, 20},
                new List<int> {5, 18, 22, 30}
            });
            Console.WriteLine($"[{smallestRange[0]}; {smallestRange[1]}]");
        }
    }
}
