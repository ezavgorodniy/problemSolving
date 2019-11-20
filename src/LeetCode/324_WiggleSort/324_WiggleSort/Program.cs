using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _324_WiggleSort
{
    class Solution
    {
        public void WiggleSort(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length / 2; ++i)
            {
                int temp = nums[i];
                nums[i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = temp;
            }
            int[] arr = new int[nums.Length];
            Array.Copy(nums, arr, nums.Length);

            int j = 0;
            for (int i = 1; i < nums.Length; i += 2)
            {
                nums[i] = arr[j];
                ++j;
            }
            for (int i = 0; i < nums.Length; i += 2)
            {
                nums[i] = arr[j];
                ++j;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var arr = new [] {1, 5, 1, 1, 6, 4};
            sln.WiggleSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
        }
    }
}
