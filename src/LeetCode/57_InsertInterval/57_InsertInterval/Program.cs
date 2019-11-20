using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57_InsertInterval
{
    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int index = 0;
            while (index < intervals.Length && intervals[index][1] < newInterval[0])
            {
                result.Add(intervals[index]);
                index++;
            }

            if (index == intervals.Length)
            {
                result.Add(newInterval);
            }
            else
            {
                int overlapLeft = Math.Min(intervals[index][0], newInterval[0]);
                int overlapRight = newInterval[1];
                while (index < intervals.Length && intervals[index][0] <= overlapRight)
                {
                    overlapRight = Math.Max(intervals[index][1], overlapRight);
                    index++;
                }

                result.Add(new[] {overlapLeft, overlapRight});

                while (index < intervals.Length)
                {
                    result.Add(intervals[index]);
                    index++;
                }
            }

            return result.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var originalIntervals = new[]
            {
                new[] { 1,2  },
                new[] { 3, 5 },
                new[] { 6, 7 },
                new[] { 8, 10 },
                new[] { 12, 16 }
            };
            var sln = new Solution();
            var result = sln.Insert(originalIntervals, new[] {4, 8});

            foreach (var interval in result)
            {
                Console.Write($"[{interval[0]}, {interval[1]}]");
            }
        }
    }
}
