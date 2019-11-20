using System;

namespace ValidPalindrome
{
    public class Solution
    {
        private bool IsLowerCaseSymbol(char c)
        {
            return 'a' <= c && c <= 'z';
        }

        private bool IsUpperCaseSymbol(char c)
        {
            return 'A' <= c && c <= 'Z';
        }

        private bool IsSymbol(char c)
        {
            return ('a' <= c && c <= 'z') ||
                   ('A' <= c && c <= 'Z');
        }

        private char ToLowerCase(char c)
        {
            if (IsLowerCaseSymbol(c))
            {
                return c;
            }
            if (IsUpperCaseSymbol(c))
            {
                return (char)(c + 'A' - 'a');
            }

            throw new Exception("Not symbolic");
        }

        public bool IsPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !IsSymbol(s[left]))
                {
                    left++;
                }
                while (left < right && !IsSymbol(s[right]))
                {
                    right--;
                }
                if (left >= right)
                {
                    break;
                }
                if (ToLowerCase(s[left]) != ToLowerCase(s[right]))
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.IsPalindrome("A man, a plan, a canal: Panama"));
        }
    }
}
