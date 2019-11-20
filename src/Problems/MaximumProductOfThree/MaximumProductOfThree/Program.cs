using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumProductOfThree
{
    public class Solution
    {
        private void AdjustThreeItems(int number, ref int firstBiggestNumber, ref int secondBiggestNumber, ref int thirdBiggestNumber, Func<int, int, bool> predicate)
        {
            if (predicate(number, firstBiggestNumber))
            {
                thirdBiggestNumber = secondBiggestNumber;
                secondBiggestNumber = firstBiggestNumber;
                firstBiggestNumber = number;
            }
            else if (predicate(number, secondBiggestNumber))
            {
                thirdBiggestNumber = secondBiggestNumber;
                secondBiggestNumber = number;
            }
            else if (predicate(number, thirdBiggestNumber))
            {
                thirdBiggestNumber = number;
            }

        }

        public int MaximumProduct(int[] nums)
        {
            int firstBiggestNumber = int.MinValue;
            int secondBiggestNumber = int.MinValue;
            int thirdBiggestNumber = int.MinValue;

            int firstSmallestNumber = int.MaxValue;
            int secondSmallestNumber = int.MaxValue;
            int thirdSmallestNumber = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                AdjustThreeItems(nums[i], ref firstBiggestNumber, ref secondBiggestNumber, ref thirdBiggestNumber, (number, a) => number > a);
                AdjustThreeItems(nums[i], ref firstSmallestNumber, ref secondSmallestNumber, ref thirdSmallestNumber, (number, a) => number < a);
            }

            return Math.Max(firstBiggestNumber * secondBiggestNumber * thirdBiggestNumber, firstBiggestNumber * firstSmallestNumber * secondSmallestNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.MaximumProduct(new int[] {-1, -2, -3, -4}));
        }
    }
}
