using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _678_ValidParenthesis
{
    public class Solution
    {
        public bool CheckValidString(string s)
        {
            int open = 0;
            int close = 0;
            int stars = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    open++;
                }
                if (s[i] == ')')
                {
                    close++;
                }
                if (s[i] == '*')
                {
                    stars++;
                }

                var balance = close - open;
                if (balance > 0 && balance > stars)
                {
                    return false;
                }
            }

            return Math.Abs(close - open) <= stars;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.CheckValidString(
                "(())((())()()(*)(*()(())())())()()((()())((()))(*"));



            // (())((())()()(*)(*()(())())())()()((()())((()))(*
            // ____(________(*)(*()(())())())()()(______________
        }
    }
}
