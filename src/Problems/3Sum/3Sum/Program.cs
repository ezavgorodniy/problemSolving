using System;
using System.Collections.Generic;

namespace _3Sum
{
    public class Solution
    {
        private int IndexOf(int[] sortedArray, int startIndex, int endIndex, int value)
        {
            while (true)
            {
                if (startIndex > endIndex)
                {
                    return -1;
                }

                var midIndex = (endIndex + startIndex) / 2;
                if (sortedArray[midIndex] == value)
                {
                    return midIndex;
                }

                if (sortedArray[midIndex] > value)
                {
                    endIndex = midIndex - 1;
                }
                else
                {
                    startIndex = midIndex + 1;
                }
            }
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var visited = new Dictionary<int, Dictionary<int, bool>>();

            var result = new List<IList<int>>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (visited.ContainsKey(nums[i]))
                {
                    continue;
                }

                var firstElementVisitedDictionary = new Dictionary<int, bool>();
                visited.Add(nums[i], firstElementVisitedDictionary);


                if (nums[i] > 0)
                {
                    break;
                }

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (firstElementVisitedDictionary.ContainsKey(nums[j]))
                    {
                        continue;
                    }
                    firstElementVisitedDictionary.Add(nums[j], true);

                    var searchValue = -(nums[i] + nums[j]);
                    if (searchValue < nums[j])
                    {
                        break;
                    }

                    var indexOf = IndexOf(nums, j + 1, nums.Length - 1, searchValue);
                    if (indexOf != -1)
                    {
                        result.Add(new List<int>(new int[] { nums[i], nums[j], nums[indexOf]}));
                    }
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var resultList = solution.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
            Console.WriteLine("[");
            foreach (var list in resultList)
            {
                Console.Write("\t[");
                foreach (var value in list)
                {
                    Console.Write($"{value}, ");
                }
                Console.WriteLine("],");
            }
            Console.WriteLine("]");
        }
    }
}
