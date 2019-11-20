using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace _273_IToEnglish
{
    public class Solution
    {
        private readonly string[] LessThan20 = new[]
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Eleven",
            "Twelve",
            "Thirteen",
            "Fourteen",
            "Fifteen", 
            "Sixteen", 
            "Seventeen",
            "Eighteen",
            "Nineteen"
        };

        private readonly string[] Tens = new[]
        {
            "Twenty",
            "Thirty",
            "Forty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety"
        };

        private const int HundreedsDivisor = 100;
        private const string Hundreeds = "Hundreed";

        private const int ThousandsDivisor = 1000;
        private const string Thousands = "Thousand";

        private const int MillionDivisor = 1000000;
        private const string Million = "Million";

        private const int BillionDivisor = 1000000000;
        private const string Billion = "Billion";

        private string GetLessThan100Word(int num)
        {
            num %= 100;
            if (num < 20)
            {
                return num == 0 ? "" : LessThan20[num];
            }

            var tens = Tens[num / 10 - 2];
            var lastDigit = num % 10;
            return lastDigit != 0 ? tens + " " + LessThan20[lastDigit] : tens;
        }

        private string GetLessThan1000Word(int num)
        {
            string hundreedsStr = null;
            var hundreeds = num / 100;
            if (hundreeds != 0)
            {
                hundreedsStr = GetLessThan100Word(hundreeds) + " " + Hundreeds;
            }

            return !string.IsNullOrEmpty(hundreedsStr)
                ? (num % 100 == 0 ? hundreedsStr : hundreedsStr + " " + GetLessThan100Word(num % 100))
                : GetLessThan100Word(num % 100);
        }

        private string ProcessDivision(ref int num, string word, int divisor)
        {
            if (num >= divisor)
            {
                var value = num / divisor;
                num %= divisor;
                return GetLessThan1000Word(value) + " " + word;
            }

            return "";
        }

        public string NumberToWords(int num)
        {
            var sb = new StringBuilder();
            var billions = ProcessDivision(ref num, Billion, BillionDivisor);
            if (!string.IsNullOrEmpty(billions))
            {
                sb.Append(billions);
            }

            var millions = ProcessDivision(ref num, Million, MillionDivisor);
            if (!string.IsNullOrEmpty(millions))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(millions);
            }

            var thousands = ProcessDivision(ref num, Thousands, ThousandsDivisor);
            if (!string.IsNullOrEmpty(thousands))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(thousands);
            }

            var ones = GetLessThan1000Word(num);
            if (!string.IsNullOrEmpty(ones))
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(ones);
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            /*for (int i = 1; i < 100; i++)
            {
                Console.WriteLine($"{i}\t{sln.NumberToWords(i)}");
            }
            for (int i = 123; i < 10000; i += 100)
            {
                Console.WriteLine($"{i}\t{sln.NumberToWords(i)}");
            }
            Console.WriteLine($"12345\t{sln.NumberToWords(12345)}");
            Console.WriteLine($"1234567\t{sln.NumberToWords(1234567)}");*/
            Console.WriteLine($"1000\t{sln.NumberToWords(1000)}");
        }
    }
}
