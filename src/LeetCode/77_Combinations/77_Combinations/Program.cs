using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _77_Combinations
{
    public class Solution
    {

        private void GenerateCombinations(int index, int k, int n, int[] current, IList<IList<int>> result)
        {
            if (index == k)
            {
                result.Add(new List<int>(current));
                return;
            }

            int minValue = index + 1;
            if (index != 0)
            {
                minValue = current[index - 1] + 1;
            }

            int minimalElementsRequired = k - index + 1;
            int elementsLeft = n - minValue + 1;
            if (elementsLeft < minimalElementsRequired)
            {
                return;
            }


            for (int i = minValue; i <= n; i++)
            {
                current[index] = i;
                GenerateCombinations(index + 1, k, n, current, result);
            }
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            GenerateCombinations(0, k, n, new int[k], result);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var res = sln.Combine(4, 2);
            foreach (var lst in res)
            {
                foreach (var i in lst)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }
        }
    }
}
