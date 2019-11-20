using System;

namespace _34_FirstAndLastPosition
{
    public class Solution
    {
        private int BinarySearch(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;

                if (nums[m] == target)
                {
                    return m;
                }
                if (nums[m] < target)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return -1;
        }

        private int FindStartRange(int[] nums, int targetPosition)
        {
            var target = nums[targetPosition];
            int l = 0;
            int r = targetPosition;
            var range = targetPosition;
            while (l <= r)
            {
                int m = (l + r) / 2;

                if (nums[m] == target)
                {
                    range = m;
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return range;
        }


        private int FindEndRange(int[] nums, int targetPosition)
        {
            var target = nums[targetPosition];
            int l = 0;
            int r = targetPosition;
            var range = targetPosition;
            while (l <= r)
            {
                int m = (l + r) / 2;

                if (nums[m] == target)
                {
                    range = m;
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return range;
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int targetPosition = BinarySearch(nums, target);
            if (targetPosition == -1)
            {
                return new[] { targetPosition, targetPosition };
            }

            var leftRange = FindStartRange(nums, targetPosition);
            var rightRange = FindEndRange(nums, targetPosition);

            return new[] { leftRange, rightRange };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var result = solution.SearchRange(new[] {1, 1, 1, 1, 1, 1, 1, 1, 1}, 1);
            Console.WriteLine($"{result[0]}; {result[1]}");
        }
    }
}
