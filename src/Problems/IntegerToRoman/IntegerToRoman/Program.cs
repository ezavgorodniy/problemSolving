using System;

namespace IntegerToRoman
{
    class Program
    {
        private static readonly char[] Characters = {'I', 'V', 'X', 'L', 'C', 'D', 'M'};

        private static string IntToRomanOneCharacterLastSet(int number, char lastCharacter)
        {
            var resultCharArray = new char[number];
            for (var i = 0; i < number; i++)
            {
                resultCharArray[i] = lastCharacter;
            }
            return new string(resultCharArray);
        }

        private static string IntToRomanOneCharacter(int number, int startSetNumber)
        {
            if (startSetNumber == Characters.Length - 1)
            {
                return IntToRomanOneCharacterLastSet(number, Characters[startSetNumber]);
            }


            if (number == 0)
            {
                return string.Empty;
            }

            var startSetChar = Characters[startSetNumber];
            var secondChar = Characters[startSetNumber + 1];
            var thirdChar = Characters[startSetNumber + 2];

            if (number == 9 || number == 4)
            {
                return new string(new [] {startSetChar, number == 9 ? thirdChar : secondChar});
            }

            bool secondCharPresented = number >= 5;
            if (secondCharPresented)
            {
                number -= 5;
            }

            var resultCharArraySize = secondCharPresented ? number + 1 : number;
            var resultCharArray = new char[resultCharArraySize];
            var startIndex = 0;
            if (secondCharPresented)
            {
                resultCharArray[startIndex] = secondChar;
                startIndex++;
            }
            for (var i = 0; i < number; i++)
            {
                resultCharArray[startIndex + i] = startSetChar;
            }

            return new string(resultCharArray);
        }

        private static string IntToRoman(int num, int startSetNumber)
        {
            if (num == 0)
            {
                return string.Empty;
            }

            return IntToRoman(num / 10, startSetNumber + 2) + IntToRomanOneCharacter(num % 10, startSetNumber);
        }

        public static string IntToRoman(int num)
        {
            return IntToRoman(num, 0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IntToRoman(3));
            Console.WriteLine(IntToRoman(4));
            Console.WriteLine(IntToRoman(9));
            Console.WriteLine(IntToRoman(58));
            Console.WriteLine(IntToRoman(1994));
        }
    }
}
