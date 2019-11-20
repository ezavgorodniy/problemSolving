using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _636_ExclusiveTimeToFunctions
{
    public class Solution
    {
        private class LogDescription
        {
            public int FunctionId { get; set; }

            public int Timestamp { get; set; }

            public bool Start { get; set; }

            public static LogDescription Parse(string log)
            {
                var splitted = log.Split(':');
                return new LogDescription
                {
                    FunctionId = int.Parse(splitted[0]),
                    Start = splitted[1] == "start",
                    Timestamp = int.Parse(splitted[2]),
                };
            }
        }

        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.ToList();

            var result = new int[n];
            var startedLogs = new Stack<LogDescription>();
            int lastTimeStamp = 0;

            foreach (var log in logs.Select(LogDescription.Parse))
            {
                if (startedLogs.Count != 0)
                {
                    var lastStarted = startedLogs.Peek();
                    result[lastStarted.FunctionId] += log.Timestamp - lastTimeStamp;
                }

                lastTimeStamp = log.Timestamp;
                if (log.Start)
                {
                    startedLogs.Push(log);
                }
                else if (startedLogs.Count != 0)
                {
                    var finished = startedLogs.Pop();
                    result[finished.FunctionId]++;
                    lastTimeStamp++;
                }
            }

            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            foreach (var time in sln.ExclusiveTime(2, new[] {"0:start:0", "1:start:2", "1:end:5", "0:end:6"}))
            {
                Console.Write($"{time} ");
            }
        }
    }
}
