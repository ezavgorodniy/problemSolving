using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMaximumNumber
{
    public class Solution
    {
        public int ThirdMax(int[] nums)
        {
            int[] maximalNumbers = new int[] { int.MinValue, int.MinValue, int.MinValue };

            int countMaximalNumbersAdded = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maximalNumbers[0])
                {
                    maximalNumbers[2] = maximalNumbers[1];
                    maximalNumbers[1] = maximalNumbers[0];
                    maximalNumbers[0] = nums[i];
                    countMaximalNumbersAdded++;
                }
                else if (nums[i] > maximalNumbers[1] && nums[i] != maximalNumbers[0])
                {
                    maximalNumbers[2] = maximalNumbers[1];
                    maximalNumbers[1] = nums[i];
                    countMaximalNumbersAdded++;
                }
                else if (nums[i] > maximalNumbers[2] && nums[i] != maximalNumbers[0] && nums[i] != maximalNumbers[1])
                {
                    maximalNumbers[2] = nums[i];
                    countMaximalNumbersAdded++;
                }
            }

            return maximalNumbers[countMaximalNumbersAdded >= 3 ? 2 : 0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.ThirdMax(new [] {2, 2, 1, 1, 3}));
        }
    }
}
