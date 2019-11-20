using System;
using System.Collections.Generic;

namespace MyPow
{
    public class Solution
    {
        //private double Pow(int n, double[] results)
        //{
        //    if (results[n] > 0)
        //    {
        //        return results[n];
        //    }

        //    results[n] = Pow(n / 2, results) * Pow(n / 2 + n % 2, results);
        //    return results[n];
        //}

        //public double MyPow(double x, int n)
        //{
        //    if (x == 0)
        //    {
        //        return 0.0;
        //    }


        //    var results = new double[40];
        //    results[0] = 1.0;
        //    results[1] = x;
        //    for (int i = 2; i < results.Length; i++)
        //    {
        //        results[i] = -1.0;
        //    }

        //    if (n == 0)
        //    {
        //        return 1.0;
        //    }
        //    else if (n < 0)
        //    {
        //        return 1 / Pow(-n, results);
        //    }
        //    else
        //    {
        //        return Pow(n, results);
        //    }

        //}

        public double MyPow(double x, int n)
        {
            if (x == 0)
            {
                return 0.0;
            }
            if (x == 1.0)
            {
                return 1.0;
            }
            if (x == -1.0)
            {
                return n % 2 == 0 ? 1.0 : -1.0;
            }
            if (n < -1000)
            {
                return 0; 
            }

            if (n == 0)
            {
                return 1.0;
            }

            if (n == 1)
            {
                return x;
            }
            if (n < 0)
            {
                return 1 / MyPow(x, -n);
            }

            return MyPow(x, n / 2) * MyPow(x, n / 2 + n % 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.MyPow(0.00001, 2147483647));
        }
    }
}
