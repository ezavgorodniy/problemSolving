using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _187_RepeatedDNA
{
    public class Solution
    {
        private int NucleotideToNumber(char c)
        {
            switch (c)
            {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                default:
                    throw new NotImplementedException();
            }
        }

        private char NucleotideToChar(int i)
        {
            switch (i)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'C';
                case 2:
                    return 'G';
                case 3:
                    return 'T';
                default:
                    throw new NotImplementedException();

            }
        }

        public string NumberToDnaSequence(int number)
        {
            var result = new char[10];
            for (int i = 0; i < 10; i++, number >>= 2)
            {
                result[i] = NucleotideToChar(number & 3);
            }

            return new string(result);
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            Dictionary<int, List<int>> occured = new Dictionary<int, List<int>>();

            var result = new List<string>();
            if (s.Length < 10)
            {
                return result;
            }

            int curSequence = 0;
            for (int i = 0; i < 10; i++)
            {
                var nucleotideToNumber = NucleotideToNumber(s[i]);
                curSequence |= nucleotideToNumber << (i * 2);
            }

            occured.Add(curSequence, new List<int>(new[] {0}));

            for (int i = 10; i < s.Length; i++)
            {
                curSequence >>= 2;
                var nucleotideToNumber = NucleotideToNumber(s[i]);
                curSequence |= nucleotideToNumber << 18;

                if (occured.ContainsKey(curSequence))
                {
                    occured[curSequence].Add(i - 10);
                }
                else
                {
                    occured.Add(curSequence, new List<int>(new [] {i - 10}));
                }
            }

            foreach (var pair in occured)
            {
                /*bool mayOccurTwice = false;
                for (int i = 0; i < pair.Value.Count && !mayOccurTwice; i++)
                {
                    for (int j = i + 1; j < pair.Value.Count && !mayOccurTwice; j++)
                    {
                        mayOccurTwice = pair.Value[j] - pair.Value[i] + 1 >= 10;
                    }
                }

                if (mayOccurTwice)*/
                if (pair.Value.Count > 1)
                {
                    result.Add(NumberToDnaSequence(pair.Key));
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            /*for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(sln.NumberToDnaSequence(i));
            }
            Console.Read();*/


            var result= sln.FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
            foreach (var dna in result)
            {
                Console.WriteLine(dna);
            }
        }
    }
}
