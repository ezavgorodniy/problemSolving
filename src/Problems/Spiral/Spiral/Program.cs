using System;
using System.Collections.Generic;

namespace Spiral
{

    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix.Length == 0)
            {
                return result;
            }
            if (matrix.Length == 1)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    result.Add(matrix[0][j]);
                }

                return result;
            }


            int currentStartI = 0;
            int currentStartJ = 0;
            int currentEndI = matrix.Length - 1;
            int currentEndJ = matrix[0].Length - 1;

            while (currentStartI <= currentEndI && currentStartJ <= currentEndJ)
            {
                for (int j = currentStartJ; j <= currentEndJ; j++)
                {
                    result.Add(matrix[currentStartI][j]);
                }
                for (int i = currentStartI + 1; i <= currentEndI; i++)
                {
                    result.Add(matrix[i][currentEndJ]);
                }
                for (int j = currentEndJ - 1; j >= currentStartJ; j--)
                {
                    result.Add(matrix[currentEndI][j]);
                }
                for (int i = currentEndI - 1; i >= currentStartI + 1; i--)
                {
                    result.Add(matrix[i][currentStartJ]);
                }

                currentStartI++;
                currentEndI--;
                currentStartJ++;
                currentEndJ--;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();

            var array = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                array[i] = new int[]{i};
            }
            sln.SpiralOrder(array);
        }
    }
}
