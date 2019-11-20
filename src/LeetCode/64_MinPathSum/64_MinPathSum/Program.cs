using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64_MinPathSum
{
    public class Solution
    {

        public int MinPathSum(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            for (int i = n - 2; i >= 0; i--)
            {
                grid[i][m - 1] += grid[i + 1][m - 1];
            }
            for (int j = m - 2; j >= 0; j--)
            {
                grid[n - 1][j] += grid[n - 1][j + 1];
            }

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    grid[i][j] += Math.Min(grid[i + 1][j], grid[i][j + 1]);
                }
            }

            return grid[0][0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[]
            {
                new[] {1, 2},
                new[] {5, 6},
                new[] {1, 1}
            };

            var sln = new Solution();
            Console.WriteLine(sln.MinPathSum(matrix));
        }
    }
}
