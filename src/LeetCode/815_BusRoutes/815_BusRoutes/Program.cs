using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _815_BusRoutes
{

    public class Solution
    {
        private Dictionary<int, HashSet<int>> StationToRoute(int[][] routes)
        {
            var result = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < routes.Length; i++)
            {
                var route = routes[i];
                foreach (var station in route)
                {
                    if (!result.ContainsKey(station))
                    {
                        result.Add(station, new HashSet<int>());
                    }

                    result[station].Add(i);
                }

            }

            return result;

        }


        public int NumBusesToDestination(int[][] routes, int S, int T)
        {
            var stationToRoute = StationToRoute(routes);
            HashSet<int> visitedRoutes = new HashSet<int>();
            HashSet<int> visitedStops = new HashSet<int>();
            visitedStops.Add(S);
            var queue = new Queue<int>();
            int count = 0;
            while (queue.Count != 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var curStation = queue.Dequeue();
                    if (curStation == T)
                    {
                        return count;
                    }

                    foreach (var routeNumber in stationToRoute[curStation])
                    {
                        if (visitedRoutes.Contains(routeNumber))
                        {
                            continue;
                        }
                        foreach (var station in routes[routeNumber])
                        {
                            if (visitedStops.Contains(station))
                            {
                                continue;
                            }
                            visitedStops.Add(station);
                            queue.Enqueue(station);
                        }
                        visitedRoutes.Add(routeNumber);
                    }
                }
                count++;
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.NumBusesToDestination(new []
            {
                new []{1,2,7},
                new []{3,6,7},
            }, 1, 6));
        }
    }
}
