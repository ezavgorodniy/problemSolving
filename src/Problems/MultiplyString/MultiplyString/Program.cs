using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyString
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.Multiply("140", "721"));
        }
    }
    public class Solution
    {
        private class MyBigInt
        {
            private readonly List<int> _list;

            public MyBigInt(string s)
            {
                _list = ConvertToList(s);
            }

            private MyBigInt(List<int> list)
            {
                _list = list;
            }

            public override string ToString()
            {
                var numberLength = _list.Count;
                var result = new char[numberLength];
                for (int i = 0; i < _list.Count; i++)
                {
                    result[numberLength - i - 1] = (char)(_list[i] + '0');
                }
                return new string(result);
            }

            public MyBigInt Multiply(MyBigInt secondOperator)
            {
                var sumsCount = secondOperator._list.Count;
                var multiplies = new MyBigInt[sumsCount];
                for (int i = 0; i < sumsCount; i++)
                {
                    multiplies[i] = this.Multiply(secondOperator._list[i]);
                }

                var result = new List<int>();
                var r = 0;
                var digitsCount = sumsCount + multiplies[sumsCount - 1]._list.Count;
                for (int i = 0; i < digitsCount; i++)
                {
                    var currentSum = r;
                    var indexFound = false;
                    for (int j = 0; j < sumsCount; j++)
                    {

                        var actualIndex = i - j;
                        if (actualIndex >= 0 && actualIndex < multiplies[j]._list.Count)
                        {
                            currentSum += multiplies[j]._list[actualIndex];
                            indexFound = true;
                        }
                    }
                    if (indexFound)
                    {
                        result.Add(currentSum % 10);
                        r = currentSum / 10;
                    }
                }

                AddRest(result, r);
                return new MyBigInt(result);
            }

            public MyBigInt Multiply(int secondOperator)
            {
                var result = new List<int>(_list.Count);
                var r = 0;
                for (int i = 0; i < _list.Count; i++)
                {
                    var newValue = _list[i] * secondOperator + r;
                    result.Add(newValue % 10);
                    r = newValue / 10;
                }

                AddRest(result, r);
                return new MyBigInt(result);
            }

            private void AddRest(List<int> result, int r)
            {
                while (r != 0)
                {
                    result.Add(r % 10);
                    r /= 10;
                }
            }

            private List<int> ConvertToList(string num)
            {
                var result = new List<int>(num.Length);
                for (int i = num.Length - 1; i >= 0; i--)
                {
                    result.Add(num[i] - '0');
                }
                return result;
            }
        }

        public string Multiply(string num1, string num2)
        {
            var a = new MyBigInt(num1);
            var b = new MyBigInt(num2);
            var result = a.Multiply(b);
            return result.ToString();
        }
    }
}
