using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _304_RangeSumQuery2d
{
    public class NumMatrix
    {

        private readonly int[][] _matrix;

        public NumMatrix(int[][] matrix)
        {
            _matrix = matrix;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    _matrix[i][j] += _matrix[i][j - 1];
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    _matrix[i][j] += _matrix[i - 1][j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write("{0}\t", matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var result = _matrix[row2][col2];
            if (row1 != 0)
            {
                result -= _matrix[row1 - 1][col2];
            }
            if (col1 != 0)
            {
                result -= _matrix[row2][col1 - 1];
            }
            if (row1 != 0 && col1 != 0)
            {
                result += _matrix[row1 - 1][col1 - 1];
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
                new[] {3, 0, 1, 4, 2},
                new[] {5, 6, 3, 2, 2},
                new[] {1, 2, 0, 1, 5},
                new[] {4, 1, 0, 1, 7},
                new[] {1, 0, 3, 0, 5}
            };

            var numMatrix = new NumMatrix(matrix);
            Console.WriteLine(numMatrix.SumRegion(2, 1, 4, 3));
            Console.WriteLine(numMatrix.SumRegion(1, 1, 2, 2));
            Console.WriteLine(numMatrix.SumRegion(1, 2, 2, 4));

        }
    }
}
