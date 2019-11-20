using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _74_Search2dMatrix
{
    public class Solution
    {
        private int GetValue(int[][] matrix, int arrayIndex)
        {
            int m = matrix[0].Length;
            int i = arrayIndex / m;
            int j = arrayIndex % m;
            return matrix[i][j];
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }

            int flatArraySize = matrix.Length * matrix[0].Length;


            int l = 0, r = flatArraySize - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                int mVal = GetValue(matrix, m);
                if (mVal == target)
                {
                    return true;
                }
                if (mVal < target)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[]
            {
                new[] {1, 3, 5, 7},
                new[] {10, 11, 16, 20},
                new[] {23, 30, 34, 50}
            };

            var sln = new Solution();
            Console.WriteLine(sln.SearchMatrix(matrix, 3));
        }
    }
}
