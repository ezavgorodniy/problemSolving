using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _224_BasicCalculator
{
    public class Solution
    {
        public bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        public bool IsSign(char c)
        {
            return c == '-' || c == '+';
        }

        public int CharToInt(char c)
        {
            return (int)c - '0';
        }

        public int Calculate(string s, ref int curIndex, int curValue, Stack<char> operations)
        {
            while (curIndex < s.Length && s[curIndex] == ' ') // skip all spaces
            {
                curIndex++;
            }
            if (curIndex < s.Length && s[curIndex] == '(')
            {
                curIndex++;

                var newValue = 0;
                var stackOperations = new Stack<char>();
                while (curIndex < s.Length && s[curIndex] != ')')
                {
                    newValue = Calculate(s, ref curIndex, newValue, stackOperations);
                }
                curIndex++;

                if (operations.Count != 0)
                {
                    var op = operations.Pop();
                    if (op == '-')
                    {
                        curValue = curValue - newValue;
                    }
                    else
                    {
                        curValue = curValue + newValue;
                    }
                }
                else
                {
                    curValue = newValue;
                }
            }
            while (curIndex < s.Length && s[curIndex] == ' ') // skip all spaces
            {
                curIndex++;
            }
            var d = 0;
            if (curIndex < s.Length && IsDigit(s[curIndex]))
            {
                while (curIndex < s.Length && IsDigit(s[curIndex]))
                {
                    d = d * 10 + CharToInt(s[curIndex]);
                    curIndex++;
                }
                if (operations.Count != 0)
                {
                    var op = operations.Pop();
                    if (op == '-')
                    {
                        curValue = curValue - d;
                    }
                    else
                    {
                        curValue = curValue + d;
                    }
                }
                else
                {
                    curValue = d;
                }
            }
            else if (curIndex < s.Length && IsSign(s[curIndex]))
            {
                operations.Push(s[curIndex]);
                curIndex++;
            }

            return curValue;
        }

        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            s = s.Trim();

            int i = 0;
            int curValue = 0;
            var stackOperations = new Stack<char>();
            while (i < s.Length)
            {
                curValue = Calculate(s, ref i, curValue, stackOperations);
            }
            return curValue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.Calculate("1 + 1") ==2);
             Console.WriteLine(sln.Calculate(" 2-1 + 2 ") == 3);
            Console.WriteLine(sln.Calculate("(1+(4+5+2)-3)+(6+8)") == 23);

            
        }
    }
}
