using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1025_DivisorGame
{
    public class Solution
    {
        public bool DivisorGame(int N)
        {
            if (N == 1)
            {
                return false;
            }
            if (N == 2)
            {
                return true;
            }
            if (N == 3)
            {
                return false;
            }

            var result = new bool[N + 1];
            result[0] = false;
            result[1] = false;
            result[2] = true;

            var aliceStep = true;
            for (int i = 3; i <= N; i++)
            {
                var canWin = false;
                for (int j = 1; j < i; j++)
                {
                    if (N % j == 0 && !result[i - j])
                    {
                        canWin = true;
                        break;
                    }
                }

                if (aliceStep)
                {
                    result[i] = canWin;
                }
                else
                {
                    result[i] = !canWin;
                }

                aliceStep = !aliceStep;
            }

            return result[N];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.DivisorGame(5));
        }
    }
}
