using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCostClimbingStairs
{
    public class Solution
    {
        public void FillSteps(int curStart, int curCost, int[] cost, int[] currentCosts)
        {
            if (currentCosts[curStart] != -1)
            {
                if (curCost >= currentCosts[curStart])
                {
                    // we already visited this step with better solution;
                    return;
                }
            }
            currentCosts[curStart] = curCost;


            if (curStart == currentCosts.Length - 1 || curStart == currentCosts.Length - 2)
            {
                // we're at the end
                if (curCost < currentCosts[curStart] || currentCosts[curStart] == -1)
                {
                    currentCosts[curStart] = curCost;
                }

                return;
            }

            // it's more greedy algo to climb 2 steps first
            if (curStart + 2 < currentCosts.Length)
            {
                FillSteps(curStart + 2, curCost + cost[curStart + 2], cost, currentCosts); // climb 2 steps
            }
            FillSteps(curStart + 1, curCost + cost[curStart + 1], cost, currentCosts); // climb 1 step
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            var currentCosts = new int[cost.Length];
            for (int i = 0; i < cost.Length; i++)
            {
                currentCosts[i] = -1;
            }

            if (cost.Length == 0)
            {
                return 0;
            }
            if (cost.Length == 1)
            {
                return cost[0];
            }

            FillSteps(0, cost[0], cost, currentCosts);
            FillSteps(1, cost[1], cost, currentCosts);

            return Math.Min(currentCosts[cost.Length - 1], currentCosts[cost.Length - 2]) ;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var costs = new [] { 10, 15, 20 };
            var solution = new Solution();
            Console.WriteLine(solution.MinCostClimbingStairs(costs));
        }
    }
}
