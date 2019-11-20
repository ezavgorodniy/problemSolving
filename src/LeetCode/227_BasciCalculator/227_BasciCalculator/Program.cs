using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _227_BasciCalculator
{
    public class Solution
    {
        private abstract class PolishNotationToken
        {

        }

        private class PolishNotationTokenOperator : PolishNotationToken
        {
            public PolishNotationTokenOperator(char c)
            {
                Operator = c;
            }

            public char Operator { get; }

            public int OperatorPrecedence
            {
                get
                {
                    if (Operator == '+' || Operator == '-')
                    {
                        return 0;
                    }
                    if (Operator == '*' || Operator == '/')
                    {
                        return 1;
                    }
                    throw new NotImplementedException();
                }
            }

            public static bool IsOperator(char c)
            {
                return c == '+' || c == '-' || c == '*' || c == '/';
            }
        }

        private class PolishNotationTokenNumber : PolishNotationToken
        {
            public PolishNotationTokenNumber(int i) 
            {
                Value = i;
            }

            public int Value { get; }
        }

        private bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        private int CharToInt(char c)
        {
            return c - '0';
        }

        private int PerformOperation(int left, int right, PolishNotationTokenOperator op)
        {
            switch (op.Operator)
            {
                case '+':
                    return left + right;
                case '*':
                    return left * right;
                case '-':
                    return left - right;
                case '/':
                    return left / right;
                default:
                    throw new NotImplementedException();
            }
        }

        private List<PolishNotationToken> ReversePolishNotation(string s)
        {
            var result = new List<PolishNotationToken>();
            var operatorsStack = new Stack<PolishNotationTokenOperator>();
            int i = 0;
            while (i < s.Length)
            {
                if (IsDigit(s[i]))
                {
                    int d = 0;
                    while (i < s.Length && IsDigit(s[i]))
                    {
                        d = d * 10 + CharToInt(s[i]);
                        i++;
                    }
                    result.Add(new PolishNotationTokenNumber(d));
                }
                else if (s[i] == ' ')
                {
                    while (i < s.Length && s[i] == ' ')
                    {
                        i++;
                    }
                }
                else if (PolishNotationTokenOperator.IsOperator(s[i]))
                {
                    var newOperator = new PolishNotationTokenOperator(s[i]);
                    while (operatorsStack.Count != 0 &&
                           operatorsStack.Peek().OperatorPrecedence >= newOperator.OperatorPrecedence)
                    {
                        result.Add(operatorsStack.Pop());
                    }
                    operatorsStack.Push(newOperator);
                    i++;
                }
            }
            while (operatorsStack.Count != 0)
            {
                result.Add(operatorsStack.Pop());
            }

            return result;
        }

        private int Calculate(List<PolishNotationToken> polishNotation)
        {
            var numbersStack = new Stack<int>();
            foreach (var token in polishNotation)
            {
                if (token is PolishNotationTokenNumber numberToken)
                {
                    numbersStack.Push(numberToken.Value);
                }
                else if (token is PolishNotationTokenOperator operatorToken)
                {
                    var right = numbersStack.Pop();
                    var left = numbersStack.Pop();

                    numbersStack.Push(PerformOperation(left, right, operatorToken));
                }
            }

            return numbersStack.Pop();
        }

        public int Calculate(string s)
        {
            var polishNotation = ReversePolishNotation(s);
            return Calculate(polishNotation); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
             var sln = new Solution();
            Console.WriteLine(sln.Calculate(" 3+5 / 2 "));
            
        }
    }
}
