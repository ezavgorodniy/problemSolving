using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerPalindrom
{
    class Program
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            long reverted = 0;
            while (x != 0)
            {
                reverted *= 10;
                reverted += x % 10;

                x /= 10;
            }

            return (reverted == (Int64)x);
        }


        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome(121));
        }
    }
}
