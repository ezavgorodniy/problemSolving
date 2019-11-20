using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _310_MinHeightTrees
{

    public class Solution
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            var edgeList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                edgeList[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                edgeList[edge[0]].Add(edge[1]);
                edgeList[edge[1]].Add(edge[0]);
            }

            var prev = new int[n];
            for (int i = 0; i < n; i++)
            {
                prev[i] = -1;
            }

            int p0 = BFS(edgeList, 0, prev);

            prev = new int[n];
            for (int i = 0; i < n; i++)
            {
                prev[i] = -1;
            }

            int p1 = BFS(edgeList, p0, prev);

            var path = new List<int>();
            for (int i = p1; i != p0; i = prev[i])
            {
                path.Add(i);
            }
            path.Add(p0);

            var res = new List<int>();
            res.Add(path[path.Count / 2]);
            if (path.Count % 2 == 0)
            {
                res.Add(path[path.Count / 2 - 1]);
            }
            return res;
        }

        private int BFS(List<int>[] edgeList, int start, int[] prev)
        {
            var q = new Queue<int>();
            q.Enqueue(start);
            prev[start] = start;
            int ret = start;
            while (q.Count != 0)
            {
                ret = q.Dequeue();
                foreach (var i in edgeList[ret])
                {
                    if (prev[i] == -1)
                    {
                        q.Enqueue(i);
                        prev[i] = ret;
                    }
                }
            }
            return ret;
        }
    }

    /*public List<Integer> findMinHeightTrees(int n, int[][] edges) {
    List<Integer>[] edgeList = new List[n];
    for (int i = 0; i < n; i++){
        edgeList[i] = new ArrayList<>();
    }
    for(int[] edge : edges){
        edgeList[edge[0]].add(edge[1]);
        edgeList[edge[1]].add(edge[0]);
    }
    
    int[] prev = new int[n];
    Arrays.fill(prev, -1);
    int p0 = bfs(edgeList, 0, prev);

    prev = new int[n];
    Arrays.fill(prev, -1);
    int p1 = bfs(edgeList, p0, prev);
    
    List<Integer> path = new ArrayList<>();
    int i = p1;
    while (i != p0) {
        path.add(i);
        i = prev[i];
    }
    path.add(p0);

    List<Integer> res = new ArrayList<>();
    res.add(path.get(path.size() / 2));
    if (path.size() % 2 == 0) res.add(path.get(path.size() / 2 - 1));
    return res;
}

private int bfs(List<Integer>[] edgeList, int start, int[] prev) {
    Queue<Integer> q = new LinkedList<>();
    q.add(start);
    prev[start] = start;
    int ret = start;
    while (!q.isEmpty()) {
        ret = q.poll();
        for (int i : edgeList[ret]) {
            if (prev[i] == -1) {
                q.add(i);
                prev[i] = ret;
            } 
        }
    }
    return ret;
}*/

    class Program
    {
        static void Main(string[] args)
        {
            Array.Fil
        }
    }
}
