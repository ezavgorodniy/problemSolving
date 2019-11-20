using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _518_CoinChange
{
    public class Solution
    {
        public int Change(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= amount; j++)
                {
                    dp[j] += dp[j - coins[i]];
                }
            }
            return dp[amount];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.Change(5, new[] {1, 2, 5}));
        }
    }
}
