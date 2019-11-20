using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _65_ValidNumber
{
    public class Solution
    {
        private bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        private bool IsDelimeter(char c)
        {
            return c == '.' || c == 'e';
        }

        private bool IsValidSign(char c)
        {
            return c == '+' || c == '-';
        }

        public bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            s = s.Trim();
            bool signOccured = false;
            bool firstDigitOccured = false;
            bool digitsAfterEOccured = false;
            bool delimeterOccured = false;
            bool eOccured = false;
            int i = 0;
            while (i < s.Length)
            {
                var c = s[i];
                if (IsDigit(c))
                {
                    if (eOccured)
                    {
                        digitsAfterEOccured = true;
                    }

                    firstDigitOccured = true;
                }
                else if (IsValidSign(c))
                {
                    if ((firstDigitOccured || delimeterOccured || signOccured) &&
                        (!eOccured || digitsAfterEOccured))
                    {
                        return false;
                    }
                    else
                    {
                        signOccured = true;
                    }
                }
                else if (c == 'e' || c == 'E')
                {
                    if (eOccured || !firstDigitOccured)
                    {
                        return false;
                    }
                    else
                    {
                        eOccured = true;
                    }
                }
                else if (c == '.')
                {
                    if (delimeterOccured || eOccured)
                    {
                        return false;
                    }
                    else
                    {
                        delimeterOccured = true;
                    }
                }
                else
                {
                    return false;
                }
                i++;
            }

            if (eOccured)
            {
                return digitsAfterEOccured;
            }
            else
            {
                return firstDigitOccured;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.IsNumber(" 005047e+6"));
        }
    }
}
