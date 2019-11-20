using System;
using System.Collections.Generic;

namespace _264_NThUglyNumber
{
    class Program
    {
        public static int NthUglyNumber(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            var q2 = new Queue<int>();
            q2.Enqueue(2);

            var q3 = new Queue<int>();
            var q5 = new Queue<int>();

            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                var v2 = q2.Count > 0 ? q2.Peek() : int.MaxValue;
                var v3 = q3.Count > 0 ? q3.Peek() : int.MaxValue;
                var v5 = q5.Count > 0 ? q5.Peek() : int.MaxValue;
                result = Math.Min(v2, Math.Min(v3, v5));
                if (result == v2)
                {
                    q2.Dequeue();
                    q2.Enqueue(2 * result);
                    q3.Enqueue(3 * result);
                }
                else if (result == v3)
                {
                    q3.Dequeue();
                    q3.Enqueue(3 * result);
                }
                else if (result == v5)
                {
                    q5.Dequeue();
                }
                q5.Enqueue(5 * result);
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(NthUglyNumber(10));
        }
    }
}
