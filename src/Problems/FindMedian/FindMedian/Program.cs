using System;

namespace FindMedian
{
    class Program
    {
        private static int GetNextElement(int[] nums1, ref int curNums1Index, int[] nums2, ref int curNums2Index)
        {
            if (curNums1Index >= nums1.Length && curNums2Index >= nums2.Length)
            {
                throw new IndexOutOfRangeException();
            }
            bool peekFromFirst;
            if (curNums1Index >= nums1.Length)
            {
                peekFromFirst = false;
            }
            else if (curNums1Index >= nums1.Length)
            {
                peekFromFirst = true;
            }
            else
            {
                peekFromFirst = nums1[curNums1Index] < nums2[curNums2Index];
            }

            int result;
            if (peekFromFirst)
            {
                result = nums1[curNums1Index];
                curNums1Index++;
            }
            else
            {
                result = nums2[curNums2Index];
                curNums2Index++;
            }

            return result;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0)
            {
                var medianIndex = nums2.Length / 2;
                if (nums2.Length % 2 == 0)
                {
                    return (nums2[medianIndex - 1] + nums2[medianIndex]) / 2.0;
                }
                else
                {
                    return nums2[medianIndex];
                }
            }
            if (nums2.Length == 0)
            {
                var medianIndex = nums1.Length / 2;
                if (nums1.Length % 2 == 0)
                {
                    return (nums1[medianIndex - 1] + nums1[medianIndex]) / 2.0;
                }
                else
                {
                    return nums1[medianIndex];
                }
            }

            var stopElementIndex = (nums1.Length + nums2.Length) / 2;
            var twoElementsRequired = (nums1.Length + nums2.Length) % 2 == 0;
            if (twoElementsRequired)
            {
                stopElementIndex--;
            }
            int currentMergedIndex = 0;
            int currentFirstIndex = 0;
            int currentSecondIndex = 0;
            int currentElement;
            if (nums1[currentFirstIndex] < nums2[currentSecondIndex])
            {
                currentElement = nums1[currentFirstIndex];
                currentFirstIndex++;
            }
            else
            {
                currentElement = nums2[currentSecondIndex];
                currentSecondIndex++;
            }
            while (currentMergedIndex != stopElementIndex)
            {
                currentElement = GetNextElement(nums1, ref currentFirstIndex, nums2, ref currentSecondIndex);
                currentMergedIndex++;
            }

            if (twoElementsRequired)
            {
                return (currentElement + GetNextElement(nums1, ref currentFirstIndex, nums2, ref currentSecondIndex)) / 2.0;
            }
            else
            {
                return currentElement;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArrays(new int[] {1 }, new int[] {1}));
        }
    }
}
