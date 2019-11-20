using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _452_BurstBaloons
{
    public class Solution
    {
        private class StartPointsComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[0] != y[0] ? x[0] - y[0] : x[1] - y[1];
            }
        }

        public int FindMinArrowShots(int[][] points)
        {
            Array.Sort(points, new StartPointsComparer());

            int result = 0;
            int curIndex = 0;
            while (curIndex < points.Length)
            {
                var shot = points[curIndex][1];
                int j = curIndex + 1;
                while (j < points.Length && points[j][0] <= shot)
                {
                    shot = Math.Min(points[j][1], shot);
                    j++;
                }


                curIndex = j;
                result++;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var array = new[]
            {
                new[] {3, 9},
                new[] {7, 12},
                new[] {3, 8},
                new[] {6, 8},
                new[] {9, 10},
                new[] {2, 9},
                new[] {0, 9},
                new[] {3, 9},
                new[] {0, 6},
                new[] {2, 8}
            };
            
            var sln = new Solution();
            Console.WriteLine(sln.FindMinArrowShots(array));


            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Remove()
        }
    }
}
