using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _403_FrogJump
{
    public class Solution
    {
        private void Jump(int curStone, int curK, Dictionary<int, HashSet<int>> visited, HashSet<int> stones, int target)
        {
            if (curK <= 0)
            {
                return;
            }

            if (visited.ContainsKey(curStone))
            {
                var visitedKCollection = visited[curStone];
                if (visitedKCollection.Contains(curK))
                {
                    return;
                }

                visitedKCollection.Add(curK);
            }
            else
            {
                visited.Add(curStone, new HashSet<int> { curK });
            }

            if (curStone >= target)
            {
                return;
            }

            if (stones.Contains(curStone + curK - 1))
            {
                Jump(curStone + curK - 1, curK - 1, visited, stones, target);
            }

            if (stones.Contains(curStone + curK))
            {
                Jump(curStone + curK, curK, visited, stones, target);
            }

            if (stones.Contains(curStone + curK + 1))
            {
                Jump(curStone + curK + 1, curK + 1, visited, stones, target);
            }
        }

        public bool CanCross(int[] stones)
        {
            Dictionary<int, HashSet<int>> visited = new Dictionary<int, HashSet<int>>();
            HashSet<int> stonesHash = new HashSet<int>();
            for (int i = 0; i < stones.Length; i++)
            {
                stonesHash.Add(stones[i]);
            }
            Jump(stones[0], 1, visited, stonesHash, stones[stones.Length - 1]);

            return visited.ContainsKey(stones[stones.Length - 1]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.CanCross(new []{0,2}));
        }
    }
}
