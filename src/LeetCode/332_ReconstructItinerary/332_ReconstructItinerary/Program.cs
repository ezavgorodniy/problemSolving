using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _332_ReconstructItinerary
{
    public class Solution
    {
        private const string StartAirport = "JFK";

        private List<string> FindItinerary(IList<IList<string>> tickets, bool[] visited, string curAirport,
            List<string> curPath)
        {
            if (visited.All(t => t))
            {
                return curPath;
            }

            for (int i = 0; i < tickets.Count; i++)
            {
                if (!visited[i] && tickets[i][0] == curAirport)
                {
                    visited[i] = true;
                    curPath.Add(tickets[i][1]);

                    var potentialResult = FindItinerary(tickets, visited, tickets[i][1], curPath);
                    if (potentialResult != null)
                    {
                        return potentialResult;
                    }

                    curPath.RemoveAt(curPath.Count - 1);
                    visited[i] = false;
                }
            }

            return null;
        }

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            return FindItinerary(tickets.OrderBy(ticket => ticket[1]).ToList(), new bool[tickets.Count], StartAirport,
                new List<string>(new[] {StartAirport}));

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tickets = new List<IList<string>>
            {
                new List<string> {"JFK", "SFO"},
                new List<string> {"JFK", "ATL"},
                new List<string> {"SFO", "ATL"},
                new List<string> {"ATL", "JFK"},
                new List<string> {"ATL", "SFO"}
            };

            var sln= new Solution();
            var itinerary = sln.FindItinerary(tickets);
            foreach (var airport in itinerary)
            {
                Console.Write("{0} ", airport);
            }
        }
    }
}
