using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_RotateImage
{
    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Swap(matrix, i, j, j, i);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    Swap(matrix, i, j, i, n - j - 1);
                }
            }
        }

        private void Swap(int[][] matrix, int i1, int j1, int i2, int j2)
        {
            int tmp = matrix[i1][j1];
            matrix[i1][j1] = matrix[i2][j2];
            matrix[i2][j2] = tmp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[]
            {
                new[] {5, 1, 9, 11},
                new[] {2, 4, 8, 10},
                new[] {13, 3, 6, 7},
                new[] {15, 14, 12, 16}
            };

            var sln = new Solution();
            sln.Rotate(matrix);

            foreach (var row in matrix)
            {
                foreach (var cell in row)
                {
                    Console.Write("{0}\t", cell);
                }
                Console.WriteLine();
            }
        }
    }
}
