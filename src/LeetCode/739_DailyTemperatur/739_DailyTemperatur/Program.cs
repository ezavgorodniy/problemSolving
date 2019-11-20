using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _739_DailyTemperatur
{
    public class Solution
    {
        private class Temperature
        {
            public int Temp { get; set; }
            public int Day { get; set; }
        }

        public int[] DailyTemperatures(int[] T)
        {
            var result = new int[T.Length];
            var stack = new Stack<Temperature>();
            for (int i = result.Length - 1; i >= 0; i--)
            {
                var curTemp = result[i];
                while (stack.Count != 0 && stack.Peek().Temp <= curTemp)
                {
                    stack.Pop();
                }

                result[i] = stack.Count != 0 ? stack.Peek().Day - i : 0;
                stack.Push(new Temperature
                {
                    Temp = curTemp,
                    Day = i
                });
            }
            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
             var sln = new Solution();
            sln.DailyTemperatures(new[] {73, 74, 75, 71, 69, 72, 76, 73});
        }
    }
}
