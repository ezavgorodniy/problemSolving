using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSumQueryImmutable
{
    public class NumArray
    {

        private class CacheSumItem
        {
            public int Sum { get; set; }
        }

        private readonly int[] _nums;
        private readonly CacheSumItem[,] _cache;
        private readonly object _cacheLock = new object();


        public NumArray(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException("nums");
            }

            _nums = nums;
            _cache = new CacheSumItem[nums.Length, nums.Length];
        }

        public int SumRange(int i, int j)
        {
            if (_cache[i, j] != null)
            {
                return _cache[i, j].Sum;
            }

            lock (_cacheLock)
            {
                var newCacheItem = new CacheSumItem();
                newCacheItem.Sum = 0;
                while (i <= j)
                {
                    newCacheItem.Sum += _nums[i];
                    i++;
                }


                _cache[i, j] = newCacheItem;
                return newCacheItem.Sum;
            }

        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(i,j);
     */

    class Program
    {
        static void Main(string[] args)
        {
            var obj = new NumArray(new [] {-2, 0, 3, -5, 2, -1});
            Console.WriteLine(obj.SumRange(0, 2));
            Console.WriteLine(obj.SumRange(2, 5));
            Console.WriteLine(obj.SumRange(0, 5));
        }
    }
}
