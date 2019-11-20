using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_LongestIncreasingSubsequence
{
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            if (n <= 1)
            {
                return n;
            }

            int[] t = new int[n];
            t[0] = 0;
            int len = 0;
            for (int i = 1; i < n; i++)
            {
                if (nums[t[0]] > nums[i])
                {
                    t[0] = i;
                }
                else if (nums[t[len]] < nums[i])
                {
                    len++;
                    t[len] = i;
                }
                else
                {
                    int index = CeilIndex(nums, t, len, nums[i]);
                    t[index] = i;
                }
            }
            return len + 1;
        }


        private int CeilIndex(int[] nums, int[] t, int end, int s)
        {
            int start = 0;
            int middle;
            int len = end;
            while (start <= end)
            {
                middle = (start + end) / 2;
                if (middle < len && nums[t[middle]] < s && s <= nums[t[middle + 1]])
                {
                    return middle + 1;
                }
                else if (nums[t[middle]] < s)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            sln.LengthOfLIS(new[] {2, 2});
        }
    }
}
