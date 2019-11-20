using System;

namespace _73_MatrixZero
{
    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return;
            }

            int n = matrix.Length;
            int m = matrix[0].Length;

            bool fillFirstColumn = false;
            bool fillFirstWo

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            bool fillFirstColumnAndRow = matrix[0][0] == 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                    if (matrix[i][0] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (fillFirstColumnAndRow)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i][0] = 0;
                }
                for (int j = 0; j < m; j++)
                {
                    matrix[0][j] = 0;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.SetZeroes(new[]
            {
                new[] {1, 1, 1},
                new[] {0, 1, 2} 
            });
            Console.WriteLine("Hello World!");
        }
    }
}
