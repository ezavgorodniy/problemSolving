using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _315_CountOfSmallerNumbersAfterSelf
{
    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            var result = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            int n = nums.Length;
            var inds = new int[nums.Length];
            var cnt = new int[nums.Length];
            for (int i = 0; i < n; ++i)
            {
                inds[i] = i;
            }
            MergeSort(nums, inds, cnt, 0, n - 1);
            return new List<int>(cnt);
        }

        private void MergeSort(int[] nums, int[] inds, int[] cnt, int lo, int hi)
        {
            if (lo >= hi) return;
            int mid = lo + (hi - lo) / 2;
            MergeSort(nums, inds, cnt, lo, mid);
            MergeSort(nums, inds, cnt, mid + 1, hi);
            Merge(nums, inds, cnt, lo, hi);
        }

        private void Merge(int[] nums, int[] inds, int[] cnt, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            var mid = lo + (hi - lo) / 2;
            var l = lo;
            var r = mid + 1;
            var rCnt = 0;
            var tempInds = new int[hi - lo + 1];
            var ind = lo;
            while (l <= mid || r <= hi)
            {
                if (l <= mid && r <= hi && nums[inds[l]] > nums[inds[r]] || l > mid)
                {
                    tempInds[ind - lo] = inds[r];
                    ++ind;
                    ++r;
                    ++rCnt;
                }
                else
                {
                    tempInds[ind - lo] = inds[l];
                    cnt[inds[l]] += rCnt;
                    ++ind;
                    ++l;
                }
            }
            for (int i = lo; i <= hi; ++i)
            {
                inds[i] = tempInds[i - lo];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var smaller = sln.CountSmaller(new int[] {5, 2, 6, 1});
            foreach (var i in smaller)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
