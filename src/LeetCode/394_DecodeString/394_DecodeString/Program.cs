using System;
using System.Text;

namespace _394_DecodeString
{
    public class Solution
    {
        private bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }


        private string RepeatPattern(string pattern, int amount)
        {
            var result = "";
            for (int i = 0; i < amount; i++)
            {
                result += pattern;
            }
            return result;
        }

        public string DecodeString(string s, int startIndex, int endIndex)
        {
            var sb = new StringBuilder();
            int index = startIndex;
            while (index <= endIndex)
            {
                var currentStartIndex = index;
                while (index <= endIndex && !IsDigit(s[index]))
                {
                    index++;
                }

                if (index != currentStartIndex)
                {
                    var charArray = new char[index - currentStartIndex];
                    for (int i = currentStartIndex; i < index; i++)
                    {
                        charArray[i - currentStartIndex] = s[i];
                    }
                    sb.Append(new string(charArray));
                }

                if (index > endIndex)
                {
                    break;
                }

                int amount = 0;
                while (IsDigit(s[index]))
                {
                    amount = amount * 10 + (s[index] - '0');
                    index++;
                }

                int patternStart = index + 1;
                int patternEnd = patternStart;
                int parenthesisAmount = 0;
                while (s[patternEnd] != ']' || parenthesisAmount != 0)
                {
                    if (s[patternEnd] == '[')
                    {
                        parenthesisAmount++;
                    }
                    if (s[patternEnd] == ']')
                    {
                        parenthesisAmount--;
                    }
                    patternEnd++;
                }

                var pattern = DecodeString(s, patternStart, patternEnd - 1);
                index = patternEnd + 1;
                sb.Append(RepeatPattern(pattern, amount));
            }

            return sb.ToString();
        }

        public string DecodeString(string s)
        {
            return DecodeString(s, 0, s.Length - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.DecodeString("3[a2[c]]"));
        }
    }
}
