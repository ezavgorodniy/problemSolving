using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransposeMatrix
{
    public class Solution
    {
        public int[][] Transpose(int[][] A)
        {
            var N = A.Length;
            var M = A[0].Length;
            int[][] result = new int[M][];
            for (int i = 0; i < M; i++)
            {
                result[i] = new int[N];
            }


            for (int i = 0; i < N; i++)
            {
                for (int j = i; j < M; j++)
                {
                    result[j][i] = A[i][j];
                }
            }

            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.Transpose(new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                // new[] {7, 8, 9},
            });
        }
    }
}
