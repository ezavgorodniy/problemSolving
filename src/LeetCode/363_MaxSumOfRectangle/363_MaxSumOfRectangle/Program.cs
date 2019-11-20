using System;

namespace _363_MaxSumOfRectangle
{
    public class Solution
    {
        public int MaxSumSubmatrix(int[][] matrix, int k)
        {
            var tmpArray = new int[matrix.Length];
            int maxSum = int.MinValue;
            for (int l = 0; l < matrix[0].Length; l++)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    tmpArray[i] = 0;
                }

                for (int r = l; r < matrix[0].Length; r++)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        tmpArray[i] += matrix[i][r];
                    }

                    var curSum = BestCumulativeSum(tmpArray, k);
                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        if (maxSum == k)
                        {
                            return maxSum;
                        }
                    }
                }
            }

            return maxSum;
        }

        public int BestCumulativeSum(int[] arr, int k)
        {
            var prefixSum = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + arr[i];
            }
        }

        public int BSearch(int[] prefixSum, int k)
        {
            int ans = -1;

            int left = 1;
            int right = prefixSum.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                int i;
                for (i = mid; i < prefixSum.Length; i++)
                {
                    if (prefixSum[i] - prefixSum[i - mid] > k)
                    {
                        break;
                    }
                }

            }
        }
    }

    class Program
    {



        static void Main(string[] args)
        {
            /*int[][] matrix = {
                new [] {1, 0, 1},
                new [] {0, -2, 3}
            };*/

            /*int[][] matrix = {
                new [] {2, 2, -1}
            };*/

            int[][] matrix = {
                new [] {5, -4, -3, 4},
                new [] {-3, -4, 4, 5},
                new [] {5, 1, 5, -4}
            };

            var sln = new Solution();

            Console.Write(sln.BestCumulativeSum(new [] {-4,-4, 1}, 8));
            Console.Read();
            Console.WriteLine(sln.MaxSumSubmatrix(matrix, 8));
        }
    }
}
