using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _282_ExpressionAddOperators
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

        private int Calculate(string s)
        {
            var polishNotation = ReversePolishNotation(s);
            return Calculate(polishNotation);
        }

        private void AddOperatorsImpl(string num,
            int target,
            int startIndex,
            Dictionary<string, bool> results)
        {
            if (results.ContainsKey(num))
            {
                return;
            }

            if (startIndex < num.Length - 1)
            {
                AddOperatorsImpl(num, target, startIndex + 1, results);
                AddOperatorsImpl(num.Insert(startIndex + 1, "-"), target, startIndex + 2, results);
                AddOperatorsImpl(num.Insert(startIndex + 1, "+"), target, startIndex + 2, results);
                AddOperatorsImpl(num.Insert(startIndex + 1, "*"), target, startIndex + 2, results);
            }

            if (!results.ContainsKey(num))
            {
                results.Add(num, Calculate(num) == target);
            }
        }

        private bool ValidateNulls(string s)
        {
            int i = 0;
            while (i < s.Length)
            {
                if (s[i] == '0')
                {
                    i++;
                    if (i < s.Length && IsDigit(s[i]))
                    {
                        return false;
                    }
                }
                else
                {
                    i++;
                }
            }
            return true;
        }

        public IList<string> AddOperators(string num, int target)
        {
            var dict = new Dictionary<string, bool>();
            AddOperatorsImpl(num, target, 0, dict);


            Console.WriteLine(num);
            foreach (var subResult in dict.Keys)
            {
                Console.WriteLine(subResult);
            }

            return (from val in dict where val.Value && ValidateNulls(val.Key) select val.Key).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            sln.AddOperators("1234", 213231);
            return;
            RunTest("105", 5);

            RunTest("123", 6);
            RunTest("232", 8);
            RunTest("105", 5);
            RunTest("00", 0);
            RunTest("3456237490", 9191);
        }

        private static void RunTest(string num, int target)
        {
            var sln = new Solution();
            var result = sln.AddOperators(num, target);
            Console.Write($"{num} to get {target}:");
            foreach (var subResult in result)
            {
                Console.Write(" " + subResult);
            }
            Console.WriteLine();

        }
    }
}
