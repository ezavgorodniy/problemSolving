using System;

namespace _787_CheapestFlight
{
    public class Solution
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var cost = new int[n];
            for (int i = 0; i < cost.Length; i++)
            {
                cost[i] = int.MaxValue;
            }
            cost[src] = 0;

            int result = cost[dst];
            while (K >= 0)
            {
                var cur = new int[n];
                for (int i = 0; i < cost.Length; i++)
                {
                    cur[i] = int.MaxValue;
                }

                foreach (var flight in flights)
                {
                    if (cost[flight[0]] != int.MaxValue)
                    {
                        cur[flight[1]] = Math.Min(cur[flight[1]], cost[flight[0]] + flight[2]);
                    }
                }

                cost = cur;
                result = Math.Min(result, cost[src]);

                K--;
            }

            return result == int.MaxValue ? -1 : result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.FindCheapestPrice(3,
                new []
                {
                    new [] {0,1,100},
                    new [] {1,2,100},
                    new [] {0,2,500}
                }, 0, 2, 1));

            /*3
[[0,1,100],[1,2,100],[0,2,500]]
0
2
1*/
        }
    }
}
