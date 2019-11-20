using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _166_FractionToRecurringDecimal
{
    public class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException();
            }
            if (numerator == 0)
            {
                return "0";
            }

            var result = new StringBuilder();

            var negative = numerator < 0 && denominator > 0 ||
                           numerator > 0 && denominator < 0;
            if (negative)
            {
                result.Append("-");
            }
            numerator = Unsignify(numerator);
            denominator = Unsignify(denominator);

            result.Append(numerator / denominator);

            var remainder = numerator % denominator;
            if (remainder == 0)
            {
                return result.ToString();
            }
            result.Append(".");

            var occurences = new Dictionary<int, int>();
            var lstIndexes = new List<int>();

            do
            {
                var oldRemainder = remainder; 
                var newNumerator = remainder * 10;
                remainder = newNumerator % denominator;
                if (occurences.ContainsKey(remainder))
                {
                    var firstOccur = occurences[remainder];
                    for (int i = 0; i < firstOccur; i++)
                    {
                        result.Append(lstIndexes[i].ToString());
                    }
                    result.Append("(");
                    for (int i = firstOccur; i < lstIndexes.Count; i++)
                    {
                        result.Append(lstIndexes[i].ToString());
                    }
                    if (newNumerator / denominator != 0 &&
                        lstIndexes[lstIndexes.Count - 1] != newNumerator / denominator)
                    {
                        result.Append(newNumerator / denominator);
                    }
                    result.Append(")");
                    break;
                }
                else
                {
                    occurences.Add(oldRemainder, lstIndexes.Count);
                    lstIndexes.Add(newNumerator / denominator);
                }
            }
            while (remainder != 0);

            if (remainder == 0)
            {
                for (int i = 0; i < lstIndexes.Count; i++)
                {
                    result.Append(lstIndexes[i].ToString());
                }
            }

            return result.ToString();
        }

        private int Unsignify(int i)
        {
            return i < 0 ? -i : i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.FractionToDecimal(4, 333));
        }
    }
}
