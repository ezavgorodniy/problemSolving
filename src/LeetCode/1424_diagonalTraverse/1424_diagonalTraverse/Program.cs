using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1424_diagonalTraverse
{
    public class Solution
    {

        public int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            if (nums.Count == 0)
            {
                return new int[0];
            }

            int maximalBucketNumber = 0;
            var resultBuckets = new Dictionary<int, LinkedList<int>>();
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums[i].Count; j++)
                {
                    var bucketNumber = i + j;
                    if (bucketNumber > maximalBucketNumber)
                    {
                        maximalBucketNumber = bucketNumber;
                    }

                    if (!resultBuckets.ContainsKey(bucketNumber))
                    {
                        resultBuckets.Add(bucketNumber, new LinkedList<int>());
                    }

                    resultBuckets[bucketNumber].AddLast(nums[i][j]);
                }
            }

            var result = new List<int>();

            for (int bucket = 0; bucket <= maximalBucketNumber; bucket++)
            {
                if (!resultBuckets.ContainsKey(bucket))
                {
                    continue;
                }

                foreach (var value in resultBuckets[bucket])
                {
                    result.Add(value);
                }
            }

            return result.ToArray();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();

            var result = sln.FindDiagonalOrder(new List<IList<int>>
            {
                new List<int> {1, 2, 3},
                new List<int> {4, 5, 6},
                new List<int> {7, 8, 9}
            });

            foreach (var i in result)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
