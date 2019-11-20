using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _494_TargetSun
{
    public class Solution
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            var prevWays = new Dictionary<int, int>();
            prevWays.Add(0, 1);
            foreach (var num in nums)
            {
                var curWays = new Dictionary<int, int>();
                foreach (var kvp in prevWays)
                {
                    var plusValue = kvp.Key + num;
                    if (!curWays.ContainsKey(plusValue))
                    {
                        curWays.Add(plusValue, kvp.Value);
                    }
                    else
                    {
                        curWays[plusValue] += kvp.Value;
                    }

                    var minusValue = kvp.Value - num;
                    if (!curWays.ContainsKey(minusValue))
                    {
                        curWays.Add(minusValue, kvp.Value);
                    }
                    else
                    {
                        curWays[minusValue] += kvp.Value;
                    }
                }

                prevWays = curWays;
            }
            return prevWays.ContainsKey(S) ? prevWays[S] : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.FindTargetSumWays(new int[] { 1, 1,1,1,1}, 3));
        }
    }
}
