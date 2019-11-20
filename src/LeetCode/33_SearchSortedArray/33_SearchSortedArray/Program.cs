using System;

namespace _33_SearchSortedArray
{
    public class Solution
    {
        public int Search(int[] nums, int l, int r, int target)
        {
            if (nums[l] < nums[r])
            {
                // sorted subsequence
                while (l < r)
                {
                    if (nums[l] > target)
                    {
                        return -1;
                    }
                    if (nums[r] < target)
                    {
                        return -1;
                    }

                    int m = (l + r) / 2;

                    if (nums[m] == target)
                    {
                        return m;
                    }

                    if (nums[m] < target)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }
            }

            if (l == r)
            {
                return nums[l] == target ? l : -1;
            }

            int halfArray = (l + r) / 2;
            int leftHalfSearch = Search(nums, l, halfArray, target);
            if (leftHalfSearch != -1)
            {
                return leftHalfSearch;
            }

            int rightHalfSearch = Search(nums, halfArray + 1, r, target);
            return rightHalfSearch;

        }

        public int SearchPivot(int[] arr, int low, int high)
        {
            // base cases 
            if (high < low)
            {
                return -1;
            }
            if (high == low)
            {
                return low;
            }

            /* low + (high - low)/2; */
            int mid = (low + high) / 2;

            if (mid < high && arr[mid] > arr[mid + 1])
            {
                return mid;
            }

            if (mid > low && arr[mid] < arr[mid - 1])
            {
                return (mid - 1);
            }

            if (arr[low] >= arr[mid])
            {
                return SearchPivot(arr, low, mid - 1);
            }

            return SearchPivot(arr, mid + 1, high);
        }

        public int Search(int[] nums, int target)
        {
            return Search(nums, 0, nums.Length - 1, target);
        }

        public int SearchPivot(int[] nums)
        {
            return SearchPivot(nums, 0, nums.Length - 1);
        }


        private int GetActualIndex(int[] nums, int i)
        {
            return i % nums.Length;
        }

        private int GetItem(int[] nums, int i)
        {
            return nums[GetActualIndex(nums, i)];
        }

        public int FindMin(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            if (nums[0] == nums[nums.Length - 1])
            {
                return nums[0];
            }

            var biggestIndex = SearchPivot(nums, 0, nums.Length - 1);
            if (biggestIndex == -1)
            {
                return nums[0];
            }

            var resultIndex = biggestIndex + 1;
            while (GetActualIndex(nums, resultIndex) != GetActualIndex(nums, biggestIndex) &&
                   GetItem(nums, biggestIndex) == GetItem(nums, resultIndex))
            {
                resultIndex++;
            }
            return nums[GetActualIndex(nums, resultIndex)];

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.FindMin(new[] { 1, 2, 3, 4, 5 }));
            
            //Console.WriteLine(sln.SearchPivot(new[] { 5, 0, 1, 2, 3, 4 }));
            /*Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 4));
            Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 5));
            Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 6));
            Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 7));
            Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 0));
            Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 1));
            Console.WriteLine(sln.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 2));*/
            Console.WriteLine("Hello World!");
        }
    }
}
