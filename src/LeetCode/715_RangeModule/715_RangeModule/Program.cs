using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _715_RangeModule
{

    /*public class RangeModule
    {
        SortedList<int, int> sortedList;
        public RangeModule()
        {
            sortedList = new SortedList<int, int>();
        }

        int GetPos(int val)
        {
            var idx = sortedList.BinarySearchKey(val);
            if (idx >= 0) return idx;

            idx = ~idx;
            if (idx > 0 && sortedList.Values[idx - 1] >= val) return idx - 1;
            else return ~idx;
        }

        // [left, right)
        public void AddRange(int left, int right)
        {
            var lidx = GetPos(left);
            if (lidx >= 0) left = sortedList.Keys[lidx];
            else lidx = ~lidx;

            var ridx = GetPos(right);
            if (ridx >= 0) right = sortedList.Values[ridx];
            else ridx = ~ridx - 1;

            for (int i = lidx; i <= ridx; i++) sortedList.RemoveAt(lidx);
            sortedList[left] = right;
        }

        // [left, right)
        public bool QueryRange(int left, int right)
        {
            var lidx = GetPos(left);
            var ridx = GetPos(right);
            return lidx == ridx && lidx >= 0;
        }

        // [left, right)
        public void RemoveRange(int left, int right)
        {
            var lidx = GetPos(left);
            var ridx = GetPos(right);

            if (ridx >= 0)
				sortedList[right] = sortedList.Values[ridx];
            else
				ridx = ~ridx - 1;

            if (lidx >= 0)
            {
                sortedList[sortedList.Keys[lidx]] = left;
                lidx++;
            }
            else
				lidx = ~lidx;

            for (int i = lidx; i <= ridx; i++) sortedList.RemoveAt(lidx);
        }
    }*/

    public static class SortedListEx
    {
        public static int BinarySearchKey<K, V>(this SortedList<K, V> slist, K key)
        {
            if (slist.Count == 0) return ~0;

            int l = 0, r = slist.Count - 1;
            var klist = slist.Keys;
            while (l <= r)
            {
                int c = (l + r) / 2;
                var res = slist.Comparer.Compare(key, klist[c]);
                if (res == 0)
                {
                    return c;
                }

                if (res > 0)
                {
                    l = c + 1;
                }
                else
                {
                    r = c - 1;
                }
            }
            return ~l;
        }
    }

    public class RangeModule
    {
        private readonly SortedList<int, int> _sortedList;

        public RangeModule()
        {
            _sortedList = new SortedList<int, int>();
        }

        private int GetPos(int val)
        {
            var idx = _sortedList.BinarySearchKey(val);
            if (idx >= 0) return idx;

            idx = ~idx;
            return idx > 0 && _sortedList.Values[idx - 1] >= val ? idx - 1 : ~idx;
        }

        public void AddRange(int left, int right)
        {
            var lidx = GetPos(left);
            if (lidx >= 0)
            {
                left = _sortedList.Keys[lidx];
            }
            else
            {
                lidx = ~lidx;
            }

            var ridx = GetPos(right);
            if (ridx >= 0)
            {
                right = _sortedList.Values[ridx];
            }
            else
            {
                ridx = ~ridx - 1;
            }

            for (int i = lidx; i <= ridx; i++)
            {
                _sortedList.RemoveAt(lidx);
            }
            _sortedList[left] = right;
        }

        public bool QueryRange(int left, int right)
        {
            var lidx = GetPos(left);
            var ridx = GetPos(right);
            return lidx == ridx && lidx >= 0;
        }

        public void RemoveRange(int left, int right)
        {
            var lidx = GetPos(left);
            var ridx = GetPos(right);

            if (ridx >= 0)
            {
                _sortedList[right] = _sortedList.Values[ridx];
            }
            else
            {
                ridx = ~ridx - 1;
            }

            if (lidx >= 0)
            {
                _sortedList[_sortedList.Keys[lidx]] = left;
                lidx++;
            }
            else
            {
                lidx = ~lidx;
            }

            for (int i = lidx; i <= ridx; i++)
            {
                _sortedList.RemoveAt(lidx);
            }

        }
    }

    /**
     * Your RangeModule object will be instantiated and called as such:
     * RangeModule obj = new RangeModule();
     * obj.AddRange(left,right);
     * bool param_2 = obj.QueryRange(left,right);
     * obj.RemoveRange(left,right);
     */

    class Program
    {
        static void Main(string[] args)
        {
            var rangeModule = new RangeModule();
            rangeModule.AddRange(10, 20);
            rangeModule.RemoveRange(14, 16);
            Console.WriteLine(rangeModule.QueryRange(10, 14));
            Console.WriteLine(rangeModule.QueryRange(13, 15));
            Console.WriteLine(rangeModule.QueryRange(16, 17));
        }
    }
}
