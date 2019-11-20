using System;

namespace CourseSchedule
{
    public class Solution
    {
        private bool IsCyclicUtil(int i, bool[] visited, bool[] recStack, int[,] edges)
        {
            if (recStack[i])
            {
                return true;
            }
            if (visited[i])
            {
                return false;
            }

            visited[i] = true;
            recStack[i] = true;

            for (int edgeNum = 0; edgeNum < edges.Length / 2; edgeNum++)
            {
                if (edges[edgeNum, 0] == i)
                {
                    if (IsCyclicUtil(edges[edgeNum, 1], visited, recStack, edges))
                    {
                        return true;
                    }
                }
            }

            recStack[i] = false;
            return false;
        }

        private bool IsCyclic(int numCourses, int[,] edges)
        {
            var visited = new bool[numCourses];
            var recStack = new bool[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                if (IsCyclicUtil(i, visited, recStack, edges))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            return !IsCyclic(numCourses, prerequisites);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.CanFinish(4, new int[,] {{0, 1}, { 1, 2 }, { 0, 2 }, { 2, 3 } }));
        }
    }
}
