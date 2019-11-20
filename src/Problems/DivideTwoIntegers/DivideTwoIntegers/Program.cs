using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideTwoIntegers
{
    public class Solution
    {
        public int DivideWithoutSign(long dividend, long divisor)
        {
            var result = 0;
            var currentPow = 0;
            var divisor64 = divisor;
            while (divisor64 << currentPow <= dividend)
            {
                currentPow++;
            }

            currentPow--;
            var dividend64 = dividend;
            while (currentPow >= 0 && dividend64 != 0)
            {
                var newResult = dividend64 - (divisor64 << currentPow);
                if (newResult >= 0)
                {
                    dividend64 = newResult;
                    result += 1 << currentPow;
                }

                currentPow--;
            }


            return result;
        }

        public int Divide(int dividend, int divisor)
        {
            if (divisor == 1)
            {
                return dividend;
            }
            if (divisor == -1)
            {
                return (dividend == int.MinValue) ? int.MaxValue : -dividend;
            }
            var plusSign = (dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0);

            var result = DivideWithoutSign(Math.Abs((long)dividend), Math.Abs((long)divisor));
            return plusSign ? result : -result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var newSolution = new Solution();
            Console.WriteLine(newSolution.Divide(-8, 2));
        }
    }
}
