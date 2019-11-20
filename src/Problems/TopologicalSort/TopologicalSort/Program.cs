using System;
using System.Collections;
using System.Collections.Generic;

namespace TopologicalSort
{
    // This class represents a directed graph using adjacency 
    // list representation 
    /*class Graph
    {
        // A recursive function used by topologicalSort 
        void topologicalSortUtil(int v, boolean visited[],
                                 Stack stack)
        {
            // Mark the current node as visited. 
            visited[v] = true;
            Integer i;

            // Recur for all the vertices adjacent to this 
            // vertex 
            Iterator<Integer> it = adj[v].iterator();
            while (it.hasNext())
            {
                i = it.next();
                if (!visited[i])
                    topologicalSortUtil(i, visited, stack);
            }

            // Push current vertex to stack which stores result 
            stack.push(new Integer(v));
        }

        // The function to do Topological Sort. It uses 
        // recursive topologicalSortUtil() 
        void topologicalSort()
        {
            Stack stack = new Stack();

            // Mark all the vertices as not visited 
            boolean visited[] = new boolean[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;

            // Call the recursive helper function to store 
            // Topological Sort starting from all vertices 
            // one by one 
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    topologicalSortUtil(i, visited, stack);

            // Print contents of stack 
            while (stack.empty() == false)
                System.out.print(stack.pop() + " ");
        }

        // Driver method 
        public static void main(String args[])
        {
            // Create a graph given in the above diagram 
            Graph g = new Graph(6);
            g.addEdge(5, 2);
            g.addEdge(5, 0);
            g.addEdge(4, 0);
            g.addEdge(4, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 1);

            System.out.println("Following is a Topological " +
                               "sort of the given graph");
            g.topologicalSort();
        }
    }*/
    // This code is contributed by Aakash Hasija 

    public class Graph
    {
        private readonly int _numberOfVertex;
        private readonly LinkedList<int>[] _adjacencyList;

        public Graph(int numberOfVertex)
        {
            _numberOfVertex = numberOfVertex;

            _adjacencyList = new LinkedList<int>[numberOfVertex];
            for (int i = 0; i < _numberOfVertex; i++)
            {
                _adjacencyList[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int i, int j)
        {
            _adjacencyList[i].AddFirst(new LinkedListNode<int>(j));
        }

        public Stack<int> TopologicalSort()
        {
            var stack = new Stack<int>();

            // Mark all the vertices as not visited 
            var visited = new bool[_numberOfVertex];
            for (int i = 0; i < _numberOfVertex; i++)
            {
                visited[i] = false;
            }

            // Call the recursive helper function to store 
            // Topological Sort starting from all vertices 
            // one by one 
            for (int i = 0; i < _numberOfVertex; i++)
            {
                if (visited[i] == false)
                {
                    TopologicalSortUtil(i, visited, stack);
                }
            }

            return stack;
        }


        // A recursive function used by topologicalSort 
        private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {
            // Mark the current node as visited. 
            visited[v] = true;


            // Recur for all the vertices adjacent to this 
            // vertex 
            foreach (var node in stack)
            {
                if (!visited[node])
                {
                    TopologicalSortUtil(node, visited, stack);
                }
            }

            // Push current vertex to stack which stores result 
            stack.Push(v);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);


            Console.WriteLine("Following is a Topological " +
                              "sort of the given graph");
            var stack = g.TopologicalSort();
            while (stack.TryPop(out var result))
            {
                Console.Write(result + " ");
            }
        }
    }
}
