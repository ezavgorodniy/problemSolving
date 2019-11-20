using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _862_ShortestSubArray
{
    public class Solution
    {
        public int ShortestSubarray(int[] A, int K)
        {
            int l = 0;
            int r = 0;
            int ans = int.MaxValue;
            int curSum = 0;

            while (l < A.Length)
            {
                while (r < A.Length && curSum < K)
                {
                    curSum += A[r];
                    r++;
                }

                if (curSum < K)
                {
                    break;
                }

                while (l < r && curSum >= K)
                {
                    curSum -= A[l];
                    l++;
                }

                var newResult = r - l + 1;
                if (newResult < ans)
                {
                    ans = newResult;
                }
            }

            return ans == int.MaxValue ? -1 : ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.ShortestSubarray(new[] {84, -37, 32, 40, 95}, 167));
        }
    }
}
