using System;

namespace ZigZagConversion
{
    class Program
    {
        private static void FillWithOneNumber(int rowIndex, int rowNums, string sourceString, char[] charArray, ref int curCharArrayIndex)
        {
            var increment = (rowNums - 1) * 2;
            for (int i = rowIndex; i < sourceString.Length; i += increment, curCharArrayIndex++)
            {
                charArray[curCharArrayIndex] = sourceString[i];
            }
        }

        private static void FillWithTwoNumbers(int rowIndex, int rowNums, string sourceString, char[] charArray, ref int curCharArrayIndex)
        {
            var increment = (rowNums - 1) * 2;
            for (int i = rowIndex; i < sourceString.Length; i += increment, curCharArrayIndex++)
            {
                charArray[curCharArrayIndex] = sourceString[i];

                var newCharIndex = i + (rowNums - rowIndex - 1) * 2;
                if (newCharIndex < sourceString.Length)
                {
                    curCharArrayIndex++;
                    charArray[curCharArrayIndex] = sourceString[newCharIndex];
                }
            }
        }

        static void Main(string[] args)
        {
            string s = "PAYPALISHIRING";
            int numRows = 4;
            var charArray = s.ToCharArray();

            int curCharArrayIndex = 0;
            FillWithOneNumber(0, numRows, s, charArray, ref curCharArrayIndex); 

            for (int rowIndex = 1; rowIndex < numRows - 1; rowIndex++)
            {
                FillWithTwoNumbers(rowIndex, numRows, s, charArray, ref curCharArrayIndex);
            }

            FillWithOneNumber(numRows - 1, numRows, s, charArray, ref curCharArrayIndex);


            Console.WriteLine(new string(charArray));
        }
    }
}
