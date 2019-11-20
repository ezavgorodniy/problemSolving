using System;
using System.Collections.Generic;

namespace BusSchedule
{
    class Route
    {
        public int Start { get; }
        public int End { get; }
        public int Interval { get; }
        public int Length { get; }

        public Route(int start, int end, int interval, int length)
        {
            Start = start;
            End = end;
            Interval = interval;
            Length = length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinTripTime(new []
            {
                new Route(0, 10, 4, 9), 
                new Route(5, 10, 2, 4), 
                new Route(10, 20, 1, 5), 
                new Route(0, 5, 1, 3) 
            }, 20));
        }

        private static void AddEdge(Dictionary<int, List<Route>> dictionary, int station, Route route)
        {
            if (!dictionary.ContainsKey(station))
            {
                dictionary.Add(station, new List<Route>(new[] { route }));
            }
            else
            {
                dictionary[station].Add(route);
            }
        }

        private static Dictionary<int, List<Route>> GetEdgesList(ICollection<Route> routes)
        {
            var result = new Dictionary<int, List<Route>>();
            foreach (var route in routes)
            {
                AddEdge(result, route.Start, route);
                AddEdge(result, route.End, route);
            }
            return result;
        }

        public static int MinTripTime(ICollection<Route> routes, int destination)
        {
            var routesDictionary = GetEdgesList(routes); 
            return MinTripTime(routesDictionary, 0, destination); 
        }

        private static int MinTripTime(Dictionary<int, List<Route>> edges, int start, int end)
        {
            var results = new Dictionary<int, int> {{start, 0}};

            bool foundOptimization;
            var currentStations = new List<int>(new []{0});
            do
            {
                foundOptimization = false;

                var prevCurrentStations = currentStations.ToArray();
                currentStations.Clear();
                foreach (var station in prevCurrentStations)
                {
                    var currentTime = results[station];
                    var routes = edges[station];
                    foreach (var route in routes)
                    {
                        var nextBusTime = currentTime + currentTime % route.Interval;
                        var timeCandidate = nextBusTime + route.Length;
                        var stationNumber = station == route.Start ? route.End : route.Start;
                        var betterSolution = false;

                        if (!results.ContainsKey(stationNumber))
                        {
                            betterSolution = true;
                        }
                        else if (results[stationNumber] > timeCandidate)
                        {
                            betterSolution = true;
                        }

                        if (betterSolution)
                        {
                            results[stationNumber] = timeCandidate;
                            foundOptimization = true;
                            currentStations.Add(stationNumber);
                        }
                    }
                }
            } while (foundOptimization);

            return results.ContainsKey(end) ? results[end] : -1;
        }
    }
}
