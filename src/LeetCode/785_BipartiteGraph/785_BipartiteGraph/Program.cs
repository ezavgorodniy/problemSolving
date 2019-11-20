using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _785_BipartiteGraph
{
    public class Solution
    {
        public bool IsBipartite(int[][] graph)
        {
            var vertexes = new int[graph.Length];
            vertexes[0] = 1;

            var queue = new Queue<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                if (vertexes[i] != 0)
                {
                    queue.Enqueue(i);
                }

                while (queue.Count != 0)
                {
                    var vertex = queue.Dequeue();
                    var currentVertexColor = vertexes[vertex];
                    var expectedOppositeVertexColor = currentVertexColor == 1 ? 2 : 1;
                    foreach (var adjacentNode in graph[vertex])
                    {
                        if (vertexes[adjacentNode] == 0)
                        {
                            queue.Enqueue(adjacentNode);
                            vertexes[adjacentNode] = expectedOppositeVertexColor;
                        }
                        else if (vertexes[adjacentNode] != expectedOppositeVertexColor)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var graph = new[]
            {
                new int[0],
                new[] {2, 4, 6},
                new[] {1, 4, 8, 9},
                new[] {7, 8},
                new[] {1, 2, 8, 9},
                new[] {6, 9},
                new[] {1, 5, 7, 8, 9},
                new[] {3, 6, 9},
                new[] {2, 3, 4, 6, 9},
                new[] {2, 4, 5, 6, 7, 8}
            };

            var sln = new Solution();
            sln.IsBipartite(graph);
        }
    }
}
