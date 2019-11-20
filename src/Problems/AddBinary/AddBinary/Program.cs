using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBinary
{

    public class Solution
    {
        public int ConvertToInt(char c)
        {
            return c == '0' ? 0 : 1;
        }

        public char ConvertToChar(int i)
        {
            return (char)(i + '0');
        }

        public void ProcessRest(string s, List<char> res, ref int currentIndex, ref int r)
        {
            while (s.Length - currentIndex - 1 > 0)
            {
                var digit = ConvertToInt(s[currentIndex]) + r;
                r = digit / 2;
                res.Add(ConvertToChar(digit % 2));
                currentIndex++;
            }
        }

        private string PrintRevertedList(List<char> list)
        {
            var result = new char[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                result[i] = list[list.Count - i - 1];
            }
            return new string(result);
        }

        public string AddBinary(string a, string b)
        {
            var result = new List<char>();
            var r = 0;
            int i = 0;
            while (a.Length - i - 1 >= 0 && b.Length - i - 1 >= 0)
            {
                var aDigit = ConvertToInt(a[i]);
                var bDigit = ConvertToInt(b[i]);

                var resDigit = aDigit + bDigit + r;
                r = resDigit / 2;
                result.Add(ConvertToChar(resDigit % 2));
                i++;
            }

            if (a.Length - i - 1 >= 0)
            {
                ProcessRest(a, result, ref i, ref r);
            }
            else if (b.Length - i >= 0)
            {
                ProcessRest(b, result, ref i, ref r);
            }
            if (r != 0)
            {
                result.Add('1');
            }

            return PrintRevertedList(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.AddBinary("11", "1"));
        }
    }
}
