using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686_RepeatedStringMatch
{
    public class Solution
    {
        public int RepeatedStringMatch(string A, string B)
        {
            var result = 0;
            var replacedB = B.Replace(A, "|");
            var firstIndex = replacedB.IndexOf('|');
            var lastIndex = replacedB.LastIndexOf('|');
            if (firstIndex != -1)
            {
                result = lastIndex - firstIndex + 1;
            }

            if (result == replacedB.Length)
            {
                return result;
            }

            if ((A + A).IndexOf(B.Replace("|", "")) == -1)
            {
                return -1;
            }
            else
            {
                return result + 2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.RepeatedStringMatch("abcd", "cdabcdab"));
        }
    }
}
