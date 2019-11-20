using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DegreeOfAnArray
{

    public class Solution
    {
        private class Occurence
        {
            public int Amount { get; set; }

            public int Left { get; set; }

            public int Right { get; set; }
        }

        Dictionary<int, Occurence> FindOccurences(int[] nums)
        {
            var result = new Dictionary<int, Occurence>();
            for (int i = 0; i < nums.Length; i++)
            {

                Occurence occurence;
                if (!result.ContainsKey(nums[i]))
                {
                    occurence = new Occurence
                    {
                        Amount = 0,
                        Left = i,
                        Right = -1
                    };
                    result.Add(nums[i], occurence);
                }
                else
                {
                    occurence = result[nums[i]];
                }

                occurence.Amount++;
                occurence.Right = i;
            }
            return result;
        }

        public int FindShortestSubArray(int[] nums)
        {
            var occurences = FindOccurences(nums);
            var degree = 0;
            Occurence resultOccurence = null;
            foreach (var occurence in occurences)
            {
                if (resultOccurence == null)
                {
                    resultOccurence = occurence.Value;
                    continue;
                }

                if (occurence.Value.Amount > resultOccurence.Amount)
                {
                    resultOccurence = occurence.Value;
                    continue;
                }

                if (occurence.Value.Amount == resultOccurence.Amount)
                {
                    if (occurence.Value.Right - occurence.Value.Left + 1 <
                        resultOccurence.Right - resultOccurence.Left + 1)
                    {
                        resultOccurence = occurence.Value;
                    }
                }
            }

            return resultOccurence.Right - resultOccurence.Left + 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> maxValues
        }
    }
}
