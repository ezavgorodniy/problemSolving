using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestValidParenthesis
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            int result = 0;
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ')' && stack.Count > 1 && s[stack.Peek()] == '(')
                {
                    stack.Pop();
                    result = Math.Max(result, i - stack.Peek());
                }
                else
                {
                    stack.Push(i);
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
            Console.WriteLine(sln.LongestValidParentheses(")()())"));
        }
    }
}
