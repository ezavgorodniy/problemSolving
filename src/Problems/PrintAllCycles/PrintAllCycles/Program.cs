using System;
using System.Collections.Generic;

namespace PrintAllCycles
{
    class Program
    {

        const int N = 100000;
        private static List<int>[] graph = new List<int>[N];
        private static List<int>[] cycles = new List<int>[N];

        // Function to mark the vertex with 
        // different colors for different cycles 
        private static void dfs_cycle(int u, int p, int[] color, int[] mark, int[] par, ref int cyclenumber)
        {

            // already (completely) visited vertex. 
            if (color[u] == 2)
            {
                return;
            }

            // seen vertex, but was not completely visited -> cycle detected. 
            // backtrack based on parents to find the complete cycle. 
            if (color[u] == 1)
            {

                cyclenumber++;
                int cur = p;
                mark[cur] = cyclenumber;

                // backtrack the vertex which are 
                // in the current cycle thats found 
                while (cur != u)
                {
                    cur = par[cur];
                    mark[cur] = cyclenumber;
                }
                return;
            }
            par[u] = p;

            // partially visited. 
            color[u] = 1;

            // simple dfs on graph 
            foreach (int v in graph[u])
            {

                // if it has not been visited previously 
                if (v == par[u])
                {
                    continue;
                }
                dfs_cycle(v, u, color, mark, par, ref cyclenumber);
            }

            // completely visited. 
            color[u] = 2;
        }

        // add the edges to the graph 
        private static void addEdge(int u, int v)
        {
            graph[u].Add(v);
            graph[v].Add(u);
        }

        // Function to print the cycles 
        private static void printCycles(int edges, int[] mark, ref int cyclenumber)
        {

            // push the edges that into the 
            // cycle adjacency list 
            for (int i = 1; i <= edges; i++)
            {
                if (mark[i] != 0)
                {
                    cycles[mark[i]].Add(i);
                }
            }

            // print all the vertex with same cycle 
            for (int i = 1; i <= cyclenumber; i++)
            {
                Console.WriteLine("Cycle Number {0}", i);
                foreach (var x in cycles[i])
                {
                    Console.Write("{0} ", x);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < N; i++)
            {
                graph[i] = new List<int>();
                cycles[i] = new List<int>();
            }

            // add edges 
            addEdge(1, 2);
            addEdge(2, 3);
            addEdge(3, 4);
            addEdge(4, 6);
            addEdge(4, 7);
            addEdge(5, 6);
            addEdge(3, 5);
            addEdge(7, 8);
            addEdge(6, 10);
            addEdge(5, 9);
            addEdge(10, 11);
            addEdge(11, 12);
            addEdge(11, 13);
            addEdge(12, 13);

            // arrays required to color the 
            // graph, store the parent of node 
            int[] color = new int[N];
            int[] par = new int[N];

            // mark with unique numbers 
            int[] mark = new int[N];

            // store the numbers of cycle 
            int cyclenumber = 0;
            int edges = 13;

            // call DFS to mark the cycles 
            dfs_cycle(1, 0, color, mark, par, ref cyclenumber);

            // function to print the cycles 
            printCycles(edges, mark, ref cyclenumber);
        }
    }
}
