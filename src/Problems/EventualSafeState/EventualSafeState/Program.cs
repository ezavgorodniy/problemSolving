using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventualSafeState
{
    public class Solution
    {
        private bool DFS(int node, int[] colors, int[][] graph)
        {
            if (colors[node] > 0)
            {
                return colors[node] == 2;
            }

            colors[node] = 1;
            foreach (var child in graph[node])
            {
                if (colors[node] == 2)
                {
                    continue;
                }
                if (colors[child] == 1 || !DFS(child, colors, graph))
                {
                    return false;
                }
            }

            colors[node] = 2;
            return true;
        }

        public IList<int> EventualSafeNodes(int[][] graph)
        {
            var colors = new int[graph.Length];
            var result = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (DFS(i, colors, graph))
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var result = solution.EventualSafeNodes(new int[][]
            {
                new int[] {1, 2},
                new int[] {2, 3},
                new int[] {5},
                new int[] {0},
                new int[] {5},
                new int[0],
                new int[0]
            });
        }
    }
}
