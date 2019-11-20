using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _228_SummaryRanges
{
    public class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            var result = new List<string>();
            if (nums.Length == 0)
            {
                return result;
            }
            int l = 0, r = 1;
            while (r < nums.Length)
            {
                while (r < nums.Length && nums[r] == nums[r - 1] + 1)
                {
                    r++;
                }


                if (l == r - 1)
                {
                    result.Add(nums[l].ToString());
                }
                else
                {
                    result.Add($"{nums[l]}->{nums[r - 1]}");
                }

                l = r;
                r++;
            }
            if (l < nums.Length)
            {
                result.Add(nums[l].ToString());
            }

            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var result = sln.SummaryRanges(new[] {0, 2, 4, 6, 8, 10, 12});
            foreach (var range in result)
            {
                Console.WriteLine(range);
            }
        }
    }
}
