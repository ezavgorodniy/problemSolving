using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _209_MinimumSizeSubarraySum
{
    public class Solution
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i - 1] + nums[i];
            }

            int l = 0;
            int r = 0;
            int result = int.MaxValue;
            while (r < nums.Length && nums[r] < s)
            {
                r++;
            }

            if (r < nums.Length)
            {
                result = r + 1;
            }

            l++;
            while (r < nums.Length)
            {
                while (l <= r && nums[r] - nums[l - 1] >= s)
                {
                    var curSize = r - l + 1;
                    if (curSize < result)
                    {
                        result = curSize;
                        if (result == 1)
                        {
                            return result;
                        }
                    }

                    l++;
                }

                while (r < nums.Length && nums[r] - nums[l - 1] < s)
                {
                    r++;
                }

                if (r < nums.Length)
                {
                    var curSize = r - l + 1;
                    if (curSize < result)
                    {
                        result = curSize;
                        if (result == 1)
                        {
                            return result;
                        }
                    }
                    result = r;
                }
            }


            if (result == int.MaxValue)
            {
                return 0;
            }
            else
            {
                return result;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            sln.MinSubArrayLen(15, new[] {5, 1, 3, 5, 10, 7, 4, 9, 2, 8});
        }
    }
}
