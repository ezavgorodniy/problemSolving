using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parenthesis
{
    class Program
    {

        public static bool IsOpenParenthesis(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        public static bool IsCloseParenthesis(char c)
        {
            return c == ')' || c == '}' || c == ']';
        }

        public static bool IsParenthesisMatches(char open, char close)
        {
            if (open == '(' && close == ')') return true;
            if (open == '{' && close == '}') return true;
            if (open == '[' && close == ']') return true;
            return false;
        }

        public static bool IsValid(string s)
        {
            Stack<char> openedParenthesis = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (IsOpenParenthesis(s[i]))
                {
                    openedParenthesis.Push(s[i]);
                }
                else if (IsCloseParenthesis(s[i]))
                {
                    if (openedParenthesis.Count <= 0)
                    {
                        return false;
                    }
                    if (!IsParenthesisMatches(openedParenthesis.Pop(), s[i]))
                    {
                        return false;
                    }
                }
            }

            return openedParenthesis.Count == 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("]"));
        }
    }
}
