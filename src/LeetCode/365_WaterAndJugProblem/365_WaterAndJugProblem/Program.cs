using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365_WaterAndJugProblem
{
    public class Solution
    {
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (x == 0 && y == 0)
            {
                return z == 0;
            }
            if (x == 0)
            {
                return z % y == 0;
            }
            if (y == 0)
            {
                return z % x == 0;
            }
            if (x == y)
            {
                return z % x == 0;
            }

            var visited = new Dictionary<int, bool>();

            int step1 = x;
            int step2 = y;
            int step3 = (x < y) ? y - x : x - y;

            var queue = new Queue<int>();
            queue.Enqueue(0);
            visited.Add(0, true);
            var minimalAddedValue = 0;
            while (queue.Count != 0)
            {
                var newValue = queue.Dequeue();
                if (AddValueHelper(newValue + step1, visited, queue, z))
                {
                    return true;
                }
                if (AddValueHelper(newValue + step2, visited, queue, z))
                {
                    return true;
                }
                if (AddValueHelper(newValue + step3, visited, queue, z))
                {
                    return true;
                }
            }

            return false;
        }

        private bool AddValueHelper(int newValue, Dictionary<int, bool> visited, Queue<int> queue, int z)
        {
            if (newValue == z)
            {
                return true;
            }

            if (visited.ContainsKey(newValue))
            {
                return false;
            }

            if (newValue > z)
            {
                return false;
            }

            visited.Add(newValue, true);
            queue.Enqueue(newValue);
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.CanMeasureWater(5,6,34));
        }
    }
}
