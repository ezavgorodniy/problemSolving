using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _695_MaxAreOfIsland
{
    public class Solution
    {
        public void MarkIslandAndCalculateArea(int[][] grid, int i, int j, ref int area)
        {
            if (i < 0 || i >= grid.Length
                || j < 0 || j >= grid[0].Length
                || grid[i][j] != '1')
            {
                return;
            }

            area++;
            grid[i][j] = '2';
            MarkIslandAndCalculateArea(grid, i - 1, j, ref area);
            MarkIslandAndCalculateArea(grid, i + 1, j, ref area);
            MarkIslandAndCalculateArea(grid, i, j - 1, ref area);
            MarkIslandAndCalculateArea(grid, i, j + 1, ref area);
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        int subResult = 0;
                        MarkIslandAndCalculateArea(grid, i, j, ref subResult);
                        if (subResult > result)
                        {
                            result = subResult;
                        }
                    }
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var grid = new[]
            {
                new[] {1, 1, 0, 0, 0},
                new[] {1, 1, 0, 0, 0},
                new[] {0, 0, 0, 1, 1},
                new[] {0, 0, 0, 1, 1}
            };

            var sln = new Solution();
            Console.WriteLine(sln.MaxAreaOfIsland(grid));
        }
    }
}
