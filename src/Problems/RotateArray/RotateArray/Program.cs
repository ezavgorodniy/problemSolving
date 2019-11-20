using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            Reverse(nums, 0, n - 1);
            /*Reverse(nums, 0, k - 1);
            Reverse(nums, k, n - 1);*/
        }

        public void Reverse(int[] nums, int start, int end)
        {
            while (start >= end)
            {
                Swap(nums, start, end);
                start++;
                end--;
            }
        }

        public void Swap(int[] nums, int l, int r)
        {
            int tmp = nums[r];
            nums[r] = nums[l];
            nums[l] = tmp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.Rotate(new[] {1, 2, 3, 4, 5, 6, 7}, 4);
        }
    }
}
