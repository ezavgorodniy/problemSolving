using System;

namespace AToI
{
    class Program
    {

        private static bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        private static int CharToInt(char c)
        {
            return (int)(c - '0');

        }

        private static bool IsSpace(char c)
        {
            return c == ' ';
        }

        private static bool IsMinus(char c)
        {
            return c == '-';
        }

        private static bool IsPlus(char c)
        {
            return c == '+';
        }

        private static bool IsSign(char c)
        {
            return IsMinus(c) || IsPlus(c);
        }

        public static int MyAtoi(string str)
        {
            bool digitFound = false;
            bool minusSign = false;
            int i = 0;
            while (i < str.Length && IsSpace(str[i])) i++;
            if (i < str.Length && IsSign(str[i]))
            {
                minusSign = IsMinus(str[i]);
                i++;
            }

            Int64 result = 0;
            Int64 currentMultiplier = 1;
            while (i < str.Length && IsDigit(str[i]))
            {
                digitFound = true;
                result *= 10;
                result += CharToInt(str[i]);
                if (result > int.MaxValue)
                {
                    return int.MaxValue;
                }
                i++;
            }

            if (!digitFound)
            {
                return 0;
            }
            if (result > int.MaxValue)
            {
                return int.MinValue;
            }
            if (minusSign)
            {
                result = -result;
            }
            if (result < int.MinValue)
            {
                return int.MinValue;
            }


            return (int)result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MyAtoi("2147483648"));
        }
    }
}
