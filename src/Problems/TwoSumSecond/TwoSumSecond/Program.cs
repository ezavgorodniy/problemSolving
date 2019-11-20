using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSumSecond
{
    public class Solution
    {
        private int SmartBinarySearch(int[] numbers, int begin, int target)
        {
            var left = begin;
            var right = numbers.Length - 1;
            while (left <= right)
            {
                if (numbers[left] > target)
                {
                    return -1;
                }

                var m = (left + right) / 2;
                if (numbers[m] == target)
                {
                    return m;
                }
                if (numbers[m] > target)

                {
                    right = m - 1;

                }

                if (numbers[m] < target)
                {
                    left = m + 1;
                }
            }

            return -1;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > target)
                {
                    return new int[0];
                }
                var findedElement = SmartBinarySearch(numbers, i + 1, target - numbers[i]);
                if (findedElement != -1)
                {
                    return new int[] { i + 1, findedElement + 1 };
                }
            }
            return new int[0];

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.TwoSum(new int[] {2,7,11,15}, 9 ));
        }
    }
}
