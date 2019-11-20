using System;
using System.Collections.Generic;

namespace _729_MyCalendar
{
    public class MyCalendar
    {

        private class Interval
        {
            public int Start { get; set; }

            public int End { get; set; }

            public bool Intersect(Interval i)
            {
                if (Start <= i.Start && i.Start < End)
                {
                    return true;
                }
                if (Start < i.End && i.End < End)
                {
                    return true;
                }
                if (i.Start <= Start && i.End > Start)
                {
                    return true;
                }
                return false;
            }

            public override string ToString()
            {
                return $"[{Start}-{End})";
            }
        }

        private readonly List<Interval> _intervals;

        public MyCalendar()
        {
            _intervals = new List<Interval>();

        }

        public bool Book(int start, int end)
        {
            var newInterval = new Interval
            {
                Start = start,
                End = end
            };

            var placeToInsert = FindPlaceToInsert(newInterval);
            if (placeToInsert == _intervals.Count)
            {
                _intervals.Add(newInterval);
            }
            else if (placeToInsert != -1)
            {
                _intervals.Insert(placeToInsert, newInterval);
            }

            return placeToInsert != -1;
        }

        private int FindPlaceToInsert(Interval newInterval)
        {
            if (_intervals.Count == 0)
            {
                return 0;
            }
            var lastInterval = _intervals[_intervals.Count - 1];
            if (lastInterval.End <= newInterval.Start)
            {
                return _intervals.Count;
            }

            var firstInterval = _intervals[0];
            if (firstInterval.Start >= newInterval.End)
            {
                return 0;
            }

            var l = 0;
            var r = _intervals.Count - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                var mInterval = _intervals[m];
                if (mInterval.Intersect(newInterval))
                {
                    return -1;
                }
                if (mInterval.Start < newInterval.Start)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return l;
        }
    }

    /**
     * Your MyCalendar object will be instantiated and called as such:
     * MyCalendar obj = new MyCalendar();
     * bool param_1 = obj.Book(start,end);
     */

    class Program
    {
        static void Main(string[] args)
        {
            var myCalendar = new MyCalendar();
            Console.WriteLine($"{myCalendar.Book(20, 29)} == true");
            Console.WriteLine($"{myCalendar.Book(13, 22)} == false");
            Console.WriteLine($"{myCalendar.Book(44, 50)} == true");
            Console.WriteLine($"{myCalendar.Book(1, 7)} == true");
            Console.WriteLine($"{myCalendar.Book(2, 10)} == false");
            Console.WriteLine($"{myCalendar.Book(14, 20)} == true");
            Console.WriteLine($"{myCalendar.Book(19, 25)} == false");
            Console.WriteLine($"{myCalendar.Book(36, 42)} == true");
            Console.WriteLine($"{myCalendar.Book(45, 50)} == false");
            Console.WriteLine($"{myCalendar.Book(47, 50)} == false");
            Console.WriteLine($"{myCalendar.Book(39, 45)} == false");
            Console.WriteLine($"{myCalendar.Book(44, 50)} == false");
            Console.WriteLine($"{myCalendar.Book(16, 25)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(45, 50)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(12, 20)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(21, 29)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(11, 20)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(12, 17)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(34, 40)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(10, 18)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(38, 44)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(23, 32)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(38, 44)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(15, 20)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(27, 33)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(34, 42)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(44, 50)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(35, 40)} == FALSE");
            Console.WriteLine($"{myCalendar.Book(24, 31)} == FALSE");

        }
    }
}
