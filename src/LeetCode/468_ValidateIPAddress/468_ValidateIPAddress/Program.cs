using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _468_ValidateIPAddress
{
    public class Solution
    {
        private const string NeitherAnswer = "Neither";
        private const string IPv4Answer = "IPv4";
        private const string IPv6Answer = "IPv6";

        private bool ValidateIPv4(string IP)
        {
            var ipParts = IP.Split('.');
            if (ipParts.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < ipParts.Length; i++)
            {
                ValidateIPv4Part(ipParts[i]);
            }
            return true;
        }

        private bool ValidateIPv6(string IP)
        {
            var ipParts = IP.Split(':');
            if (ipParts.Length != 8)
            {
                return false;
            }

            for (int i = 0; i < ipParts.Length; i++)
            {
                if (!ValidateIPv6Part(ipParts[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateIPv6Part(string part)
        {
            if (part.Length > 4)
            {
                return false;
            }
            if (part.Length == 0)
            {
                return false;
            }
            if (part[0] == '0')
            {
                int leadingZeroes = 0;
                for (int i = 0; i < part.Length && part[i] == '0'; i++)
                {
                    leadingZeroes++;
                }
                if (leadingZeroes > 1)
                {
                    return part[part.Length - 1] == '0';
                }
                if (leadingZeroes == 1)
                {
                    return true;
                }
            }
            if (part.Length != 4)
            {
                return false;
            }
            for (int i = 0; i < part.Length; i++)
            {
                if (!IsValidHexadecimal(part[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateIPv4Part(string part)
        {
            int number;
            for (int i = 0; i < part.Length; i++)
            {
                if (part[i] < '0' || part[i] > '9')
                {
                    return false;
                }
            }
            if (!int.TryParse(part, out number))
            {
                return false;
            }

            if (number < 0 || number > 255)
            {
                return false;
            }

            int leadingZeroes = 0;
            for (int i = 0; i < part.Length && part[i] == '0'; i++)
            {
                leadingZeroes++;
            }

            if (leadingZeroes > 0)
            {
                return (leadingZeroes == 1 && number == 0);
            }
            else
            {
                return true;
            }




        }

        private bool IsValidHexadecimal(char c)
        {
            return ('0' <= c && c <= '9') ||
                   ('a' <= c && c <= 'f') ||
                   ('A' <= c && c <= 'F');
        }

        public string ValidIPAddress(string IP)
        {
            if (IP.Contains('.') && ValidateIPv4(IP))
            {
                return IPv4Answer;
            }
            if (IP.Contains(':') && ValidateIPv6(IP))
            {
                return IPv6Answer;
            }
            return NeitherAnswer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.ValidIPAddress(
                "20EE:Fb8:85a3:0:0:8A2E:0370:7334"));
        }
    }
}
