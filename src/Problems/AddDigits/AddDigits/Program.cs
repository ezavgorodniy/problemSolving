using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddDigits
{
    public class Solution
    {
        public int AddDigits(int num)
        {
            var result = 0;
            while (num >= 10)
            {
                var currentResult = 0;
                while (num != 0)
                {
                    currentResult += num % 10;
                    num /= 10;
                }
                num = currentResult;
                result += currentResult;
            }
            result += num;

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.AddDigits(38));
        }
    }
}
