using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _886_Bipartition
{
    public class Solution
    {
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            var groups = new int[N + 1];
            var visitedNodes = new bool[N + 1];
            var visitedEdges = new bool[dislikes.Length];
            for (int i = 0; i < dislikes.Length; i++)
            {
                if (visitedEdges[i])
                {
                    continue;
                }

                visitedEdges[i] = true;
                groups[dislikes[i][0]] = 1;
                groups[dislikes[i][1]] = 2;

                var queue = new Queue<int>();
                queue.Enqueue(dislikes[i][0]);
                queue.Enqueue(dislikes[i][1]);

                while (queue.Count != 0)
                {
                    var curVertex = queue.Dequeue();
                    if (visitedNodes[curVertex])
                    {
                        continue;
                    }
                    visitedNodes[curVertex] = true;

                    for (int j = 0; j < dislikes.Length; j++)
                    {
                        if (visitedEdges[j])
                        {
                            continue;
                        }

                        if (dislikes[j][0] == curVertex || dislikes[j][1] == curVertex)
                        {
                            var anotherVertex = dislikes[j][0] == curVertex ? dislikes[j][1] : dislikes[j][0];
                            if (groups[anotherVertex] == 0)
                            {
                                groups[anotherVertex] = groups[curVertex] == 1 ? 2 : 1;
                            }
                            else if (groups[anotherVertex] == groups[curVertex])
                            {
                                return false;
                            }

                            visitedEdges[j] = true;
                            queue.Enqueue(anotherVertex);
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
            var sln = new Solution();
            Console.WriteLine(sln.PossibleBipartition(3, new[]
            {
                new[] {1, 2},
                new[] {1, 3},
                new[] {2, 3}
            }));
        }
    }
}
