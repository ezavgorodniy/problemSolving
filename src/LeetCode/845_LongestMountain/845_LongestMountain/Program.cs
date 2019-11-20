using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _845_LongestMountain
{
    public class Solution
    {
        public int LongestMountain(int[] A)
        {
            var curIndex = 1;
            int result = 0;
            int prevSize = -1;
            int curSize = -1;

            while (curIndex < A.Length)
            {
                if (A[curIndex] > A[curIndex - 1])
                {
                    curSize = 1;
                    while (curIndex < A.Length && A[curIndex] > A[curIndex - 1])
                    {
                        curSize++;
                        curIndex++;
                    }

                    if (prevSize != -1)
                    {
                        var potentialResult = prevSize + curSize - 1;
                        if (potentialResult > result)
                        {
                            result = potentialResult;
                        }
                    }
                    prevSize = curSize;
                }
                else if (curIndex < A.Length && A[curIndex] < A[curIndex - 1])
                {
                    curSize = 1;
                    while (curIndex < A.Length && A[curIndex] < A[curIndex - 1])
                    {
                        curSize++;
                        curIndex++;
                    }

                    if (prevSize != -1)
                    {
                        var potentialResult = prevSize + curSize - 1;
                        if (potentialResult > result)
                        {
                            result = potentialResult;
                        }
                    }
                    prevSize = curSize;
                }
                else
                {
                    while (curIndex < A.Length && A[curIndex] == A[curIndex - 1])
                    {
                        curIndex++;
                    }
                    prevSize = -1;
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
            Console.WriteLine(sln.LongestMountain(new[] { 2, 2, 2, 2, 2, 2, 2 }));
            
        }
    }
}
