using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _498_DiagonalTraverse
{
    public class Solution
    {
        public int[] FindDiagonalOrder(int[][] matrix)
        {
            int n = matrix.Length;
            if (n == 0)
            {
                return new int[0];
            }

            int m = matrix[0].Length;
            if (m == 0)
            {
                return new int[0];
            }
            var curResultIndex = 0;
            var curI = 0;
            var curJ = 0;
            var goUp = true;
            var result = new int[n * m];
            if (n == 1)
            {
                for (int j = 0; j < m; j++)
                {
                    result[j] = matrix[0][j];
                }
                return result;
            }
            if (m == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    result[i] = matrix[i][0];
                }
                return result;
            }

            while (curResultIndex < result.Length)
            {
                if (goUp)
                {
                    if (curI == n)
                    {
                        curI--;
                        curJ++;
                    }

                    while (curI >= 0 && curJ < m)
                    {
                        result[curResultIndex] = matrix[curI][curJ];

                        curI--;
                        curJ++;
                        curResultIndex++;
                    }

                    curI++;

                    goUp = false;
                }
                else
                {
                    if (curJ == m)
                    {
                        curJ--;
                        curI++;
                    }
                    while (curI < n && curJ >= 0)
                    {
                        result[curResultIndex] = matrix[curI][curJ];

                        curI++;
                        curJ--;
                        curResultIndex++;
                    }

                    curJ++;

                    goUp = true;
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[]
            {
                new[] {1, 2, 5, 6},
                new[] {3, 4, 7, 8}
            };

            var sln = new Solution();
            var result = sln.FindDiagonalOrder(matrix);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
