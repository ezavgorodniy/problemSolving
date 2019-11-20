using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60_PermutationSequence
{
    public class Solution
    {
        /*public String getPermutation(int n, int k) {
            List<Integer> num = new LinkedList<Integer>();
            for (int i = 1; i <= n; i++) num.add(i);
            int[] fact = new int[n];  // factorial
            fact[0] = 1;
            for (int i = 1; i < n; i++) fact[i] = i*fact[i-1];
            k = k-1;
            StringBuilder sb = new StringBuilder();
            for (int i = n; i > 0; i--){
                int ind = k/fact[i-1];
                k = k%fact[i-1];
                sb.append(num.get(ind));
                num.remove(ind);
            }
            return sb.toString();
        }*/


        public string GetPermutation(int n, int k)
        {
            var num = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                num.Add(i);
            }

            var fact = new int[n];
            fact[0] = 1;
            for (int i = 1; i < n; i++)
            {
                fact[i] = i * fact[i - 1];
            }

            k = k - 1;
            var result = new char[n];
            for (int i = n; i > 0; i--)
            {
                int ind = k / fact[i - 1];
                k = k % fact[i - 1];
                result[n - i] = (char)(num[ind] + '0');
                num.RemoveAt(ind);
            }

            return new string(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            // 3, 3 -   213
            Console.WriteLine(sln.GetPermutation(3, 3));

            // 4, 9 -   2314
            Console.WriteLine(sln.GetPermutation(4, 9));
        }
    }
}
